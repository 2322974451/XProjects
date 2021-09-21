using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038A RID: 906
	[ProtoContract(Name = "ForgeEquipRes")]
	[Serializable]
	public class ForgeEquipRes : IExtensible
	{
		// Token: 0x17000F35 RID: 3893
		// (get) Token: 0x06003128 RID: 12584 RVA: 0x0005EBA0 File Offset: 0x0005CDA0
		// (set) Token: 0x06003129 RID: 12585 RVA: 0x0005EBCC File Offset: 0x0005CDCC
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

		// Token: 0x17000F36 RID: 3894
		// (get) Token: 0x0600312A RID: 12586 RVA: 0x0005EBDC File Offset: 0x0005CDDC
		// (set) Token: 0x0600312B RID: 12587 RVA: 0x0005EBFC File Offset: 0x0005CDFC
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

		// Token: 0x0600312C RID: 12588 RVA: 0x0005EC40 File Offset: 0x0005CE40
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x0005EC58 File Offset: 0x0005CE58
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x0005EC64 File Offset: 0x0005CE64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C35 RID: 3125
		private ErrorCode? _errorcode;

		// Token: 0x04000C36 RID: 3126
		private IExtension extensionObject;
	}
}
