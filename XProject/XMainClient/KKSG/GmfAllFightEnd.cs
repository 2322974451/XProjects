using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A8 RID: 424
	[ProtoContract(Name = "GmfAllFightEnd")]
	[Serializable]
	public class GmfAllFightEnd : IExtensible
	{
		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x0600190D RID: 6413 RVA: 0x00031C98 File Offset: 0x0002FE98
		// (set) Token: 0x0600190E RID: 6414 RVA: 0x00031CB0 File Offset: 0x0002FEB0
		[ProtoMember(1, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x0600190F RID: 6415 RVA: 0x00031CBC File Offset: 0x0002FEBC
		// (set) Token: 0x06001910 RID: 6416 RVA: 0x00031CD4 File Offset: 0x0002FED4
		[ProtoMember(2, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06001911 RID: 6417 RVA: 0x00031CE0 File Offset: 0x0002FEE0
		// (set) Token: 0x06001912 RID: 6418 RVA: 0x00031D0C File Offset: 0x0002FF0C
		[ProtoMember(3, IsRequired = false, Name = "wintype", DataFormat = DataFormat.TwosComplement)]
		public GMF_FINAL_WIN_TYPE wintype
		{
			get
			{
				return this._wintype ?? GMF_FINAL_WIN_TYPE.GMF_FWY_NORMAL;
			}
			set
			{
				this._wintype = new GMF_FINAL_WIN_TYPE?(value);
			}
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06001913 RID: 6419 RVA: 0x00031D1C File Offset: 0x0002FF1C
		// (set) Token: 0x06001914 RID: 6420 RVA: 0x00031D3C File Offset: 0x0002FF3C
		[XmlIgnore]
		[Browsable(false)]
		public bool wintypeSpecified
		{
			get
			{
				return this._wintype != null;
			}
			set
			{
				bool flag = value == (this._wintype == null);
				if (flag)
				{
					this._wintype = (value ? new GMF_FINAL_WIN_TYPE?(this.wintype) : null);
				}
			}
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x00031D80 File Offset: 0x0002FF80
		private bool ShouldSerializewintype()
		{
			return this.wintypeSpecified;
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x00031D98 File Offset: 0x0002FF98
		private void Resetwintype()
		{
			this.wintypeSpecified = false;
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00031DA4 File Offset: 0x0002FFA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000638 RID: 1592
		private GmfGuildBrief _winguild = null;

		// Token: 0x04000639 RID: 1593
		private GmfGuildBrief _loseguild = null;

		// Token: 0x0400063A RID: 1594
		private GMF_FINAL_WIN_TYPE? _wintype;

		// Token: 0x0400063B RID: 1595
		private IExtension extensionObject;
	}
}
