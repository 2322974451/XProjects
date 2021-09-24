using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyVipLevelGiftArg")]
	[Serializable]
	public class BuyVipLevelGiftArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public int vipLevel
		{
			get
			{
				return this._vipLevel ?? 0;
			}
			set
			{
				this._vipLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new int?(this.vipLevel) : null);
				}
			}
		}

		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _vipLevel;

		private IExtension extensionObject;
	}
}
