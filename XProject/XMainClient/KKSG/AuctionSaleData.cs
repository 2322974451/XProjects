using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AB RID: 1707
	[ProtoContract(Name = "AuctionSaleData")]
	[Serializable]
	public class AuctionSaleData : IExtensible
	{
		// Token: 0x1700233E RID: 9022
		// (get) Token: 0x06006F56 RID: 28502 RVA: 0x000D50A4 File Offset: 0x000D32A4
		// (set) Token: 0x06006F57 RID: 28503 RVA: 0x000D50D1 File Offset: 0x000D32D1
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700233F RID: 9023
		// (get) Token: 0x06006F58 RID: 28504 RVA: 0x000D50E0 File Offset: 0x000D32E0
		// (set) Token: 0x06006F59 RID: 28505 RVA: 0x000D5100 File Offset: 0x000D3300
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06006F5A RID: 28506 RVA: 0x000D5144 File Offset: 0x000D3344
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06006F5B RID: 28507 RVA: 0x000D515C File Offset: 0x000D335C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002340 RID: 9024
		// (get) Token: 0x06006F5C RID: 28508 RVA: 0x000D5168 File Offset: 0x000D3368
		// (set) Token: 0x06006F5D RID: 28509 RVA: 0x000D5194 File Offset: 0x000D3394
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

		// Token: 0x17002341 RID: 9025
		// (get) Token: 0x06006F5E RID: 28510 RVA: 0x000D51A4 File Offset: 0x000D33A4
		// (set) Token: 0x06006F5F RID: 28511 RVA: 0x000D51C4 File Offset: 0x000D33C4
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

		// Token: 0x06006F60 RID: 28512 RVA: 0x000D5208 File Offset: 0x000D3408
		private bool ShouldSerializeperprice()
		{
			return this.perpriceSpecified;
		}

		// Token: 0x06006F61 RID: 28513 RVA: 0x000D5220 File Offset: 0x000D3420
		private void Resetperprice()
		{
			this.perpriceSpecified = false;
		}

		// Token: 0x17002342 RID: 9026
		// (get) Token: 0x06006F62 RID: 28514 RVA: 0x000D522C File Offset: 0x000D342C
		// (set) Token: 0x06006F63 RID: 28515 RVA: 0x000D5258 File Offset: 0x000D3458
		[ProtoMember(3, IsRequired = false, Name = "duelefttime", DataFormat = DataFormat.TwosComplement)]
		public uint duelefttime
		{
			get
			{
				return this._duelefttime ?? 0U;
			}
			set
			{
				this._duelefttime = new uint?(value);
			}
		}

		// Token: 0x17002343 RID: 9027
		// (get) Token: 0x06006F64 RID: 28516 RVA: 0x000D5268 File Offset: 0x000D3468
		// (set) Token: 0x06006F65 RID: 28517 RVA: 0x000D5288 File Offset: 0x000D3488
		[XmlIgnore]
		[Browsable(false)]
		public bool duelefttimeSpecified
		{
			get
			{
				return this._duelefttime != null;
			}
			set
			{
				bool flag = value == (this._duelefttime == null);
				if (flag)
				{
					this._duelefttime = (value ? new uint?(this.duelefttime) : null);
				}
			}
		}

		// Token: 0x06006F66 RID: 28518 RVA: 0x000D52CC File Offset: 0x000D34CC
		private bool ShouldSerializeduelefttime()
		{
			return this.duelefttimeSpecified;
		}

		// Token: 0x06006F67 RID: 28519 RVA: 0x000D52E4 File Offset: 0x000D34E4
		private void Resetduelefttime()
		{
			this.duelefttimeSpecified = false;
		}

		// Token: 0x17002344 RID: 9028
		// (get) Token: 0x06006F68 RID: 28520 RVA: 0x000D52F0 File Offset: 0x000D34F0
		// (set) Token: 0x06006F69 RID: 28521 RVA: 0x000D5308 File Offset: 0x000D3508
		[ProtoMember(4, IsRequired = false, Name = "itemdata", DataFormat = DataFormat.Default)]
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

		// Token: 0x06006F6A RID: 28522 RVA: 0x000D5314 File Offset: 0x000D3514
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AA3 RID: 6819
		private ulong? _uid;

		// Token: 0x04001AA4 RID: 6820
		private uint? _perprice;

		// Token: 0x04001AA5 RID: 6821
		private uint? _duelefttime;

		// Token: 0x04001AA6 RID: 6822
		private Item _itemdata = null;

		// Token: 0x04001AA7 RID: 6823
		private IExtension extensionObject;
	}
}
