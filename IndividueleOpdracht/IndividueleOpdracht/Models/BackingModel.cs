using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class BackingModel : DatabaseModel
    {
        public BackingModel(string accountId, string tierId,string projectId, DateTime backingTime)
        {
            this.AccountId = accountId;
            this.TierId = tierId;
            this.ProjectId = projectId;
            this.BackingTime = backingTime;
            this.PaymentType = "CREDITCARD";
        }

        public string AccountId { get; private set; }

        public string TierId { get; private set; }

        public string ProjectId { get; private set; }
        public DateTime BackingTime { get; private set; }

        public string PaymentType { get; private set; }

        public string Id { get; set; }

        public override bool Create()
        {
            throw new NotImplementedException();
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