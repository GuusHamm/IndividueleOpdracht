namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ProjectModel : IDatabaseModel
    {
        public ProjectModel()
        {
            this.Comments = new List<CommentModel>();
            this.Tags = new List<TagModel>();
        }

        public string Id { get; set; }

        public string Beschrijving { get; private set; }

        public string Naam { get; private set; }

        public AccountModel Creator { get; private set; }

        public CategorieModel Categorie { get; private set; }

        public int GeldNodig { get; private set; }

        public int GeldBehaald { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Views { get; private set; }

        public List<TagModel> Tags { get; private set; }

        public List<CommentModel> Comments { get; private set; }

        public bool Create()
        {
            IDatabaseMode
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