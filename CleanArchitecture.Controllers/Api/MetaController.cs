using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CleanArchitecture.Web.Api
{
    public class MetaController : BaseApiController
    {
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            //TODO Move to UseCase
            var assembly = typeof(MetaController).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}
