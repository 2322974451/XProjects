using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028D RID: 653
	[ProtoContract(Name = "GetGuildWageReward")]
	[Serializable]
	public class GetGuildWageReward : IExtensible
	{
		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x060024AE RID: 9390 RVA: 0x000478D0 File Offset: 0x00045AD0
		// (set) Token: 0x060024AF RID: 9391 RVA: 0x000478FC File Offset: 0x00045AFC
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

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x060024B0 RID: 9392 RVA: 0x0004790C File Offset: 0x00045B0C
		// (set) Token: 0x060024B1 RID: 9393 RVA: 0x0004792C File Offset: 0x00045B2C
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

		// Token: 0x060024B2 RID: 9394 RVA: 0x00047970 File Offset: 0x00045B70
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00047988 File Offset: 0x00045B88
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x00047994 File Offset: 0x00045B94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400090F RID: 2319
		private ErrorCode? _errorcode;

		// Token: 0x04000910 RID: 2320
		private IExtension extensionObject;
	}
}
