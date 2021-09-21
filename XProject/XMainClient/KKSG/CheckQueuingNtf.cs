using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D9 RID: 473
	[ProtoContract(Name = "CheckQueuingNtf")]
	[Serializable]
	public class CheckQueuingNtf : IExtensible
	{
		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x06001B56 RID: 6998 RVA: 0x00036034 File Offset: 0x00034234
		// (set) Token: 0x06001B57 RID: 6999 RVA: 0x00036060 File Offset: 0x00034260
		[ProtoMember(1, IsRequired = false, Name = "rolecount", DataFormat = DataFormat.TwosComplement)]
		public uint rolecount
		{
			get
			{
				return this._rolecount ?? 0U;
			}
			set
			{
				this._rolecount = new uint?(value);
			}
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x06001B58 RID: 7000 RVA: 0x00036070 File Offset: 0x00034270
		// (set) Token: 0x06001B59 RID: 7001 RVA: 0x00036090 File Offset: 0x00034290
		[XmlIgnore]
		[Browsable(false)]
		public bool rolecountSpecified
		{
			get
			{
				return this._rolecount != null;
			}
			set
			{
				bool flag = value == (this._rolecount == null);
				if (flag)
				{
					this._rolecount = (value ? new uint?(this.rolecount) : null);
				}
			}
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x000360D4 File Offset: 0x000342D4
		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x000360EC File Offset: 0x000342EC
		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x06001B5C RID: 7004 RVA: 0x000360F8 File Offset: 0x000342F8
		// (set) Token: 0x06001B5D RID: 7005 RVA: 0x00036124 File Offset: 0x00034324
		[ProtoMember(2, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x06001B5E RID: 7006 RVA: 0x00036134 File Offset: 0x00034334
		// (set) Token: 0x06001B5F RID: 7007 RVA: 0x00036154 File Offset: 0x00034354
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06001B60 RID: 7008 RVA: 0x00036198 File Offset: 0x00034398
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x000361B0 File Offset: 0x000343B0
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x06001B62 RID: 7010 RVA: 0x000361BC File Offset: 0x000343BC
		// (set) Token: 0x06001B63 RID: 7011 RVA: 0x000361E8 File Offset: 0x000343E8
		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06001B64 RID: 7012 RVA: 0x000361F8 File Offset: 0x000343F8
		// (set) Token: 0x06001B65 RID: 7013 RVA: 0x00036218 File Offset: 0x00034418
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

		// Token: 0x06001B66 RID: 7014 RVA: 0x0003625C File Offset: 0x0003445C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x00036274 File Offset: 0x00034474
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x00036280 File Offset: 0x00034480
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006D0 RID: 1744
		private uint? _rolecount;

		// Token: 0x040006D1 RID: 1745
		private uint? _timeleft;

		// Token: 0x040006D2 RID: 1746
		private ErrorCode? _errorcode;

		// Token: 0x040006D3 RID: 1747
		private IExtension extensionObject;
	}
}
