using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045F RID: 1119
	[ProtoContract(Name = "GroupChatQuitS2C")]
	[Serializable]
	public class GroupChatQuitS2C : IExtensible
	{
		// Token: 0x17001203 RID: 4611
		// (get) Token: 0x06003ABF RID: 15039 RVA: 0x00070528 File Offset: 0x0006E728
		// (set) Token: 0x06003AC0 RID: 15040 RVA: 0x00070554 File Offset: 0x0006E754
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

		// Token: 0x17001204 RID: 4612
		// (get) Token: 0x06003AC1 RID: 15041 RVA: 0x00070564 File Offset: 0x0006E764
		// (set) Token: 0x06003AC2 RID: 15042 RVA: 0x00070584 File Offset: 0x0006E784
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

		// Token: 0x06003AC3 RID: 15043 RVA: 0x000705C8 File Offset: 0x0006E7C8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003AC4 RID: 15044 RVA: 0x000705E0 File Offset: 0x0006E7E0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003AC5 RID: 15045 RVA: 0x000705EC File Offset: 0x0006E7EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E96 RID: 3734
		private ErrorCode? _errorcode;

		// Token: 0x04000E97 RID: 3735
		private IExtension extensionObject;
	}
}
