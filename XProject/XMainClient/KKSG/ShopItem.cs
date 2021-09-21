using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000598 RID: 1432
	[ProtoContract(Name = "ShopItem")]
	[Serializable]
	public class ShopItem : IExtensible
	{
		// Token: 0x17001783 RID: 6019
		// (get) Token: 0x06004C5D RID: 19549 RVA: 0x00091428 File Offset: 0x0008F628
		// (set) Token: 0x06004C5E RID: 19550 RVA: 0x00091440 File Offset: 0x0008F640
		[ProtoMember(1, IsRequired = false, Name = "Item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item Item
		{
			get
			{
				return this._Item;
			}
			set
			{
				this._Item = value;
			}
		}

		// Token: 0x17001784 RID: 6020
		// (get) Token: 0x06004C5F RID: 19551 RVA: 0x0009144C File Offset: 0x0008F64C
		// (set) Token: 0x06004C60 RID: 19552 RVA: 0x00091478 File Offset: 0x0008F678
		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		// Token: 0x17001785 RID: 6021
		// (get) Token: 0x06004C61 RID: 19553 RVA: 0x00091488 File Offset: 0x0008F688
		// (set) Token: 0x06004C62 RID: 19554 RVA: 0x000914A8 File Offset: 0x0008F6A8
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		// Token: 0x06004C63 RID: 19555 RVA: 0x000914EC File Offset: 0x0008F6EC
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06004C64 RID: 19556 RVA: 0x00091504 File Offset: 0x0008F704
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x17001786 RID: 6022
		// (get) Token: 0x06004C65 RID: 19557 RVA: 0x00091510 File Offset: 0x0008F710
		// (set) Token: 0x06004C66 RID: 19558 RVA: 0x0009153C File Offset: 0x0008F73C
		[ProtoMember(3, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		// Token: 0x17001787 RID: 6023
		// (get) Token: 0x06004C67 RID: 19559 RVA: 0x0009154C File Offset: 0x0008F74C
		// (set) Token: 0x06004C68 RID: 19560 RVA: 0x0009156C File Offset: 0x0008F76C
		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		// Token: 0x06004C69 RID: 19561 RVA: 0x000915B0 File Offset: 0x0008F7B0
		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		// Token: 0x06004C6A RID: 19562 RVA: 0x000915C8 File Offset: 0x0008F7C8
		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		// Token: 0x17001788 RID: 6024
		// (get) Token: 0x06004C6B RID: 19563 RVA: 0x000915D4 File Offset: 0x0008F7D4
		// (set) Token: 0x06004C6C RID: 19564 RVA: 0x00091600 File Offset: 0x0008F800
		[ProtoMember(4, IsRequired = false, Name = "dailybuycount", DataFormat = DataFormat.TwosComplement)]
		public uint dailybuycount
		{
			get
			{
				return this._dailybuycount ?? 0U;
			}
			set
			{
				this._dailybuycount = new uint?(value);
			}
		}

		// Token: 0x17001789 RID: 6025
		// (get) Token: 0x06004C6D RID: 19565 RVA: 0x00091610 File Offset: 0x0008F810
		// (set) Token: 0x06004C6E RID: 19566 RVA: 0x00091630 File Offset: 0x0008F830
		[XmlIgnore]
		[Browsable(false)]
		public bool dailybuycountSpecified
		{
			get
			{
				return this._dailybuycount != null;
			}
			set
			{
				bool flag = value == (this._dailybuycount == null);
				if (flag)
				{
					this._dailybuycount = (value ? new uint?(this.dailybuycount) : null);
				}
			}
		}

		// Token: 0x06004C6F RID: 19567 RVA: 0x00091674 File Offset: 0x0008F874
		private bool ShouldSerializedailybuycount()
		{
			return this.dailybuycountSpecified;
		}

		// Token: 0x06004C70 RID: 19568 RVA: 0x0009168C File Offset: 0x0008F88C
		private void Resetdailybuycount()
		{
			this.dailybuycountSpecified = false;
		}

		// Token: 0x1700178A RID: 6026
		// (get) Token: 0x06004C71 RID: 19569 RVA: 0x00091698 File Offset: 0x0008F898
		// (set) Token: 0x06004C72 RID: 19570 RVA: 0x000916C4 File Offset: 0x0008F8C4
		[ProtoMember(5, IsRequired = false, Name = "weekbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint weekbuycount
		{
			get
			{
				return this._weekbuycount ?? 0U;
			}
			set
			{
				this._weekbuycount = new uint?(value);
			}
		}

		// Token: 0x1700178B RID: 6027
		// (get) Token: 0x06004C73 RID: 19571 RVA: 0x000916D4 File Offset: 0x0008F8D4
		// (set) Token: 0x06004C74 RID: 19572 RVA: 0x000916F4 File Offset: 0x0008F8F4
		[XmlIgnore]
		[Browsable(false)]
		public bool weekbuycountSpecified
		{
			get
			{
				return this._weekbuycount != null;
			}
			set
			{
				bool flag = value == (this._weekbuycount == null);
				if (flag)
				{
					this._weekbuycount = (value ? new uint?(this.weekbuycount) : null);
				}
			}
		}

		// Token: 0x06004C75 RID: 19573 RVA: 0x00091738 File Offset: 0x0008F938
		private bool ShouldSerializeweekbuycount()
		{
			return this.weekbuycountSpecified;
		}

		// Token: 0x06004C76 RID: 19574 RVA: 0x00091750 File Offset: 0x0008F950
		private void Resetweekbuycount()
		{
			this.weekbuycountSpecified = false;
		}

		// Token: 0x06004C77 RID: 19575 RVA: 0x0009175C File Offset: 0x0008F95C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012F2 RID: 4850
		private Item _Item = null;

		// Token: 0x040012F3 RID: 4851
		private uint? _slot;

		// Token: 0x040012F4 RID: 4852
		private uint? _buycount;

		// Token: 0x040012F5 RID: 4853
		private uint? _dailybuycount;

		// Token: 0x040012F6 RID: 4854
		private uint? _weekbuycount;

		// Token: 0x040012F7 RID: 4855
		private IExtension extensionObject;
	}
}
