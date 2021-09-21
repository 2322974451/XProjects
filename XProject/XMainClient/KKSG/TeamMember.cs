using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059D RID: 1437
	[ProtoContract(Name = "TeamMember")]
	[Serializable]
	public class TeamMember : IExtensible
	{
		// Token: 0x170017B4 RID: 6068
		// (get) Token: 0x06004CF4 RID: 19700 RVA: 0x00092630 File Offset: 0x00090830
		// (set) Token: 0x06004CF5 RID: 19701 RVA: 0x0009265D File Offset: 0x0009085D
		[ProtoMember(1, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public ulong memberID
		{
			get
			{
				return this._memberID ?? 0UL;
			}
			set
			{
				this._memberID = new ulong?(value);
			}
		}

		// Token: 0x170017B5 RID: 6069
		// (get) Token: 0x06004CF6 RID: 19702 RVA: 0x0009266C File Offset: 0x0009086C
		// (set) Token: 0x06004CF7 RID: 19703 RVA: 0x0009268C File Offset: 0x0009088C
		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new ulong?(this.memberID) : null);
				}
			}
		}

		// Token: 0x06004CF8 RID: 19704 RVA: 0x000926D0 File Offset: 0x000908D0
		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		// Token: 0x06004CF9 RID: 19705 RVA: 0x000926E8 File Offset: 0x000908E8
		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		// Token: 0x170017B6 RID: 6070
		// (get) Token: 0x06004CFA RID: 19706 RVA: 0x000926F4 File Offset: 0x000908F4
		// (set) Token: 0x06004CFB RID: 19707 RVA: 0x00092720 File Offset: 0x00090920
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public RoleType profession
		{
			get
			{
				return this._profession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._profession = new RoleType?(value);
			}
		}

		// Token: 0x170017B7 RID: 6071
		// (get) Token: 0x06004CFC RID: 19708 RVA: 0x00092730 File Offset: 0x00090930
		// (set) Token: 0x06004CFD RID: 19709 RVA: 0x00092750 File Offset: 0x00090950
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
					this._profession = (value ? new RoleType?(this.profession) : null);
				}
			}
		}

		// Token: 0x06004CFE RID: 19710 RVA: 0x00092794 File Offset: 0x00090994
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06004CFF RID: 19711 RVA: 0x000927AC File Offset: 0x000909AC
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170017B8 RID: 6072
		// (get) Token: 0x06004D00 RID: 19712 RVA: 0x000927B8 File Offset: 0x000909B8
		// (set) Token: 0x06004D01 RID: 19713 RVA: 0x000927D9 File Offset: 0x000909D9
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170017B9 RID: 6073
		// (get) Token: 0x06004D02 RID: 19714 RVA: 0x000927E4 File Offset: 0x000909E4
		// (set) Token: 0x06004D03 RID: 19715 RVA: 0x00092800 File Offset: 0x00090A00
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06004D04 RID: 19716 RVA: 0x00092830 File Offset: 0x00090A30
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004D05 RID: 19717 RVA: 0x00092848 File Offset: 0x00090A48
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170017BA RID: 6074
		// (get) Token: 0x06004D06 RID: 19718 RVA: 0x00092854 File Offset: 0x00090A54
		// (set) Token: 0x06004D07 RID: 19719 RVA: 0x00092880 File Offset: 0x00090A80
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x170017BB RID: 6075
		// (get) Token: 0x06004D08 RID: 19720 RVA: 0x00092890 File Offset: 0x00090A90
		// (set) Token: 0x06004D09 RID: 19721 RVA: 0x000928B0 File Offset: 0x00090AB0
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06004D0A RID: 19722 RVA: 0x000928F4 File Offset: 0x00090AF4
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004D0B RID: 19723 RVA: 0x0009290C File Offset: 0x00090B0C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170017BC RID: 6076
		// (get) Token: 0x06004D0C RID: 19724 RVA: 0x00092918 File Offset: 0x00090B18
		// (set) Token: 0x06004D0D RID: 19725 RVA: 0x00092944 File Offset: 0x00090B44
		[ProtoMember(5, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		// Token: 0x170017BD RID: 6077
		// (get) Token: 0x06004D0E RID: 19726 RVA: 0x00092954 File Offset: 0x00090B54
		// (set) Token: 0x06004D0F RID: 19727 RVA: 0x00092974 File Offset: 0x00090B74
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x06004D10 RID: 19728 RVA: 0x000929B8 File Offset: 0x00090BB8
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x06004D11 RID: 19729 RVA: 0x000929D0 File Offset: 0x00090BD0
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x170017BE RID: 6078
		// (get) Token: 0x06004D12 RID: 19730 RVA: 0x000929DC File Offset: 0x00090BDC
		// (set) Token: 0x06004D13 RID: 19731 RVA: 0x00092A08 File Offset: 0x00090C08
		[ProtoMember(6, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public int state
		{
			get
			{
				return this._state ?? 0;
			}
			set
			{
				this._state = new int?(value);
			}
		}

		// Token: 0x170017BF RID: 6079
		// (get) Token: 0x06004D14 RID: 19732 RVA: 0x00092A18 File Offset: 0x00090C18
		// (set) Token: 0x06004D15 RID: 19733 RVA: 0x00092A38 File Offset: 0x00090C38
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
					this._state = (value ? new int?(this.state) : null);
				}
			}
		}

		// Token: 0x06004D16 RID: 19734 RVA: 0x00092A7C File Offset: 0x00090C7C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06004D17 RID: 19735 RVA: 0x00092A94 File Offset: 0x00090C94
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170017C0 RID: 6080
		// (get) Token: 0x06004D18 RID: 19736 RVA: 0x00092AA0 File Offset: 0x00090CA0
		[ProtoMember(7, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x170017C1 RID: 6081
		// (get) Token: 0x06004D19 RID: 19737 RVA: 0x00092AB8 File Offset: 0x00090CB8
		// (set) Token: 0x06004D1A RID: 19738 RVA: 0x00092AE4 File Offset: 0x00090CE4
		[ProtoMember(8, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		// Token: 0x170017C2 RID: 6082
		// (get) Token: 0x06004D1B RID: 19739 RVA: 0x00092AF4 File Offset: 0x00090CF4
		// (set) Token: 0x06004D1C RID: 19740 RVA: 0x00092B14 File Offset: 0x00090D14
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x06004D1D RID: 19741 RVA: 0x00092B58 File Offset: 0x00090D58
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x06004D1E RID: 19742 RVA: 0x00092B70 File Offset: 0x00090D70
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x170017C3 RID: 6083
		// (get) Token: 0x06004D1F RID: 19743 RVA: 0x00092B7C File Offset: 0x00090D7C
		// (set) Token: 0x06004D20 RID: 19744 RVA: 0x00092BA8 File Offset: 0x00090DA8
		[ProtoMember(9, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		// Token: 0x170017C4 RID: 6084
		// (get) Token: 0x06004D21 RID: 19745 RVA: 0x00092BB8 File Offset: 0x00090DB8
		// (set) Token: 0x06004D22 RID: 19746 RVA: 0x00092BD8 File Offset: 0x00090DD8
		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		// Token: 0x06004D23 RID: 19747 RVA: 0x00092C1C File Offset: 0x00090E1C
		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		// Token: 0x06004D24 RID: 19748 RVA: 0x00092C34 File Offset: 0x00090E34
		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		// Token: 0x170017C5 RID: 6085
		// (get) Token: 0x06004D25 RID: 19749 RVA: 0x00092C40 File Offset: 0x00090E40
		// (set) Token: 0x06004D26 RID: 19750 RVA: 0x00092C6C File Offset: 0x00090E6C
		[ProtoMember(10, IsRequired = false, Name = "robot", DataFormat = DataFormat.Default)]
		public bool robot
		{
			get
			{
				return this._robot ?? false;
			}
			set
			{
				this._robot = new bool?(value);
			}
		}

		// Token: 0x170017C6 RID: 6086
		// (get) Token: 0x06004D27 RID: 19751 RVA: 0x00092C7C File Offset: 0x00090E7C
		// (set) Token: 0x06004D28 RID: 19752 RVA: 0x00092C9C File Offset: 0x00090E9C
		[XmlIgnore]
		[Browsable(false)]
		public bool robotSpecified
		{
			get
			{
				return this._robot != null;
			}
			set
			{
				bool flag = value == (this._robot == null);
				if (flag)
				{
					this._robot = (value ? new bool?(this.robot) : null);
				}
			}
		}

		// Token: 0x06004D29 RID: 19753 RVA: 0x00092CE0 File Offset: 0x00090EE0
		private bool ShouldSerializerobot()
		{
			return this.robotSpecified;
		}

		// Token: 0x06004D2A RID: 19754 RVA: 0x00092CF8 File Offset: 0x00090EF8
		private void Resetrobot()
		{
			this.robotSpecified = false;
		}

		// Token: 0x170017C7 RID: 6087
		// (get) Token: 0x06004D2B RID: 19755 RVA: 0x00092D04 File Offset: 0x00090F04
		// (set) Token: 0x06004D2C RID: 19756 RVA: 0x00092D31 File Offset: 0x00090F31
		[ProtoMember(11, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x170017C8 RID: 6088
		// (get) Token: 0x06004D2D RID: 19757 RVA: 0x00092D40 File Offset: 0x00090F40
		// (set) Token: 0x06004D2E RID: 19758 RVA: 0x00092D60 File Offset: 0x00090F60
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06004D2F RID: 19759 RVA: 0x00092DA4 File Offset: 0x00090FA4
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06004D30 RID: 19760 RVA: 0x00092DBC File Offset: 0x00090FBC
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x170017C9 RID: 6089
		// (get) Token: 0x06004D31 RID: 19761 RVA: 0x00092DC8 File Offset: 0x00090FC8
		// (set) Token: 0x06004D32 RID: 19762 RVA: 0x00092DF5 File Offset: 0x00090FF5
		[ProtoMember(12, IsRequired = false, Name = "dragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildid
		{
			get
			{
				return this._dragonguildid ?? 0UL;
			}
			set
			{
				this._dragonguildid = new ulong?(value);
			}
		}

		// Token: 0x170017CA RID: 6090
		// (get) Token: 0x06004D33 RID: 19763 RVA: 0x00092E04 File Offset: 0x00091004
		// (set) Token: 0x06004D34 RID: 19764 RVA: 0x00092E24 File Offset: 0x00091024
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildidSpecified
		{
			get
			{
				return this._dragonguildid != null;
			}
			set
			{
				bool flag = value == (this._dragonguildid == null);
				if (flag)
				{
					this._dragonguildid = (value ? new ulong?(this.dragonguildid) : null);
				}
			}
		}

		// Token: 0x06004D35 RID: 19765 RVA: 0x00092E68 File Offset: 0x00091068
		private bool ShouldSerializedragonguildid()
		{
			return this.dragonguildidSpecified;
		}

		// Token: 0x06004D36 RID: 19766 RVA: 0x00092E80 File Offset: 0x00091080
		private void Resetdragonguildid()
		{
			this.dragonguildidSpecified = false;
		}

		// Token: 0x170017CB RID: 6091
		// (get) Token: 0x06004D37 RID: 19767 RVA: 0x00092E8C File Offset: 0x0009108C
		// (set) Token: 0x06004D38 RID: 19768 RVA: 0x00092EA4 File Offset: 0x000910A4
		[ProtoMember(13, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x170017CC RID: 6092
		// (get) Token: 0x06004D39 RID: 19769 RVA: 0x00092EB0 File Offset: 0x000910B0
		// (set) Token: 0x06004D3A RID: 19770 RVA: 0x00092EDC File Offset: 0x000910DC
		[ProtoMember(14, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public uint vipLevel
		{
			get
			{
				return this._vipLevel ?? 0U;
			}
			set
			{
				this._vipLevel = new uint?(value);
			}
		}

		// Token: 0x170017CD RID: 6093
		// (get) Token: 0x06004D3B RID: 19771 RVA: 0x00092EEC File Offset: 0x000910EC
		// (set) Token: 0x06004D3C RID: 19772 RVA: 0x00092F0C File Offset: 0x0009110C
		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new uint?(this.vipLevel) : null);
				}
			}
		}

		// Token: 0x06004D3D RID: 19773 RVA: 0x00092F50 File Offset: 0x00091150
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x06004D3E RID: 19774 RVA: 0x00092F68 File Offset: 0x00091168
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x170017CE RID: 6094
		// (get) Token: 0x06004D3F RID: 19775 RVA: 0x00092F74 File Offset: 0x00091174
		// (set) Token: 0x06004D40 RID: 19776 RVA: 0x00092FA0 File Offset: 0x000911A0
		[ProtoMember(15, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x170017CF RID: 6095
		// (get) Token: 0x06004D41 RID: 19777 RVA: 0x00092FB0 File Offset: 0x000911B0
		// (set) Token: 0x06004D42 RID: 19778 RVA: 0x00092FD0 File Offset: 0x000911D0
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x06004D43 RID: 19779 RVA: 0x00093014 File Offset: 0x00091214
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x06004D44 RID: 19780 RVA: 0x0009302C File Offset: 0x0009122C
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x170017D0 RID: 6096
		// (get) Token: 0x06004D45 RID: 19781 RVA: 0x00093038 File Offset: 0x00091238
		// (set) Token: 0x06004D46 RID: 19782 RVA: 0x00093064 File Offset: 0x00091264
		[ProtoMember(16, IsRequired = false, Name = "membertype", DataFormat = DataFormat.TwosComplement)]
		public TeamMemberType membertype
		{
			get
			{
				return this._membertype ?? TeamMemberType.TMT_NORMAL;
			}
			set
			{
				this._membertype = new TeamMemberType?(value);
			}
		}

		// Token: 0x170017D1 RID: 6097
		// (get) Token: 0x06004D47 RID: 19783 RVA: 0x00093074 File Offset: 0x00091274
		// (set) Token: 0x06004D48 RID: 19784 RVA: 0x00093094 File Offset: 0x00091294
		[XmlIgnore]
		[Browsable(false)]
		public bool membertypeSpecified
		{
			get
			{
				return this._membertype != null;
			}
			set
			{
				bool flag = value == (this._membertype == null);
				if (flag)
				{
					this._membertype = (value ? new TeamMemberType?(this.membertype) : null);
				}
			}
		}

		// Token: 0x06004D49 RID: 19785 RVA: 0x000930D8 File Offset: 0x000912D8
		private bool ShouldSerializemembertype()
		{
			return this.membertypeSpecified;
		}

		// Token: 0x06004D4A RID: 19786 RVA: 0x000930F0 File Offset: 0x000912F0
		private void Resetmembertype()
		{
			this.membertypeSpecified = false;
		}

		// Token: 0x170017D2 RID: 6098
		// (get) Token: 0x06004D4B RID: 19787 RVA: 0x000930FC File Offset: 0x000912FC
		// (set) Token: 0x06004D4C RID: 19788 RVA: 0x00093128 File Offset: 0x00091328
		[ProtoMember(17, IsRequired = false, Name = "tarjatime", DataFormat = DataFormat.TwosComplement)]
		public uint tarjatime
		{
			get
			{
				return this._tarjatime ?? 0U;
			}
			set
			{
				this._tarjatime = new uint?(value);
			}
		}

		// Token: 0x170017D3 RID: 6099
		// (get) Token: 0x06004D4D RID: 19789 RVA: 0x00093138 File Offset: 0x00091338
		// (set) Token: 0x06004D4E RID: 19790 RVA: 0x00093158 File Offset: 0x00091358
		[XmlIgnore]
		[Browsable(false)]
		public bool tarjatimeSpecified
		{
			get
			{
				return this._tarjatime != null;
			}
			set
			{
				bool flag = value == (this._tarjatime == null);
				if (flag)
				{
					this._tarjatime = (value ? new uint?(this.tarjatime) : null);
				}
			}
		}

		// Token: 0x06004D4F RID: 19791 RVA: 0x0009319C File Offset: 0x0009139C
		private bool ShouldSerializetarjatime()
		{
			return this.tarjatimeSpecified;
		}

		// Token: 0x06004D50 RID: 19792 RVA: 0x000931B4 File Offset: 0x000913B4
		private void Resettarjatime()
		{
			this.tarjatimeSpecified = false;
		}

		// Token: 0x170017D4 RID: 6100
		// (get) Token: 0x06004D51 RID: 19793 RVA: 0x000931C0 File Offset: 0x000913C0
		// (set) Token: 0x06004D52 RID: 19794 RVA: 0x000931EC File Offset: 0x000913EC
		[ProtoMember(18, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x170017D5 RID: 6101
		// (get) Token: 0x06004D53 RID: 19795 RVA: 0x000931FC File Offset: 0x000913FC
		// (set) Token: 0x06004D54 RID: 19796 RVA: 0x0009321C File Offset: 0x0009141C
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06004D55 RID: 19797 RVA: 0x00093260 File Offset: 0x00091460
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06004D56 RID: 19798 RVA: 0x00093278 File Offset: 0x00091478
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170017D6 RID: 6102
		// (get) Token: 0x06004D57 RID: 19799 RVA: 0x00093284 File Offset: 0x00091484
		// (set) Token: 0x06004D58 RID: 19800 RVA: 0x000932B0 File Offset: 0x000914B0
		[ProtoMember(19, IsRequired = false, Name = "kingback", DataFormat = DataFormat.Default)]
		public bool kingback
		{
			get
			{
				return this._kingback ?? false;
			}
			set
			{
				this._kingback = new bool?(value);
			}
		}

		// Token: 0x170017D7 RID: 6103
		// (get) Token: 0x06004D59 RID: 19801 RVA: 0x000932C0 File Offset: 0x000914C0
		// (set) Token: 0x06004D5A RID: 19802 RVA: 0x000932E0 File Offset: 0x000914E0
		[XmlIgnore]
		[Browsable(false)]
		public bool kingbackSpecified
		{
			get
			{
				return this._kingback != null;
			}
			set
			{
				bool flag = value == (this._kingback == null);
				if (flag)
				{
					this._kingback = (value ? new bool?(this.kingback) : null);
				}
			}
		}

		// Token: 0x06004D5B RID: 19803 RVA: 0x00093324 File Offset: 0x00091524
		private bool ShouldSerializekingback()
		{
			return this.kingbackSpecified;
		}

		// Token: 0x06004D5C RID: 19804 RVA: 0x0009333C File Offset: 0x0009153C
		private void Resetkingback()
		{
			this.kingbackSpecified = false;
		}

		// Token: 0x06004D5D RID: 19805 RVA: 0x00093348 File Offset: 0x00091548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001312 RID: 4882
		private ulong? _memberID;

		// Token: 0x04001313 RID: 4883
		private RoleType? _profession;

		// Token: 0x04001314 RID: 4884
		private string _name;

		// Token: 0x04001315 RID: 4885
		private int? _level;

		// Token: 0x04001316 RID: 4886
		private uint? _powerpoint;

		// Token: 0x04001317 RID: 4887
		private int? _state;

		// Token: 0x04001318 RID: 4888
		private readonly List<uint> _fashion = new List<uint>();

		// Token: 0x04001319 RID: 4889
		private uint? _sceneID;

		// Token: 0x0400131A RID: 4890
		private int? _leftcount;

		// Token: 0x0400131B RID: 4891
		private bool? _robot;

		// Token: 0x0400131C RID: 4892
		private ulong? _guildid;

		// Token: 0x0400131D RID: 4893
		private ulong? _dragonguildid;

		// Token: 0x0400131E RID: 4894
		private OutLook _outlook = null;

		// Token: 0x0400131F RID: 4895
		private uint? _vipLevel;

		// Token: 0x04001320 RID: 4896
		private uint? _paymemberid;

		// Token: 0x04001321 RID: 4897
		private TeamMemberType? _membertype;

		// Token: 0x04001322 RID: 4898
		private uint? _tarjatime;

		// Token: 0x04001323 RID: 4899
		private uint? _serverid;

		// Token: 0x04001324 RID: 4900
		private bool? _kingback;

		// Token: 0x04001325 RID: 4901
		private IExtension extensionObject;
	}
}
