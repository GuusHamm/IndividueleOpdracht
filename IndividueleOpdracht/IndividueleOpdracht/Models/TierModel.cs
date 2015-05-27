namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TierModel : IDatabaseModel
    {
        public string Id { get; set; }

        public ProjectModel ProjectId { get; private set; }

        public string Naam { get; private set; }

        public string Reward { get; private set; }

        public int Prijs { get; private set; }


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