using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    public ConfigModel Config { get; set; } = new();

    IConfiguration _cfg;
    public IndexModel(IConfiguration cfg, ILogger<IndexModel> logger)
    {
        _cfg = cfg;
        _logger = logger;
    }


    public void OnGet()
    {
        // Bind the model from SSM Parameter Store
        _cfg.Bind(Config);
    }
}
