using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberData")]
	[Serializable]
	public class GuildMemberData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public uint contribute
		{
			get
			{
				return this._contribute ?? 0U;
			}
			set
			{
				this._contribute = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new uint?(this.contribute) : null);
				}
			}
		}

		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "flag", DataFormat = DataFormat.TwosComplement)]
		public uint flag
		{
			get
			{
				return this._flag ?? 0U;
			}
			set
			{
				this._flag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool flagSpecified
		{
			get
			{
				return this._flag != null;
			}
			set
			{
				bool flag = value == (this._flag == null);
				if (flag)
				{
					this._flag = (value ? new uint?(this.flag) : null);
				}
			}
		}

		private bool ShouldSerializeflag()
		{
			return this.flagSpecified;
		}

		private void Resetflag()
		{
			this.flagSpecified = false;
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

		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = false, Name = "vip", DataFormat = DataFormat.TwosComplement)]
		public uint vip
		{
			get
			{
				return this._vip ?? 0U;
			}
			set
			{
				this._vip = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipSpecified
		{
			get
			{
				return this._vip != null;
			}
			set
			{
				bool flag = value == (this._vip == null);
				if (flag)
				{
					this._vip = (value ? new uint?(this.vip) : null);
				}
			}
		}

		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "isonline", DataFormat = DataFormat.Default)]
		public bool isonline
		{
			get
			{
				return this._isonline ?? false;
			}
			set
			{
				this._isonline = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isonlineSpecified
		{
			get
			{
				return this._isonline != null;
			}
			set
			{
				bool flag = value == (this._isonline == null);
				if (flag)
				{
					this._isonline = (value ? new bool?(this.isonline) : null);
				}
			}
		}

		private bool ShouldSerializeisonline()
		{
			return this.isonlineSpecified;
		}

		private void Resetisonline()
		{
			this.isonlineSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(14, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
		public uint title
		{
			get
			{
				return this._title ?? 0U;
			}
			set
			{
				this._title = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? new uint?(this.title) : null);
				}
			}
		}

		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "task_luck", DataFormat = DataFormat.TwosComplement)]
		public uint task_luck
		{
			get
			{
				return this._task_luck ?? 0U;
			}
			set
			{
				this._task_luck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool task_luckSpecified
		{
			get
			{
				return this._task_luck != null;
			}
			set
			{
				bool flag = value == (this._task_luck == null);
				if (flag)
				{
					this._task_luck = (value ? new uint?(this.task_luck) : null);
				}
			}
		}

		private bool ShouldSerializetask_luck()
		{
			return this.task_luckSpecified;
		}

		private void Resettask_luck()
		{
			this.task_luckSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "task_score", DataFormat = DataFormat.TwosComplement)]
		public uint task_score
		{
			get
			{
				return this._task_score ?? 0U;
			}
			set
			{
				this._task_score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool task_scoreSpecified
		{
			get
			{
				return this._task_score != null;
			}
			set
			{
				bool flag = value == (this._task_score == null);
				if (flag)
				{
					this._task_score = (value ? new uint?(this.task_score) : null);
				}
			}
		}

		private bool ShouldSerializetask_score()
		{
			return this.task_scoreSpecified;
		}

		private void Resettask_score()
		{
			this.task_scoreSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "can_refresh", DataFormat = DataFormat.Default)]
		public bool can_refresh
		{
			get
			{
				return this._can_refresh ?? false;
			}
			set
			{
				this._can_refresh = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool can_refreshSpecified
		{
			get
			{
				return this._can_refresh != null;
			}
			set
			{
				bool flag = value == (this._can_refresh == null);
				if (flag)
				{
					this._can_refresh = (value ? new bool?(this.can_refresh) : null);
				}
			}
		}

		private bool ShouldSerializecan_refresh()
		{
			return this.can_refreshSpecified;
		}

		private void Resetcan_refresh()
		{
			this.can_refreshSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private ulong? _roleid;

		private int? _position;

		private uint? _contribute;

		private uint? _ppt;

		private uint? _flag;

		private uint? _level;

		private RoleType? _profession;

		private uint? _lastlogin;

		private uint? _vip;

		private bool? _isonline;

		private uint? _activity;

		private uint? _paymemberid;

		private uint? _title;

		private uint? _task_luck;

		private uint? _task_score;

		private bool? _can_refresh;

		private IExtension extensionObject;
	}
}
