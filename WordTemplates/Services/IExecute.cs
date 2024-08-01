using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Services
{
    internal interface IExecute
    {
        DocX Execute();
    }
}
