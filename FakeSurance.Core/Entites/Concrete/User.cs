using FakeSurance.Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.Core.Entites.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public bool isAdmin { get; set; }
        public string Name { get; set; }
        //encrypt password olmayacak :/
        public string Password { get; set; }
    }
}
