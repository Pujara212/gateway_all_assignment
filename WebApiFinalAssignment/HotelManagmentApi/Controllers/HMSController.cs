using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMS.BAL.Interface;
using HMS.Models;

namespace HotelManagmentApi.Controllers
{
    public class HMSController : ApiController
    {
        // GET: api/HMS

        private readonly IHotelManager _hotelManager;

        public HMSController(IHotelManager hotelManager)
        {
           _hotelManager = hotelManager;
        }


        public List<HotelModel> GetHotels()
        {
            return _hotelManager.GetAllHotels();
        }

        // GET: api/HMS/5
        public HotelModel Get(int id)
        {
            return _hotelManager.GetHotel(id);
        }

        // POST: api/HMS
        public string Post([FromBody]HotelModel value)
        {
            return _hotelManager.CreateHotel(value);
        }

        // PUT: api/HMS/5
        public string Put( [FromBody]HotelModel value)
        {
            return _hotelManager.UpdateHotel(value);
        }

        // DELETE: api/HMS/5
        public void Delete(int id)
        {
        }
    }
}
