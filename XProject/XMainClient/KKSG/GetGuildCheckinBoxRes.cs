using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B2 RID: 178
	[ProtoContract(Name = "GetGuildCheckinBoxRes")]
	[Serializable]
	public class GetGuildCheckinBoxRes : IExtensible
	{
		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x00019D30 File Offset: 0x00017F30
		// (set) Token: 0x06000C37 RID: 3127 RVA: 0x00019D5C File Offset: 0x00017F5C
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

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x00019D6C File Offset: 0x00017F6C
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x00019D8C File Offset: 0x00017F8C
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

		// Token: 0x06000C3A RID: 3130 RVA: 0x00019DD0 File Offset: 0x00017FD0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00019DE8 File Offset: 0x00017FE8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00019DF4 File Offset: 0x00017FF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000307 RID: 775
		private ErrorCode? _errorcode;

		// Token: 0x04000308 RID: 776
		private IExtension extensionObject;
	}
}
