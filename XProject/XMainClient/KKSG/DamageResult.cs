using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000581 RID: 1409
	[ProtoContract(Name = "DamageResult")]
	[Serializable]
	public class DamageResult : IExtensible
	{
		// Token: 0x17001675 RID: 5749
		// (get) Token: 0x06004928 RID: 18728 RVA: 0x0008B098 File Offset: 0x00089298
		// (set) Token: 0x06004929 RID: 18729 RVA: 0x0008B0C4 File Offset: 0x000892C4
		[ProtoMember(1, IsRequired = false, Name = "Result", DataFormat = DataFormat.TwosComplement)]
		public uint Result
		{
			get
			{
				return this._Result ?? 0U;
			}
			set
			{
				this._Result = new uint?(value);
			}
		}

		// Token: 0x17001676 RID: 5750
		// (get) Token: 0x0600492A RID: 18730 RVA: 0x0008B0D4 File Offset: 0x000892D4
		// (set) Token: 0x0600492B RID: 18731 RVA: 0x0008B0F4 File Offset: 0x000892F4
		[XmlIgnore]
		[Browsable(false)]
		public bool ResultSpecified
		{
			get
			{
				return this._Result != null;
			}
			set
			{
				bool flag = value == (this._Result == null);
				if (flag)
				{
					this._Result = (value ? new uint?(this.Result) : null);
				}
			}
		}

		// Token: 0x0600492C RID: 18732 RVA: 0x0008B138 File Offset: 0x00089338
		private bool ShouldSerializeResult()
		{
			return this.ResultSpecified;
		}

		// Token: 0x0600492D RID: 18733 RVA: 0x0008B150 File Offset: 0x00089350
		private void ResetResult()
		{
			this.ResultSpecified = false;
		}

		// Token: 0x17001677 RID: 5751
		// (get) Token: 0x0600492E RID: 18734 RVA: 0x0008B15C File Offset: 0x0008935C
		// (set) Token: 0x0600492F RID: 18735 RVA: 0x0008B190 File Offset: 0x00089390
		[ProtoMember(2, IsRequired = false, Name = "Value", DataFormat = DataFormat.TwosComplement)]
		public double Value
		{
			get
			{
				return this._Value ?? 0.0;
			}
			set
			{
				this._Value = new double?(value);
			}
		}

		// Token: 0x17001678 RID: 5752
		// (get) Token: 0x06004930 RID: 18736 RVA: 0x0008B1A0 File Offset: 0x000893A0
		// (set) Token: 0x06004931 RID: 18737 RVA: 0x0008B1C0 File Offset: 0x000893C0
		[XmlIgnore]
		[Browsable(false)]
		public bool ValueSpecified
		{
			get
			{
				return this._Value != null;
			}
			set
			{
				bool flag = value == (this._Value == null);
				if (flag)
				{
					this._Value = (value ? new double?(this.Value) : null);
				}
			}
		}

		// Token: 0x06004932 RID: 18738 RVA: 0x0008B204 File Offset: 0x00089404
		private bool ShouldSerializeValue()
		{
			return this.ValueSpecified;
		}

		// Token: 0x06004933 RID: 18739 RVA: 0x0008B21C File Offset: 0x0008941C
		private void ResetValue()
		{
			this.ValueSpecified = false;
		}

		// Token: 0x17001679 RID: 5753
		// (get) Token: 0x06004934 RID: 18740 RVA: 0x0008B228 File Offset: 0x00089428
		// (set) Token: 0x06004935 RID: 18741 RVA: 0x0008B254 File Offset: 0x00089454
		[ProtoMember(3, IsRequired = false, Name = "Flag", DataFormat = DataFormat.TwosComplement)]
		public int Flag
		{
			get
			{
				return this._Flag ?? 0;
			}
			set
			{
				this._Flag = new int?(value);
			}
		}

		// Token: 0x1700167A RID: 5754
		// (get) Token: 0x06004936 RID: 18742 RVA: 0x0008B264 File Offset: 0x00089464
		// (set) Token: 0x06004937 RID: 18743 RVA: 0x0008B284 File Offset: 0x00089484
		[XmlIgnore]
		[Browsable(false)]
		public bool FlagSpecified
		{
			get
			{
				return this._Flag != null;
			}
			set
			{
				bool flag = value == (this._Flag == null);
				if (flag)
				{
					this._Flag = (value ? new int?(this.Flag) : null);
				}
			}
		}

		// Token: 0x06004938 RID: 18744 RVA: 0x0008B2C8 File Offset: 0x000894C8
		private bool ShouldSerializeFlag()
		{
			return this.FlagSpecified;
		}

		// Token: 0x06004939 RID: 18745 RVA: 0x0008B2E0 File Offset: 0x000894E0
		private void ResetFlag()
		{
			this.FlagSpecified = false;
		}

		// Token: 0x1700167B RID: 5755
		// (get) Token: 0x0600493A RID: 18746 RVA: 0x0008B2EC File Offset: 0x000894EC
		// (set) Token: 0x0600493B RID: 18747 RVA: 0x0008B318 File Offset: 0x00089518
		[ProtoMember(4, IsRequired = false, Name = "DamageType", DataFormat = DataFormat.TwosComplement)]
		public uint DamageType
		{
			get
			{
				return this._DamageType ?? 0U;
			}
			set
			{
				this._DamageType = new uint?(value);
			}
		}

		// Token: 0x1700167C RID: 5756
		// (get) Token: 0x0600493C RID: 18748 RVA: 0x0008B328 File Offset: 0x00089528
		// (set) Token: 0x0600493D RID: 18749 RVA: 0x0008B348 File Offset: 0x00089548
		[XmlIgnore]
		[Browsable(false)]
		public bool DamageTypeSpecified
		{
			get
			{
				return this._DamageType != null;
			}
			set
			{
				bool flag = value == (this._DamageType == null);
				if (flag)
				{
					this._DamageType = (value ? new uint?(this.DamageType) : null);
				}
			}
		}

		// Token: 0x0600493E RID: 18750 RVA: 0x0008B38C File Offset: 0x0008958C
		private bool ShouldSerializeDamageType()
		{
			return this.DamageTypeSpecified;
		}

		// Token: 0x0600493F RID: 18751 RVA: 0x0008B3A4 File Offset: 0x000895A4
		private void ResetDamageType()
		{
			this.DamageTypeSpecified = false;
		}

		// Token: 0x1700167D RID: 5757
		// (get) Token: 0x06004940 RID: 18752 RVA: 0x0008B3B0 File Offset: 0x000895B0
		// (set) Token: 0x06004941 RID: 18753 RVA: 0x0008B3DC File Offset: 0x000895DC
		[ProtoMember(5, IsRequired = false, Name = "ElementType", DataFormat = DataFormat.TwosComplement)]
		public int ElementType
		{
			get
			{
				return this._ElementType ?? 0;
			}
			set
			{
				this._ElementType = new int?(value);
			}
		}

		// Token: 0x1700167E RID: 5758
		// (get) Token: 0x06004942 RID: 18754 RVA: 0x0008B3EC File Offset: 0x000895EC
		// (set) Token: 0x06004943 RID: 18755 RVA: 0x0008B40C File Offset: 0x0008960C
		[XmlIgnore]
		[Browsable(false)]
		public bool ElementTypeSpecified
		{
			get
			{
				return this._ElementType != null;
			}
			set
			{
				bool flag = value == (this._ElementType == null);
				if (flag)
				{
					this._ElementType = (value ? new int?(this.ElementType) : null);
				}
			}
		}

		// Token: 0x06004944 RID: 18756 RVA: 0x0008B450 File Offset: 0x00089650
		private bool ShouldSerializeElementType()
		{
			return this.ElementTypeSpecified;
		}

		// Token: 0x06004945 RID: 18757 RVA: 0x0008B468 File Offset: 0x00089668
		private void ResetElementType()
		{
			this.ElementTypeSpecified = false;
		}

		// Token: 0x1700167F RID: 5759
		// (get) Token: 0x06004946 RID: 18758 RVA: 0x0008B474 File Offset: 0x00089674
		// (set) Token: 0x06004947 RID: 18759 RVA: 0x0008B4A0 File Offset: 0x000896A0
		[ProtoMember(6, IsRequired = false, Name = "IsTargetDead", DataFormat = DataFormat.Default)]
		public bool IsTargetDead
		{
			get
			{
				return this._IsTargetDead ?? false;
			}
			set
			{
				this._IsTargetDead = new bool?(value);
			}
		}

		// Token: 0x17001680 RID: 5760
		// (get) Token: 0x06004948 RID: 18760 RVA: 0x0008B4B0 File Offset: 0x000896B0
		// (set) Token: 0x06004949 RID: 18761 RVA: 0x0008B4D0 File Offset: 0x000896D0
		[XmlIgnore]
		[Browsable(false)]
		public bool IsTargetDeadSpecified
		{
			get
			{
				return this._IsTargetDead != null;
			}
			set
			{
				bool flag = value == (this._IsTargetDead == null);
				if (flag)
				{
					this._IsTargetDead = (value ? new bool?(this.IsTargetDead) : null);
				}
			}
		}

		// Token: 0x0600494A RID: 18762 RVA: 0x0008B514 File Offset: 0x00089714
		private bool ShouldSerializeIsTargetDead()
		{
			return this.IsTargetDeadSpecified;
		}

		// Token: 0x0600494B RID: 18763 RVA: 0x0008B52C File Offset: 0x0008972C
		private void ResetIsTargetDead()
		{
			this.IsTargetDeadSpecified = false;
		}

		// Token: 0x17001681 RID: 5761
		// (get) Token: 0x0600494C RID: 18764 RVA: 0x0008B538 File Offset: 0x00089738
		// (set) Token: 0x0600494D RID: 18765 RVA: 0x0008B564 File Offset: 0x00089764
		[ProtoMember(7, IsRequired = false, Name = "ComboCount", DataFormat = DataFormat.TwosComplement)]
		public int ComboCount
		{
			get
			{
				return this._ComboCount ?? 0;
			}
			set
			{
				this._ComboCount = new int?(value);
			}
		}

		// Token: 0x17001682 RID: 5762
		// (get) Token: 0x0600494E RID: 18766 RVA: 0x0008B574 File Offset: 0x00089774
		// (set) Token: 0x0600494F RID: 18767 RVA: 0x0008B594 File Offset: 0x00089794
		[XmlIgnore]
		[Browsable(false)]
		public bool ComboCountSpecified
		{
			get
			{
				return this._ComboCount != null;
			}
			set
			{
				bool flag = value == (this._ComboCount == null);
				if (flag)
				{
					this._ComboCount = (value ? new int?(this.ComboCount) : null);
				}
			}
		}

		// Token: 0x06004950 RID: 18768 RVA: 0x0008B5D8 File Offset: 0x000897D8
		private bool ShouldSerializeComboCount()
		{
			return this.ComboCountSpecified;
		}

		// Token: 0x06004951 RID: 18769 RVA: 0x0008B5F0 File Offset: 0x000897F0
		private void ResetComboCount()
		{
			this.ComboCountSpecified = false;
		}

		// Token: 0x06004952 RID: 18770 RVA: 0x0008B5FC File Offset: 0x000897FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001249 RID: 4681
		private uint? _Result;

		// Token: 0x0400124A RID: 4682
		private double? _Value;

		// Token: 0x0400124B RID: 4683
		private int? _Flag;

		// Token: 0x0400124C RID: 4684
		private uint? _DamageType;

		// Token: 0x0400124D RID: 4685
		private int? _ElementType;

		// Token: 0x0400124E RID: 4686
		private bool? _IsTargetDead;

		// Token: 0x0400124F RID: 4687
		private int? _ComboCount;

		// Token: 0x04001250 RID: 4688
		private IExtension extensionObject;
	}
}
