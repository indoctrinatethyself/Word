﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Services.NameChanger
{
    internal class NameChanger:IExecute
    {
        DocX document;
        NameChanger(DocX _document)
        {
            document = _document;
        }
        void Execute()
        {

        }
    }
}
