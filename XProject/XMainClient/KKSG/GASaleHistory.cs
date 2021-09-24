using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GASaleHistory")]
	[Serializable]
	public class GASaleHistory : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "acttype", DataFormat = DataFormat.TwosComplement)]
		public int acttype
		{
			get
			{
				return this._acttype ?? 0;
			}
			set
			{
				this._acttype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool acttypeSpecified
		{
			get
			{
				return this._acttype != null;
			}
			set
			{
				bool flag = value == (this._acttype == null);
				if (flag)
				{
					this._acttype = (value ? new int?(this.acttype) : null);
				}
			}
		}

		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "saletime", DataFormat = DataFormat.TwosComplement)]
		public uint saletime
		{
			get
			{
				return this._saletime ?? 0U;
			}
			set
			{
				this._saletime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool saletimeSpecified
		{
			get
			{
				return this._saletime != null;
			}
			set
			{
				bool flag = value == (this._saletime == null);
				if (flag)
				{
					this._saletime = (value ? new uint?(this.saletime) : null);
				}
			}
		}

		private bool ShouldSerializesaletime()
		{
			return this.saletimeSpecified;
		}

		private void Resetsaletime()
		{
			this.saletimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "saleprice", DataFormat = DataFormat.TwosComplement)]
		public uint saleprice
		{
			get
			{
				return this._saleprice ?? 0U;
			}
			set
			{
				this._saleprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool salepriceSpecified
		{
			get
			{
				return this._saleprice != null;
			}
			set
			{
				bool flag = value == (this._saleprice == null);
				if (flag)
				{
					this._saleprice = (value ? new uint?(this.saleprice) : null);
				}
			}
		}

		private bool ShouldSerializesaleprice()
		{
			return this.salepriceSpecified;
		}

		private void Resetsaleprice()
		{
			this.salepriceSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "auctresult", DataFormat = DataFormat.TwosComplement)]
		public GuildAuctResultType auctresult
		{
			get
			{
				return this._auctresult ?? GuildAuctResultType.GA_RESULT_BUY_NOW;
			}
			set
			{
				this._auctresult = new GuildAuctResultType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool auctresultSpecified
		{
			get
			{
				return this._auctresult != null;
			}
			set
			{
				bool flag = value == (this._auctresult == null);
				if (flag)
				{
					this._auctresult = (value ? new GuildAuctResultType?(this.auctresult) : null);
				}
			}
		}

		private bool ShouldSerializeauctresult()
		{
			return this.auctresultSpecified;
		}

		private void Resetauctresult()
		{
			this.auctresultSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _acttype;

		private uint? _saletime;

		private uint? _itemid;

		private uint? _saleprice;

		private GuildAuctResultType? _auctresult;

		private IExtension extensionObject;
	}
}
