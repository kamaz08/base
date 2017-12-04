using Base.Model.Repository.Preference;
using Base.Model.ViewModel.PreferenceVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Base.Controllers.Preference
{
    [Authorize]
    public class PreferenceController : BaseController
    {
        private PreferenceRepository _preferenceRepository;
        public PreferenceController()
        {
            this._preferenceRepository = new PreferenceRepository();
        }

        [HttpGet] 
        public List<PreferenceVM> GetCityPreference()
        {
            var user = GetCurrentUser();

            return _preferenceRepository.GetCityPreference(user.Id);
        }

        [HttpGet]
        public List<PreferenceVM> GetCategoryPreference()
        {
            var user = GetCurrentUser();

            return _preferenceRepository.GetCategoryPreference(user.Id);
        }

        [HttpPost]
        public IHttpActionResult UpdateCityPreference(List<PreferenceVM> preferenceList)
        {
            var user = this.GetCurrentUser();

            _preferenceRepository.UpdateCityPreference(user.Id, preferenceList);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateCategoryPreference(List<PreferenceVM> preferenceList)
        {
            var user = this.GetCurrentUser();

            _preferenceRepository.UpdateCategoryPreference(user.Id, preferenceList);

            return Ok();
        }


    }
}
