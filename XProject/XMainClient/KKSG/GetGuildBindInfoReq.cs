using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025A RID: 602
	[ProtoContract(Name = "GetGuildBindInfoReq")]
	[Serializable]
	public class GetGuildBindInfoReq : IExtensible
	{
		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x060021B3 RID: 8627 RVA: 0x00041F24 File Offset: 0x00040124
		// (set) Token: 0x060021B4 RID: 8628 RVA: 0x00041F45 File Offset: 0x00040145
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

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x060021B5 RID: 8629 RVA: 0x00041F50 File Offset: 0x00040150
		// (set) Token: 0x060021B6 RID: 8630 RVA: 0x00041F6C File Offset: 0x0004016C
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

		// Token: 0x060021B7 RID: 8631 RVA: 0x00041F9C File Offset: 0x0004019C
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x00041FB4 File Offset: 0x000401B4
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x00041FC0 File Offset: 0x000401C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400085F RID: 2143
		private string _token;

		// Token: 0x04000860 RID: 2144
		private IExtension extensionObject;
	}
}
