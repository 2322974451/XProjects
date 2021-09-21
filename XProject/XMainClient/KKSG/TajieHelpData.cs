using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000449 RID: 1097
	[ProtoContract(Name = "TajieHelpData")]
	[Serializable]
	public class TajieHelpData : IExtensible
	{
		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x060039DA RID: 14810 RVA: 0x0006EAA0 File Offset: 0x0006CCA0
		// (set) Token: 0x060039DB RID: 14811 RVA: 0x0006EACC File Offset: 0x0006CCCC
		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x060039DC RID: 14812 RVA: 0x0006EADC File Offset: 0x0006CCDC
		// (set) Token: 0x060039DD RID: 14813 RVA: 0x0006EAFC File Offset: 0x0006CCFC
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060039DE RID: 14814 RVA: 0x0006EB40 File Offset: 0x0006CD40
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060039DF RID: 14815 RVA: 0x0006EB58 File Offset: 0x0006CD58
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x060039E0 RID: 14816 RVA: 0x0006EB64 File Offset: 0x0006CD64
		// (set) Token: 0x060039E1 RID: 14817 RVA: 0x0006EB90 File Offset: 0x0006CD90
		[ProtoMember(2, IsRequired = false, Name = "sceneType", DataFormat = DataFormat.TwosComplement)]
		public int sceneType
		{
			get
			{
				return this._sceneType ?? 0;
			}
			set
			{
				this._sceneType = new int?(value);
			}
		}

		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x060039E2 RID: 14818 RVA: 0x0006EBA0 File Offset: 0x0006CDA0
		// (set) Token: 0x060039E3 RID: 14819 RVA: 0x0006EBC0 File Offset: 0x0006CDC0
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneTypeSpecified
		{
			get
			{
				return this._sceneType != null;
			}
			set
			{
				bool flag = value == (this._sceneType == null);
				if (flag)
				{
					this._sceneType = (value ? new int?(this.sceneType) : null);
				}
			}
		}

		// Token: 0x060039E4 RID: 14820 RVA: 0x0006EC04 File Offset: 0x0006CE04
		private bool ShouldSerializesceneType()
		{
			return this.sceneTypeSpecified;
		}

		// Token: 0x060039E5 RID: 14821 RVA: 0x0006EC1C File Offset: 0x0006CE1C
		private void ResetsceneType()
		{
			this.sceneTypeSpecified = false;
		}

		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x060039E6 RID: 14822 RVA: 0x0006EC28 File Offset: 0x0006CE28
		// (set) Token: 0x060039E7 RID: 14823 RVA: 0x0006EC54 File Offset: 0x0006CE54
		[ProtoMember(3, IsRequired = false, Name = "dragonStatus", DataFormat = DataFormat.TwosComplement)]
		public int dragonStatus
		{
			get
			{
				return this._dragonStatus ?? 0;
			}
			set
			{
				this._dragonStatus = new int?(value);
			}
		}

		// Token: 0x170011C5 RID: 4549
		// (get) Token: 0x060039E8 RID: 14824 RVA: 0x0006EC64 File Offset: 0x0006CE64
		// (set) Token: 0x060039E9 RID: 14825 RVA: 0x0006EC84 File Offset: 0x0006CE84
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonStatusSpecified
		{
			get
			{
				return this._dragonStatus != null;
			}
			set
			{
				bool flag = value == (this._dragonStatus == null);
				if (flag)
				{
					this._dragonStatus = (value ? new int?(this.dragonStatus) : null);
				}
			}
		}

		// Token: 0x060039EA RID: 14826 RVA: 0x0006ECC8 File Offset: 0x0006CEC8
		private bool ShouldSerializedragonStatus()
		{
			return this.dragonStatusSpecified;
		}

		// Token: 0x060039EB RID: 14827 RVA: 0x0006ECE0 File Offset: 0x0006CEE0
		private void ResetdragonStatus()
		{
			this.dragonStatusSpecified = false;
		}

		// Token: 0x170011C6 RID: 4550
		// (get) Token: 0x060039EC RID: 14828 RVA: 0x0006ECEC File Offset: 0x0006CEEC
		// (set) Token: 0x060039ED RID: 14829 RVA: 0x0006ED18 File Offset: 0x0006CF18
		[ProtoMember(4, IsRequired = false, Name = "dragonWeakLeftTime", DataFormat = DataFormat.TwosComplement)]
		public int dragonWeakLeftTime
		{
			get
			{
				return this._dragonWeakLeftTime ?? 0;
			}
			set
			{
				this._dragonWeakLeftTime = new int?(value);
			}
		}

		// Token: 0x170011C7 RID: 4551
		// (get) Token: 0x060039EE RID: 14830 RVA: 0x0006ED28 File Offset: 0x0006CF28
		// (set) Token: 0x060039EF RID: 14831 RVA: 0x0006ED48 File Offset: 0x0006CF48
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonWeakLeftTimeSpecified
		{
			get
			{
				return this._dragonWeakLeftTime != null;
			}
			set
			{
				bool flag = value == (this._dragonWeakLeftTime == null);
				if (flag)
				{
					this._dragonWeakLeftTime = (value ? new int?(this.dragonWeakLeftTime) : null);
				}
			}
		}

		// Token: 0x060039F0 RID: 14832 RVA: 0x0006ED8C File Offset: 0x0006CF8C
		private bool ShouldSerializedragonWeakLeftTime()
		{
			return this.dragonWeakLeftTimeSpecified;
		}

		// Token: 0x060039F1 RID: 14833 RVA: 0x0006EDA4 File Offset: 0x0006CFA4
		private void ResetdragonWeakLeftTime()
		{
			this.dragonWeakLeftTimeSpecified = false;
		}

		// Token: 0x170011C8 RID: 4552
		// (get) Token: 0x060039F2 RID: 14834 RVA: 0x0006EDB0 File Offset: 0x0006CFB0
		// (set) Token: 0x060039F3 RID: 14835 RVA: 0x0006EDDC File Offset: 0x0006CFDC
		[ProtoMember(5, IsRequired = false, Name = "isIconAppear", DataFormat = DataFormat.Default)]
		public bool isIconAppear
		{
			get
			{
				return this._isIconAppear ?? false;
			}
			set
			{
				this._isIconAppear = new bool?(value);
			}
		}

		// Token: 0x170011C9 RID: 4553
		// (get) Token: 0x060039F4 RID: 14836 RVA: 0x0006EDEC File Offset: 0x0006CFEC
		// (set) Token: 0x060039F5 RID: 14837 RVA: 0x0006EE0C File Offset: 0x0006D00C
		[XmlIgnore]
		[Browsable(false)]
		public bool isIconAppearSpecified
		{
			get
			{
				return this._isIconAppear != null;
			}
			set
			{
				bool flag = value == (this._isIconAppear == null);
				if (flag)
				{
					this._isIconAppear = (value ? new bool?(this.isIconAppear) : null);
				}
			}
		}

		// Token: 0x060039F6 RID: 14838 RVA: 0x0006EE50 File Offset: 0x0006D050
		private bool ShouldSerializeisIconAppear()
		{
			return this.isIconAppearSpecified;
		}

		// Token: 0x060039F7 RID: 14839 RVA: 0x0006EE68 File Offset: 0x0006D068
		private void ResetisIconAppear()
		{
			this.isIconAppearSpecified = false;
		}

		// Token: 0x060039F8 RID: 14840 RVA: 0x0006EE74 File Offset: 0x0006D074
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E5A RID: 3674
		private int? _sceneID;

		// Token: 0x04000E5B RID: 3675
		private int? _sceneType;

		// Token: 0x04000E5C RID: 3676
		private int? _dragonStatus;

		// Token: 0x04000E5D RID: 3677
		private int? _dragonWeakLeftTime;

		// Token: 0x04000E5E RID: 3678
		private bool? _isIconAppear;

		// Token: 0x04000E5F RID: 3679
		private IExtension extensionObject;
	}
}
