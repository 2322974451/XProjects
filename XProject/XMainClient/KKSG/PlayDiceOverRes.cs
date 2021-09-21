using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021A RID: 538
	[ProtoContract(Name = "PlayDiceOverRes")]
	[Serializable]
	public class PlayDiceOverRes : IExtensible
	{
		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06001E15 RID: 7701 RVA: 0x0003B1AC File Offset: 0x000393AC
		// (set) Token: 0x06001E16 RID: 7702 RVA: 0x0003B1D8 File Offset: 0x000393D8
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06001E17 RID: 7703 RVA: 0x0003B1E8 File Offset: 0x000393E8
		// (set) Token: 0x06001E18 RID: 7704 RVA: 0x0003B208 File Offset: 0x00039408
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x0003B24C File Offset: 0x0003944C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001E1A RID: 7706 RVA: 0x0003B264 File Offset: 0x00039464
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06001E1B RID: 7707 RVA: 0x0003B270 File Offset: 0x00039470
		// (set) Token: 0x06001E1C RID: 7708 RVA: 0x0003B29C File Offset: 0x0003949C
		[ProtoMember(2, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public int mapID
		{
			get
			{
				return this._mapID ?? 0;
			}
			set
			{
				this._mapID = new int?(value);
			}
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06001E1D RID: 7709 RVA: 0x0003B2AC File Offset: 0x000394AC
		// (set) Token: 0x06001E1E RID: 7710 RVA: 0x0003B2CC File Offset: 0x000394CC
		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new int?(this.mapID) : null);
				}
			}
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x0003B310 File Offset: 0x00039510
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x0003B328 File Offset: 0x00039528
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06001E21 RID: 7713 RVA: 0x0003B334 File Offset: 0x00039534
		// (set) Token: 0x06001E22 RID: 7714 RVA: 0x0003B34C File Offset: 0x0003954C
		[ProtoMember(3, IsRequired = false, Name = "addBoxInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskBoxInfo addBoxInfo
		{
			get
			{
				return this._addBoxInfo;
			}
			set
			{
				this._addBoxInfo = value;
			}
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06001E23 RID: 7715 RVA: 0x0003B358 File Offset: 0x00039558
		// (set) Token: 0x06001E24 RID: 7716 RVA: 0x0003B384 File Offset: 0x00039584
		[ProtoMember(4, IsRequired = false, Name = "hasTriggerBuy", DataFormat = DataFormat.Default)]
		public bool hasTriggerBuy
		{
			get
			{
				return this._hasTriggerBuy ?? false;
			}
			set
			{
				this._hasTriggerBuy = new bool?(value);
			}
		}

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06001E25 RID: 7717 RVA: 0x0003B394 File Offset: 0x00039594
		// (set) Token: 0x06001E26 RID: 7718 RVA: 0x0003B3B4 File Offset: 0x000395B4
		[XmlIgnore]
		[Browsable(false)]
		public bool hasTriggerBuySpecified
		{
			get
			{
				return this._hasTriggerBuy != null;
			}
			set
			{
				bool flag = value == (this._hasTriggerBuy == null);
				if (flag)
				{
					this._hasTriggerBuy = (value ? new bool?(this.hasTriggerBuy) : null);
				}
			}
		}

		// Token: 0x06001E27 RID: 7719 RVA: 0x0003B3F8 File Offset: 0x000395F8
		private bool ShouldSerializehasTriggerBuy()
		{
			return this.hasTriggerBuySpecified;
		}

		// Token: 0x06001E28 RID: 7720 RVA: 0x0003B410 File Offset: 0x00039610
		private void ResethasTriggerBuy()
		{
			this.hasTriggerBuySpecified = false;
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x0003B41C File Offset: 0x0003961C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000786 RID: 1926
		private ErrorCode? _error;

		// Token: 0x04000787 RID: 1927
		private int? _mapID;

		// Token: 0x04000788 RID: 1928
		private RiskBoxInfo _addBoxInfo = null;

		// Token: 0x04000789 RID: 1929
		private bool? _hasTriggerBuy;

		// Token: 0x0400078A RID: 1930
		private IExtension extensionObject;
	}
}
