using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Base.Controllers.Account
{
    public class BaseController : ApiController
    {
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            string errMessage = string.Empty;
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    errMessage = String.Join("\n", result.Errors);

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(errMessage);
            }
            return null;
        }

        protected IHttpActionResult GetErrorResultModel()
        {
            string errMessage = String.Join("\n", ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));


            return BadRequest(errMessage);
        }
    }
}
