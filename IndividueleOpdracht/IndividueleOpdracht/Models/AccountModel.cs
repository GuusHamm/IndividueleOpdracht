using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class AccountModel : IDatabaseModel
    {
        public string Id { get; set; }
        public string Naam { get; private set; }
        public string Mail { get; private set; }
        public string Land { get; private set; }
        public string Telefoonnummer { get; private set; }
        public enum Soort
        {
            Regular,
            Creator
        }
        public Soort AccountSoort { get; private set; }
        public string Biografie { get; private set; }
        public string Adres { get; private set; }
        public string Woonplaats { get; private set; }
        public string Postcode { get; private set; }
        public string BetalingGegevens { get; private set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }
}