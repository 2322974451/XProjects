using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000263 RID: 611
	[ProtoContract(Name = "GuildUnBindGroupReq")]
	[Serializable]
	public class GuildUnBindGroupReq : IExtensible
	{
		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x0600223F RID: 8767 RVA: 0x00042F4C File Offset: 0x0004114C
		// (set) Token: 0x06002240 RID: 8768 RVA: 0x00042F6D File Offset: 0x0004116D
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

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x06002241 RID: 8769 RVA: 0x00042F78 File Offset: 0x00041178
		// (set) Token: 0x06002242 RID: 8770 RVA: 0x00042F94 File Offset: 0x00041194
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

		// Token: 0x06002243 RID: 8771 RVA: 0x00042FC4 File Offset: 0x000411C4
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x00042FDC File Offset: 0x000411DC
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x00042FE8 File Offset: 0x000411E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400087E RID: 2174
		private string _token;

		// Token: 0x0400087F RID: 2175
		private IExtension extensionObject;
	}
}
