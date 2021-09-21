using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073D RID: 1853
	[ProtoContract(Name = "ZoneRoleInfo")]
	[Serializable]
	public class ZoneRoleInfo : IExtensible
	{
		// Token: 0x170028BD RID: 10429
		// (get) Token: 0x0600807F RID: 32895 RVA: 0x000F5B90 File Offset: 0x000F3D90
		// (set) Token: 0x06008080 RID: 32896 RVA: 0x000F5BBC File Offset: 0x000F3DBC
		[ProtoMember(1, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028BE RID: 10430
		// (get) Token: 0x06008081 RID: 32897 RVA: 0x000F5BCC File Offset: 0x000F3DCC
		// (set) Token: 0x06008082 RID: 32898 RVA: 0x000F5BEC File Offset: 0x000F3DEC
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

		// Token: 0x06008083 RID: 32899 RVA: 0x000F5C30 File Offset: 0x000F3E30
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06008084 RID: 32900 RVA: 0x000F5C48 File Offset: 0x000F3E48
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170028BF RID: 10431
		// (get) Token: 0x06008085 RID: 32901 RVA: 0x000F5C54 File Offset: 0x000F3E54
		// (set) Token: 0x06008086 RID: 32902 RVA: 0x000F5C75 File Offset: 0x000F3E75
		[ProtoMember(2, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x170028C0 RID: 10432
		// (get) Token: 0x06008087 RID: 32903 RVA: 0x000F5C80 File Offset: 0x000F3E80
		// (set) Token: 0x06008088 RID: 32904 RVA: 0x000F5C9C File Offset: 0x000F3E9C
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x06008089 RID: 32905 RVA: 0x000F5CCC File Offset: 0x000F3ECC
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x0600808A RID: 32906 RVA: 0x000F5CE4 File Offset: 0x000F3EE4
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170028C1 RID: 10433
		// (get) Token: 0x0600808B RID: 32907 RVA: 0x000F5CF0 File Offset: 0x000F3EF0
		// (set) Token: 0x0600808C RID: 32908 RVA: 0x000F5D1D File Offset: 0x000F3F1D
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028C2 RID: 10434
		// (get) Token: 0x0600808D RID: 32909 RVA: 0x000F5D2C File Offset: 0x000F3F2C
		// (set) Token: 0x0600808E RID: 32910 RVA: 0x000F5D4C File Offset: 0x000F3F4C
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

		// Token: 0x0600808F RID: 32911 RVA: 0x000F5D90 File Offset: 0x000F3F90
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06008090 RID: 32912 RVA: 0x000F5DA8 File Offset: 0x000F3FA8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170028C3 RID: 10435
		// (get) Token: 0x06008091 RID: 32913 RVA: 0x000F5DB4 File Offset: 0x000F3FB4
		// (set) Token: 0x06008092 RID: 32914 RVA: 0x000F5DD5 File Offset: 0x000F3FD5
		[ProtoMember(4, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x170028C4 RID: 10436
		// (get) Token: 0x06008093 RID: 32915 RVA: 0x000F5DE0 File Offset: 0x000F3FE0
		// (set) Token: 0x06008094 RID: 32916 RVA: 0x000F5DFC File Offset: 0x000F3FFC
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

		// Token: 0x06008095 RID: 32917 RVA: 0x000F5E2C File Offset: 0x000F402C
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06008096 RID: 32918 RVA: 0x000F5E44 File Offset: 0x000F4044
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x170028C5 RID: 10437
		// (get) Token: 0x06008097 RID: 32919 RVA: 0x000F5E50 File Offset: 0x000F4050
		// (set) Token: 0x06008098 RID: 32920 RVA: 0x000F5E7C File Offset: 0x000F407C
		[ProtoMember(5, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public RoleType roleprofession
		{
			get
			{
				return this._roleprofession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._roleprofession = new RoleType?(value);
			}
		}

		// Token: 0x170028C6 RID: 10438
		// (get) Token: 0x06008099 RID: 32921 RVA: 0x000F5E8C File Offset: 0x000F408C
		// (set) Token: 0x0600809A RID: 32922 RVA: 0x000F5EAC File Offset: 0x000F40AC
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
					this._roleprofession = (value ? new RoleType?(this.roleprofession) : null);
				}
			}
		}

		// Token: 0x0600809B RID: 32923 RVA: 0x000F5EF0 File Offset: 0x000F40F0
		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		// Token: 0x0600809C RID: 32924 RVA: 0x000F5F08 File Offset: 0x000F4108
		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		// Token: 0x170028C7 RID: 10439
		// (get) Token: 0x0600809D RID: 32925 RVA: 0x000F5F14 File Offset: 0x000F4114
		// (set) Token: 0x0600809E RID: 32926 RVA: 0x000F5F40 File Offset: 0x000F4140
		[ProtoMember(6, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
		public uint rolelevel
		{
			get
			{
				return this._rolelevel ?? 0U;
			}
			set
			{
				this._rolelevel = new uint?(value);
			}
		}

		// Token: 0x170028C8 RID: 10440
		// (get) Token: 0x0600809F RID: 32927 RVA: 0x000F5F50 File Offset: 0x000F4150
		// (set) Token: 0x060080A0 RID: 32928 RVA: 0x000F5F70 File Offset: 0x000F4170
		[XmlIgnore]
		[Browsable(false)]
		public bool rolelevelSpecified
		{
			get
			{
				return this._rolelevel != null;
			}
			set
			{
				bool flag = value == (this._rolelevel == null);
				if (flag)
				{
					this._rolelevel = (value ? new uint?(this.rolelevel) : null);
				}
			}
		}

		// Token: 0x060080A1 RID: 32929 RVA: 0x000F5FB4 File Offset: 0x000F41B4
		private bool ShouldSerializerolelevel()
		{
			return this.rolelevelSpecified;
		}

		// Token: 0x060080A2 RID: 32930 RVA: 0x000F5FCC File Offset: 0x000F41CC
		private void Resetrolelevel()
		{
			this.rolelevelSpecified = false;
		}

		// Token: 0x170028C9 RID: 10441
		// (get) Token: 0x060080A3 RID: 32931 RVA: 0x000F5FD8 File Offset: 0x000F41D8
		// (set) Token: 0x060080A4 RID: 32932 RVA: 0x000F6004 File Offset: 0x000F4204
		[ProtoMember(7, IsRequired = false, Name = "paycnt", DataFormat = DataFormat.TwosComplement)]
		public uint paycnt
		{
			get
			{
				return this._paycnt ?? 0U;
			}
			set
			{
				this._paycnt = new uint?(value);
			}
		}

		// Token: 0x170028CA RID: 10442
		// (get) Token: 0x060080A5 RID: 32933 RVA: 0x000F6014 File Offset: 0x000F4214
		// (set) Token: 0x060080A6 RID: 32934 RVA: 0x000F6034 File Offset: 0x000F4234
		[XmlIgnore]
		[Browsable(false)]
		public bool paycntSpecified
		{
			get
			{
				return this._paycnt != null;
			}
			set
			{
				bool flag = value == (this._paycnt == null);
				if (flag)
				{
					this._paycnt = (value ? new uint?(this.paycnt) : null);
				}
			}
		}

		// Token: 0x060080A7 RID: 32935 RVA: 0x000F6078 File Offset: 0x000F4278
		private bool ShouldSerializepaycnt()
		{
			return this.paycntSpecified;
		}

		// Token: 0x060080A8 RID: 32936 RVA: 0x000F6090 File Offset: 0x000F4290
		private void Resetpaycnt()
		{
			this.paycntSpecified = false;
		}

		// Token: 0x170028CB RID: 10443
		// (get) Token: 0x060080A9 RID: 32937 RVA: 0x000F609C File Offset: 0x000F429C
		// (set) Token: 0x060080AA RID: 32938 RVA: 0x000F60C8 File Offset: 0x000F42C8
		[ProtoMember(8, IsRequired = false, Name = "opentime", DataFormat = DataFormat.TwosComplement)]
		public uint opentime
		{
			get
			{
				return this._opentime ?? 0U;
			}
			set
			{
				this._opentime = new uint?(value);
			}
		}

		// Token: 0x170028CC RID: 10444
		// (get) Token: 0x060080AB RID: 32939 RVA: 0x000F60D8 File Offset: 0x000F42D8
		// (set) Token: 0x060080AC RID: 32940 RVA: 0x000F60F8 File Offset: 0x000F42F8
		[XmlIgnore]
		[Browsable(false)]
		public bool opentimeSpecified
		{
			get
			{
				return this._opentime != null;
			}
			set
			{
				bool flag = value == (this._opentime == null);
				if (flag)
				{
					this._opentime = (value ? new uint?(this.opentime) : null);
				}
			}
		}

		// Token: 0x060080AD RID: 32941 RVA: 0x000F613C File Offset: 0x000F433C
		private bool ShouldSerializeopentime()
		{
			return this.opentimeSpecified;
		}

		// Token: 0x060080AE RID: 32942 RVA: 0x000F6154 File Offset: 0x000F4354
		private void Resetopentime()
		{
			this.opentimeSpecified = false;
		}

		// Token: 0x060080AF RID: 32943 RVA: 0x000F6160 File Offset: 0x000F4360
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E1D RID: 7709
		private uint? _serverid;

		// Token: 0x04001E1E RID: 7710
		private string _servername;

		// Token: 0x04001E1F RID: 7711
		private ulong? _roleid;

		// Token: 0x04001E20 RID: 7712
		private string _rolename;

		// Token: 0x04001E21 RID: 7713
		private RoleType? _roleprofession;

		// Token: 0x04001E22 RID: 7714
		private uint? _rolelevel;

		// Token: 0x04001E23 RID: 7715
		private uint? _paycnt;

		// Token: 0x04001E24 RID: 7716
		private uint? _opentime;

		// Token: 0x04001E25 RID: 7717
		private IExtension extensionObject;
	}
}
