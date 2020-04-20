using System;
using System.Collections.Generic;
using System.Text;

namespace XamTraining.Models
{
    class AlphabetGroupNameList:List<AlphabetNameList>
    {
        public string Title
        {
            get;
            set;
        }

        public AlphabetGroupNameList(string name, List<AlphabetNameList> List) : base(List)
        {
            Title = name;
        }
    }
}
