using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000261 RID: 609
	[ProtoContract(Name = "GuildJoinBindGroupReq")]
	[Serializable]
	public class GuildJoinBindGroupReq : IExtensible
	{
		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x0600222F RID: 8751 RVA: 0x00042DAC File Offset: 0x00040FAC
		// (set) Token: 0x06002230 RID: 8752 RVA: 0x00042DCD File Offset: 0x00040FCD
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

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06002231 RID: 8753 RVA: 0x00042DD8 File Offset: 0x00040FD8
		// (set) Token: 0x06002232 RID: 8754 RVA: 0x00042DF4 File Offset: 0x00040FF4
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

		// Token: 0x06002233 RID: 8755 RVA: 0x00042E24 File Offset: 0x00041024
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x00042E3C File Offset: 0x0004103C
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x00042E48 File Offset: 0x00041048
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400087A RID: 2170
		private string _token;

		// Token: 0x0400087B RID: 2171
		private IExtension extensionObject;
	}
}
