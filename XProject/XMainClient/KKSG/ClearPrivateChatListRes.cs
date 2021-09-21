using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001EA RID: 490
	[ProtoContract(Name = "ClearPrivateChatListRes")]
	[Serializable]
	public class ClearPrivateChatListRes : IExtensible
	{
		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x06001C2A RID: 7210 RVA: 0x00037914 File Offset: 0x00035B14
		// (set) Token: 0x06001C2B RID: 7211 RVA: 0x00037940 File Offset: 0x00035B40
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

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x06001C2C RID: 7212 RVA: 0x00037950 File Offset: 0x00035B50
		// (set) Token: 0x06001C2D RID: 7213 RVA: 0x00037970 File Offset: 0x00035B70
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

		// Token: 0x06001C2E RID: 7214 RVA: 0x000379B4 File Offset: 0x00035BB4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x000379CC File Offset: 0x00035BCC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001C30 RID: 7216 RVA: 0x000379D8 File Offset: 0x00035BD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000701 RID: 1793
		private ErrorCode? _errorcode;

		// Token: 0x04000702 RID: 1794
		private IExtension extensionObject;
	}
}
