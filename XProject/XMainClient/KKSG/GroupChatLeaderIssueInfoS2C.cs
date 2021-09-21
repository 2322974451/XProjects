using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000455 RID: 1109
	[ProtoContract(Name = "GroupChatLeaderIssueInfoS2C")]
	[Serializable]
	public class GroupChatLeaderIssueInfoS2C : IExtensible
	{
		// Token: 0x170011E4 RID: 4580
		// (get) Token: 0x06003A54 RID: 14932 RVA: 0x0006F8B4 File Offset: 0x0006DAB4
		// (set) Token: 0x06003A55 RID: 14933 RVA: 0x0006F8E0 File Offset: 0x0006DAE0
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

		// Token: 0x170011E5 RID: 4581
		// (get) Token: 0x06003A56 RID: 14934 RVA: 0x0006F8F0 File Offset: 0x0006DAF0
		// (set) Token: 0x06003A57 RID: 14935 RVA: 0x0006F910 File Offset: 0x0006DB10
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

		// Token: 0x06003A58 RID: 14936 RVA: 0x0006F954 File Offset: 0x0006DB54
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A59 RID: 14937 RVA: 0x0006F96C File Offset: 0x0006DB6C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A5A RID: 14938 RVA: 0x0006F978 File Offset: 0x0006DB78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E7B RID: 3707
		private ErrorCode? _errorcode;

		// Token: 0x04000E7C RID: 3708
		private IExtension extensionObject;
	}
}
