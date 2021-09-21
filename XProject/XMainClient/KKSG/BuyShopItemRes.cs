using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005B RID: 91
	[ProtoContract(Name = "BuyShopItemRes")]
	[Serializable]
	public class BuyShopItemRes : IExtensible
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x0000E3B0 File Offset: 0x0000C5B0
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x0000E3DC File Offset: 0x0000C5DC
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

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x0000E3EC File Offset: 0x0000C5EC
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x0000E40C File Offset: 0x0000C60C
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

		// Token: 0x0600060D RID: 1549 RVA: 0x0000E450 File Offset: 0x0000C650
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0000E468 File Offset: 0x0000C668
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000E474 File Offset: 0x0000C674
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000189 RID: 393
		private ErrorCode? _ErrorCode;

		// Token: 0x0400018A RID: 394
		private IExtension extensionObject;
	}
}
