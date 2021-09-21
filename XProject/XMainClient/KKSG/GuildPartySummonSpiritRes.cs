using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000514 RID: 1300
	[ProtoContract(Name = "GuildPartySummonSpiritRes")]
	[Serializable]
	public class GuildPartySummonSpiritRes : IExtensible
	{
		// Token: 0x17001471 RID: 5233
		// (get) Token: 0x060042DB RID: 17115 RVA: 0x0007F36C File Offset: 0x0007D56C
		// (set) Token: 0x060042DC RID: 17116 RVA: 0x0007F398 File Offset: 0x0007D598
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

		// Token: 0x17001472 RID: 5234
		// (get) Token: 0x060042DD RID: 17117 RVA: 0x0007F3A8 File Offset: 0x0007D5A8
		// (set) Token: 0x060042DE RID: 17118 RVA: 0x0007F3C8 File Offset: 0x0007D5C8
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

		// Token: 0x060042DF RID: 17119 RVA: 0x0007F40C File Offset: 0x0007D60C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060042E0 RID: 17120 RVA: 0x0007F424 File Offset: 0x0007D624
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060042E1 RID: 17121 RVA: 0x0007F430 File Offset: 0x0007D630
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010AD RID: 4269
		private ErrorCode? _result;

		// Token: 0x040010AE RID: 4270
		private IExtension extensionObject;
	}
}
