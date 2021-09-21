using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000604 RID: 1540
	[ProtoContract(Name = "PkBaseHist")]
	[Serializable]
	public class PkBaseHist : IExtensible
	{
		// Token: 0x17001D09 RID: 7433
		// (get) Token: 0x06005CA7 RID: 23719 RVA: 0x000B0884 File Offset: 0x000AEA84
		// (set) Token: 0x06005CA8 RID: 23720 RVA: 0x000B08B0 File Offset: 0x000AEAB0
		[ProtoMember(1, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		// Token: 0x17001D0A RID: 7434
		// (get) Token: 0x06005CA9 RID: 23721 RVA: 0x000B08C0 File Offset: 0x000AEAC0
		// (set) Token: 0x06005CAA RID: 23722 RVA: 0x000B08E0 File Offset: 0x000AEAE0
		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		// Token: 0x06005CAB RID: 23723 RVA: 0x000B0924 File Offset: 0x000AEB24
		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		// Token: 0x06005CAC RID: 23724 RVA: 0x000B093C File Offset: 0x000AEB3C
		private void Resetwin()
		{
			this.winSpecified = false;
		}

		// Token: 0x17001D0B RID: 7435
		// (get) Token: 0x06005CAD RID: 23725 RVA: 0x000B0948 File Offset: 0x000AEB48
		// (set) Token: 0x06005CAE RID: 23726 RVA: 0x000B0974 File Offset: 0x000AEB74
		[ProtoMember(2, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		// Token: 0x17001D0C RID: 7436
		// (get) Token: 0x06005CAF RID: 23727 RVA: 0x000B0984 File Offset: 0x000AEB84
		// (set) Token: 0x06005CB0 RID: 23728 RVA: 0x000B09A4 File Offset: 0x000AEBA4
		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		// Token: 0x06005CB1 RID: 23729 RVA: 0x000B09E8 File Offset: 0x000AEBE8
		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		// Token: 0x06005CB2 RID: 23730 RVA: 0x000B0A00 File Offset: 0x000AEC00
		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		// Token: 0x17001D0D RID: 7437
		// (get) Token: 0x06005CB3 RID: 23731 RVA: 0x000B0A0C File Offset: 0x000AEC0C
		// (set) Token: 0x06005CB4 RID: 23732 RVA: 0x000B0A38 File Offset: 0x000AEC38
		[ProtoMember(3, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		// Token: 0x17001D0E RID: 7438
		// (get) Token: 0x06005CB5 RID: 23733 RVA: 0x000B0A48 File Offset: 0x000AEC48
		// (set) Token: 0x06005CB6 RID: 23734 RVA: 0x000B0A68 File Offset: 0x000AEC68
		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		// Token: 0x06005CB7 RID: 23735 RVA: 0x000B0AAC File Offset: 0x000AECAC
		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		// Token: 0x06005CB8 RID: 23736 RVA: 0x000B0AC4 File Offset: 0x000AECC4
		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		// Token: 0x17001D0F RID: 7439
		// (get) Token: 0x06005CB9 RID: 23737 RVA: 0x000B0AD0 File Offset: 0x000AECD0
		// (set) Token: 0x06005CBA RID: 23738 RVA: 0x000B0AFC File Offset: 0x000AECFC
		[ProtoMember(4, IsRequired = false, Name = "lastwin", DataFormat = DataFormat.TwosComplement)]
		public uint lastwin
		{
			get
			{
				return this._lastwin ?? 0U;
			}
			set
			{
				this._lastwin = new uint?(value);
			}
		}

		// Token: 0x17001D10 RID: 7440
		// (get) Token: 0x06005CBB RID: 23739 RVA: 0x000B0B0C File Offset: 0x000AED0C
		// (set) Token: 0x06005CBC RID: 23740 RVA: 0x000B0B2C File Offset: 0x000AED2C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastwinSpecified
		{
			get
			{
				return this._lastwin != null;
			}
			set
			{
				bool flag = value == (this._lastwin == null);
				if (flag)
				{
					this._lastwin = (value ? new uint?(this.lastwin) : null);
				}
			}
		}

		// Token: 0x06005CBD RID: 23741 RVA: 0x000B0B70 File Offset: 0x000AED70
		private bool ShouldSerializelastwin()
		{
			return this.lastwinSpecified;
		}

		// Token: 0x06005CBE RID: 23742 RVA: 0x000B0B88 File Offset: 0x000AED88
		private void Resetlastwin()
		{
			this.lastwinSpecified = false;
		}

		// Token: 0x17001D11 RID: 7441
		// (get) Token: 0x06005CBF RID: 23743 RVA: 0x000B0B94 File Offset: 0x000AED94
		// (set) Token: 0x06005CC0 RID: 23744 RVA: 0x000B0BC0 File Offset: 0x000AEDC0
		[ProtoMember(5, IsRequired = false, Name = "lastlose", DataFormat = DataFormat.TwosComplement)]
		public uint lastlose
		{
			get
			{
				return this._lastlose ?? 0U;
			}
			set
			{
				this._lastlose = new uint?(value);
			}
		}

		// Token: 0x17001D12 RID: 7442
		// (get) Token: 0x06005CC1 RID: 23745 RVA: 0x000B0BD0 File Offset: 0x000AEDD0
		// (set) Token: 0x06005CC2 RID: 23746 RVA: 0x000B0BF0 File Offset: 0x000AEDF0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastloseSpecified
		{
			get
			{
				return this._lastlose != null;
			}
			set
			{
				bool flag = value == (this._lastlose == null);
				if (flag)
				{
					this._lastlose = (value ? new uint?(this.lastlose) : null);
				}
			}
		}

		// Token: 0x06005CC3 RID: 23747 RVA: 0x000B0C34 File Offset: 0x000AEE34
		private bool ShouldSerializelastlose()
		{
			return this.lastloseSpecified;
		}

		// Token: 0x06005CC4 RID: 23748 RVA: 0x000B0C4C File Offset: 0x000AEE4C
		private void Resetlastlose()
		{
			this.lastloseSpecified = false;
		}

		// Token: 0x17001D13 RID: 7443
		// (get) Token: 0x06005CC5 RID: 23749 RVA: 0x000B0C58 File Offset: 0x000AEE58
		// (set) Token: 0x06005CC6 RID: 23750 RVA: 0x000B0C84 File Offset: 0x000AEE84
		[ProtoMember(6, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		// Token: 0x17001D14 RID: 7444
		// (get) Token: 0x06005CC7 RID: 23751 RVA: 0x000B0C94 File Offset: 0x000AEE94
		// (set) Token: 0x06005CC8 RID: 23752 RVA: 0x000B0CB4 File Offset: 0x000AEEB4
		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		// Token: 0x06005CC9 RID: 23753 RVA: 0x000B0CF8 File Offset: 0x000AEEF8
		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		// Token: 0x06005CCA RID: 23754 RVA: 0x000B0D10 File Offset: 0x000AEF10
		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		// Token: 0x17001D15 RID: 7445
		// (get) Token: 0x06005CCB RID: 23755 RVA: 0x000B0D1C File Offset: 0x000AEF1C
		// (set) Token: 0x06005CCC RID: 23756 RVA: 0x000B0D48 File Offset: 0x000AEF48
		[ProtoMember(7, IsRequired = false, Name = "continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint continuelose
		{
			get
			{
				return this._continuelose ?? 0U;
			}
			set
			{
				this._continuelose = new uint?(value);
			}
		}

		// Token: 0x17001D16 RID: 7446
		// (get) Token: 0x06005CCD RID: 23757 RVA: 0x000B0D58 File Offset: 0x000AEF58
		// (set) Token: 0x06005CCE RID: 23758 RVA: 0x000B0D78 File Offset: 0x000AEF78
		[XmlIgnore]
		[Browsable(false)]
		public bool continueloseSpecified
		{
			get
			{
				return this._continuelose != null;
			}
			set
			{
				bool flag = value == (this._continuelose == null);
				if (flag)
				{
					this._continuelose = (value ? new uint?(this.continuelose) : null);
				}
			}
		}

		// Token: 0x06005CCF RID: 23759 RVA: 0x000B0DBC File Offset: 0x000AEFBC
		private bool ShouldSerializecontinuelose()
		{
			return this.continueloseSpecified;
		}

		// Token: 0x06005CD0 RID: 23760 RVA: 0x000B0DD4 File Offset: 0x000AEFD4
		private void Resetcontinuelose()
		{
			this.continueloseSpecified = false;
		}

		// Token: 0x06005CD1 RID: 23761 RVA: 0x000B0DE0 File Offset: 0x000AEFE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001686 RID: 5766
		private uint? _win;

		// Token: 0x04001687 RID: 5767
		private uint? _lose;

		// Token: 0x04001688 RID: 5768
		private uint? _draw;

		// Token: 0x04001689 RID: 5769
		private uint? _lastwin;

		// Token: 0x0400168A RID: 5770
		private uint? _lastlose;

		// Token: 0x0400168B RID: 5771
		private uint? _continuewin;

		// Token: 0x0400168C RID: 5772
		private uint? _continuelose;

		// Token: 0x0400168D RID: 5773
		private IExtension extensionObject;
	}
}
