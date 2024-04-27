using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("pedidos-seis-meses/{id:int}")]
        public IActionResult ClienteEPedidosSeisMeses([FromRoute] int id)
        {
            try
            {
                var x = _clienteRepository.ObterPedidosSeisMeses(id);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
