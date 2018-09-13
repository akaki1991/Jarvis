using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DAO;
using Domain.DAO.Entities;

namespace API.Helpers
{
    public static class DbSeeder
    {
        public static void Seed(this EMobileContext context)
        {
          
            if (context.Database.EnsureCreated())
            {
                if (context.Mobiles.Any())
                    return;
                for (int i = 0; i < 20; i++)
                {
                    context.Mobiles.Add(new Mobile()
                    {
                        Name = "Iphone " + new Random().Next(5, 8),
                        CPU = "A " + new Random().Next(6, 12),
                        OS = "ios " + new Random().Next(6, 12),
                        Brand = "Apple",
                        InternalMemory = "64gb",
                        ScreenResolution = "1140x728",
                        Size = "128-5-4",
                        ScreenSize = "5",
                        RAM = "4gb",
                        Price = new Random().Next(1500, 2000),
                        VideoUrl = "https://www.youtube.com/embed/VlefObjJ5hM",
                        Weight = "128",
                        Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Value="https://images.kogan.com/image/fetch/s--PYK8gQDP--/b_white,c_pad,f_auto,h_400,q_auto:good,w_600/https://assets.kogan.com/files/product/KHIP6xxxxx/KHIP6xxGLD-webres.jpg"
                        },
                        new Photo()
                        {
                            Value="https://images.officeworks.com.au/api/2/img/https://s3-ap-southeast-2.amazonaws.com/wc-prod-pim/JPEG_1000x1000/AIP632SG_B_iphone_6_32gb_space_grey_unlocked.jpg/resize?size=706&auth=MjA5OTcwODkwMg__"
                        }
                    }

                    });
                }
                context.SaveChanges();
            }

          


          
        }

        
    }
}
