using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SelectChestArg")]
	[Serializable]
	public class SelectChestArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "chestIdx", DataFormat = DataFormat.TwosComplement)]
		public uint chestIdx
		{
			get
			{
				return this._chestIdx ?? 0U;
			}
			set
			{
				this._chestIdx = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chestIdxSpecified
		{
			get
			{
				return this._chestIdx != null;
			}
			set
			{
				bool flag = value == (this._chestIdx == null);
				if (flag)
				{
					this._chestIdx = (value ? new uint?(this.chestIdx) : null);
				}
			}
		}

		private bool ShouldSerializechestIdx()
		{
			return this.chestIdxSpecified;
		}

		private void ResetchestIdx()
		{
			this.chestIdxSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _chestIdx;

		private IExtension extensionObject;
	}
}
