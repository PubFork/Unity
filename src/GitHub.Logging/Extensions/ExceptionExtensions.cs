using System;
using System.Linq;

namespace GitHub.Unity.Logs
{
    static class ExceptionExtensions
    {
        public static string GetExceptionMessage(this Exception ex)
        {
            var message = ex.ToString();
            var inner = ex.InnerException;
            while (inner != null)
            {
                message += Environment.NewLine + inner.ToString();
                inner = inner.InnerException;
            }
            var caller = Environment.StackTrace;
            var stack = caller.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            message += Environment.NewLine + "=======";
            message += Environment.NewLine + String.Join(Environment.NewLine, stack.Skip(1).SkipWhile(x => x.Contains("GitHub.Unity.Logs")).ToArray());
            return message;
        }
    }
}