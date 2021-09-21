using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000669 RID: 1641
	[ProtoContract(Name = "HeroBattleOneGame")]
	[Serializable]
	public class HeroBattleOneGame : IExtensible
	{
		// Token: 0x170020D4 RID: 8404
		// (get) Token: 0x060067DD RID: 26589 RVA: 0x000C67D4 File Offset: 0x000C49D4
		[ProtoMember(1, Name = "team1", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> team1
		{
			get
			{
				return this._team1;
			}
		}

		// Token: 0x170020D5 RID: 8405
		// (get) Token: 0x060067DE RID: 26590 RVA: 0x000C67EC File Offset: 0x000C49EC
		[ProtoMember(2, Name = "team2", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> team2
		{
			get
			{
				return this._team2;
			}
		}

		// Token: 0x170020D6 RID: 8406
		// (get) Token: 0x060067DF RID: 26591 RVA: 0x000C6804 File Offset: 0x000C4A04
		// (set) Token: 0x060067E0 RID: 26592 RVA: 0x000C6830 File Offset: 0x000C4A30
		[ProtoMember(3, IsRequired = false, Name = "over", DataFormat = DataFormat.TwosComplement)]
		public HeroBattleOver over
		{
			get
			{
				return this._over ?? HeroBattleOver.HeroBattleOver_Win;
			}
			set
			{
				this._over = new HeroBattleOver?(value);
			}
		}

		// Token: 0x170020D7 RID: 8407
		// (get) Token: 0x060067E1 RID: 26593 RVA: 0x000C6840 File Offset: 0x000C4A40
		// (set) Token: 0x060067E2 RID: 26594 RVA: 0x000C6860 File Offset: 0x000C4A60
		[XmlIgnore]
		[Browsable(false)]
		public bool overSpecified
		{
			get
			{
				return this._over != null;
			}
			set
			{
				bool flag = value == (this._over == null);
				if (flag)
				{
					this._over = (value ? new HeroBattleOver?(this.over) : null);
				}
			}
		}

		// Token: 0x060067E3 RID: 26595 RVA: 0x000C68A4 File Offset: 0x000C4AA4
		private bool ShouldSerializeover()
		{
			return this.overSpecified;
		}

		// Token: 0x060067E4 RID: 26596 RVA: 0x000C68BC File Offset: 0x000C4ABC
		private void Resetover()
		{
			this.overSpecified = false;
		}

		// Token: 0x170020D8 RID: 8408
		// (get) Token: 0x060067E5 RID: 26597 RVA: 0x000C68C8 File Offset: 0x000C4AC8
		// (set) Token: 0x060067E6 RID: 26598 RVA: 0x000C68F5 File Offset: 0x000C4AF5
		[ProtoMember(4, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		// Token: 0x170020D9 RID: 8409
		// (get) Token: 0x060067E7 RID: 26599 RVA: 0x000C6904 File Offset: 0x000C4B04
		// (set) Token: 0x060067E8 RID: 26600 RVA: 0x000C6924 File Offset: 0x000C4B24
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		// Token: 0x060067E9 RID: 26601 RVA: 0x000C6968 File Offset: 0x000C4B68
		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		// Token: 0x060067EA RID: 26602 RVA: 0x000C6980 File Offset: 0x000C4B80
		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		// Token: 0x170020DA RID: 8410
		// (get) Token: 0x060067EB RID: 26603 RVA: 0x000C698C File Offset: 0x000C4B8C
		// (set) Token: 0x060067EC RID: 26604 RVA: 0x000C69B8 File Offset: 0x000C4BB8
		[ProtoMember(5, IsRequired = false, Name = "exploit", DataFormat = DataFormat.TwosComplement)]
		public uint exploit
		{
			get
			{
				return this._exploit ?? 0U;
			}
			set
			{
				this._exploit = new uint?(value);
			}
		}

		// Token: 0x170020DB RID: 8411
		// (get) Token: 0x060067ED RID: 26605 RVA: 0x000C69C8 File Offset: 0x000C4BC8
		// (set) Token: 0x060067EE RID: 26606 RVA: 0x000C69E8 File Offset: 0x000C4BE8
		[XmlIgnore]
		[Browsable(false)]
		public bool exploitSpecified
		{
			get
			{
				return this._exploit != null;
			}
			set
			{
				bool flag = value == (this._exploit == null);
				if (flag)
				{
					this._exploit = (value ? new uint?(this.exploit) : null);
				}
			}
		}

		// Token: 0x060067EF RID: 26607 RVA: 0x000C6A2C File Offset: 0x000C4C2C
		private bool ShouldSerializeexploit()
		{
			return this.exploitSpecified;
		}

		// Token: 0x060067F0 RID: 26608 RVA: 0x000C6A44 File Offset: 0x000C4C44
		private void Resetexploit()
		{
			this.exploitSpecified = false;
		}

		// Token: 0x060067F1 RID: 26609 RVA: 0x000C6A50 File Offset: 0x000C4C50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001917 RID: 6423
		private readonly List<RoleSmallInfo> _team1 = new List<RoleSmallInfo>();

		// Token: 0x04001918 RID: 6424
		private readonly List<RoleSmallInfo> _team2 = new List<RoleSmallInfo>();

		// Token: 0x04001919 RID: 6425
		private HeroBattleOver? _over;

		// Token: 0x0400191A RID: 6426
		private ulong? _mvpid;

		// Token: 0x0400191B RID: 6427
		private uint? _exploit;

		// Token: 0x0400191C RID: 6428
		private IExtension extensionObject;
	}
}
