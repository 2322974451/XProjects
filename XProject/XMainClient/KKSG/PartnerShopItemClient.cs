using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E3 RID: 1763
	[ProtoContract(Name = "PartnerShopItemClient")]
	[Serializable]
	public class PartnerShopItemClient : IExtensible
	{
		// Token: 0x17002547 RID: 9543
		// (get) Token: 0x060075BA RID: 30138 RVA: 0x000E13D8 File Offset: 0x000DF5D8
		// (set) Token: 0x060075BB RID: 30139 RVA: 0x000E1404 File Offset: 0x000DF604
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17002548 RID: 9544
		// (get) Token: 0x060075BC RID: 30140 RVA: 0x000E1414 File Offset: 0x000DF614
		// (set) Token: 0x060075BD RID: 30141 RVA: 0x000E1434 File Offset: 0x000DF634
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060075BE RID: 30142 RVA: 0x000E1478 File Offset: 0x000DF678
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060075BF RID: 30143 RVA: 0x000E1490 File Offset: 0x000DF690
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002549 RID: 9545
		// (get) Token: 0x060075C0 RID: 30144 RVA: 0x000E149C File Offset: 0x000DF69C
		// (set) Token: 0x060075C1 RID: 30145 RVA: 0x000E14C8 File Offset: 0x000DF6C8
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

		// Token: 0x1700254A RID: 9546
		// (get) Token: 0x060075C2 RID: 30146 RVA: 0x000E14D8 File Offset: 0x000DF6D8
		// (set) Token: 0x060075C3 RID: 30147 RVA: 0x000E14F8 File Offset: 0x000DF6F8
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

		// Token: 0x060075C4 RID: 30148 RVA: 0x000E153C File Offset: 0x000DF73C
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060075C5 RID: 30149 RVA: 0x000E1554 File Offset: 0x000DF754
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700254B RID: 9547
		// (get) Token: 0x060075C6 RID: 30150 RVA: 0x000E1560 File Offset: 0x000DF760
		// (set) Token: 0x060075C7 RID: 30151 RVA: 0x000E158C File Offset: 0x000DF78C
		[ProtoMember(3, IsRequired = false, Name = "buy_count", DataFormat = DataFormat.TwosComplement)]
		public uint buy_count
		{
			get
			{
				return this._buy_count ?? 0U;
			}
			set
			{
				this._buy_count = new uint?(value);
			}
		}

		// Token: 0x1700254C RID: 9548
		// (get) Token: 0x060075C8 RID: 30152 RVA: 0x000E159C File Offset: 0x000DF79C
		// (set) Token: 0x060075C9 RID: 30153 RVA: 0x000E15BC File Offset: 0x000DF7BC
		[XmlIgnore]
		[Browsable(false)]
		public bool buy_countSpecified
		{
			get
			{
				return this._buy_count != null;
			}
			set
			{
				bool flag = value == (this._buy_count == null);
				if (flag)
				{
					this._buy_count = (value ? new uint?(this.buy_count) : null);
				}
			}
		}

		// Token: 0x060075CA RID: 30154 RVA: 0x000E1600 File Offset: 0x000DF800
		private bool ShouldSerializebuy_count()
		{
			return this.buy_countSpecified;
		}

		// Token: 0x060075CB RID: 30155 RVA: 0x000E1618 File Offset: 0x000DF818
		private void Resetbuy_count()
		{
			this.buy_countSpecified = false;
		}

		// Token: 0x060075CC RID: 30156 RVA: 0x000E1624 File Offset: 0x000DF824
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BED RID: 7149
		private uint? _id;

		// Token: 0x04001BEE RID: 7150
		private uint? _itemid;

		// Token: 0x04001BEF RID: 7151
		private uint? _buy_count;

		// Token: 0x04001BF0 RID: 7152
		private IExtension extensionObject;
	}
}
