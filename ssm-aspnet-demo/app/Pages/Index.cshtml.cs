using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private SecretsManagerCache _secretsManagerCache;
    private IAmazonSecretsManager _sm;

    public ConfigModel Config { get; set; } = new();

    public string SecretValue { get; set; }


    IConfiguration _cfg;
    public IndexModel(IConfiguration cfg, IAmazonSecretsManager sm, SecretsManagerCache smc, ILogger<IndexModel> logger)
    {
        _cfg = cfg;
        _logger = logger;
        _sm = sm;
        _secretsManagerCache = smc;
    }
    public async Task OnGet()
    {
        // Bind the model from SSM Parameter Store
        _cfg.Bind(Config);


        //Get the Cached Secret
        var value = await _secretsManagerCache.GetCachedSecret("testsecret").GetSecretValue();
        SecretValue = value.SecretString;
    }
}
