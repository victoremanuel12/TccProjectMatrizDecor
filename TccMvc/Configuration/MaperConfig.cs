using AutoMapper;
using TccMvc.Models;
using TccMvc.ViewModel;

namespace TccMvc.Configuration
{
    public class MaperConfig : Profile
    {
        public MaperConfig()
        {
            CreateMap<AluguelProduto, Produto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Produto.Nome))
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Produto.Preco))
                .ForMember(dest => dest.ImagemUrl, opt => opt.MapFrom(src => src.Produto.ImagemUrl));

            CreateMap<Aluguel, HistoricoAlugueisViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Cliente.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Cliente.Email))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Cliente.CEP))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Cliente.Bairro))
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Cliente.Rua))
                .ForMember(dest => dest.DataInicial, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal))
                .ForMember(dest => dest.AluguelId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.AluguelProdutos)

                );
        }
    }
}
