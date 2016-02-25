using System.Collections.Generic;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// Zipcode service interface
    /// </summary>
    public partial interface IZipcodeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>

        void DeleteZipcode(Zipcodes zipcodes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        Zipcodes GetZipcodeById(int zipcodeID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        IList<Zipcodes> GetZipcodeByName(string zipcode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Zipcodes> GetZipcodesByCityId(int cityId, bool showHidden = false);

        /// <summary>
        /// GetCity
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Zipcodes> GetZipcodes(bool showHidden = false);

        /// <summary>
        /// InsertCity
        /// </summary>
        /// <param name="city"></param>
        void InsertzipCodes(Zipcodes zipcode);
        /// <summary>
        /// UpdateCity
        /// </summary>
        /// <param name="city"></param>
        void UpdateZipcodes(Zipcodes zipcodes);
    }
}
