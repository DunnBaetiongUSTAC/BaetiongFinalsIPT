using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models;

namespace BaetiongFinalsIPT.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var customer = db.Customers;
                var response = Request.CreateResponse<IEnumerable<Customer>>(HttpStatusCode.OK, customer);
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
                var customer = db.Customers.Where(m => m.CustomerID == id).FirstOrDefault();
                if (customer == null)
                    throw new Exception("Customer Id not found.");
                var response = Request.CreateResponse<Customer>(HttpStatusCode.OK, customer);
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
