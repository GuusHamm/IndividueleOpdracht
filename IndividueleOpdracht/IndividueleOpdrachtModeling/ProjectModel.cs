using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class ProjectModel:IDatabaseModel
    {
        private string beschrijving;
        private string naam;
        private UserModel creatorID;
        private CategorieModel categorieID;
        private int GeldNodig;
        private int GeldBehaald;
        private DateTime StartDate;
        private DateTime Deadline;
        private int views;

        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public UserModel CreatorId
        {
            get { return creatorID; }
            set { creatorID = value; }
        }

        public CategorieModel CategorieId
        {
            get { return categorieID; }
            set { categorieID = value; }
        }

        public int GeldNodig1
        {
            get { return GeldNodig; }
            set { GeldNodig = value; }
        }

        public int GeldBehaald1
        {
            get { return GeldBehaald; }
            set { GeldBehaald = value; }
        }

        public DateTime StartDate1
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

        public DateTime Deadline1
        {
            get { return Deadline; }
            set { Deadline = value; }
        }

        public int Views
        {
            get { return views; }
            set { views = value; }
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