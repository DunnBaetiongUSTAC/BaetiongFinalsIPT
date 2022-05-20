using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models

namespace BaetiongFinalsIPT.Controllers
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var categories = db.Categories;
                var response = Request.CreateResponse<IEnumerable<Category>>(HttpStatusCode.OK, categories);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }

        }
        [HttpGet]
        public HttpResponseMessage Index(int id)
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var category = db.Categories.Where(m => m.CategoryID == id).FirstOrDefault();
                if (category == null)
                    throw new Exception("Category Id not found.");
                var response = Request.CreateResponse<Category>(HttpStatusCode.OK, category);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }
        }
        public string Put(int id, [FromBody] string value)
        {
            return value + "updated successfully with id" + id;
        }
    }
}
