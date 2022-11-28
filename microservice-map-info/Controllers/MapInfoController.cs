using System;
using GoogleMapInfo;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

namespace microservice_map_info.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapInfoController: ControllerBase
    {

        private readonly GoogleDistanceApi _googleDistanceApi;
        public MapInfoController(GoogleDistanceApi googleDistanceApi)
        {
            _googleDistanceApi = googleDistanceApi;
        }
        [HttpGet]
        public async Task<GoogleDistanceData> GetDistance(string originCity,string destinationCity)
        {
            return await _googleDistanceApi.GetMapDistance(originCity,
            destinationCity);
        } 
    }
}

