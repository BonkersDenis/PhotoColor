using PhotoColor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PhotoColor.Type;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using PhotoColor.Type;
using Microsoft.Scripting.Hosting;
using IronPython;
using IronPython.Hosting;
using Python.Runtime;

namespace PhotoColor.MainViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public Command OpenImageCommand { get; private set; }
        public Command ColorCommand { get; private set; }

        public string OriginalImage
        {
            get => _originalImage;
            set => Set(ref _originalImage, value, nameof(OriginalImage));
        }
        private string _originalImage;
        public string ColorImages
        {
            get => _colorImags;
            set => Set(ref _colorImags, value, nameof(ColorImages));
        }
        private string _colorImags;
        private ScriptEngine _pythonEngine;

        private ScriptScope _pyScope;

        public MainWindowViewModel()
        {
            ColorCommand = new Command(ColorImage);
            OpenImageCommand = new Command(OpenImage);
            
        }

        public void ColorImage()
        {
            ColorizeImage();
        }

        public void OpenImage()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                OriginalImage = openFileDialog.FileName;
            }
        }

        private void ColorizeImage()
        {
            if (string.IsNullOrEmpty(OriginalImage))
            {
                return;
            }

            var pythonExePath = @"C:\Users\Denis\AppData\Local\Programs\Python\Python312\python.exe"; 
            var scriptPath = @"C:\Users\Denis\OneDrive\Рабочий стол\PhotoColor\PhotoColor\main.py"; 

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $"\"{scriptPath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.OutputDataReceived += (sender, data) =>
            {
                if (data.Data != null)
                {
                    ColorImages = data.Data;
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
    }
}