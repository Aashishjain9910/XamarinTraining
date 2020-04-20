using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamTraining.Models
{
    class AlphabetNameList:INotifyPropertyChanged
    {
        public string ProfileImage
        {
            get;
            set;
        }
        public string PersonName
        {
            get;
            set;
        }
        
        public string BeforeProgress { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public string beforeProgressColor
        {
            get
            {
                if(BeforeProgress== "On Hold")
                {
                    return "#fac177";
                }
                else if(BeforeProgress== "Not Started")
                {
                    return "#d47476";
                }
                else if(BeforeProgress== "In Progress")
                {
                    return "#d77f80";
                }
                else
                {
                    return "#96d099";
                }

            }
            
        }
        public string AfterProgress
        {
            get;
            set;
        }

        public string afterProgressColor
        {
            get
            {
                if (AfterProgress == "In Progress")
                {
                    return "#7ab8f7";
                }
                else if(AfterProgress=="Completed")
                {
                    return "#abd9ad";
                }
                else
                {
                    return "#d67c7e";
                }
            }
        }

        public string WorkOrderId
        {
            get;
            set;
        }

    }
}
