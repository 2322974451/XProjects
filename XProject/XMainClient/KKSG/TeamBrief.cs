using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamBrief")]
	[Serializable]
	public class TeamBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamID", DataFormat = DataFormat.TwosComplement)]
		public int teamID
		{
			get
			{
				return this._teamID ?? 0;
			}
			set
			{
				this._teamID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamIDSpecified
		{
			get
			{
				return this._teamID != null;
			}
			set
			{
				bool flag = value == (this._teamID == null);
				if (flag)
				{
					this._teamID = (value ? new int?(this.teamID) : null);
				}
			}
		}

		private bool ShouldSerializeteamID()
		{
			return this.teamIDSpecified;
		}

		private void ResetteamID()
		{
			this.teamIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "teamMemberCount", DataFormat = DataFormat.TwosComplement)]
		public int teamMemberCount
		{
			get
			{
				return this._teamMemberCount ?? 0;
			}
			set
			{
				this._teamMemberCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamMemberCountSpecified
		{
			get
			{
				return this._teamMemberCount != null;
			}
			set
			{
				bool flag = value == (this._teamMemberCount == null);
				if (flag)
				{
					this._teamMemberCount = (value ? new int?(this.teamMemberCount) : null);
				}
			}
		}

		private bool ShouldSerializeteamMemberCount()
		{
			return this.teamMemberCountSpecified;
		}

		private void ResetteamMemberCount()
		{
			this.teamMemberCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "teamState", DataFormat = DataFormat.TwosComplement)]
		public int teamState
		{
			get
			{
				return this._teamState ?? 0;
			}
			set
			{
				this._teamState = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamStateSpecified
		{
			get
			{
				return this._teamState != null;
			}
			set
			{
				bool flag = value == (this._teamState == null);
				if (flag)
				{
					this._teamState = (value ? new int?(this.teamState) : null);
				}
			}
		}

		private bool ShouldSerializeteamState()
		{
			return this.teamStateSpecified;
		}

		private void ResetteamState()
		{
			this.teamStateSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
		public string leaderName
		{
			get
			{
				return this._leaderName ?? "";
			}
			set
			{
				this._leaderName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderNameSpecified
		{
			get
			{
				return this._leaderName != null;
			}
			set
			{
				bool flag = value == (this._leaderName == null);
				if (flag)
				{
					this._leaderName = (value ? this.leaderName : null);
				}
			}
		}

		private bool ShouldSerializeleaderName()
		{
			return this.leaderNameSpecified;
		}

		private void ResetleaderName()
		{
			this.leaderNameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
		public uint expID
		{
			get
			{
				return this._expID ?? 0U;
			}
			set
			{
				this._expID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expIDSpecified
		{
			get
			{
				return this._expID != null;
			}
			set
			{
				bool flag = value == (this._expID == null);
				if (flag)
				{
					this._expID = (value ? new uint?(this.expID) : null);
				}
			}
		}

		private bool ShouldSerializeexpID()
		{
			return this.expIDSpecified;
		}

		private void ResetexpID()
		{
			this.expIDSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "haspassword", DataFormat = DataFormat.Default)]
		public bool haspassword
		{
			get
			{
				return this._haspassword ?? false;
			}
			set
			{
				this._haspassword = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool haspasswordSpecified
		{
			get
			{
				return this._haspassword != null;
			}
			set
			{
				bool flag = value == (this._haspassword == null);
				if (flag)
				{
					this._haspassword = (value ? new bool?(this.haspassword) : null);
				}
			}
		}

		private bool ShouldSerializehaspassword()
		{
			return this.haspasswordSpecified;
		}

		private void Resethaspassword()
		{
			this.haspasswordSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "leaderLevel", DataFormat = DataFormat.TwosComplement)]
		public uint leaderLevel
		{
			get
			{
				return this._leaderLevel ?? 0U;
			}
			set
			{
				this._leaderLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderLevelSpecified
		{
			get
			{
				return this._leaderLevel != null;
			}
			set
			{
				bool flag = value == (this._leaderLevel == null);
				if (flag)
				{
					this._leaderLevel = (value ? new uint?(this.leaderLevel) : null);
				}
			}
		}

		private bool ShouldSerializeleaderLevel()
		{
			return this.leaderLevelSpecified;
		}

		private void ResetleaderLevel()
		{
			this.leaderLevelSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "leaderPowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint leaderPowerPoint
		{
			get
			{
				return this._leaderPowerPoint ?? 0U;
			}
			set
			{
				this._leaderPowerPoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderPowerPointSpecified
		{
			get
			{
				return this._leaderPowerPoint != null;
			}
			set
			{
				bool flag = value == (this._leaderPowerPoint == null);
				if (flag)
				{
					this._leaderPowerPoint = (value ? new uint?(this.leaderPowerPoint) : null);
				}
			}
		}

		private bool ShouldSerializeleaderPowerPoint()
		{
			return this.leaderPowerPointSpecified;
		}

		private void ResetleaderPowerPoint()
		{
			this.leaderPowerPointSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "leaderProfession", DataFormat = DataFormat.TwosComplement)]
		public RoleType leaderProfession
		{
			get
			{
				return this._leaderProfession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._leaderProfession = new RoleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderProfessionSpecified
		{
			get
			{
				return this._leaderProfession != null;
			}
			set
			{
				bool flag = value == (this._leaderProfession == null);
				if (flag)
				{
					this._leaderProfession = (value ? new RoleType?(this.leaderProfession) : null);
				}
			}
		}

		private bool ShouldSerializeleaderProfession()
		{
			return this.leaderProfessionSpecified;
		}

		private void ResetleaderProfession()
		{
			this.leaderProfessionSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "extrainfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamExtraInfo extrainfo
		{
			get
			{
				return this._extrainfo;
			}
			set
			{
				this._extrainfo = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "matchtype", DataFormat = DataFormat.TwosComplement)]
		public KMatchType matchtype
		{
			get
			{
				return this._matchtype ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._matchtype = new KMatchType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool matchtypeSpecified
		{
			get
			{
				return this._matchtype != null;
			}
			set
			{
				bool flag = value == (this._matchtype == null);
				if (flag)
				{
					this._matchtype = (value ? new KMatchType?(this.matchtype) : null);
				}
			}
		}

		private bool ShouldSerializematchtype()
		{
			return this.matchtypeSpecified;
		}

		private void Resetmatchtype()
		{
			this.matchtypeSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "kingback", DataFormat = DataFormat.Default)]
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

		private int? _teamID;

		private int? _teamMemberCount;

		private int? _teamState;

		private string _leaderName;

		private uint? _expID;

		private bool? _haspassword;

		private uint? _leaderLevel;

		private uint? _leaderPowerPoint;

		private RoleType? _leaderProfession;

		private TeamExtraInfo _extrainfo = null;

		private string _password;

		private KMatchType? _matchtype;

		private bool? _kingback;

		private IExtension extensionObject;
	}
}
