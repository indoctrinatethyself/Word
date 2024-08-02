using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Services
{
    //this abstract class is created for convinience purpose, to be rewritten
    internal abstract class Executioneer
    {
        internal static DocX document;
        internal abstract DocX Execute();
        internal abstract DocX Execute(DocX document);
    }
}
