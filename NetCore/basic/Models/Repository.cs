using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic.Models
{
    public class Repository
    {
        private static readonly List<Bootcamp> _bootcamp = new();

        static Repository()
        {
            _bootcamp = new List<Bootcamp>{
                new Bootcamp(){BootcampId = 1, Title="Sql Bootcamp", Description="Detayı derinlemesine öğren",Image = "2.jpg",Tags = new string[]{"sql","data"},isActive= true,isHome=true},
                new Bootcamp(){BootcampId = 2, Title="Unity Bootcamp", Description="Oyunları derinlemesine öğren",Image = "3.jpg",Tags = new string[]{"unity","oyun geliştirme"},isActive= true,isHome=true},
                new Bootcamp(){BootcampId = 3, Title="Back-end Bootcamp", Description="Webi derinlemesine öğren",Image = "1.jpg",Tags = new string[]{"aspnet","web geliştirme"},isActive= true,isHome=true},
            };
        }
        public static List<Bootcamp> Bootcamps
        {
            get
            {
                return _bootcamp;
            }
        }

        public static Bootcamp? GetById(int? id)
        {
            return _bootcamp.FirstOrDefault(b => b.BootcampId == id);
        }
    }
}