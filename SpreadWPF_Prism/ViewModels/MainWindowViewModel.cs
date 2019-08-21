using System.Data;
using Prism.Mvvm;
using Prism.Commands;

namespace SpreadWPF_Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            // モデルからデータを取得
            Products = ProductModel.GetProducts();

            // DelegateCommandの設定
            SelectedCommand = new DelegateCommand(OnItemSelected);
        }

        private DataTable _products;
        public DataTable Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        private int _productPrice;
        public int ProductPrice
        {
            get => _productPrice;
            set => SetProperty(ref _productPrice, value);
        }

        private DataRowView _selectedProduct;
        public DataRowView SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }
        //public DataRowView SelectedProduct
        //{
        //    get => _selectedProduct;
        //    set
        //    {
        //        SetProperty(ref _selectedProduct, value);
        //        this.ProductName = (string)this.SelectedProduct["Name"];
        //        this.ProductPrice = (int)this.SelectedProduct["Price"];
        //    }
        //}

        public DelegateCommand SelectedCommand { get; private set; }
        private void OnItemSelected()
        {
            this.ProductName = (string)this.SelectedProduct["Name"];
            this.ProductPrice = (int)this.SelectedProduct["Price"];
        }
    }
}
