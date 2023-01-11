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
        foreach (var header in Request.Headers)
        {
            debug_data += "<p><b>" + header.Key + ": </b>" + header.Value + "</p>";
        }

    }
}
