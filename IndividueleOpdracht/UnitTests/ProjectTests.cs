using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;
    /// <summary>The project tests.</summary>
    [TestClass]
    public class ProjectTests
    {
        /// <summary>The project controller.</summary>
        ProjectController projectController = new ProjectController();


        /// <summary>Initializes a new instance of the <see cref="ProjectTests"/> class.</summary>
        public ProjectTests()
        {
            DatabaseController.Initialiaze();
        }
       
        /// <summary>The new project test.</summary>
        [TestMethod]
        public void NewProjectTest()
        {
            string naam = "FANDROID";
            string beschrijving = "A REVOLUTION IN SOFTWARE";

            // Id of creator Guus Hamm
            int creator = 1;

            // Id of categorie techonlogy
            int categorie = 1;
            int geldNodig = 15000;
            int runningTime = 90;

            ProjectModel testModel = this.projectController.CreateProject(
                beschrijving, 
                naam, 
                creator, 
                categorie, 
                geldNodig, 
                runningTime);

            Assert.AreEqual(naam, testModel.Naam, "Naam niet correct");
            Assert.AreEqual(beschrijving, testModel.Beschrijving);
            Assert.AreEqual(creator, Convert.ToInt32(testModel.Creator.Id));
            Assert.AreEqual(categorie, Convert.ToInt32(testModel.Categorie.Id));
            Assert.AreEqual(geldNodig, testModel.GeldNodig);

            projectController.DeleteProject(Convert.ToInt32(testModel.Id));

        }

        [TestMethod]
        public void NewTier()
        {
            string naam = "FANDROID";
            string beschrijving = "A REVOLUTION IN SOFTWARE";

            // Id of creator Guus Hamm
            int creator = 1;

            // Id of categorie techonlogy
            int categorie = 1;
            int geldNodig = 15000;
            int runningTime = 90;

            ProjectModel projectModel = this.projectController.CreateProject(
                beschrijving,
                naam,
                creator,
                categorie,
                geldNodig,
                runningTime);

            string tierNaam = "AWESOME TIER";
            string reward = "COOL STUFF";
            int prijs = 100;

            TierModel tierModel = this.projectController.CreateTier(
                Convert.ToInt32(projectModel.Id),
                tierNaam,
                reward,
                prijs);

            Assert.AreEqual(tierNaam, tierModel.Naam, "Naam niet correct");
            Assert.AreEqual(reward, tierModel.Reward);
            Assert.AreEqual(prijs, tierModel.Prijs);


            this.projectController.DeleteTier(Convert.ToInt32(tierModel.Id));
            this.projectController.DeleteProject(Convert.ToInt32(projectModel.Id));
        }

        /// <summary>The new backing.</summary>
        [TestMethod]
        public void NewBacking()
        {
            string naam = "FANDROID";
            string beschrijving = "A REVOLUTION IN SOFTWARE";

            // Id of creator Guus Hamm
            int creator = 1;

            // Id of categorie techonlogy
            int categorie = 1;
            int geldNodig = 15000;
            int runningTime = 90;

            ProjectModel projectModel = this.projectController.CreateProject(
                beschrijving, 
                naam, 
                creator, 
                categorie, 
                geldNodig, 
                runningTime);

            string tierNaam = "AWESOME TIER";
            string reward = "COOL STUFF";
            int prijs = 100;

            TierModel tierModel = this.projectController.CreateTier(
                Convert.ToInt32(projectModel.Id), 
                tierNaam, 
                reward, 
                prijs);

            BackingModel backingModel = this.projectController.CreateBacking(projectModel.Creator.Id, tierModel.Id, projectModel.Id);

            Assert.AreEqual(projectModel.Creator.Id, backingModel.AccountId);
            Assert.AreEqual(tierModel.Id, backingModel.TierId);
            Assert.AreEqual(projectModel.Id, backingModel.ProjectId);

            ProjectModel newProjectModel = this.projectController.GetProject(Convert.ToInt32(projectModel.Id));
            Assert.AreNotEqual(projectModel.GeldBehaald,newProjectModel.GeldBehaald);

            this.projectController.DeleteBacking(Convert.ToInt32(backingModel.Id));
            this.projectController.DeleteTier(Convert.ToInt32(tierModel.Id));
            this.projectController.DeleteProject(Convert.ToInt32(projectModel.Id));
        }
    }
}
