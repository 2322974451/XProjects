using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamMember")]
	[Serializable]
	public class TeamMember : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public ulong memberID
		{
			get
			{
				return this._memberID ?? 0UL;
			}
			set
			{
				this._memberID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new ulong?(this.memberID) : null);
				}
			}
		}

		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public RoleType profession
		{
			get
			{
				return this._profession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._profession = new RoleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new RoleType?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
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
					this._level = (value ? new int?(this.level) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public int state
		{
			get
			{
				return this._state ?? 0;
			}
			set
			{
				this._state = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new int?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(7, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

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
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "robot", DataFormat = DataFormat.Default)]
		public bool robot
		{
			get
			{
				return this._robot ?? false;
			}
			set
			{
				this._robot = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool robotSpecified
		{
			get
			{
				return this._robot != null;
			}
			set
			{
				bool flag = value == (this._robot == null);
				if (flag)
				{
					this._robot = (value ? new bool?(this.robot) : null);
				}
			}
		}

		private bool ShouldSerializerobot()
		{
			return this.robotSpecified;
		}

		private void Resetrobot()
		{
			this.robotSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "dragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildid
		{
			get
			{
				return this._dragonguildid ?? 0UL;
			}
			set
			{
				this._dragonguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildidSpecified
		{
			get
			{
				return this._dragonguildid != null;
			}
			set
			{
				bool flag = value == (this._dragonguildid == null);
				if (flag)
				{
					this._dragonguildid = (value ? new ulong?(this.dragonguildid) : null);
				}
			}
		}

		private bool ShouldSerializedragonguildid()
		{
			return this.dragonguildidSpecified;
		}

		private void Resetdragonguildid()
		{
			this.dragonguildidSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
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

		[ProtoMember(14, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public uint vipLevel
		{
			get
			{
				return this._vipLevel ?? 0U;
			}
			set
			{
				this._vipLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new uint?(this.vipLevel) : null);
				}
			}
		}

		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(16, IsRequired = false, Name = "membertype", DataFormat = DataFormat.TwosComplement)]
		public TeamMemberType membertype
		{
			get
			{
				return this._membertype ?? TeamMemberType.TMT_NORMAL;
			}
			set
			{
				this._membertype = new TeamMemberType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool membertypeSpecified
		{
			get
			{
				return this._membertype != null;
			}
			set
			{
				bool flag = value == (this._membertype == null);
				if (flag)
				{
					this._membertype = (value ? new TeamMemberType?(this.membertype) : null);
				}
			}
		}

		private bool ShouldSerializemembertype()
		{
			return this.membertypeSpecified;
		}

		private void Resetmembertype()
		{
			this.membertypeSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "tarjatime", DataFormat = DataFormat.TwosComplement)]
		public uint tarjatime
		{
			get
			{
				return this._tarjatime ?? 0U;
			}
			set
			{
				this._tarjatime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tarjatimeSpecified
		{
			get
			{
				return this._tarjatime != null;
			}
			set
			{
				bool flag = value == (this._tarjatime == null);
				if (flag)
				{
					this._tarjatime = (value ? new uint?(this.tarjatime) : null);
				}
			}
		}

		private bool ShouldSerializetarjatime()
		{
			return this.tarjatimeSpecified;
		}

		private void Resettarjatime()
		{
			this.tarjatimeSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "kingback", DataFormat = DataFormat.Default)]
		public bool kingback
		{
			get
			{
				return this._kingback ?? false;
			}
			set
			{
				this._kingback = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kingbackSpecified
		{
			get
			{
				return this._kingback != null;
			}
			set
			{
				bool flag = value == (this._kingback == null);
				if (flag)
				{
					this._kingback = (value ? new bool?(this.kingback) : null);
				}
			}
		}

		private bool ShouldSerializekingback()
		{
			return this.kingbackSpecified;
		}

		private void Resetkingback()
		{
			this.kingbackSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _memberID;

		private RoleType? _profession;

		private string _name;

		private int? _level;

		private uint? _powerpoint;

		private int? _state;

		private readonly List<uint> _fashion = new List<uint>();

		private uint? _sceneID;

		private int? _leftcount;

		private bool? _robot;

		private ulong? _guildid;

		private ulong? _dragonguildid;

		private OutLook _outlook = null;

		private uint? _vipLevel;

		private uint? _paymemberid;

		private TeamMemberType? _membertype;

		private uint? _tarjatime;

		private uint? _serverid;

		private bool? _kingback;

		private IExtension extensionObject;
	}
}
