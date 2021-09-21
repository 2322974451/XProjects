using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000730 RID: 1840
	[ProtoContract(Name = "DragonGuildShopItemClient")]
	[Serializable]
	public class DragonGuildShopItemClient : IExtensible
	{
		// Token: 0x17002859 RID: 10329
		// (get) Token: 0x06007F40 RID: 32576 RVA: 0x000F3560 File Offset: 0x000F1760
		// (set) Token: 0x06007F41 RID: 32577 RVA: 0x000F358C File Offset: 0x000F178C
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

		// Token: 0x1700285A RID: 10330
		// (get) Token: 0x06007F42 RID: 32578 RVA: 0x000F359C File Offset: 0x000F179C
		// (set) Token: 0x06007F43 RID: 32579 RVA: 0x000F35BC File Offset: 0x000F17BC
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

		// Token: 0x06007F44 RID: 32580 RVA: 0x000F3600 File Offset: 0x000F1800
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007F45 RID: 32581 RVA: 0x000F3618 File Offset: 0x000F1818
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700285B RID: 10331
		// (get) Token: 0x06007F46 RID: 32582 RVA: 0x000F3624 File Offset: 0x000F1824
		// (set) Token: 0x06007F47 RID: 32583 RVA: 0x000F3650 File Offset: 0x000F1850
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

		// Token: 0x1700285C RID: 10332
		// (get) Token: 0x06007F48 RID: 32584 RVA: 0x000F3660 File Offset: 0x000F1860
		// (set) Token: 0x06007F49 RID: 32585 RVA: 0x000F3680 File Offset: 0x000F1880
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

		// Token: 0x06007F4A RID: 32586 RVA: 0x000F36C4 File Offset: 0x000F18C4
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06007F4B RID: 32587 RVA: 0x000F36DC File Offset: 0x000F18DC
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700285D RID: 10333
		// (get) Token: 0x06007F4C RID: 32588 RVA: 0x000F36E8 File Offset: 0x000F18E8
		// (set) Token: 0x06007F4D RID: 32589 RVA: 0x000F3714 File Offset: 0x000F1914
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

		// Token: 0x1700285E RID: 10334
		// (get) Token: 0x06007F4E RID: 32590 RVA: 0x000F3724 File Offset: 0x000F1924
		// (set) Token: 0x06007F4F RID: 32591 RVA: 0x000F3744 File Offset: 0x000F1944
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

		// Token: 0x06007F50 RID: 32592 RVA: 0x000F3788 File Offset: 0x000F1988
		private bool ShouldSerializebuy_count()
		{
			return this.buy_countSpecified;
		}

		// Token: 0x06007F51 RID: 32593 RVA: 0x000F37A0 File Offset: 0x000F19A0
		private void Resetbuy_count()
		{
			this.buy_countSpecified = false;
		}

		// Token: 0x06007F52 RID: 32594 RVA: 0x000F37AC File Offset: 0x000F19AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DDC RID: 7644
		private uint? _id;

		// Token: 0x04001DDD RID: 7645
		private uint? _itemid;

		// Token: 0x04001DDE RID: 7646
		private uint? _buy_count;

		// Token: 0x04001DDF RID: 7647
		private IExtension extensionObject;
	}
}
