using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date
        {
            get
            {
                return (this.dateCreated == default(DateTime))
                   ? this.dateCreated = DateTime.Now
                   : this.dateCreated;
            }

            set { this.dateCreated = value; }
        }
        private DateTime dateCreated = default(DateTime);

    }
}
