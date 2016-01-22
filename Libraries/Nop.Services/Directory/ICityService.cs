using System.Collections.Generic;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// City service interface
    /// </summary>
    public partial interface ICityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>

        void DeleteCity(City city);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        City GetCityById(int cityID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<City> GetCityByStateProvincesId(int stateId, bool showHidden = false);

        /// <summary>
        /// GetCity
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<City> GetCity(bool showHidden = false);

        /// <summary>
        /// InsertCity
        /// </summary>
        /// <param name="city"></param>
        void InsertCity(City city);
        /// <summary>
        /// UpdateCity
        /// </summary>
        /// <param name="city"></param>
        void UpdateCity(City city);
    }
}
