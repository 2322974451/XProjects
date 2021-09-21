using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000453 RID: 1107
	[ProtoContract(Name = "GroupChatPlayerIssueInfoS2C")]
	[Serializable]
	public class GroupChatPlayerIssueInfoS2C : IExtensible
	{
		// Token: 0x170011E1 RID: 4577
		// (get) Token: 0x06003A48 RID: 14920 RVA: 0x0006F77C File Offset: 0x0006D97C
		// (set) Token: 0x06003A49 RID: 14921 RVA: 0x0006F7A8 File Offset: 0x0006D9A8
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

		// Token: 0x170011E2 RID: 4578
		// (get) Token: 0x06003A4A RID: 14922 RVA: 0x0006F7B8 File Offset: 0x0006D9B8
		// (set) Token: 0x06003A4B RID: 14923 RVA: 0x0006F7D8 File Offset: 0x0006D9D8
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

		// Token: 0x06003A4C RID: 14924 RVA: 0x0006F81C File Offset: 0x0006DA1C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A4D RID: 14925 RVA: 0x0006F834 File Offset: 0x0006DA34
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A4E RID: 14926 RVA: 0x0006F840 File Offset: 0x0006DA40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E77 RID: 3703
		private ErrorCode? _errorcode;

		// Token: 0x04000E78 RID: 3704
		private IExtension extensionObject;
	}
}
