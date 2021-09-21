using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F5 RID: 1269
	[ProtoContract(Name = "BuyDrawRes")]
	[Serializable]
	public class BuyDrawRes : IExtensible
	{
		// Token: 0x17001415 RID: 5141
		// (get) Token: 0x06004198 RID: 16792 RVA: 0x0007CE24 File Offset: 0x0007B024
		// (set) Token: 0x06004199 RID: 16793 RVA: 0x0007CE50 File Offset: 0x0007B050
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17001416 RID: 5142
		// (get) Token: 0x0600419A RID: 16794 RVA: 0x0007CE60 File Offset: 0x0007B060
		// (set) Token: 0x0600419B RID: 16795 RVA: 0x0007CE80 File Offset: 0x0007B080
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x0600419C RID: 16796 RVA: 0x0007CEC4 File Offset: 0x0007B0C4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600419D RID: 16797 RVA: 0x0007CEDC File Offset: 0x0007B0DC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600419E RID: 16798 RVA: 0x0007CEE8 File Offset: 0x0007B0E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400105C RID: 4188
		private ErrorCode? _errorcode;

		// Token: 0x0400105D RID: 4189
		private IExtension extensionObject;
	}
}
