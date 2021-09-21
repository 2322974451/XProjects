using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CA RID: 1226
	[ProtoContract(Name = "GetDragonGuildBindInfoArg")]
	[Serializable]
	public class GetDragonGuildBindInfoArg : IExtensible
	{
		// Token: 0x17001385 RID: 4997
		// (get) Token: 0x06003FB8 RID: 16312 RVA: 0x00079750 File Offset: 0x00077950
		// (set) Token: 0x06003FB9 RID: 16313 RVA: 0x00079771 File Offset: 0x00077971
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

		// Token: 0x17001386 RID: 4998
		// (get) Token: 0x06003FBA RID: 16314 RVA: 0x0007977C File Offset: 0x0007797C
		// (set) Token: 0x06003FBB RID: 16315 RVA: 0x00079798 File Offset: 0x00077998
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

		// Token: 0x06003FBC RID: 16316 RVA: 0x000797C8 File Offset: 0x000779C8
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003FBD RID: 16317 RVA: 0x000797E0 File Offset: 0x000779E0
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06003FBE RID: 16318 RVA: 0x000797EC File Offset: 0x000779EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FDE RID: 4062
		private string _token;

		// Token: 0x04000FDF RID: 4063
		private IExtension extensionObject;
	}
}
