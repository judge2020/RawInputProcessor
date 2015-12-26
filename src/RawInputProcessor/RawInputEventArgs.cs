using System;

namespace RawInputProcessor
{
    public class RawInputEventArgs : EventArgs
    {
        public RawKeyboardDevice Device { get; protected set; }
        public KeyPressState KeyPressState { get; protected set; }
        public uint Message { get; protected set; }
        public int VirtualKey { get; protected set; }
        public bool Handled { get; set; }

        public RawInputEventArgs(RawKeyboardDevice device, KeyPressState keyPressState, uint message, int virtualKey)
        {
            Device = device;
            KeyPressState = keyPressState;
            Message = message;
            VirtualKey = virtualKey;
        }
    }
}