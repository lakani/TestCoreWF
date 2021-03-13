using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow1 = new Workflow1();
            Dictionary<string, object> inputs = new Dictionary<string, object>();

            inputs.Add("x", 50);
            inputs.Add("Path", "C:\\Work\\BUGS\\INC000000286049_Wrong_Portfolio_Position\\");

            var Ret = WorkflowInvoker.Invoke(workflow1, inputs);

            System.Console.WriteLine(Ret["Out"]);
            System.Console.ReadLine();
        }
    }
}
