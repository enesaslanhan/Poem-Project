using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Poem:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PoemName { get; set; }
        public string PoemText { get; set; }
    }
}
