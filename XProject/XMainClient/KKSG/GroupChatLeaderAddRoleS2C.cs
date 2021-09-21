using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047D RID: 1149
	[ProtoContract(Name = "GroupChatLeaderAddRoleS2C")]
	[Serializable]
	public class GroupChatLeaderAddRoleS2C : IExtensible
	{
		// Token: 0x1700126C RID: 4716
		// (get) Token: 0x06003C18 RID: 15384 RVA: 0x00072D0C File Offset: 0x00070F0C
		// (set) Token: 0x06003C19 RID: 15385 RVA: 0x00072D38 File Offset: 0x00070F38
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

		// Token: 0x1700126D RID: 4717
		// (get) Token: 0x06003C1A RID: 15386 RVA: 0x00072D48 File Offset: 0x00070F48
		// (set) Token: 0x06003C1B RID: 15387 RVA: 0x00072D68 File Offset: 0x00070F68
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

		// Token: 0x06003C1C RID: 15388 RVA: 0x00072DAC File Offset: 0x00070FAC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003C1D RID: 15389 RVA: 0x00072DC4 File Offset: 0x00070FC4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003C1E RID: 15390 RVA: 0x00072DD0 File Offset: 0x00070FD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EF1 RID: 3825
		private ErrorCode? _errorcode;

		// Token: 0x04000EF2 RID: 3826
		private IExtension extensionObject;
	}
}
