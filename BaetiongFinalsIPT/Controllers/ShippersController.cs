using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models;

namespace BaetiongFinalsIPT.Controllers
{
    public class ShippersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var shippers = db.Shippers;
                var response = Request.CreateResponse<IEnumerable<Shipper>>(HttpStatusCode.OK, shippers);
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
                var shippers = db.Shippers.Where(m => m.ShipperID == id).FirstOrDefault();
                if (shippers == null)
                    throw new Exception("Shipper Id not found.");
                var response = Request.CreateResponse<Shipper>(HttpStatusCode.OK, shippers);
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
