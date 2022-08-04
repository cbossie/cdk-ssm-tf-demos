using Amazon.CDK;
using Amazon.CDK.AWS.SSM;

using Constructs;

namespace CreateParameters
{
    public class CreateParametersStack : Stack
    {
        

        internal CreateParametersStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {


            // Dev paramters
            string env = "dev";
            CreateStringParam(env, "main/env-name", "Development");
            CreateStringParam(env, "main/adm-group", "dev-admins");
            CreateStringParam(env, "db/db-name", "ErpDev");
            CreateStringParam(env, "db/db-user", "dev-db");
            CreateStringParam(env, "main/email", "@yahoo.com");

            env = "uat";
            CreateStringParam(env, "main/env-name", "UserTest");
            CreateStringParam(env, "main/adm-group", "uat-admins");
            CreateStringParam(env, "db/db-name", "ErpUat");
            CreateStringParam(env, "db/db-user", "uat-db");
            CreateStringParam(env, "main/email", "@mycorp.com");


            env = "prod";
            CreateStringParam(env, "main/env-name", "Production");
            CreateStringParam(env, "main/adm-group", "enterprise-admins");
            CreateStringParam(env, "db/db-name", "MainDB");
            CreateStringParam(env, "db/db-user", "-db");
            CreateStringParam(env, "main/email", "@corporate.com");





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
