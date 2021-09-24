using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UnitAppearance")]
	[Serializable]
	public class UnitAppearance : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uID", DataFormat = DataFormat.TwosComplement)]
		public ulong uID
		{
			get
			{
				return this._uID ?? 0UL;
			}
			set
			{
				this._uID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uIDSpecified
		{
			get
			{
				return this._uID != null;
			}
			set
			{
				bool flag = value == (this._uID == null);
				if (flag)
				{
					this._uID = (value ? new ulong?(this.uID) : null);
				}
			}
		}

		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "unitName", DataFormat = DataFormat.Default)]
		public string unitName
		{
			get
			{
				return this._unitName ?? "";
			}
			set
			{
				this._unitName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unitNameSpecified
		{
			get
			{
				return this._unitName != null;
			}
			set
			{
				bool flag = value == (this._unitName == null);
				if (flag)
				{
					this._unitName = (value ? this.unitName : null);
				}
			}
		}

		private bool ShouldSerializeunitName()
		{
			return this.unitNameSpecified;
		}

		private void ResetunitName()
		{
			this.unitNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "unitType", DataFormat = DataFormat.TwosComplement)]
		public uint unitType
		{
			get
			{
				return this._unitType ?? 0U;
			}
			set
			{
				this._unitType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unitTypeSpecified
		{
			get
			{
				return this._unitType != null;
			}
			set
			{
				bool flag = value == (this._unitType == null);
				if (flag)
				{
					this._unitType = (value ? new uint?(this.unitType) : null);
				}
			}
		}

		private bool ShouldSerializeunitType()
		{
			return this.unitTypeSpecified;
		}

		private void ResetunitType()
		{
			this.unitTypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "position", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "direction", DataFormat = DataFormat.FixedSize)]
		public float direction
		{
			get
			{
				return this._direction ?? 0f;
			}
			set
			{
				this._direction = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool directionSpecified
		{
			get
			{
				return this._direction != null;
			}
			set
			{
				bool flag = value == (this._direction == null);
				if (flag)
				{
					this._direction = (value ? new float?(this.direction) : null);
				}
			}
		}

		private bool ShouldSerializedirection()
		{
			return this.directionSpecified;
		}

		private void Resetdirection()
		{
			this.directionSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "attributes", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Attribute attributes
		{
			get
			{
				return this._attributes;
			}
			set
			{
				this._attributes = value;
			}
		}

		[ProtoMember(7, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "waveID", DataFormat = DataFormat.TwosComplement)]
		public uint waveID
		{
			get
			{
				return this._waveID ?? 0U;
			}
			set
			{
				this._waveID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool waveIDSpecified
		{
			get
			{
				return this._waveID != null;
			}
			set
			{
				bool flag = value == (this._waveID == null);
				if (flag)
				{
					this._waveID = (value ? new uint?(this.waveID) : null);
				}
			}
		}

		private bool ShouldSerializewaveID()
		{
			return this.waveIDSpecified;
		}

		private void ResetwaveID()
		{
			this.waveIDSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "isServerControl", DataFormat = DataFormat.Default)]
		public bool isServerControl
		{
			get
			{
				return this._isServerControl ?? false;
			}
			set
			{
				this._isServerControl = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isServerControlSpecified
		{
			get
			{
				return this._isServerControl != null;
			}
			set
			{
				bool flag = value == (this._isServerControl == null);
				if (flag)
				{
					this._isServerControl = (value ? new bool?(this.isServerControl) : null);
				}
			}
		}

		private bool ShouldSerializeisServerControl()
		{
			return this.isServerControlSpecified;
		}

		private void ResetisServerControl()
		{
			this.isServerControlSpecified = false;
		}

		[ProtoMember(10, Name = "skills", DataFormat = DataFormat.Default)]
		public List<SkillInfo> skills
		{
			get
			{
				return this._skills;
			}
		}

		[ProtoMember(11, Name = "equip", DataFormat = DataFormat.Default)]
		public List<Item> equip
		{
			get
			{
				return this._equip;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(13, IsRequired = false, Name = "PowerPoint", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(14, Name = "emblem", DataFormat = DataFormat.Default)]
		public List<Item> emblem
		{
			get
			{
				return this._emblem;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "fightgroup", DataFormat = DataFormat.TwosComplement)]
		public uint fightgroup
		{
			get
			{
				return this._fightgroup ?? 0U;
			}
			set
			{
				this._fightgroup = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fightgroupSpecified
		{
			get
			{
				return this._fightgroup != null;
			}
			set
			{
				bool flag = value == (this._fightgroup == null);
				if (flag)
				{
					this._fightgroup = (value ? new uint?(this.fightgroup) : null);
				}
			}
		}

		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

		[ProtoMember(16, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<BuffInfo> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "IsDead", DataFormat = DataFormat.Default)]
		public bool IsDead
		{
			get
			{
				return this._IsDead ?? false;
			}
			set
			{
				this._IsDead = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsDeadSpecified
		{
			get
			{
				return this._IsDead != null;
			}
			set
			{
				bool flag = value == (this._IsDead == null);
				if (flag)
				{
					this._IsDead = (value ? new bool?(this.IsDead) : null);
				}
			}
		}

		private bool ShouldSerializeIsDead()
		{
			return this.IsDeadSpecified;
		}

		private void ResetIsDead()
		{
			this.IsDeadSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public uint lastlogin
		{
			get
			{
				return this._lastlogin ?? 0U;
			}
			set
			{
				this._lastlogin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastloginSpecified
		{
			get
			{
				return this._lastlogin != null;
			}
			set
			{
				bool flag = value == (this._lastlogin == null);
				if (flag)
				{
					this._lastlogin = (value ? new uint?(this.lastlogin) : null);
				}
			}
		}

		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		[ProtoMember(21, IsRequired = false, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public uint nickid
		{
			get
			{
				return this._nickid ?? 0U;
			}
			set
			{
				this._nickid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nickidSpecified
		{
			get
			{
				return this._nickid != null;
			}
			set
			{
				bool flag = value == (this._nickid == null);
				if (flag)
				{
					this._nickid = (value ? new uint?(this.nickid) : null);
				}
			}
		}

		private bool ShouldSerializenickid()
		{
			return this.nickidSpecified;
		}

		private void Resetnickid()
		{
			this.nickidSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "isnewmob", DataFormat = DataFormat.Default)]
		public bool isnewmob
		{
			get
			{
				return this._isnewmob ?? false;
			}
			set
			{
				this._isnewmob = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isnewmobSpecified
		{
			get
			{
				return this._isnewmob != null;
			}
			set
			{
				bool flag = value == (this._isnewmob == null);
				if (flag)
				{
					this._isnewmob = (value ? new bool?(this.isnewmob) : null);
				}
			}
		}

		private bool ShouldSerializeisnewmob()
		{
			return this.isnewmobSpecified;
		}

		private void Resetisnewmob()
		{
			this.isnewmobSpecified = false;
		}

		[ProtoMember(23, Name = "bindskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bindskills
		{
			get
			{
				return this._bindskills;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "allbuffsinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AllBuffsInfo allbuffsinfo
		{
			get
			{
				return this._allbuffsinfo;
			}
			set
			{
				this._allbuffsinfo = value;
			}
		}

		[ProtoMember(25, Name = "sprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> sprites
		{
			get
			{
				return this._sprites;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "pet", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PetSingle pet
		{
			get
			{
				return this._pet;
			}
			set
			{
				this._pet = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "hostid", DataFormat = DataFormat.TwosComplement)]
		public ulong hostid
		{
			get
			{
				return this._hostid ?? 0UL;
			}
			set
			{
				this._hostid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hostidSpecified
		{
			get
			{
				return this._hostid != null;
			}
			set
			{
				bool flag = value == (this._hostid == null);
				if (flag)
				{
					this._hostid = (value ? new ulong?(this.hostid) : null);
				}
			}
		}

		private bool ShouldSerializehostid()
		{
			return this.hostidSpecified;
		}

		private void Resethostid()
		{
			this.hostidSpecified = false;
		}

		[ProtoMember(28, IsRequired = false, Name = "category", DataFormat = DataFormat.TwosComplement)]
		public EntityCategory category
		{
			get
			{
				return this._category ?? EntityCategory.Category_Role;
			}
			set
			{
				this._category = new EntityCategory?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool categorySpecified
		{
			get
			{
				return this._category != null;
			}
			set
			{
				bool flag = value == (this._category == null);
				if (flag)
				{
					this._category = (value ? new EntityCategory?(this.category) : null);
				}
			}
		}

		private bool ShouldSerializecategory()
		{
			return this.categorySpecified;
		}

		private void Resetcategory()
		{
			this.categorySpecified = false;
		}

		[ProtoMember(29, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		[ProtoMember(30, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearanceTeam team
		{
			get
			{
				return this._team;
			}
			set
			{
				this._team = value;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "specialstate", DataFormat = DataFormat.TwosComplement)]
		public uint specialstate
		{
			get
			{
				return this._specialstate ?? 0U;
			}
			set
			{
				this._specialstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool specialstateSpecified
		{
			get
			{
				return this._specialstate != null;
			}
			set
			{
				bool flag = value == (this._specialstate == null);
				if (flag)
				{
					this._specialstate = (value ? new uint?(this.specialstate) : null);
				}
			}
		}

		private bool ShouldSerializespecialstate()
		{
			return this.specialstateSpecified;
		}

		private void Resetspecialstate()
		{
			this.specialstateSpecified = false;
		}

		[ProtoMember(32, Name = "artifact", DataFormat = DataFormat.Default)]
		public List<Item> artifact
		{
			get
			{
				return this._artifact;
			}
		}

		[ProtoMember(33, IsRequired = false, Name = "mobshieldable", DataFormat = DataFormat.Default)]
		public bool mobshieldable
		{
			get
			{
				return this._mobshieldable ?? false;
			}
			set
			{
				this._mobshieldable = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mobshieldableSpecified
		{
			get
			{
				return this._mobshieldable != null;
			}
			set
			{
				bool flag = value == (this._mobshieldable == null);
				if (flag)
				{
					this._mobshieldable = (value ? new bool?(this.mobshieldable) : null);
				}
			}
		}

		private bool ShouldSerializemobshieldable()
		{
			return this.mobshieldableSpecified;
		}

		private void Resetmobshieldable()
		{
			this.mobshieldableSpecified = false;
		}

		[ProtoMember(34, IsRequired = false, Name = "forcedisappear", DataFormat = DataFormat.Default)]
		public bool forcedisappear
		{
			get
			{
				return this._forcedisappear ?? false;
			}
			set
			{
				this._forcedisappear = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool forcedisappearSpecified
		{
			get
			{
				return this._forcedisappear != null;
			}
			set
			{
				bool flag = value == (this._forcedisappear == null);
				if (flag)
				{
					this._forcedisappear = (value ? new bool?(this.forcedisappear) : null);
				}
			}
		}

		private bool ShouldSerializeforcedisappear()
		{
			return this.forcedisappearSpecified;
		}

		private void Resetforcedisappear()
		{
			this.forcedisappearSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uID;

		private string _unitName;

		private uint? _unitType;

		private Vec3 _position = null;

		private float? _direction;

		private Attribute _attributes = null;

		private readonly List<uint> _fashion = new List<uint>();

		private uint? _waveID;

		private bool? _isServerControl;

		private readonly List<SkillInfo> _skills = new List<SkillInfo>();

		private readonly List<Item> _equip = new List<Item>();

		private uint? _level;

		private uint? _PowerPoint;

		private readonly List<Item> _emblem = new List<Item>();

		private uint? _fightgroup;

		private readonly List<BuffInfo> _buffs = new List<BuffInfo>();

		private bool? _IsDead;

		private OutLook _outlook = null;

		private uint? _viplevel;

		private uint? _lastlogin;

		private uint? _nickid;

		private bool? _isnewmob;

		private readonly List<uint> _bindskills = new List<uint>();

		private AllBuffsInfo _allbuffsinfo = null;

		private readonly List<SpriteInfo> _sprites = new List<SpriteInfo>();

		private PetSingle _pet = null;

		private ulong? _hostid;

		private EntityCategory? _category;

		private uint? _paymemberid;

		private UnitAppearanceTeam _team = null;

		private uint? _specialstate;

		private readonly List<Item> _artifact = new List<Item>();

		private bool? _mobshieldable;

		private bool? _forcedisappear;

		private IExtension extensionObject;
	}
}
