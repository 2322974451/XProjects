using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F6 RID: 1014
	[ProtoContract(Name = "GuildCampExchangeOperateRes")]
	[Serializable]
	public class GuildCampExchangeOperateRes : IExtensible
	{
		// Token: 0x1700108B RID: 4235
		// (get) Token: 0x060035CC RID: 13772 RVA: 0x00067140 File Offset: 0x00065340
		// (set) Token: 0x060035CD RID: 13773 RVA: 0x0006716C File Offset: 0x0006536C
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

		// Token: 0x1700108C RID: 4236
		// (get) Token: 0x060035CE RID: 13774 RVA: 0x0006717C File Offset: 0x0006537C
		// (set) Token: 0x060035CF RID: 13775 RVA: 0x0006719C File Offset: 0x0006539C
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

		// Token: 0x060035D0 RID: 13776 RVA: 0x000671E0 File Offset: 0x000653E0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060035D1 RID: 13777 RVA: 0x000671F8 File Offset: 0x000653F8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060035D2 RID: 13778 RVA: 0x00067204 File Offset: 0x00065404
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D5D RID: 3421
		private ErrorCode? _result;

		// Token: 0x04000D5E RID: 3422
		private IExtension extensionObject;
	}
}
