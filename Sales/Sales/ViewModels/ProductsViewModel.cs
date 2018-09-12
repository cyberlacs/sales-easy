//Parte 07
namespace Sales.ViewModels
{
    using Common.Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel /*Herança de Sales.ViewModels.BaseViewModel*/
    {
        private ApiServices apiServices;//Parte 07
        private ObservableCollection<Product> _products;//Parte 07

        public ObservableCollection<Product> Products //Retorna list para Sales.Views.ProductsPage.xaml
        {
            get { return this._products; }
            set { this.SetValue(ref this._products, value); }
        }

        public ProductsViewModel()
        {
            this.apiServices = new ApiServices();
            this.LoadProducts();
        }

        private async void LoadProducts()//Envia para Sales.Services.ApiServices
        {
            var response = await this.apiServices.GetList<Product>("http://www.sistemavoltesempre.com.br", "/salesapi/api", "/Products");
            
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}
