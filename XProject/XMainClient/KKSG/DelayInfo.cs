using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DelayInfo")]
	[Serializable]
	public class DelayInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "delay", DataFormat = DataFormat.TwosComplement)]
		public uint delay
		{
			get
			{
				return this._delay ?? 0U;
			}
			set
			{
				this._delay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool delaySpecified
		{
			get
			{
				return this._delay != null;
			}
			set
			{
				bool flag = value == (this._delay == null);
				if (flag)
				{
					this._delay = (value ? new uint?(this.delay) : null);
				}
			}
		}

		private bool ShouldSerializedelay()
		{
			return this.delaySpecified;
		}

		private void Resetdelay()
		{
			this.delaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _delay;

		private IExtension extensionObject;
	}
}
