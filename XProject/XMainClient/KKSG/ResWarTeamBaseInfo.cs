using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C6 RID: 1734
	[ProtoContract(Name = "ResWarTeamBaseInfo")]
	[Serializable]
	public class ResWarTeamBaseInfo : IExtensible
	{
		// Token: 0x17002423 RID: 9251
		// (get) Token: 0x06007229 RID: 29225 RVA: 0x000DA6E4 File Offset: 0x000D88E4
		// (set) Token: 0x0600722A RID: 29226 RVA: 0x000DA710 File Offset: 0x000D8910
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x17002424 RID: 9252
		// (get) Token: 0x0600722B RID: 29227 RVA: 0x000DA720 File Offset: 0x000D8920
		// (set) Token: 0x0600722C RID: 29228 RVA: 0x000DA740 File Offset: 0x000D8940
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x0600722D RID: 29229 RVA: 0x000DA784 File Offset: 0x000D8984
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x0600722E RID: 29230 RVA: 0x000DA79C File Offset: 0x000D899C
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17002425 RID: 9253
		// (get) Token: 0x0600722F RID: 29231 RVA: 0x000DA7A8 File Offset: 0x000D89A8
		// (set) Token: 0x06007230 RID: 29232 RVA: 0x000DA7D5 File Offset: 0x000D89D5
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17002426 RID: 9254
		// (get) Token: 0x06007231 RID: 29233 RVA: 0x000DA7E4 File Offset: 0x000D89E4
		// (set) Token: 0x06007232 RID: 29234 RVA: 0x000DA804 File Offset: 0x000D8A04
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
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06007233 RID: 29235 RVA: 0x000DA848 File Offset: 0x000D8A48
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007234 RID: 29236 RVA: 0x000DA860 File Offset: 0x000D8A60
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002427 RID: 9255
		// (get) Token: 0x06007235 RID: 29237 RVA: 0x000DA86C File Offset: 0x000D8A6C
		// (set) Token: 0x06007236 RID: 29238 RVA: 0x000DA88D File Offset: 0x000D8A8D
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

		// Token: 0x17002428 RID: 9256
		// (get) Token: 0x06007237 RID: 29239 RVA: 0x000DA898 File Offset: 0x000D8A98
		// (set) Token: 0x06007238 RID: 29240 RVA: 0x000DA8B4 File Offset: 0x000D8AB4
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

		// Token: 0x06007239 RID: 29241 RVA: 0x000DA8E4 File Offset: 0x000D8AE4
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600723A RID: 29242 RVA: 0x000DA8FC File Offset: 0x000D8AFC
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002429 RID: 9257
		// (get) Token: 0x0600723B RID: 29243 RVA: 0x000DA908 File Offset: 0x000D8B08
		// (set) Token: 0x0600723C RID: 29244 RVA: 0x000DA934 File Offset: 0x000D8B34
		[ProtoMember(4, IsRequired = false, Name = "lv", DataFormat = DataFormat.TwosComplement)]
		public uint lv
		{
			get
			{
				return this._lv ?? 0U;
			}
			set
			{
				this._lv = new uint?(value);
			}
		}

		// Token: 0x1700242A RID: 9258
		// (get) Token: 0x0600723D RID: 29245 RVA: 0x000DA944 File Offset: 0x000D8B44
		// (set) Token: 0x0600723E RID: 29246 RVA: 0x000DA964 File Offset: 0x000D8B64
		[XmlIgnore]
		[Browsable(false)]
		public bool lvSpecified
		{
			get
			{
				return this._lv != null;
			}
			set
			{
				bool flag = value == (this._lv == null);
				if (flag)
				{
					this._lv = (value ? new uint?(this.lv) : null);
				}
			}
		}

		// Token: 0x0600723F RID: 29247 RVA: 0x000DA9A8 File Offset: 0x000D8BA8
		private bool ShouldSerializelv()
		{
			return this.lvSpecified;
		}

		// Token: 0x06007240 RID: 29248 RVA: 0x000DA9C0 File Offset: 0x000D8BC0
		private void Resetlv()
		{
			this.lvSpecified = false;
		}

		// Token: 0x1700242B RID: 9259
		// (get) Token: 0x06007241 RID: 29249 RVA: 0x000DA9CC File Offset: 0x000D8BCC
		// (set) Token: 0x06007242 RID: 29250 RVA: 0x000DA9F8 File Offset: 0x000D8BF8
		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x1700242C RID: 9260
		// (get) Token: 0x06007243 RID: 29251 RVA: 0x000DAA08 File Offset: 0x000D8C08
		// (set) Token: 0x06007244 RID: 29252 RVA: 0x000DAA28 File Offset: 0x000D8C28
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06007245 RID: 29253 RVA: 0x000DAA6C File Offset: 0x000D8C6C
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06007246 RID: 29254 RVA: 0x000DAA84 File Offset: 0x000D8C84
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x1700242D RID: 9261
		// (get) Token: 0x06007247 RID: 29255 RVA: 0x000DAA90 File Offset: 0x000D8C90
		// (set) Token: 0x06007248 RID: 29256 RVA: 0x000DAABC File Offset: 0x000D8CBC
		[ProtoMember(6, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		// Token: 0x1700242E RID: 9262
		// (get) Token: 0x06007249 RID: 29257 RVA: 0x000DAACC File Offset: 0x000D8CCC
		// (set) Token: 0x0600724A RID: 29258 RVA: 0x000DAAEC File Offset: 0x000D8CEC
		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		// Token: 0x0600724B RID: 29259 RVA: 0x000DAB30 File Offset: 0x000D8D30
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x0600724C RID: 29260 RVA: 0x000DAB48 File Offset: 0x000D8D48
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x1700242F RID: 9263
		// (get) Token: 0x0600724D RID: 29261 RVA: 0x000DAB54 File Offset: 0x000D8D54
		// (set) Token: 0x0600724E RID: 29262 RVA: 0x000DAB80 File Offset: 0x000D8D80
		[ProtoMember(7, IsRequired = false, Name = "online", DataFormat = DataFormat.Default)]
		public bool online
		{
			get
			{
				return this._online ?? false;
			}
			set
			{
				this._online = new bool?(value);
			}
		}

		// Token: 0x17002430 RID: 9264
		// (get) Token: 0x0600724F RID: 29263 RVA: 0x000DAB90 File Offset: 0x000D8D90
		// (set) Token: 0x06007250 RID: 29264 RVA: 0x000DABB0 File Offset: 0x000D8DB0
		[XmlIgnore]
		[Browsable(false)]
		public bool onlineSpecified
		{
			get
			{
				return this._online != null;
			}
			set
			{
				bool flag = value == (this._online == null);
				if (flag)
				{
					this._online = (value ? new bool?(this.online) : null);
				}
			}
		}

		// Token: 0x06007251 RID: 29265 RVA: 0x000DABF4 File Offset: 0x000D8DF4
		private bool ShouldSerializeonline()
		{
			return this.onlineSpecified;
		}

		// Token: 0x06007252 RID: 29266 RVA: 0x000DAC0C File Offset: 0x000D8E0C
		private void Resetonline()
		{
			this.onlineSpecified = false;
		}

		// Token: 0x17002431 RID: 9265
		// (get) Token: 0x06007253 RID: 29267 RVA: 0x000DAC18 File Offset: 0x000D8E18
		// (set) Token: 0x06007254 RID: 29268 RVA: 0x000DAC45 File Offset: 0x000D8E45
		[ProtoMember(8, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002432 RID: 9266
		// (get) Token: 0x06007255 RID: 29269 RVA: 0x000DAC54 File Offset: 0x000D8E54
		// (set) Token: 0x06007256 RID: 29270 RVA: 0x000DAC74 File Offset: 0x000D8E74
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

		// Token: 0x06007257 RID: 29271 RVA: 0x000DACB8 File Offset: 0x000D8EB8
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06007258 RID: 29272 RVA: 0x000DACD0 File Offset: 0x000D8ED0
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002433 RID: 9267
		// (get) Token: 0x06007259 RID: 29273 RVA: 0x000DACDC File Offset: 0x000D8EDC
		// (set) Token: 0x0600725A RID: 29274 RVA: 0x000DACFD File Offset: 0x000D8EFD
		[ProtoMember(9, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x17002434 RID: 9268
		// (get) Token: 0x0600725B RID: 29275 RVA: 0x000DAD08 File Offset: 0x000D8F08
		// (set) Token: 0x0600725C RID: 29276 RVA: 0x000DAD24 File Offset: 0x000D8F24
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x0600725D RID: 29277 RVA: 0x000DAD54 File Offset: 0x000D8F54
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x0600725E RID: 29278 RVA: 0x000DAD6C File Offset: 0x000D8F6C
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x0600725F RID: 29279 RVA: 0x000DAD78 File Offset: 0x000D8F78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B37 RID: 6967
		private uint? _teamid;

		// Token: 0x04001B38 RID: 6968
		private ulong? _uid;

		// Token: 0x04001B39 RID: 6969
		private string _name;

		// Token: 0x04001B3A RID: 6970
		private uint? _lv;

		// Token: 0x04001B3B RID: 6971
		private uint? _ppt;

		// Token: 0x04001B3C RID: 6972
		private uint? _job;

		// Token: 0x04001B3D RID: 6973
		private bool? _online;

		// Token: 0x04001B3E RID: 6974
		private ulong? _guildid;

		// Token: 0x04001B3F RID: 6975
		private string _guildname;

		// Token: 0x04001B40 RID: 6976
		private IExtension extensionObject;
	}
}
