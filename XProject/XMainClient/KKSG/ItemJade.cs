using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemJade")]
	[Serializable]
	public class ItemJade : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "SlotInfo", DataFormat = DataFormat.TwosComplement)]
		public uint SlotInfo
		{
			get
			{
				return this._SlotInfo ?? 0U;
			}
			set
			{
				this._SlotInfo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SlotInfoSpecified
		{
			get
			{
				return this._SlotInfo != null;
			}
			set
			{
				bool flag = value == (this._SlotInfo == null);
				if (flag)
				{
					this._SlotInfo = (value ? new uint?(this.SlotInfo) : null);
				}
			}
		}

		private bool ShouldSerializeSlotInfo()
		{
			return this.SlotInfoSpecified;
		}

		private void ResetSlotInfo()
		{
			this.SlotInfoSpecified = false;
		}

		[ProtoMember(2, Name = "ItemJadeSingle", DataFormat = DataFormat.Default)]
		public List<ItemJadeSingle> ItemJadeSingle
		{
			get
			{
				return this._ItemJadeSingle;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SlotInfo;

		private readonly List<ItemJadeSingle> _ItemJadeSingle = new List<ItemJadeSingle>();

		private IExtension extensionObject;
	}
}
