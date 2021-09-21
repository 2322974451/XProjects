using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000352 RID: 850
	[ProtoContract(Name = "GCFG2CSynPara")]
	[Serializable]
	public class GCFG2CSynPara : IExtensible
	{
		// Token: 0x17000E64 RID: 3684
		// (get) Token: 0x06002E68 RID: 11880 RVA: 0x00059B14 File Offset: 0x00057D14
		// (set) Token: 0x06002E69 RID: 11881 RVA: 0x00059B40 File Offset: 0x00057D40
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GCFG2CSynType type
		{
			get
			{
				return this._type ?? GCFG2CSynType.GCF_G2C_SYN_KILL_ONE;
			}
			set
			{
				this._type = new GCFG2CSynType?(value);
			}
		}

		// Token: 0x17000E65 RID: 3685
		// (get) Token: 0x06002E6A RID: 11882 RVA: 0x00059B50 File Offset: 0x00057D50
		// (set) Token: 0x06002E6B RID: 11883 RVA: 0x00059B70 File Offset: 0x00057D70
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
					this._type = (value ? new GCFG2CSynType?(this.type) : null);
				}
			}
		}

		// Token: 0x06002E6C RID: 11884 RVA: 0x00059BB4 File Offset: 0x00057DB4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002E6D RID: 11885 RVA: 0x00059BCC File Offset: 0x00057DCC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000E66 RID: 3686
		// (get) Token: 0x06002E6E RID: 11886 RVA: 0x00059BD8 File Offset: 0x00057DD8
		// (set) Token: 0x06002E6F RID: 11887 RVA: 0x00059C05 File Offset: 0x00057E05
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000E67 RID: 3687
		// (get) Token: 0x06002E70 RID: 11888 RVA: 0x00059C14 File Offset: 0x00057E14
		// (set) Token: 0x06002E71 RID: 11889 RVA: 0x00059C34 File Offset: 0x00057E34
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

		// Token: 0x06002E72 RID: 11890 RVA: 0x00059C78 File Offset: 0x00057E78
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002E73 RID: 11891 RVA: 0x00059C90 File Offset: 0x00057E90
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17000E68 RID: 3688
		// (get) Token: 0x06002E74 RID: 11892 RVA: 0x00059C9C File Offset: 0x00057E9C
		// (set) Token: 0x06002E75 RID: 11893 RVA: 0x00059CC8 File Offset: 0x00057EC8
		[ProtoMember(3, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x17000E69 RID: 3689
		// (get) Token: 0x06002E76 RID: 11894 RVA: 0x00059CD8 File Offset: 0x00057ED8
		// (set) Token: 0x06002E77 RID: 11895 RVA: 0x00059CF8 File Offset: 0x00057EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x06002E78 RID: 11896 RVA: 0x00059D3C File Offset: 0x00057F3C
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06002E79 RID: 11897 RVA: 0x00059D54 File Offset: 0x00057F54
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17000E6A RID: 3690
		// (get) Token: 0x06002E7A RID: 11898 RVA: 0x00059D60 File Offset: 0x00057F60
		// (set) Token: 0x06002E7B RID: 11899 RVA: 0x00059D81 File Offset: 0x00057F81
		[ProtoMember(4, IsRequired = false, Name = "killname", DataFormat = DataFormat.Default)]
		public string killname
		{
			get
			{
				return this._killname ?? "";
			}
			set
			{
				this._killname = value;
			}
		}

		// Token: 0x17000E6B RID: 3691
		// (get) Token: 0x06002E7C RID: 11900 RVA: 0x00059D8C File Offset: 0x00057F8C
		// (set) Token: 0x06002E7D RID: 11901 RVA: 0x00059DA8 File Offset: 0x00057FA8
		[XmlIgnore]
		[Browsable(false)]
		public bool killnameSpecified
		{
			get
			{
				return this._killname != null;
			}
			set
			{
				bool flag = value == (this._killname == null);
				if (flag)
				{
					this._killname = (value ? this.killname : null);
				}
			}
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x00059DD8 File Offset: 0x00057FD8
		private bool ShouldSerializekillname()
		{
			return this.killnameSpecified;
		}

		// Token: 0x06002E7F RID: 11903 RVA: 0x00059DF0 File Offset: 0x00057FF0
		private void Resetkillname()
		{
			this.killnameSpecified = false;
		}

		// Token: 0x17000E6C RID: 3692
		// (get) Token: 0x06002E80 RID: 11904 RVA: 0x00059DFC File Offset: 0x00057FFC
		// (set) Token: 0x06002E81 RID: 11905 RVA: 0x00059E1D File Offset: 0x0005801D
		[ProtoMember(5, IsRequired = false, Name = "deadname", DataFormat = DataFormat.Default)]
		public string deadname
		{
			get
			{
				return this._deadname ?? "";
			}
			set
			{
				this._deadname = value;
			}
		}

		// Token: 0x17000E6D RID: 3693
		// (get) Token: 0x06002E82 RID: 11906 RVA: 0x00059E28 File Offset: 0x00058028
		// (set) Token: 0x06002E83 RID: 11907 RVA: 0x00059E44 File Offset: 0x00058044
		[XmlIgnore]
		[Browsable(false)]
		public bool deadnameSpecified
		{
			get
			{
				return this._deadname != null;
			}
			set
			{
				bool flag = value == (this._deadname == null);
				if (flag)
				{
					this._deadname = (value ? this.deadname : null);
				}
			}
		}

		// Token: 0x06002E84 RID: 11908 RVA: 0x00059E74 File Offset: 0x00058074
		private bool ShouldSerializedeadname()
		{
			return this.deadnameSpecified;
		}

		// Token: 0x06002E85 RID: 11909 RVA: 0x00059E8C File Offset: 0x0005808C
		private void Resetdeadname()
		{
			this.deadnameSpecified = false;
		}

		// Token: 0x17000E6E RID: 3694
		// (get) Token: 0x06002E86 RID: 11910 RVA: 0x00059E98 File Offset: 0x00058098
		// (set) Token: 0x06002E87 RID: 11911 RVA: 0x00059EC4 File Offset: 0x000580C4
		[ProtoMember(6, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		// Token: 0x17000E6F RID: 3695
		// (get) Token: 0x06002E88 RID: 11912 RVA: 0x00059ED4 File Offset: 0x000580D4
		// (set) Token: 0x06002E89 RID: 11913 RVA: 0x00059EF4 File Offset: 0x000580F4
		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		// Token: 0x06002E8A RID: 11914 RVA: 0x00059F38 File Offset: 0x00058138
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x06002E8B RID: 11915 RVA: 0x00059F50 File Offset: 0x00058150
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x17000E70 RID: 3696
		// (get) Token: 0x06002E8C RID: 11916 RVA: 0x00059F5C File Offset: 0x0005815C
		// (set) Token: 0x06002E8D RID: 11917 RVA: 0x00059F88 File Offset: 0x00058188
		[ProtoMember(7, IsRequired = false, Name = "mulpoint", DataFormat = DataFormat.TwosComplement)]
		public uint mulpoint
		{
			get
			{
				return this._mulpoint ?? 0U;
			}
			set
			{
				this._mulpoint = new uint?(value);
			}
		}

		// Token: 0x17000E71 RID: 3697
		// (get) Token: 0x06002E8E RID: 11918 RVA: 0x00059F98 File Offset: 0x00058198
		// (set) Token: 0x06002E8F RID: 11919 RVA: 0x00059FB8 File Offset: 0x000581B8
		[XmlIgnore]
		[Browsable(false)]
		public bool mulpointSpecified
		{
			get
			{
				return this._mulpoint != null;
			}
			set
			{
				bool flag = value == (this._mulpoint == null);
				if (flag)
				{
					this._mulpoint = (value ? new uint?(this.mulpoint) : null);
				}
			}
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x00059FFC File Offset: 0x000581FC
		private bool ShouldSerializemulpoint()
		{
			return this.mulpointSpecified;
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x0005A014 File Offset: 0x00058214
		private void Resetmulpoint()
		{
			this.mulpointSpecified = false;
		}

		// Token: 0x17000E72 RID: 3698
		// (get) Token: 0x06002E92 RID: 11922 RVA: 0x0005A020 File Offset: 0x00058220
		// (set) Token: 0x06002E93 RID: 11923 RVA: 0x0005A038 File Offset: 0x00058238
		[ProtoMember(8, IsRequired = false, Name = "jvdian", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFJvDianInfo jvdian
		{
			get
			{
				return this._jvdian;
			}
			set
			{
				this._jvdian = value;
			}
		}

		// Token: 0x17000E73 RID: 3699
		// (get) Token: 0x06002E94 RID: 11924 RVA: 0x0005A044 File Offset: 0x00058244
		// (set) Token: 0x06002E95 RID: 11925 RVA: 0x0005A070 File Offset: 0x00058270
		[ProtoMember(9, IsRequired = false, Name = "territoryid", DataFormat = DataFormat.TwosComplement)]
		public uint territoryid
		{
			get
			{
				return this._territoryid ?? 0U;
			}
			set
			{
				this._territoryid = new uint?(value);
			}
		}

		// Token: 0x17000E74 RID: 3700
		// (get) Token: 0x06002E96 RID: 11926 RVA: 0x0005A080 File Offset: 0x00058280
		// (set) Token: 0x06002E97 RID: 11927 RVA: 0x0005A0A0 File Offset: 0x000582A0
		[XmlIgnore]
		[Browsable(false)]
		public bool territoryidSpecified
		{
			get
			{
				return this._territoryid != null;
			}
			set
			{
				bool flag = value == (this._territoryid == null);
				if (flag)
				{
					this._territoryid = (value ? new uint?(this.territoryid) : null);
				}
			}
		}

		// Token: 0x06002E98 RID: 11928 RVA: 0x0005A0E4 File Offset: 0x000582E4
		private bool ShouldSerializeterritoryid()
		{
			return this.territoryidSpecified;
		}

		// Token: 0x06002E99 RID: 11929 RVA: 0x0005A0FC File Offset: 0x000582FC
		private void Resetterritoryid()
		{
			this.territoryidSpecified = false;
		}

		// Token: 0x06002E9A RID: 11930 RVA: 0x0005A108 File Offset: 0x00058308
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B89 RID: 2953
		private GCFG2CSynType? _type;

		// Token: 0x04000B8A RID: 2954
		private ulong? _roleid;

		// Token: 0x04000B8B RID: 2955
		private uint? _killcount;

		// Token: 0x04000B8C RID: 2956
		private string _killname;

		// Token: 0x04000B8D RID: 2957
		private string _deadname;

		// Token: 0x04000B8E RID: 2958
		private uint? _mapid;

		// Token: 0x04000B8F RID: 2959
		private uint? _mulpoint;

		// Token: 0x04000B90 RID: 2960
		private GCFJvDianInfo _jvdian = null;

		// Token: 0x04000B91 RID: 2961
		private uint? _territoryid;

		// Token: 0x04000B92 RID: 2962
		private IExtension extensionObject;
	}
}
