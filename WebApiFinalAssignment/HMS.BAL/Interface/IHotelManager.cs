using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {

        List<HotelModel> GetAllHotels();

        HotelModel GetHotel(int id);

        string CreateHotel(HotelModel model);

        string UpdateHotel(HotelModel model);



        RoomModel GetRoom(int Id);
        List<RoomModel> GetRooms();
        string CreateRoom(RoomModel model);
        string UpdateRoom(RoomModel model);
 






        BookModel GetBookRoom(int Id);
        List<BookModel> GetBookRooms();
        string BookRoom(BookModel model);
        string UpdateBookRoom(BookModel model);
        string DeleteBookRoom(int Id);


    }
}
