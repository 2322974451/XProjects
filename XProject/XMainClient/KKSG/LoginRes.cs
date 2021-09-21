using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AA RID: 170
	[ProtoContract(Name = "LoginRes")]
	[Serializable]
	public class LoginRes : IExtensible
	{
		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x00018FAC File Offset: 0x000171AC
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x00018FD8 File Offset: 0x000171D8
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x00018FE8 File Offset: 0x000171E8
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x00019008 File Offset: 0x00017208
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0001904C File Offset: 0x0001724C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x00019064 File Offset: 0x00017264
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x00019070 File Offset: 0x00017270
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x00019091 File Offset: 0x00017291
		[ProtoMember(2, IsRequired = false, Name = "version", DataFormat = DataFormat.Default)]
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

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0001909C File Offset: 0x0001729C
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x000190B8 File Offset: 0x000172B8
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

		// Token: 0x06000BCA RID: 3018 RVA: 0x000190E8 File Offset: 0x000172E8
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x00019100 File Offset: 0x00017300
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0001910C File Offset: 0x0001730C
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x00019124 File Offset: 0x00017324
		[ProtoMember(3, IsRequired = false, Name = "accountData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoadAccountData accountData
		{
			get
			{
				return this._accountData;
			}
			set
			{
				this._accountData = value;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00019130 File Offset: 0x00017330
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x0001915C File Offset: 0x0001735C
		[ProtoMember(4, IsRequired = false, Name = "function_open", DataFormat = DataFormat.TwosComplement)]
		public uint function_open
		{
			get
			{
				return this._function_open ?? 0U;
			}
			set
			{
				this._function_open = new uint?(value);
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0001916C File Offset: 0x0001736C
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x0001918C File Offset: 0x0001738C
		[XmlIgnore]
		[Browsable(false)]
		public bool function_openSpecified
		{
			get
			{
				return this._function_open != null;
			}
			set
			{
				bool flag = value == (this._function_open == null);
				if (flag)
				{
					this._function_open = (value ? new uint?(this.function_open) : null);
				}
			}
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x000191D0 File Offset: 0x000173D0
		private bool ShouldSerializefunction_open()
		{
			return this.function_openSpecified;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x000191E8 File Offset: 0x000173E8
		private void Resetfunction_open()
		{
			this.function_openSpecified = false;
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x000191F4 File Offset: 0x000173F4
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x0001920C File Offset: 0x0001740C
		[ProtoMember(5, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginExtraData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x00019218 File Offset: 0x00017418
		// (set) Token: 0x06000BD7 RID: 3031 RVA: 0x00019230 File Offset: 0x00017430
		[ProtoMember(6, IsRequired = false, Name = "rinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginReconnectInfo rinfo
		{
			get
			{
				return this._rinfo;
			}
			set
			{
				this._rinfo = value;
			}
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0001923C File Offset: 0x0001743C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002EC RID: 748
		private ErrorCode? _result;

		// Token: 0x040002ED RID: 749
		private string _version;

		// Token: 0x040002EE RID: 750
		private LoadAccountData _accountData = null;

		// Token: 0x040002EF RID: 751
		private uint? _function_open;

		// Token: 0x040002F0 RID: 752
		private LoginExtraData _data = null;

		// Token: 0x040002F1 RID: 753
		private LoginReconnectInfo _rinfo = null;

		// Token: 0x040002F2 RID: 754
		private IExtension extensionObject;
	}
}
