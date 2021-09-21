using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CA RID: 202
	[ProtoContract(Name = "GetNextDayRewardRes")]
	[Serializable]
	public class GetNextDayRewardRes : IExtensible
	{
		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000D35 RID: 3381 RVA: 0x0001BA50 File Offset: 0x00019C50
		// (set) Token: 0x06000D36 RID: 3382 RVA: 0x0001BA7C File Offset: 0x00019C7C
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

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000D37 RID: 3383 RVA: 0x0001BA8C File Offset: 0x00019C8C
		// (set) Token: 0x06000D38 RID: 3384 RVA: 0x0001BAAC File Offset: 0x00019CAC
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

		// Token: 0x06000D39 RID: 3385 RVA: 0x0001BAF0 File Offset: 0x00019CF0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x0001BB08 File Offset: 0x00019D08
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0001BB14 File Offset: 0x00019D14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000350 RID: 848
		private ErrorCode? _errorcode;

		// Token: 0x04000351 RID: 849
		private IExtension extensionObject;
	}
}
