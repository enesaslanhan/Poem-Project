﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PoemScore:IEntity
    {
        public int Id { get; set; }
        public int PoemId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }

    }
}
