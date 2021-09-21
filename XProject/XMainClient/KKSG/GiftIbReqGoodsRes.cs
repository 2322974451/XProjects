using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FA RID: 1018
	[ProtoContract(Name = "GiftIbReqGoodsRes")]
	[Serializable]
	public class GiftIbReqGoodsRes : IExtensible
	{
		// Token: 0x17001094 RID: 4244
		// (get) Token: 0x060035ED RID: 13805 RVA: 0x000674D4 File Offset: 0x000656D4
		// (set) Token: 0x060035EE RID: 13806 RVA: 0x00067500 File Offset: 0x00065700
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

		// Token: 0x17001095 RID: 4245
		// (get) Token: 0x060035EF RID: 13807 RVA: 0x00067510 File Offset: 0x00065710
		// (set) Token: 0x060035F0 RID: 13808 RVA: 0x00067530 File Offset: 0x00065730
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

		// Token: 0x060035F1 RID: 13809 RVA: 0x00067574 File Offset: 0x00065774
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060035F2 RID: 13810 RVA: 0x0006758C File Offset: 0x0006578C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x00067598 File Offset: 0x00065798
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D66 RID: 3430
		private ErrorCode? _error;

		// Token: 0x04000D67 RID: 3431
		private IExtension extensionObject;
	}
}
