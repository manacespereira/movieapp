using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MovieApp.Services
{
    public interface ICultureService
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo cultureInfo);
    }
}
