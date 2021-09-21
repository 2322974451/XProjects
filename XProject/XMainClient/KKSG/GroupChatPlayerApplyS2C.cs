using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000459 RID: 1113
	[ProtoContract(Name = "GroupChatPlayerApplyS2C")]
	[Serializable]
	public class GroupChatPlayerApplyS2C : IExtensible
	{
		// Token: 0x170011F4 RID: 4596
		// (get) Token: 0x06003A8C RID: 14988 RVA: 0x0006FF54 File Offset: 0x0006E154
		// (set) Token: 0x06003A8D RID: 14989 RVA: 0x0006FF80 File Offset: 0x0006E180
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

		// Token: 0x170011F5 RID: 4597
		// (get) Token: 0x06003A8E RID: 14990 RVA: 0x0006FF90 File Offset: 0x0006E190
		// (set) Token: 0x06003A8F RID: 14991 RVA: 0x0006FFB0 File Offset: 0x0006E1B0
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

		// Token: 0x06003A90 RID: 14992 RVA: 0x0006FFF4 File Offset: 0x0006E1F4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A91 RID: 14993 RVA: 0x0007000C File Offset: 0x0006E20C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A92 RID: 14994 RVA: 0x00070018 File Offset: 0x0006E218
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E87 RID: 3719
		private ErrorCode? _errorcode;

		// Token: 0x04000E88 RID: 3720
		private IExtension extensionObject;
	}
}
