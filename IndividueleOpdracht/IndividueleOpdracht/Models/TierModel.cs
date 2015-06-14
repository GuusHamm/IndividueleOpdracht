namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TierModel : DatabaseModel
    {
        public TierModel(string projectId, string naam, string reward, int prijs)
        {
            this.ProjectId = projectId;
            this.Naam = naam;
            this.Reward = reward;
            this.Prijs = prijs;
        }

        public string ProjectId { get; private set; }

        public string Naam { get; private set; }

        public string Reward { get; private set; }

        public int Prijs { get; private set; }

        public string Id { get; set; }
        public override bool Create()
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