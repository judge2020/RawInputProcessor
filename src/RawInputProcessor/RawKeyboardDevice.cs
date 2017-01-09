using System;

namespace RawInputProcessor
{
	public sealed class RawKeyboardDevice
	{
		internal RawKeyboardDevice(string name, RawDeviceType type, IntPtr handle, string description)
		{
			Handle = handle;
			Type = type;
			Name = name;
			Description = description;
		}

		public string Name { get; }
		public RawDeviceType Type { get; }
		public IntPtr Handle { get; }
		public string Description { get; }

		public override string ToString()
		{
			return string.Format("Device\n Name: {0}\n Type: {1}\n Handle: {2}\n Name: {3}\n",
				Name,
				Type,
				Handle.ToInt64().ToString("X"),
				Description);
		}
	}
}