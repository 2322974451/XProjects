using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskRefreshRoleInfo")]
	[Serializable]
	public class DailyTaskRefreshRoleInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_num
		{
			get
			{
				return this._refresh_num ?? 0U;
			}
			set
			{
				this._refresh_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_numSpecified
		{
			get
			{
				return this._refresh_num != null;
			}
			set
			{
				bool flag = value == (this._refresh_num == null);
				if (flag)
				{
					this._refresh_num = (value ? new uint?(this.refresh_num) : null);
				}
			}
		}

		private bool ShouldSerializerefresh_num()
		{
			return this.refresh_numSpecified;
		}

		private void Resetrefresh_num()
		{
			this.refresh_numSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "already_ask", DataFormat = DataFormat.Default)]
		public bool already_ask
		{
			get
			{
				return this._already_ask ?? false;
			}
			set
			{
				this._already_ask = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool already_askSpecified
		{
			get
			{
				return this._already_ask != null;
			}
			set
			{
				bool flag = value == (this._already_ask == null);
				if (flag)
				{
					this._already_ask = (value ? new bool?(this.already_ask) : null);
				}
			}
		}

		private bool ShouldSerializealready_ask()
		{
			return this.already_askSpecified;
		}

		private void Resetalready_ask()
		{
			this.already_askSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "already_refused", DataFormat = DataFormat.Default)]
		public bool already_refused
		{
			get
			{
				return this._already_refused ?? false;
			}
			set
			{
				this._already_refused = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool already_refusedSpecified
		{
			get
			{
				return this._already_refused != null;
			}
			set
			{
				bool flag = value == (this._already_refused == null);
				if (flag)
				{
					this._already_refused = (value ? new bool?(this.already_refused) : null);
				}
			}
		}

		private bool ShouldSerializealready_refused()
		{
			return this.already_refusedSpecified;
		}

		private void Resetalready_refused()
		{
			this.already_refusedSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "already_helped", DataFormat = DataFormat.Default)]
		public bool already_helped
		{
			get
			{
				return this._already_helped ?? false;
			}
			set
			{
				this._already_helped = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool already_helpedSpecified
		{
			get
			{
				return this._already_helped != null;
			}
			set
			{
				bool flag = value == (this._already_helped == null);
				if (flag)
				{
					this._already_helped = (value ? new bool?(this.already_helped) : null);
				}
			}
		}

		private bool ShouldSerializealready_helped()
		{
			return this.already_helpedSpecified;
		}

		private void Resetalready_helped()
		{
			this.already_helpedSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "is_online", DataFormat = DataFormat.Default)]
		public bool is_online
		{
			get
			{
				return this._is_online ?? false;
			}
			set
			{
				this._is_online = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_onlineSpecified
		{
			get
			{
				return this._is_online != null;
			}
			set
			{
				bool flag = value == (this._is_online == null);
				if (flag)
				{
					this._is_online = (value ? new bool?(this.is_online) : null);
				}
			}
		}

		private bool ShouldSerializeis_online()
		{
			return this.is_onlineSpecified;
		}

		private void Resetis_online()
		{
			this.is_onlineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private RoleType? _profession;

		private uint? _luck;

		private uint? _refresh_num;

		private bool? _already_ask;

		private bool? _already_refused;

		private bool? _already_helped;

		private uint? _score;

		private uint? _time;

		private bool? _is_online;

		private IExtension extensionObject;
	}
}
