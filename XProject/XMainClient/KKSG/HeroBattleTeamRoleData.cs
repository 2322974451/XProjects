using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034C RID: 844
	[ProtoContract(Name = "HeroBattleTeamRoleData")]
	[Serializable]
	public class HeroBattleTeamRoleData : IExtensible
	{
		// Token: 0x17000E48 RID: 3656
		// (get) Token: 0x06002E0C RID: 11788 RVA: 0x00059110 File Offset: 0x00057310
		// (set) Token: 0x06002E0D RID: 11789 RVA: 0x0005913C File Offset: 0x0005733C
		[ProtoMember(1, IsRequired = false, Name = "team1", DataFormat = DataFormat.TwosComplement)]
		public uint team1
		{
			get
			{
				return this._team1 ?? 0U;
			}
			set
			{
				this._team1 = new uint?(value);
			}
		}

		// Token: 0x17000E49 RID: 3657
		// (get) Token: 0x06002E0E RID: 11790 RVA: 0x0005914C File Offset: 0x0005734C
		// (set) Token: 0x06002E0F RID: 11791 RVA: 0x0005916C File Offset: 0x0005736C
		[XmlIgnore]
		[Browsable(false)]
		public bool team1Specified
		{
			get
			{
				return this._team1 != null;
			}
			set
			{
				bool flag = value == (this._team1 == null);
				if (flag)
				{
					this._team1 = (value ? new uint?(this.team1) : null);
				}
			}
		}

		// Token: 0x06002E10 RID: 11792 RVA: 0x000591B0 File Offset: 0x000573B0
		private bool ShouldSerializeteam1()
		{
			return this.team1Specified;
		}

		// Token: 0x06002E11 RID: 11793 RVA: 0x000591C8 File Offset: 0x000573C8
		private void Resetteam1()
		{
			this.team1Specified = false;
		}

		// Token: 0x17000E4A RID: 3658
		// (get) Token: 0x06002E12 RID: 11794 RVA: 0x000591D4 File Offset: 0x000573D4
		[ProtoMember(2, Name = "members1", DataFormat = DataFormat.Default)]
		public List<HeroBattleTeamMember> members1
		{
			get
			{
				return this._members1;
			}
		}

		// Token: 0x17000E4B RID: 3659
		// (get) Token: 0x06002E13 RID: 11795 RVA: 0x000591EC File Offset: 0x000573EC
		// (set) Token: 0x06002E14 RID: 11796 RVA: 0x00059218 File Offset: 0x00057418
		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.TwosComplement)]
		public uint team2
		{
			get
			{
				return this._team2 ?? 0U;
			}
			set
			{
				this._team2 = new uint?(value);
			}
		}

		// Token: 0x17000E4C RID: 3660
		// (get) Token: 0x06002E15 RID: 11797 RVA: 0x00059228 File Offset: 0x00057428
		// (set) Token: 0x06002E16 RID: 11798 RVA: 0x00059248 File Offset: 0x00057448
		[XmlIgnore]
		[Browsable(false)]
		public bool team2Specified
		{
			get
			{
				return this._team2 != null;
			}
			set
			{
				bool flag = value == (this._team2 == null);
				if (flag)
				{
					this._team2 = (value ? new uint?(this.team2) : null);
				}
			}
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x0005928C File Offset: 0x0005748C
		private bool ShouldSerializeteam2()
		{
			return this.team2Specified;
		}

		// Token: 0x06002E18 RID: 11800 RVA: 0x000592A4 File Offset: 0x000574A4
		private void Resetteam2()
		{
			this.team2Specified = false;
		}

		// Token: 0x17000E4D RID: 3661
		// (get) Token: 0x06002E19 RID: 11801 RVA: 0x000592B0 File Offset: 0x000574B0
		[ProtoMember(4, Name = "members2", DataFormat = DataFormat.Default)]
		public List<HeroBattleTeamMember> members2
		{
			get
			{
				return this._members2;
			}
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000592C8 File Offset: 0x000574C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B74 RID: 2932
		private uint? _team1;

		// Token: 0x04000B75 RID: 2933
		private readonly List<HeroBattleTeamMember> _members1 = new List<HeroBattleTeamMember>();

		// Token: 0x04000B76 RID: 2934
		private uint? _team2;

		// Token: 0x04000B77 RID: 2935
		private readonly List<HeroBattleTeamMember> _members2 = new List<HeroBattleTeamMember>();

		// Token: 0x04000B78 RID: 2936
		private IExtension extensionObject;
	}
}
