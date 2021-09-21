using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D3 RID: 467
	[ProtoContract(Name = "BuyVipLevelGiftArg")]
	[Serializable]
	public class BuyVipLevelGiftArg : IExtensible
	{
		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x00035B0C File Offset: 0x00033D0C
		// (set) Token: 0x06001B28 RID: 6952 RVA: 0x00035B38 File Offset: 0x00033D38
		[ProtoMember(1, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public int vipLevel
		{
			get
			{
				return this._vipLevel ?? 0;
			}
			set
			{
				this._vipLevel = new int?(value);
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x00035B48 File Offset: 0x00033D48
		// (set) Token: 0x06001B2A RID: 6954 RVA: 0x00035B68 File Offset: 0x00033D68
		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new int?(this.vipLevel) : null);
				}
			}
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x00035BAC File Offset: 0x00033DAC
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x00035BC4 File Offset: 0x00033DC4
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x00035BD0 File Offset: 0x00033DD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006C2 RID: 1730
		private int? _vipLevel;

		// Token: 0x040006C3 RID: 1731
		private IExtension extensionObject;
	}
}
