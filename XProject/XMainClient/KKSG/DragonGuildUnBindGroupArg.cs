using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D0 RID: 1232
	[ProtoContract(Name = "DragonGuildUnBindGroupArg")]
	[Serializable]
	public class DragonGuildUnBindGroupArg : IExtensible
	{
		// Token: 0x17001397 RID: 5015
		// (get) Token: 0x06003FFA RID: 16378 RVA: 0x00079E2C File Offset: 0x0007802C
		// (set) Token: 0x06003FFB RID: 16379 RVA: 0x00079E4D File Offset: 0x0007804D
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

		// Token: 0x17001398 RID: 5016
		// (get) Token: 0x06003FFC RID: 16380 RVA: 0x00079E58 File Offset: 0x00078058
		// (set) Token: 0x06003FFD RID: 16381 RVA: 0x00079E74 File Offset: 0x00078074
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

		// Token: 0x06003FFE RID: 16382 RVA: 0x00079EA4 File Offset: 0x000780A4
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003FFF RID: 16383 RVA: 0x00079EBC File Offset: 0x000780BC
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06004000 RID: 16384 RVA: 0x00079EC8 File Offset: 0x000780C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FED RID: 4077
		private string _token;

		// Token: 0x04000FEE RID: 4078
		private IExtension extensionObject;
	}
}
