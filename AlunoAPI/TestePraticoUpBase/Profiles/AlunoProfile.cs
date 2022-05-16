using AlunoAPI.Data.Dto;
using AlunoAPI.Models;
using AutoMapper;

namespace AlunoAPI.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<CreateAlunoDto, Aluno>();
            CreateMap<Aluno, CreateAlunoDto>();
            CreateMap<Aluno, UpdateAlunoDto>();
            CreateMap<UpdateAlunoDto, Aluno>();
            CreateMap<Aluno, ReadAlunoDto>();
            CreateMap<ReadAlunoDto, Aluno>();

        }
    }
}
