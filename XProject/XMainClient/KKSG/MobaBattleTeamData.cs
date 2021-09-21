using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071A RID: 1818
	[ProtoContract(Name = "MobaBattleTeamData")]
	[Serializable]
	public class MobaBattleTeamData : IExtensible
	{
		// Token: 0x1700274E RID: 10062
		// (get) Token: 0x06007C01 RID: 31745 RVA: 0x000ED0FC File Offset: 0x000EB2FC
		// (set) Token: 0x06007C02 RID: 31746 RVA: 0x000ED128 File Offset: 0x000EB328
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x1700274F RID: 10063
		// (get) Token: 0x06007C03 RID: 31747 RVA: 0x000ED138 File Offset: 0x000EB338
		// (set) Token: 0x06007C04 RID: 31748 RVA: 0x000ED158 File Offset: 0x000EB358
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x06007C05 RID: 31749 RVA: 0x000ED19C File Offset: 0x000EB39C
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06007C06 RID: 31750 RVA: 0x000ED1B4 File Offset: 0x000EB3B4
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17002750 RID: 10064
		// (get) Token: 0x06007C07 RID: 31751 RVA: 0x000ED1C0 File Offset: 0x000EB3C0
		// (set) Token: 0x06007C08 RID: 31752 RVA: 0x000ED1EC File Offset: 0x000EB3EC
		[ProtoMember(2, IsRequired = false, Name = "grouplevel", DataFormat = DataFormat.TwosComplement)]
		public uint grouplevel
		{
			get
			{
				return this._grouplevel ?? 0U;
			}
			set
			{
				this._grouplevel = new uint?(value);
			}
		}

		// Token: 0x17002751 RID: 10065
		// (get) Token: 0x06007C09 RID: 31753 RVA: 0x000ED1FC File Offset: 0x000EB3FC
		// (set) Token: 0x06007C0A RID: 31754 RVA: 0x000ED21C File Offset: 0x000EB41C
		[XmlIgnore]
		[Browsable(false)]
		public bool grouplevelSpecified
		{
			get
			{
				return this._grouplevel != null;
			}
			set
			{
				bool flag = value == (this._grouplevel == null);
				if (flag)
				{
					this._grouplevel = (value ? new uint?(this.grouplevel) : null);
				}
			}
		}

		// Token: 0x06007C0B RID: 31755 RVA: 0x000ED260 File Offset: 0x000EB460
		private bool ShouldSerializegrouplevel()
		{
			return this.grouplevelSpecified;
		}

		// Token: 0x06007C0C RID: 31756 RVA: 0x000ED278 File Offset: 0x000EB478
		private void Resetgrouplevel()
		{
			this.grouplevelSpecified = false;
		}

		// Token: 0x17002752 RID: 10066
		// (get) Token: 0x06007C0D RID: 31757 RVA: 0x000ED284 File Offset: 0x000EB484
		// (set) Token: 0x06007C0E RID: 31758 RVA: 0x000ED2B0 File Offset: 0x000EB4B0
		[ProtoMember(3, IsRequired = false, Name = "headcount", DataFormat = DataFormat.TwosComplement)]
		public uint headcount
		{
			get
			{
				return this._headcount ?? 0U;
			}
			set
			{
				this._headcount = new uint?(value);
			}
		}

		// Token: 0x17002753 RID: 10067
		// (get) Token: 0x06007C0F RID: 31759 RVA: 0x000ED2C0 File Offset: 0x000EB4C0
		// (set) Token: 0x06007C10 RID: 31760 RVA: 0x000ED2E0 File Offset: 0x000EB4E0
		[XmlIgnore]
		[Browsable(false)]
		public bool headcountSpecified
		{
			get
			{
				return this._headcount != null;
			}
			set
			{
				bool flag = value == (this._headcount == null);
				if (flag)
				{
					this._headcount = (value ? new uint?(this.headcount) : null);
				}
			}
		}

		// Token: 0x06007C11 RID: 31761 RVA: 0x000ED324 File Offset: 0x000EB524
		private bool ShouldSerializeheadcount()
		{
			return this.headcountSpecified;
		}

		// Token: 0x06007C12 RID: 31762 RVA: 0x000ED33C File Offset: 0x000EB53C
		private void Resetheadcount()
		{
			this.headcountSpecified = false;
		}

		// Token: 0x06007C13 RID: 31763 RVA: 0x000ED348 File Offset: 0x000EB548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D3C RID: 7484
		private uint? _teamid;

		// Token: 0x04001D3D RID: 7485
		private uint? _grouplevel;

		// Token: 0x04001D3E RID: 7486
		private uint? _headcount;

		// Token: 0x04001D3F RID: 7487
		private IExtension extensionObject;
	}
}
