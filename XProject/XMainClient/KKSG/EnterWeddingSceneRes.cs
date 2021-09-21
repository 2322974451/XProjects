using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000474 RID: 1140
	[ProtoContract(Name = "EnterWeddingSceneRes")]
	[Serializable]
	public class EnterWeddingSceneRes : IExtensible
	{
		// Token: 0x1700123E RID: 4670
		// (get) Token: 0x06003B81 RID: 15233 RVA: 0x00071B48 File Offset: 0x0006FD48
		// (set) Token: 0x06003B82 RID: 15234 RVA: 0x00071B74 File Offset: 0x0006FD74
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

		// Token: 0x1700123F RID: 4671
		// (get) Token: 0x06003B83 RID: 15235 RVA: 0x00071B84 File Offset: 0x0006FD84
		// (set) Token: 0x06003B84 RID: 15236 RVA: 0x00071BA4 File Offset: 0x0006FDA4
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

		// Token: 0x06003B85 RID: 15237 RVA: 0x00071BE8 File Offset: 0x0006FDE8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003B86 RID: 15238 RVA: 0x00071C00 File Offset: 0x0006FE00
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003B87 RID: 15239 RVA: 0x00071C0C File Offset: 0x0006FE0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ECF RID: 3791
		private ErrorCode? _result;

		// Token: 0x04000ED0 RID: 3792
		private IExtension extensionObject;
	}
}
