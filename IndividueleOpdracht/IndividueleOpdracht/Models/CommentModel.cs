using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    public class CommentModel: IDatabaseModel

{
        public string Id { get; set; }
        public int PosterId { get; private set; }
        public int ReplyId { get; private set; }
        public int ProjectId { get; private set; }
        public string Bericht { get; private set; }
        public DateTime PostDate { get; private set; }

        public CommentModel(int posterId, int projectId, string bericht, DateTime postDate)
        {
            this.PosterId = posterId;
            this.ProjectId = projectId;
            this.PostDate = postDate;
            this.Bericht = bericht;
        }

        public CommentModel(int posterId, int replyId, int projectId, string bericht, DateTime postDate)
        {
            this.PosterId = posterId;
            this.ReplyId = replyId;
            this.ProjectId = projectId;
            this.Bericht = bericht;
            this.PostDate = postDate;
        }

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