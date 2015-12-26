using System;

namespace RawInputProcessor
{
    public abstract class RawInput<T> : IDisposable
        where T : RawInputEventArgs
    {
        private readonly RawKeyboard _keyboardDriver;

        public event EventHandler<T> KeyPressed;

        public int NumberOfKeyboards
        {
            get { return KeyboardDriver.NumberOfKeyboards; }
        }

        protected RawKeyboard KeyboardDriver
        {
            get { return _keyboardDriver; }
        }

        void _keyboardDriver_KeyPressed(object sender, RawInputEventArgs e)
        {
            var hndlr = KeyPressed;
            if(hndlr!=null)
            {
                var ea = ConvertEventArgs(e);
                hndlr(this, ea);
            }
        }

        protected abstract T ConvertEventArgs(RawInputEventArgs eSource);

        protected RawInput(IntPtr handle, RawInputCaptureMode captureMode)
        {
            _keyboardDriver = new RawKeyboard(handle, captureMode == RawInputCaptureMode.Foreground);
            _keyboardDriver.KeyPressed+=_keyboardDriver_KeyPressed;
        }

        public abstract void AddMessageFilter();
        public abstract void RemoveMessageFilter();

        public void Dispose()
        {
            _keyboardDriver.KeyPressed -= _keyboardDriver_KeyPressed;
            KeyboardDriver.Dispose();
        }
    }
}