using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class BackingModel : IDatabaseModel
    {
        public string Id { get; set; }
        public AccountModel AccountId { get; private set; }
        public TierModel TierId{ get; private set;}
        public DateTime BackingTime { get; private set; }
        public string PaymentType { get; private set; }

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