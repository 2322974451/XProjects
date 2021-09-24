using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemJadeSingle")]
	[Serializable]
	public class ItemJadeSingle : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "SlotPos", DataFormat = DataFormat.TwosComplement)]
		public uint SlotPos
		{
			get
			{
				return this._SlotPos ?? 0U;
			}
			set
			{
				this._SlotPos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SlotPosSpecified
		{
			get
			{
				return this._SlotPos != null;
			}
			set
			{
				bool flag = value == (this._SlotPos == null);
				if (flag)
				{
					this._SlotPos = (value ? new uint?(this.SlotPos) : null);
				}
			}
		}

		private bool ShouldSerializeSlotPos()
		{
			return this.SlotPosSpecified;
		}

		private void ResetSlotPos()
		{
			this.SlotPosSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public uint ItemId
		{
			get
			{
				return this._ItemId ?? 0U;
			}
			set
			{
				this._ItemId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ItemIdSpecified
		{
			get
			{
				return this._ItemId != null;
			}
			set
			{
				bool flag = value == (this._ItemId == null);
				if (flag)
				{
					this._ItemId = (value ? new uint?(this.ItemId) : null);
				}
			}
		}

		private bool ShouldSerializeItemId()
		{
			return this.ItemIdSpecified;
		}

		private void ResetItemId()
		{
			this.ItemIdSpecified = false;
		}

		[ProtoMember(3, Name = "AttrId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrId
		{
			get
			{
				return this._AttrId;
			}
		}

		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SlotPos;

		private uint? _ItemId;

		private readonly List<uint> _AttrId = new List<uint>();

		private readonly List<uint> _AttrValue = new List<uint>();

		private IExtension extensionObject;
	}
}
