using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DB RID: 987
	[ProtoContract(Name = "SkyCraftMatchRes")]
	[Serializable]
	public class SkyCraftMatchRes : IExtensible
	{
		// Token: 0x17001024 RID: 4132
		// (get) Token: 0x06003476 RID: 13430 RVA: 0x000649D8 File Offset: 0x00062BD8
		// (set) Token: 0x06003477 RID: 13431 RVA: 0x00064A04 File Offset: 0x00062C04
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

		// Token: 0x17001025 RID: 4133
		// (get) Token: 0x06003478 RID: 13432 RVA: 0x00064A14 File Offset: 0x00062C14
		// (set) Token: 0x06003479 RID: 13433 RVA: 0x00064A34 File Offset: 0x00062C34
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

		// Token: 0x0600347A RID: 13434 RVA: 0x00064A78 File Offset: 0x00062C78
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600347B RID: 13435 RVA: 0x00064A90 File Offset: 0x00062C90
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600347C RID: 13436 RVA: 0x00064A9C File Offset: 0x00062C9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D08 RID: 3336
		private ErrorCode? _result;

		// Token: 0x04000D09 RID: 3337
		private IExtension extensionObject;
	}
}
