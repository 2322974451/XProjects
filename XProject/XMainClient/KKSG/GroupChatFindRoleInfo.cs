using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000722 RID: 1826
	[ProtoContract(Name = "GroupChatFindRoleInfo")]
	[Serializable]
	public class GroupChatFindRoleInfo : IExtensible
	{
		// Token: 0x170027BC RID: 10172
		// (get) Token: 0x06007D57 RID: 32087 RVA: 0x000EFAE0 File Offset: 0x000EDCE0
		// (set) Token: 0x06007D58 RID: 32088 RVA: 0x000EFB0D File Offset: 0x000EDD0D
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170027BD RID: 10173
		// (get) Token: 0x06007D59 RID: 32089 RVA: 0x000EFB1C File Offset: 0x000EDD1C
		// (set) Token: 0x06007D5A RID: 32090 RVA: 0x000EFB3C File Offset: 0x000EDD3C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007D5B RID: 32091 RVA: 0x000EFB80 File Offset: 0x000EDD80
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007D5C RID: 32092 RVA: 0x000EFB98 File Offset: 0x000EDD98
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170027BE RID: 10174
		// (get) Token: 0x06007D5D RID: 32093 RVA: 0x000EFBA4 File Offset: 0x000EDDA4
		// (set) Token: 0x06007D5E RID: 32094 RVA: 0x000EFBC5 File Offset: 0x000EDDC5
		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x170027BF RID: 10175
		// (get) Token: 0x06007D5F RID: 32095 RVA: 0x000EFBD0 File Offset: 0x000EDDD0
		// (set) Token: 0x06007D60 RID: 32096 RVA: 0x000EFBEC File Offset: 0x000EDDEC
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06007D61 RID: 32097 RVA: 0x000EFC1C File Offset: 0x000EDE1C
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06007D62 RID: 32098 RVA: 0x000EFC34 File Offset: 0x000EDE34
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170027C0 RID: 10176
		// (get) Token: 0x06007D63 RID: 32099 RVA: 0x000EFC40 File Offset: 0x000EDE40
		// (set) Token: 0x06007D64 RID: 32100 RVA: 0x000EFC6D File Offset: 0x000EDE6D
		[ProtoMember(3, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027C1 RID: 10177
		// (get) Token: 0x06007D65 RID: 32101 RVA: 0x000EFC7C File Offset: 0x000EDE7C
		// (set) Token: 0x06007D66 RID: 32102 RVA: 0x000EFC9C File Offset: 0x000EDE9C
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

		// Token: 0x06007D67 RID: 32103 RVA: 0x000EFCE0 File Offset: 0x000EDEE0
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06007D68 RID: 32104 RVA: 0x000EFCF8 File Offset: 0x000EDEF8
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x170027C2 RID: 10178
		// (get) Token: 0x06007D69 RID: 32105 RVA: 0x000EFD04 File Offset: 0x000EDF04
		// (set) Token: 0x06007D6A RID: 32106 RVA: 0x000EFD25 File Offset: 0x000EDF25
		[ProtoMember(4, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
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

		// Token: 0x170027C3 RID: 10179
		// (get) Token: 0x06007D6B RID: 32107 RVA: 0x000EFD30 File Offset: 0x000EDF30
		// (set) Token: 0x06007D6C RID: 32108 RVA: 0x000EFD4C File Offset: 0x000EDF4C
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

		// Token: 0x06007D6D RID: 32109 RVA: 0x000EFD7C File Offset: 0x000EDF7C
		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		// Token: 0x06007D6E RID: 32110 RVA: 0x000EFD94 File Offset: 0x000EDF94
		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		// Token: 0x170027C4 RID: 10180
		// (get) Token: 0x06007D6F RID: 32111 RVA: 0x000EFDA0 File Offset: 0x000EDFA0
		// (set) Token: 0x06007D70 RID: 32112 RVA: 0x000EFDCD File Offset: 0x000EDFCD
		[ProtoMember(5, IsRequired = false, Name = "issueIndex", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027C5 RID: 10181
		// (get) Token: 0x06007D71 RID: 32113 RVA: 0x000EFDDC File Offset: 0x000EDFDC
		// (set) Token: 0x06007D72 RID: 32114 RVA: 0x000EFDFC File Offset: 0x000EDFFC
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

		// Token: 0x06007D73 RID: 32115 RVA: 0x000EFE40 File Offset: 0x000EE040
		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		// Token: 0x06007D74 RID: 32116 RVA: 0x000EFE58 File Offset: 0x000EE058
		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		// Token: 0x170027C6 RID: 10182
		// (get) Token: 0x06007D75 RID: 32117 RVA: 0x000EFE64 File Offset: 0x000EE064
		// (set) Token: 0x06007D76 RID: 32118 RVA: 0x000EFE90 File Offset: 0x000EE090
		[ProtoMember(6, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027C7 RID: 10183
		// (get) Token: 0x06007D77 RID: 32119 RVA: 0x000EFEA0 File Offset: 0x000EE0A0
		// (set) Token: 0x06007D78 RID: 32120 RVA: 0x000EFEC0 File Offset: 0x000EE0C0
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

		// Token: 0x06007D79 RID: 32121 RVA: 0x000EFF04 File Offset: 0x000EE104
		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		// Token: 0x06007D7A RID: 32122 RVA: 0x000EFF1C File Offset: 0x000EE11C
		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		// Token: 0x170027C8 RID: 10184
		// (get) Token: 0x06007D7B RID: 32123 RVA: 0x000EFF28 File Offset: 0x000EE128
		// (set) Token: 0x06007D7C RID: 32124 RVA: 0x000EFF54 File Offset: 0x000EE154
		[ProtoMember(7, IsRequired = false, Name = "fighting", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027C9 RID: 10185
		// (get) Token: 0x06007D7D RID: 32125 RVA: 0x000EFF64 File Offset: 0x000EE164
		// (set) Token: 0x06007D7E RID: 32126 RVA: 0x000EFF84 File Offset: 0x000EE184
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

		// Token: 0x06007D7F RID: 32127 RVA: 0x000EFFC8 File Offset: 0x000EE1C8
		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		// Token: 0x06007D80 RID: 32128 RVA: 0x000EFFE0 File Offset: 0x000EE1E0
		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		// Token: 0x170027CA RID: 10186
		// (get) Token: 0x06007D81 RID: 32129 RVA: 0x000EFFEC File Offset: 0x000EE1EC
		// (set) Token: 0x06007D82 RID: 32130 RVA: 0x000F0018 File Offset: 0x000EE218
		[ProtoMember(8, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027CB RID: 10187
		// (get) Token: 0x06007D83 RID: 32131 RVA: 0x000F0028 File Offset: 0x000EE228
		// (set) Token: 0x06007D84 RID: 32132 RVA: 0x000F0048 File Offset: 0x000EE248
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

		// Token: 0x06007D85 RID: 32133 RVA: 0x000F008C File Offset: 0x000EE28C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007D86 RID: 32134 RVA: 0x000F00A4 File Offset: 0x000EE2A4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170027CC RID: 10188
		// (get) Token: 0x06007D87 RID: 32135 RVA: 0x000F00B0 File Offset: 0x000EE2B0
		// (set) Token: 0x06007D88 RID: 32136 RVA: 0x000F00DC File Offset: 0x000EE2DC
		[ProtoMember(9, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027CD RID: 10189
		// (get) Token: 0x06007D89 RID: 32137 RVA: 0x000F00EC File Offset: 0x000EE2EC
		// (set) Token: 0x06007D8A RID: 32138 RVA: 0x000F010C File Offset: 0x000EE30C
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

		// Token: 0x06007D8B RID: 32139 RVA: 0x000F0150 File Offset: 0x000EE350
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007D8C RID: 32140 RVA: 0x000F0168 File Offset: 0x000EE368
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170027CE RID: 10190
		// (get) Token: 0x06007D8D RID: 32141 RVA: 0x000F0174 File Offset: 0x000EE374
		// (set) Token: 0x06007D8E RID: 32142 RVA: 0x000F01A0 File Offset: 0x000EE3A0
		[ProtoMember(10, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027CF RID: 10191
		// (get) Token: 0x06007D8F RID: 32143 RVA: 0x000F01B0 File Offset: 0x000EE3B0
		// (set) Token: 0x06007D90 RID: 32144 RVA: 0x000F01D0 File Offset: 0x000EE3D0
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

		// Token: 0x06007D91 RID: 32145 RVA: 0x000F0214 File Offset: 0x000EE414
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007D92 RID: 32146 RVA: 0x000F022C File Offset: 0x000EE42C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170027D0 RID: 10192
		// (get) Token: 0x06007D93 RID: 32147 RVA: 0x000F0238 File Offset: 0x000EE438
		// (set) Token: 0x06007D94 RID: 32148 RVA: 0x000F0264 File Offset: 0x000EE464
		[ProtoMember(11, IsRequired = false, Name = "issuetime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027D1 RID: 10193
		// (get) Token: 0x06007D95 RID: 32149 RVA: 0x000F0274 File Offset: 0x000EE474
		// (set) Token: 0x06007D96 RID: 32150 RVA: 0x000F0294 File Offset: 0x000EE494
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

		// Token: 0x06007D97 RID: 32151 RVA: 0x000F02D8 File Offset: 0x000EE4D8
		private bool ShouldSerializeissuetime()
		{
			return this.issuetimeSpecified;
		}

		// Token: 0x06007D98 RID: 32152 RVA: 0x000F02F0 File Offset: 0x000EE4F0
		private void Resetissuetime()
		{
			this.issuetimeSpecified = false;
		}

		// Token: 0x170027D2 RID: 10194
		// (get) Token: 0x06007D99 RID: 32153 RVA: 0x000F02FC File Offset: 0x000EE4FC
		// (set) Token: 0x06007D9A RID: 32154 RVA: 0x000F0328 File Offset: 0x000EE528
		[ProtoMember(12, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		// Token: 0x170027D3 RID: 10195
		// (get) Token: 0x06007D9B RID: 32155 RVA: 0x000F0338 File Offset: 0x000EE538
		// (set) Token: 0x06007D9C RID: 32156 RVA: 0x000F0358 File Offset: 0x000EE558
		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		// Token: 0x06007D9D RID: 32157 RVA: 0x000F039C File Offset: 0x000EE59C
		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		// Token: 0x06007D9E RID: 32158 RVA: 0x000F03B4 File Offset: 0x000EE5B4
		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		// Token: 0x06007D9F RID: 32159 RVA: 0x000F03C0 File Offset: 0x000EE5C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D7C RID: 7548
		private ulong? _roleid;

		// Token: 0x04001D7D RID: 7549
		private string _rolename;

		// Token: 0x04001D7E RID: 7550
		private ulong? _groupchatID;

		// Token: 0x04001D7F RID: 7551
		private string _groupchatName;

		// Token: 0x04001D80 RID: 7552
		private ulong? _issueIndex;

		// Token: 0x04001D81 RID: 7553
		private uint? _stageID;

		// Token: 0x04001D82 RID: 7554
		private uint? _fighting;

		// Token: 0x04001D83 RID: 7555
		private uint? _type;

		// Token: 0x04001D84 RID: 7556
		private uint? _time;

		// Token: 0x04001D85 RID: 7557
		private uint? _state;

		// Token: 0x04001D86 RID: 7558
		private uint? _issuetime;

		// Token: 0x04001D87 RID: 7559
		private uint? _roleprofession;

		// Token: 0x04001D88 RID: 7560
		private IExtension extensionObject;
	}
}
