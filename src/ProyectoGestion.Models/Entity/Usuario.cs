using System.Collections.Generic;

namespace ProyectoGestion.Models.Entity
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserPhoto UserPhoto { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
