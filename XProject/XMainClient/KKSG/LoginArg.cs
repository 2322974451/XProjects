using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A9 RID: 169
	[ProtoContract(Name = "LoginArg")]
	[Serializable]
	public class LoginArg : IExtensible
	{
		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00018AB8 File Offset: 0x00016CB8
		// (set) Token: 0x06000B93 RID: 2963 RVA: 0x00018AE4 File Offset: 0x00016CE4
		[ProtoMember(1, IsRequired = false, Name = "gameserverid", DataFormat = DataFormat.TwosComplement)]
		public uint gameserverid
		{
			get
			{
				return this._gameserverid ?? 0U;
			}
			set
			{
				this._gameserverid = new uint?(value);
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00018AF4 File Offset: 0x00016CF4
		// (set) Token: 0x06000B95 RID: 2965 RVA: 0x00018B14 File Offset: 0x00016D14
		[XmlIgnore]
		[Browsable(false)]
		public bool gameserveridSpecified
		{
			get
			{
				return this._gameserverid != null;
			}
			set
			{
				bool flag = value == (this._gameserverid == null);
				if (flag)
				{
					this._gameserverid = (value ? new uint?(this.gameserverid) : null);
				}
			}
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x00018B58 File Offset: 0x00016D58
		private bool ShouldSerializegameserverid()
		{
			return this.gameserveridSpecified;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00018B70 File Offset: 0x00016D70
		private void Resetgameserverid()
		{
			this.gameserveridSpecified = false;
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x00018B7C File Offset: 0x00016D7C
		// (set) Token: 0x06000B99 RID: 2969 RVA: 0x00018B99 File Offset: 0x00016D99
		[ProtoMember(2, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public byte[] token
		{
			get
			{
				return this._token ?? null;
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00018BA4 File Offset: 0x00016DA4
		// (set) Token: 0x06000B9B RID: 2971 RVA: 0x00018BC0 File Offset: 0x00016DC0
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

		// Token: 0x06000B9C RID: 2972 RVA: 0x00018BF0 File Offset: 0x00016DF0
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00018C08 File Offset: 0x00016E08
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00018C14 File Offset: 0x00016E14
		// (set) Token: 0x06000B9F RID: 2975 RVA: 0x00018C35 File Offset: 0x00016E35
		[ProtoMember(3, IsRequired = false, Name = "ios", DataFormat = DataFormat.Default)]
		public string ios
		{
			get
			{
				return this._ios ?? "";
			}
			set
			{
				this._ios = value;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00018C40 File Offset: 0x00016E40
		// (set) Token: 0x06000BA1 RID: 2977 RVA: 0x00018C5C File Offset: 0x00016E5C
		[XmlIgnore]
		[Browsable(false)]
		public bool iosSpecified
		{
			get
			{
				return this._ios != null;
			}
			set
			{
				bool flag = value == (this._ios == null);
				if (flag)
				{
					this._ios = (value ? this.ios : null);
				}
			}
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x00018C8C File Offset: 0x00016E8C
		private bool ShouldSerializeios()
		{
			return this.iosSpecified;
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00018CA4 File Offset: 0x00016EA4
		private void Resetios()
		{
			this.iosSpecified = false;
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x00018CB0 File Offset: 0x00016EB0
		// (set) Token: 0x06000BA5 RID: 2981 RVA: 0x00018CD1 File Offset: 0x00016ED1
		[ProtoMember(4, IsRequired = false, Name = "android", DataFormat = DataFormat.Default)]
		public string android
		{
			get
			{
				return this._android ?? "";
			}
			set
			{
				this._android = value;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x00018CDC File Offset: 0x00016EDC
		// (set) Token: 0x06000BA7 RID: 2983 RVA: 0x00018CF8 File Offset: 0x00016EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool androidSpecified
		{
			get
			{
				return this._android != null;
			}
			set
			{
				bool flag = value == (this._android == null);
				if (flag)
				{
					this._android = (value ? this.android : null);
				}
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00018D28 File Offset: 0x00016F28
		private bool ShouldSerializeandroid()
		{
			return this.androidSpecified;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00018D40 File Offset: 0x00016F40
		private void Resetandroid()
		{
			this.androidSpecified = false;
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x00018D4C File Offset: 0x00016F4C
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x00018D6D File Offset: 0x00016F6D
		[ProtoMember(5, IsRequired = false, Name = "pc", DataFormat = DataFormat.Default)]
		public string pc
		{
			get
			{
				return this._pc ?? "";
			}
			set
			{
				this._pc = value;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x00018D78 File Offset: 0x00016F78
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x00018D94 File Offset: 0x00016F94
		[XmlIgnore]
		[Browsable(false)]
		public bool pcSpecified
		{
			get
			{
				return this._pc != null;
			}
			set
			{
				bool flag = value == (this._pc == null);
				if (flag)
				{
					this._pc = (value ? this.pc : null);
				}
			}
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x00018DC4 File Offset: 0x00016FC4
		private bool ShouldSerializepc()
		{
			return this.pcSpecified;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00018DDC File Offset: 0x00016FDC
		private void Resetpc()
		{
			this.pcSpecified = false;
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x00018DE8 File Offset: 0x00016FE8
		// (set) Token: 0x06000BB1 RID: 2993 RVA: 0x00018E09 File Offset: 0x00017009
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

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x00018E14 File Offset: 0x00017014
		// (set) Token: 0x06000BB3 RID: 2995 RVA: 0x00018E30 File Offset: 0x00017030
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

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00018E60 File Offset: 0x00017060
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00018E78 File Offset: 0x00017078
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x00018E84 File Offset: 0x00017084
		// (set) Token: 0x06000BB7 RID: 2999 RVA: 0x00018E9C File Offset: 0x0001709C
		[ProtoMember(7, IsRequired = false, Name = "clientInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ClientInfo clientInfo
		{
			get
			{
				return this._clientInfo;
			}
			set
			{
				this._clientInfo = value;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x00018EA8 File Offset: 0x000170A8
		// (set) Token: 0x06000BB9 RID: 3001 RVA: 0x00018ED4 File Offset: 0x000170D4
		[ProtoMember(8, IsRequired = false, Name = "loginzoneid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x00018EE4 File Offset: 0x000170E4
		// (set) Token: 0x06000BBB RID: 3003 RVA: 0x00018F04 File Offset: 0x00017104
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

		// Token: 0x06000BBC RID: 3004 RVA: 0x00018F48 File Offset: 0x00017148
		private bool ShouldSerializeloginzoneid()
		{
			return this.loginzoneidSpecified;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00018F60 File Offset: 0x00017160
		private void Resetloginzoneid()
		{
			this.loginzoneidSpecified = false;
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00018F6C File Offset: 0x0001716C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002E3 RID: 739
		private uint? _gameserverid;

		// Token: 0x040002E4 RID: 740
		private byte[] _token;

		// Token: 0x040002E5 RID: 741
		private string _ios;

		// Token: 0x040002E6 RID: 742
		private string _android;

		// Token: 0x040002E7 RID: 743
		private string _pc;

		// Token: 0x040002E8 RID: 744
		private string _openid;

		// Token: 0x040002E9 RID: 745
		private ClientInfo _clientInfo = null;

		// Token: 0x040002EA RID: 746
		private uint? _loginzoneid;

		// Token: 0x040002EB RID: 747
		private IExtension extensionObject;
	}
}
