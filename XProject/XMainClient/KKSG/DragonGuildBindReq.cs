using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CC RID: 1228
	[ProtoContract(Name = "DragonGuildBindReq")]
	[Serializable]
	public class DragonGuildBindReq : IExtensible
	{
		// Token: 0x1700138D RID: 5005
		// (get) Token: 0x06003FD4 RID: 16340 RVA: 0x00079A50 File Offset: 0x00077C50
		// (set) Token: 0x06003FD5 RID: 16341 RVA: 0x00079A71 File Offset: 0x00077C71
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

		// Token: 0x1700138E RID: 5006
		// (get) Token: 0x06003FD6 RID: 16342 RVA: 0x00079A7C File Offset: 0x00077C7C
		// (set) Token: 0x06003FD7 RID: 16343 RVA: 0x00079A98 File Offset: 0x00077C98
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

		// Token: 0x06003FD8 RID: 16344 RVA: 0x00079AC8 File Offset: 0x00077CC8
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003FD9 RID: 16345 RVA: 0x00079AE0 File Offset: 0x00077CE0
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06003FDA RID: 16346 RVA: 0x00079AEC File Offset: 0x00077CEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FE4 RID: 4068
		private string _token;

		// Token: 0x04000FE5 RID: 4069
		private IExtension extensionObject;
	}
}
