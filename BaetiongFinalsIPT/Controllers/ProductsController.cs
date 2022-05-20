using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models;

namespace BaetiongFinalsIPT.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
               IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var products = db.Products;
                var response = Request.CreateResponse<IEnumerable<Product>>(HttpStatusCode.OK, products);
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
                var product = db.Products.Where(m => m.ProductID == id).FirstOrDefault();
                if (product == null)
                    throw new Exception("Product Id not found.");
                var response = Request.CreateResponse<Product>(HttpStatusCode.OK, product);
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
