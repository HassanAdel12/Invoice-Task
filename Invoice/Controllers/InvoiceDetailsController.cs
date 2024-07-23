using AutoMapper;
using Invoice.Core.DTO;
using Invoice.Core.Interfaces;
using Invoice.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public InvoiceDetailsController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }



        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {
            InvoiceDetails invoiceDetails = unitOfWork.InvoiceDetails.GetById(ID);

            if (invoiceDetails == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(
                        mapper.Map<InvoiceDetailsDTO>
                        (invoiceDetails)
                        );
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(
                    mapper.Map<IEnumerable<InvoiceDetailsDTO>>
                    (unitOfWork.InvoiceDetails.GetAll())
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        [HttpPost]
        public IActionResult Add(InvoiceDetailsDTO invoiceDetailsDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    InvoiceDetails invoiceDetails =
                        unitOfWork.InvoiceDetails
                        .Add(mapper.Map<InvoiceDetails>(invoiceDetailsDTO));


                    unitOfWork.Complete();
                    return Ok(invoiceDetails);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("{ID:int}")]
        public IActionResult Update(InvoiceDetailsDTO invoiceDetailsDTO, int ID)
        {

            if (ModelState.IsValid)
            {

                InvoiceDetails oldInvoiceDetails = unitOfWork.InvoiceDetails.GetById(ID);

                if (oldInvoiceDetails != null)
                {
                    try
                    {
                        invoiceDetailsDTO.lineNo = ID;
                        mapper.Map(invoiceDetailsDTO, oldInvoiceDetails);

                        InvoiceDetails invoiceDetails = unitOfWork.InvoiceDetails
                            .Update(oldInvoiceDetails);

                        unitOfWork.Complete();

                        return Ok(invoiceDetails);


                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete("{ID:int}")]
        public IActionResult Delete(int ID)
        {

            InvoiceDetails invoiceDetails = unitOfWork.InvoiceDetails.GetById(ID);

            if (invoiceDetails != null)
            {
                try
                {

                    unitOfWork.InvoiceDetails.Delete(invoiceDetails);

                    unitOfWork.Complete();

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return NotFound();
            }


        }

    }
}
