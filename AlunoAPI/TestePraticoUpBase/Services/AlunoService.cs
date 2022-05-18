using AlunoAPI.Data;
using AlunoAPI.Data.Dto;
using AlunoAPI.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlunoAPI.Services
{
    public class AlunoService
    {
        private IMapper _mapper;
        private AlunoContext _context;
        private SecurityService _secutiry;

        public AlunoService(AlunoContext context, IMapper mapper, SecurityService secutiry)
        {
            _context = context;
            _mapper = mapper;
            _secutiry = secutiry;
        }
        
        public ReadAlunoDto AdicionaAluno(CreateAlunoDto dto)
        {

            Aluno aluno = _mapper.Map<Aluno>(dto);
            aluno.Password = _secutiry.CriptografaSenha(aluno.Password);
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
            return _mapper.Map<ReadAlunoDto>(aluno);
        }

        public List<ReadAlunoDto> RecuperaTodosOsALunos()
        {
            List<Aluno> aluno = _context.Aluno.ToList();
            if(aluno == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadAlunoDto>>(aluno);
        }

        public ReadAlunoDto RecuperaAlunoPorId(int id)
        {
            Aluno aluno = _context.Aluno.FirstOrDefault(aluno => aluno.Id == id);
            if(aluno != null)
            {
                return _mapper.Map<ReadAlunoDto>(aluno);
            }
            return null;
        }

        public Result AtualizaAluno(int id, UpdateAlunoDto alunoDto)
        {
            Aluno aluno = _context.Aluno.FirstOrDefault(aluno => aluno.Id == id);
            if(aluno == null)
            {
                return Result.Fail("Aluno não encontrado");
            }
            _mapper.Map(alunoDto, aluno);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaAluno(int id)
        {
            Aluno aluno = _context.Aluno.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null)
            {
                return Result.Fail("Aluno não encontrado");
            }
            _context.Remove(aluno);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
