using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068C RID: 1676
	[ProtoContract(Name = "TeamInvRoleInfo")]
	[Serializable]
	public class TeamInvRoleInfo : IExtensible
	{
		// Token: 0x17002232 RID: 8754
		// (get) Token: 0x06006C0D RID: 27661 RVA: 0x000CEB30 File Offset: 0x000CCD30
		// (set) Token: 0x06006C0E RID: 27662 RVA: 0x000CEB5D File Offset: 0x000CCD5D
		[ProtoMember(1, IsRequired = false, Name = "userID", DataFormat = DataFormat.TwosComplement)]
		public ulong userID
		{
			get
			{
				return this._userID ?? 0UL;
			}
			set
			{
				this._userID = new ulong?(value);
			}
		}

		// Token: 0x17002233 RID: 8755
		// (get) Token: 0x06006C0F RID: 27663 RVA: 0x000CEB6C File Offset: 0x000CCD6C
		// (set) Token: 0x06006C10 RID: 27664 RVA: 0x000CEB8C File Offset: 0x000CCD8C
		[XmlIgnore]
		[Browsable(false)]
		public bool userIDSpecified
		{
			get
			{
				return this._userID != null;
			}
			set
			{
				bool flag = value == (this._userID == null);
				if (flag)
				{
					this._userID = (value ? new ulong?(this.userID) : null);
				}
			}
		}

		// Token: 0x06006C11 RID: 27665 RVA: 0x000CEBD0 File Offset: 0x000CCDD0
		private bool ShouldSerializeuserID()
		{
			return this.userIDSpecified;
		}

		// Token: 0x06006C12 RID: 27666 RVA: 0x000CEBE8 File Offset: 0x000CCDE8
		private void ResetuserID()
		{
			this.userIDSpecified = false;
		}

		// Token: 0x17002234 RID: 8756
		// (get) Token: 0x06006C13 RID: 27667 RVA: 0x000CEBF4 File Offset: 0x000CCDF4
		// (set) Token: 0x06006C14 RID: 27668 RVA: 0x000CEC15 File Offset: 0x000CCE15
		[ProtoMember(2, IsRequired = false, Name = "userName", DataFormat = DataFormat.Default)]
		public string userName
		{
			get
			{
				return this._userName ?? "";
			}
			set
			{
				this._userName = value;
			}
		}

		// Token: 0x17002235 RID: 8757
		// (get) Token: 0x06006C15 RID: 27669 RVA: 0x000CEC20 File Offset: 0x000CCE20
		// (set) Token: 0x06006C16 RID: 27670 RVA: 0x000CEC3C File Offset: 0x000CCE3C
		[XmlIgnore]
		[Browsable(false)]
		public bool userNameSpecified
		{
			get
			{
				return this._userName != null;
			}
			set
			{
				bool flag = value == (this._userName == null);
				if (flag)
				{
					this._userName = (value ? this.userName : null);
				}
			}
		}

		// Token: 0x06006C17 RID: 27671 RVA: 0x000CEC6C File Offset: 0x000CCE6C
		private bool ShouldSerializeuserName()
		{
			return this.userNameSpecified;
		}

		// Token: 0x06006C18 RID: 27672 RVA: 0x000CEC84 File Offset: 0x000CCE84
		private void ResetuserName()
		{
			this.userNameSpecified = false;
		}

		// Token: 0x17002236 RID: 8758
		// (get) Token: 0x06006C19 RID: 27673 RVA: 0x000CEC90 File Offset: 0x000CCE90
		// (set) Token: 0x06006C1A RID: 27674 RVA: 0x000CECBC File Offset: 0x000CCEBC
		[ProtoMember(3, IsRequired = false, Name = "userLevel", DataFormat = DataFormat.TwosComplement)]
		public uint userLevel
		{
			get
			{
				return this._userLevel ?? 0U;
			}
			set
			{
				this._userLevel = new uint?(value);
			}
		}

		// Token: 0x17002237 RID: 8759
		// (get) Token: 0x06006C1B RID: 27675 RVA: 0x000CECCC File Offset: 0x000CCECC
		// (set) Token: 0x06006C1C RID: 27676 RVA: 0x000CECEC File Offset: 0x000CCEEC
		[XmlIgnore]
		[Browsable(false)]
		public bool userLevelSpecified
		{
			get
			{
				return this._userLevel != null;
			}
			set
			{
				bool flag = value == (this._userLevel == null);
				if (flag)
				{
					this._userLevel = (value ? new uint?(this.userLevel) : null);
				}
			}
		}

		// Token: 0x06006C1D RID: 27677 RVA: 0x000CED30 File Offset: 0x000CCF30
		private bool ShouldSerializeuserLevel()
		{
			return this.userLevelSpecified;
		}

		// Token: 0x06006C1E RID: 27678 RVA: 0x000CED48 File Offset: 0x000CCF48
		private void ResetuserLevel()
		{
			this.userLevelSpecified = false;
		}

		// Token: 0x17002238 RID: 8760
		// (get) Token: 0x06006C1F RID: 27679 RVA: 0x000CED54 File Offset: 0x000CCF54
		// (set) Token: 0x06006C20 RID: 27680 RVA: 0x000CED80 File Offset: 0x000CCF80
		[ProtoMember(4, IsRequired = false, Name = "userVip", DataFormat = DataFormat.TwosComplement)]
		public uint userVip
		{
			get
			{
				return this._userVip ?? 0U;
			}
			set
			{
				this._userVip = new uint?(value);
			}
		}

		// Token: 0x17002239 RID: 8761
		// (get) Token: 0x06006C21 RID: 27681 RVA: 0x000CED90 File Offset: 0x000CCF90
		// (set) Token: 0x06006C22 RID: 27682 RVA: 0x000CEDB0 File Offset: 0x000CCFB0
		[XmlIgnore]
		[Browsable(false)]
		public bool userVipSpecified
		{
			get
			{
				return this._userVip != null;
			}
			set
			{
				bool flag = value == (this._userVip == null);
				if (flag)
				{
					this._userVip = (value ? new uint?(this.userVip) : null);
				}
			}
		}

		// Token: 0x06006C23 RID: 27683 RVA: 0x000CEDF4 File Offset: 0x000CCFF4
		private bool ShouldSerializeuserVip()
		{
			return this.userVipSpecified;
		}

		// Token: 0x06006C24 RID: 27684 RVA: 0x000CEE0C File Offset: 0x000CD00C
		private void ResetuserVip()
		{
			this.userVipSpecified = false;
		}

		// Token: 0x1700223A RID: 8762
		// (get) Token: 0x06006C25 RID: 27685 RVA: 0x000CEE18 File Offset: 0x000CD018
		// (set) Token: 0x06006C26 RID: 27686 RVA: 0x000CEE44 File Offset: 0x000CD044
		[ProtoMember(5, IsRequired = false, Name = "userPowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint userPowerPoint
		{
			get
			{
				return this._userPowerPoint ?? 0U;
			}
			set
			{
				this._userPowerPoint = new uint?(value);
			}
		}

		// Token: 0x1700223B RID: 8763
		// (get) Token: 0x06006C27 RID: 27687 RVA: 0x000CEE54 File Offset: 0x000CD054
		// (set) Token: 0x06006C28 RID: 27688 RVA: 0x000CEE74 File Offset: 0x000CD074
		[XmlIgnore]
		[Browsable(false)]
		public bool userPowerPointSpecified
		{
			get
			{
				return this._userPowerPoint != null;
			}
			set
			{
				bool flag = value == (this._userPowerPoint == null);
				if (flag)
				{
					this._userPowerPoint = (value ? new uint?(this.userPowerPoint) : null);
				}
			}
		}

		// Token: 0x06006C29 RID: 27689 RVA: 0x000CEEB8 File Offset: 0x000CD0B8
		private bool ShouldSerializeuserPowerPoint()
		{
			return this.userPowerPointSpecified;
		}

		// Token: 0x06006C2A RID: 27690 RVA: 0x000CEED0 File Offset: 0x000CD0D0
		private void ResetuserPowerPoint()
		{
			this.userPowerPointSpecified = false;
		}

		// Token: 0x1700223C RID: 8764
		// (get) Token: 0x06006C2B RID: 27691 RVA: 0x000CEEDC File Offset: 0x000CD0DC
		// (set) Token: 0x06006C2C RID: 27692 RVA: 0x000CEEFD File Offset: 0x000CD0FD
		[ProtoMember(6, IsRequired = false, Name = "guildName", DataFormat = DataFormat.Default)]
		public string guildName
		{
			get
			{
				return this._guildName ?? "";
			}
			set
			{
				this._guildName = value;
			}
		}

		// Token: 0x1700223D RID: 8765
		// (get) Token: 0x06006C2D RID: 27693 RVA: 0x000CEF08 File Offset: 0x000CD108
		// (set) Token: 0x06006C2E RID: 27694 RVA: 0x000CEF24 File Offset: 0x000CD124
		[XmlIgnore]
		[Browsable(false)]
		public bool guildNameSpecified
		{
			get
			{
				return this._guildName != null;
			}
			set
			{
				bool flag = value == (this._guildName == null);
				if (flag)
				{
					this._guildName = (value ? this.guildName : null);
				}
			}
		}

		// Token: 0x06006C2F RID: 27695 RVA: 0x000CEF54 File Offset: 0x000CD154
		private bool ShouldSerializeguildName()
		{
			return this.guildNameSpecified;
		}

		// Token: 0x06006C30 RID: 27696 RVA: 0x000CEF6C File Offset: 0x000CD16C
		private void ResetguildName()
		{
			this.guildNameSpecified = false;
		}

		// Token: 0x1700223E RID: 8766
		// (get) Token: 0x06006C31 RID: 27697 RVA: 0x000CEF78 File Offset: 0x000CD178
		// (set) Token: 0x06006C32 RID: 27698 RVA: 0x000CEFA4 File Offset: 0x000CD1A4
		[ProtoMember(7, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		// Token: 0x1700223F RID: 8767
		// (get) Token: 0x06006C33 RID: 27699 RVA: 0x000CEFB4 File Offset: 0x000CD1B4
		// (set) Token: 0x06006C34 RID: 27700 RVA: 0x000CEFD4 File Offset: 0x000CD1D4
		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		// Token: 0x06006C35 RID: 27701 RVA: 0x000CF018 File Offset: 0x000CD218
		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		// Token: 0x06006C36 RID: 27702 RVA: 0x000CF030 File Offset: 0x000CD230
		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		// Token: 0x17002240 RID: 8768
		// (get) Token: 0x06006C37 RID: 27703 RVA: 0x000CF03C File Offset: 0x000CD23C
		// (set) Token: 0x06006C38 RID: 27704 RVA: 0x000CF068 File Offset: 0x000CD268
		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		// Token: 0x17002241 RID: 8769
		// (get) Token: 0x06006C39 RID: 27705 RVA: 0x000CF078 File Offset: 0x000CD278
		// (set) Token: 0x06006C3A RID: 27706 RVA: 0x000CF098 File Offset: 0x000CD298
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		// Token: 0x06006C3B RID: 27707 RVA: 0x000CF0DC File Offset: 0x000CD2DC
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06006C3C RID: 27708 RVA: 0x000CF0F4 File Offset: 0x000CD2F4
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002242 RID: 8770
		// (get) Token: 0x06006C3D RID: 27709 RVA: 0x000CF100 File Offset: 0x000CD300
		// (set) Token: 0x06006C3E RID: 27710 RVA: 0x000CF12D File Offset: 0x000CD32D
		[ProtoMember(9, IsRequired = false, Name = "teamguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong teamguildid
		{
			get
			{
				return this._teamguildid ?? 0UL;
			}
			set
			{
				this._teamguildid = new ulong?(value);
			}
		}

		// Token: 0x17002243 RID: 8771
		// (get) Token: 0x06006C3F RID: 27711 RVA: 0x000CF13C File Offset: 0x000CD33C
		// (set) Token: 0x06006C40 RID: 27712 RVA: 0x000CF15C File Offset: 0x000CD35C
		[XmlIgnore]
		[Browsable(false)]
		public bool teamguildidSpecified
		{
			get
			{
				return this._teamguildid != null;
			}
			set
			{
				bool flag = value == (this._teamguildid == null);
				if (flag)
				{
					this._teamguildid = (value ? new ulong?(this.teamguildid) : null);
				}
			}
		}

		// Token: 0x06006C41 RID: 27713 RVA: 0x000CF1A0 File Offset: 0x000CD3A0
		private bool ShouldSerializeteamguildid()
		{
			return this.teamguildidSpecified;
		}

		// Token: 0x06006C42 RID: 27714 RVA: 0x000CF1B8 File Offset: 0x000CD3B8
		private void Resetteamguildid()
		{
			this.teamguildidSpecified = false;
		}

		// Token: 0x17002244 RID: 8772
		// (get) Token: 0x06006C43 RID: 27715 RVA: 0x000CF1C4 File Offset: 0x000CD3C4
		// (set) Token: 0x06006C44 RID: 27716 RVA: 0x000CF1F1 File Offset: 0x000CD3F1
		[ProtoMember(10, IsRequired = false, Name = "roleguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleguildid
		{
			get
			{
				return this._roleguildid ?? 0UL;
			}
			set
			{
				this._roleguildid = new ulong?(value);
			}
		}

		// Token: 0x17002245 RID: 8773
		// (get) Token: 0x06006C45 RID: 27717 RVA: 0x000CF200 File Offset: 0x000CD400
		// (set) Token: 0x06006C46 RID: 27718 RVA: 0x000CF220 File Offset: 0x000CD420
		[XmlIgnore]
		[Browsable(false)]
		public bool roleguildidSpecified
		{
			get
			{
				return this._roleguildid != null;
			}
			set
			{
				bool flag = value == (this._roleguildid == null);
				if (flag)
				{
					this._roleguildid = (value ? new ulong?(this.roleguildid) : null);
				}
			}
		}

		// Token: 0x06006C47 RID: 27719 RVA: 0x000CF264 File Offset: 0x000CD464
		private bool ShouldSerializeroleguildid()
		{
			return this.roleguildidSpecified;
		}

		// Token: 0x06006C48 RID: 27720 RVA: 0x000CF27C File Offset: 0x000CD47C
		private void Resetroleguildid()
		{
			this.roleguildidSpecified = false;
		}

		// Token: 0x17002246 RID: 8774
		// (get) Token: 0x06006C49 RID: 27721 RVA: 0x000CF288 File Offset: 0x000CD488
		// (set) Token: 0x06006C4A RID: 27722 RVA: 0x000CF2B5 File Offset: 0x000CD4B5
		[ProtoMember(11, IsRequired = false, Name = "roledragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong roledragonguildid
		{
			get
			{
				return this._roledragonguildid ?? 0UL;
			}
			set
			{
				this._roledragonguildid = new ulong?(value);
			}
		}

		// Token: 0x17002247 RID: 8775
		// (get) Token: 0x06006C4B RID: 27723 RVA: 0x000CF2C4 File Offset: 0x000CD4C4
		// (set) Token: 0x06006C4C RID: 27724 RVA: 0x000CF2E4 File Offset: 0x000CD4E4
		[XmlIgnore]
		[Browsable(false)]
		public bool roledragonguildidSpecified
		{
			get
			{
				return this._roledragonguildid != null;
			}
			set
			{
				bool flag = value == (this._roledragonguildid == null);
				if (flag)
				{
					this._roledragonguildid = (value ? new ulong?(this.roledragonguildid) : null);
				}
			}
		}

		// Token: 0x06006C4D RID: 27725 RVA: 0x000CF328 File Offset: 0x000CD528
		private bool ShouldSerializeroledragonguildid()
		{
			return this.roledragonguildidSpecified;
		}

		// Token: 0x06006C4E RID: 27726 RVA: 0x000CF340 File Offset: 0x000CD540
		private void Resetroledragonguildid()
		{
			this.roledragonguildidSpecified = false;
		}

		// Token: 0x17002248 RID: 8776
		// (get) Token: 0x06006C4F RID: 27727 RVA: 0x000CF34C File Offset: 0x000CD54C
		// (set) Token: 0x06006C50 RID: 27728 RVA: 0x000CF378 File Offset: 0x000CD578
		[ProtoMember(12, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public TeamInvRoleState state
		{
			get
			{
				return this._state ?? TeamInvRoleState.TIRS_IN_OTHER_TEAM;
			}
			set
			{
				this._state = new TeamInvRoleState?(value);
			}
		}

		// Token: 0x17002249 RID: 8777
		// (get) Token: 0x06006C51 RID: 27729 RVA: 0x000CF388 File Offset: 0x000CD588
		// (set) Token: 0x06006C52 RID: 27730 RVA: 0x000CF3A8 File Offset: 0x000CD5A8
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new TeamInvRoleState?(this.state) : null);
				}
			}
		}

		// Token: 0x06006C53 RID: 27731 RVA: 0x000CF3EC File Offset: 0x000CD5EC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006C54 RID: 27732 RVA: 0x000CF404 File Offset: 0x000CD604
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x1700224A RID: 8778
		// (get) Token: 0x06006C55 RID: 27733 RVA: 0x000CF410 File Offset: 0x000CD610
		// (set) Token: 0x06006C56 RID: 27734 RVA: 0x000CF43C File Offset: 0x000CD63C
		[ProtoMember(13, IsRequired = false, Name = "wanthelp", DataFormat = DataFormat.Default)]
		public bool wanthelp
		{
			get
			{
				return this._wanthelp ?? false;
			}
			set
			{
				this._wanthelp = new bool?(value);
			}
		}

		// Token: 0x1700224B RID: 8779
		// (get) Token: 0x06006C57 RID: 27735 RVA: 0x000CF44C File Offset: 0x000CD64C
		// (set) Token: 0x06006C58 RID: 27736 RVA: 0x000CF46C File Offset: 0x000CD66C
		[XmlIgnore]
		[Browsable(false)]
		public bool wanthelpSpecified
		{
			get
			{
				return this._wanthelp != null;
			}
			set
			{
				bool flag = value == (this._wanthelp == null);
				if (flag)
				{
					this._wanthelp = (value ? new bool?(this.wanthelp) : null);
				}
			}
		}

		// Token: 0x06006C59 RID: 27737 RVA: 0x000CF4B0 File Offset: 0x000CD6B0
		private bool ShouldSerializewanthelp()
		{
			return this.wanthelpSpecified;
		}

		// Token: 0x06006C5A RID: 27738 RVA: 0x000CF4C8 File Offset: 0x000CD6C8
		private void Resetwanthelp()
		{
			this.wanthelpSpecified = false;
		}

		// Token: 0x06006C5B RID: 27739 RVA: 0x000CF4D4 File Offset: 0x000CD6D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019F6 RID: 6646
		private ulong? _userID;

		// Token: 0x040019F7 RID: 6647
		private string _userName;

		// Token: 0x040019F8 RID: 6648
		private uint? _userLevel;

		// Token: 0x040019F9 RID: 6649
		private uint? _userVip;

		// Token: 0x040019FA RID: 6650
		private uint? _userPowerPoint;

		// Token: 0x040019FB RID: 6651
		private string _guildName;

		// Token: 0x040019FC RID: 6652
		private uint? _degree;

		// Token: 0x040019FD RID: 6653
		private int? _profession;

		// Token: 0x040019FE RID: 6654
		private ulong? _teamguildid;

		// Token: 0x040019FF RID: 6655
		private ulong? _roleguildid;

		// Token: 0x04001A00 RID: 6656
		private ulong? _roledragonguildid;

		// Token: 0x04001A01 RID: 6657
		private TeamInvRoleState? _state;

		// Token: 0x04001A02 RID: 6658
		private bool? _wanthelp;

		// Token: 0x04001A03 RID: 6659
		private IExtension extensionObject;
	}
}
