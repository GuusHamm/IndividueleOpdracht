// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommentModel.cs" company="">
//   
// </copyright>
// <summary>
//   The comment model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The comment model.</summary>
    public class CommentModel: IDatabaseModel

{
        /// <summary>Initializes a new instance of the <see cref="CommentModel"/> class.</summary>
        /// <param name="posterId">The poster id.</param>
        /// <param name="projectId">The project id.</param>
        /// <param name="bericht">The bericht.</param>
        /// <param name="postDate">The post date.</param>
        public CommentModel(int posterId, int projectId, string bericht, DateTime postDate)
        {
            this.PosterId = posterId;
            this.ProjectId = projectId;
            this.PostDate = postDate;
            this.Bericht = bericht;
        }

        /// <summary>Initializes a new instance of the <see cref="CommentModel"/> class.</summary>
        /// <param name="posterId">The poster id.</param>
        /// <param name="replyId">The reply id.</param>
        /// <param name="projectId">The project id.</param>
        /// <param name="bericht">The bericht.</param>
        /// <param name="postDate">The post date.</param>
        public CommentModel(int posterId, int replyId, int projectId, string bericht, DateTime postDate)
        {
            this.PosterId = posterId;
            this.ReplyId = replyId;
            this.ProjectId = projectId;
            this.Bericht = bericht;
            this.PostDate = postDate;
        }

        /// <summary>Gets the poster id.</summary>
        /// <value>The poster id.</value>
        public int PosterId { get; private set; }

        /// <summary>Gets the reply id.</summary>
        /// <value>The reply id.</value>
        public int ReplyId { get; private set; }

        /// <summary>Gets the project id.</summary>
        /// <value>The project id.</value>
        public int ProjectId { get; private set; }

        /// <summary>Gets the bericht.</summary>
        /// <value>The bericht.</value>
        public string Bericht { get; private set; }

        /// <summary>Gets the post date.</summary>
        /// <value>The post date.</value>
        public DateTime PostDate { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }

        }
}