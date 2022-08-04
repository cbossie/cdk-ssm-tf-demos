using System.Text.Json.Serialization;

namespace app;

public class ConfigModel
{
    public string EnvironmentName { get; set; }

    public string AdministratorGroup { get; set; }

    public string DatabaseName { get; set; }

    public string DatabaseUserName { get; set; }
        
    public string Email { get; set; }
}
