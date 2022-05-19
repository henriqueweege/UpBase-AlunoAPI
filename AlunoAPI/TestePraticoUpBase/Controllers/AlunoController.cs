using AlunoAPI.Data.Dto;
using AlunoAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        /// <response code="201">Aluno criado com sucesso.</response>
        /// <response code="400">Erro ocorre caso os campos não estejam preenchidos de maneira válida.</response>
        /// <summary>
        /// Este método permite cadastrar um novo aluno no bando de dados.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     {
        ///        "NomeCompleto": "João da Silva",
        ///        "NomeDeUsuario ": "joaodasilva",
        ///        "Email": "email@email.com.br",
        ///        "Password":"Senha123!"
        ///     }
        ///
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult AdicionaAluno([FromBody] CreateAlunoDto dto)
        {
            try
            {
                ReadAlunoDto readDto = _alunoService.AdicionaAluno(dto);
                return CreatedAtAction(nameof(RecuperaAlunoPorId), new { Id = readDto.Id }, readDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

        }






        /// <response code="200">Alunos recuperados com sucesso.</response>
        /// <response code="404">Banco de dados vazio.</response>
        /// <summary>
        ///  Este método permite recuperar os dados de todos os alunos.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult RecuperaTodosOsAlunos()
        {
            List<ReadAlunoDto> readDto = _alunoService.RecuperaTodosOsALunos();
            if (readDto.Count == 0) return NotFound();
            return Ok(readDto);
        }







        /// <response code="200">Aluno recuperado com sucesso.</response>
        /// <response code="404">ID inválido.</response>
        /// <summary>
        ///  Este método permite recuperar os dados do aluno a partir do seu ID.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult RecuperaAlunoPorId(int id)
        {
            ReadAlunoDto readDto = _alunoService.RecuperaAlunoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }








        /// <response code="204">Cadastro alterado com sucesso.</response>
        /// <response code="404">ID inválido.</response>
        /// <summary>
        ///  Este método permite editar o cadastro do aluno a partir do seu ID.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public IActionResult AtualizaAluno(int id, [FromBody] UpdateAlunoDto alunoDto)
        {
            Result resultado = _alunoService.AtualizaAluno(id, alunoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }








        /// <response code="204">Cadastro excluído com sucesso.</response>
        /// <response code="404">ID inválido.</response>
        /// <summary>
        /// Este método permite deletar o cadastro do aluno a partir do seu ID.
        /// </summary>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public IActionResult DeletaAluno(int id)
        {
            Result resultado = _alunoService.DeletaAluno(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
