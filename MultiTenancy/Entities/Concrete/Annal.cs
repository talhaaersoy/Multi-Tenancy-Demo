
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Annal : IEntity
    {
        public int Id { get; set; }
        public string Time  { get; set; }
        public string Category { get; set; }
        public string Event { get; set; }
    }
}
