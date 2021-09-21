using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004D RID: 77
	[ProtoContract(Name = "BuyJadeSlotRes")]
	[Serializable]
	public class BuyJadeSlotRes : IExtensible
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000C8A0 File Offset: 0x0000AAA0
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000C8CC File Offset: 0x0000AACC
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

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000C8DC File Offset: 0x0000AADC
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000C8FC File Offset: 0x0000AAFC
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

		// Token: 0x0600052B RID: 1323 RVA: 0x0000C940 File Offset: 0x0000AB40
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0000C958 File Offset: 0x0000AB58
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000C964 File Offset: 0x0000AB64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000153 RID: 339
		private ErrorCode? _ErrorCode;

		// Token: 0x04000154 RID: 340
		private IExtension extensionObject;
	}
}
