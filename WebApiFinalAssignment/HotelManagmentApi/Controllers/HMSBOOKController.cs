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
    public class HMSBOOKController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HMSBOOKController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/HMSBOOK
        public List<BookModel> Get()
        {
            return _hotelManager.GetBookRooms(); ;
        }

        // GET: api/HMSBOOK/5
        public BookModel Get(int id)
        {
            return _hotelManager.GetBookRoom(id);
        }
        // POST: api/HMSBOOK
        public string Post([FromBody]BookModel value)
        {
            return _hotelManager.BookRoom(value);
        }

        // PUT: api/HMSBOOK/5
        public string Put( [FromBody]BookModel value)
        {
            return _hotelManager.UpdateBookRoom(value);
        }

        // DELETE: api/HMSBOOK/5
        public string Delete(int id)
        {
            return _hotelManager.DeleteBookRoom(id);
        }
    }
}
