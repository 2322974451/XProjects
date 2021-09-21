using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004EF RID: 1263
	[ProtoContract(Name = "TurnOverWeeklyTaskItemRes")]
	[Serializable]
	public class TurnOverWeeklyTaskItemRes : IExtensible
	{
		// Token: 0x170013EE RID: 5102
		// (get) Token: 0x06004128 RID: 16680 RVA: 0x0007C0D8 File Offset: 0x0007A2D8
		// (set) Token: 0x06004129 RID: 16681 RVA: 0x0007C104 File Offset: 0x0007A304
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

		// Token: 0x170013EF RID: 5103
		// (get) Token: 0x0600412A RID: 16682 RVA: 0x0007C114 File Offset: 0x0007A314
		// (set) Token: 0x0600412B RID: 16683 RVA: 0x0007C134 File Offset: 0x0007A334
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

		// Token: 0x0600412C RID: 16684 RVA: 0x0007C178 File Offset: 0x0007A378
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600412D RID: 16685 RVA: 0x0007C190 File Offset: 0x0007A390
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600412E RID: 16686 RVA: 0x0007C19C File Offset: 0x0007A39C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400103D RID: 4157
		private ErrorCode? _result;

		// Token: 0x0400103E RID: 4158
		private IExtension extensionObject;
	}
}
