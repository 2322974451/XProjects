using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000338 RID: 824
	[ProtoContract(Name = "BuyPartnerShopItemRes")]
	[Serializable]
	public class BuyPartnerShopItemRes : IExtensible
	{
		// Token: 0x17000E0F RID: 3599
		// (get) Token: 0x06002D4F RID: 11599 RVA: 0x00057AF0 File Offset: 0x00055CF0
		// (set) Token: 0x06002D50 RID: 11600 RVA: 0x00057B1C File Offset: 0x00055D1C
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000E10 RID: 3600
		// (get) Token: 0x06002D51 RID: 11601 RVA: 0x00057B2C File Offset: 0x00055D2C
		// (set) Token: 0x06002D52 RID: 11602 RVA: 0x00057B4C File Offset: 0x00055D4C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x00057B90 File Offset: 0x00055D90
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002D54 RID: 11604 RVA: 0x00057BA8 File Offset: 0x00055DA8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06002D55 RID: 11605 RVA: 0x00057BB4 File Offset: 0x00055DB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B3E RID: 2878
		private ErrorCode? _result;

		// Token: 0x04000B3F RID: 2879
		private IExtension extensionObject;
	}
}
