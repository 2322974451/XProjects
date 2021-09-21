using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000313 RID: 787
	[ProtoContract(Name = "UpdateMentorApplyStudentInfoRes")]
	[Serializable]
	public class UpdateMentorApplyStudentInfoRes : IExtensible
	{
		// Token: 0x17000D5D RID: 3421
		// (get) Token: 0x06002B21 RID: 11041 RVA: 0x000538FC File Offset: 0x00051AFC
		// (set) Token: 0x06002B22 RID: 11042 RVA: 0x00053928 File Offset: 0x00051B28
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000D5E RID: 3422
		// (get) Token: 0x06002B23 RID: 11043 RVA: 0x00053938 File Offset: 0x00051B38
		// (set) Token: 0x06002B24 RID: 11044 RVA: 0x00053958 File Offset: 0x00051B58
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06002B25 RID: 11045 RVA: 0x0005399C File Offset: 0x00051B9C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002B26 RID: 11046 RVA: 0x000539B4 File Offset: 0x00051BB4
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06002B27 RID: 11047 RVA: 0x000539C0 File Offset: 0x00051BC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AB2 RID: 2738
		private ErrorCode? _error;

		// Token: 0x04000AB3 RID: 2739
		private IExtension extensionObject;
	}
}
