using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PersonalHomePage")]
	[Serializable]
	public class PersonalHomePage : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "qq_vip", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip
		{
			get
			{
				return this._qq_vip ?? 0U;
			}
			set
			{
				this._qq_vip = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vipSpecified
		{
			get
			{
				return this._qq_vip != null;
			}
			set
			{
				bool flag = value == (this._qq_vip == null);
				if (flag)
				{
					this._qq_vip = (value ? new uint?(this.qq_vip) : null);
				}
			}
		}

		private bool ShouldSerializeqq_vip()
		{
			return this.qq_vipSpecified;
		}

		private void Resetqq_vip()
		{
			this.qq_vipSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "paymember_id", DataFormat = DataFormat.TwosComplement)]
		public uint paymember_id
		{
			get
			{
				return this._paymember_id ?? 0U;
			}
			set
			{
				this._paymember_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paymember_idSpecified
		{
			get
			{
				return this._paymember_id != null;
			}
			set
			{
				bool flag = value == (this._paymember_id == null);
				if (flag)
				{
					this._paymember_id = (value ? new uint?(this.paymember_id) : null);
				}
			}
		}

		private bool ShouldSerializepaymember_id()
		{
			return this.paymember_idSpecified;
		}

		private void Resetpaymember_id()
		{
			this.paymember_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "play_name", DataFormat = DataFormat.Default)]
		public string play_name
		{
			get
			{
				return this._play_name ?? "";
			}
			set
			{
				this._play_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool play_nameSpecified
		{
			get
			{
				return this._play_name != null;
			}
			set
			{
				bool flag = value == (this._play_name == null);
				if (flag)
				{
					this._play_name = (value ? this.play_name : null);
				}
			}
		}

		private bool ShouldSerializeplay_name()
		{
			return this.play_nameSpecified;
		}

		private void Resetplay_name()
		{
			this.play_nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public uint uid
		{
			get
			{
				return this._uid ?? 0U;
			}
			set
			{
				this._uid = new uint?(value);
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
					this._uid = (value ? new uint?(this.uid) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "declaration", DataFormat = DataFormat.Default)]
		public string declaration
		{
			get
			{
				return this._declaration ?? "";
			}
			set
			{
				this._declaration = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool declarationSpecified
		{
			get
			{
				return this._declaration != null;
			}
			set
			{
				bool flag = value == (this._declaration == null);
				if (flag)
				{
					this._declaration = (value ? this.declaration : null);
				}
			}
		}

		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "server_name", DataFormat = DataFormat.Default)]
		public string server_name
		{
			get
			{
				return this._server_name ?? "";
			}
			set
			{
				this._server_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool server_nameSpecified
		{
			get
			{
				return this._server_name != null;
			}
			set
			{
				bool flag = value == (this._server_name == null);
				if (flag)
				{
					this._server_name = (value ? this.server_name : null);
				}
			}
		}

		private bool ShouldSerializeserver_name()
		{
			return this.server_nameSpecified;
		}

		private void Resetserver_name()
		{
			this.server_nameSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
		public uint profession_id
		{
			get
			{
				return this._profession_id ?? 0U;
			}
			set
			{
				this._profession_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool profession_idSpecified
		{
			get
			{
				return this._profession_id != null;
			}
			set
			{
				bool flag = value == (this._profession_id == null);
				if (flag)
				{
					this._profession_id = (value ? new uint?(this.profession_id) : null);
				}
			}
		}

		private bool ShouldSerializeprofession_id()
		{
			return this.profession_idSpecified;
		}

		private void Resetprofession_id()
		{
			this.profession_idSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "guild_name", DataFormat = DataFormat.Default)]
		public string guild_name
		{
			get
			{
				return this._guild_name ?? "";
			}
			set
			{
				this._guild_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guild_nameSpecified
		{
			get
			{
				return this._guild_name != null;
			}
			set
			{
				bool flag = value == (this._guild_name == null);
				if (flag)
				{
					this._guild_name = (value ? this.guild_name : null);
				}
			}
		}

		private bool ShouldSerializeguild_name()
		{
			return this.guild_nameSpecified;
		}

		private void Resetguild_name()
		{
			this.guild_nameSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "power", DataFormat = DataFormat.TwosComplement)]
		public double power
		{
			get
			{
				return this._power ?? 0.0;
			}
			set
			{
				this._power = new double?(value);
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
					this._power = (value ? new double?(this.power) : null);
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

		[ProtoMember(11, IsRequired = false, Name = "continue_login_time", DataFormat = DataFormat.TwosComplement)]
		public uint continue_login_time
		{
			get
			{
				return this._continue_login_time ?? 0U;
			}
			set
			{
				this._continue_login_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continue_login_timeSpecified
		{
			get
			{
				return this._continue_login_time != null;
			}
			set
			{
				bool flag = value == (this._continue_login_time == null);
				if (flag)
				{
					this._continue_login_time = (value ? new uint?(this.continue_login_time) : null);
				}
			}
		}

		private bool ShouldSerializecontinue_login_time()
		{
			return this.continue_login_timeSpecified;
		}

		private void Resetcontinue_login_time()
		{
			this.continue_login_timeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "online_time", DataFormat = DataFormat.TwosComplement)]
		public uint online_time
		{
			get
			{
				return this._online_time ?? 0U;
			}
			set
			{
				this._online_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool online_timeSpecified
		{
			get
			{
				return this._online_time != null;
			}
			set
			{
				bool flag = value == (this._online_time == null);
				if (flag)
				{
					this._online_time = (value ? new uint?(this.online_time) : null);
				}
			}
		}

		private bool ShouldSerializeonline_time()
		{
			return this.online_timeSpecified;
		}

		private void Resetonline_time()
		{
			this.online_timeSpecified = false;
		}

		[ProtoMember(13, Name = "carrer_data", DataFormat = DataFormat.Default)]
		public List<CareerData> carrer_data
		{
			get
			{
				return this._carrer_data;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _qq_vip;

		private uint? _paymember_id;

		private string _play_name;

		private uint? _uid;

		private string _declaration;

		private string _server_name;

		private uint? _level;

		private uint? _profession_id;

		private string _guild_name;

		private double? _power;

		private uint? _continue_login_time;

		private uint? _online_time;

		private readonly List<CareerData> _carrer_data = new List<CareerData>();

		private IExtension extensionObject;
	}
}
