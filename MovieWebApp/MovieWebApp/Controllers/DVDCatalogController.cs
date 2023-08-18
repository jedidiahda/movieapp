using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DVDCatalogController : ControllerBase
    {
        private readonly DVDCatalogService _dVDCatalogService;

        public DVDCatalogController(IDVDCatalogRepository dVDCatalogRepository)
        {
            _dVDCatalogService = new DVDCatalogService(dVDCatalogRepository);
        }

        [HttpGet]
        public IActionResult Get(string? title, int limit = 10, int pageNumber = 1)
        {
            return Ok(_dVDCatalogService.GetAll(title ?? "", limit, pageNumber));
        }

        // GET api/<DVDCatalogController>/5
        [HttpGet("{DVDCatalogId}")]
        public IActionResult Get(int DVDCatalogId)
        {
            return Ok(_dVDCatalogService.GetById(DVDCatalogId));
        }

        [HttpPost]
        public IActionResult Post(DVDCatalogDTO dVDCatalogDTO)
        {
            try
            {
                _dVDCatalogService.Save(dVDCatalogDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{DVDCatalogId}")]
        public IActionResult Put(int DVDCatalogId, DVDCatalogDTO dVDCatalogDTO)
        {
            try
            {
                _dVDCatalogService.Update(DVDCatalogId, dVDCatalogDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{dvdCatalogId}")]
        public IActionResult Delete(int dvdCatalogId)
        {
            if (_dVDCatalogService.GetById(dvdCatalogId) == null)
            {
                return NotFound("DVD Catalog not found");
            }
            if (_dVDCatalogService.Delete(dvdCatalogId) == true)
            {
                return Ok();
            }

            return Ok();
        }

        [HttpGet]
        [Route("{dvdCatalogId}/dvdcopy")]
        public IActionResult GetDvdCopies(int dvdCatalogId, string? code, int limit,int pageNumber)
        {
            try
            {
                return Ok(_dVDCatalogService.GetDVDCopies(dvdCatalogId,code, limit, pageNumber));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{dvdCatalogId}/dvdcopy/{code}")]
        public IActionResult GetDvdCopy(string code)
        {
            return Ok(_dVDCatalogService.GetDvdcopy(code));
        }

        [HttpPost]
        [Route("{dvdCatalogId}/dvdcopy")]
        public IActionResult AddDvdCopy(int dvdCatalogId,DvdcopyDTO dvdcopyDTO)
        {
            try
            {
                _dVDCatalogService.AddDVDCopy(dvdCatalogId, dvdcopyDTO);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("dvdcopy/{dvdCopyId}")]
        public IActionResult UpdateDvdCopy(int dvdCopyId,DvdcopyDTO dvdcopyDTO)
        {
            try
            {
                var dvdCopy = _dVDCatalogService.UpdateDvdCopy(dvdCopyId, dvdcopyDTO);
                if (dvdCopy != null) return Ok();
                else return NotFound("DVD code not found");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("dvdcopy/{dvdCopyId}")]
        public IActionResult DeleteDvdCopy(int dvdCopyId)
        {
            try
            {
                if(_dVDCatalogService.GetDvdcopy(dvdCopyId) == null)
                {
                    return NotFound("Dvd code not found");
                }
                _dVDCatalogService.DeleteDVDCopy(dvdCopyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
