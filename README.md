RawInputProcessor
=================

Provides a way to distinguish input from multiple keyboards in WPF and Windows Forms.

Forked from this CodeProject article:
http://www.codeproject.com/Articles/17123/Using-Raw-Input-from-C-to-handle-multiple-keyboard

## Usage:

compile RawInputProcessor into a class library. WPF only supported for now. 

Reference it:

```c#
using RawInputProcessor.Win32;
```

Create a new object and create an event handler:

```c#
_rawInput = new RawPresentationInput(this, RawInputCaptureMode.ForegroundAndBackground);
_rawInput.KeyPressed += OnKeyPressed;

private void OnKeyPressed(object sender, RawInputEventArgs e)
{
Event = e;
DeviceCount = _rawInput.NumberOfKeyboards;
e.Handled = (ShouldHandle.IsChecked == true);
}
```

The properties of the RawInputEventArgs are on the [wiki](https://github.com/judge2020/RawInputProcessor/wiki)
