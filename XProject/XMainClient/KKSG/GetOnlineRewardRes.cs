using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C8 RID: 200
	[ProtoContract(Name = "GetOnlineRewardRes")]
	[Serializable]
	public class GetOnlineRewardRes : IExtensible
	{
		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x0001B94C File Offset: 0x00019B4C
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x0001B978 File Offset: 0x00019B78
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

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0001B988 File Offset: 0x00019B88
		// (set) Token: 0x06000D2E RID: 3374 RVA: 0x0001B9A8 File Offset: 0x00019BA8
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

		// Token: 0x06000D2F RID: 3375 RVA: 0x0001B9EC File Offset: 0x00019BEC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0001BA04 File Offset: 0x00019C04
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0001BA10 File Offset: 0x00019C10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400034D RID: 845
		private ErrorCode? _errorcode;

		// Token: 0x0400034E RID: 846
		private IExtension extensionObject;
	}
}
