using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000215 RID: 533
	[ProtoContract(Name = "LevelSealExchangeRes")]
	[Serializable]
	public class LevelSealExchangeRes : IExtensible
	{
		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x06001DF2 RID: 7666 RVA: 0x0003ADC0 File Offset: 0x00038FC0
		// (set) Token: 0x06001DF3 RID: 7667 RVA: 0x0003ADEC File Offset: 0x00038FEC
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x06001DF4 RID: 7668 RVA: 0x0003ADFC File Offset: 0x00038FFC
		// (set) Token: 0x06001DF5 RID: 7669 RVA: 0x0003AE1C File Offset: 0x0003901C
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x0003AE60 File Offset: 0x00039060
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x0003AE78 File Offset: 0x00039078
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06001DF8 RID: 7672 RVA: 0x0003AE84 File Offset: 0x00039084
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400077C RID: 1916
		private ErrorCode? _errcode;

		// Token: 0x0400077D RID: 1917
		private IExtension extensionObject;
	}
}
