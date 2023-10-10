using DrogaBoa.Model;
using DrogaBoa.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DrogaBoa.Controllers
{
    [Route("~/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<Categoria> _categoriaValidator;

        public CategoriaController(ICategoriaService categoriaService, IValidator<Categoria> categoriaValidator)
        {
            _categoriaService = categoriaService;
            _categoriaValidator = categoriaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _categoriaService.GetById(id);

            if(Resposta == null) 
            {
                return NotFound();
            }

            return Ok(Resposta);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> GetByTipo(string tipo)
        {
            return Ok(await _categoriaService.GetByTipo(tipo));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            var validarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);
            }

            await _categoriaService.Create(categoria);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            if(categoria.Id == 0)
            {
                return BadRequest("Id do Categoria é inválido!");
            }

            var validarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);
            }

            var Resposta = await _categoriaService.Update(categoria);

            if(Resposta is null)
            {
                return NotFound("Categoria não encontrada!");
            }

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaTema = await _categoriaService.GetById(id);

            if(BuscaTema is null)
            {
                return NotFound("Categoria não encontrada!");
            }

            await _categoriaService.Delete(BuscaTema);

            return NoContent();
        }
    }
}