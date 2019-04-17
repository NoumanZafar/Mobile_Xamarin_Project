using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Books
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<BookViewModel> booksList;
        public ObservableCollection<BookViewModel> BooksList
        {
            get { return booksList; }
            private set { SetValue(ref booksList, value); }
        }

        private BookViewModel selectedBook;
        public BookViewModel SelectedBook
        {
            get { return selectedBook; }
            set { SetValue(ref selectedBook, value); }
        }

        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }

        public MainViewModel()
        {
            ReadList();
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<BookViewModel>(DeleteFromList);//takes the parameter
        }

        private void SaveList()
        {
            BookViewModel.SaveBooksList(BooksList);
        }

        public void DeleteFromList(BookViewModel book)
        {
            BooksList.Remove(book);
            SelectedBook = null;
        }

        public void ReadList()
        {
            BooksList = BookViewModel.ReadBooksListData();
        }
    }
}
