using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BA RID: 954
	[ProtoContract(Name = "PayFriendItemRes")]
	[Serializable]
	public class PayFriendItemRes : IExtensible
	{
		// Token: 0x17000FBA RID: 4026
		// (get) Token: 0x06003301 RID: 13057 RVA: 0x000620B8 File Offset: 0x000602B8
		// (set) Token: 0x06003302 RID: 13058 RVA: 0x000620E4 File Offset: 0x000602E4
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x17000FBB RID: 4027
		// (get) Token: 0x06003303 RID: 13059 RVA: 0x000620F4 File Offset: 0x000602F4
		// (set) Token: 0x06003304 RID: 13060 RVA: 0x00062114 File Offset: 0x00060314
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x06003305 RID: 13061 RVA: 0x00062158 File Offset: 0x00060358
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x06003306 RID: 13062 RVA: 0x00062170 File Offset: 0x00060370
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x17000FBC RID: 4028
		// (get) Token: 0x06003307 RID: 13063 RVA: 0x0006217C File Offset: 0x0006037C
		// (set) Token: 0x06003308 RID: 13064 RVA: 0x0006219D File Offset: 0x0006039D
		[ProtoMember(2, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000FBD RID: 4029
		// (get) Token: 0x06003309 RID: 13065 RVA: 0x000621A8 File Offset: 0x000603A8
		// (set) Token: 0x0600330A RID: 13066 RVA: 0x000621C4 File Offset: 0x000603C4
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

		// Token: 0x0600330B RID: 13067 RVA: 0x000621F4 File Offset: 0x000603F4
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x0600330C RID: 13068 RVA: 0x0006220C File Offset: 0x0006040C
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x17000FBE RID: 4030
		// (get) Token: 0x0600330D RID: 13069 RVA: 0x00062218 File Offset: 0x00060418
		// (set) Token: 0x0600330E RID: 13070 RVA: 0x00062239 File Offset: 0x00060439
		[ProtoMember(3, IsRequired = false, Name = "url_param", DataFormat = DataFormat.Default)]
		public string url_param
		{
			get
			{
				return this._url_param ?? "";
			}
			set
			{
				this._url_param = value;
			}
		}

		// Token: 0x17000FBF RID: 4031
		// (get) Token: 0x0600330F RID: 13071 RVA: 0x00062244 File Offset: 0x00060444
		// (set) Token: 0x06003310 RID: 13072 RVA: 0x00062260 File Offset: 0x00060460
		[XmlIgnore]
		[Browsable(false)]
		public bool url_paramSpecified
		{
			get
			{
				return this._url_param != null;
			}
			set
			{
				bool flag = value == (this._url_param == null);
				if (flag)
				{
					this._url_param = (value ? this.url_param : null);
				}
			}
		}

		// Token: 0x06003311 RID: 13073 RVA: 0x00062290 File Offset: 0x00060490
		private bool ShouldSerializeurl_param()
		{
			return this.url_paramSpecified;
		}

		// Token: 0x06003312 RID: 13074 RVA: 0x000622A8 File Offset: 0x000604A8
		private void Reseturl_param()
		{
			this.url_paramSpecified = false;
		}

		// Token: 0x17000FC0 RID: 4032
		// (get) Token: 0x06003313 RID: 13075 RVA: 0x000622B4 File Offset: 0x000604B4
		// (set) Token: 0x06003314 RID: 13076 RVA: 0x000622D5 File Offset: 0x000604D5
		[ProtoMember(4, IsRequired = false, Name = "billno", DataFormat = DataFormat.Default)]
		public string billno
		{
			get
			{
				return this._billno ?? "";
			}
			set
			{
				this._billno = value;
			}
		}

		// Token: 0x17000FC1 RID: 4033
		// (get) Token: 0x06003315 RID: 13077 RVA: 0x000622E0 File Offset: 0x000604E0
		// (set) Token: 0x06003316 RID: 13078 RVA: 0x000622FC File Offset: 0x000604FC
		[XmlIgnore]
		[Browsable(false)]
		public bool billnoSpecified
		{
			get
			{
				return this._billno != null;
			}
			set
			{
				bool flag = value == (this._billno == null);
				if (flag)
				{
					this._billno = (value ? this.billno : null);
				}
			}
		}

		// Token: 0x06003317 RID: 13079 RVA: 0x0006232C File Offset: 0x0006052C
		private bool ShouldSerializebillno()
		{
			return this.billnoSpecified;
		}

		// Token: 0x06003318 RID: 13080 RVA: 0x00062344 File Offset: 0x00060544
		private void Resetbillno()
		{
			this.billnoSpecified = false;
		}

		// Token: 0x17000FC2 RID: 4034
		// (get) Token: 0x06003319 RID: 13081 RVA: 0x00062350 File Offset: 0x00060550
		// (set) Token: 0x0600331A RID: 13082 RVA: 0x00062371 File Offset: 0x00060571
		[ProtoMember(5, IsRequired = false, Name = "paramid", DataFormat = DataFormat.Default)]
		public string paramid
		{
			get
			{
				return this._paramid ?? "";
			}
			set
			{
				this._paramid = value;
			}
		}

		// Token: 0x17000FC3 RID: 4035
		// (get) Token: 0x0600331B RID: 13083 RVA: 0x0006237C File Offset: 0x0006057C
		// (set) Token: 0x0600331C RID: 13084 RVA: 0x00062398 File Offset: 0x00060598
		[XmlIgnore]
		[Browsable(false)]
		public bool paramidSpecified
		{
			get
			{
				return this._paramid != null;
			}
			set
			{
				bool flag = value == (this._paramid == null);
				if (flag)
				{
					this._paramid = (value ? this.paramid : null);
				}
			}
		}

		// Token: 0x0600331D RID: 13085 RVA: 0x000623C8 File Offset: 0x000605C8
		private bool ShouldSerializeparamid()
		{
			return this.paramidSpecified;
		}

		// Token: 0x0600331E RID: 13086 RVA: 0x000623E0 File Offset: 0x000605E0
		private void Resetparamid()
		{
			this.paramidSpecified = false;
		}

		// Token: 0x17000FC4 RID: 4036
		// (get) Token: 0x0600331F RID: 13087 RVA: 0x000623EC File Offset: 0x000605EC
		// (set) Token: 0x06003320 RID: 13088 RVA: 0x00062418 File Offset: 0x00060618
		[ProtoMember(6, IsRequired = false, Name = "price", DataFormat = DataFormat.TwosComplement)]
		public uint price
		{
			get
			{
				return this._price ?? 0U;
			}
			set
			{
				this._price = new uint?(value);
			}
		}

		// Token: 0x17000FC5 RID: 4037
		// (get) Token: 0x06003321 RID: 13089 RVA: 0x00062428 File Offset: 0x00060628
		// (set) Token: 0x06003322 RID: 13090 RVA: 0x00062448 File Offset: 0x00060648
		[XmlIgnore]
		[Browsable(false)]
		public bool priceSpecified
		{
			get
			{
				return this._price != null;
			}
			set
			{
				bool flag = value == (this._price == null);
				if (flag)
				{
					this._price = (value ? new uint?(this.price) : null);
				}
			}
		}

		// Token: 0x06003323 RID: 13091 RVA: 0x0006248C File Offset: 0x0006068C
		private bool ShouldSerializeprice()
		{
			return this.priceSpecified;
		}

		// Token: 0x06003324 RID: 13092 RVA: 0x000624A4 File Offset: 0x000606A4
		private void Resetprice()
		{
			this.priceSpecified = false;
		}

		// Token: 0x06003325 RID: 13093 RVA: 0x000624B0 File Offset: 0x000606B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CAF RID: 3247
		private ErrorCode? _ret;

		// Token: 0x04000CB0 RID: 3248
		private string _token;

		// Token: 0x04000CB1 RID: 3249
		private string _url_param;

		// Token: 0x04000CB2 RID: 3250
		private string _billno;

		// Token: 0x04000CB3 RID: 3251
		private string _paramid;

		// Token: 0x04000CB4 RID: 3252
		private uint? _price;

		// Token: 0x04000CB5 RID: 3253
		private IExtension extensionObject;
	}
}
