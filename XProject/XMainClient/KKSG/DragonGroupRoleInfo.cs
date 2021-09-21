using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000674 RID: 1652
	[ProtoContract(Name = "DragonGroupRoleInfo")]
	[Serializable]
	public class DragonGroupRoleInfo : IExtensible
	{
		// Token: 0x1700214C RID: 8524
		// (get) Token: 0x06006949 RID: 26953 RVA: 0x000C9498 File Offset: 0x000C7698
		// (set) Token: 0x0600694A RID: 26954 RVA: 0x000C94C5 File Offset: 0x000C76C5
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

		// Token: 0x1700214D RID: 8525
		// (get) Token: 0x0600694B RID: 26955 RVA: 0x000C94D4 File Offset: 0x000C76D4
		// (set) Token: 0x0600694C RID: 26956 RVA: 0x000C94F4 File Offset: 0x000C76F4
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

		// Token: 0x0600694D RID: 26957 RVA: 0x000C9538 File Offset: 0x000C7738
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600694E RID: 26958 RVA: 0x000C9550 File Offset: 0x000C7750
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700214E RID: 8526
		// (get) Token: 0x0600694F RID: 26959 RVA: 0x000C955C File Offset: 0x000C775C
		// (set) Token: 0x06006950 RID: 26960 RVA: 0x000C957D File Offset: 0x000C777D
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

		// Token: 0x1700214F RID: 8527
		// (get) Token: 0x06006951 RID: 26961 RVA: 0x000C9588 File Offset: 0x000C7788
		// (set) Token: 0x06006952 RID: 26962 RVA: 0x000C95A4 File Offset: 0x000C77A4
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

		// Token: 0x06006953 RID: 26963 RVA: 0x000C95D4 File Offset: 0x000C77D4
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06006954 RID: 26964 RVA: 0x000C95EC File Offset: 0x000C77EC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17002150 RID: 8528
		// (get) Token: 0x06006955 RID: 26965 RVA: 0x000C95F8 File Offset: 0x000C77F8
		// (set) Token: 0x06006956 RID: 26966 RVA: 0x000C9624 File Offset: 0x000C7824
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17002151 RID: 8529
		// (get) Token: 0x06006957 RID: 26967 RVA: 0x000C9634 File Offset: 0x000C7834
		// (set) Token: 0x06006958 RID: 26968 RVA: 0x000C9654 File Offset: 0x000C7854
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
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06006959 RID: 26969 RVA: 0x000C9698 File Offset: 0x000C7898
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x0600695A RID: 26970 RVA: 0x000C96B0 File Offset: 0x000C78B0
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002152 RID: 8530
		// (get) Token: 0x0600695B RID: 26971 RVA: 0x000C96BC File Offset: 0x000C78BC
		// (set) Token: 0x0600695C RID: 26972 RVA: 0x000C96E8 File Offset: 0x000C78E8
		[ProtoMember(4, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
		public uint title
		{
			get
			{
				return this._title ?? 0U;
			}
			set
			{
				this._title = new uint?(value);
			}
		}

		// Token: 0x17002153 RID: 8531
		// (get) Token: 0x0600695D RID: 26973 RVA: 0x000C96F8 File Offset: 0x000C78F8
		// (set) Token: 0x0600695E RID: 26974 RVA: 0x000C9718 File Offset: 0x000C7918
		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? new uint?(this.title) : null);
				}
			}
		}

		// Token: 0x0600695F RID: 26975 RVA: 0x000C975C File Offset: 0x000C795C
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06006960 RID: 26976 RVA: 0x000C9774 File Offset: 0x000C7974
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x17002154 RID: 8532
		// (get) Token: 0x06006961 RID: 26977 RVA: 0x000C9780 File Offset: 0x000C7980
		// (set) Token: 0x06006962 RID: 26978 RVA: 0x000C97AC File Offset: 0x000C79AC
		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17002155 RID: 8533
		// (get) Token: 0x06006963 RID: 26979 RVA: 0x000C97BC File Offset: 0x000C79BC
		// (set) Token: 0x06006964 RID: 26980 RVA: 0x000C97DC File Offset: 0x000C79DC
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
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06006965 RID: 26981 RVA: 0x000C9820 File Offset: 0x000C7A20
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06006966 RID: 26982 RVA: 0x000C9838 File Offset: 0x000C7A38
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002156 RID: 8534
		// (get) Token: 0x06006967 RID: 26983 RVA: 0x000C9844 File Offset: 0x000C7A44
		// (set) Token: 0x06006968 RID: 26984 RVA: 0x000C9870 File Offset: 0x000C7A70
		[ProtoMember(6, IsRequired = false, Name = "fighting", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002157 RID: 8535
		// (get) Token: 0x06006969 RID: 26985 RVA: 0x000C9880 File Offset: 0x000C7A80
		// (set) Token: 0x0600696A RID: 26986 RVA: 0x000C98A0 File Offset: 0x000C7AA0
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

		// Token: 0x0600696B RID: 26987 RVA: 0x000C98E4 File Offset: 0x000C7AE4
		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		// Token: 0x0600696C RID: 26988 RVA: 0x000C98FC File Offset: 0x000C7AFC
		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		// Token: 0x17002158 RID: 8536
		// (get) Token: 0x0600696D RID: 26989 RVA: 0x000C9908 File Offset: 0x000C7B08
		// (set) Token: 0x0600696E RID: 26990 RVA: 0x000C9929 File Offset: 0x000C7B29
		[ProtoMember(7, IsRequired = false, Name = "guild", DataFormat = DataFormat.Default)]
		public string guild
		{
			get
			{
				return this._guild ?? "";
			}
			set
			{
				this._guild = value;
			}
		}

		// Token: 0x17002159 RID: 8537
		// (get) Token: 0x0600696F RID: 26991 RVA: 0x000C9934 File Offset: 0x000C7B34
		// (set) Token: 0x06006970 RID: 26992 RVA: 0x000C9950 File Offset: 0x000C7B50
		[XmlIgnore]
		[Browsable(false)]
		public bool guildSpecified
		{
			get
			{
				return this._guild != null;
			}
			set
			{
				bool flag = value == (this._guild == null);
				if (flag)
				{
					this._guild = (value ? this.guild : null);
				}
			}
		}

		// Token: 0x06006971 RID: 26993 RVA: 0x000C9980 File Offset: 0x000C7B80
		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		// Token: 0x06006972 RID: 26994 RVA: 0x000C9998 File Offset: 0x000C7B98
		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		// Token: 0x1700215A RID: 8538
		// (get) Token: 0x06006973 RID: 26995 RVA: 0x000C99A4 File Offset: 0x000C7BA4
		// (set) Token: 0x06006974 RID: 26996 RVA: 0x000C99D0 File Offset: 0x000C7BD0
		[ProtoMember(8, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public uint uid
		{
			get
			{
				return this._uid ?? 0U;
			}
			set
			{
				this._uid = new uint?(value);
			}
		}

		// Token: 0x1700215B RID: 8539
		// (get) Token: 0x06006975 RID: 26997 RVA: 0x000C99E0 File Offset: 0x000C7BE0
		// (set) Token: 0x06006976 RID: 26998 RVA: 0x000C9A00 File Offset: 0x000C7C00
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new uint?(this.uid) : null);
				}
			}
		}

		// Token: 0x06006977 RID: 26999 RVA: 0x000C9A44 File Offset: 0x000C7C44
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06006978 RID: 27000 RVA: 0x000C9A5C File Offset: 0x000C7C5C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700215C RID: 8540
		// (get) Token: 0x06006979 RID: 27001 RVA: 0x000C9A68 File Offset: 0x000C7C68
		// (set) Token: 0x0600697A RID: 27002 RVA: 0x000C9A94 File Offset: 0x000C7C94
		[ProtoMember(9, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700215D RID: 8541
		// (get) Token: 0x0600697B RID: 27003 RVA: 0x000C9AA4 File Offset: 0x000C7CA4
		// (set) Token: 0x0600697C RID: 27004 RVA: 0x000C9AC4 File Offset: 0x000C7CC4
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

		// Token: 0x0600697D RID: 27005 RVA: 0x000C9B08 File Offset: 0x000C7D08
		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		// Token: 0x0600697E RID: 27006 RVA: 0x000C9B20 File Offset: 0x000C7D20
		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		// Token: 0x1700215E RID: 8542
		// (get) Token: 0x0600697F RID: 27007 RVA: 0x000C9B2C File Offset: 0x000C7D2C
		// (set) Token: 0x06006980 RID: 27008 RVA: 0x000C9B58 File Offset: 0x000C7D58
		[ProtoMember(10, IsRequired = false, Name = "stageTime", DataFormat = DataFormat.TwosComplement)]
		public uint stageTime
		{
			get
			{
				return this._stageTime ?? 0U;
			}
			set
			{
				this._stageTime = new uint?(value);
			}
		}

		// Token: 0x1700215F RID: 8543
		// (get) Token: 0x06006981 RID: 27009 RVA: 0x000C9B68 File Offset: 0x000C7D68
		// (set) Token: 0x06006982 RID: 27010 RVA: 0x000C9B88 File Offset: 0x000C7D88
		[XmlIgnore]
		[Browsable(false)]
		public bool stageTimeSpecified
		{
			get
			{
				return this._stageTime != null;
			}
			set
			{
				bool flag = value == (this._stageTime == null);
				if (flag)
				{
					this._stageTime = (value ? new uint?(this.stageTime) : null);
				}
			}
		}

		// Token: 0x06006983 RID: 27011 RVA: 0x000C9BCC File Offset: 0x000C7DCC
		private bool ShouldSerializestageTime()
		{
			return this.stageTimeSpecified;
		}

		// Token: 0x06006984 RID: 27012 RVA: 0x000C9BE4 File Offset: 0x000C7DE4
		private void ResetstageTime()
		{
			this.stageTimeSpecified = false;
		}

		// Token: 0x17002160 RID: 8544
		// (get) Token: 0x06006985 RID: 27013 RVA: 0x000C9BF0 File Offset: 0x000C7DF0
		// (set) Token: 0x06006986 RID: 27014 RVA: 0x000C9C1C File Offset: 0x000C7E1C
		[ProtoMember(11, IsRequired = false, Name = "stageCount", DataFormat = DataFormat.TwosComplement)]
		public uint stageCount
		{
			get
			{
				return this._stageCount ?? 0U;
			}
			set
			{
				this._stageCount = new uint?(value);
			}
		}

		// Token: 0x17002161 RID: 8545
		// (get) Token: 0x06006987 RID: 27015 RVA: 0x000C9C2C File Offset: 0x000C7E2C
		// (set) Token: 0x06006988 RID: 27016 RVA: 0x000C9C4C File Offset: 0x000C7E4C
		[XmlIgnore]
		[Browsable(false)]
		public bool stageCountSpecified
		{
			get
			{
				return this._stageCount != null;
			}
			set
			{
				bool flag = value == (this._stageCount == null);
				if (flag)
				{
					this._stageCount = (value ? new uint?(this.stageCount) : null);
				}
			}
		}

		// Token: 0x06006989 RID: 27017 RVA: 0x000C9C90 File Offset: 0x000C7E90
		private bool ShouldSerializestageCount()
		{
			return this.stageCountSpecified;
		}

		// Token: 0x0600698A RID: 27018 RVA: 0x000C9CA8 File Offset: 0x000C7EA8
		private void ResetstageCount()
		{
			this.stageCountSpecified = false;
		}

		// Token: 0x17002162 RID: 8546
		// (get) Token: 0x0600698B RID: 27019 RVA: 0x000C9CB4 File Offset: 0x000C7EB4
		// (set) Token: 0x0600698C RID: 27020 RVA: 0x000C9CCC File Offset: 0x000C7ECC
		[ProtoMember(12, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x0600698D RID: 27021 RVA: 0x000C9CD8 File Offset: 0x000C7ED8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001963 RID: 6499
		private ulong? _roleid;

		// Token: 0x04001964 RID: 6500
		private string _rolename;

		// Token: 0x04001965 RID: 6501
		private uint? _profession;

		// Token: 0x04001966 RID: 6502
		private uint? _title;

		// Token: 0x04001967 RID: 6503
		private uint? _level;

		// Token: 0x04001968 RID: 6504
		private uint? _fighting;

		// Token: 0x04001969 RID: 6505
		private string _guild;

		// Token: 0x0400196A RID: 6506
		private uint? _uid;

		// Token: 0x0400196B RID: 6507
		private uint? _stageID;

		// Token: 0x0400196C RID: 6508
		private uint? _stageTime;

		// Token: 0x0400196D RID: 6509
		private uint? _stageCount;

		// Token: 0x0400196E RID: 6510
		private PayConsume _pre = null;

		// Token: 0x0400196F RID: 6511
		private IExtension extensionObject;
	}
}
