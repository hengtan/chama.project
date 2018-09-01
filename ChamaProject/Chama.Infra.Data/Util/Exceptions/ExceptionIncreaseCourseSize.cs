using System;

namespace Chama.Infra.Data.Util.Exceptions
{
    public class ExceptionIncreaseCourseSize : Exception
    {
        public ExceptionIncreaseCourseSize()
        {
            
        }

        public ExceptionIncreaseCourseSize(string msg) : base(msg) { }
    }
}
