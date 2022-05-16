using AlunoAPI.Data.Dto;
using AlunoAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlunoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpPost]
        public IActionResult AdicionaAluno([FromBody] CreateAlunoDto dto)
        {
            ReadAlunoDto readDto = _alunoService.AdicionaAluno(dto);
            return CreatedAtAction(nameof(RecuperaAlunoPorId), new { Id = readDto.Id }, readDto);

        }
        [HttpGet]
        public IActionResult RecuperaTodosOsAlunos()
        {
            List<ReadAlunoDto> readDto = _alunoService.RecuperaTodosOsALunos();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaAlunoPorId(int id)
        {
            ReadAlunoDto readDto = _alunoService.RecuperaAlunoPorId(id);
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaAluno(int id, [FromBody] UpdateAlunoDto alunoDto)
        {
            Result resultado = _alunoService.AtualizaAluno(id, alunoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaAluno(int id)
        {
            Result resultado = _alunoService.DeletaAluno(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
