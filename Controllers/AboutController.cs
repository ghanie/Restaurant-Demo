using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController : Controller
    {
        public string Phone()
        {
            return "+201017844633";
        }

        public string Address()
        {
            return "Egypt";
        }
    }
}
