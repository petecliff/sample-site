using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleSite.Pages;

public class IndexModel : PageModel
{
    public string debug_data = String.Empty;
    public string site_name = Environment.GetEnvironmentVariable("SITE_NAME") ?? "Sample Site - Default";
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var headers = Request.Headers;
        PropertyInfo[] properties = headers.GetType().GetProperties();
        foreach (var prop in properties)
        {
            debug_data += "<p><b>" + prop.Name + ": </b>" + Request.Headers[prop.Name] + "</p>";
        }

    }
}
