using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models;

namespace BaetiongFinalsIPT.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var order = db.Orders;
                var response = Request.CreateResponse<IEnumerable<Order>>(HttpStatusCode.OK, order);
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
                var order = db.Orders.Where(m => m.OrderID == id).FirstOrDefault();
                if (order == null)
                    throw new Exception("Order Id not found.");
                var response = Request.CreateResponse<Order>(HttpStatusCode.OK, order);
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
