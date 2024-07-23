using AutoMapper;
using Invoice.Core.DTO;
using Invoice.Core.Model;
using System.Threading.Channels;

namespace Invoice.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {


            CreateMap<InvoiceDetails, InvoiceDetailsDTO>().ReverseMap();

            CreateMap<Unit, UnitDTO>().ReverseMap();

         




        }
    }
}
