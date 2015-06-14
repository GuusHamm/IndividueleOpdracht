// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackingModel.cs" company="">
//   
// </copyright>
// <summary>
//   The backing model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The backing model.</summary>
    public class BackingModel : DatabaseModel
    {
        public BackingModel(string accountId, string tierId, string projectId, DateTime backingTime)
        {
            this.AccountId = accountId;
            this.TierId = tierId;
            this.ProjectId = projectId;
            this.BackingTime = backingTime;
            this.PaymentType = "CREDITCARD";
        }

        /// <summary>Gets the account id.</summary>
        /// <value>The account id.</value>
        public string AccountId { get; private set; }

        /// <summary>Gets the tier id.</summary>
        /// <value>The tier id.</value>
        public string TierId { get; private set; }

        /// <summary>Gets the project id.</summary>
        /// <value>The project id.</value>
        public string ProjectId { get; private set; }

        /// <summary>Gets the backing time.</summary>
        /// <value>The backing time.</value>
        public DateTime BackingTime { get; private set; }

        /// <summary>Gets the payment type.</summary>
        /// <value>The payment type.</value>
        public string PaymentType { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }
    }
}