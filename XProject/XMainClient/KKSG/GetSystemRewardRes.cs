using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000053 RID: 83
	[ProtoContract(Name = "GetSystemRewardRes")]
	[Serializable]
	public class GetSystemRewardRes : IExtensible
	{
		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x0000D404 File Offset: 0x0000B604
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

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0000D414 File Offset: 0x0000B614
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0000D434 File Offset: 0x0000B634
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

		// Token: 0x06000589 RID: 1417 RVA: 0x0000D478 File Offset: 0x0000B678
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0000D490 File Offset: 0x0000B690
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0000D49C File Offset: 0x0000B69C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000169 RID: 361
		private ErrorCode? _ErrorCode;

		// Token: 0x0400016A RID: 362
		private IExtension extensionObject;
	}
}
