using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctOverlapData")]
	[Serializable]
	public class AuctOverlapData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "overlapid", DataFormat = DataFormat.TwosComplement)]
		public ulong overlapid
		{
			get
			{
				return this._overlapid ?? 0UL;
			}
			set
			{
				this._overlapid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool overlapidSpecified
		{
			get
			{
				return this._overlapid != null;
			}
			set
			{
				bool flag = value == (this._overlapid == null);
				if (flag)
				{
					this._overlapid = (value ? new ulong?(this.overlapid) : null);
				}
			}
		}

		private bool ShouldSerializeoverlapid()
		{
			return this.overlapidSpecified;
		}

		private void Resetoverlapid()
		{
			this.overlapidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "perprice", DataFormat = DataFormat.TwosComplement)]
		public uint perprice
		{
			get
			{
				return this._perprice ?? 0U;
			}
			set
			{
				this._perprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool perpriceSpecified
		{
			get
			{
				return this._perprice != null;
			}
			set
			{
				bool flag = value == (this._perprice == null);
				if (flag)
				{
					this._perprice = (value ? new uint?(this.perprice) : null);
				}
			}
		}

		private bool ShouldSerializeperprice()
		{
			return this.perpriceSpecified;
		}

		private void Resetperprice()
		{
			this.perpriceSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item itemdata
		{
			get
			{
				return this._itemdata;
			}
			set
			{
				this._itemdata = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _overlapid;

		private uint? _perprice;

		private Item _itemdata = null;

		private IExtension extensionObject;
	}
}
