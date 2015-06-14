// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountModel.cs" company="">
//   
// </copyright>
// <summary>
//   The account model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The account model.</summary>
    public class AccountModel : IDatabaseModel
    {
        /// <summary>The soort.</summary>
        public enum Soort
        {
            /// <summary>The regular.</summary>
            Regular, 

            /// <summary>The creator.</summary>
            Creator
        }

        /// <summary>Initializes a new instance of the <see cref="AccountModel"/> class.</summary>
        /// <param name="naam">The naam.</param>
        /// <param name="mail">The mail.</param>
        /// <param name="land">The land.</param>
        /// <param name="telefoonnummer">The telefoonnummer.</param>
        /// <param name="accountSoort">The account soort.</param>
        /// <param name="biografie">The biografie.</param>
        /// <param name="adres">The adres.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="woonplaats">The woonplaats.</param>
        /// <param name="betalingGegevens">The betaling gegevens.</param>
        public AccountModel(string naam, string mail, string land, string telefoonnummer, Soort accountSoort, string biografie, string adres, string postcode, string woonplaats, string betalingGegevens)
        {
            this.Naam = naam;
            this.Mail = mail;
            this.Land = land;
            this.Telefoonnummer = telefoonnummer;
            this.AccountSoort = accountSoort;

            if (accountSoort == Soort.Creator)
            {
                this.Biografie = biografie;
                this.Adres = adres;
                this.Postcode = postcode;
                this.Woonplaats = woonplaats;
                this.BetalingGegevens = betalingGegevens;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="AccountModel"/> class.</summary>
        /// <param name="naam">The naam.</param>
        /// <param name="mail">The mail.</param>
        /// <param name="land">The land.</param>
        /// <param name="telefoonnummer">The telefoonnummer.</param>
        /// <param name="accountSoort">The account soort.</param>
        public AccountModel(string naam, string mail, string land, string telefoonnummer, Soort accountSoort)
        {
            this.Naam = naam;
            this.Mail = mail;
            this.Land = land;
            this.Telefoonnummer = telefoonnummer;
            this.AccountSoort = accountSoort;
        }

        /// <summary>Gets the naam.</summary>
        /// <value>The naam.</value>
        public string Naam { get; private set; }

        /// <summary>Gets the mail.</summary>
        /// <value>The mail.</value>
        public string Mail { get; private set; }

        /// <summary>Gets the land.</summary>
        /// <value>The land.</value>
        public string Land { get; private set; }

        /// <summary>Gets the telefoonnummer.</summary>
        /// <value>The telefoonnummer.</value>
        public string Telefoonnummer { get; private set; }

        /// <summary>Gets the account soort.</summary>
        /// <value>The account soort.</value>
        public Soort AccountSoort { get; private set; }

        /// <summary>Gets the biografie.</summary>
        /// <value>The biografie.</value>
        public string Biografie { get; private set; }

        /// <summary>Gets the adres.</summary>
        /// <value>The adres.</value>
        public string Adres { get; private set; }

        /// <summary>Gets the woonplaats.</summary>
        /// <value>The woonplaats.</value>
        public string Woonplaats { get; private set; }

        /// <summary>Gets the postcode.</summary>
        /// <value>The postcode.</value>
        public string Postcode { get; private set; }

        /// <summary>Gets the betaling gegevens.</summary>
        /// <value>The betaling gegevens.</value>
        public string BetalingGegevens { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }
    }
}