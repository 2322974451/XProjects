using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildAuctReqRes")]
	[Serializable]
	public class GuildAuctReqRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "curauctprice", DataFormat = DataFormat.TwosComplement)]
		public uint curauctprice
		{
			get
			{
				return this._curauctprice ?? 0U;
			}
			set
			{
				this._curauctprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curauctpriceSpecified
		{
			get
			{
				return this._curauctprice != null;
			}
			set
			{
				bool flag = value == (this._curauctprice == null);
				if (flag)
				{
					this._curauctprice = (value ? new uint?(this.curauctprice) : null);
				}
			}
		}

		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		[ProtoMember(3, Name = "saleitems", DataFormat = DataFormat.Default)]
		public List<GASaleItem> saleitems
		{
			get
			{
				return this._saleitems;
			}
		}

		[ProtoMember(4, Name = "salehistorys", DataFormat = DataFormat.Default)]
		public List<GASaleHistory> salehistorys
		{
			get
			{
				return this._salehistorys;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "profit", DataFormat = DataFormat.TwosComplement)]
		public uint profit
		{
			get
			{
				return this._profit ?? 0U;
			}
			set
			{
				this._profit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool profitSpecified
		{
			get
			{
				return this._profit != null;
			}
			set
			{
				bool flag = value == (this._profit == null);
				if (flag)
				{
					this._profit = (value ? new uint?(this.profit) : null);
				}
			}
		}

		private bool ShouldSerializeprofit()
		{
			return this.profitSpecified;
		}

		private void Resetprofit()
		{
			this.profitSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _curauctprice;

		private readonly List<GASaleItem> _saleitems = new List<GASaleItem>();

		private readonly List<GASaleHistory> _salehistorys = new List<GASaleHistory>();

		private uint? _profit;

		private IExtension extensionObject;
	}
}
