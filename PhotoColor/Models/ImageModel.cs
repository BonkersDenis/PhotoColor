using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoColor.Models
{
    public class ImageModel : INotifyPropertyChanged
    {
        private BitmapSource _originalImage;
        private BitmapSource _processedImage;

        public BitmapSource OriginalImage
        {
            get => _originalImage;
            set
            {
                _originalImage = value;
                OnPropertyChanged(nameof(OriginalImage));
            }
        }

        public BitmapSource ProcessedImage
        {
            get => _processedImage;
            set
            {
                _processedImage = value;
                OnPropertyChanged(nameof(ProcessedImage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
