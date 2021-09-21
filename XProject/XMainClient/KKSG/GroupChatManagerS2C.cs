using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045D RID: 1117
	[ProtoContract(Name = "GroupChatManagerS2C")]
	[Serializable]
	public class GroupChatManagerS2C : IExtensible
	{
		// Token: 0x170011FF RID: 4607
		// (get) Token: 0x06003AAF RID: 15023 RVA: 0x00070360 File Offset: 0x0006E560
		// (set) Token: 0x06003AB0 RID: 15024 RVA: 0x0007038C File Offset: 0x0006E58C
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

		// Token: 0x17001200 RID: 4608
		// (get) Token: 0x06003AB1 RID: 15025 RVA: 0x0007039C File Offset: 0x0006E59C
		// (set) Token: 0x06003AB2 RID: 15026 RVA: 0x000703BC File Offset: 0x0006E5BC
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

		// Token: 0x06003AB3 RID: 15027 RVA: 0x00070400 File Offset: 0x0006E600
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x00070418 File Offset: 0x0006E618
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003AB5 RID: 15029 RVA: 0x00070424 File Offset: 0x0006E624
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E92 RID: 3730
		private ErrorCode? _errorcode;

		// Token: 0x04000E93 RID: 3731
		private IExtension extensionObject;
	}
}
