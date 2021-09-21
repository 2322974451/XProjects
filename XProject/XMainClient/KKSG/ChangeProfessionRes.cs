using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000394 RID: 916
	[ProtoContract(Name = "ChangeProfessionRes")]
	[Serializable]
	public class ChangeProfessionRes : IExtensible
	{
		// Token: 0x17000F51 RID: 3921
		// (get) Token: 0x0600318C RID: 12684 RVA: 0x0005F6DC File Offset: 0x0005D8DC
		// (set) Token: 0x0600318D RID: 12685 RVA: 0x0005F708 File Offset: 0x0005D908
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

		// Token: 0x17000F52 RID: 3922
		// (get) Token: 0x0600318E RID: 12686 RVA: 0x0005F718 File Offset: 0x0005D918
		// (set) Token: 0x0600318F RID: 12687 RVA: 0x0005F738 File Offset: 0x0005D938
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

		// Token: 0x06003190 RID: 12688 RVA: 0x0005F77C File Offset: 0x0005D97C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003191 RID: 12689 RVA: 0x0005F794 File Offset: 0x0005D994
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003192 RID: 12690 RVA: 0x0005F7A0 File Offset: 0x0005D9A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C4E RID: 3150
		private ErrorCode? _errorcode;

		// Token: 0x04000C4F RID: 3151
		private IExtension extensionObject;
	}
}
