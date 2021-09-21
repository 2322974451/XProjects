using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000723 RID: 1827
	[ProtoContract(Name = "GroupChatPlayerInfo")]
	[Serializable]
	public class GroupChatPlayerInfo : IExtensible
	{
		// Token: 0x170027D4 RID: 10196
		// (get) Token: 0x06007DA1 RID: 32161 RVA: 0x000F03E0 File Offset: 0x000EE5E0
		// (set) Token: 0x06007DA2 RID: 32162 RVA: 0x000F040D File Offset: 0x000EE60D
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

		// Token: 0x170027D5 RID: 10197
		// (get) Token: 0x06007DA3 RID: 32163 RVA: 0x000F041C File Offset: 0x000EE61C
		// (set) Token: 0x06007DA4 RID: 32164 RVA: 0x000F043C File Offset: 0x000EE63C
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

		// Token: 0x06007DA5 RID: 32165 RVA: 0x000F0480 File Offset: 0x000EE680
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007DA6 RID: 32166 RVA: 0x000F0498 File Offset: 0x000EE698
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170027D6 RID: 10198
		// (get) Token: 0x06007DA7 RID: 32167 RVA: 0x000F04A4 File Offset: 0x000EE6A4
		// (set) Token: 0x06007DA8 RID: 32168 RVA: 0x000F04C5 File Offset: 0x000EE6C5
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

		// Token: 0x170027D7 RID: 10199
		// (get) Token: 0x06007DA9 RID: 32169 RVA: 0x000F04D0 File Offset: 0x000EE6D0
		// (set) Token: 0x06007DAA RID: 32170 RVA: 0x000F04EC File Offset: 0x000EE6EC
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

		// Token: 0x06007DAB RID: 32171 RVA: 0x000F051C File Offset: 0x000EE71C
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06007DAC RID: 32172 RVA: 0x000F0534 File Offset: 0x000EE734
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170027D8 RID: 10200
		// (get) Token: 0x06007DAD RID: 32173 RVA: 0x000F0540 File Offset: 0x000EE740
		// (set) Token: 0x06007DAE RID: 32174 RVA: 0x000F056C File Offset: 0x000EE76C
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

		// Token: 0x170027D9 RID: 10201
		// (get) Token: 0x06007DAF RID: 32175 RVA: 0x000F057C File Offset: 0x000EE77C
		// (set) Token: 0x06007DB0 RID: 32176 RVA: 0x000F059C File Offset: 0x000EE79C
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

		// Token: 0x06007DB1 RID: 32177 RVA: 0x000F05E0 File Offset: 0x000EE7E0
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007DB2 RID: 32178 RVA: 0x000F05F8 File Offset: 0x000EE7F8
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170027DA RID: 10202
		// (get) Token: 0x06007DB3 RID: 32179 RVA: 0x000F0604 File Offset: 0x000EE804
		// (set) Token: 0x06007DB4 RID: 32180 RVA: 0x000F0630 File Offset: 0x000EE830
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

		// Token: 0x170027DB RID: 10203
		// (get) Token: 0x06007DB5 RID: 32181 RVA: 0x000F0640 File Offset: 0x000EE840
		// (set) Token: 0x06007DB6 RID: 32182 RVA: 0x000F0660 File Offset: 0x000EE860
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

		// Token: 0x06007DB7 RID: 32183 RVA: 0x000F06A4 File Offset: 0x000EE8A4
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06007DB8 RID: 32184 RVA: 0x000F06BC File Offset: 0x000EE8BC
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x170027DC RID: 10204
		// (get) Token: 0x06007DB9 RID: 32185 RVA: 0x000F06C8 File Offset: 0x000EE8C8
		// (set) Token: 0x06007DBA RID: 32186 RVA: 0x000F06F4 File Offset: 0x000EE8F4
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

		// Token: 0x170027DD RID: 10205
		// (get) Token: 0x06007DBB RID: 32187 RVA: 0x000F0704 File Offset: 0x000EE904
		// (set) Token: 0x06007DBC RID: 32188 RVA: 0x000F0724 File Offset: 0x000EE924
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

		// Token: 0x06007DBD RID: 32189 RVA: 0x000F0768 File Offset: 0x000EE968
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007DBE RID: 32190 RVA: 0x000F0780 File Offset: 0x000EE980
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170027DE RID: 10206
		// (get) Token: 0x06007DBF RID: 32191 RVA: 0x000F078C File Offset: 0x000EE98C
		// (set) Token: 0x06007DC0 RID: 32192 RVA: 0x000F07B8 File Offset: 0x000EE9B8
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

		// Token: 0x170027DF RID: 10207
		// (get) Token: 0x06007DC1 RID: 32193 RVA: 0x000F07C8 File Offset: 0x000EE9C8
		// (set) Token: 0x06007DC2 RID: 32194 RVA: 0x000F07E8 File Offset: 0x000EE9E8
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

		// Token: 0x06007DC3 RID: 32195 RVA: 0x000F082C File Offset: 0x000EEA2C
		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		// Token: 0x06007DC4 RID: 32196 RVA: 0x000F0844 File Offset: 0x000EEA44
		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		// Token: 0x170027E0 RID: 10208
		// (get) Token: 0x06007DC5 RID: 32197 RVA: 0x000F0850 File Offset: 0x000EEA50
		// (set) Token: 0x06007DC6 RID: 32198 RVA: 0x000F0871 File Offset: 0x000EEA71
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

		// Token: 0x170027E1 RID: 10209
		// (get) Token: 0x06007DC7 RID: 32199 RVA: 0x000F087C File Offset: 0x000EEA7C
		// (set) Token: 0x06007DC8 RID: 32200 RVA: 0x000F0898 File Offset: 0x000EEA98
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

		// Token: 0x06007DC9 RID: 32201 RVA: 0x000F08C8 File Offset: 0x000EEAC8
		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		// Token: 0x06007DCA RID: 32202 RVA: 0x000F08E0 File Offset: 0x000EEAE0
		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		// Token: 0x170027E2 RID: 10210
		// (get) Token: 0x06007DCB RID: 32203 RVA: 0x000F08EC File Offset: 0x000EEAEC
		// (set) Token: 0x06007DCC RID: 32204 RVA: 0x000F0918 File Offset: 0x000EEB18
		[ProtoMember(8, IsRequired = false, Name = "joingrouptime", DataFormat = DataFormat.TwosComplement)]
		public uint joingrouptime
		{
			get
			{
				return this._joingrouptime ?? 0U;
			}
			set
			{
				this._joingrouptime = new uint?(value);
			}
		}

		// Token: 0x170027E3 RID: 10211
		// (get) Token: 0x06007DCD RID: 32205 RVA: 0x000F0928 File Offset: 0x000EEB28
		// (set) Token: 0x06007DCE RID: 32206 RVA: 0x000F0948 File Offset: 0x000EEB48
		[XmlIgnore]
		[Browsable(false)]
		public bool joingrouptimeSpecified
		{
			get
			{
				return this._joingrouptime != null;
			}
			set
			{
				bool flag = value == (this._joingrouptime == null);
				if (flag)
				{
					this._joingrouptime = (value ? new uint?(this.joingrouptime) : null);
				}
			}
		}

		// Token: 0x06007DCF RID: 32207 RVA: 0x000F098C File Offset: 0x000EEB8C
		private bool ShouldSerializejoingrouptime()
		{
			return this.joingrouptimeSpecified;
		}

		// Token: 0x06007DD0 RID: 32208 RVA: 0x000F09A4 File Offset: 0x000EEBA4
		private void Resetjoingrouptime()
		{
			this.joingrouptimeSpecified = false;
		}

		// Token: 0x170027E4 RID: 10212
		// (get) Token: 0x06007DD1 RID: 32209 RVA: 0x000F09B0 File Offset: 0x000EEBB0
		// (set) Token: 0x06007DD2 RID: 32210 RVA: 0x000F09DC File Offset: 0x000EEBDC
		[ProtoMember(9, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170027E5 RID: 10213
		// (get) Token: 0x06007DD3 RID: 32211 RVA: 0x000F09EC File Offset: 0x000EEBEC
		// (set) Token: 0x06007DD4 RID: 32212 RVA: 0x000F0A0C File Offset: 0x000EEC0C
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

		// Token: 0x06007DD5 RID: 32213 RVA: 0x000F0A50 File Offset: 0x000EEC50
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007DD6 RID: 32214 RVA: 0x000F0A68 File Offset: 0x000EEC68
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06007DD7 RID: 32215 RVA: 0x000F0A74 File Offset: 0x000EEC74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D89 RID: 7561
		private ulong? _roleid;

		// Token: 0x04001D8A RID: 7562
		private string _rolename;

		// Token: 0x04001D8B RID: 7563
		private uint? _profession;

		// Token: 0x04001D8C RID: 7564
		private uint? _title;

		// Token: 0x04001D8D RID: 7565
		private uint? _level;

		// Token: 0x04001D8E RID: 7566
		private uint? _fighting;

		// Token: 0x04001D8F RID: 7567
		private string _guild;

		// Token: 0x04001D90 RID: 7568
		private uint? _joingrouptime;

		// Token: 0x04001D91 RID: 7569
		private uint? _uid;

		// Token: 0x04001D92 RID: 7570
		private IExtension extensionObject;
	}
}
