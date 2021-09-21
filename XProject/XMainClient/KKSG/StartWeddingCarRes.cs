using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049C RID: 1180
	[ProtoContract(Name = "StartWeddingCarRes")]
	[Serializable]
	public class StartWeddingCarRes : IExtensible
	{
		// Token: 0x170012D6 RID: 4822
		// (get) Token: 0x06003D75 RID: 15733 RVA: 0x000754EC File Offset: 0x000736EC
		// (set) Token: 0x06003D76 RID: 15734 RVA: 0x00075518 File Offset: 0x00073718
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

		// Token: 0x170012D7 RID: 4823
		// (get) Token: 0x06003D77 RID: 15735 RVA: 0x00075528 File Offset: 0x00073728
		// (set) Token: 0x06003D78 RID: 15736 RVA: 0x00075548 File Offset: 0x00073748
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

		// Token: 0x06003D79 RID: 15737 RVA: 0x0007558C File Offset: 0x0007378C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003D7A RID: 15738 RVA: 0x000755A4 File Offset: 0x000737A4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003D7B RID: 15739 RVA: 0x000755B0 File Offset: 0x000737B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F4E RID: 3918
		private ErrorCode? _result;

		// Token: 0x04000F4F RID: 3919
		private IExtension extensionObject;
	}
}
