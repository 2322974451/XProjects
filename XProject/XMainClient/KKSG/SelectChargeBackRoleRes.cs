using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000522 RID: 1314
	[ProtoContract(Name = "SelectChargeBackRoleRes")]
	[Serializable]
	public class SelectChargeBackRoleRes : IExtensible
	{
		// Token: 0x170014AA RID: 5290
		// (get) Token: 0x0600439D RID: 17309 RVA: 0x00080A34 File Offset: 0x0007EC34
		// (set) Token: 0x0600439E RID: 17310 RVA: 0x00080A60 File Offset: 0x0007EC60
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

		// Token: 0x170014AB RID: 5291
		// (get) Token: 0x0600439F RID: 17311 RVA: 0x00080A70 File Offset: 0x0007EC70
		// (set) Token: 0x060043A0 RID: 17312 RVA: 0x00080A90 File Offset: 0x0007EC90
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

		// Token: 0x060043A1 RID: 17313 RVA: 0x00080AD4 File Offset: 0x0007ECD4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060043A2 RID: 17314 RVA: 0x00080AEC File Offset: 0x0007ECEC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060043A3 RID: 17315 RVA: 0x00080AF8 File Offset: 0x0007ECF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010D9 RID: 4313
		private ErrorCode? _result;

		// Token: 0x040010DA RID: 4314
		private IExtension extensionObject;
	}
}
