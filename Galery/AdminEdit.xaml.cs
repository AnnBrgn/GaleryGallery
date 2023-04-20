using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Galery
{
    /// <summary>
    /// Логика взаимодействия для AdminEdit.xaml
    /// </summary>
    public partial class AdminEdit : Window, INotifyPropertyChanged
    {

        public List<Genre> Genres { get; set; }
        public List<Time> Times { get; set; }
        
        public Crosscreatorpaint Paint { get; }

        public AdminEdit(Crosscreatorpaint paint)
        {
            InitializeComponent();
            GalleryContext galleryContext = new GalleryContext();
            Genres = galleryContext.Genres.ToList();
            Times = galleryContext.Times.ToList();
            Paint = paint;
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Apply(object sender, RoutedEventArgs e)
        {
            GalleryContext galleryContext = new GalleryContext();
                galleryContext.Paints.Update(Paint.IdPaintNavigation);
                galleryContext.Creators.Update(Paint.IdCreatorNavigation);
            galleryContext.SaveChanges();
            //что-то
        }
    }
}
