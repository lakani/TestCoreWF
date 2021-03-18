using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.Statements;
using System.Activities.XamlIntegration;
using System.IO;

namespace ActivityLib
{
#if _CORE_
    public sealed class CodeActivity1 : NativeActivity
#else
    public sealed class CodeActivity1 : CodeActivity
#endif
    {
        // Define an activity input argument of type string
        public InArgument<int> op1 { get; set; }
        public InArgument<int> op2 { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
#if _CORE_
        protected override void Execute(NativeActivityContext context)
#else
        protected override void Execute(CodeActivityContext context)
#endif
        {
            // Obtain the runtime value of the Text input argument
            int _op1 = context.GetValue(this.op1);
            int _op2 = context.GetValue(this.op2);

            int _Sum = _op1 + _op2;

            System.Console.WriteLine("From Activty, Sum is = " + _Sum.ToString());
        }
    }
}
