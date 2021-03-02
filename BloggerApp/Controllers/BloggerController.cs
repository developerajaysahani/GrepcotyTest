using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloggerCore.EntityModel;
namespace BloggerApp.Controllers
{
    [Authorize]
    public class BloggerController : ApiController
    {
        private readonly GrepecityEntities db;
        public BloggerController()
        {
            db = new GrepecityEntities();
        }

        [HttpGet]
        [Route("BlogList")]
        public IHttpActionResult BlogList()
        {

            var List = db.BlogPosts.ToList();
            return Ok(List);
        }


        [Route("GetBlog")]
        [HttpGet]
        public IHttpActionResult GetBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Result = db.BlogPosts.Where(x => x.Id == id);
            return Ok(Result);
        }


        [HttpPost]
        [Route("PostBlog")]
        public HttpResponseMessage PostBlog(BlogPost model)
        {

            if (model.UserId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Blog Successfully Deleted");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }


        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                if (id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                if (id > 0)
                {
                    var result = db.BlogPosts.Find(id);
                    db.BlogPosts.Remove(result);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Blog Successfully Deleted");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }


        }

        [HttpPost]
        [Route("PostComment")]
        public HttpResponseMessage PostComment(Comment model)
        {

            if (model.PostId == 0 && model.UserId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                db.Comments.Add(model);
                db.SaveChanges();
                
                return Request.CreateResponse(HttpStatusCode.OK,"Post comment Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }

        }
    }

}

