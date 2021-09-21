using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000550 RID: 1360
	[ProtoContract(Name = "BuyJadeSlotNewRes")]
	[Serializable]
	public class BuyJadeSlotNewRes : IExtensible
	{
		// Token: 0x17001543 RID: 5443
		// (get) Token: 0x06004598 RID: 17816 RVA: 0x0008446C File Offset: 0x0008266C
		// (set) Token: 0x06004599 RID: 17817 RVA: 0x00084498 File Offset: 0x00082698
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

		// Token: 0x17001544 RID: 5444
		// (get) Token: 0x0600459A RID: 17818 RVA: 0x000844A8 File Offset: 0x000826A8
		// (set) Token: 0x0600459B RID: 17819 RVA: 0x000844C8 File Offset: 0x000826C8
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

		// Token: 0x0600459C RID: 17820 RVA: 0x0008450C File Offset: 0x0008270C
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600459D RID: 17821 RVA: 0x00084524 File Offset: 0x00082724
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x0600459E RID: 17822 RVA: 0x00084530 File Offset: 0x00082730
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001160 RID: 4448
		private ErrorCode? _ErrorCode;

		// Token: 0x04001161 RID: 4449
		private IExtension extensionObject;
	}
}
