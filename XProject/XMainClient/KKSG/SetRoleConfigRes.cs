using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000EE RID: 238
	[ProtoContract(Name = "SetRoleConfigRes")]
	[Serializable]
	public class SetRoleConfigRes : IExtensible
	{
		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0001F468 File Offset: 0x0001D668
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x0001F494 File Offset: 0x0001D694
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

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x0001F4A4 File Offset: 0x0001D6A4
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x0001F4C4 File Offset: 0x0001D6C4
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

		// Token: 0x06000F2D RID: 3885 RVA: 0x0001F508 File Offset: 0x0001D708
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0001F520 File Offset: 0x0001D720
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x0001F52C File Offset: 0x0001D72C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003CF RID: 975
		private ErrorCode? _errorcode;

		// Token: 0x040003D0 RID: 976
		private IExtension extensionObject;
	}
}
