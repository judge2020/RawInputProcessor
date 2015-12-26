using RawInputProcessor.WPF;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RawInputProcessor.WPFDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private RawPresentationInput _rawInput;
        private int _deviceCount;
        private RawInputEventArgs _event;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public int DeviceCount
        {
            get { return _deviceCount; }
            set
            {
                _deviceCount = value;
                OnPropertyChanged("DeviceCount");
            }
        }

        public RawInputEventArgs Event
        {
            get { return _event; }
            set
            {
                _event = value;
                OnPropertyChanged("Event");
            }
        }

        private void OnKeyPressed(object sender, RawInputEventArgs e)
        {
            Event = e;
            DeviceCount = _rawInput.NumberOfKeyboards;
            e.Handled = (ShouldHandle.IsChecked == true);
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            StartWndProcHandler();
            base.OnSourceInitialized(e);
        }

        private void StartWndProcHandler()
        {
            _rawInput = new RawPresentationInput(this, RawInputCaptureMode.Foreground);
            _rawInput.KeyPressed += OnKeyPressed;
            DeviceCount = _rawInput.NumberOfKeyboards;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}