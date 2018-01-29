using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib;
using DataAccessLib.DAL;

namespace TestWebApi.Tests
{
    internal class MockRepository : IRepository<TimeBooker>
    {
        private List<TimeBooker> Bookings { get; } = new List<TimeBooker>
        {
            new TimeBooker
            {
                Id = 1,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 12, 13, 22, 33),
                Project = "Project One",
                Time = "2.3"
            },
            new TimeBooker
            {
                Id = 2,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 13, 14, 22, 33),
                Project = "Project Two",
                Time = "3.3"
            },
            new TimeBooker
            {
                Id = 3,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 14, 15, 22, 33),
                Project = "Project Three",
                Time = "4.3"
            },
            new TimeBooker
            {
                Id = 4,
                IsRemoved = false,
                Created = new DateTime(2017, 12, 15, 16, 22, 33),
                Project = "Project Four",
                Time = "5.3"
            }
        };

        public IEnumerable<TimeBooker> GetAll()
        {
            return Bookings.Where(x => !x.IsRemoved).ToList();
        }

        public TimeBooker Get(int id)
        {
            return Bookings.FirstOrDefault(x => x.Id == id && !x.IsRemoved);
        }

        public void Insert(TimeBooker newBooking)
        {
            Bookings.Add(newBooking);
        }

        public bool Update(TimeBooker updatedBooking)
        {
            var tempBooking = Bookings.FirstOrDefault(x => x.Id == updatedBooking.Id);

            if (tempBooking != null)
            {
                tempBooking.Time = updatedBooking.Time;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var tempBooking = Bookings.FirstOrDefault(x => x.Id == id);

            if (tempBooking != null && !tempBooking.IsRemoved)
            {
                tempBooking.IsRemoved = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            //do nothing here. 
        }

        public void Dispose()
        {
            //do nothing here. 
        }
    }
}
