using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamTraining.Models
{
    class ActivityIndicatorModel : BaseViewModel
    {
        private bool isLoadingData;

        public bool IsLoadingData
        {
            get => isLoadingData;
            set => SetProperty(ref isLoadingData, value);
        }

        public async Task LoadData()
        {
            IsLoadingData = true;
            await Task.Delay(30000);
            IsLoadingData = false;
        }

    }
}
