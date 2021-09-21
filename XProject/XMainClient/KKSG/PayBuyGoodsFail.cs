using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D2 RID: 978
	[ProtoContract(Name = "PayBuyGoodsFail")]
	[Serializable]
	public class PayBuyGoodsFail : IExtensible
	{
		// Token: 0x17001008 RID: 4104
		// (get) Token: 0x06003414 RID: 13332 RVA: 0x00063EE4 File Offset: 0x000620E4
		// (set) Token: 0x06003415 RID: 13333 RVA: 0x00063F05 File Offset: 0x00062105
		[ProtoMember(1, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x17001009 RID: 4105
		// (get) Token: 0x06003416 RID: 13334 RVA: 0x00063F10 File Offset: 0x00062110
		// (set) Token: 0x06003417 RID: 13335 RVA: 0x00063F2C File Offset: 0x0006212C
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x06003418 RID: 13336 RVA: 0x00063F5C File Offset: 0x0006215C
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003419 RID: 13337 RVA: 0x00063F74 File Offset: 0x00062174
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x0600341A RID: 13338 RVA: 0x00063F80 File Offset: 0x00062180
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CF0 RID: 3312
		private string _token;

		// Token: 0x04000CF1 RID: 3313
		private IExtension extensionObject;
	}
}
