using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteInfo")]
	[Serializable]
	public class SpriteInfo : IExtensible
	{

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

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

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

		private bool ShouldSerializeSpriteID()
		{
			return this.SpriteIDSpecified;
		}

		private void ResetSpriteID()
		{
			this.SpriteIDSpecified = false;
		}

		[ProtoMember(3, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		[ProtoMember(5, Name = "AddValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AddValue
		{
			get
			{
				return this._AddValue;
			}
		}

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

		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		[ProtoMember(7, Name = "PassiveSkillID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> PassiveSkillID
		{
			get
			{
				return this._PassiveSkillID;
			}
		}

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

		private bool ShouldSerializeLevel()
		{
			return this.LevelSpecified;
		}

		private void ResetLevel()
		{
			this.LevelSpecified = false;
		}

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

		private bool ShouldSerializeEvolutionLevel()
		{
			return this.EvolutionLevelSpecified;
		}

		private void ResetEvolutionLevel()
		{
			this.EvolutionLevelSpecified = false;
		}

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

		private bool ShouldSerializeExp()
		{
			return this.ExpSpecified;
		}

		private void ResetExp()
		{
			this.ExpSpecified = false;
		}

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

		private bool ShouldSerializePowerPoint()
		{
			return this.PowerPointSpecified;
		}

		private void ResetPowerPoint()
		{
			this.PowerPointSpecified = false;
		}

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

		private bool ShouldSerializeTrainExp()
		{
			return this.TrainExpSpecified;
		}

		private void ResetTrainExp()
		{
			this.TrainExpSpecified = false;
		}

		[ProtoMember(13, Name = "EvoAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> EvoAttrID
		{
			get
			{
				return this._EvoAttrID;
			}
		}

		[ProtoMember(14, Name = "EvoAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> EvoAttrValue
		{
			get
			{
				return this._EvoAttrValue;
			}
		}

		[ProtoMember(15, Name = "ThisLevelEvoAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ThisLevelEvoAttrID
		{
			get
			{
				return this._ThisLevelEvoAttrID;
			}
		}

		[ProtoMember(16, Name = "ThisLevelEvoAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> ThisLevelEvoAttrValue
		{
			get
			{
				return this._ThisLevelEvoAttrValue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _SpriteID;

		private readonly List<uint> _AttrID = new List<uint>();

		private readonly List<double> _AttrValue = new List<double>();

		private readonly List<double> _AddValue = new List<double>();

		private uint? _SkillID;

		private readonly List<uint> _PassiveSkillID = new List<uint>();

		private uint? _Level;

		private uint? _EvolutionLevel;

		private uint? _Exp;

		private uint? _PowerPoint;

		private uint? _TrainExp;

		private readonly List<uint> _EvoAttrID = new List<uint>();

		private readonly List<double> _EvoAttrValue = new List<double>();

		private readonly List<uint> _ThisLevelEvoAttrID = new List<uint>();

		private readonly List<double> _ThisLevelEvoAttrValue = new List<double>();

		private IExtension extensionObject;
	}
}
