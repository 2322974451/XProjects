using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000324 RID: 804
	[ProtoContract(Name = "CancelLeavePartnerRes")]
	[Serializable]
	public class CancelLeavePartnerRes : IExtensible
	{
		// Token: 0x17000DBB RID: 3515
		// (get) Token: 0x06002C49 RID: 11337 RVA: 0x00055C88 File Offset: 0x00053E88
		// (set) Token: 0x06002C4A RID: 11338 RVA: 0x00055CB4 File Offset: 0x00053EB4
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

		// Token: 0x17000DBC RID: 3516
		// (get) Token: 0x06002C4B RID: 11339 RVA: 0x00055CC4 File Offset: 0x00053EC4
		// (set) Token: 0x06002C4C RID: 11340 RVA: 0x00055CE4 File Offset: 0x00053EE4
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

		// Token: 0x06002C4D RID: 11341 RVA: 0x00055D28 File Offset: 0x00053F28
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x00055D40 File Offset: 0x00053F40
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x00055D4C File Offset: 0x00053F4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AF7 RID: 2807
		private ErrorCode? _result;

		// Token: 0x04000AF8 RID: 2808
		private IExtension extensionObject;
	}
}
