using System;
using Constructs;
using HashiCorp.Cdktf;

using HashiCorp.Cdktf.Providers.Aws;

using HashiCorp.Cdktf.Providers.Aws.Ec2;
using HashiCorp.Cdktf.Providers.Aws.S3;
using HashiCorp.Cdktf.Providers.Aws.Ssm;

namespace MyCompany.MyApp
{
    class MyStack : TerraformStack
    {
        public MyStack(Construct scope, string id) : base(scope, id)
        {
            new AwsProvider(this, "AWS", new AwsProviderConfig 
            {
                 Region = "us-west-2",
                 Profile = "dotnet-west-2"
            });



            new TerraformOutput(this, "paramName", new TerraformOutputConfig
            {
            });
        }
    }
}
