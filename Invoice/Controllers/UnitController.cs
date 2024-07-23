using AutoMapper;
using Invoice.Core.DTO;
using Invoice.Core.Interfaces;
using Invoice.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace Invoice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public UnitController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }



        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {
            Unit unit = unitOfWork.Units.GetById(ID);

            if (unit == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(
                        mapper.Map<UnitDTO>
                        (unit)
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
                    mapper.Map<IEnumerable<UnitDTO>>
                    (unitOfWork.Units.GetAll())
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        [HttpPost]
        public IActionResult Add(UnitDTO unitDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Unit unit =
                        unitOfWork.Units
                        .Add(mapper.Map<Unit>(unitDTO));


                    unitOfWork.Complete();
                    return Ok(unit);

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
        public IActionResult Update(UnitDTO unitDTO, int ID)
        {

            if (ModelState.IsValid)
            {

                Unit oldUnit = unitOfWork.Units.GetById(ID);

                if (oldUnit != null)
                {
                    try
                    {
                        unitDTO.unitNo = ID;
                        mapper.Map(unitDTO, oldUnit);

                        Unit unit = unitOfWork.Units
                            .Update(oldUnit);

                        unitOfWork.Complete();

                        return Ok(unit);


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

            Unit unit = unitOfWork.Units.GetById(ID);

            if (unit != null)
            {
                try
                {

                    unitOfWork.Units.Delete(unit);

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
