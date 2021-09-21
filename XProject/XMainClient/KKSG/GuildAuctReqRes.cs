using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A2 RID: 674
	[ProtoContract(Name = "GuildAuctReqRes")]
	[Serializable]
	public class GuildAuctReqRes : IExtensible
	{
		// Token: 0x17000BBA RID: 3002
		// (get) Token: 0x060025B8 RID: 9656 RVA: 0x00049778 File Offset: 0x00047978
		// (set) Token: 0x060025B9 RID: 9657 RVA: 0x000497A4 File Offset: 0x000479A4
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

		// Token: 0x17000BBB RID: 3003
		// (get) Token: 0x060025BA RID: 9658 RVA: 0x000497B4 File Offset: 0x000479B4
		// (set) Token: 0x060025BB RID: 9659 RVA: 0x000497D4 File Offset: 0x000479D4
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

		// Token: 0x060025BC RID: 9660 RVA: 0x00049818 File Offset: 0x00047A18
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060025BD RID: 9661 RVA: 0x00049830 File Offset: 0x00047A30
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x060025BE RID: 9662 RVA: 0x0004983C File Offset: 0x00047A3C
		// (set) Token: 0x060025BF RID: 9663 RVA: 0x00049868 File Offset: 0x00047A68
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

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x060025C0 RID: 9664 RVA: 0x00049878 File Offset: 0x00047A78
		// (set) Token: 0x060025C1 RID: 9665 RVA: 0x00049898 File Offset: 0x00047A98
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

		// Token: 0x060025C2 RID: 9666 RVA: 0x000498DC File Offset: 0x00047ADC
		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		// Token: 0x060025C3 RID: 9667 RVA: 0x000498F4 File Offset: 0x00047AF4
		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x060025C4 RID: 9668 RVA: 0x00049900 File Offset: 0x00047B00
		[ProtoMember(3, Name = "saleitems", DataFormat = DataFormat.Default)]
		public List<GASaleItem> saleitems
		{
			get
			{
				return this._saleitems;
			}
		}

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x060025C5 RID: 9669 RVA: 0x00049918 File Offset: 0x00047B18
		[ProtoMember(4, Name = "salehistorys", DataFormat = DataFormat.Default)]
		public List<GASaleHistory> salehistorys
		{
			get
			{
				return this._salehistorys;
			}
		}

		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x060025C6 RID: 9670 RVA: 0x00049930 File Offset: 0x00047B30
		// (set) Token: 0x060025C7 RID: 9671 RVA: 0x0004995C File Offset: 0x00047B5C
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

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x060025C8 RID: 9672 RVA: 0x0004996C File Offset: 0x00047B6C
		// (set) Token: 0x060025C9 RID: 9673 RVA: 0x0004998C File Offset: 0x00047B8C
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

		// Token: 0x060025CA RID: 9674 RVA: 0x000499D0 File Offset: 0x00047BD0
		private bool ShouldSerializeprofit()
		{
			return this.profitSpecified;
		}

		// Token: 0x060025CB RID: 9675 RVA: 0x000499E8 File Offset: 0x00047BE8
		private void Resetprofit()
		{
			this.profitSpecified = false;
		}

		// Token: 0x060025CC RID: 9676 RVA: 0x000499F4 File Offset: 0x00047BF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000955 RID: 2389
		private ErrorCode? _errorcode;

		// Token: 0x04000956 RID: 2390
		private uint? _curauctprice;

		// Token: 0x04000957 RID: 2391
		private readonly List<GASaleItem> _saleitems = new List<GASaleItem>();

		// Token: 0x04000958 RID: 2392
		private readonly List<GASaleHistory> _salehistorys = new List<GASaleHistory>();

		// Token: 0x04000959 RID: 2393
		private uint? _profit;

		// Token: 0x0400095A RID: 2394
		private IExtension extensionObject;
	}
}
