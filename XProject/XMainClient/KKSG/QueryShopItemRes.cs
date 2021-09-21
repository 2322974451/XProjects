using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005A RID: 90
	[ProtoContract(Name = "QueryShopItemRes")]
	[Serializable]
	public class QueryShopItemRes : IExtensible
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0000E12C File Offset: 0x0000C32C
		[ProtoMember(1, Name = "ShopItem", DataFormat = DataFormat.Default)]
		public List<ShopItem> ShopItem
		{
			get
			{
				return this._ShopItem;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000E144 File Offset: 0x0000C344
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000E170 File Offset: 0x0000C370
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0000E180 File Offset: 0x0000C380
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x0000E1A0 File Offset: 0x0000C3A0
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

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000E1E4 File Offset: 0x0000C3E4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000E1FC File Offset: 0x0000C3FC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000E208 File Offset: 0x0000C408
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x0000E234 File Offset: 0x0000C434
		[ProtoMember(3, IsRequired = false, Name = "refreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint refreshcount
		{
			get
			{
				return this._refreshcount ?? 0U;
			}
			set
			{
				this._refreshcount = new uint?(value);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0000E244 File Offset: 0x0000C444
		// (set) Token: 0x060005FE RID: 1534 RVA: 0x0000E264 File Offset: 0x0000C464
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshcountSpecified
		{
			get
			{
				return this._refreshcount != null;
			}
			set
			{
				bool flag = value == (this._refreshcount == null);
				if (flag)
				{
					this._refreshcount = (value ? new uint?(this.refreshcount) : null);
				}
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
		private bool ShouldSerializerefreshcount()
		{
			return this.refreshcountSpecified;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0000E2C0 File Offset: 0x0000C4C0
		private void Resetrefreshcount()
		{
			this.refreshcountSpecified = false;
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x0000E2CC File Offset: 0x0000C4CC
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x0000E2F8 File Offset: 0x0000C4F8
		[ProtoMember(4, IsRequired = false, Name = "cooklevel", DataFormat = DataFormat.TwosComplement)]
		public uint cooklevel
		{
			get
			{
				return this._cooklevel ?? 0U;
			}
			set
			{
				this._cooklevel = new uint?(value);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x0000E308 File Offset: 0x0000C508
		// (set) Token: 0x06000604 RID: 1540 RVA: 0x0000E328 File Offset: 0x0000C528
		[XmlIgnore]
		[Browsable(false)]
		public bool cooklevelSpecified
		{
			get
			{
				return this._cooklevel != null;
			}
			set
			{
				bool flag = value == (this._cooklevel == null);
				if (flag)
				{
					this._cooklevel = (value ? new uint?(this.cooklevel) : null);
				}
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000E36C File Offset: 0x0000C56C
		private bool ShouldSerializecooklevel()
		{
			return this.cooklevelSpecified;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000E384 File Offset: 0x0000C584
		private void Resetcooklevel()
		{
			this.cooklevelSpecified = false;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0000E390 File Offset: 0x0000C590
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000184 RID: 388
		private readonly List<ShopItem> _ShopItem = new List<ShopItem>();

		// Token: 0x04000185 RID: 389
		private ErrorCode? _errorcode;

		// Token: 0x04000186 RID: 390
		private uint? _refreshcount;

		// Token: 0x04000187 RID: 391
		private uint? _cooklevel;

		// Token: 0x04000188 RID: 392
		private IExtension extensionObject;
	}
}
