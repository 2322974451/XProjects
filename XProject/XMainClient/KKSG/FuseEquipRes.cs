using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004EA RID: 1258
	[ProtoContract(Name = "FuseEquipRes")]
	[Serializable]
	public class FuseEquipRes : IExtensible
	{
		// Token: 0x170013E4 RID: 5092
		// (get) Token: 0x06004104 RID: 16644 RVA: 0x0007BCD0 File Offset: 0x00079ED0
		// (set) Token: 0x06004105 RID: 16645 RVA: 0x0007BCFC File Offset: 0x00079EFC
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

		// Token: 0x170013E5 RID: 5093
		// (get) Token: 0x06004106 RID: 16646 RVA: 0x0007BD0C File Offset: 0x00079F0C
		// (set) Token: 0x06004107 RID: 16647 RVA: 0x0007BD2C File Offset: 0x00079F2C
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

		// Token: 0x06004108 RID: 16648 RVA: 0x0007BD70 File Offset: 0x00079F70
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004109 RID: 16649 RVA: 0x0007BD88 File Offset: 0x00079F88
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600410A RID: 16650 RVA: 0x0007BD94 File Offset: 0x00079F94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001032 RID: 4146
		private ErrorCode? _errorcode;

		// Token: 0x04001033 RID: 4147
		private IExtension extensionObject;
	}
}
