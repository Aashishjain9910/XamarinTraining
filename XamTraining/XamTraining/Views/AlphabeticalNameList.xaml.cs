using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlphabeticalNameList : ContentPage
    {
        List<AlphabetNameList> aNameList;
        List<AlphabetNameList> kNameList;
        List<AlphabetNameList> pNameList;
        List<AlphabetNameList> sNameList;

        public AlphabeticalNameList()
        {
            InitializeComponent();
            aNameList = new List<AlphabetNameList>
            {
                new AlphabetNameList
                {
                    ProfileImage="profile4.jpg", 
                    PersonName="Aashish", 
                    BeforeProgress="Not Started", 
                    AfterProgress="In Progress", 
                    WorkOrderId="Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage="profile8.jpg", 
                    PersonName="Arif", 
                    BeforeProgress="On Hold", 
                    AfterProgress="In Progress", 
                    WorkOrderId="Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage="tri.jpg", 
                    PersonName="Ayush", 
                    BeforeProgress="Not Started", 
                    AfterProgress="In Progress", 
                    WorkOrderId="Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage="profile4.jpg", 
                    PersonName="Azam", 
                    BeforeProgress="In Progress", 
                    AfterProgress="Completed", 
                    WorkOrderId="Work order id: FED 89045"
                }
            };

            kNameList = new List<AlphabetNameList>
            {
                new AlphabetNameList
                {
                    ProfileImage = "profile3.jpg",
                    PersonName = "Kartik",
                    BeforeProgress="In Progress",
                    AfterProgress="Completed",
                    WorkOrderId = "Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage = "profile1.jpg",
                    PersonName = "Kunwar Pratap",
                    BeforeProgress="Not Started",
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                }
            };

            pNameList = new List<AlphabetNameList>
            {
                new AlphabetNameList
                {
                    ProfileImage = "profile9.jpg",
                    PersonName = "Paras",
                    BeforeProgress="On Hold", 
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage = "profile8.jpg",
                    PersonName = "Prabhat",
                    BeforeProgress="Not Started", 
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                },
                
                new AlphabetNameList
                {
                    ProfileImage = "tri.jpg",
                    PersonName = "Prince",
                    BeforeProgress="In Progress", 
                    AfterProgress="Completed",
                    WorkOrderId = "Work order id: FED 89045"
                }
            };

            sNameList = new List<AlphabetNameList>
            {
                new AlphabetNameList
                {
                    ProfileImage = "profile4.jpg",
                    PersonName = "Shubham",
                    BeforeProgress="On Hold", 
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage = "profile7.jpg",
                    PersonName = "Shivani",
                    BeforeProgress="Not Started", 
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                },
                new AlphabetNameList
                {
                    ProfileImage = "profile1.jpg",
                    PersonName = "Swapnil",
                    BeforeProgress="Not Started", 
                    AfterProgress="In Progress",
                    WorkOrderId = "Work order id: FED 89045"
                }
            };
            List<AlphabetGroupNameList> mainNameList = new List<AlphabetGroupNameList>
            {
                new AlphabetGroupNameList("A",aNameList),
                new AlphabetGroupNameList("K",kNameList),
                new AlphabetGroupNameList("P",pNameList),
                new AlphabetGroupNameList("S",sNameList),

            };

            alphabeticalListView.ItemsSource = mainNameList;

        }
    }
}