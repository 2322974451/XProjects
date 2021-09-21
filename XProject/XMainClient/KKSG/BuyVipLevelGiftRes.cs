using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D4 RID: 468
	[ProtoContract(Name = "BuyVipLevelGiftRes")]
	[Serializable]
	public class BuyVipLevelGiftRes : IExtensible
	{
		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06001B2F RID: 6959 RVA: 0x00035C04 File Offset: 0x00033E04
		// (set) Token: 0x06001B30 RID: 6960 RVA: 0x00035C30 File Offset: 0x00033E30
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06001B31 RID: 6961 RVA: 0x00035C40 File Offset: 0x00033E40
		// (set) Token: 0x06001B32 RID: 6962 RVA: 0x00035C60 File Offset: 0x00033E60
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x00035CA4 File Offset: 0x00033EA4
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001B34 RID: 6964 RVA: 0x00035CBC File Offset: 0x00033EBC
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06001B35 RID: 6965 RVA: 0x00035CC8 File Offset: 0x00033EC8
		[ProtoMember(2, Name = "VipLevelGift", DataFormat = DataFormat.TwosComplement)]
		public List<int> VipLevelGift
		{
			get
			{
				return this._VipLevelGift;
			}
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x00035CE0 File Offset: 0x00033EE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006C4 RID: 1732
		private ErrorCode? _errcode;

		// Token: 0x040006C5 RID: 1733
		private readonly List<int> _VipLevelGift = new List<int>();

		// Token: 0x040006C6 RID: 1734
		private IExtension extensionObject;
	}
}
