using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace B_Commerce.Common.Helper
{
    public class ExceptionHelper
    {

        public class LogException
        {

            public int ExceptionLine { get; set; }
            public string MethodName { get; set; }
            public string ExceptionMessage { get; set; }
            public string ExceptionStackTrace { get; set; }


            public static LogException ShowDebugInfo(Exception ownException)
            {

                LogException exceptionInfo = new LogException();
                try
                {

                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ownException, true);
                    StackFrame stackFrame = trace.GetFrame(0);
                    MethodBase method = stackFrame.GetMethod();
                    exceptionInfo.MethodName = method.DeclaringType.FullName;
                    exceptionInfo.ExceptionLine = stackFrame.GetFileLineNumber();
                    exceptionInfo.ExceptionMessage = ownException.Message;
                    exceptionInfo.ExceptionStackTrace = ownException.StackTrace;

                   

                   

                }
                catch (System.Exception x)
                {

                }
                return exceptionInfo;
            }



            public override string ToString()
            {
                //Newtonsoft json işlemleri için kullanılan dll.
                //objecten jsona   jsondan objecte donus yapabilir.
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
        }
    }
}
