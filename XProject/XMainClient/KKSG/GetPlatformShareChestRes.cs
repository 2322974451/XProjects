using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CC RID: 972
	[ProtoContract(Name = "GetPlatformShareChestRes")]
	[Serializable]
	public class GetPlatformShareChestRes : IExtensible
	{
		// Token: 0x17000FF5 RID: 4085
		// (get) Token: 0x060033D1 RID: 13265 RVA: 0x00063764 File Offset: 0x00061964
		// (set) Token: 0x060033D2 RID: 13266 RVA: 0x00063790 File Offset: 0x00061990
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000FF6 RID: 4086
		// (get) Token: 0x060033D3 RID: 13267 RVA: 0x000637A0 File Offset: 0x000619A0
		// (set) Token: 0x060033D4 RID: 13268 RVA: 0x000637C0 File Offset: 0x000619C0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060033D5 RID: 13269 RVA: 0x00063804 File Offset: 0x00061A04
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x0006381C File Offset: 0x00061A1C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000FF7 RID: 4087
		// (get) Token: 0x060033D7 RID: 13271 RVA: 0x00063828 File Offset: 0x00061A28
		// (set) Token: 0x060033D8 RID: 13272 RVA: 0x00063849 File Offset: 0x00061A49
		[ProtoMember(2, IsRequired = false, Name = "boxid", DataFormat = DataFormat.Default)]
		public string boxid
		{
			get
			{
				return this._boxid ?? "";
			}
			set
			{
				this._boxid = value;
			}
		}

		// Token: 0x17000FF8 RID: 4088
		// (get) Token: 0x060033D9 RID: 13273 RVA: 0x00063854 File Offset: 0x00061A54
		// (set) Token: 0x060033DA RID: 13274 RVA: 0x00063870 File Offset: 0x00061A70
		[XmlIgnore]
		[Browsable(false)]
		public bool boxidSpecified
		{
			get
			{
				return this._boxid != null;
			}
			set
			{
				bool flag = value == (this._boxid == null);
				if (flag)
				{
					this._boxid = (value ? this.boxid : null);
				}
			}
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x000638A0 File Offset: 0x00061AA0
		private bool ShouldSerializeboxid()
		{
			return this.boxidSpecified;
		}

		// Token: 0x060033DC RID: 13276 RVA: 0x000638B8 File Offset: 0x00061AB8
		private void Resetboxid()
		{
			this.boxidSpecified = false;
		}

		// Token: 0x17000FF9 RID: 4089
		// (get) Token: 0x060033DD RID: 13277 RVA: 0x000638C4 File Offset: 0x00061AC4
		// (set) Token: 0x060033DE RID: 13278 RVA: 0x000638F0 File Offset: 0x00061AF0
		[ProtoMember(3, IsRequired = false, Name = "act_id", DataFormat = DataFormat.TwosComplement)]
		public uint act_id
		{
			get
			{
				return this._act_id ?? 0U;
			}
			set
			{
				this._act_id = new uint?(value);
			}
		}

		// Token: 0x17000FFA RID: 4090
		// (get) Token: 0x060033DF RID: 13279 RVA: 0x00063900 File Offset: 0x00061B00
		// (set) Token: 0x060033E0 RID: 13280 RVA: 0x00063920 File Offset: 0x00061B20
		[XmlIgnore]
		[Browsable(false)]
		public bool act_idSpecified
		{
			get
			{
				return this._act_id != null;
			}
			set
			{
				bool flag = value == (this._act_id == null);
				if (flag)
				{
					this._act_id = (value ? new uint?(this.act_id) : null);
				}
			}
		}

		// Token: 0x060033E1 RID: 13281 RVA: 0x00063964 File Offset: 0x00061B64
		private bool ShouldSerializeact_id()
		{
			return this.act_idSpecified;
		}

		// Token: 0x060033E2 RID: 13282 RVA: 0x0006397C File Offset: 0x00061B7C
		private void Resetact_id()
		{
			this.act_idSpecified = false;
		}

		// Token: 0x17000FFB RID: 4091
		// (get) Token: 0x060033E3 RID: 13283 RVA: 0x00063988 File Offset: 0x00061B88
		// (set) Token: 0x060033E4 RID: 13284 RVA: 0x000639A9 File Offset: 0x00061BA9
		[ProtoMember(4, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		// Token: 0x17000FFC RID: 4092
		// (get) Token: 0x060033E5 RID: 13285 RVA: 0x000639B4 File Offset: 0x00061BB4
		// (set) Token: 0x060033E6 RID: 13286 RVA: 0x000639D0 File Offset: 0x00061BD0
		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x00063A00 File Offset: 0x00061C00
		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		// Token: 0x060033E8 RID: 13288 RVA: 0x00063A18 File Offset: 0x00061C18
		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x00063A24 File Offset: 0x00061C24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CE0 RID: 3296
		private ErrorCode? _errorcode;

		// Token: 0x04000CE1 RID: 3297
		private string _boxid;

		// Token: 0x04000CE2 RID: 3298
		private uint? _act_id;

		// Token: 0x04000CE3 RID: 3299
		private string _url;

		// Token: 0x04000CE4 RID: 3300
		private IExtension extensionObject;
	}
}
