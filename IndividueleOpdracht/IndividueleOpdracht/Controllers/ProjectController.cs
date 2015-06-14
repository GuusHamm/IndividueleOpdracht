// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The business logic that handles project things.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Dynamic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Web;
    using System.Web.Services.Description;

    using IndividueleOpdracht.Models;

    using Npgsql;

    using NpgsqlTypes;

    /// <summary>
    /// The business logic that handles project things.
    /// </summary>
    public class ProjectController
    {
        /// <summary>Creates a project model and inserts that into the database.</summary>
        /// <param name="beschrijving">The beschrijving.</param>
        /// <param name="naam"> The naam.</param>
        /// <param name="creatorID">The creator id.</param>
        /// <param name="categorieID"> The categorie id.</param>
        /// <param name="geldNodig">The geld nodig.</param>
        /// <param name="runningTime">The running time.</param>
        /// <returns>The <see cref="ProjectModel"/>.</returns>
        public ProjectModel CreateProject(string beschrijving,string naam,int creatorID,int categorieID, int geldNodig,int runningTime)
        {
            DateTime startDateTime = DateTime.Now;
            DateTime endDateTime = startDateTime.AddDays(runningTime);
            CategorieModel categorieModel = this.GetCategorieOfProject(categorieID,null);
            AccountModel creator = AccountController.RetrieveAccount(creatorID);

            // Creates a new project model
            ProjectModel projectModel = new ProjectModel(beschrijving.ToUpper(),naam.ToUpper(),creator,geldNodig,startDateTime,endDateTime,0,0,categorieModel);

            // Inserts the projectmodel into the database
            NpgsqlCommand command = new NpgsqlCommand("Insert into projects(id,beschrijving,naam,creatorid,geld_nodig,geld_behaald,startdate,deadline,views,categorieid) values(nextval('projects_seq'),:value1,:value2,:value3,:value4,0,:value5,:value6,0,:value7) returning id ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Text);
            command.Parameters[0].Value = projectModel.Beschrijving;

            command.Parameters.Add("value2", NpgsqlDbType.Text);
            command.Parameters[1].Value = projectModel.Naam;

            command.Parameters.Add("value3", NpgsqlDbType.Integer);
            command.Parameters[2].Value = projectModel.Creator.Id;

            command.Parameters.Add("value4", NpgsqlDbType.Integer);
            command.Parameters[3].Value = projectModel.GeldNodig;

            command.Parameters.Add("value5", NpgsqlDbType.Date);
            command.Parameters[4].Value = projectModel.StartDate;

            command.Parameters.Add("value6", NpgsqlDbType.Date);
            command.Parameters[5].Value = projectModel.EndDate;

            command.Parameters.Add("value7", NpgsqlDbType.Integer);
            command.Parameters[6].Value = categorieModel.Id;

            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    // Retrieves the projectid and adds it to the model
                    projectModel.Id = dr[0].ToString();
                }
            }

            // returns the model
            return projectModel;
        }

        /// <summary>Creates a backingmodel and inserts that into the database.</summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="tierId">The tier id.</param>
        /// <param name="projectId">The project id.</param>
        /// <returns>The <see cref="BackingModel"/>.</returns>
        public BackingModel CreateBacking(string accountId, string tierId,string projectId)
        {
            BackingModel backingModel = new BackingModel(accountId,tierId,projectId,DateTime.Now);

            ProjectModel projectModel = this.GetProject(Convert.ToInt32(projectId));
            TierModel tierModel = this.GetTier(Convert.ToInt32(tierId), null);
            NpgsqlCommand command = new NpgsqlCommand("Insert into backing(id,projectid,userid,tierid,backingtime,paymenttype) values(nextval('backing_seq'),:value1,:value2,:value3,:value4,:value5) returning id ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = Convert.ToInt32(backingModel.ProjectId);

            command.Parameters.Add("value2", NpgsqlDbType.Integer);
            command.Parameters[1].Value = Convert.ToInt32(backingModel.AccountId);

            command.Parameters.Add("value3", NpgsqlDbType.Integer);
            command.Parameters[2].Value = Convert.ToInt32(backingModel.TierId);

            command.Parameters.Add("value4", NpgsqlDbType.Date);
            command.Parameters[3].Value = backingModel.BackingTime;

            command.Parameters.Add("value5", NpgsqlDbType.Text);
            command.Parameters[4].Value = backingModel.PaymentType;

            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    backingModel.Id = dr[0].ToString();
                }
            }

            projectModel.AddBacking(tierModel.Prijs);

            command = new NpgsqlCommand("update projects set geld_behaald = :value1 where id = :value2 ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = Convert.ToInt32(projectModel.GeldBehaald);

            command.Parameters.Add("value2", NpgsqlDbType.Integer);
            command.Parameters[1].Value = Convert.ToInt32(projectModel.Id);

            command.ExecuteNonQuery();
            return backingModel;
        }

        /// <summary>Creates a commentModel and inserts that into the database.</summary>
        /// <param name="tekst">The tekst.</param>
        /// <param name="commenterID">The commenter id.</param>
        /// <param name="projectID">The project id.</param>
        /// <returns>The <see cref="CommentModel"/>.</returns>
        public CommentModel CreateComment(string tekst,int commenterID, int projectID)
        {
            CommentModel commentModel = new CommentModel(commenterID,projectID,tekst,DateTime.Now);

            NpgsqlCommand command = new NpgsqlCommand("Insert into comments(id,posterid,replyid,projectid,bericht,postdate) values(nextval('comments_seq'),:value1,null,:value2,:value3,:value4) ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = commentModel.PosterId;

            command.Parameters.Add("value2", NpgsqlDbType.Integer);
            command.Parameters[1].Value = commentModel.ProjectId;

            command.Parameters.Add("value3", NpgsqlDbType.Text);
            command.Parameters[2].Value = commentModel.Bericht;

            command.Parameters.Add("value4", NpgsqlDbType.Date);
            command.Parameters[3].Value = commentModel.PostDate;

            if (command.ExecuteNonQuery() != 0)
            {
                return commentModel;
            }
            else
            {
                return null;
            }


        }

        /// <summary>Retrieves the projectmodel for a id.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ProjectModel"/>.</returns>
        public ProjectModel GetProject(int id)
        {
            NpgsqlCommand command;

            command = new NpgsqlCommand(
                    "Select p.*,u.*,c.*  from projects p join users u on (p.creatorid = u.id) join categorie c on (p.categorieid = c.id) where p.id = :value1",
                    DatabaseController.Connection);
            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = id;
            ProjectModel projectModel = null;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    string beschrijving = Convert.ToString(dr[1]);
                    string naam = Convert.ToString(dr[2]);
                    AccountModel.Soort soort;
                    AccountModel.Soort.TryParse(Convert.ToString(dr[15]), false, out soort);
                    AccountModel creator = new AccountModel(Convert.ToString(dr[11]), Convert.ToString(dr[12]), Convert.ToString(dr[13]), Convert.ToString(dr[14]), soort, Convert.ToString(dr[16]), Convert.ToString(dr[17]), Convert.ToString(dr[18]), Convert.ToString(dr[19]), Convert.ToString(dr[20]));
                    int geldNodig = Convert.ToInt32(dr[5]);
                    int geldBehaald = Convert.ToInt32(dr[6]);
                    DateTime startDate;
                    DateTime.TryParse(Convert.ToString(dr[7]), out startDate);
                    DateTime endDate;
                    DateTime.TryParse(Convert.ToString(dr[8]), out endDate);
                    int views = Convert.ToInt32(dr[9]);
                    projectModel = new ProjectModel(
                        beschrijving,
                        naam,
                        creator,
                        geldNodig,
                        startDate,
                        endDate,
                        geldBehaald,
                        views,
                        new CategorieModel(dr[24].ToString(), dr[25].ToString()));
                    projectModel.Id = dr[0].ToString();
                }
            }
            return projectModel;
        }

        /// <summary>Gets all the commentmodels of a project.</summary>
        /// <param name="id">The id.</param>
        /// <param name="projectModel">The project model.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<CommentModel> GetCommentsOfProject(int id, ProjectModel projectModel)
        {
            int projectID;
            List<CommentModel> commentModels = new List<CommentModel>();
            if (id == 0)
            {
                projectID = Convert.ToInt32(projectModel.Id);
            }
            else
            {
                projectID = id;
            }
            NpgsqlCommand command =new NpgsqlCommand( "Select c.* from comments c where c.projectid = :value1 ;", DatabaseController.Connection);

           command.Parameters.Add("value1", NpgsqlDbType.Integer);
           command.Parameters[0].Value = projectID;
            

            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    CommentModel commentModel;
                    
                        commentModel = new CommentModel(
                            Convert.ToInt32(dr[1]), 
                            Convert.ToInt32(dr[3]), 
                            Convert.ToString(dr[4]), 
                            Convert.ToDateTime(dr[5]));

                    commentModel.Id = dr[0].ToString();
                    
                    commentModels.Add(commentModel);
                     
                }

            }

            return commentModels;
        }

        /// <summary>Gets all the tiermodels of a project.</summary>
        /// <param name="id">The id.</param>
        /// <param name="projectModel">The project model.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<TierModel> GetTiersOfProject(int id, ProjectModel projectModel)
        {
            int projectId;

            List<TierModel> tierModels = new List<TierModel>();
            if (id == 0)
            {
                projectId = Convert.ToInt32(projectModel.Id);
            }
            else
            {
                projectId = id;
            }
            NpgsqlCommand command = new NpgsqlCommand("Select t.* from tier t where t.projectid = :value1 ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = projectId;

            TierModel tierModel;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                
                {
                    tierModel = new TierModel(
                        dr[1].ToString(), 
                        dr[2].ToString(), 
                        dr[3].ToString(), 
                        Convert.ToInt32(dr[4]));
                    tierModel.Id = dr[0].ToString();

                    tierModels.Add(tierModel);
                }
            }

            return tierModels;
        }

        /// <summary>The get categorie model.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="CategorieModel"/>.</returns>
        public CategorieModel GetCategorieOfProject(int id, ProjectModel projectModel)
        {
            int projectId;

            if (id == 0)
            {
                projectId = Convert.ToInt32(projectModel.Id);
            }
            else
            {
                projectId = id;
            }

            NpgsqlCommand command = new NpgsqlCommand("select c.* from categorie c where id = :value1 ;", DatabaseController.Connection);


            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = projectId;

            CategorieModel categorieModel = null;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    categorieModel = new CategorieModel(dr[1].ToString(), dr[2].ToString());
                    categorieModel.Id = dr[0].ToString();
                }
            }

            return categorieModel;
        }

        /// <summary>Gets all the tagmodels of a project.</summary>
        /// <param name="id">The id.</param>
        /// <param name="projectModel">The project model.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<TagModel> GetTagOfProject(int id, ProjectModel projectModel)
        {
            int projectID;
            List<TagModel> tagModels = new List<TagModel>();
            if (id == 0)
            {
                projectID = Convert.ToInt32(projectModel.Id);
            }
            else
            {
                projectID = id;
            }

            NpgsqlCommand command = new NpgsqlCommand("select t.* from tag t join project_tag pt on (pt.tagid = t.id) where pt.projectid = :value1 ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = projectID;

            TagModel tagModel;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    tagModel = new TagModel(dr[1].ToString(), dr[2].ToString());
                    tagModels.Add(tagModel);
                }
            }

            return tagModels;


        }
        
        /// <summary>Gets all the projectmodels in the database.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="List"/>.</returns>
        public List<ProjectModel> GetProjects(int id)
        {
            List<ProjectModel> projects = new List<ProjectModel>();
            NpgsqlCommand command;
            if (id == 0)
            {
                command =
                    new NpgsqlCommand(
                        "Select p.*,u.*,c.*  from projects p join users u on (p.creatorid = u.id) join categorie c on (p.categorieid = c.id);",
                        DatabaseController.Connection);
            }
            else
            {
                command = new NpgsqlCommand(
                    "Select p.*,u.*,c.*  from projects p join users u on (p.creatorid = u.id) join categorie c on (p.categorieid = c.id) where p.id = :value1",
                    DatabaseController.Connection);
                command.Parameters.Add("value1", NpgsqlDbType.Integer);
                command.Parameters[0].Value = id;
            }
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    string beschrijving = Convert.ToString(dr[1]);
                    string naam = Convert.ToString(dr[2]);
                    AccountModel.Soort soort;
                    AccountModel.Soort.TryParse(Convert.ToString(dr[15]), false, out soort);
                    AccountModel creator = new AccountModel(Convert.ToString(dr[11]), Convert.ToString(dr[12]), Convert.ToString(dr[13]), Convert.ToString(dr[14]), soort, Convert.ToString(dr[16]), Convert.ToString(dr[17]), Convert.ToString(dr[18]), Convert.ToString(dr[19]), Convert.ToString(dr[20]));
                    int geldNodig = Convert.ToInt32(dr[5]);
                    int geldBehaald = Convert.ToInt32(dr[6]);
                    DateTime startDate;
                    DateTime.TryParse(Convert.ToString(dr[7]), out startDate);
                    DateTime endDate;
                    DateTime.TryParse(Convert.ToString(dr[8]), out endDate);
                    int views = Convert.ToInt32(dr[9]);
                    ProjectModel project = new ProjectModel(
                        beschrijving,
                        naam,
                        creator,
                        geldNodig,
                        startDate,
                        endDate,
                        geldBehaald,
                        views,
                        new CategorieModel(dr[24].ToString(), dr[25].ToString()));
                    project.Id = dr[0].ToString();
                    projects.Add(project);
                }
            }

            return projects;
        }

        /// <summary>Gets the tiermodel beloning to the id.</summary>
        /// <param name="id">The id.</param>
        /// <param name="tierModel">The tier model.</param>
        /// <returns>The <see cref="TierModel"/>.</returns>
        public TierModel GetTier(int id, TierModel tierModel)
        {
            int tierId;

            if (id == 0)
            {
                tierId = Convert.ToInt32(tierModel.Id);
            }
            else
            {
                tierId = id;
            }
            NpgsqlCommand command = new NpgsqlCommand("Select t.* from tier t where t.id= :value1 ;", DatabaseController.Connection);

            command.Parameters.Add("value1", NpgsqlDbType.Integer);
            command.Parameters[0].Value = tierId;

            TierModel tier = null;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                
                {
                    tier = new TierModel(
                        dr[1].ToString(), 
                        dr[2].ToString(), 
                        dr[3].ToString(), 
                        Convert.ToInt32(dr[4]));
                    tier.Id = dr[0].ToString();

                }
            }

            return tier;
        }

        /// <summary>Gets all the tagmodels in the database.</summary>
        /// <returns>The <see cref="List"/>.</returns>
        public List<TagModel> GetAllTags()
        {
            List<TagModel>tagModels = new List<TagModel>();
            NpgsqlCommand command = new NpgsqlCommand("select t.* from tag t ;", DatabaseController.Connection);

            TagModel tagModel;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    tagModel = new TagModel(dr[1].ToString(), dr[2].ToString());
                    tagModel.Id = dr[0].ToString();
                    tagModels.Add(tagModel);
                }
            }

            return tagModels;
        }

        /// <summary>Gets all the categoriemodels in the database.</summary>
        /// <returns>The <see cref="List"/>.</returns>
        public List<CategorieModel> GetAllCategories()
        {
            List<CategorieModel> categorieModels = new List<CategorieModel>();

            NpgsqlCommand command = new NpgsqlCommand("select c.* from categorie c ;", DatabaseController.Connection);

            CategorieModel categorieModel;
            using (NpgsqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    categorieModel = new CategorieModel(dr[1].ToString(), dr[2].ToString());
                    categorieModel.Id = dr[0].ToString();
                    categorieModels.Add(categorieModel);
                }
            }

            return categorieModels;
        }

        
    }
}