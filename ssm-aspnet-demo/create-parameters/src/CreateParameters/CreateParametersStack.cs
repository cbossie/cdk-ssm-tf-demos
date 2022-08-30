using Amazon.CDK;
using Amazon.CDK.AWS.SSM;
using Amazon.CDK.AWS.SecretsManager;

using Constructs;

namespace CreateParameters
{
    public class CreateParametersStack : Stack
    {
        

        internal CreateParametersStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {


            // Dev paramters
            string env = "dev";
            CreateStringParam(env, "main/environmentname", "Development");
            CreateStringParam(env, "main/administratorgroup", "dev-admins");
            CreateStringParam(env, "db/databasename", "ErpDev");
            CreateStringParam(env, "db/databaseusername", "dev-db");
            CreateStringParam(env, "main/email", "@yahoo.com");

            env = "uat";
            CreateStringParam(env, "main/environmentname", "UserTest");
            CreateStringParam(env, "main/adm-group", "uat-admins");
            CreateStringParam(env, "db/databasename", "ErpUat");
            CreateStringParam(env, "db/databaseusername", "uat-db");
            CreateStringParam(env, "main/email", "@mycorp.com");


            env = "prod";
            CreateStringParam(env, "main/environmentname", "Production");
            CreateStringParam(env, "main/adm-group", "enterprise-admins");
            CreateStringParam(env, "db/databasename", "MainDB");
            CreateStringParam(env, "db/databaseusername", "-db");
            CreateStringParam(env, "main/email", "@corporate.com");


            new Secret(this, "testsecret",new SecretProps
            {
                SecretName = "testsecret",
                SecretStringValue = new SecretValue("Hello from Virginia")
            });




        }

        private StringParameter CreateStringParam(string env, string paramname, string paramvalue)
        {
            string uniqueId = $"{env}-{paramname.Replace("/", "-")}";

            var param = new StringParameter(this, uniqueId, new StringParameterProps
            {
                ParameterName = $"/{env}/{paramname}",
                StringValue = paramvalue
            });
            return param;
        }
    }
}
