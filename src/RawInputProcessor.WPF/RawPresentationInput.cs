using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using RawInputProcessor;
using System.Windows.Input;

namespace RawInputProcessor.WPF
{
    public sealed class RawInputEventArgs : RawInputProcessor.RawInputEventArgs
    {
        public Key Key { get; private set; }

        public RawInputEventArgs(RawInputProcessor.RawInputEventArgs orignalToClone) 
            : base(orignalToClone.Device,orignalToClone.KeyPressState,orignalToClone.Message,orignalToClone.VirtualKey)
        {
            this.Device = orignalToClone.Device;
            this.Handled = orignalToClone.Handled;
            this.KeyPressState = orignalToClone.KeyPressState;
            this.Message = orignalToClone.Message;
            this.VirtualKey = orignalToClone.VirtualKey;
            Key = KeyInterop.KeyFromVirtualKey(this.VirtualKey);
        }
    }

    public class RawPresentationInput : RawInput<RawInputEventArgs>
    {
        private bool _hasFilter;

        public RawPresentationInput(HwndSource hwndSource, RawInputCaptureMode captureMode)
            : base(hwndSource.Handle, captureMode)
        {
            hwndSource.AddHook(Hook);
        }

        public RawPresentationInput(Visual visual, RawInputCaptureMode captureMode)
            : this(GetHwndSource(visual), captureMode)
        {
        }

        private static HwndSource GetHwndSource(Visual visual)
        {
            var source = PresentationSource.FromVisual(visual) as HwndSource;
            if (source == null)
            {
                throw new InvalidOperationException("Cannot find a valid HwndSource");
            }
            return source;
        }

        private IntPtr Hook(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            KeyboardDriver.HandleMessage(msg, wparam, lparam);
            return IntPtr.Zero;
        }

        public override void AddMessageFilter()
        {
            if (_hasFilter)
            {
                return;
            }
            ComponentDispatcher.ThreadFilterMessage += OnThreadFilterMessage;
            _hasFilter = true;
        }

        public override void RemoveMessageFilter()
        {
            ComponentDispatcher.ThreadFilterMessage -= OnThreadFilterMessage;
            _hasFilter = false;
        }

        protected override RawInputEventArgs ConvertEventArgs(RawInputProcessor.RawInputEventArgs eSource)
        {
            return new RawInputEventArgs(eSource);
        }

        // ReSharper disable once RedundantAssignment
        private void OnThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            handled = KeyboardDriver.HandleMessage(msg.message, msg.wParam, msg.lParam);
        }
    }
}