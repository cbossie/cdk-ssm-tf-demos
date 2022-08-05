using System;
using Constructs;
using HashiCorp.Cdktf;

namespace MyCompany.MyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            App app = new App();
            var stack = new MyStack(app, "cdktf");
            new LocalBackend(stack, new LocalBackendProps());

            app.Synth();
            Console.WriteLine("App synth complete");
        }
    }
}