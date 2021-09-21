using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031F RID: 799
	[ProtoContract(Name = "LeavePartnerRes")]
	[Serializable]
	public class LeavePartnerRes : IExtensible
	{
		// Token: 0x17000D98 RID: 3480
		// (get) Token: 0x06002BE0 RID: 11232 RVA: 0x00054FD4 File Offset: 0x000531D4
		// (set) Token: 0x06002BE1 RID: 11233 RVA: 0x00055000 File Offset: 0x00053200
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

		// Token: 0x17000D99 RID: 3481
		// (get) Token: 0x06002BE2 RID: 11234 RVA: 0x00055010 File Offset: 0x00053210
		// (set) Token: 0x06002BE3 RID: 11235 RVA: 0x00055030 File Offset: 0x00053230
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

		// Token: 0x06002BE4 RID: 11236 RVA: 0x00055074 File Offset: 0x00053274
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002BE5 RID: 11237 RVA: 0x0005508C File Offset: 0x0005328C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06002BE6 RID: 11238 RVA: 0x00055098 File Offset: 0x00053298
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ADE RID: 2782
		private ErrorCode? _result;

		// Token: 0x04000ADF RID: 2783
		private IExtension extensionObject;
	}
}
