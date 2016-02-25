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
    ///Zipcode service
    /// </summary>
    public partial class ZipcodeService : IZipcodeService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {1} : City ID
        /// </remarks>
        private const string ZIPCODE_ALL_KEY = "Nop.Zipcode.all-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string ZIPCODE_PATTERN_KEY = "Nop.Zipcode.";

        #endregion

        #region Fields

        private readonly IRepository<Zipcodes> _zipcodeRepository;
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
        public ZipcodeService(ICacheManager cacheManager,
            IRepository<Zipcodes> zipcodeRepository,
            IEventPublisher eventPublisher)
        {
            _cacheManager = cacheManager;
            _zipcodeRepository = zipcodeRepository;
            _eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        public virtual void DeleteZipcode(Zipcodes zipcodes)
        {
            if (zipcodes == null)
                throw new ArgumentNullException("zipcodes");

            _zipcodeRepository.Delete(zipcodes);

            _cacheManager.RemoveByPattern(ZIPCODE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(zipcodes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public virtual Zipcodes GetZipcodeById(int zipcodeID)
        {
            if (zipcodeID == 0)
                return null;

            return _zipcodeRepository.GetById(zipcodeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IList<Zipcodes> GetZipcodesByCityId(int cityId, bool showHidden = false)
        {
            string key = string.Format(ZIPCODE_ALL_KEY, cityId);
            return _cacheManager.Get(key, () =>
            {
                var query = from sp in _zipcodeRepository.Table
                            orderby  sp.ZipcodeID
                            where sp.CityID == cityId
                            select sp;
                var zipcodes = query.ToList();
                return zipcodes;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IList<Zipcodes> GetZipcodes(bool showHidden = false)
        {
            var query = from sp in _zipcodeRepository.Table
                        orderby sp.ZipcodeID
                where showHidden || sp.IsActive
                select sp;
            var cities = query.ToList();
            return cities;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void InsertzipCodes(Zipcodes zipcodes)
        {
            if (zipcodes == null)
                throw new ArgumentNullException("zipcodes");

            _zipcodeRepository.Insert(zipcodes);

            _cacheManager.RemoveByPattern(ZIPCODE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(zipcodes);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void UpdateZipcodes(Zipcodes zipcodes)
        {
            if (zipcodes == null)
                throw new ArgumentNullException("zipcodes");

            _zipcodeRepository.Update(zipcodes);

            _cacheManager.RemoveByPattern(ZIPCODE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(zipcodes);
        }
        public virtual IList<Zipcodes> GetZipcodeByName(string zipcode) {

            if (zipcode == "")
                throw new ArgumentNullException("zipcodes");

            var query = from sp in _zipcodeRepository.Table
                    orderby sp.ZipcodeID
                    where sp.ZipcodeNumber == zipcode.Trim()
                    select sp;
            var zipcodes = query.ToList();
            return zipcodes;
        }
        #endregion
    }
}
