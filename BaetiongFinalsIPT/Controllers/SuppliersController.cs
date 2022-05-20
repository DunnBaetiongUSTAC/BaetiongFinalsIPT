using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaetiongFinalsIPT.Models;

namespace BaetiongFinalsIPT.Controllers
{
    public class SuppliersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTFinalsBaetiongEntitiesLast db = new IPTFinalsBaetiongEntitiesLast();
                var suppliers = db.Suppliers;
                var response = Request.CreateResponse<IEnumerable<Supplier>>(HttpStatusCode.OK, suppliers);
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
                var supplier = db.Suppliers.Where(m => m.SuppliersID == id).FirstOrDefault();
                if (supplier == null)
                    throw new Exception("Supplier Id not found.");
                var response = Request.CreateResponse<Supplier>(HttpStatusCode.OK, supplier);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }

        }
    }
}
