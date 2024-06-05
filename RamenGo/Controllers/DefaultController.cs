using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RamenGo.Domain.DTO;
using RamenGo.Domain.Entities;
using RamenGo.Domain.Interfaces;

namespace RamenGo.Controllers;

[ApiController]
[Route("[controller]")]
public class DefaultController : ControllerBase
{
    private readonly IBrothRepository _brothRepository;
    private readonly IProteinRepository _proteinRepository;
    private readonly IOrderRepository _orderRepository;    
    public DefaultController(IBrothRepository brothRepository, IProteinRepository proteinRepository, IOrderRepository orderRepository)
    {
        _brothRepository = brothRepository;
        _proteinRepository = proteinRepository;
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// List of all available broths
    /// </summary>
    /// <response code="201">A list of broths</response> 
    /// <response code="403">Forbiden</response>    
    [ApiKey]
    [HttpGet("/broths")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]     
    public async Task<ActionResult<Broth>> ListBroths()
    {
        var broths = await _brothRepository.GetAsync();
        return StatusCode(201, broths);
    }
    /// <summary>
    /// List of all available proteins
    /// </summary>
    /// <response code="201">A list of proteins</response> 
    /// <response code="403">Forbiden</response>      
    [ApiKey]
    [HttpGet("/proteins")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)] 
    public async Task<ActionResult<Protein>> ListProteins()
    {
        var proteins = await _proteinRepository.GetAsync();
        return StatusCode(201, proteins);
    }

    /// <summary>
    /// Place an order
    /// </summary>
    /// <response code="201">Order placed successfully</response>
    /// <response code="400">Invalid request</response>    
    /// <response code="403">Forbiden</response>    
    /// <response code="500">Internal server error</response>    
    [ApiKey]
    [HttpPost("/orders")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderResponse>> PlaceOrder([FromBody] OrderRequest orderRequest)
    {
        try
        {
            OrderResponse orderResponse = await _orderRepository.PlaceOrder(orderRequest.BrothId, orderRequest.ProteinId);
            return StatusCode(201, orderResponse);
            
        }catch(Exception)
        {
            ErrorResponse errorResponse = new ErrorResponse("could not place order");
            return StatusCode(500, errorResponse);
        }
    }

}
