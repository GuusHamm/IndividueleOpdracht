namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class UpdateModel : IDatabaseModel
    {
        public string Id { get; set; }

        public string Bericht { get; private set; }

        public DateTime PostDate { get; private set; }

        public ProjectModel ProjectId { get; private set; }


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