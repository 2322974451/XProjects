using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000072 RID: 114
	[ProtoContract(Name = "QueryGateRes")]
	[Serializable]
	public class QueryGateRes : IExtensible
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00010EC0 File Offset: 0x0000F0C0
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x00010EDD File Offset: 0x0000F0DD
		[ProtoMember(1, IsRequired = false, Name = "loginToken", DataFormat = DataFormat.Default)]
		public byte[] loginToken
		{
			get
			{
				return this._loginToken ?? null;
			}
			set
			{
				this._loginToken = value;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00010EE8 File Offset: 0x0000F0E8
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00010F04 File Offset: 0x0000F104
		[XmlIgnore]
		[Browsable(false)]
		public bool loginTokenSpecified
		{
			get
			{
				return this._loginToken != null;
			}
			set
			{
				bool flag = value == (this._loginToken == null);
				if (flag)
				{
					this._loginToken = (value ? this.loginToken : null);
				}
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00010F34 File Offset: 0x0000F134
		private bool ShouldSerializeloginToken()
		{
			return this.loginTokenSpecified;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00010F4C File Offset: 0x0000F14C
		private void ResetloginToken()
		{
			this.loginTokenSpecified = false;
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00010F58 File Offset: 0x0000F158
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x00010F75 File Offset: 0x0000F175
		[ProtoMember(2, IsRequired = false, Name = "gateconfig", DataFormat = DataFormat.Default)]
		public byte[] gateconfig
		{
			get
			{
				return this._gateconfig ?? null;
			}
			set
			{
				this._gateconfig = value;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00010F80 File Offset: 0x0000F180
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00010F9C File Offset: 0x0000F19C
		[XmlIgnore]
		[Browsable(false)]
		public bool gateconfigSpecified
		{
			get
			{
				return this._gateconfig != null;
			}
			set
			{
				bool flag = value == (this._gateconfig == null);
				if (flag)
				{
					this._gateconfig = (value ? this.gateconfig : null);
				}
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00010FCC File Offset: 0x0000F1CC
		private bool ShouldSerializegateconfig()
		{
			return this.gateconfigSpecified;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00010FE4 File Offset: 0x0000F1E4
		private void Resetgateconfig()
		{
			this.gateconfigSpecified = false;
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x00010FF0 File Offset: 0x0000F1F0
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x00011011 File Offset: 0x0000F211
		[ProtoMember(3, IsRequired = false, Name = "userphone", DataFormat = DataFormat.Default)]
		public string userphone
		{
			get
			{
				return this._userphone ?? "";
			}
			set
			{
				this._userphone = value;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x0001101C File Offset: 0x0000F21C
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x00011038 File Offset: 0x0000F238
		[XmlIgnore]
		[Browsable(false)]
		public bool userphoneSpecified
		{
			get
			{
				return this._userphone != null;
			}
			set
			{
				bool flag = value == (this._userphone == null);
				if (flag)
				{
					this._userphone = (value ? this.userphone : null);
				}
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00011068 File Offset: 0x0000F268
		private bool ShouldSerializeuserphone()
		{
			return this.userphoneSpecified;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00011080 File Offset: 0x0000F280
		private void Resetuserphone()
		{
			this.userphoneSpecified = false;
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0001108C File Offset: 0x0000F28C
		// (set) Token: 0x0600078A RID: 1930 RVA: 0x000110A4 File Offset: 0x0000F2A4
		[ProtoMember(4, IsRequired = false, Name = "RecommandGate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginGateData RecommandGate
		{
			get
			{
				return this._RecommandGate;
			}
			set
			{
				this._RecommandGate = value;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x000110B0 File Offset: 0x0000F2B0
		[ProtoMember(5, Name = "servers", DataFormat = DataFormat.Default)]
		public List<SelfServerData> servers
		{
			get
			{
				return this._servers;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x000110C8 File Offset: 0x0000F2C8
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x000110F4 File Offset: 0x0000F2F4
		[ProtoMember(6, IsRequired = false, Name = "loginzoneid", DataFormat = DataFormat.TwosComplement)]
		public uint loginzoneid
		{
			get
			{
				return this._loginzoneid ?? 0U;
			}
			set
			{
				this._loginzoneid = new uint?(value);
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x00011104 File Offset: 0x0000F304
		// (set) Token: 0x0600078F RID: 1935 RVA: 0x00011124 File Offset: 0x0000F324
		[XmlIgnore]
		[Browsable(false)]
		public bool loginzoneidSpecified
		{
			get
			{
				return this._loginzoneid != null;
			}
			set
			{
				bool flag = value == (this._loginzoneid == null);
				if (flag)
				{
					this._loginzoneid = (value ? new uint?(this.loginzoneid) : null);
				}
			}
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00011168 File Offset: 0x0000F368
		private bool ShouldSerializeloginzoneid()
		{
			return this.loginzoneidSpecified;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00011180 File Offset: 0x0000F380
		private void Resetloginzoneid()
		{
			this.loginzoneidSpecified = false;
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0001118C File Offset: 0x0000F38C
		[ProtoMember(7, Name = "allservers", DataFormat = DataFormat.Default)]
		public List<LoginGateData> allservers
		{
			get
			{
				return this._allservers;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x000111A4 File Offset: 0x0000F3A4
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x000111D0 File Offset: 0x0000F3D0
		[ProtoMember(8, IsRequired = false, Name = "in_white_list", DataFormat = DataFormat.Default)]
		public bool in_white_list
		{
			get
			{
				return this._in_white_list ?? false;
			}
			set
			{
				this._in_white_list = new bool?(value);
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x000111E0 File Offset: 0x0000F3E0
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00011200 File Offset: 0x0000F400
		[XmlIgnore]
		[Browsable(false)]
		public bool in_white_listSpecified
		{
			get
			{
				return this._in_white_list != null;
			}
			set
			{
				bool flag = value == (this._in_white_list == null);
				if (flag)
				{
					this._in_white_list = (value ? new bool?(this.in_white_list) : null);
				}
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00011244 File Offset: 0x0000F444
		private bool ShouldSerializein_white_list()
		{
			return this.in_white_listSpecified;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001125C File Offset: 0x0000F45C
		private void Resetin_white_list()
		{
			this.in_white_listSpecified = false;
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00011268 File Offset: 0x0000F468
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00011280 File Offset: 0x0000F480
		[ProtoMember(9, IsRequired = false, Name = "notice", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatNotice notice
		{
			get
			{
				return this._notice;
			}
			set
			{
				this._notice = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0001128C File Offset: 0x0000F48C
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x000112B8 File Offset: 0x0000F4B8
		[ProtoMember(10, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x000112C8 File Offset: 0x0000F4C8
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x000112E8 File Offset: 0x0000F4E8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001132C File Offset: 0x0000F52C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00011344 File Offset: 0x0000F544
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00011350 File Offset: 0x0000F550
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x00011368 File Offset: 0x0000F568
		[ProtoMember(11, IsRequired = false, Name = "baninfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatBanAccount baninfo
		{
			get
			{
				return this._baninfo;
			}
			set
			{
				this._baninfo = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00011374 File Offset: 0x0000F574
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x000113A0 File Offset: 0x0000F5A0
		[ProtoMember(12, IsRequired = false, Name = "freeflow", DataFormat = DataFormat.Default)]
		public bool freeflow
		{
			get
			{
				return this._freeflow ?? false;
			}
			set
			{
				this._freeflow = new bool?(value);
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x000113B0 File Offset: 0x0000F5B0
		// (set) Token: 0x060007A6 RID: 1958 RVA: 0x000113D0 File Offset: 0x0000F5D0
		[XmlIgnore]
		[Browsable(false)]
		public bool freeflowSpecified
		{
			get
			{
				return this._freeflow != null;
			}
			set
			{
				bool flag = value == (this._freeflow == null);
				if (flag)
				{
					this._freeflow = (value ? new bool?(this.freeflow) : null);
				}
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00011414 File Offset: 0x0000F614
		private bool ShouldSerializefreeflow()
		{
			return this.freeflowSpecified;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001142C File Offset: 0x0000F62C
		private void Resetfreeflow()
		{
			this.freeflowSpecified = false;
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x00011438 File Offset: 0x0000F638
		// (set) Token: 0x060007AA RID: 1962 RVA: 0x00011464 File Offset: 0x0000F664
		[ProtoMember(13, IsRequired = false, Name = "cctype", DataFormat = DataFormat.TwosComplement)]
		public int cctype
		{
			get
			{
				return this._cctype ?? 0;
			}
			set
			{
				this._cctype = new int?(value);
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x00011474 File Offset: 0x0000F674
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x00011494 File Offset: 0x0000F694
		[XmlIgnore]
		[Browsable(false)]
		public bool cctypeSpecified
		{
			get
			{
				return this._cctype != null;
			}
			set
			{
				bool flag = value == (this._cctype == null);
				if (flag)
				{
					this._cctype = (value ? new int?(this.cctype) : null);
				}
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x000114D8 File Offset: 0x0000F6D8
		private bool ShouldSerializecctype()
		{
			return this.cctypeSpecified;
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x000114F0 File Offset: 0x0000F6F0
		private void Resetcctype()
		{
			this.cctypeSpecified = false;
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x000114FC File Offset: 0x0000F6FC
		[ProtoMember(14, Name = "platFriendServers", DataFormat = DataFormat.Default)]
		public List<PlatFriendServer> platFriendServers
		{
			get
			{
				return this._platFriendServers;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00011514 File Offset: 0x0000F714
		[ProtoMember(15, Name = "bespeakserverids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bespeakserverids
		{
			get
			{
				return this._bespeakserverids;
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001152C File Offset: 0x0000F72C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001E3 RID: 483
		private byte[] _loginToken;

		// Token: 0x040001E4 RID: 484
		private byte[] _gateconfig;

		// Token: 0x040001E5 RID: 485
		private string _userphone;

		// Token: 0x040001E6 RID: 486
		private LoginGateData _RecommandGate = null;

		// Token: 0x040001E7 RID: 487
		private readonly List<SelfServerData> _servers = new List<SelfServerData>();

		// Token: 0x040001E8 RID: 488
		private uint? _loginzoneid;

		// Token: 0x040001E9 RID: 489
		private readonly List<LoginGateData> _allservers = new List<LoginGateData>();

		// Token: 0x040001EA RID: 490
		private bool? _in_white_list;

		// Token: 0x040001EB RID: 491
		private PlatNotice _notice = null;

		// Token: 0x040001EC RID: 492
		private ErrorCode? _error;

		// Token: 0x040001ED RID: 493
		private PlatBanAccount _baninfo = null;

		// Token: 0x040001EE RID: 494
		private bool? _freeflow;

		// Token: 0x040001EF RID: 495
		private int? _cctype;

		// Token: 0x040001F0 RID: 496
		private readonly List<PlatFriendServer> _platFriendServers = new List<PlatFriendServer>();

		// Token: 0x040001F1 RID: 497
		private readonly List<uint> _bespeakserverids = new List<uint>();

		// Token: 0x040001F2 RID: 498
		private IExtension extensionObject;
	}
}
