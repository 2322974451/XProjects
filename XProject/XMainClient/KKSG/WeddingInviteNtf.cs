using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047B RID: 1147
	[ProtoContract(Name = "WeddingInviteNtf")]
	[Serializable]
	public class WeddingInviteNtf : IExtensible
	{
		// Token: 0x17001262 RID: 4706
		// (get) Token: 0x06003BF8 RID: 15352 RVA: 0x00072974 File Offset: 0x00070B74
		// (set) Token: 0x06003BF9 RID: 15353 RVA: 0x000729A0 File Offset: 0x00070BA0
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingInviteOperType type
		{
			get
			{
				return this._type ?? WeddingInviteOperType.Wedding_Invite;
			}
			set
			{
				this._type = new WeddingInviteOperType?(value);
			}
		}

		// Token: 0x17001263 RID: 4707
		// (get) Token: 0x06003BFA RID: 15354 RVA: 0x000729B0 File Offset: 0x00070BB0
		// (set) Token: 0x06003BFB RID: 15355 RVA: 0x000729D0 File Offset: 0x00070BD0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingInviteOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003BFC RID: 15356 RVA: 0x00072A14 File Offset: 0x00070C14
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003BFD RID: 15357 RVA: 0x00072A2C File Offset: 0x00070C2C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001264 RID: 4708
		// (get) Token: 0x06003BFE RID: 15358 RVA: 0x00072A38 File Offset: 0x00070C38
		// (set) Token: 0x06003BFF RID: 15359 RVA: 0x00072A50 File Offset: 0x00070C50
		[ProtoMember(2, IsRequired = false, Name = "weddinginfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingBrief weddinginfo
		{
			get
			{
				return this._weddinginfo;
			}
			set
			{
				this._weddinginfo = value;
			}
		}

		// Token: 0x17001265 RID: 4709
		// (get) Token: 0x06003C00 RID: 15360 RVA: 0x00072A5C File Offset: 0x00070C5C
		// (set) Token: 0x06003C01 RID: 15361 RVA: 0x00072A74 File Offset: 0x00070C74
		[ProtoMember(3, IsRequired = false, Name = "applyer", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief applyer
		{
			get
			{
				return this._applyer;
			}
			set
			{
				this._applyer = value;
			}
		}

		// Token: 0x06003C02 RID: 15362 RVA: 0x00072A80 File Offset: 0x00070C80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EE9 RID: 3817
		private WeddingInviteOperType? _type;

		// Token: 0x04000EEA RID: 3818
		private WeddingBrief _weddinginfo = null;

		// Token: 0x04000EEB RID: 3819
		private WeddingRoleBrief _applyer = null;

		// Token: 0x04000EEC RID: 3820
		private IExtension extensionObject;
	}
}
