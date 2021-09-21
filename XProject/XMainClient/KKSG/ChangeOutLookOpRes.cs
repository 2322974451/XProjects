using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001EF RID: 495
	[ProtoContract(Name = "ChangeOutLookOpRes")]
	[Serializable]
	public class ChangeOutLookOpRes : IExtensible
	{
		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x06001C4F RID: 7247 RVA: 0x00037CFC File Offset: 0x00035EFC
		// (set) Token: 0x06001C50 RID: 7248 RVA: 0x00037D28 File Offset: 0x00035F28
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

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x06001C51 RID: 7249 RVA: 0x00037D38 File Offset: 0x00035F38
		// (set) Token: 0x06001C52 RID: 7250 RVA: 0x00037D58 File Offset: 0x00035F58
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

		// Token: 0x06001C53 RID: 7251 RVA: 0x00037D9C File Offset: 0x00035F9C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00037DB4 File Offset: 0x00035FB4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x00037DC0 File Offset: 0x00035FC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400070C RID: 1804
		private ErrorCode? _errorcode;

		// Token: 0x0400070D RID: 1805
		private IExtension extensionObject;
	}
}
