using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Directory;
using Nop.Services.Events;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service
    /// </summary>
    public partial class CityService : ICityService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {1} : State ID
        /// </remarks>
        private const string CITY_ALL_KEY = "Nop.City.all-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string CITY_PATTERN_KEY = "Nop.City.";

        #endregion

        #region Fields

        private readonly IRepository<City> _cityRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="stateProvinceRepository">State/province repository</param>
        /// <param name="eventPublisher">Event published</param>
        public CityService(ICacheManager cacheManager,
            IRepository<City> cityRepository,
            IEventPublisher eventPublisher)
        {
            _cacheManager = cacheManager;
            _cityRepository = cityRepository;
            _eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        public virtual void DeleteCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("stateProvince");
            
            _cityRepository.Delete(city);

            _cacheManager.RemoveByPattern(CITY_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(city);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public virtual City GetCityById(int cityID)
        {
            if (cityID == 0)
                return null;

            return _cityRepository.GetById(cityID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IList<City> GetCityByStateProvincesId(int stateId, bool showHidden = false)
        {
            string key = string.Format(CITY_ALL_KEY, stateId);
            return _cacheManager.Get(key, () =>
            {
                var query = from sp in _cityRepository.Table
                            orderby  sp.CityName
                            where sp.StateID == stateId &&
                            (showHidden || sp.IsActive)
                            select sp;
                var cities = query.ToList();
                return cities;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IList<City> GetCity(bool showHidden = false)
        {
            var query = from sp in _cityRepository.Table
                        orderby sp.CityName
                where showHidden || sp.IsActive
                select sp;
            var cities = query.ToList();
            return cities;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void InsertCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            _cityRepository.Insert(city);

            _cacheManager.RemoveByPattern(CITY_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(city);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void UpdateCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException("city");

            _cityRepository.Update(city);

            _cacheManager.RemoveByPattern(CITY_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(city);
        }

        #endregion
    }
}
