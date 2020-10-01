using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Oppgave1Web.Controllers
{
    public class ReiseController : Controller
    {
        public String hentReiseRute()
        {
            return "Dette er en reiserute";
        }
    }
}
