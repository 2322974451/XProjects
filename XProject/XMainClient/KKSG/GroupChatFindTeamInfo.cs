using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000721 RID: 1825
	[ProtoContract(Name = "GroupChatFindTeamInfo")]
	[Serializable]
	public class GroupChatFindTeamInfo : IExtensible
	{
		// Token: 0x170027A6 RID: 10150
		// (get) Token: 0x06007D13 RID: 32019 RVA: 0x000EF27C File Offset: 0x000ED47C
		// (set) Token: 0x06007D14 RID: 32020 RVA: 0x000EF2A9 File Offset: 0x000ED4A9
		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		// Token: 0x170027A7 RID: 10151
		// (get) Token: 0x06007D15 RID: 32021 RVA: 0x000EF2B8 File Offset: 0x000ED4B8
		// (set) Token: 0x06007D16 RID: 32022 RVA: 0x000EF2D8 File Offset: 0x000ED4D8
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		// Token: 0x06007D17 RID: 32023 RVA: 0x000EF31C File Offset: 0x000ED51C
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06007D18 RID: 32024 RVA: 0x000EF334 File Offset: 0x000ED534
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x170027A8 RID: 10152
		// (get) Token: 0x06007D19 RID: 32025 RVA: 0x000EF340 File Offset: 0x000ED540
		// (set) Token: 0x06007D1A RID: 32026 RVA: 0x000EF361 File Offset: 0x000ED561
		[ProtoMember(2, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
		public string groupchatName
		{
			get
			{
				return this._groupchatName ?? "";
			}
			set
			{
				this._groupchatName = value;
			}
		}

		// Token: 0x170027A9 RID: 10153
		// (get) Token: 0x06007D1B RID: 32027 RVA: 0x000EF36C File Offset: 0x000ED56C
		// (set) Token: 0x06007D1C RID: 32028 RVA: 0x000EF388 File Offset: 0x000ED588
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatNameSpecified
		{
			get
			{
				return this._groupchatName != null;
			}
			set
			{
				bool flag = value == (this._groupchatName == null);
				if (flag)
				{
					this._groupchatName = (value ? this.groupchatName : null);
				}
			}
		}

		// Token: 0x06007D1D RID: 32029 RVA: 0x000EF3B8 File Offset: 0x000ED5B8
		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		// Token: 0x06007D1E RID: 32030 RVA: 0x000EF3D0 File Offset: 0x000ED5D0
		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		// Token: 0x170027AA RID: 10154
		// (get) Token: 0x06007D1F RID: 32031 RVA: 0x000EF3DC File Offset: 0x000ED5DC
		// (set) Token: 0x06007D20 RID: 32032 RVA: 0x000EF409 File Offset: 0x000ED609
		[ProtoMember(3, IsRequired = false, Name = "issueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong issueIndex
		{
			get
			{
				return this._issueIndex ?? 0UL;
			}
			set
			{
				this._issueIndex = new ulong?(value);
			}
		}

		// Token: 0x170027AB RID: 10155
		// (get) Token: 0x06007D21 RID: 32033 RVA: 0x000EF418 File Offset: 0x000ED618
		// (set) Token: 0x06007D22 RID: 32034 RVA: 0x000EF438 File Offset: 0x000ED638
		[XmlIgnore]
		[Browsable(false)]
		public bool issueIndexSpecified
		{
			get
			{
				return this._issueIndex != null;
			}
			set
			{
				bool flag = value == (this._issueIndex == null);
				if (flag)
				{
					this._issueIndex = (value ? new ulong?(this.issueIndex) : null);
				}
			}
		}

		// Token: 0x06007D23 RID: 32035 RVA: 0x000EF47C File Offset: 0x000ED67C
		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		// Token: 0x06007D24 RID: 32036 RVA: 0x000EF494 File Offset: 0x000ED694
		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		// Token: 0x170027AC RID: 10156
		// (get) Token: 0x06007D25 RID: 32037 RVA: 0x000EF4A0 File Offset: 0x000ED6A0
		// (set) Token: 0x06007D26 RID: 32038 RVA: 0x000EF4CC File Offset: 0x000ED6CC
		[ProtoMember(4, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
		public uint stageID
		{
			get
			{
				return this._stageID ?? 0U;
			}
			set
			{
				this._stageID = new uint?(value);
			}
		}

		// Token: 0x170027AD RID: 10157
		// (get) Token: 0x06007D27 RID: 32039 RVA: 0x000EF4DC File Offset: 0x000ED6DC
		// (set) Token: 0x06007D28 RID: 32040 RVA: 0x000EF4FC File Offset: 0x000ED6FC
		[XmlIgnore]
		[Browsable(false)]
		public bool stageIDSpecified
		{
			get
			{
				return this._stageID != null;
			}
			set
			{
				bool flag = value == (this._stageID == null);
				if (flag)
				{
					this._stageID = (value ? new uint?(this.stageID) : null);
				}
			}
		}

		// Token: 0x06007D29 RID: 32041 RVA: 0x000EF540 File Offset: 0x000ED740
		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		// Token: 0x06007D2A RID: 32042 RVA: 0x000EF558 File Offset: 0x000ED758
		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		// Token: 0x170027AE RID: 10158
		// (get) Token: 0x06007D2B RID: 32043 RVA: 0x000EF564 File Offset: 0x000ED764
		// (set) Token: 0x06007D2C RID: 32044 RVA: 0x000EF590 File Offset: 0x000ED790
		[ProtoMember(5, IsRequired = false, Name = "fighting", DataFormat = DataFormat.TwosComplement)]
		public uint fighting
		{
			get
			{
				return this._fighting ?? 0U;
			}
			set
			{
				this._fighting = new uint?(value);
			}
		}

		// Token: 0x170027AF RID: 10159
		// (get) Token: 0x06007D2D RID: 32045 RVA: 0x000EF5A0 File Offset: 0x000ED7A0
		// (set) Token: 0x06007D2E RID: 32046 RVA: 0x000EF5C0 File Offset: 0x000ED7C0
		[XmlIgnore]
		[Browsable(false)]
		public bool fightingSpecified
		{
			get
			{
				return this._fighting != null;
			}
			set
			{
				bool flag = value == (this._fighting == null);
				if (flag)
				{
					this._fighting = (value ? new uint?(this.fighting) : null);
				}
			}
		}

		// Token: 0x06007D2F RID: 32047 RVA: 0x000EF604 File Offset: 0x000ED804
		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		// Token: 0x06007D30 RID: 32048 RVA: 0x000EF61C File Offset: 0x000ED81C
		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		// Token: 0x170027B0 RID: 10160
		// (get) Token: 0x06007D31 RID: 32049 RVA: 0x000EF628 File Offset: 0x000ED828
		// (set) Token: 0x06007D32 RID: 32050 RVA: 0x000EF654 File Offset: 0x000ED854
		[ProtoMember(6, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170027B1 RID: 10161
		// (get) Token: 0x06007D33 RID: 32051 RVA: 0x000EF664 File Offset: 0x000ED864
		// (set) Token: 0x06007D34 RID: 32052 RVA: 0x000EF684 File Offset: 0x000ED884
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06007D35 RID: 32053 RVA: 0x000EF6C8 File Offset: 0x000ED8C8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007D36 RID: 32054 RVA: 0x000EF6E0 File Offset: 0x000ED8E0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170027B2 RID: 10162
		// (get) Token: 0x06007D37 RID: 32055 RVA: 0x000EF6EC File Offset: 0x000ED8EC
		// (set) Token: 0x06007D38 RID: 32056 RVA: 0x000EF718 File Offset: 0x000ED918
		[ProtoMember(7, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170027B3 RID: 10163
		// (get) Token: 0x06007D39 RID: 32057 RVA: 0x000EF728 File Offset: 0x000ED928
		// (set) Token: 0x06007D3A RID: 32058 RVA: 0x000EF748 File Offset: 0x000ED948
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007D3B RID: 32059 RVA: 0x000EF78C File Offset: 0x000ED98C
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007D3C RID: 32060 RVA: 0x000EF7A4 File Offset: 0x000ED9A4
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170027B4 RID: 10164
		// (get) Token: 0x06007D3D RID: 32061 RVA: 0x000EF7B0 File Offset: 0x000ED9B0
		// (set) Token: 0x06007D3E RID: 32062 RVA: 0x000EF7DC File Offset: 0x000ED9DC
		[ProtoMember(8, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x170027B5 RID: 10165
		// (get) Token: 0x06007D3F RID: 32063 RVA: 0x000EF7EC File Offset: 0x000ED9EC
		// (set) Token: 0x06007D40 RID: 32064 RVA: 0x000EF80C File Offset: 0x000EDA0C
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
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06007D41 RID: 32065 RVA: 0x000EF850 File Offset: 0x000EDA50
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007D42 RID: 32066 RVA: 0x000EF868 File Offset: 0x000EDA68
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170027B6 RID: 10166
		// (get) Token: 0x06007D43 RID: 32067 RVA: 0x000EF874 File Offset: 0x000EDA74
		// (set) Token: 0x06007D44 RID: 32068 RVA: 0x000EF8A0 File Offset: 0x000EDAA0
		[ProtoMember(9, IsRequired = false, Name = "issuetime", DataFormat = DataFormat.TwosComplement)]
		public uint issuetime
		{
			get
			{
				return this._issuetime ?? 0U;
			}
			set
			{
				this._issuetime = new uint?(value);
			}
		}

		// Token: 0x170027B7 RID: 10167
		// (get) Token: 0x06007D45 RID: 32069 RVA: 0x000EF8B0 File Offset: 0x000EDAB0
		// (set) Token: 0x06007D46 RID: 32070 RVA: 0x000EF8D0 File Offset: 0x000EDAD0
		[XmlIgnore]
		[Browsable(false)]
		public bool issuetimeSpecified
		{
			get
			{
				return this._issuetime != null;
			}
			set
			{
				bool flag = value == (this._issuetime == null);
				if (flag)
				{
					this._issuetime = (value ? new uint?(this.issuetime) : null);
				}
			}
		}

		// Token: 0x06007D47 RID: 32071 RVA: 0x000EF914 File Offset: 0x000EDB14
		private bool ShouldSerializeissuetime()
		{
			return this.issuetimeSpecified;
		}

		// Token: 0x06007D48 RID: 32072 RVA: 0x000EF92C File Offset: 0x000EDB2C
		private void Resetissuetime()
		{
			this.issuetimeSpecified = false;
		}

		// Token: 0x170027B8 RID: 10168
		// (get) Token: 0x06007D49 RID: 32073 RVA: 0x000EF938 File Offset: 0x000EDB38
		// (set) Token: 0x06007D4A RID: 32074 RVA: 0x000EF965 File Offset: 0x000EDB65
		[ProtoMember(10, IsRequired = false, Name = "leaderroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderroleid
		{
			get
			{
				return this._leaderroleid ?? 0UL;
			}
			set
			{
				this._leaderroleid = new ulong?(value);
			}
		}

		// Token: 0x170027B9 RID: 10169
		// (get) Token: 0x06007D4B RID: 32075 RVA: 0x000EF974 File Offset: 0x000EDB74
		// (set) Token: 0x06007D4C RID: 32076 RVA: 0x000EF994 File Offset: 0x000EDB94
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderroleidSpecified
		{
			get
			{
				return this._leaderroleid != null;
			}
			set
			{
				bool flag = value == (this._leaderroleid == null);
				if (flag)
				{
					this._leaderroleid = (value ? new ulong?(this.leaderroleid) : null);
				}
			}
		}

		// Token: 0x06007D4D RID: 32077 RVA: 0x000EF9D8 File Offset: 0x000EDBD8
		private bool ShouldSerializeleaderroleid()
		{
			return this.leaderroleidSpecified;
		}

		// Token: 0x06007D4E RID: 32078 RVA: 0x000EF9F0 File Offset: 0x000EDBF0
		private void Resetleaderroleid()
		{
			this.leaderroleidSpecified = false;
		}

		// Token: 0x170027BA RID: 10170
		// (get) Token: 0x06007D4F RID: 32079 RVA: 0x000EF9FC File Offset: 0x000EDBFC
		// (set) Token: 0x06007D50 RID: 32080 RVA: 0x000EFA28 File Offset: 0x000EDC28
		[ProtoMember(11, IsRequired = false, Name = "isselfingroup", DataFormat = DataFormat.Default)]
		public bool isselfingroup
		{
			get
			{
				return this._isselfingroup ?? false;
			}
			set
			{
				this._isselfingroup = new bool?(value);
			}
		}

		// Token: 0x170027BB RID: 10171
		// (get) Token: 0x06007D51 RID: 32081 RVA: 0x000EFA38 File Offset: 0x000EDC38
		// (set) Token: 0x06007D52 RID: 32082 RVA: 0x000EFA58 File Offset: 0x000EDC58
		[XmlIgnore]
		[Browsable(false)]
		public bool isselfingroupSpecified
		{
			get
			{
				return this._isselfingroup != null;
			}
			set
			{
				bool flag = value == (this._isselfingroup == null);
				if (flag)
				{
					this._isselfingroup = (value ? new bool?(this.isselfingroup) : null);
				}
			}
		}

		// Token: 0x06007D53 RID: 32083 RVA: 0x000EFA9C File Offset: 0x000EDC9C
		private bool ShouldSerializeisselfingroup()
		{
			return this.isselfingroupSpecified;
		}

		// Token: 0x06007D54 RID: 32084 RVA: 0x000EFAB4 File Offset: 0x000EDCB4
		private void Resetisselfingroup()
		{
			this.isselfingroupSpecified = false;
		}

		// Token: 0x06007D55 RID: 32085 RVA: 0x000EFAC0 File Offset: 0x000EDCC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D70 RID: 7536
		private ulong? _groupchatID;

		// Token: 0x04001D71 RID: 7537
		private string _groupchatName;

		// Token: 0x04001D72 RID: 7538
		private ulong? _issueIndex;

		// Token: 0x04001D73 RID: 7539
		private uint? _stageID;

		// Token: 0x04001D74 RID: 7540
		private uint? _fighting;

		// Token: 0x04001D75 RID: 7541
		private uint? _type;

		// Token: 0x04001D76 RID: 7542
		private uint? _time;

		// Token: 0x04001D77 RID: 7543
		private uint? _state;

		// Token: 0x04001D78 RID: 7544
		private uint? _issuetime;

		// Token: 0x04001D79 RID: 7545
		private ulong? _leaderroleid;

		// Token: 0x04001D7A RID: 7546
		private bool? _isselfingroup;

		// Token: 0x04001D7B RID: 7547
		private IExtension extensionObject;
	}
}
