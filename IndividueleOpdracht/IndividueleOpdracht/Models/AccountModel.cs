namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AccountModel : IDatabaseModel
    {

        public enum Soort
        {
            Regular,
            Creator
        }

        public AccountModel(Soort accountSoort)
        {
            this.AccountSoort = accountSoort;
        }

        public AccountModel()
        {
            
        }

        public AccountModel(string naam, string mail, string land, string telefoonnummer, Soort accountSoort, string biografie, string adres, string postcode, string woonplaats, string betalingGegevens)
        {
            this.Naam = naam;
            this.Mail = mail;
            this.Land = land;
            this.Telefoonnummer = telefoonnummer;
            this.AccountSoort = accountSoort;

            if (accountSoort == Soort.Creator)
            {
                this.Biografie = biografie;
                this.Adres = adres;
                this.Postcode = postcode;
                this.Woonplaats = woonplaats;
                this.BetalingGegevens = betalingGegevens;
            }
        }

        public AccountModel(string naam, string mail, string land, string telefoonnummer, Soort accountSoort)
        {
            this.Naam = naam;
            this.Mail = mail;
            this.Land = land;
            this.Telefoonnummer = telefoonnummer;
            this.AccountSoort = accountSoort;
        }


        public string Id { get; set; }

        public string Naam { get; private set; }

        public string Mail { get; private set; }

        public string Land { get; private set; }

        public string Telefoonnummer { get; private set; }

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