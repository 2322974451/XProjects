using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetSingle")]
	[Serializable]
	public class PetSingle : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public uint petid
		{
			get
			{
				return this._petid ?? 0U;
			}
			set
			{
				this._petid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new uint?(this.petid) : null);
				}
			}
		}

		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "sex", DataFormat = DataFormat.TwosComplement)]
		public uint sex
		{
			get
			{
				return this._sex ?? 0U;
			}
			set
			{
				this._sex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sexSpecified
		{
			get
			{
				return this._sex != null;
			}
			set
			{
				bool flag = value == (this._sex == null);
				if (flag)
				{
					this._sex = (value ? new uint?(this.sex) : null);
				}
			}
		}

		private bool ShouldSerializesex()
		{
			return this.sexSpecified;
		}

		private void Resetsex()
		{
			this.sexSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "power", DataFormat = DataFormat.TwosComplement)]
		public uint power
		{
			get
			{
				return this._power ?? 0U;
			}
			set
			{
				this._power = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerSpecified
		{
			get
			{
				return this._power != null;
			}
			set
			{
				bool flag = value == (this._power == null);
				if (flag)
				{
					this._power = (value ? new uint?(this.power) : null);
				}
			}
		}

		private bool ShouldSerializepower()
		{
			return this.powerSpecified;
		}

		private void Resetpower()
		{
			this.powerSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "mood", DataFormat = DataFormat.TwosComplement)]
		public uint mood
		{
			get
			{
				return this._mood ?? 0U;
			}
			set
			{
				this._mood = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moodSpecified
		{
			get
			{
				return this._mood != null;
			}
			set
			{
				bool flag = value == (this._mood == null);
				if (flag)
				{
					this._mood = (value ? new uint?(this.mood) : null);
				}
			}
		}

		private bool ShouldSerializemood()
		{
			return this.moodSpecified;
		}

		private void Resetmood()
		{
			this.moodSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		[ProtoMember(9, Name = "fixedskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fixedskills
		{
			get
			{
				return this._fixedskills;
			}
		}

		[ProtoMember(10, Name = "randskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> randskills
		{
			get
			{
				return this._randskills;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SPetRecord record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "max_level", DataFormat = DataFormat.TwosComplement)]
		public uint max_level
		{
			get
			{
				return this._max_level ?? 0U;
			}
			set
			{
				this._max_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool max_levelSpecified
		{
			get
			{
				return this._max_level != null;
			}
			set
			{
				bool flag = value == (this._max_level == null);
				if (flag)
				{
					this._max_level = (value ? new uint?(this.max_level) : null);
				}
			}
		}

		private bool ShouldSerializemax_level()
		{
			return this.max_levelSpecified;
		}

		private void Resetmax_level()
		{
			this.max_levelSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "canpairride", DataFormat = DataFormat.Default)]
		public bool canpairride
		{
			get
			{
				return this._canpairride ?? false;
			}
			set
			{
				this._canpairride = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canpairrideSpecified
		{
			get
			{
				return this._canpairride != null;
			}
			set
			{
				bool flag = value == (this._canpairride == null);
				if (flag)
				{
					this._canpairride = (value ? new bool?(this.canpairride) : null);
				}
			}
		}

		private bool ShouldSerializecanpairride()
		{
			return this.canpairrideSpecified;
		}

		private void Resetcanpairride()
		{
			this.canpairrideSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _petid;

		private uint? _level;

		private uint? _exp;

		private uint? _sex;

		private uint? _power;

		private uint? _mood;

		private uint? _hungry;

		private readonly List<uint> _fixedskills = new List<uint>();

		private readonly List<uint> _randskills = new List<uint>();

		private SPetRecord _record = null;

		private uint? _max_level;

		private bool? _canpairride;

		private IExtension extensionObject;
	}
}
