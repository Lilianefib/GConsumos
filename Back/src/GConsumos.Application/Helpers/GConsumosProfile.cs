using AutoMapper;
using GConsumos.Application.Dtos;
using GConsumos.Domain;

namespace GConsumos.Application.Helpers
{
    public class GConsumosProfile : Profile
    {
        public GConsumosProfile()
        {
           CreateMap<Morador, MoradorDto>().ReverseMap(); 
           CreateMap<Medidor, MedidorDto>().ReverseMap();
        }
    }
}