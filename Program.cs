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
            string xamlString;
            
            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings
            {
                CompileExpressions = true 
            };
            
            String stFilePath = Directory.GetCurrentDirectory();
            stFilePath += "\\..\\..\\..\\WorkflowConsoleApplication1\\Workflow1.xaml";

            xamlString = System.IO.File.ReadAllText(stFilePath);
               
            var ActivityFromFile = ActivityXamlServices.Load(new StringReader(xamlString), settings);
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
