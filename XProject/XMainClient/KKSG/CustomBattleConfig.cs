using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleConfig")]
	[Serializable]
	public class CustomBattleConfig : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "tagtype", DataFormat = DataFormat.TwosComplement)]
		public uint tagtype
		{
			get
			{
				return this._tagtype ?? 0U;
			}
			set
			{
				this._tagtype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tagtypeSpecified
		{
			get
			{
				return this._tagtype != null;
			}
			set
			{
				bool flag = value == (this._tagtype == null);
				if (flag)
				{
					this._tagtype = (value ? new uint?(this.tagtype) : null);
				}
			}
		}

		private bool ShouldSerializetagtype()
		{
			return this.tagtypeSpecified;
		}

		private void Resettagtype()
		{
			this.tagtypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "configid", DataFormat = DataFormat.TwosComplement)]
		public uint configid
		{
			get
			{
				return this._configid ?? 0U;
			}
			set
			{
				this._configid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool configidSpecified
		{
			get
			{
				return this._configid != null;
			}
			set
			{
				bool flag = value == (this._configid == null);
				if (flag)
				{
					this._configid = (value ? new uint?(this.configid) : null);
				}
			}
		}

		private bool ShouldSerializeconfigid()
		{
			return this.configidSpecified;
		}

		private void Resetconfigid()
		{
			this.configidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "scalemask", DataFormat = DataFormat.TwosComplement)]
		public uint scalemask
		{
			get
			{
				return this._scalemask ?? 0U;
			}
			set
			{
				this._scalemask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scalemaskSpecified
		{
			get
			{
				return this._scalemask != null;
			}
			set
			{
				bool flag = value == (this._scalemask == null);
				if (flag)
				{
					this._scalemask = (value ? new uint?(this.scalemask) : null);
				}
			}
		}

		private bool ShouldSerializescalemask()
		{
			return this.scalemaskSpecified;
		}

		private void Resetscalemask()
		{
			this.scalemaskSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "desc", DataFormat = DataFormat.Default)]
		public string desc
		{
			get
			{
				return this._desc ?? "";
			}
			set
			{
				this._desc = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool descSpecified
		{
			get
			{
				return this._desc != null;
			}
			set
			{
				bool flag = value == (this._desc == null);
				if (flag)
				{
					this._desc = (value ? this.desc : null);
				}
			}
		}

		private bool ShouldSerializedesc()
		{
			return this.descSpecified;
		}

		private void Resetdesc()
		{
			this.descSpecified = false;
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

		[ProtoMember(7, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
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

		[ProtoMember(8, IsRequired = false, Name = "isfair", DataFormat = DataFormat.Default)]
		public bool isfair
		{
			get
			{
				return this._isfair ?? false;
			}
			set
			{
				this._isfair = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isfairSpecified
		{
			get
			{
				return this._isfair != null;
			}
			set
			{
				bool flag = value == (this._isfair == null);
				if (flag)
				{
					this._isfair = (value ? new bool?(this.isfair) : null);
				}
			}
		}

		private bool ShouldSerializeisfair()
		{
			return this.isfairSpecified;
		}

		private void Resetisfair()
		{
			this.isfairSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "battletime", DataFormat = DataFormat.TwosComplement)]
		public uint battletime
		{
			get
			{
				return this._battletime ?? 0U;
			}
			set
			{
				this._battletime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battletimeSpecified
		{
			get
			{
				return this._battletime != null;
			}
			set
			{
				bool flag = value == (this._battletime == null);
				if (flag)
				{
					this._battletime = (value ? new uint?(this.battletime) : null);
				}
			}
		}

		private bool ShouldSerializebattletime()
		{
			return this.battletimeSpecified;
		}

		private void Resetbattletime()
		{
			this.battletimeSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "canjoincount", DataFormat = DataFormat.TwosComplement)]
		public uint canjoincount
		{
			get
			{
				return this._canjoincount ?? 0U;
			}
			set
			{
				this._canjoincount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canjoincountSpecified
		{
			get
			{
				return this._canjoincount != null;
			}
			set
			{
				bool flag = value == (this._canjoincount == null);
				if (flag)
				{
					this._canjoincount = (value ? new uint?(this.canjoincount) : null);
				}
			}
		}

		private bool ShouldSerializecanjoincount()
		{
			return this.canjoincountSpecified;
		}

		private void Resetcanjoincount()
		{
			this.canjoincountSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "creator", DataFormat = DataFormat.TwosComplement)]
		public ulong creator
		{
			get
			{
				return this._creator ?? 0UL;
			}
			set
			{
				this._creator = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool creatorSpecified
		{
			get
			{
				return this._creator != null;
			}
			set
			{
				bool flag = value == (this._creator == null);
				if (flag)
				{
					this._creator = (value ? new ulong?(this.creator) : null);
				}
			}
		}

		private bool ShouldSerializecreator()
		{
			return this.creatorSpecified;
		}

		private void Resetcreator()
		{
			this.creatorSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "creatorname", DataFormat = DataFormat.Default)]
		public string creatorname
		{
			get
			{
				return this._creatorname ?? "";
			}
			set
			{
				this._creatorname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool creatornameSpecified
		{
			get
			{
				return this._creatorname != null;
			}
			set
			{
				bool flag = value == (this._creatorname == null);
				if (flag)
				{
					this._creatorname = (value ? this.creatorname : null);
				}
			}
		}

		private bool ShouldSerializecreatorname()
		{
			return this.creatornameSpecified;
		}

		private void Resetcreatorname()
		{
			this.creatornameSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleState state
		{
			get
			{
				return this._state ?? CustomBattleState.CustomBattle_Ready;
			}
			set
			{
				this._state = new CustomBattleState?(value);
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
					this._state = (value ? new CustomBattleState?(this.state) : null);
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

		[ProtoMember(14, IsRequired = false, Name = "readytime", DataFormat = DataFormat.TwosComplement)]
		public uint readytime
		{
			get
			{
				return this._readytime ?? 0U;
			}
			set
			{
				this._readytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool readytimeSpecified
		{
			get
			{
				return this._readytime != null;
			}
			set
			{
				bool flag = value == (this._readytime == null);
				if (flag)
				{
					this._readytime = (value ? new uint?(this.readytime) : null);
				}
			}
		}

		private bool ShouldSerializereadytime()
		{
			return this.readytimeSpecified;
		}

		private void Resetreadytime()
		{
			this.readytimeSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "issystem", DataFormat = DataFormat.Default)]
		public bool issystem
		{
			get
			{
				return this._issystem ?? false;
			}
			set
			{
				this._issystem = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool issystemSpecified
		{
			get
			{
				return this._issystem != null;
			}
			set
			{
				bool flag = value == (this._issystem == null);
				if (flag)
				{
					this._issystem = (value ? new bool?(this.issystem) : null);
				}
			}
		}

		private bool ShouldSerializeissystem()
		{
			return this.issystemSpecified;
		}

		private void Resetissystem()
		{
			this.issystemSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "hasjoincount", DataFormat = DataFormat.TwosComplement)]
		public uint hasjoincount
		{
			get
			{
				return this._hasjoincount ?? 0U;
			}
			set
			{
				this._hasjoincount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasjoincountSpecified
		{
			get
			{
				return this._hasjoincount != null;
			}
			set
			{
				bool flag = value == (this._hasjoincount == null);
				if (flag)
				{
					this._hasjoincount = (value ? new uint?(this.hasjoincount) : null);
				}
			}
		}

		private bool ShouldSerializehasjoincount()
		{
			return this.hasjoincountSpecified;
		}

		private void Resethasjoincount()
		{
			this.hasjoincountSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "battletimeconf", DataFormat = DataFormat.TwosComplement)]
		public uint battletimeconf
		{
			get
			{
				return this._battletimeconf ?? 0U;
			}
			set
			{
				this._battletimeconf = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battletimeconfSpecified
		{
			get
			{
				return this._battletimeconf != null;
			}
			set
			{
				bool flag = value == (this._battletimeconf == null);
				if (flag)
				{
					this._battletimeconf = (value ? new uint?(this.battletimeconf) : null);
				}
			}
		}

		private bool ShouldSerializebattletimeconf()
		{
			return this.battletimeconfSpecified;
		}

		private void Resetbattletimeconf()
		{
			this.battletimeconfSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "tagmask", DataFormat = DataFormat.TwosComplement)]
		public uint tagmask
		{
			get
			{
				return this._tagmask ?? 0U;
			}
			set
			{
				this._tagmask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tagmaskSpecified
		{
			get
			{
				return this._tagmask != null;
			}
			set
			{
				bool flag = value == (this._tagmask == null);
				if (flag)
				{
					this._tagmask = (value ? new uint?(this.tagmask) : null);
				}
			}
		}

		private bool ShouldSerializetagmask()
		{
			return this.tagmaskSpecified;
		}

		private void Resettagmask()
		{
			this.tagmaskSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "fighttype", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleType fighttype
		{
			get
			{
				return this._fighttype ?? CustomBattleType.CustomBattle_PK_Normal;
			}
			set
			{
				this._fighttype = new CustomBattleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fighttypeSpecified
		{
			get
			{
				return this._fighttype != null;
			}
			set
			{
				bool flag = value == (this._fighttype == null);
				if (flag)
				{
					this._fighttype = (value ? new CustomBattleType?(this.fighttype) : null);
				}
			}
		}

		private bool ShouldSerializefighttype()
		{
			return this.fighttypeSpecified;
		}

		private void Resetfighttype()
		{
			this.fighttypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _tagtype;

		private uint? _configid;

		private uint? _scalemask;

		private string _name;

		private string _desc;

		private bool? _haspassword;

		private string _password;

		private bool? _isfair;

		private uint? _battletime;

		private uint? _canjoincount;

		private ulong? _creator;

		private string _creatorname;

		private CustomBattleState? _state;

		private uint? _readytime;

		private bool? _issystem;

		private uint? _hasjoincount;

		private string _token;

		private uint? _battletimeconf;

		private uint? _tagmask;

		private CustomBattleType? _fighttype;

		private IExtension extensionObject;
	}
}
