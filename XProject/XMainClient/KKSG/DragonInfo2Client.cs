using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068B RID: 1675
	[ProtoContract(Name = "DragonInfo2Client")]
	[Serializable]
	public class DragonInfo2Client : IExtensible
	{
		// Token: 0x17002228 RID: 8744
		// (get) Token: 0x06006BED RID: 27629 RVA: 0x000CE73C File Offset: 0x000CC93C
		// (set) Token: 0x06006BEE RID: 27630 RVA: 0x000CE768 File Offset: 0x000CC968
		[ProtoMember(1, IsRequired = false, Name = "dragonType", DataFormat = DataFormat.TwosComplement)]
		public int dragonType
		{
			get
			{
				return this._dragonType ?? 0;
			}
			set
			{
				this._dragonType = new int?(value);
			}
		}

		// Token: 0x17002229 RID: 8745
		// (get) Token: 0x06006BEF RID: 27631 RVA: 0x000CE778 File Offset: 0x000CC978
		// (set) Token: 0x06006BF0 RID: 27632 RVA: 0x000CE798 File Offset: 0x000CC998
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonTypeSpecified
		{
			get
			{
				return this._dragonType != null;
			}
			set
			{
				bool flag = value == (this._dragonType == null);
				if (flag)
				{
					this._dragonType = (value ? new int?(this.dragonType) : null);
				}
			}
		}

		// Token: 0x06006BF1 RID: 27633 RVA: 0x000CE7DC File Offset: 0x000CC9DC
		private bool ShouldSerializedragonType()
		{
			return this.dragonTypeSpecified;
		}

		// Token: 0x06006BF2 RID: 27634 RVA: 0x000CE7F4 File Offset: 0x000CC9F4
		private void ResetdragonType()
		{
			this.dragonTypeSpecified = false;
		}

		// Token: 0x1700222A RID: 8746
		// (get) Token: 0x06006BF3 RID: 27635 RVA: 0x000CE800 File Offset: 0x000CCA00
		// (set) Token: 0x06006BF4 RID: 27636 RVA: 0x000CE82C File Offset: 0x000CCA2C
		[ProtoMember(2, IsRequired = false, Name = "hardLevel", DataFormat = DataFormat.TwosComplement)]
		public int hardLevel
		{
			get
			{
				return this._hardLevel ?? 0;
			}
			set
			{
				this._hardLevel = new int?(value);
			}
		}

		// Token: 0x1700222B RID: 8747
		// (get) Token: 0x06006BF5 RID: 27637 RVA: 0x000CE83C File Offset: 0x000CCA3C
		// (set) Token: 0x06006BF6 RID: 27638 RVA: 0x000CE85C File Offset: 0x000CCA5C
		[XmlIgnore]
		[Browsable(false)]
		public bool hardLevelSpecified
		{
			get
			{
				return this._hardLevel != null;
			}
			set
			{
				bool flag = value == (this._hardLevel == null);
				if (flag)
				{
					this._hardLevel = (value ? new int?(this.hardLevel) : null);
				}
			}
		}

		// Token: 0x06006BF7 RID: 27639 RVA: 0x000CE8A0 File Offset: 0x000CCAA0
		private bool ShouldSerializehardLevel()
		{
			return this.hardLevelSpecified;
		}

		// Token: 0x06006BF8 RID: 27640 RVA: 0x000CE8B8 File Offset: 0x000CCAB8
		private void ResethardLevel()
		{
			this.hardLevelSpecified = false;
		}

		// Token: 0x1700222C RID: 8748
		// (get) Token: 0x06006BF9 RID: 27641 RVA: 0x000CE8C4 File Offset: 0x000CCAC4
		// (set) Token: 0x06006BFA RID: 27642 RVA: 0x000CE8F0 File Offset: 0x000CCAF0
		[ProtoMember(3, IsRequired = false, Name = "curFloor", DataFormat = DataFormat.TwosComplement)]
		public int curFloor
		{
			get
			{
				return this._curFloor ?? 0;
			}
			set
			{
				this._curFloor = new int?(value);
			}
		}

		// Token: 0x1700222D RID: 8749
		// (get) Token: 0x06006BFB RID: 27643 RVA: 0x000CE900 File Offset: 0x000CCB00
		// (set) Token: 0x06006BFC RID: 27644 RVA: 0x000CE920 File Offset: 0x000CCB20
		[XmlIgnore]
		[Browsable(false)]
		public bool curFloorSpecified
		{
			get
			{
				return this._curFloor != null;
			}
			set
			{
				bool flag = value == (this._curFloor == null);
				if (flag)
				{
					this._curFloor = (value ? new int?(this.curFloor) : null);
				}
			}
		}

		// Token: 0x06006BFD RID: 27645 RVA: 0x000CE964 File Offset: 0x000CCB64
		private bool ShouldSerializecurFloor()
		{
			return this.curFloorSpecified;
		}

		// Token: 0x06006BFE RID: 27646 RVA: 0x000CE97C File Offset: 0x000CCB7C
		private void ResetcurFloor()
		{
			this.curFloorSpecified = false;
		}

		// Token: 0x1700222E RID: 8750
		// (get) Token: 0x06006BFF RID: 27647 RVA: 0x000CE988 File Offset: 0x000CCB88
		// (set) Token: 0x06006C00 RID: 27648 RVA: 0x000CE9B4 File Offset: 0x000CCBB4
		[ProtoMember(4, IsRequired = false, Name = "refreshTimes", DataFormat = DataFormat.TwosComplement)]
		public int refreshTimes
		{
			get
			{
				return this._refreshTimes ?? 0;
			}
			set
			{
				this._refreshTimes = new int?(value);
			}
		}

		// Token: 0x1700222F RID: 8751
		// (get) Token: 0x06006C01 RID: 27649 RVA: 0x000CE9C4 File Offset: 0x000CCBC4
		// (set) Token: 0x06006C02 RID: 27650 RVA: 0x000CE9E4 File Offset: 0x000CCBE4
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshTimesSpecified
		{
			get
			{
				return this._refreshTimes != null;
			}
			set
			{
				bool flag = value == (this._refreshTimes == null);
				if (flag)
				{
					this._refreshTimes = (value ? new int?(this.refreshTimes) : null);
				}
			}
		}

		// Token: 0x06006C03 RID: 27651 RVA: 0x000CEA28 File Offset: 0x000CCC28
		private bool ShouldSerializerefreshTimes()
		{
			return this.refreshTimesSpecified;
		}

		// Token: 0x06006C04 RID: 27652 RVA: 0x000CEA40 File Offset: 0x000CCC40
		private void ResetrefreshTimes()
		{
			this.refreshTimesSpecified = false;
		}

		// Token: 0x17002230 RID: 8752
		// (get) Token: 0x06006C05 RID: 27653 RVA: 0x000CEA4C File Offset: 0x000CCC4C
		// (set) Token: 0x06006C06 RID: 27654 RVA: 0x000CEA78 File Offset: 0x000CCC78
		[ProtoMember(5, IsRequired = false, Name = "weakType", DataFormat = DataFormat.TwosComplement)]
		public DragonWeakType weakType
		{
			get
			{
				return this._weakType ?? DragonWeakType.DragonWeakType_Null;
			}
			set
			{
				this._weakType = new DragonWeakType?(value);
			}
		}

		// Token: 0x17002231 RID: 8753
		// (get) Token: 0x06006C07 RID: 27655 RVA: 0x000CEA88 File Offset: 0x000CCC88
		// (set) Token: 0x06006C08 RID: 27656 RVA: 0x000CEAA8 File Offset: 0x000CCCA8
		[XmlIgnore]
		[Browsable(false)]
		public bool weakTypeSpecified
		{
			get
			{
				return this._weakType != null;
			}
			set
			{
				bool flag = value == (this._weakType == null);
				if (flag)
				{
					this._weakType = (value ? new DragonWeakType?(this.weakType) : null);
				}
			}
		}

		// Token: 0x06006C09 RID: 27657 RVA: 0x000CEAEC File Offset: 0x000CCCEC
		private bool ShouldSerializeweakType()
		{
			return this.weakTypeSpecified;
		}

		// Token: 0x06006C0A RID: 27658 RVA: 0x000CEB04 File Offset: 0x000CCD04
		private void ResetweakType()
		{
			this.weakTypeSpecified = false;
		}

		// Token: 0x06006C0B RID: 27659 RVA: 0x000CEB10 File Offset: 0x000CCD10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019F0 RID: 6640
		private int? _dragonType;

		// Token: 0x040019F1 RID: 6641
		private int? _hardLevel;

		// Token: 0x040019F2 RID: 6642
		private int? _curFloor;

		// Token: 0x040019F3 RID: 6643
		private int? _refreshTimes;

		// Token: 0x040019F4 RID: 6644
		private DragonWeakType? _weakType;

		// Token: 0x040019F5 RID: 6645
		private IExtension extensionObject;
	}
}
