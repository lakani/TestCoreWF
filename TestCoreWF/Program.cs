using System;
using System.Activities;
using System.Activities.Statements;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.IO;

namespace TestCoreW
{
    

    class Program
    {
        static void Main(string[] args)
        {

            //var helloWorldActivity = new System.Activities.Statements.Sequence()
            //{
            //    Activities =
            //    {
            //        new WriteLine
            //        {
            //            Text = "Hello World! CoreWF" 
            //        } , 
            //        new MessageBox 
            //        { 
            //            Text = "new Activity"
            //        }
            //    }
            //};

            //Console.WriteLine("Hello World!");
            //System.Activities.WorkflowInvoker.Invoke(helloWorldActivity);

            //var helloWorldActivity = ActivityXamlServices.Load(new StringReader(xamlString));
            //System.Activities.WorkflowInvoker.Invoke(helloWorldActivity);
            
            
            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings
            {
                CompileExpressions = true 
            };
            
            String stFilePath = Directory.GetCurrentDirectory();
            stFilePath += "\\..\\..\\..\\..\\WorkflowConsoleApplication1\\Workflow1.xaml";

            string xamlString = System.IO.File.ReadAllText(stFilePath);
            StringReader stReader = new StringReader(xamlString);
            // TODO : pass here assemblies list
            var context = new System.Xaml.XamlSchemaContext();

            var ActivityBuilder = ActivityXamlServices.CreateBuilderReader(stReader, context);

            //var ActivityFromFile = ActivityXamlServices.Load(new StringReader(xamlString), settings);
            var ActivityFromFile = ActivityXamlServices.Load(ActivityBuilder, settings);
            
            Dictionary<string, object> inputs = new Dictionary<string, object>();

            inputs.Add("x", 50);
            inputs.Add("Path", "C:\\Work\\BUGS\\INC000000286049_Wrong_Portfolio_Position\\");

            var Ret = System.Activities.WorkflowInvoker.Invoke(ActivityFromFile, inputs);

            System.Console.WriteLine(Ret["Out"]);
            //System.Console.ReadLine();
            //Console.ReadLine();

        }
    }
}
