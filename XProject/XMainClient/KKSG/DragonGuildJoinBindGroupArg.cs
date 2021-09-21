using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CE RID: 1230
	[ProtoContract(Name = "DragonGuildJoinBindGroupArg")]
	[Serializable]
	public class DragonGuildJoinBindGroupArg : IExtensible
	{
		// Token: 0x17001393 RID: 5011
		// (get) Token: 0x06003FEA RID: 16362 RVA: 0x00079C8C File Offset: 0x00077E8C
		// (set) Token: 0x06003FEB RID: 16363 RVA: 0x00079CAD File Offset: 0x00077EAD
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

		// Token: 0x17001394 RID: 5012
		// (get) Token: 0x06003FEC RID: 16364 RVA: 0x00079CB8 File Offset: 0x00077EB8
		// (set) Token: 0x06003FED RID: 16365 RVA: 0x00079CD4 File Offset: 0x00077ED4
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

		// Token: 0x06003FEE RID: 16366 RVA: 0x00079D04 File Offset: 0x00077F04
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003FEF RID: 16367 RVA: 0x00079D1C File Offset: 0x00077F1C
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06003FF0 RID: 16368 RVA: 0x00079D28 File Offset: 0x00077F28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FE9 RID: 4073
		private string _token;

		// Token: 0x04000FEA RID: 4074
		private IExtension extensionObject;
	}
}
