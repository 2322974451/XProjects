using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000404 RID: 1028
	[ProtoContract(Name = "EnchantActiveAttributeRes")]
	[Serializable]
	public class EnchantActiveAttributeRes : IExtensible
	{
		// Token: 0x170010DE RID: 4318
		// (get) Token: 0x060036D5 RID: 14037 RVA: 0x000690D4 File Offset: 0x000672D4
		// (set) Token: 0x060036D6 RID: 14038 RVA: 0x00069100 File Offset: 0x00067300
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

		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x060036D7 RID: 14039 RVA: 0x00069110 File Offset: 0x00067310
		// (set) Token: 0x060036D8 RID: 14040 RVA: 0x00069130 File Offset: 0x00067330
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

		// Token: 0x060036D9 RID: 14041 RVA: 0x00069174 File Offset: 0x00067374
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060036DA RID: 14042 RVA: 0x0006918C File Offset: 0x0006738C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060036DB RID: 14043 RVA: 0x00069198 File Offset: 0x00067398
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D98 RID: 3480
		private ErrorCode? _errorcode;

		// Token: 0x04000D99 RID: 3481
		private IExtension extensionObject;
	}
}
