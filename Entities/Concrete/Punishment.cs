using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Punishment:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PunishmentStartingDay { get; set; }
        public DateTime PunishmentEndDay { get; set; }

    }
}
