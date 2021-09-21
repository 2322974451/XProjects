using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C0 RID: 960
	[ProtoContract(Name = "ItemComposeRes")]
	[Serializable]
	public class ItemComposeRes : IExtensible
	{
		// Token: 0x17000FD2 RID: 4050
		// (get) Token: 0x06003352 RID: 13138 RVA: 0x0006292C File Offset: 0x00060B2C
		// (set) Token: 0x06003353 RID: 13139 RVA: 0x00062958 File Offset: 0x00060B58
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

		// Token: 0x17000FD3 RID: 4051
		// (get) Token: 0x06003354 RID: 13140 RVA: 0x00062968 File Offset: 0x00060B68
		// (set) Token: 0x06003355 RID: 13141 RVA: 0x00062988 File Offset: 0x00060B88
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

		// Token: 0x06003356 RID: 13142 RVA: 0x000629CC File Offset: 0x00060BCC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x000629E4 File Offset: 0x00060BE4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x000629F0 File Offset: 0x00060BF0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CC2 RID: 3266
		private ErrorCode? _errorcode;

		// Token: 0x04000CC3 RID: 3267
		private IExtension extensionObject;
	}
}
