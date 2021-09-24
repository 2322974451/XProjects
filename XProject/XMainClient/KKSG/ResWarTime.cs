using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarTime")]
	[Serializable]
	public class ResWarTime : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nTime", DataFormat = DataFormat.TwosComplement)]
		public uint nTime
		{
			get
			{
				return this._nTime ?? 0U;
			}
			set
			{
				this._nTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nTimeSpecified
		{
			get
			{
				return this._nTime != null;
			}
			set
			{
				bool flag = value == (this._nTime == null);
				if (flag)
				{
					this._nTime = (value ? new uint?(this.nTime) : null);
				}
			}
		}

		private bool ShouldSerializenTime()
		{
			return this.nTimeSpecified;
		}

		private void ResetnTime()
		{
			this.nTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nTime;

		private IExtension extensionObject;
	}
}
