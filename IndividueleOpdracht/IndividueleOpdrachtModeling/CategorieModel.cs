using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class CategorieModel :IDatabaseModel
    {
        private string naam;
        private string beschrijving;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public string Id()
        {
            throw new NotImplementedException();
        }

        public IDatabaseModel Create()
        {
            throw new NotImplementedException();
        }

        public IDatabaseModel Read()
        {
            throw new NotImplementedException();
        }

        public IDatabaseModel Update()
        {
            throw new NotImplementedException();
        }

        public IDatabaseModel Destroy()
        {
            throw new NotImplementedException();
        }
    }
}