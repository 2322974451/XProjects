using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D1 RID: 1489
	[ProtoContract(Name = "GuildGoblinResult")]
	[Serializable]
	public class GuildGoblinResult : IExtensible
	{
		// Token: 0x17001A5F RID: 6751
		// (get) Token: 0x06005505 RID: 21765 RVA: 0x000A1C6C File Offset: 0x0009FE6C
		// (set) Token: 0x06005506 RID: 21766 RVA: 0x000A1C98 File Offset: 0x0009FE98
		[ProtoMember(1, IsRequired = false, Name = "getGuildBonus", DataFormat = DataFormat.Default)]
		public bool getGuildBonus
		{
			get
			{
				return this._getGuildBonus ?? false;
			}
			set
			{
				this._getGuildBonus = new bool?(value);
			}
		}

		// Token: 0x17001A60 RID: 6752
		// (get) Token: 0x06005507 RID: 21767 RVA: 0x000A1CA8 File Offset: 0x0009FEA8
		// (set) Token: 0x06005508 RID: 21768 RVA: 0x000A1CC8 File Offset: 0x0009FEC8
		[XmlIgnore]
		[Browsable(false)]
		public bool getGuildBonusSpecified
		{
			get
			{
				return this._getGuildBonus != null;
			}
			set
			{
				bool flag = value == (this._getGuildBonus == null);
				if (flag)
				{
					this._getGuildBonus = (value ? new bool?(this.getGuildBonus) : null);
				}
			}
		}

		// Token: 0x06005509 RID: 21769 RVA: 0x000A1D0C File Offset: 0x0009FF0C
		private bool ShouldSerializegetGuildBonus()
		{
			return this.getGuildBonusSpecified;
		}

		// Token: 0x0600550A RID: 21770 RVA: 0x000A1D24 File Offset: 0x0009FF24
		private void ResetgetGuildBonus()
		{
			this.getGuildBonusSpecified = false;
		}

		// Token: 0x17001A61 RID: 6753
		// (get) Token: 0x0600550B RID: 21771 RVA: 0x000A1D30 File Offset: 0x0009FF30
		// (set) Token: 0x0600550C RID: 21772 RVA: 0x000A1D5C File Offset: 0x0009FF5C
		[ProtoMember(2, IsRequired = false, Name = "curRank", DataFormat = DataFormat.TwosComplement)]
		public int curRank
		{
			get
			{
				return this._curRank ?? 0;
			}
			set
			{
				this._curRank = new int?(value);
			}
		}

		// Token: 0x17001A62 RID: 6754
		// (get) Token: 0x0600550D RID: 21773 RVA: 0x000A1D6C File Offset: 0x0009FF6C
		// (set) Token: 0x0600550E RID: 21774 RVA: 0x000A1D8C File Offset: 0x0009FF8C
		[XmlIgnore]
		[Browsable(false)]
		public bool curRankSpecified
		{
			get
			{
				return this._curRank != null;
			}
			set
			{
				bool flag = value == (this._curRank == null);
				if (flag)
				{
					this._curRank = (value ? new int?(this.curRank) : null);
				}
			}
		}

		// Token: 0x0600550F RID: 21775 RVA: 0x000A1DD0 File Offset: 0x0009FFD0
		private bool ShouldSerializecurRank()
		{
			return this.curRankSpecified;
		}

		// Token: 0x06005510 RID: 21776 RVA: 0x000A1DE8 File Offset: 0x0009FFE8
		private void ResetcurRank()
		{
			this.curRankSpecified = false;
		}

		// Token: 0x06005511 RID: 21777 RVA: 0x000A1DF4 File Offset: 0x0009FFF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014BC RID: 5308
		private bool? _getGuildBonus;

		// Token: 0x040014BD RID: 5309
		private int? _curRank;

		// Token: 0x040014BE RID: 5310
		private IExtension extensionObject;
	}
}
