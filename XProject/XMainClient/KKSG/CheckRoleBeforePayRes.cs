using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000496 RID: 1174
	[ProtoContract(Name = "CheckRoleBeforePayRes")]
	[Serializable]
	public class CheckRoleBeforePayRes : IExtensible
	{
		// Token: 0x170012C1 RID: 4801
		// (get) Token: 0x06003D2C RID: 15660 RVA: 0x00074C58 File Offset: 0x00072E58
		// (set) Token: 0x06003D2D RID: 15661 RVA: 0x00074C84 File Offset: 0x00072E84
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

		// Token: 0x170012C2 RID: 4802
		// (get) Token: 0x06003D2E RID: 15662 RVA: 0x00074C94 File Offset: 0x00072E94
		// (set) Token: 0x06003D2F RID: 15663 RVA: 0x00074CB4 File Offset: 0x00072EB4
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

		// Token: 0x06003D30 RID: 15664 RVA: 0x00074CF8 File Offset: 0x00072EF8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003D31 RID: 15665 RVA: 0x00074D10 File Offset: 0x00072F10
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003D32 RID: 15666 RVA: 0x00074D1C File Offset: 0x00072F1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F3D RID: 3901
		private ErrorCode? _result;

		// Token: 0x04000F3E RID: 3902
		private IExtension extensionObject;
	}
}
