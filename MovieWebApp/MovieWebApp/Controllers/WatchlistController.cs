using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Repository;
using MovieWebApp.Service;
using MovieWebApp.Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly WatchlistService _watchlistService;

        public WatchlistController(IWatchlistRepository watchlistRepository)
        {
            _watchlistService = new WatchlistService(watchlistRepository);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get(int customerId)
        {
            return Ok(_watchlistService.GetAll(customerId));
        }

        // GET api/<WatchlistController>/5
        [HttpGet]
        public IActionResult Get(int customerId,int watchlistId)
        {
            return Ok(_watchlistService.Get(customerId,watchlistId));
        }

        // POST api/<WatchlistController>
        [HttpPost]
        public IActionResult Post([FromBody] WatchlistDTO watchlistDTO)
        {
            try
            {
                return Ok(_watchlistService.Save(watchlistDTO));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<WatchlistController>/5
        [HttpPut]
        [Route("UpdateRank")]
        public IActionResult Put(int customerId,int dvdcatalogId, int rank)
        {
            try
            {
                var watchlistDTO = new WatchlistDTO();
                watchlistDTO.CustomerId = customerId;
                watchlistDTO.DvdcatalogId = dvdcatalogId;
                watchlistDTO.Rank = rank;
                return Ok(_watchlistService.Update(WatchlistAdapter.GetWatchlist(watchlistDTO)));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int customerId,int dvdCatalogId)
        {
            try
            {
                _watchlistService.Delete(customerId, dvdCatalogId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
