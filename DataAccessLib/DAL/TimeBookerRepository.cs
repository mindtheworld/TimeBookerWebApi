using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.DAL
{
    public sealed class TimeBookerRepository: IRepository<TimeBooker>
    {
        private readonly TimeBookerDbEntities _timeBookerEntities;

        private bool _disposed = false;

        public TimeBookerRepository()
        {
            _timeBookerEntities= new TimeBookerDbEntities();
        }

        public IEnumerable<TimeBooker> GetAll()
        {
            return _timeBookerEntities.TimeBookers.Where(x => !x.IsRemoved).ToList();
        }

        public TimeBooker Get(int id)
        {
            return _timeBookerEntities.TimeBookers.FirstOrDefault(x => x.Id == id && !x.IsRemoved);
        }

        public void Insert(TimeBooker timeBooker)
        {
            //update timestamp for creation.
            timeBooker.Created = DateTime.Now;
            _timeBookerEntities.TimeBookers.Add(timeBooker);

        }

        public bool Update(TimeBooker updatedBooking)
        {
            var tempBooking = _timeBookerEntities.TimeBookers.FirstOrDefault(x => x.Id == updatedBooking.Id);

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
            var tempBooking = _timeBookerEntities.TimeBookers.FirstOrDefault(x => x.Id == id);
          
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
            _timeBookerEntities.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _timeBookerEntities.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
