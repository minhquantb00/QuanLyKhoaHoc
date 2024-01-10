﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.DefaultConstants;

namespace WebCourseManagement_Commons.HandleExceptions
{
    public class NotFoundException : Exception
    {
        public string Name { get; private set; }

        public NotFoundException(string name)
        {
            Name = name;
        }
        public override string Message => string.Format(Constants.ExceptionMessage.NOT_FOUND, Name);
    }
}
