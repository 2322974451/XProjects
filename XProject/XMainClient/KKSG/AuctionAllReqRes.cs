using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionAllReqRes")]
	[Serializable]
	public class AuctionAllReqRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		[ProtoMember(2, Name = "itembrief", DataFormat = DataFormat.Default)]
		public List<AuctItemBrief> itembrief
		{
			get
			{
				return this._itembrief;
			}
		}

		[ProtoMember(3, Name = "overlapdata", DataFormat = DataFormat.Default)]
		public List<AuctOverlapData> overlapdata
		{
			get
			{
				return this._overlapdata;
			}
		}

		[ProtoMember(4, Name = "saledata", DataFormat = DataFormat.Default)]
		public List<AuctionSaleData> saledata
		{
			get
			{
				return this._saledata;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "autorefreshlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint autorefreshlefttime
		{
			get
			{
				return this._autorefreshlefttime ?? 0U;
			}
			set
			{
				this._autorefreshlefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool autorefreshlefttimeSpecified
		{
			get
			{
				return this._autorefreshlefttime != null;
			}
			set
			{
				bool flag = value == (this._autorefreshlefttime == null);
				if (flag)
				{
					this._autorefreshlefttime = (value ? new uint?(this.autorefreshlefttime) : null);
				}
			}
		}

		private bool ShouldSerializeautorefreshlefttime()
		{
			return this.autorefreshlefttimeSpecified;
		}

		private void Resetautorefreshlefttime()
		{
			this.autorefreshlefttimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "tradeprice", DataFormat = DataFormat.TwosComplement)]
		public uint tradeprice
		{
			get
			{
				return this._tradeprice ?? 0U;
			}
			set
			{
				this._tradeprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tradepriceSpecified
		{
			get
			{
				return this._tradeprice != null;
			}
			set
			{
				bool flag = value == (this._tradeprice == null);
				if (flag)
				{
					this._tradeprice = (value ? new uint?(this.tradeprice) : null);
				}
			}
		}

		private bool ShouldSerializetradeprice()
		{
			return this.tradepriceSpecified;
		}

		private void Resettradeprice()
		{
			this.tradepriceSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "leftfreerefreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint leftfreerefreshcount
		{
			get
			{
				return this._leftfreerefreshcount ?? 0U;
			}
			set
			{
				this._leftfreerefreshcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftfreerefreshcountSpecified
		{
			get
			{
				return this._leftfreerefreshcount != null;
			}
			set
			{
				bool flag = value == (this._leftfreerefreshcount == null);
				if (flag)
				{
					this._leftfreerefreshcount = (value ? new uint?(this.leftfreerefreshcount) : null);
				}
			}
		}

		private bool ShouldSerializeleftfreerefreshcount()
		{
			return this.leftfreerefreshcountSpecified;
		}

		private void Resetleftfreerefreshcount()
		{
			this.leftfreerefreshcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "itemleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemleftcount
		{
			get
			{
				return this._itemleftcount ?? 0U;
			}
			set
			{
				this._itemleftcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemleftcountSpecified
		{
			get
			{
				return this._itemleftcount != null;
			}
			set
			{
				bool flag = value == (this._itemleftcount == null);
				if (flag)
				{
					this._itemleftcount = (value ? new uint?(this.itemleftcount) : null);
				}
			}
		}

		private bool ShouldSerializeitemleftcount()
		{
			return this.itemleftcountSpecified;
		}

		private void Resetitemleftcount()
		{
			this.itemleftcountSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "freerefreshlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint freerefreshlefttime
		{
			get
			{
				return this._freerefreshlefttime ?? 0U;
			}
			set
			{
				this._freerefreshlefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freerefreshlefttimeSpecified
		{
			get
			{
				return this._freerefreshlefttime != null;
			}
			set
			{
				bool flag = value == (this._freerefreshlefttime == null);
				if (flag)
				{
					this._freerefreshlefttime = (value ? new uint?(this.freerefreshlefttime) : null);
				}
			}
		}

		private bool ShouldSerializefreerefreshlefttime()
		{
			return this.freerefreshlefttimeSpecified;
		}

		private void Resetfreerefreshlefttime()
		{
			this.freerefreshlefttimeSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "need_copyitem", DataFormat = DataFormat.Default)]
		public bool need_copyitem
		{
			get
			{
				return this._need_copyitem ?? false;
			}
			set
			{
				this._need_copyitem = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool need_copyitemSpecified
		{
			get
			{
				return this._need_copyitem != null;
			}
			set
			{
				bool flag = value == (this._need_copyitem == null);
				if (flag)
				{
					this._need_copyitem = (value ? new bool?(this.need_copyitem) : null);
				}
			}
		}

		private bool ShouldSerializeneed_copyitem()
		{
			return this.need_copyitemSpecified;
		}

		private void Resetneed_copyitem()
		{
			this.need_copyitemSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errcode;

		private readonly List<AuctItemBrief> _itembrief = new List<AuctItemBrief>();

		private readonly List<AuctOverlapData> _overlapdata = new List<AuctOverlapData>();

		private readonly List<AuctionSaleData> _saledata = new List<AuctionSaleData>();

		private uint? _autorefreshlefttime;

		private uint? _tradeprice;

		private uint? _leftfreerefreshcount;

		private uint? _itemleftcount;

		private uint? _freerefreshlefttime;

		private bool? _need_copyitem;

		private IExtension extensionObject;
	}
}
