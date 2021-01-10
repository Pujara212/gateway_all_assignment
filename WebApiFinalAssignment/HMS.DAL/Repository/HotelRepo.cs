using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.DAL.Repository
{
    public class HotelRepo : IHotelRepo
    {

        private readonly DataBase.HMSEntities dbcontext;

        public HotelRepo()
        {
            dbcontext = new DataBase.HMSEntities();
        }

        public string CreateHotel(HotelModel item)
        {

            try
            {
                if (item != null)
                {
                    DataBase.Hotel hotel = new DataBase.Hotel();


                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = DateTime.Now;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive =item.IsActive;

                    dbcontext.Hotels.Add(hotel);
                    dbcontext.SaveChanges();

                    return "Hotel Added SuccesFully";
                }
                return "Data Is Not There!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            

        }

        public List<HotelModel> GetAllHotels()
        {
            List<HotelModel> list = new List<HotelModel>();

            var data = dbcontext.Hotels.OrderBy(x => x.HotelName).ToList();

            if (data != null)
            {
                foreach (var item in data)
                {
                    HotelModel hotel = new HotelModel();

                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = item.CreateDate;
                    hotel.UpdateDate = item.UpdateDate;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;

                    list.Add(hotel);
                }

            }
                return list;
        }

        public HotelModel GetHotel(int id)
        {
            try
            {
                var item = dbcontext.Hotels.Find(id);
                if (item !=null)
                {
                    HotelModel hotel = new HotelModel();

                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreateDate = item.CreateDate;
                     hotel.UpdatedBy = item.UpdatedBy;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;

                    return hotel;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
        public string UpdateHotel(HotelModel model)
        {
             try
            {
                var item = dbcontext.Hotels.Find(model.Hotel_Id);
                if (item != null)
                {
                    DataBase.Hotel hotel = new DataBase.Hotel();


                    hotel.Hotel_Id = item.Hotel_Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.ContactNumer = item.ContactNumer;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;
                    hotel.UpdateDate = item.UpdateDate;
                    hotel.UpdatedBy = item.UpdatedBy;

                    dbcontext.SaveChanges();

                    return "Hotel Updated SuccesFully";
                }
                return "Data Is Not There!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }












        public string CreateRoom(RoomModel entity)
        {
            try
            {
                if (entity != null)
                {
                   DataBase.Room dealer = new DataBase.Room();

                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.RoomName = entity.RoomName;
                    dealer.Category = entity.Category;
                    dealer.Price = entity.Price;
                    dealer.IsActive = entity.IsActive;
                    dealer.CreateDate = DateTime.Now;
                    dealer.CreatedBy = entity.CreatedBy;

                    dbcontext.Rooms.Add(dealer);
                    dbcontext.SaveChanges();

                    return "Successfully added Room!";
                }

                return "Model is null!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
         
        public List<RoomModel> GetRooms()
        {
            var entities = dbcontext.Rooms.ToList();

            List<RoomModel> list = new List<RoomModel>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    RoomModel dealer = new RoomModel();

                    ///TODO: Problem why manually?                     
                    dealer.Hotel_Id = item.Hotel_Id;
                    dealer.RoomName = item.RoomName;
                    dealer.Category = item.Category;
                    dealer.IsActive = item.IsActive;
                    dealer.Price = item.Price;
                    dealer.CreateDate = item.CreateDate;
                    dealer.UpdateDate = item.UpdateDate;
                    dealer.IsActive = item.IsActive;
                    dealer.CreatedBy = item.CreatedBy;
                    dealer.UpdatedBy = item.UpdatedBy;

                    list.Add(dealer);

                }
            }


            return list;

        }


        public RoomModel GetRoom(int Id)
        {
            var item = dbcontext.Rooms.Find(Id);


            RoomModel dealer = new RoomModel();

            if (item != null)
            {
                ///TODO: Problem why manually?                     
                ///TODO: Problem why manually?                     
                dealer.Hotel_Id = item.Hotel_Id;
                dealer.RoomName = item.RoomName;
                dealer.Category = item.Category;
                dealer.IsActive = item.IsActive;
                dealer.Price = item.Price;
                dealer.CreateDate = item.CreateDate;
                dealer.UpdateDate = item.UpdateDate;
                dealer.IsActive = item.IsActive;
                dealer.CreatedBy = item.CreatedBy;
                dealer.UpdatedBy = item.UpdatedBy;


            }

            return dealer;
        }


        public string UpdateRoom(RoomModel item)
        {
            try
            {
                var dealer = dbcontext.Rooms.Find(item.Hotel_Id);

                if (item != null)
                {
                    dealer.Hotel_Id = item.Hotel_Id;
                    dealer.RoomName = item.RoomName;
                    dealer.Category = item.Category;
                    dealer.IsActive = item.IsActive;
                    dealer.Price = item.Price;
                     dealer.UpdateDate = DateTime.Now;
                    dealer.IsActive = item.IsActive;
                     dealer.UpdatedBy = item.UpdatedBy;


                    dbcontext.SaveChanges();

                    return "Updated Room!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }




        public string BookRoom(BookModel entity)

        {
            try
            {
                if (entity != null)
                {
                    DataBase.Book dealer = new DataBase.Book();

                    dealer.Booking_Id = entity.Booking_Id;
                     dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;
                    
                    dbcontext.Books.Add(dealer);
                    dbcontext.SaveChanges();

                    return "Successfully Book!";
                }

                return "Model is null!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBookRoom(int Id)
        {
            try
            {

                var entity = dbcontext.Books.Find(Id);

                if (entity != null)
                {

                    dbcontext.Books.Remove(entity);
                    dbcontext.SaveChanges();

                    return "Booking  Deleted!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<BookModel> GetBookRooms()
        {
            var entities = dbcontext.Books.ToList();

            List<BookModel> list = new List<BookModel>();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    BookModel dealer = new BookModel();

                    ///TODO: Problem why manually?                     
                    dealer.Booking_Id = entity.Booking_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;

                    list.Add(dealer);

                }
            }


            return list;

        }


        public BookModel GetBookRoom(int Id)
        {
            var entity = dbcontext.Books.Find(Id);


            BookModel dealer = new BookModel();

            if (entity != null)
            {
                ///TODO: Problem why manually?                     
                dealer.Booking_Id = entity.Booking_Id;
                dealer.Room_Id = entity.Room_Id;
                dealer.Hotel_Id = entity.Hotel_Id;
                dealer.StatusOfBooking = entity.StatusOfBooking;
                dealer.IsActive = entity.IsActive;


            }

            return dealer;
        }


        public string UpdateBookRoom(BookModel entity)
        {
            try
            {
                var dealer = dbcontext.Books.Find(entity.Booking_Id);

                if (entity != null)
                {
                    dealer.Booking_Id = entity.Booking_Id;
                    dealer.Room_Id = entity.Room_Id;
                    dealer.Hotel_Id = entity.Hotel_Id;
                    dealer.StatusOfBooking = entity.StatusOfBooking;
                    dealer.IsActive = entity.IsActive;



                    dbcontext.SaveChanges();

                    return "Updated!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }







    }
}
