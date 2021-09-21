using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000293 RID: 659
	[ProtoContract(Name = "SendGift2PlatFriendArg")]
	[Serializable]
	public class SendGift2PlatFriendArg : IExtensible
	{
		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x060024E4 RID: 9444 RVA: 0x00047ED8 File Offset: 0x000460D8
		// (set) Token: 0x060024E5 RID: 9445 RVA: 0x00047EF9 File Offset: 0x000460F9
		[ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x17000B79 RID: 2937
		// (get) Token: 0x060024E6 RID: 9446 RVA: 0x00047F04 File Offset: 0x00046104
		// (set) Token: 0x060024E7 RID: 9447 RVA: 0x00047F20 File Offset: 0x00046120
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x00047F50 File Offset: 0x00046150
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x00047F68 File Offset: 0x00046168
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x00047F74 File Offset: 0x00046174
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400091F RID: 2335
		private string _openid;

		// Token: 0x04000920 RID: 2336
		private IExtension extensionObject;
	}
}
