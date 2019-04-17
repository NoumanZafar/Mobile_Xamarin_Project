using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Books
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            BookViewModel book = (sender as MenuItem).CommandParameter as BookViewModel;
            (BindingContext as MainViewModel).DeleteFromList(book);
        }
    }
}
