using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleBrief")]
	[Serializable]
	public class RoleBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public RoleType type
		{
			get
			{
				return this._type ?? RoleType.Role_INVALID;
			}
			set
			{
				this._type = new RoleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new RoleType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "accountID", DataFormat = DataFormat.Default)]
		public string accountID
		{
			get
			{
				return this._accountID ?? "";
			}
			set
			{
				this._accountID = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountIDSpecified
		{
			get
			{
				return this._accountID != null;
			}
			set
			{
				bool flag = value == (this._accountID == null);
				if (flag)
				{
					this._accountID = (value ? this.accountID : null);
				}
			}
		}

		private bool ShouldSerializeaccountID()
		{
			return this.accountIDSpecified;
		}

		private void ResetaccountID()
		{
			this.accountIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public ulong exp
		{
			get
			{
				return this._exp ?? 0UL;
			}
			set
			{
				this._exp = new ulong?(value);
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
					this._exp = (value ? new ulong?(this.exp) : null);
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

		[ProtoMember(7, IsRequired = false, Name = "maxexp", DataFormat = DataFormat.TwosComplement)]
		public ulong maxexp
		{
			get
			{
				return this._maxexp ?? 0UL;
			}
			set
			{
				this._maxexp = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxexpSpecified
		{
			get
			{
				return this._maxexp != null;
			}
			set
			{
				bool flag = value == (this._maxexp == null);
				if (flag)
				{
					this._maxexp = (value ? new ulong?(this.maxexp) : null);
				}
			}
		}

		private bool ShouldSerializemaxexp()
		{
			return this.maxexpSpecified;
		}

		private void Resetmaxexp()
		{
			this.maxexpSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "position", DataFormat = DataFormat.Default)]
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

		[ProtoMember(9, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "face", DataFormat = DataFormat.FixedSize)]
		public float face
		{
			get
			{
				return this._face ?? 0f;
			}
			set
			{
				this._face = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool faceSpecified
		{
			get
			{
				return this._face != null;
			}
			set
			{
				bool flag = value == (this._face == null);
				if (flag)
				{
					this._face = (value ? new float?(this.face) : null);
				}
			}
		}

		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		private void Resetface()
		{
			this.faceSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "offlineTime", DataFormat = DataFormat.TwosComplement)]
		public uint offlineTime
		{
			get
			{
				return this._offlineTime ?? 0U;
			}
			set
			{
				this._offlineTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool offlineTimeSpecified
		{
			get
			{
				return this._offlineTime != null;
			}
			set
			{
				bool flag = value == (this._offlineTime == null);
				if (flag)
				{
					this._offlineTime = (value ? new uint?(this.offlineTime) : null);
				}
			}
		}

		private bool ShouldSerializeofflineTime()
		{
			return this.offlineTimeSpecified;
		}

		private void ResetofflineTime()
		{
			this.offlineTimeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "completeguidestage", DataFormat = DataFormat.Default)]
		public bool completeguidestage
		{
			get
			{
				return this._completeguidestage ?? false;
			}
			set
			{
				this._completeguidestage = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool completeguidestageSpecified
		{
			get
			{
				return this._completeguidestage != null;
			}
			set
			{
				bool flag = value == (this._completeguidestage == null);
				if (flag)
				{
					this._completeguidestage = (value ? new bool?(this.completeguidestage) : null);
				}
			}
		}

		private bool ShouldSerializecompleteguidestage()
		{
			return this.completeguidestageSpecified;
		}

		private void Resetcompleteguidestage()
		{
			this.completeguidestageSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "tutorialBits", DataFormat = DataFormat.TwosComplement)]
		public ulong tutorialBits
		{
			get
			{
				return this._tutorialBits ?? 0UL;
			}
			set
			{
				this._tutorialBits = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialBitsSpecified
		{
			get
			{
				return this._tutorialBits != null;
			}
			set
			{
				bool flag = value == (this._tutorialBits == null);
				if (flag)
				{
					this._tutorialBits = (value ? new ulong?(this.tutorialBits) : null);
				}
			}
		}

		private bool ShouldSerializetutorialBits()
		{
			return this.tutorialBitsSpecified;
		}

		private void ResettutorialBits()
		{
			this.tutorialBitsSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "onlimetime", DataFormat = DataFormat.TwosComplement)]
		public uint onlimetime
		{
			get
			{
				return this._onlimetime ?? 0U;
			}
			set
			{
				this._onlimetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlimetimeSpecified
		{
			get
			{
				return this._onlimetime != null;
			}
			set
			{
				bool flag = value == (this._onlimetime == null);
				if (flag)
				{
					this._onlimetime = (value ? new uint?(this.onlimetime) : null);
				}
			}
		}

		private bool ShouldSerializeonlimetime()
		{
			return this.onlimetimeSpecified;
		}

		private void Resetonlimetime()
		{
			this.onlimetimeSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "auctionPoint", DataFormat = DataFormat.TwosComplement)]
		public uint auctionPoint
		{
			get
			{
				return this._auctionPoint ?? 0U;
			}
			set
			{
				this._auctionPoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool auctionPointSpecified
		{
			get
			{
				return this._auctionPoint != null;
			}
			set
			{
				bool flag = value == (this._auctionPoint == null);
				if (flag)
				{
					this._auctionPoint = (value ? new uint?(this.auctionPoint) : null);
				}
			}
		}

		private bool ShouldSerializeauctionPoint()
		{
			return this.auctionPointSpecified;
		}

		private void ResetauctionPoint()
		{
			this.auctionPointSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "campID", DataFormat = DataFormat.TwosComplement)]
		public uint campID
		{
			get
			{
				return this._campID ?? 0U;
			}
			set
			{
				this._campID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool campIDSpecified
		{
			get
			{
				return this._campID != null;
			}
			set
			{
				bool flag = value == (this._campID == null);
				if (flag)
				{
					this._campID = (value ? new uint?(this.campID) : null);
				}
			}
		}

		private bool ShouldSerializecampID()
		{
			return this.campIDSpecified;
		}

		private void ResetcampID()
		{
			this.campIDSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "accountNumberLastDay", DataFormat = DataFormat.TwosComplement)]
		public uint accountNumberLastDay
		{
			get
			{
				return this._accountNumberLastDay ?? 0U;
			}
			set
			{
				this._accountNumberLastDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountNumberLastDaySpecified
		{
			get
			{
				return this._accountNumberLastDay != null;
			}
			set
			{
				bool flag = value == (this._accountNumberLastDay == null);
				if (flag)
				{
					this._accountNumberLastDay = (value ? new uint?(this.accountNumberLastDay) : null);
				}
			}
		}

		private bool ShouldSerializeaccountNumberLastDay()
		{
			return this.accountNumberLastDaySpecified;
		}

		private void ResetaccountNumberLastDay()
		{
			this.accountNumberLastDaySpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "lastAccountTime", DataFormat = DataFormat.TwosComplement)]
		public ulong lastAccountTime
		{
			get
			{
				return this._lastAccountTime ?? 0UL;
			}
			set
			{
				this._lastAccountTime = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastAccountTimeSpecified
		{
			get
			{
				return this._lastAccountTime != null;
			}
			set
			{
				bool flag = value == (this._lastAccountTime == null);
				if (flag)
				{
					this._lastAccountTime = (value ? new ulong?(this.lastAccountTime) : null);
				}
			}
		}

		private bool ShouldSerializelastAccountTime()
		{
			return this.lastAccountTimeSpecified;
		}

		private void ResetlastAccountTime()
		{
			this.lastAccountTimeSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "nickID", DataFormat = DataFormat.TwosComplement)]
		public uint nickID
		{
			get
			{
				return this._nickID ?? 0U;
			}
			set
			{
				this._nickID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nickIDSpecified
		{
			get
			{
				return this._nickID != null;
			}
			set
			{
				bool flag = value == (this._nickID == null);
				if (flag)
				{
					this._nickID = (value ? new uint?(this.nickID) : null);
				}
			}
		}

		private bool ShouldSerializenickID()
		{
			return this.nickIDSpecified;
		}

		private void ResetnickID()
		{
			this.nickIDSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "tutorialBitsArray", DataFormat = DataFormat.Default)]
		public byte[] tutorialBitsArray
		{
			get
			{
				return this._tutorialBitsArray ?? null;
			}
			set
			{
				this._tutorialBitsArray = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialBitsArraySpecified
		{
			get
			{
				return this._tutorialBitsArray != null;
			}
			set
			{
				bool flag = value == (this._tutorialBitsArray == null);
				if (flag)
				{
					this._tutorialBitsArray = (value ? this.tutorialBitsArray : null);
				}
			}
		}

		private bool ShouldSerializetutorialBitsArray()
		{
			return this.tutorialBitsArraySpecified;
		}

		private void ResettutorialBitsArray()
		{
			this.tutorialBitsArraySpecified = false;
		}

		[ProtoMember(21, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(23, IsRequired = false, Name = "changenamecount", DataFormat = DataFormat.TwosComplement)]
		public uint changenamecount
		{
			get
			{
				return this._changenamecount ?? 0U;
			}
			set
			{
				this._changenamecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool changenamecountSpecified
		{
			get
			{
				return this._changenamecount != null;
			}
			set
			{
				bool flag = value == (this._changenamecount == null);
				if (flag)
				{
					this._changenamecount = (value ? new uint?(this.changenamecount) : null);
				}
			}
		}

		private bool ShouldSerializechangenamecount()
		{
			return this.changenamecountSpecified;
		}

		private void Resetchangenamecount()
		{
			this.changenamecountSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "op", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookOp op
		{
			get
			{
				return this._op;
			}
			set
			{
				this._op = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "inittime", DataFormat = DataFormat.TwosComplement)]
		public ulong inittime
		{
			get
			{
				return this._inittime ?? 0UL;
			}
			set
			{
				this._inittime = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inittimeSpecified
		{
			get
			{
				return this._inittime != null;
			}
			set
			{
				bool flag = value == (this._inittime == null);
				if (flag)
				{
					this._inittime = (value ? new ulong?(this.inittime) : null);
				}
			}
		}

		private bool ShouldSerializeinittime()
		{
			return this.inittimeSpecified;
		}

		private void Resetinittime()
		{
			this.inittimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleType? _type;

		private string _name;

		private ulong? _roleID;

		private string _accountID;

		private uint? _level;

		private ulong? _exp;

		private ulong? _maxexp;

		private Vec3 _position = null;

		private int? _sceneID;

		private float? _face;

		private uint? _offlineTime;

		private bool? _completeguidestage;

		private ulong? _tutorialBits;

		private uint? _onlimetime;

		private uint? _auctionPoint;

		private uint? _campID;

		private uint? _accountNumberLastDay;

		private ulong? _lastAccountTime;

		private uint? _nickID;

		private byte[] _tutorialBitsArray;

		private uint? _titleID;

		private uint? _paymemberid;

		private uint? _changenamecount;

		private OutLookOp _op = null;

		private ulong? _inittime;

		private IExtension extensionObject;
	}
}
