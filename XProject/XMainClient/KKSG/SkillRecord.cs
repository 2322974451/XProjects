using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillRecord")]
	[Serializable]
	public class SkillRecord : IExtensible
	{

		[ProtoMember(1, Name = "Skills", DataFormat = DataFormat.Default)]
		public List<SkillInfo> Skills
		{
			get
			{
				return this._Skills;
			}
		}

		[ProtoMember(2, Name = "SkillSlot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> SkillSlot
		{
			get
			{
				return this._SkillSlot;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "freeresetskill", DataFormat = DataFormat.Default)]
		public bool freeresetskill
		{
			get
			{
				return this._freeresetskill ?? false;
			}
			set
			{
				this._freeresetskill = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeresetskillSpecified
		{
			get
			{
				return this._freeresetskill != null;
			}
			set
			{
				bool flag = value == (this._freeresetskill == null);
				if (flag)
				{
					this._freeresetskill = (value ? new bool?(this.freeresetskill) : null);
				}
			}
		}

		private bool ShouldSerializefreeresetskill()
		{
			return this.freeresetskillSpecified;
		}

		private void Resetfreeresetskill()
		{
			this.freeresetskillSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		[ProtoMember(5, Name = "SkillsTwo", DataFormat = DataFormat.Default)]
		public List<SkillInfo> SkillsTwo
		{
			get
			{
				return this._SkillsTwo;
			}
		}

		[ProtoMember(6, Name = "SkillSlotTwo", DataFormat = DataFormat.TwosComplement)]
		public List<uint> SkillSlotTwo
		{
			get
			{
				return this._SkillSlotTwo;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "awakepoint", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SkillInfo> _Skills = new List<SkillInfo>();

		private readonly List<uint> _SkillSlot = new List<uint>();

		private bool? _freeresetskill;

		private uint? _index;

		private readonly List<SkillInfo> _SkillsTwo = new List<SkillInfo>();

		private readonly List<uint> _SkillSlotTwo = new List<uint>();

		private uint? _awakepoint;

		private IExtension extensionObject;
	}
}
