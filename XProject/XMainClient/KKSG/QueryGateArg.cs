using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000071 RID: 113
	[ProtoContract(Name = "QueryGateArg")]
	[Serializable]
	public class QueryGateArg : IExtensible
	{
		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00010918 File Offset: 0x0000EB18
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00010939 File Offset: 0x0000EB39
		[ProtoMember(1, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x00010944 File Offset: 0x0000EB44
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x00010960 File Offset: 0x0000EB60
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00010990 File Offset: 0x0000EB90
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000109A8 File Offset: 0x0000EBA8
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x000109B4 File Offset: 0x0000EBB4
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x000109D5 File Offset: 0x0000EBD5
		[ProtoMember(2, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x000109E0 File Offset: 0x0000EBE0
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x000109FC File Offset: 0x0000EBFC
		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00010A2C File Offset: 0x0000EC2C
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00010A44 File Offset: 0x0000EC44
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00010A50 File Offset: 0x0000EC50
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x00010A71 File Offset: 0x0000EC71
		[ProtoMember(3, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00010A7C File Offset: 0x0000EC7C
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x00010A98 File Offset: 0x0000EC98
		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00010AC8 File Offset: 0x0000ECC8
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00010AE0 File Offset: 0x0000ECE0
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00010AEC File Offset: 0x0000ECEC
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x00010B18 File Offset: 0x0000ED18
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LoginType type
		{
			get
			{
				return this._type ?? LoginType.LOGIN_PASSWORD;
			}
			set
			{
				this._type = new LoginType?(value);
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00010B28 File Offset: 0x0000ED28
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x00010B48 File Offset: 0x0000ED48
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
					this._type = (value ? new LoginType?(this.type) : null);
				}
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00010B8C File Offset: 0x0000ED8C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00010BA4 File Offset: 0x0000EDA4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00010BB0 File Offset: 0x0000EDB0
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x00010BD1 File Offset: 0x0000EDD1
		[ProtoMember(5, IsRequired = false, Name = "pf", DataFormat = DataFormat.Default)]
		public string pf
		{
			get
			{
				return this._pf ?? "";
			}
			set
			{
				this._pf = value;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00010BDC File Offset: 0x0000EDDC
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00010BF8 File Offset: 0x0000EDF8
		[XmlIgnore]
		[Browsable(false)]
		public bool pfSpecified
		{
			get
			{
				return this._pf != null;
			}
			set
			{
				bool flag = value == (this._pf == null);
				if (flag)
				{
					this._pf = (value ? this.pf : null);
				}
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00010C28 File Offset: 0x0000EE28
		private bool ShouldSerializepf()
		{
			return this.pfSpecified;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00010C40 File Offset: 0x0000EE40
		private void Resetpf()
		{
			this.pfSpecified = false;
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x00010C4C File Offset: 0x0000EE4C
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x00010C6D File Offset: 0x0000EE6D
		[ProtoMember(6, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x00010C78 File Offset: 0x0000EE78
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x00010C94 File Offset: 0x0000EE94
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00010CC4 File Offset: 0x0000EEC4
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00010CDC File Offset: 0x0000EEDC
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00010CE8 File Offset: 0x0000EEE8
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x00010D14 File Offset: 0x0000EF14
		[ProtoMember(7, IsRequired = false, Name = "platid", DataFormat = DataFormat.TwosComplement)]
		public PlatType platid
		{
			get
			{
				return this._platid ?? PlatType.PLAT_IOS;
			}
			set
			{
				this._platid = new PlatType?(value);
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00010D24 File Offset: 0x0000EF24
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00010D44 File Offset: 0x0000EF44
		[XmlIgnore]
		[Browsable(false)]
		public bool platidSpecified
		{
			get
			{
				return this._platid != null;
			}
			set
			{
				bool flag = value == (this._platid == null);
				if (flag)
				{
					this._platid = (value ? new PlatType?(this.platid) : null);
				}
			}
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00010D88 File Offset: 0x0000EF88
		private bool ShouldSerializeplatid()
		{
			return this.platidSpecified;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00010DA0 File Offset: 0x0000EFA0
		private void Resetplatid()
		{
			this.platidSpecified = false;
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x00010DAC File Offset: 0x0000EFAC
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x00010DCD File Offset: 0x0000EFCD
		[ProtoMember(8, IsRequired = false, Name = "version", DataFormat = DataFormat.Default)]
		public string version
		{
			get
			{
				return this._version ?? "";
			}
			set
			{
				this._version = value;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x00010DD8 File Offset: 0x0000EFD8
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x00010DF4 File Offset: 0x0000EFF4
		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? this.version : null);
				}
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00010E24 File Offset: 0x0000F024
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00010E3C File Offset: 0x0000F03C
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00010E48 File Offset: 0x0000F048
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001DA RID: 474
		private string _token;

		// Token: 0x040001DB RID: 475
		private string _account;

		// Token: 0x040001DC RID: 476
		private string _password;

		// Token: 0x040001DD RID: 477
		private LoginType? _type;

		// Token: 0x040001DE RID: 478
		private string _pf;

		// Token: 0x040001DF RID: 479
		private string _openid;

		// Token: 0x040001E0 RID: 480
		private PlatType? _platid;

		// Token: 0x040001E1 RID: 481
		private string _version;

		// Token: 0x040001E2 RID: 482
		private IExtension extensionObject;
	}
}
