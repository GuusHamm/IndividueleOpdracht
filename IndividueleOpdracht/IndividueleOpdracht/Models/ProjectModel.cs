namespace IndividueleOpdracht.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Microsoft.Ajax.Utilities;

    public class ProjectModel : DatabaseModel
    {
        public ProjectModel(string beschrijving, string naam, AccountModel creator, int geldNodig, DateTime startDate, DateTime endDate, int geldBehaald,int views, CategorieModel categorieModel)
        {
            this.Comments = new List<CommentModel>();
            this.Tags = new List<TagModel>();


            this.Beschrijving = beschrijving;
            this.Naam = naam;
            this.Creator = creator;
            this.GeldNodig = geldNodig;
            if (geldBehaald != 0)
            {
                this.GeldBehaald = geldBehaald;
            }
            else
            {
                this.GeldBehaald = 0;
            }
            
            this.StartDate = startDate;
            this.EndDate = endDate;

            if (views != 0)
            {
                this.Views = views;
            }
            else
            {
                this.Views = 0;
            }
            this.Categorie = categorieModel;
        }

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

        public void AddComments(List<CommentModel> comments)
        {
            this.Comments = comments;
        }

        public void AddTags(List<TagModel> tags)
        {
            this.Tags = tags;
        }

        public void AddBacking(int amount)
        {
            this.GeldBehaald += amount;
        }
        public bool Create()
        {

            /*
            List<OracleParameter>parameters = new List<OracleParameter>();

            if (this.Beschrijving == null || this.Naam == null || this.Creator == null || this.GeldNodig == 0)
            {
                return false;
            }

            this.OracleCommand.CommandText =
                "INSERT INTO PROJECTS (beschrijving, naam, creatorid, geld_nodig,geld_behaald,startdate,deadline,views) "
                + "VALUES (@beschrijving, @naam, @creatorid,@geldnodig,0,@startdate,@enddate,0)";

            OracleParameter beschrijvingparameter = new OracleParameter("@beschrijving", OracleDbType.Varchar2);
            beschrijvingparameter.Value = this.Beschrijving;
            parameters.Add(beschrijvingparameter);

            OracleParameter naampParameter = new OracleParameter("@naam", OracleDbType.Varchar2);
            naampParameter.Value = this.Naam;
            parameters.Add(naampParameter);

            OracleParameter creatorParameter = new OracleParameter("@creatorid", OracleDbType.Int32);
            creatorParameter.Value = this.Creator;
            parameters.Add(creatorParameter);

            OracleParameter geldNodigParameter = new OracleParameter("@geldnodig", OracleDbType.Varchar2);
            geldNodigParameter.Value = this.GeldNodig;
            parameters.Add(geldNodigParameter);

            OracleParameter startDateParameter = new OracleParameter("@startdate", OracleDbType.Date);
            startDateParameter.Value = this.StartDate;
            parameters.Add(startDateParameter);

            OracleParameter endDateParameter = new OracleParameter("@enddate", OracleDbType.Date);
            endDateParameter.Value = this.EndDate;
            parameters.Add(endDateParameter);

            foreach (OracleParameter parameter in parameters)
            {
                this.OracleCommand.Parameters.Add(parameter);
            }
            this.OracleCommand.Prepare();
            
            if (this.OracleCommand.ExecuteNonQuery() > 0)
            {
                return true;
            }
            */
            return false;
             
        }

        public override bool Read()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }

        public override bool Destroy()
        {
            throw new NotImplementedException();
        }
    }
}