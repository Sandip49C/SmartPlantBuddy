using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPlantBuddy.Services
{
    public interface IWeatherService
    {
        Task<string> GetCurrentWeatherAsync();
    }
}
