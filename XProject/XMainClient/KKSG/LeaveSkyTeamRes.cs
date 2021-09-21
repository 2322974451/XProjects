using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D9 RID: 985
	[ProtoContract(Name = "LeaveSkyTeamRes")]
	[Serializable]
	public class LeaveSkyTeamRes : IExtensible
	{
		// Token: 0x17001020 RID: 4128
		// (get) Token: 0x06003466 RID: 13414 RVA: 0x00064810 File Offset: 0x00062A10
		// (set) Token: 0x06003467 RID: 13415 RVA: 0x0006483C File Offset: 0x00062A3C
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001021 RID: 4129
		// (get) Token: 0x06003468 RID: 13416 RVA: 0x0006484C File Offset: 0x00062A4C
		// (set) Token: 0x06003469 RID: 13417 RVA: 0x0006486C File Offset: 0x00062A6C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x000648B0 File Offset: 0x00062AB0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000648C8 File Offset: 0x00062AC8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000648D4 File Offset: 0x00062AD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D04 RID: 3332
		private ErrorCode? _result;

		// Token: 0x04000D05 RID: 3333
		private IExtension extensionObject;
	}
}
