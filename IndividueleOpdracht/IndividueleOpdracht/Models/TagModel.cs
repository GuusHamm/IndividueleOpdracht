namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TagModel:IDatabaseModel
    {

        public string Naam { get; private set; }

        public string Beschrijving { get; private set; }

        public string Id { get; set; }

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