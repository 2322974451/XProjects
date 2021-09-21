using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CA RID: 1738
	[ProtoContract(Name = "ResWarRoleRank")]
	[Serializable]
	public class ResWarRoleRank : IExtensible
	{
		// Token: 0x17002458 RID: 9304
		// (get) Token: 0x060072CE RID: 29390 RVA: 0x000DBAB0 File Offset: 0x000D9CB0
		// (set) Token: 0x060072CF RID: 29391 RVA: 0x000DBAD1 File Offset: 0x000D9CD1
		[ProtoMember(1, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002459 RID: 9305
		// (get) Token: 0x060072D0 RID: 29392 RVA: 0x000DBADC File Offset: 0x000D9CDC
		// (set) Token: 0x060072D1 RID: 29393 RVA: 0x000DBAF8 File Offset: 0x000D9CF8
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

		// Token: 0x060072D2 RID: 29394 RVA: 0x000DBB28 File Offset: 0x000D9D28
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x060072D3 RID: 29395 RVA: 0x000DBB40 File Offset: 0x000D9D40
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700245A RID: 9306
		// (get) Token: 0x060072D4 RID: 29396 RVA: 0x000DBB4C File Offset: 0x000D9D4C
		// (set) Token: 0x060072D5 RID: 29397 RVA: 0x000DBB6D File Offset: 0x000D9D6D
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700245B RID: 9307
		// (get) Token: 0x060072D6 RID: 29398 RVA: 0x000DBB78 File Offset: 0x000D9D78
		// (set) Token: 0x060072D7 RID: 29399 RVA: 0x000DBB94 File Offset: 0x000D9D94
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

		// Token: 0x060072D8 RID: 29400 RVA: 0x000DBBC4 File Offset: 0x000D9DC4
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x060072D9 RID: 29401 RVA: 0x000DBBDC File Offset: 0x000D9DDC
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x1700245C RID: 9308
		// (get) Token: 0x060072DA RID: 29402 RVA: 0x000DBBE8 File Offset: 0x000D9DE8
		// (set) Token: 0x060072DB RID: 29403 RVA: 0x000DBC14 File Offset: 0x000D9E14
		[ProtoMember(3, IsRequired = false, Name = "res", DataFormat = DataFormat.TwosComplement)]
		public uint res
		{
			get
			{
				return this._res ?? 0U;
			}
			set
			{
				this._res = new uint?(value);
			}
		}

		// Token: 0x1700245D RID: 9309
		// (get) Token: 0x060072DC RID: 29404 RVA: 0x000DBC24 File Offset: 0x000D9E24
		// (set) Token: 0x060072DD RID: 29405 RVA: 0x000DBC44 File Offset: 0x000D9E44
		[XmlIgnore]
		[Browsable(false)]
		public bool resSpecified
		{
			get
			{
				return this._res != null;
			}
			set
			{
				bool flag = value == (this._res == null);
				if (flag)
				{
					this._res = (value ? new uint?(this.res) : null);
				}
			}
		}

		// Token: 0x060072DE RID: 29406 RVA: 0x000DBC88 File Offset: 0x000D9E88
		private bool ShouldSerializeres()
		{
			return this.resSpecified;
		}

		// Token: 0x060072DF RID: 29407 RVA: 0x000DBCA0 File Offset: 0x000D9EA0
		private void Resetres()
		{
			this.resSpecified = false;
		}

		// Token: 0x1700245E RID: 9310
		// (get) Token: 0x060072E0 RID: 29408 RVA: 0x000DBCAC File Offset: 0x000D9EAC
		// (set) Token: 0x060072E1 RID: 29409 RVA: 0x000DBCD9 File Offset: 0x000D9ED9
		[ProtoMember(4, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700245F RID: 9311
		// (get) Token: 0x060072E2 RID: 29410 RVA: 0x000DBCE8 File Offset: 0x000D9EE8
		// (set) Token: 0x060072E3 RID: 29411 RVA: 0x000DBD08 File Offset: 0x000D9F08
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

		// Token: 0x060072E4 RID: 29412 RVA: 0x000DBD4C File Offset: 0x000D9F4C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060072E5 RID: 29413 RVA: 0x000DBD64 File Offset: 0x000D9F64
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002460 RID: 9312
		// (get) Token: 0x060072E6 RID: 29414 RVA: 0x000DBD70 File Offset: 0x000D9F70
		// (set) Token: 0x060072E7 RID: 29415 RVA: 0x000DBD9D File Offset: 0x000D9F9D
		[ProtoMember(5, IsRequired = false, Name = "guild", DataFormat = DataFormat.TwosComplement)]
		public ulong guild
		{
			get
			{
				return this._guild ?? 0UL;
			}
			set
			{
				this._guild = new ulong?(value);
			}
		}

		// Token: 0x17002461 RID: 9313
		// (get) Token: 0x060072E8 RID: 29416 RVA: 0x000DBDAC File Offset: 0x000D9FAC
		// (set) Token: 0x060072E9 RID: 29417 RVA: 0x000DBDCC File Offset: 0x000D9FCC
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
					this._guild = (value ? new ulong?(this.guild) : null);
				}
			}
		}

		// Token: 0x060072EA RID: 29418 RVA: 0x000DBE10 File Offset: 0x000DA010
		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		// Token: 0x060072EB RID: 29419 RVA: 0x000DBE28 File Offset: 0x000DA028
		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		// Token: 0x060072EC RID: 29420 RVA: 0x000DBE34 File Offset: 0x000DA034
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B56 RID: 6998
		private string _rolename;

		// Token: 0x04001B57 RID: 6999
		private string _guildname;

		// Token: 0x04001B58 RID: 7000
		private uint? _res;

		// Token: 0x04001B59 RID: 7001
		private ulong? _roleid;

		// Token: 0x04001B5A RID: 7002
		private ulong? _guild;

		// Token: 0x04001B5B RID: 7003
		private IExtension extensionObject;
	}
}
