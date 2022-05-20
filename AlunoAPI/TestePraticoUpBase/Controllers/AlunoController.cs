using AlunoAPI.Data.Dto;
using AlunoAPI.Models;
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







        /// <response code="201">Student created with success.</response>
        /// <response code="400">This error occurs when the requesition fields are not filled within the required format, 
        /// or the student email/username already exists in the database.</response>
        /// <response code="500">Server error.</response>
        /// <summary>Insert a student into the database.</summary>
        /// <remarks>
        /// Requisition example:
        ///
        ///     {
        ///        "id": 0,
        ///        "nomeCompleto": "João da Silva",
        ///        "nomeDeUsuario ": "joaodasilva",
        ///        "email": "email@email.com.br",
        ///        "password":"Senha123!"
        ///     }
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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
                return Problem(detail: ex.GetBaseException().Message);
            }
        }






        /// <response code="200">Data recovered Successfully.</response>
        /// <response code="404">Empty database.</response>
        /// <response code="500">Server error.</response>
        /// <summary>Access all database information.</summary>
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpGet]
        public IActionResult RecuperaTodosOsAlunos()
        {
            try
            {
                List<ReadAlunoDto> readDto = _alunoService.RecuperaTodosOsALunos();
                if (readDto.Count == 0) return NotFound();
                return Ok(readDto);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
            
        }







        /// <response code="200">Data recovered Successfully.</response>
        /// <response code="404">Invalid ID.</response>
        /// <response code="500">Server error.</response>
        /// <summary>Using ID, access information from a specific student.</summary>
        /// <param name="id" example ="0"></param>
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpGet("{id}")]
        public IActionResult RecuperaAlunoPorId(int id)
        {
            try
            {
                ReadAlunoDto readDto = _alunoService.RecuperaAlunoPorId(id);
                if (readDto == null) return Problem(detail: "The required ID was not found in the database.", title:"Bad Request", statusCode: 404);
                return Ok(readDto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }








        /// <response code="200">Information updated successfully.</response>
        /// <response code="400">This error occurs when the requesition fields are not filled within the required format.</response>
        /// <response code="404">Invalid ID.</response>
        /// <response code="500">Server error.</response>
        /// <summary>Using ID, enables to update information from a specific student.</summary>
        /// <param name="id" example ="0"></param>
        /// <remarks>
        /// Requisition example:
        ///
        ///     {
        ///        "nomeCompleto": "João da Silva",
        ///        "nomeDeUsuario ": "newusername",
        ///        "email": "email@email.com.br",
        ///        "password":"Senha123!"
        ///     }
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Aluno), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpPut("{id}")]
        public IActionResult AtualizaAluno(int id, [FromBody] UpdateAlunoDto alunoDto)
        {
            try
            {
                Aluno resultado = _alunoService.AtualizaAluno(id, alunoDto);
                if (resultado == null) return Problem(detail:"Invalid ID", title: "Bad Request", statusCode: 400);
                return Ok(resultado);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }








        /// <response code="204">Student deleted successfully.</response>
        /// <response code="404">Invalid ID.</response>
        /// <response code="500">Server error.</response>
        /// <summary> Using ID, enables to delete a specific student.</summary>
        /// <param name="id" example ="0"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]

        [HttpDelete("{id}")]
        public IActionResult DeletaAluno(int id)
        {
            try
            {
                Result resultado = _alunoService.DeletaAluno(id);
                if (resultado.IsFailed) return Problem(detail: "Invalid ID", title: "Bad Request", statusCode: 404);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }
    }
}
