using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionAllReqArg")]
	[Serializable]
	public class AuctionAllReqArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public AuctionAllReqType reqtype
		{
			get
			{
				return this._reqtype ?? AuctionAllReqType.ART_REQSALE;
			}
			set
			{
				this._reqtype = new AuctionAllReqType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new AuctionAllReqType?(this.reqtype) : null);
				}
			}
		}

		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemuniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong itemuniqueid
		{
			get
			{
				return this._itemuniqueid ?? 0UL;
			}
			set
			{
				this._itemuniqueid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemuniqueidSpecified
		{
			get
			{
				return this._itemuniqueid != null;
			}
			set
			{
				bool flag = value == (this._itemuniqueid == null);
				if (flag)
				{
					this._itemuniqueid = (value ? new ulong?(this.itemuniqueid) : null);
				}
			}
		}

		private bool ShouldSerializeitemuniqueid()
		{
			return this.itemuniqueidSpecified;
		}

		private void Resetitemuniqueid()
		{
			this.itemuniqueidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "perprice", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "overlapid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "auctuid", DataFormat = DataFormat.TwosComplement)]
		public ulong auctuid
		{
			get
			{
				return this._auctuid ?? 0UL;
			}
			set
			{
				this._auctuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool auctuidSpecified
		{
			get
			{
				return this._auctuid != null;
			}
			set
			{
				bool flag = value == (this._auctuid == null);
				if (flag)
				{
					this._auctuid = (value ? new ulong?(this.auctuid) : null);
				}
			}
		}

		private bool ShouldSerializeauctuid()
		{
			return this.auctuidSpecified;
		}

		private void Resetauctuid()
		{
			this.auctuidSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "istreasure", DataFormat = DataFormat.Default)]
		public bool istreasure
		{
			get
			{
				return this._istreasure ?? false;
			}
			set
			{
				this._istreasure = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool istreasureSpecified
		{
			get
			{
				return this._istreasure != null;
			}
			set
			{
				bool flag = value == (this._istreasure == null);
				if (flag)
				{
					this._istreasure = (value ? new bool?(this.istreasure) : null);
				}
			}
		}

		private bool ShouldSerializeistreasure()
		{
			return this.istreasureSpecified;
		}

		private void Resetistreasure()
		{
			this.istreasureSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private AuctionAllReqType? _reqtype;

		private uint? _itemid;

		private ulong? _itemuniqueid;

		private uint? _itemcount;

		private uint? _perprice;

		private ulong? _overlapid;

		private ulong? _auctuid;

		private bool? _istreasure;

		private IExtension extensionObject;
	}
}
