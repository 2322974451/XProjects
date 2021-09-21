using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000258 RID: 600
	[ProtoContract(Name = "GuildBindGroupReq")]
	[Serializable]
	public class GuildBindGroupReq : IExtensible
	{
		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x06002197 RID: 8599 RVA: 0x00041BF8 File Offset: 0x0003FDF8
		// (set) Token: 0x06002198 RID: 8600 RVA: 0x00041C19 File Offset: 0x0003FE19
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

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x06002199 RID: 8601 RVA: 0x00041C24 File Offset: 0x0003FE24
		// (set) Token: 0x0600219A RID: 8602 RVA: 0x00041C40 File Offset: 0x0003FE40
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

		// Token: 0x0600219B RID: 8603 RVA: 0x00041C70 File Offset: 0x0003FE70
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x00041C88 File Offset: 0x0003FE88
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x00041C94 File Offset: 0x0003FE94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000859 RID: 2137
		private string _token;

		// Token: 0x0400085A RID: 2138
		private IExtension extensionObject;
	}
}
