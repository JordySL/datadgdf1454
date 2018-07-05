using System.Collections;
using System.Collections.Generic;

namespace ProyectoGestion.Models.EntityForm
{
    public class UserAccountPhoto
    {
        public int ID { get; set; }
        public int IDKey { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<string> UserNameList { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public List<string> PhotoList { get; set; }
    }
}
