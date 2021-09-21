using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F9 RID: 761
	[ProtoContract(Name = "ChangeNameRes")]
	[Serializable]
	public class ChangeNameRes : IExtensible
	{
		// Token: 0x17000CF5 RID: 3317
		// (get) Token: 0x060029C7 RID: 10695 RVA: 0x000510C8 File Offset: 0x0004F2C8
		// (set) Token: 0x060029C8 RID: 10696 RVA: 0x000510F4 File Offset: 0x0004F2F4
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

		// Token: 0x17000CF6 RID: 3318
		// (get) Token: 0x060029C9 RID: 10697 RVA: 0x00051104 File Offset: 0x0004F304
		// (set) Token: 0x060029CA RID: 10698 RVA: 0x00051124 File Offset: 0x0004F324
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

		// Token: 0x060029CB RID: 10699 RVA: 0x00051168 File Offset: 0x0004F368
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060029CC RID: 10700 RVA: 0x00051180 File Offset: 0x0004F380
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060029CD RID: 10701 RVA: 0x0005118C File Offset: 0x0004F38C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A5F RID: 2655
		private ErrorCode? _errorcode;

		// Token: 0x04000A60 RID: 2656
		private IExtension extensionObject;
	}
}
