using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000434 RID: 1076
	[ProtoContract(Name = "PetOperationOtherRes")]
	[Serializable]
	public class PetOperationOtherRes : IExtensible
	{
		// Token: 0x1700117C RID: 4476
		// (get) Token: 0x060038EE RID: 14574 RVA: 0x0006CF2C File Offset: 0x0006B12C
		// (set) Token: 0x060038EF RID: 14575 RVA: 0x0006CF58 File Offset: 0x0006B158
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

		// Token: 0x1700117D RID: 4477
		// (get) Token: 0x060038F0 RID: 14576 RVA: 0x0006CF68 File Offset: 0x0006B168
		// (set) Token: 0x060038F1 RID: 14577 RVA: 0x0006CF88 File Offset: 0x0006B188
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

		// Token: 0x060038F2 RID: 14578 RVA: 0x0006CFCC File Offset: 0x0006B1CC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x0006CFE4 File Offset: 0x0006B1E4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x0006CFF0 File Offset: 0x0006B1F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E20 RID: 3616
		private ErrorCode? _errorcode;

		// Token: 0x04000E21 RID: 3617
		private IExtension extensionObject;
	}
}
