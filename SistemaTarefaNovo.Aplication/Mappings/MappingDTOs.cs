using AutoMapper;
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.Mappings
{
    public class MappingDTOs : Profile
    {

        public MappingDTOs()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
        }


    }
}
