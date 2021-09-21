using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041A RID: 1050
	[ProtoContract(Name = "GetPlatShareAwardRes")]
	[Serializable]
	public class GetPlatShareAwardRes : IExtensible
	{
		// Token: 0x17001126 RID: 4390
		// (get) Token: 0x060037D1 RID: 14289 RVA: 0x0006ADFC File Offset: 0x00068FFC
		// (set) Token: 0x060037D2 RID: 14290 RVA: 0x0006AE28 File Offset: 0x00069028
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

		// Token: 0x17001127 RID: 4391
		// (get) Token: 0x060037D3 RID: 14291 RVA: 0x0006AE38 File Offset: 0x00069038
		// (set) Token: 0x060037D4 RID: 14292 RVA: 0x0006AE58 File Offset: 0x00069058
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

		// Token: 0x060037D5 RID: 14293 RVA: 0x0006AE9C File Offset: 0x0006909C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060037D6 RID: 14294 RVA: 0x0006AEB4 File Offset: 0x000690B4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060037D7 RID: 14295 RVA: 0x0006AEC0 File Offset: 0x000690C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DD4 RID: 3540
		private ErrorCode? _result;

		// Token: 0x04000DD5 RID: 3541
		private IExtension extensionObject;
	}
}
