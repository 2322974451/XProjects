using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamOPArg")]
	[Serializable]
	public class TeamOPArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "request", DataFormat = DataFormat.TwosComplement)]
		public TeamOperate request
		{
			get
			{
				return this._request ?? TeamOperate.TEAM_CREATE;
			}
			set
			{
				this._request = new TeamOperate?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool requestSpecified
		{
			get
			{
				return this._request != null;
			}
			set
			{
				bool flag = value == (this._request == null);
				if (flag)
				{
					this._request = (value ? new TeamOperate?(this.request) : null);
				}
			}
		}

		private bool ShouldSerializerequest()
		{
			return this.requestSpecified;
		}

		private void Resetrequest()
		{
			this.requestSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "teamID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "extrainfo", DataFormat = DataFormat.Default)]
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

		[ProtoMember(7, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public ulong param
		{
			get
			{
				return this._param ?? 0UL;
			}
			set
			{
				this._param = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new ulong?(this.param) : null);
				}
			}
		}

		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "membertype", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "isplatfriend", DataFormat = DataFormat.Default)]
		public bool isplatfriend
		{
			get
			{
				return this._isplatfriend ?? false;
			}
			set
			{
				this._isplatfriend = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isplatfriendSpecified
		{
			get
			{
				return this._isplatfriend != null;
			}
			set
			{
				bool flag = value == (this._isplatfriend == null);
				if (flag)
				{
					this._isplatfriend = (value ? new bool?(this.isplatfriend) : null);
				}
			}
		}

		private bool ShouldSerializeisplatfriend()
		{
			return this.isplatfriendSpecified;
		}

		private void Resetisplatfriend()
		{
			this.isplatfriendSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private TeamOperate? _request;

		private int? _teamID;

		private string _password;

		private uint? _expID;

		private ulong? _roleid;

		private TeamExtraInfo _extrainfo = null;

		private ulong? _param;

		private TeamMemberType? _membertype;

		private string _account;

		private bool? _isplatfriend;

		private IExtension extensionObject;
	}
}
