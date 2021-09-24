using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInvRoleInfo")]
	[Serializable]
	public class TeamInvRoleInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "userID", DataFormat = DataFormat.TwosComplement)]
		public ulong userID
		{
			get
			{
				return this._userID ?? 0UL;
			}
			set
			{
				this._userID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userIDSpecified
		{
			get
			{
				return this._userID != null;
			}
			set
			{
				bool flag = value == (this._userID == null);
				if (flag)
				{
					this._userID = (value ? new ulong?(this.userID) : null);
				}
			}
		}

		private bool ShouldSerializeuserID()
		{
			return this.userIDSpecified;
		}

		private void ResetuserID()
		{
			this.userIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "userName", DataFormat = DataFormat.Default)]
		public string userName
		{
			get
			{
				return this._userName ?? "";
			}
			set
			{
				this._userName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userNameSpecified
		{
			get
			{
				return this._userName != null;
			}
			set
			{
				bool flag = value == (this._userName == null);
				if (flag)
				{
					this._userName = (value ? this.userName : null);
				}
			}
		}

		private bool ShouldSerializeuserName()
		{
			return this.userNameSpecified;
		}

		private void ResetuserName()
		{
			this.userNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "userLevel", DataFormat = DataFormat.TwosComplement)]
		public uint userLevel
		{
			get
			{
				return this._userLevel ?? 0U;
			}
			set
			{
				this._userLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userLevelSpecified
		{
			get
			{
				return this._userLevel != null;
			}
			set
			{
				bool flag = value == (this._userLevel == null);
				if (flag)
				{
					this._userLevel = (value ? new uint?(this.userLevel) : null);
				}
			}
		}

		private bool ShouldSerializeuserLevel()
		{
			return this.userLevelSpecified;
		}

		private void ResetuserLevel()
		{
			this.userLevelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "userVip", DataFormat = DataFormat.TwosComplement)]
		public uint userVip
		{
			get
			{
				return this._userVip ?? 0U;
			}
			set
			{
				this._userVip = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userVipSpecified
		{
			get
			{
				return this._userVip != null;
			}
			set
			{
				bool flag = value == (this._userVip == null);
				if (flag)
				{
					this._userVip = (value ? new uint?(this.userVip) : null);
				}
			}
		}

		private bool ShouldSerializeuserVip()
		{
			return this.userVipSpecified;
		}

		private void ResetuserVip()
		{
			this.userVipSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "userPowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint userPowerPoint
		{
			get
			{
				return this._userPowerPoint ?? 0U;
			}
			set
			{
				this._userPowerPoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userPowerPointSpecified
		{
			get
			{
				return this._userPowerPoint != null;
			}
			set
			{
				bool flag = value == (this._userPowerPoint == null);
				if (flag)
				{
					this._userPowerPoint = (value ? new uint?(this.userPowerPoint) : null);
				}
			}
		}

		private bool ShouldSerializeuserPowerPoint()
		{
			return this.userPowerPointSpecified;
		}

		private void ResetuserPowerPoint()
		{
			this.userPowerPointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "guildName", DataFormat = DataFormat.Default)]
		public string guildName
		{
			get
			{
				return this._guildName ?? "";
			}
			set
			{
				this._guildName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildNameSpecified
		{
			get
			{
				return this._guildName != null;
			}
			set
			{
				bool flag = value == (this._guildName == null);
				if (flag)
				{
					this._guildName = (value ? this.guildName : null);
				}
			}
		}

		private bool ShouldSerializeguildName()
		{
			return this.guildNameSpecified;
		}

		private void ResetguildName()
		{
			this.guildNameSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
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
					this._profession = (value ? new int?(this.profession) : null);
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

		[ProtoMember(9, IsRequired = false, Name = "teamguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong teamguildid
		{
			get
			{
				return this._teamguildid ?? 0UL;
			}
			set
			{
				this._teamguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamguildidSpecified
		{
			get
			{
				return this._teamguildid != null;
			}
			set
			{
				bool flag = value == (this._teamguildid == null);
				if (flag)
				{
					this._teamguildid = (value ? new ulong?(this.teamguildid) : null);
				}
			}
		}

		private bool ShouldSerializeteamguildid()
		{
			return this.teamguildidSpecified;
		}

		private void Resetteamguildid()
		{
			this.teamguildidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "roleguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleguildid
		{
			get
			{
				return this._roleguildid ?? 0UL;
			}
			set
			{
				this._roleguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleguildidSpecified
		{
			get
			{
				return this._roleguildid != null;
			}
			set
			{
				bool flag = value == (this._roleguildid == null);
				if (flag)
				{
					this._roleguildid = (value ? new ulong?(this.roleguildid) : null);
				}
			}
		}

		private bool ShouldSerializeroleguildid()
		{
			return this.roleguildidSpecified;
		}

		private void Resetroleguildid()
		{
			this.roleguildidSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "roledragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong roledragonguildid
		{
			get
			{
				return this._roledragonguildid ?? 0UL;
			}
			set
			{
				this._roledragonguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roledragonguildidSpecified
		{
			get
			{
				return this._roledragonguildid != null;
			}
			set
			{
				bool flag = value == (this._roledragonguildid == null);
				if (flag)
				{
					this._roledragonguildid = (value ? new ulong?(this.roledragonguildid) : null);
				}
			}
		}

		private bool ShouldSerializeroledragonguildid()
		{
			return this.roledragonguildidSpecified;
		}

		private void Resetroledragonguildid()
		{
			this.roledragonguildidSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public TeamInvRoleState state
		{
			get
			{
				return this._state ?? TeamInvRoleState.TIRS_IN_OTHER_TEAM;
			}
			set
			{
				this._state = new TeamInvRoleState?(value);
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
					this._state = (value ? new TeamInvRoleState?(this.state) : null);
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

		[ProtoMember(13, IsRequired = false, Name = "wanthelp", DataFormat = DataFormat.Default)]
		public bool wanthelp
		{
			get
			{
				return this._wanthelp ?? false;
			}
			set
			{
				this._wanthelp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wanthelpSpecified
		{
			get
			{
				return this._wanthelp != null;
			}
			set
			{
				bool flag = value == (this._wanthelp == null);
				if (flag)
				{
					this._wanthelp = (value ? new bool?(this.wanthelp) : null);
				}
			}
		}

		private bool ShouldSerializewanthelp()
		{
			return this.wanthelpSpecified;
		}

		private void Resetwanthelp()
		{
			this.wanthelpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _userID;

		private string _userName;

		private uint? _userLevel;

		private uint? _userVip;

		private uint? _userPowerPoint;

		private string _guildName;

		private uint? _degree;

		private int? _profession;

		private ulong? _teamguildid;

		private ulong? _roleguildid;

		private ulong? _roledragonguildid;

		private TeamInvRoleState? _state;

		private bool? _wanthelp;

		private IExtension extensionObject;
	}
}
