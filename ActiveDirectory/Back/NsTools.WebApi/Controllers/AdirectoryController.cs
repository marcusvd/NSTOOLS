using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace NsTools.WebApi.Controllers
{

    [Route("api/{controller}")]
    [ApiController]
    public class AdirectoryController : ControllerBase
    {
        public AdirectoryController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            string usr = "adm01";
            string toShow = string.Empty;
            DirectoryEntry adLdapConnection = CreateDirectoryEntry();
            DirectorySearcher search = new DirectorySearcher(adLdapConnection);
            search.Filter = "(cn=" + usr + ")";

            SearchResult result = search.FindOne();

            if (result != null)
            {
                ResultPropertyCollection fields = result.Properties;
                foreach (String ldapField in fields.PropertyNames)
                {
                    foreach (Object myCollection in fields[ldapField])
                    {
                         toShow = (String.Format("{0,-20} : {1}", ldapField, myCollection.ToString()));
                    }
                }
            }


            return Ok(toShow);
        }



    }
}