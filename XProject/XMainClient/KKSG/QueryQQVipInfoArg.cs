using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E5 RID: 741
	[ProtoContract(Name = "QueryQQVipInfoArg")]
	[Serializable]
	public class QueryQQVipInfoArg : IExtensible
	{
		// Token: 0x17000CAF RID: 3247
		// (get) Token: 0x060028D6 RID: 10454 RVA: 0x0004F558 File Offset: 0x0004D758
		// (set) Token: 0x060028D7 RID: 10455 RVA: 0x0004F579 File Offset: 0x0004D779
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

		// Token: 0x17000CB0 RID: 3248
		// (get) Token: 0x060028D8 RID: 10456 RVA: 0x0004F584 File Offset: 0x0004D784
		// (set) Token: 0x060028D9 RID: 10457 RVA: 0x0004F5A0 File Offset: 0x0004D7A0
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

		// Token: 0x060028DA RID: 10458 RVA: 0x0004F5D0 File Offset: 0x0004D7D0
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x060028DB RID: 10459 RVA: 0x0004F5E8 File Offset: 0x0004D7E8
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x060028DC RID: 10460 RVA: 0x0004F5F4 File Offset: 0x0004D7F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A25 RID: 2597
		private string _token;

		// Token: 0x04000A26 RID: 2598
		private IExtension extensionObject;
	}
}
