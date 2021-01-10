using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.DAL.Repository;
using HMS.Models;

namespace HMS.BAL.Interface
{
   public class HotelManager : IHotelManager
    {
        private readonly IHotelRepo _hotelRepo;

        public HotelManager(IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public string BookRoom(BookModel model)
        {
            return _hotelRepo.BookRoom(model);
        }

        public string CreateHotel(HotelModel model)
        {
           return  _hotelRepo.CreateHotel(model);
        }

        public string CreateRoom(RoomModel model)
        {
            return _hotelRepo.CreateRoom(model);
        }

        public string DeleteBookRoom(int Id)
        {
            return _hotelRepo.DeleteBookRoom(Id);
        }

        public List<HotelModel> GetAllHotels()
        {
            return _hotelRepo.GetAllHotels();
        }

        public BookModel GetBookRoom(int Id)
        {
            return _hotelRepo.GetBookRoom(Id);
        }

        public List<BookModel> GetBookRooms()
        {
            return _hotelRepo.GetBookRooms();   
        }

        public HotelModel GetHotel(int id)
        {
            return _hotelRepo.GetHotel(id);
        }

        public RoomModel GetRoom(int Id)
        {
            return _hotelRepo.GetRoom(Id);
        }

        public List<RoomModel> GetRooms()
        {
            return _hotelRepo.GetRooms();
        }

        public string UpdateBookRoom(BookModel model)
        {
            return _hotelRepo.UpdateBookRoom(model);
        }

        public string UpdateHotel(HotelModel model)
        {
            return _hotelRepo.UpdateHotel(model);
        }

        public string UpdateRoom(RoomModel model)
        {
            return _hotelRepo.UpdateRoom(model);
        }
    }
}
