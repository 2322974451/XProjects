using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000043 RID: 67
	[ProtoContract(Name = "JadeComposeRes")]
	[Serializable]
	public class JadeComposeRes : IExtensible
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000B78C File Offset: 0x0000998C
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000B7B8 File Offset: 0x000099B8
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000B7C8 File Offset: 0x000099C8
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000B7E8 File Offset: 0x000099E8
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000B82C File Offset: 0x00009A2C
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000B844 File Offset: 0x00009A44
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000B850 File Offset: 0x00009A50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000130 RID: 304
		private ErrorCode? _ErrorCode;

		// Token: 0x04000131 RID: 305
		private IExtension extensionObject;
	}
}
