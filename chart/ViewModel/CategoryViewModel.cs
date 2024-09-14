using chart.Models;
using chart.Repositories;
using chart.ViewModel.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chart.ViewModel
{
    public partial class CategoryViewModel : BaseView
    {
        private CategoryRepositorys _repository;

        [ObservableProperty]
        public ObservableCollection<Categorys> categorys = new ObservableCollection<Categorys>();

        public CategoryViewModel(CategoryRepositorys categoryRepositorys)
        {
            _repository = categoryRepositorys;
            loadProcess();
        }

        public async Task loadProcess()
        {
            IsBusy = true;
            try
            {
                if (_repository == null)
                    throw new ArgumentNullException(nameof(_repository));

                categorys.Clear();

                var categoryToList = await _repository.GET();

                foreach (var categorysReadyList in categoryToList)
                {
                    categorys.Add(categorysReadyList);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Ошибка загрузки категорий: {ex.Message}");
            }
            finally 
            {
                IsBusy = false;
            }
        }
    }
}
