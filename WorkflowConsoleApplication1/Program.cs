using System;
using System.Activities;
using System.Activities.Statements;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadFileByFile();
            return;

            Activity workflow1 = new Workflow1();
            Dictionary<string, object> inputs = new Dictionary<string, object>();

            inputs.Add("x", 50);
            inputs.Add("Path", "C:\\Work\\BUGS\\INC000000286049_Wrong_Portfolio_Position\\");

            var Ret = WorkflowInvoker.Invoke(workflow1, inputs);

            System.Console.WriteLine(Ret["Out"]);
            System.Console.ReadLine();
        }

        static void LoadFileByFile()
        {
            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings
            {
                CompileExpressions = true
            };

            //String stFilePath = Directory.GetCurrentDirectory();
            var stFilePath = "C:\\Work\\Projects\\TestCoreWF\\WorkflowConsoleApplication1\\Workflow1.xaml";

            string xamlString = System.IO.File.ReadAllText(stFilePath);
            StringReader stReader = new StringReader(xamlString);
            
            var ActivityFromFile = ActivityXamlServices.Load(new StringReader(xamlString), settings);
            Dictionary<string, object> inputs = new Dictionary<string, object>();

            inputs.Add("x", 50);
            inputs.Add("Path", "C:\\Work\\BUGS\\INC000000286049_Wrong_Portfolio_Position\\");

            var Ret = System.Activities.WorkflowInvoker.Invoke(ActivityFromFile, inputs);

            System.Console.WriteLine(Ret["Out"]);
            //System.Console.ReadLine();
            Console.ReadLine();
        }
    }
}
