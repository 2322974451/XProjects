using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012B RID: 299
	[ProtoContract(Name = "NewGuildBonusData")]
	[Serializable]
	public class NewGuildBonusData : IExtensible
	{
		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06001281 RID: 4737 RVA: 0x000258FC File Offset: 0x00023AFC
		// (set) Token: 0x06001282 RID: 4738 RVA: 0x00025928 File Offset: 0x00023B28
		[ProtoMember(1, IsRequired = false, Name = "showIconInScreen", DataFormat = DataFormat.Default)]
		public bool showIconInScreen
		{
			get
			{
				return this._showIconInScreen ?? false;
			}
			set
			{
				this._showIconInScreen = new bool?(value);
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001283 RID: 4739 RVA: 0x00025938 File Offset: 0x00023B38
		// (set) Token: 0x06001284 RID: 4740 RVA: 0x00025958 File Offset: 0x00023B58
		[XmlIgnore]
		[Browsable(false)]
		public bool showIconInScreenSpecified
		{
			get
			{
				return this._showIconInScreen != null;
			}
			set
			{
				bool flag = value == (this._showIconInScreen == null);
				if (flag)
				{
					this._showIconInScreen = (value ? new bool?(this.showIconInScreen) : null);
				}
			}
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x0002599C File Offset: 0x00023B9C
		private bool ShouldSerializeshowIconInScreen()
		{
			return this.showIconInScreenSpecified;
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x000259B4 File Offset: 0x00023BB4
		private void ResetshowIconInScreen()
		{
			this.showIconInScreenSpecified = false;
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x000259C0 File Offset: 0x00023BC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400049F RID: 1183
		private bool? _showIconInScreen;

		// Token: 0x040004A0 RID: 1184
		private IExtension extensionObject;
	}
}
