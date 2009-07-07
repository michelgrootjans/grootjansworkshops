using System;
using System.Collections.Generic;
using System.Web.UI;
using Domain;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var names = new List<string> { "Albert Einstein", "John Cleese", "George W. Bush" };
            var namePrinter = new NamePrinter(n => Response.Write(n + "<br/>"));
            namePrinter.Print(names);
        }
    }
}