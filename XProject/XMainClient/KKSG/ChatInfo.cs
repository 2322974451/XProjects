using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059F RID: 1439
	[ProtoContract(Name = "ChatInfo")]
	[Serializable]
	public class ChatInfo : IExtensible
	{
		// Token: 0x170017E0 RID: 6112
		// (get) Token: 0x06004D79 RID: 19833 RVA: 0x000936D4 File Offset: 0x000918D4
		// (set) Token: 0x06004D7A RID: 19834 RVA: 0x00093700 File Offset: 0x00091900
		[ProtoMember(1, IsRequired = false, Name = "channel", DataFormat = DataFormat.TwosComplement)]
		public uint channel
		{
			get
			{
				return this._channel ?? 0U;
			}
			set
			{
				this._channel = new uint?(value);
			}
		}

		// Token: 0x170017E1 RID: 6113
		// (get) Token: 0x06004D7B RID: 19835 RVA: 0x00093710 File Offset: 0x00091910
		// (set) Token: 0x06004D7C RID: 19836 RVA: 0x00093730 File Offset: 0x00091930
		[XmlIgnore]
		[Browsable(false)]
		public bool channelSpecified
		{
			get
			{
				return this._channel != null;
			}
			set
			{
				bool flag = value == (this._channel == null);
				if (flag)
				{
					this._channel = (value ? new uint?(this.channel) : null);
				}
			}
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x00093774 File Offset: 0x00091974
		private bool ShouldSerializechannel()
		{
			return this.channelSpecified;
		}

		// Token: 0x06004D7E RID: 19838 RVA: 0x0009378C File Offset: 0x0009198C
		private void Resetchannel()
		{
			this.channelSpecified = false;
		}

		// Token: 0x170017E2 RID: 6114
		// (get) Token: 0x06004D7F RID: 19839 RVA: 0x00093798 File Offset: 0x00091998
		// (set) Token: 0x06004D80 RID: 19840 RVA: 0x000937B0 File Offset: 0x000919B0
		[ProtoMember(2, IsRequired = false, Name = "source", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatSource source
		{
			get
			{
				return this._source;
			}
			set
			{
				this._source = value;
			}
		}

		// Token: 0x170017E3 RID: 6115
		// (get) Token: 0x06004D81 RID: 19841 RVA: 0x000937BC File Offset: 0x000919BC
		// (set) Token: 0x06004D82 RID: 19842 RVA: 0x000937D4 File Offset: 0x000919D4
		[ProtoMember(3, IsRequired = false, Name = "dest", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatDest dest
		{
			get
			{
				return this._dest;
			}
			set
			{
				this._dest = value;
			}
		}

		// Token: 0x170017E4 RID: 6116
		// (get) Token: 0x06004D83 RID: 19843 RVA: 0x000937E0 File Offset: 0x000919E0
		// (set) Token: 0x06004D84 RID: 19844 RVA: 0x00093801 File Offset: 0x00091A01
		[ProtoMember(4, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		public string info
		{
			get
			{
				return this._info ?? "";
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x170017E5 RID: 6117
		// (get) Token: 0x06004D85 RID: 19845 RVA: 0x0009380C File Offset: 0x00091A0C
		// (set) Token: 0x06004D86 RID: 19846 RVA: 0x00093828 File Offset: 0x00091A28
		[XmlIgnore]
		[Browsable(false)]
		public bool infoSpecified
		{
			get
			{
				return this._info != null;
			}
			set
			{
				bool flag = value == (this._info == null);
				if (flag)
				{
					this._info = (value ? this.info : null);
				}
			}
		}

		// Token: 0x06004D87 RID: 19847 RVA: 0x00093858 File Offset: 0x00091A58
		private bool ShouldSerializeinfo()
		{
			return this.infoSpecified;
		}

		// Token: 0x06004D88 RID: 19848 RVA: 0x00093870 File Offset: 0x00091A70
		private void Resetinfo()
		{
			this.infoSpecified = false;
		}

		// Token: 0x170017E6 RID: 6118
		// (get) Token: 0x06004D89 RID: 19849 RVA: 0x0009387C File Offset: 0x00091A7C
		[ProtoMember(5, Name = "param", DataFormat = DataFormat.Default)]
		public List<ChatParam> param
		{
			get
			{
				return this._param;
			}
		}

		// Token: 0x170017E7 RID: 6119
		// (get) Token: 0x06004D8A RID: 19850 RVA: 0x00093894 File Offset: 0x00091A94
		// (set) Token: 0x06004D8B RID: 19851 RVA: 0x000938C0 File Offset: 0x00091AC0
		[ProtoMember(6, IsRequired = false, Name = "priority", DataFormat = DataFormat.TwosComplement)]
		public uint priority
		{
			get
			{
				return this._priority ?? 0U;
			}
			set
			{
				this._priority = new uint?(value);
			}
		}

		// Token: 0x170017E8 RID: 6120
		// (get) Token: 0x06004D8C RID: 19852 RVA: 0x000938D0 File Offset: 0x00091AD0
		// (set) Token: 0x06004D8D RID: 19853 RVA: 0x000938F0 File Offset: 0x00091AF0
		[XmlIgnore]
		[Browsable(false)]
		public bool prioritySpecified
		{
			get
			{
				return this._priority != null;
			}
			set
			{
				bool flag = value == (this._priority == null);
				if (flag)
				{
					this._priority = (value ? new uint?(this.priority) : null);
				}
			}
		}

		// Token: 0x06004D8E RID: 19854 RVA: 0x00093934 File Offset: 0x00091B34
		private bool ShouldSerializepriority()
		{
			return this.prioritySpecified;
		}

		// Token: 0x06004D8F RID: 19855 RVA: 0x0009394C File Offset: 0x00091B4C
		private void Resetpriority()
		{
			this.prioritySpecified = false;
		}

		// Token: 0x170017E9 RID: 6121
		// (get) Token: 0x06004D90 RID: 19856 RVA: 0x00093958 File Offset: 0x00091B58
		// (set) Token: 0x06004D91 RID: 19857 RVA: 0x00093984 File Offset: 0x00091B84
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

		// Token: 0x170017EA RID: 6122
		// (get) Token: 0x06004D92 RID: 19858 RVA: 0x00093994 File Offset: 0x00091B94
		// (set) Token: 0x06004D93 RID: 19859 RVA: 0x000939B4 File Offset: 0x00091BB4
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

		// Token: 0x06004D94 RID: 19860 RVA: 0x000939F8 File Offset: 0x00091BF8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06004D95 RID: 19861 RVA: 0x00093A10 File Offset: 0x00091C10
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170017EB RID: 6123
		// (get) Token: 0x06004D96 RID: 19862 RVA: 0x00093A1C File Offset: 0x00091C1C
		// (set) Token: 0x06004D97 RID: 19863 RVA: 0x00093A48 File Offset: 0x00091C48
		[ProtoMember(8, IsRequired = false, Name = "issystem", DataFormat = DataFormat.Default)]
		public bool issystem
		{
			get
			{
				return this._issystem ?? false;
			}
			set
			{
				this._issystem = new bool?(value);
			}
		}

		// Token: 0x170017EC RID: 6124
		// (get) Token: 0x06004D98 RID: 19864 RVA: 0x00093A58 File Offset: 0x00091C58
		// (set) Token: 0x06004D99 RID: 19865 RVA: 0x00093A78 File Offset: 0x00091C78
		[XmlIgnore]
		[Browsable(false)]
		public bool issystemSpecified
		{
			get
			{
				return this._issystem != null;
			}
			set
			{
				bool flag = value == (this._issystem == null);
				if (flag)
				{
					this._issystem = (value ? new bool?(this.issystem) : null);
				}
			}
		}

		// Token: 0x06004D9A RID: 19866 RVA: 0x00093ABC File Offset: 0x00091CBC
		private bool ShouldSerializeissystem()
		{
			return this.issystemSpecified;
		}

		// Token: 0x06004D9B RID: 19867 RVA: 0x00093AD4 File Offset: 0x00091CD4
		private void Resetissystem()
		{
			this.issystemSpecified = false;
		}

		// Token: 0x170017ED RID: 6125
		// (get) Token: 0x06004D9C RID: 19868 RVA: 0x00093AE0 File Offset: 0x00091CE0
		// (set) Token: 0x06004D9D RID: 19869 RVA: 0x00093B0D File Offset: 0x00091D0D
		[ProtoMember(9, IsRequired = false, Name = "storeKeyId", DataFormat = DataFormat.TwosComplement)]
		public ulong storeKeyId
		{
			get
			{
				return this._storeKeyId ?? 0UL;
			}
			set
			{
				this._storeKeyId = new ulong?(value);
			}
		}

		// Token: 0x170017EE RID: 6126
		// (get) Token: 0x06004D9E RID: 19870 RVA: 0x00093B1C File Offset: 0x00091D1C
		// (set) Token: 0x06004D9F RID: 19871 RVA: 0x00093B3C File Offset: 0x00091D3C
		[XmlIgnore]
		[Browsable(false)]
		public bool storeKeyIdSpecified
		{
			get
			{
				return this._storeKeyId != null;
			}
			set
			{
				bool flag = value == (this._storeKeyId == null);
				if (flag)
				{
					this._storeKeyId = (value ? new ulong?(this.storeKeyId) : null);
				}
			}
		}

		// Token: 0x06004DA0 RID: 19872 RVA: 0x00093B80 File Offset: 0x00091D80
		private bool ShouldSerializestoreKeyId()
		{
			return this.storeKeyIdSpecified;
		}

		// Token: 0x06004DA1 RID: 19873 RVA: 0x00093B98 File Offset: 0x00091D98
		private void ResetstoreKeyId()
		{
			this.storeKeyIdSpecified = false;
		}

		// Token: 0x170017EF RID: 6127
		// (get) Token: 0x06004DA2 RID: 19874 RVA: 0x00093BA4 File Offset: 0x00091DA4
		// (set) Token: 0x06004DA3 RID: 19875 RVA: 0x00093BD1 File Offset: 0x00091DD1
		[ProtoMember(10, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		// Token: 0x170017F0 RID: 6128
		// (get) Token: 0x06004DA4 RID: 19876 RVA: 0x00093BE0 File Offset: 0x00091DE0
		// (set) Token: 0x06004DA5 RID: 19877 RVA: 0x00093C00 File Offset: 0x00091E00
		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		// Token: 0x06004DA6 RID: 19878 RVA: 0x00093C44 File Offset: 0x00091E44
		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		// Token: 0x06004DA7 RID: 19879 RVA: 0x00093C5C File Offset: 0x00091E5C
		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		// Token: 0x170017F1 RID: 6129
		// (get) Token: 0x06004DA8 RID: 19880 RVA: 0x00093C68 File Offset: 0x00091E68
		// (set) Token: 0x06004DA9 RID: 19881 RVA: 0x00093C94 File Offset: 0x00091E94
		[ProtoMember(11, IsRequired = false, Name = "audioLen", DataFormat = DataFormat.TwosComplement)]
		public uint audioLen
		{
			get
			{
				return this._audioLen ?? 0U;
			}
			set
			{
				this._audioLen = new uint?(value);
			}
		}

		// Token: 0x170017F2 RID: 6130
		// (get) Token: 0x06004DAA RID: 19882 RVA: 0x00093CA4 File Offset: 0x00091EA4
		// (set) Token: 0x06004DAB RID: 19883 RVA: 0x00093CC4 File Offset: 0x00091EC4
		[XmlIgnore]
		[Browsable(false)]
		public bool audioLenSpecified
		{
			get
			{
				return this._audioLen != null;
			}
			set
			{
				bool flag = value == (this._audioLen == null);
				if (flag)
				{
					this._audioLen = (value ? new uint?(this.audioLen) : null);
				}
			}
		}

		// Token: 0x06004DAC RID: 19884 RVA: 0x00093D08 File Offset: 0x00091F08
		private bool ShouldSerializeaudioLen()
		{
			return this.audioLenSpecified;
		}

		// Token: 0x06004DAD RID: 19885 RVA: 0x00093D20 File Offset: 0x00091F20
		private void ResetaudioLen()
		{
			this.audioLenSpecified = false;
		}

		// Token: 0x170017F3 RID: 6131
		// (get) Token: 0x06004DAE RID: 19886 RVA: 0x00093D2C File Offset: 0x00091F2C
		[ProtoMember(12, Name = "destList", DataFormat = DataFormat.Default)]
		public List<ChatSource> destList
		{
			get
			{
				return this._destList;
			}
		}

		// Token: 0x170017F4 RID: 6132
		// (get) Token: 0x06004DAF RID: 19887 RVA: 0x00093D44 File Offset: 0x00091F44
		// (set) Token: 0x06004DB0 RID: 19888 RVA: 0x00093D70 File Offset: 0x00091F70
		[ProtoMember(13, IsRequired = false, Name = "isbroadcast", DataFormat = DataFormat.Default)]
		public bool isbroadcast
		{
			get
			{
				return this._isbroadcast ?? false;
			}
			set
			{
				this._isbroadcast = new bool?(value);
			}
		}

		// Token: 0x170017F5 RID: 6133
		// (get) Token: 0x06004DB1 RID: 19889 RVA: 0x00093D80 File Offset: 0x00091F80
		// (set) Token: 0x06004DB2 RID: 19890 RVA: 0x00093DA0 File Offset: 0x00091FA0
		[XmlIgnore]
		[Browsable(false)]
		public bool isbroadcastSpecified
		{
			get
			{
				return this._isbroadcast != null;
			}
			set
			{
				bool flag = value == (this._isbroadcast == null);
				if (flag)
				{
					this._isbroadcast = (value ? new bool?(this.isbroadcast) : null);
				}
			}
		}

		// Token: 0x06004DB3 RID: 19891 RVA: 0x00093DE4 File Offset: 0x00091FE4
		private bool ShouldSerializeisbroadcast()
		{
			return this.isbroadcastSpecified;
		}

		// Token: 0x06004DB4 RID: 19892 RVA: 0x00093DFC File Offset: 0x00091FFC
		private void Resetisbroadcast()
		{
			this.isbroadcastSpecified = false;
		}

		// Token: 0x170017F6 RID: 6134
		// (get) Token: 0x06004DB5 RID: 19893 RVA: 0x00093E08 File Offset: 0x00092008
		// (set) Token: 0x06004DB6 RID: 19894 RVA: 0x00093E34 File Offset: 0x00092034
		[ProtoMember(14, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170017F7 RID: 6135
		// (get) Token: 0x06004DB7 RID: 19895 RVA: 0x00093E44 File Offset: 0x00092044
		// (set) Token: 0x06004DB8 RID: 19896 RVA: 0x00093E64 File Offset: 0x00092064
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

		// Token: 0x06004DB9 RID: 19897 RVA: 0x00093EA8 File Offset: 0x000920A8
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004DBA RID: 19898 RVA: 0x00093EC0 File Offset: 0x000920C0
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170017F8 RID: 6136
		// (get) Token: 0x06004DBB RID: 19899 RVA: 0x00093ECC File Offset: 0x000920CC
		// (set) Token: 0x06004DBC RID: 19900 RVA: 0x00093EF8 File Offset: 0x000920F8
		[ProtoMember(15, IsRequired = false, Name = "isRecruit", DataFormat = DataFormat.Default)]
		public bool isRecruit
		{
			get
			{
				return this._isRecruit ?? false;
			}
			set
			{
				this._isRecruit = new bool?(value);
			}
		}

		// Token: 0x170017F9 RID: 6137
		// (get) Token: 0x06004DBD RID: 19901 RVA: 0x00093F08 File Offset: 0x00092108
		// (set) Token: 0x06004DBE RID: 19902 RVA: 0x00093F28 File Offset: 0x00092128
		[XmlIgnore]
		[Browsable(false)]
		public bool isRecruitSpecified
		{
			get
			{
				return this._isRecruit != null;
			}
			set
			{
				bool flag = value == (this._isRecruit == null);
				if (flag)
				{
					this._isRecruit = (value ? new bool?(this.isRecruit) : null);
				}
			}
		}

		// Token: 0x06004DBF RID: 19903 RVA: 0x00093F6C File Offset: 0x0009216C
		private bool ShouldSerializeisRecruit()
		{
			return this.isRecruitSpecified;
		}

		// Token: 0x06004DC0 RID: 19904 RVA: 0x00093F84 File Offset: 0x00092184
		private void ResetisRecruit()
		{
			this.isRecruitSpecified = false;
		}

		// Token: 0x170017FA RID: 6138
		// (get) Token: 0x06004DC1 RID: 19905 RVA: 0x00093F90 File Offset: 0x00092190
		// (set) Token: 0x06004DC2 RID: 19906 RVA: 0x00093FBC File Offset: 0x000921BC
		[ProtoMember(16, IsRequired = false, Name = "isDragonGuildRecruit", DataFormat = DataFormat.Default)]
		public bool isDragonGuildRecruit
		{
			get
			{
				return this._isDragonGuildRecruit ?? false;
			}
			set
			{
				this._isDragonGuildRecruit = new bool?(value);
			}
		}

		// Token: 0x170017FB RID: 6139
		// (get) Token: 0x06004DC3 RID: 19907 RVA: 0x00093FCC File Offset: 0x000921CC
		// (set) Token: 0x06004DC4 RID: 19908 RVA: 0x00093FEC File Offset: 0x000921EC
		[XmlIgnore]
		[Browsable(false)]
		public bool isDragonGuildRecruitSpecified
		{
			get
			{
				return this._isDragonGuildRecruit != null;
			}
			set
			{
				bool flag = value == (this._isDragonGuildRecruit == null);
				if (flag)
				{
					this._isDragonGuildRecruit = (value ? new bool?(this.isDragonGuildRecruit) : null);
				}
			}
		}

		// Token: 0x06004DC5 RID: 19909 RVA: 0x00094030 File Offset: 0x00092230
		private bool ShouldSerializeisDragonGuildRecruit()
		{
			return this.isDragonGuildRecruitSpecified;
		}

		// Token: 0x06004DC6 RID: 19910 RVA: 0x00094048 File Offset: 0x00092248
		private void ResetisDragonGuildRecruit()
		{
			this.isDragonGuildRecruitSpecified = false;
		}

		// Token: 0x170017FC RID: 6140
		// (get) Token: 0x06004DC7 RID: 19911 RVA: 0x00094054 File Offset: 0x00092254
		// (set) Token: 0x06004DC8 RID: 19912 RVA: 0x0009406C File Offset: 0x0009226C
		[ProtoMember(17, IsRequired = false, Name = "groupchatinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GroupChatTeamInfo groupchatinfo
		{
			get
			{
				return this._groupchatinfo;
			}
			set
			{
				this._groupchatinfo = value;
			}
		}

		// Token: 0x170017FD RID: 6141
		// (get) Token: 0x06004DC9 RID: 19913 RVA: 0x00094078 File Offset: 0x00092278
		// (set) Token: 0x06004DCA RID: 19914 RVA: 0x00094090 File Offset: 0x00092290
		[ProtoMember(18, IsRequired = false, Name = "groupchatnewrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatSource groupchatnewrole
		{
			get
			{
				return this._groupchatnewrole;
			}
			set
			{
				this._groupchatnewrole = value;
			}
		}

		// Token: 0x06004DCB RID: 19915 RVA: 0x0009409C File Offset: 0x0009229C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400132B RID: 4907
		private uint? _channel;

		// Token: 0x0400132C RID: 4908
		private ChatSource _source = null;

		// Token: 0x0400132D RID: 4909
		private ChatDest _dest = null;

		// Token: 0x0400132E RID: 4910
		private string _info;

		// Token: 0x0400132F RID: 4911
		private readonly List<ChatParam> _param = new List<ChatParam>();

		// Token: 0x04001330 RID: 4912
		private uint? _priority;

		// Token: 0x04001331 RID: 4913
		private uint? _time;

		// Token: 0x04001332 RID: 4914
		private bool? _issystem;

		// Token: 0x04001333 RID: 4915
		private ulong? _storeKeyId;

		// Token: 0x04001334 RID: 4916
		private ulong? _audioUid;

		// Token: 0x04001335 RID: 4917
		private uint? _audioLen;

		// Token: 0x04001336 RID: 4918
		private readonly List<ChatSource> _destList = new List<ChatSource>();

		// Token: 0x04001337 RID: 4919
		private bool? _isbroadcast;

		// Token: 0x04001338 RID: 4920
		private uint? _level;

		// Token: 0x04001339 RID: 4921
		private bool? _isRecruit;

		// Token: 0x0400133A RID: 4922
		private bool? _isDragonGuildRecruit;

		// Token: 0x0400133B RID: 4923
		private GroupChatTeamInfo _groupchatinfo = null;

		// Token: 0x0400133C RID: 4924
		private ChatSource _groupchatnewrole = null;

		// Token: 0x0400133D RID: 4925
		private IExtension extensionObject;
	}
}
