using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RemoveIBShopIcon")]
	[Serializable]
	public class RemoveIBShopIcon : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nData", DataFormat = DataFormat.TwosComplement)]
		public uint nData
		{
			get
			{
				return this._nData ?? 0U;
			}
			set
			{
				this._nData = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nDataSpecified
		{
			get
			{
				return this._nData != null;
			}
			set
			{
				bool flag = value == (this._nData == null);
				if (flag)
				{
					this._nData = (value ? new uint?(this.nData) : null);
				}
			}
		}

		private bool ShouldSerializenData()
		{
			return this.nDataSpecified;
		}

		private void ResetnData()
		{
			this.nDataSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nData;

		private IExtension extensionObject;
	}
}
