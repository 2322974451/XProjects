using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057C RID: 1404
	[ProtoContract(Name = "SpriteInfo")]
	[Serializable]
	public class SpriteInfo : IExtensible
	{
		// Token: 0x1700162F RID: 5679
		// (get) Token: 0x06004862 RID: 18530 RVA: 0x00089854 File Offset: 0x00087A54
		// (set) Token: 0x06004863 RID: 18531 RVA: 0x00089881 File Offset: 0x00087A81
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17001630 RID: 5680
		// (get) Token: 0x06004864 RID: 18532 RVA: 0x00089890 File Offset: 0x00087A90
		// (set) Token: 0x06004865 RID: 18533 RVA: 0x000898B0 File Offset: 0x00087AB0
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06004866 RID: 18534 RVA: 0x000898F4 File Offset: 0x00087AF4
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06004867 RID: 18535 RVA: 0x0008990C File Offset: 0x00087B0C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001631 RID: 5681
		// (get) Token: 0x06004868 RID: 18536 RVA: 0x00089918 File Offset: 0x00087B18
		// (set) Token: 0x06004869 RID: 18537 RVA: 0x00089944 File Offset: 0x00087B44
		[ProtoMember(2, IsRequired = false, Name = "SpriteID", DataFormat = DataFormat.TwosComplement)]
		public uint SpriteID
		{
			get
			{
				return this._SpriteID ?? 0U;
			}
			set
			{
				this._SpriteID = new uint?(value);
			}
		}

		// Token: 0x17001632 RID: 5682
		// (get) Token: 0x0600486A RID: 18538 RVA: 0x00089954 File Offset: 0x00087B54
		// (set) Token: 0x0600486B RID: 18539 RVA: 0x00089974 File Offset: 0x00087B74
		[XmlIgnore]
		[Browsable(false)]
		public bool SpriteIDSpecified
		{
			get
			{
				return this._SpriteID != null;
			}
			set
			{
				bool flag = value == (this._SpriteID == null);
				if (flag)
				{
					this._SpriteID = (value ? new uint?(this.SpriteID) : null);
				}
			}
		}

		// Token: 0x0600486C RID: 18540 RVA: 0x000899B8 File Offset: 0x00087BB8
		private bool ShouldSerializeSpriteID()
		{
			return this.SpriteIDSpecified;
		}

		// Token: 0x0600486D RID: 18541 RVA: 0x000899D0 File Offset: 0x00087BD0
		private void ResetSpriteID()
		{
			this.SpriteIDSpecified = false;
		}

		// Token: 0x17001633 RID: 5683
		// (get) Token: 0x0600486E RID: 18542 RVA: 0x000899DC File Offset: 0x00087BDC
		[ProtoMember(3, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		// Token: 0x17001634 RID: 5684
		// (get) Token: 0x0600486F RID: 18543 RVA: 0x000899F4 File Offset: 0x00087BF4
		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		// Token: 0x17001635 RID: 5685
		// (get) Token: 0x06004870 RID: 18544 RVA: 0x00089A0C File Offset: 0x00087C0C
		[ProtoMember(5, Name = "AddValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AddValue
		{
			get
			{
				return this._AddValue;
			}
		}

		// Token: 0x17001636 RID: 5686
		// (get) Token: 0x06004871 RID: 18545 RVA: 0x00089A24 File Offset: 0x00087C24
		// (set) Token: 0x06004872 RID: 18546 RVA: 0x00089A50 File Offset: 0x00087C50
		[ProtoMember(6, IsRequired = false, Name = "SkillID", DataFormat = DataFormat.TwosComplement)]
		public uint SkillID
		{
			get
			{
				return this._SkillID ?? 0U;
			}
			set
			{
				this._SkillID = new uint?(value);
			}
		}

		// Token: 0x17001637 RID: 5687
		// (get) Token: 0x06004873 RID: 18547 RVA: 0x00089A60 File Offset: 0x00087C60
		// (set) Token: 0x06004874 RID: 18548 RVA: 0x00089A80 File Offset: 0x00087C80
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIDSpecified
		{
			get
			{
				return this._SkillID != null;
			}
			set
			{
				bool flag = value == (this._SkillID == null);
				if (flag)
				{
					this._SkillID = (value ? new uint?(this.SkillID) : null);
				}
			}
		}

		// Token: 0x06004875 RID: 18549 RVA: 0x00089AC4 File Offset: 0x00087CC4
		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		// Token: 0x06004876 RID: 18550 RVA: 0x00089ADC File Offset: 0x00087CDC
		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		// Token: 0x17001638 RID: 5688
		// (get) Token: 0x06004877 RID: 18551 RVA: 0x00089AE8 File Offset: 0x00087CE8
		[ProtoMember(7, Name = "PassiveSkillID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> PassiveSkillID
		{
			get
			{
				return this._PassiveSkillID;
			}
		}

		// Token: 0x17001639 RID: 5689
		// (get) Token: 0x06004878 RID: 18552 RVA: 0x00089B00 File Offset: 0x00087D00
		// (set) Token: 0x06004879 RID: 18553 RVA: 0x00089B2C File Offset: 0x00087D2C
		[ProtoMember(8, IsRequired = false, Name = "Level", DataFormat = DataFormat.TwosComplement)]
		public uint Level
		{
			get
			{
				return this._Level ?? 0U;
			}
			set
			{
				this._Level = new uint?(value);
			}
		}

		// Token: 0x1700163A RID: 5690
		// (get) Token: 0x0600487A RID: 18554 RVA: 0x00089B3C File Offset: 0x00087D3C
		// (set) Token: 0x0600487B RID: 18555 RVA: 0x00089B5C File Offset: 0x00087D5C
		[XmlIgnore]
		[Browsable(false)]
		public bool LevelSpecified
		{
			get
			{
				return this._Level != null;
			}
			set
			{
				bool flag = value == (this._Level == null);
				if (flag)
				{
					this._Level = (value ? new uint?(this.Level) : null);
				}
			}
		}

		// Token: 0x0600487C RID: 18556 RVA: 0x00089BA0 File Offset: 0x00087DA0
		private bool ShouldSerializeLevel()
		{
			return this.LevelSpecified;
		}

		// Token: 0x0600487D RID: 18557 RVA: 0x00089BB8 File Offset: 0x00087DB8
		private void ResetLevel()
		{
			this.LevelSpecified = false;
		}

		// Token: 0x1700163B RID: 5691
		// (get) Token: 0x0600487E RID: 18558 RVA: 0x00089BC4 File Offset: 0x00087DC4
		// (set) Token: 0x0600487F RID: 18559 RVA: 0x00089BF0 File Offset: 0x00087DF0
		[ProtoMember(9, IsRequired = false, Name = "EvolutionLevel", DataFormat = DataFormat.TwosComplement)]
		public uint EvolutionLevel
		{
			get
			{
				return this._EvolutionLevel ?? 0U;
			}
			set
			{
				this._EvolutionLevel = new uint?(value);
			}
		}

		// Token: 0x1700163C RID: 5692
		// (get) Token: 0x06004880 RID: 18560 RVA: 0x00089C00 File Offset: 0x00087E00
		// (set) Token: 0x06004881 RID: 18561 RVA: 0x00089C20 File Offset: 0x00087E20
		[XmlIgnore]
		[Browsable(false)]
		public bool EvolutionLevelSpecified
		{
			get
			{
				return this._EvolutionLevel != null;
			}
			set
			{
				bool flag = value == (this._EvolutionLevel == null);
				if (flag)
				{
					this._EvolutionLevel = (value ? new uint?(this.EvolutionLevel) : null);
				}
			}
		}

		// Token: 0x06004882 RID: 18562 RVA: 0x00089C64 File Offset: 0x00087E64
		private bool ShouldSerializeEvolutionLevel()
		{
			return this.EvolutionLevelSpecified;
		}

		// Token: 0x06004883 RID: 18563 RVA: 0x00089C7C File Offset: 0x00087E7C
		private void ResetEvolutionLevel()
		{
			this.EvolutionLevelSpecified = false;
		}

		// Token: 0x1700163D RID: 5693
		// (get) Token: 0x06004884 RID: 18564 RVA: 0x00089C88 File Offset: 0x00087E88
		// (set) Token: 0x06004885 RID: 18565 RVA: 0x00089CB4 File Offset: 0x00087EB4
		[ProtoMember(10, IsRequired = false, Name = "Exp", DataFormat = DataFormat.TwosComplement)]
		public uint Exp
		{
			get
			{
				return this._Exp ?? 0U;
			}
			set
			{
				this._Exp = new uint?(value);
			}
		}

		// Token: 0x1700163E RID: 5694
		// (get) Token: 0x06004886 RID: 18566 RVA: 0x00089CC4 File Offset: 0x00087EC4
		// (set) Token: 0x06004887 RID: 18567 RVA: 0x00089CE4 File Offset: 0x00087EE4
		[XmlIgnore]
		[Browsable(false)]
		public bool ExpSpecified
		{
			get
			{
				return this._Exp != null;
			}
			set
			{
				bool flag = value == (this._Exp == null);
				if (flag)
				{
					this._Exp = (value ? new uint?(this.Exp) : null);
				}
			}
		}

		// Token: 0x06004888 RID: 18568 RVA: 0x00089D28 File Offset: 0x00087F28
		private bool ShouldSerializeExp()
		{
			return this.ExpSpecified;
		}

		// Token: 0x06004889 RID: 18569 RVA: 0x00089D40 File Offset: 0x00087F40
		private void ResetExp()
		{
			this.ExpSpecified = false;
		}

		// Token: 0x1700163F RID: 5695
		// (get) Token: 0x0600488A RID: 18570 RVA: 0x00089D4C File Offset: 0x00087F4C
		// (set) Token: 0x0600488B RID: 18571 RVA: 0x00089D78 File Offset: 0x00087F78
		[ProtoMember(11, IsRequired = false, Name = "PowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint PowerPoint
		{
			get
			{
				return this._PowerPoint ?? 0U;
			}
			set
			{
				this._PowerPoint = new uint?(value);
			}
		}

		// Token: 0x17001640 RID: 5696
		// (get) Token: 0x0600488C RID: 18572 RVA: 0x00089D88 File Offset: 0x00087F88
		// (set) Token: 0x0600488D RID: 18573 RVA: 0x00089DA8 File Offset: 0x00087FA8
		[XmlIgnore]
		[Browsable(false)]
		public bool PowerPointSpecified
		{
			get
			{
				return this._PowerPoint != null;
			}
			set
			{
				bool flag = value == (this._PowerPoint == null);
				if (flag)
				{
					this._PowerPoint = (value ? new uint?(this.PowerPoint) : null);
				}
			}
		}

		// Token: 0x0600488E RID: 18574 RVA: 0x00089DEC File Offset: 0x00087FEC
		private bool ShouldSerializePowerPoint()
		{
			return this.PowerPointSpecified;
		}

		// Token: 0x0600488F RID: 18575 RVA: 0x00089E04 File Offset: 0x00088004
		private void ResetPowerPoint()
		{
			this.PowerPointSpecified = false;
		}

		// Token: 0x17001641 RID: 5697
		// (get) Token: 0x06004890 RID: 18576 RVA: 0x00089E10 File Offset: 0x00088010
		// (set) Token: 0x06004891 RID: 18577 RVA: 0x00089E3C File Offset: 0x0008803C
		[ProtoMember(12, IsRequired = false, Name = "TrainExp", DataFormat = DataFormat.TwosComplement)]
		public uint TrainExp
		{
			get
			{
				return this._TrainExp ?? 0U;
			}
			set
			{
				this._TrainExp = new uint?(value);
			}
		}

		// Token: 0x17001642 RID: 5698
		// (get) Token: 0x06004892 RID: 18578 RVA: 0x00089E4C File Offset: 0x0008804C
		// (set) Token: 0x06004893 RID: 18579 RVA: 0x00089E6C File Offset: 0x0008806C
		[XmlIgnore]
		[Browsable(false)]
		public bool TrainExpSpecified
		{
			get
			{
				return this._TrainExp != null;
			}
			set
			{
				bool flag = value == (this._TrainExp == null);
				if (flag)
				{
					this._TrainExp = (value ? new uint?(this.TrainExp) : null);
				}
			}
		}

		// Token: 0x06004894 RID: 18580 RVA: 0x00089EB0 File Offset: 0x000880B0
		private bool ShouldSerializeTrainExp()
		{
			return this.TrainExpSpecified;
		}

		// Token: 0x06004895 RID: 18581 RVA: 0x00089EC8 File Offset: 0x000880C8
		private void ResetTrainExp()
		{
			this.TrainExpSpecified = false;
		}

		// Token: 0x17001643 RID: 5699
		// (get) Token: 0x06004896 RID: 18582 RVA: 0x00089ED4 File Offset: 0x000880D4
		[ProtoMember(13, Name = "EvoAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EvoAttrID
		{
			get
			{
				return this._EvoAttrID;
			}
		}

		// Token: 0x17001644 RID: 5700
		// (get) Token: 0x06004897 RID: 18583 RVA: 0x00089EEC File Offset: 0x000880EC
		[ProtoMember(14, Name = "EvoAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> EvoAttrValue
		{
			get
			{
				return this._EvoAttrValue;
			}
		}

		// Token: 0x17001645 RID: 5701
		// (get) Token: 0x06004898 RID: 18584 RVA: 0x00089F04 File Offset: 0x00088104
		[ProtoMember(15, Name = "ThisLevelEvoAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ThisLevelEvoAttrID
		{
			get
			{
				return this._ThisLevelEvoAttrID;
			}
		}

		// Token: 0x17001646 RID: 5702
		// (get) Token: 0x06004899 RID: 18585 RVA: 0x00089F1C File Offset: 0x0008811C
		[ProtoMember(16, Name = "ThisLevelEvoAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> ThisLevelEvoAttrValue
		{
			get
			{
				return this._ThisLevelEvoAttrValue;
			}
		}

		// Token: 0x0600489A RID: 18586 RVA: 0x00089F34 File Offset: 0x00088134
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400121B RID: 4635
		private ulong? _uid;

		// Token: 0x0400121C RID: 4636
		private uint? _SpriteID;

		// Token: 0x0400121D RID: 4637
		private readonly List<uint> _AttrID = new List<uint>();

		// Token: 0x0400121E RID: 4638
		private readonly List<double> _AttrValue = new List<double>();

		// Token: 0x0400121F RID: 4639
		private readonly List<double> _AddValue = new List<double>();

		// Token: 0x04001220 RID: 4640
		private uint? _SkillID;

		// Token: 0x04001221 RID: 4641
		private readonly List<uint> _PassiveSkillID = new List<uint>();

		// Token: 0x04001222 RID: 4642
		private uint? _Level;

		// Token: 0x04001223 RID: 4643
		private uint? _EvolutionLevel;

		// Token: 0x04001224 RID: 4644
		private uint? _Exp;

		// Token: 0x04001225 RID: 4645
		private uint? _PowerPoint;

		// Token: 0x04001226 RID: 4646
		private uint? _TrainExp;

		// Token: 0x04001227 RID: 4647
		private readonly List<uint> _EvoAttrID = new List<uint>();

		// Token: 0x04001228 RID: 4648
		private readonly List<double> _EvoAttrValue = new List<double>();

		// Token: 0x04001229 RID: 4649
		private readonly List<uint> _ThisLevelEvoAttrID = new List<uint>();

		// Token: 0x0400122A RID: 4650
		private readonly List<double> _ThisLevelEvoAttrValue = new List<double>();

		// Token: 0x0400122B RID: 4651
		private IExtension extensionObject;
	}
}
