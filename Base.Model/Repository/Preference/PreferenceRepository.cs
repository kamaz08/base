using Base.Model.Model;
using Base.Model.Model.Location;
using Base.Model.Model.OrderModel;
using Base.Model.ViewModel.PreferenceVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.Preference
{
    public class PreferenceRepository
    {
        private PracaDorywczaDbContext db;

        public PreferenceRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public List<PreferenceVM> GetCategoryPreference(String userId)
        {
            var category = db.OrderCategory.ToList()
                .Select<OrderCategory, PreferenceVM>(x => x)
                .ToList();

            var preference = db.Preference
                .Where(x => x.AppUserId == userId)
                .ToList();

            category.ForEach(x => x.Selected = preference.Exists(y => y.OrderCategoryId == x.Id));

            return category;
        }

        public List<PreferenceVM> GetCityPreference(String userId)
        {
            var category = db.City.ToList()
                .Select<City, PreferenceVM>(x => x)
                .ToList();

            var preference = db.CityPreference
                .Where(x => x.AppUserId == userId)
                .ToList();

            category.ForEach(x => x.Selected = preference.Exists(y => y.CityId == x.Id));

            return category;
        }

        public void UpdateCategoryPreference(String userId, List<PreferenceVM> list)
        {
            var preference = db.Preference.Where(x => x.AppUserId == userId);

            var unselected = list.Where(x => !x.Selected).Select(x => x.Id).ToList();

            var toDelete = preference.Where(x => unselected.Contains(x.OrderCategoryId));
            db.Preference.RemoveRange(toDelete);

            var toAdd = list.Where(x => x.Selected).Select(x => x.Id).ToList();

            toAdd.ForEach(x =>
                db.Preference.Add(new Model.User.Preference
                {
                    AppUserId = userId,
                    OrderCategoryId = x
                }));

            db.SaveChanges();
        }

        public void UpdateCityPreference(String userId, List<PreferenceVM> list)
        {
            var preference = db.CityPreference.Where(x => x.AppUserId == userId);

            var unselected = list.Where(x => !x.Selected).Select(x => x.Id).ToList();

            if (unselected.Count > 0)
            {
                var toDelete = preference.Where(x => unselected.Contains(x.CityId)).ToList();
                if (toDelete.Count > 0) db.CityPreference.RemoveRange(toDelete);
            }
            var toAdd = list.Where(x => x.Selected).Select(x => x.Id).ToList();

            toAdd.ForEach(x =>
                db.CityPreference.Add(new Model.User.CityPreference
                {
                    AppUserId = userId,
                    CityId = x
                }));

            db.SaveChanges();
        }


    }
}