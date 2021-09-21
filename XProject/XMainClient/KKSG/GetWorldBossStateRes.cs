using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000066 RID: 102
	[ProtoContract(Name = "GetWorldBossStateRes")]
	[Serializable]
	public class GetWorldBossStateRes : IExtensible
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0000FBD4 File Offset: 0x0000DDD4
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x0000FC00 File Offset: 0x0000DE00
		[ProtoMember(1, IsRequired = false, Name = "TimeLeft", DataFormat = DataFormat.TwosComplement)]
		public uint TimeLeft
		{
			get
			{
				return this._TimeLeft ?? 0U;
			}
			set
			{
				this._TimeLeft = new uint?(value);
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0000FC10 File Offset: 0x0000DE10
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x0000FC30 File Offset: 0x0000DE30
		[XmlIgnore]
		[Browsable(false)]
		public bool TimeLeftSpecified
		{
			get
			{
				return this._TimeLeft != null;
			}
			set
			{
				bool flag = value == (this._TimeLeft == null);
				if (flag)
				{
					this._TimeLeft = (value ? new uint?(this.TimeLeft) : null);
				}
			}
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0000FC74 File Offset: 0x0000DE74
		private bool ShouldSerializeTimeLeft()
		{
			return this.TimeLeftSpecified;
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0000FC8C File Offset: 0x0000DE8C
		private void ResetTimeLeft()
		{
			this.TimeLeftSpecified = false;
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0000FC98 File Offset: 0x0000DE98
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x0000FCC4 File Offset: 0x0000DEC4
		[ProtoMember(2, IsRequired = false, Name = "BossHp", DataFormat = DataFormat.TwosComplement)]
		public uint BossHp
		{
			get
			{
				return this._BossHp ?? 0U;
			}
			set
			{
				this._BossHp = new uint?(value);
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x0000FCD4 File Offset: 0x0000DED4
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x0000FCF4 File Offset: 0x0000DEF4
		[XmlIgnore]
		[Browsable(false)]
		public bool BossHpSpecified
		{
			get
			{
				return this._BossHp != null;
			}
			set
			{
				bool flag = value == (this._BossHp == null);
				if (flag)
				{
					this._BossHp = (value ? new uint?(this.BossHp) : null);
				}
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0000FD38 File Offset: 0x0000DF38
		private bool ShouldSerializeBossHp()
		{
			return this.BossHpSpecified;
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0000FD50 File Offset: 0x0000DF50
		private void ResetBossHp()
		{
			this.BossHpSpecified = false;
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0000FD88 File Offset: 0x0000DF88
		[ProtoMember(3, IsRequired = false, Name = "BossId", DataFormat = DataFormat.TwosComplement)]
		public uint BossId
		{
			get
			{
				return this._BossId ?? 0U;
			}
			set
			{
				this._BossId = new uint?(value);
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0000FD98 File Offset: 0x0000DF98
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0000FDB8 File Offset: 0x0000DFB8
		[XmlIgnore]
		[Browsable(false)]
		public bool BossIdSpecified
		{
			get
			{
				return this._BossId != null;
			}
			set
			{
				bool flag = value == (this._BossId == null);
				if (flag)
				{
					this._BossId = (value ? new uint?(this.BossId) : null);
				}
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0000FDFC File Offset: 0x0000DFFC
		private bool ShouldSerializeBossId()
		{
			return this.BossIdSpecified;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0000FE14 File Offset: 0x0000E014
		private void ResetBossId()
		{
			this.BossIdSpecified = false;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0000FE20 File Offset: 0x0000E020
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001BA RID: 442
		private uint? _TimeLeft;

		// Token: 0x040001BB RID: 443
		private uint? _BossHp;

		// Token: 0x040001BC RID: 444
		private uint? _BossId;

		// Token: 0x040001BD RID: 445
		private IExtension extensionObject;
	}
}
