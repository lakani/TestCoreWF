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
        public InArgument<string> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
#if _CORE_
        protected override void Execute(NativeActivityContext context)
#else
        protected override void Execute(CodeActivityContext context)
#endif
        {
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);

            System.Console.WriteLine("From Activty");
        }
    }
}
