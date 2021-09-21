using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000544 RID: 1348
	[ProtoContract(Name = "GetMarriagePrivilegeRes")]
	[Serializable]
	public class GetMarriagePrivilegeRes : IExtensible
	{
		// Token: 0x17001510 RID: 5392
		// (get) Token: 0x060044EA RID: 17642 RVA: 0x000830C0 File Offset: 0x000812C0
		// (set) Token: 0x060044EB RID: 17643 RVA: 0x000830EC File Offset: 0x000812EC
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17001511 RID: 5393
		// (get) Token: 0x060044EC RID: 17644 RVA: 0x000830FC File Offset: 0x000812FC
		// (set) Token: 0x060044ED RID: 17645 RVA: 0x0008311C File Offset: 0x0008131C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060044EE RID: 17646 RVA: 0x00083160 File Offset: 0x00081360
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060044EF RID: 17647 RVA: 0x00083178 File Offset: 0x00081378
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060044F0 RID: 17648 RVA: 0x00083184 File Offset: 0x00081384
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001139 RID: 4409
		private ErrorCode? _error;

		// Token: 0x0400113A RID: 4410
		private IExtension extensionObject;
	}
}
