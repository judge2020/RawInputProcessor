using System;

namespace RawInputProcessor
{
	public abstract class RawInput : IDisposable
	{
		protected RawInput(IntPtr handle, RawInputCaptureMode captureMode)
		{
			KeyboardDriver = new RawKeyboard(handle, captureMode == RawInputCaptureMode.Foreground);
		}

		public int NumberOfKeyboards
		{
			get { return KeyboardDriver.NumberOfKeyboards; }
		}

		protected RawKeyboard KeyboardDriver { get; }

		public void Dispose()
		{
			KeyboardDriver.Dispose();
		}

		public event EventHandler<RawInputEventArgs> KeyPressed
		{
			add { KeyboardDriver.KeyPressed += value; }
			remove { KeyboardDriver.KeyPressed -= value; }
		}

		public abstract void AddMessageFilter();
		public abstract void RemoveMessageFilter();
	}
}