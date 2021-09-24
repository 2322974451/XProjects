using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillChangedData")]
	[Serializable]
	public class SkillChangedData : IExtensible
	{

		[ProtoMember(1, Name = "newSkill", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newSkill
		{
			get
			{
				return this._newSkill;
			}
		}

		[ProtoMember(2, Name = "newSkillLevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newSkillLevel
		{
			get
			{
				return this._newSkillLevel;
			}
		}

		[ProtoMember(3, Name = "removeSkill", DataFormat = DataFormat.TwosComplement)]
		public List<uint> removeSkill
		{
			get
			{
				return this._removeSkill;
			}
		}

		[ProtoMember(4, Name = "changedSkillHash", DataFormat = DataFormat.TwosComplement)]
		public List<uint> changedSkillHash
		{
			get
			{
				return this._changedSkillHash;
			}
		}

		[ProtoMember(5, Name = "changedSkillLevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> changedSkillLevel
		{
			get
			{
				return this._changedSkillLevel;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "skillpoint", DataFormat = DataFormat.TwosComplement)]
		public int skillpoint
		{
			get
			{
				return this._skillpoint ?? 0;
			}
			set
			{
				this._skillpoint = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointSpecified
		{
			get
			{
				return this._skillpoint != null;
			}
			set
			{
				bool flag = value == (this._skillpoint == null);
				if (flag)
				{
					this._skillpoint = (value ? new int?(this.skillpoint) : null);
				}
			}
		}

		private bool ShouldSerializeskillpoint()
		{
			return this.skillpointSpecified;
		}

		private void Resetskillpoint()
		{
			this.skillpointSpecified = false;
		}

		[ProtoMember(7, Name = "skillSlot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillSlot
		{
			get
			{
				return this._skillSlot;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "skillType", DataFormat = DataFormat.TwosComplement)]
		public int skillType
		{
			get
			{
				return this._skillType ?? 0;
			}
			set
			{
				this._skillType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillTypeSpecified
		{
			get
			{
				return this._skillType != null;
			}
			set
			{
				bool flag = value == (this._skillType == null);
				if (flag)
				{
					this._skillType = (value ? new int?(this.skillType) : null);
				}
			}
		}

		private bool ShouldSerializeskillType()
		{
			return this.skillTypeSpecified;
		}

		private void ResetskillType()
		{
			this.skillTypeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "skillpointtwo", DataFormat = DataFormat.TwosComplement)]
		public uint skillpointtwo
		{
			get
			{
				return this._skillpointtwo ?? 0U;
			}
			set
			{
				this._skillpointtwo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointtwoSpecified
		{
			get
			{
				return this._skillpointtwo != null;
			}
			set
			{
				bool flag = value == (this._skillpointtwo == null);
				if (flag)
				{
					this._skillpointtwo = (value ? new uint?(this.skillpointtwo) : null);
				}
			}
		}

		private bool ShouldSerializeskillpointtwo()
		{
			return this.skillpointtwoSpecified;
		}

		private void Resetskillpointtwo()
		{
			this.skillpointtwoSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "awakepoint", DataFormat = DataFormat.TwosComplement)]
		public uint awakepoint
		{
			get
			{
				return this._awakepoint ?? 0U;
			}
			set
			{
				this._awakepoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool awakepointSpecified
		{
			get
			{
				return this._awakepoint != null;
			}
			set
			{
				bool flag = value == (this._awakepoint == null);
				if (flag)
				{
					this._awakepoint = (value ? new uint?(this.awakepoint) : null);
				}
			}
		}

		private bool ShouldSerializeawakepoint()
		{
			return this.awakepointSpecified;
		}

		private void Resetawakepoint()
		{
			this.awakepointSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "awakepointtwo", DataFormat = DataFormat.TwosComplement)]
		public uint awakepointtwo
		{
			get
			{
				return this._awakepointtwo ?? 0U;
			}
			set
			{
				this._awakepointtwo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool awakepointtwoSpecified
		{
			get
			{
				return this._awakepointtwo != null;
			}
			set
			{
				bool flag = value == (this._awakepointtwo == null);
				if (flag)
				{
					this._awakepointtwo = (value ? new uint?(this.awakepointtwo) : null);
				}
			}
		}

		private bool ShouldSerializeawakepointtwo()
		{
			return this.awakepointtwoSpecified;
		}

		private void Resetawakepointtwo()
		{
			this.awakepointtwoSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _newSkill = new List<uint>();

		private readonly List<uint> _newSkillLevel = new List<uint>();

		private readonly List<uint> _removeSkill = new List<uint>();

		private readonly List<uint> _changedSkillHash = new List<uint>();

		private readonly List<uint> _changedSkillLevel = new List<uint>();

		private int? _skillpoint;

		private readonly List<uint> _skillSlot = new List<uint>();

		private int? _skillType;

		private uint? _skillpointtwo;

		private uint? _awakepoint;

		private uint? _awakepointtwo;

		private IExtension extensionObject;
	}
}
