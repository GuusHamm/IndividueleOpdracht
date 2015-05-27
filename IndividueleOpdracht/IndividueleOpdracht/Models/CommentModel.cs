using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class CommentModel: IDatabaseModel

{
        public string Id { get; set; }
        public AccountModel PosterId { get; private set; }
        public CommentModel ReplyId { get; private set; }
        public ProjectModel ProjectId { get; private set; }
        public string Bericht { get; private set; }
        public DateTime PostDate { get; private set; }
        
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