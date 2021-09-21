using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E8 RID: 744
	[ProtoContract(Name = "DailyTaskGiveUpRes")]
	[Serializable]
	public class DailyTaskGiveUpRes : IExtensible
	{
		// Token: 0x17000CB4 RID: 3252
		// (get) Token: 0x060028EA RID: 10474 RVA: 0x0004F74C File Offset: 0x0004D94C
		// (set) Token: 0x060028EB RID: 10475 RVA: 0x0004F778 File Offset: 0x0004D978
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

		// Token: 0x17000CB5 RID: 3253
		// (get) Token: 0x060028EC RID: 10476 RVA: 0x0004F788 File Offset: 0x0004D988
		// (set) Token: 0x060028ED RID: 10477 RVA: 0x0004F7A8 File Offset: 0x0004D9A8
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

		// Token: 0x060028EE RID: 10478 RVA: 0x0004F7EC File Offset: 0x0004D9EC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060028EF RID: 10479 RVA: 0x0004F804 File Offset: 0x0004DA04
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060028F0 RID: 10480 RVA: 0x0004F810 File Offset: 0x0004DA10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A2B RID: 2603
		private ErrorCode? _result;

		// Token: 0x04000A2C RID: 2604
		private IExtension extensionObject;
	}
}
