using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000266 RID: 614
	[ProtoContract(Name = "gmfjoinres")]
	[Serializable]
	public class gmfjoinres : IExtensible
	{
		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x06002251 RID: 8785 RVA: 0x0004310C File Offset: 0x0004130C
		// (set) Token: 0x06002252 RID: 8786 RVA: 0x00043138 File Offset: 0x00041338
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

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x06002253 RID: 8787 RVA: 0x00043148 File Offset: 0x00041348
		// (set) Token: 0x06002254 RID: 8788 RVA: 0x00043168 File Offset: 0x00041368
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

		// Token: 0x06002255 RID: 8789 RVA: 0x000431AC File Offset: 0x000413AC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x000431C4 File Offset: 0x000413C4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x000431D0 File Offset: 0x000413D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000883 RID: 2179
		private ErrorCode? _errorcode;

		// Token: 0x04000884 RID: 2180
		private IExtension extensionObject;
	}
}
