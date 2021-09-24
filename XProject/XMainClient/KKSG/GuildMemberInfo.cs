using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberInfo")]
	[Serializable]
	public class GuildMemberInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
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
					this._contribute = (value ? new int?(this.contribute) : null);
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

		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "groupFightContribute", DataFormat = DataFormat.TwosComplement)]
		public uint groupFightContribute
		{
			get
			{
				return this._groupFightContribute ?? 0U;
			}
			set
			{
				this._groupFightContribute = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupFightContributeSpecified
		{
			get
			{
				return this._groupFightContribute != null;
			}
			set
			{
				bool flag = value == (this._groupFightContribute == null);
				if (flag)
				{
					this._groupFightContribute = (value ? new uint?(this.groupFightContribute) : null);
				}
			}
		}

		private bool ShouldSerializegroupFightContribute()
		{
			return this.groupFightContributeSpecified;
		}

		private void ResetgroupFightContribute()
		{
			this.groupFightContributeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "joinTime", DataFormat = DataFormat.TwosComplement)]
		public uint joinTime
		{
			get
			{
				return this._joinTime ?? 0U;
			}
			set
			{
				this._joinTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joinTimeSpecified
		{
			get
			{
				return this._joinTime != null;
			}
			set
			{
				bool flag = value == (this._joinTime == null);
				if (flag)
				{
					this._joinTime = (value ? new uint?(this.joinTime) : null);
				}
			}
		}

		private bool ShouldSerializejoinTime()
		{
			return this.joinTimeSpecified;
		}

		private void ResetjoinTime()
		{
			this.joinTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "bind_status", DataFormat = DataFormat.TwosComplement)]
		public GuildBindStatus bind_status
		{
			get
			{
				return this._bind_status ?? GuildBindStatus.GBS_NotBind;
			}
			set
			{
				this._bind_status = new GuildBindStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bind_statusSpecified
		{
			get
			{
				return this._bind_status != null;
			}
			set
			{
				bool flag = value == (this._bind_status == null);
				if (flag)
				{
					this._bind_status = (value ? new GuildBindStatus?(this.bind_status) : null);
				}
			}
		}

		private bool ShouldSerializebind_status()
		{
			return this.bind_statusSpecified;
		}

		private void Resetbind_status()
		{
			this.bind_statusSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "update_bind_time", DataFormat = DataFormat.TwosComplement)]
		public uint update_bind_time
		{
			get
			{
				return this._update_bind_time ?? 0U;
			}
			set
			{
				this._update_bind_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool update_bind_timeSpecified
		{
			get
			{
				return this._update_bind_time != null;
			}
			set
			{
				bool flag = value == (this._update_bind_time == null);
				if (flag)
				{
					this._update_bind_time = (value ? new uint?(this.update_bind_time) : null);
				}
			}
		}

		private bool ShouldSerializeupdate_bind_time()
		{
			return this.update_bind_timeSpecified;
		}

		private void Resetupdate_bind_time()
		{
			this.update_bind_timeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "weeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyschoolpoint
		{
			get
			{
				return this._weeklyschoolpoint ?? 0U;
			}
			set
			{
				this._weeklyschoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyschoolpointSpecified
		{
			get
			{
				return this._weeklyschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyschoolpoint == null);
				if (flag)
				{
					this._weeklyschoolpoint = (value ? new uint?(this.weeklyschoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyschoolpoint()
		{
			return this.weeklyschoolpointSpecified;
		}

		private void Resetweeklyschoolpoint()
		{
			this.weeklyschoolpointSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "weeklyschooltime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyschooltime
		{
			get
			{
				return this._weeklyschooltime ?? 0U;
			}
			set
			{
				this._weeklyschooltime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyschooltimeSpecified
		{
			get
			{
				return this._weeklyschooltime != null;
			}
			set
			{
				bool flag = value == (this._weeklyschooltime == null);
				if (flag)
				{
					this._weeklyschooltime = (value ? new uint?(this.weeklyschooltime) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyschooltime()
		{
			return this.weeklyschooltimeSpecified;
		}

		private void Resetweeklyschooltime()
		{
			this.weeklyschooltimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "weeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhallpoint
		{
			get
			{
				return this._weeklyhallpoint ?? 0U;
			}
			set
			{
				this._weeklyhallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhallpointSpecified
		{
			get
			{
				return this._weeklyhallpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyhallpoint == null);
				if (flag)
				{
					this._weeklyhallpoint = (value ? new uint?(this.weeklyhallpoint) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyhallpoint()
		{
			return this.weeklyhallpointSpecified;
		}

		private void Resetweeklyhallpoint()
		{
			this.weeklyhallpointSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "weeklyhalltime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhalltime
		{
			get
			{
				return this._weeklyhalltime ?? 0U;
			}
			set
			{
				this._weeklyhalltime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhalltimeSpecified
		{
			get
			{
				return this._weeklyhalltime != null;
			}
			set
			{
				bool flag = value == (this._weeklyhalltime == null);
				if (flag)
				{
					this._weeklyhalltime = (value ? new uint?(this.weeklyhalltime) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyhalltime()
		{
			return this.weeklyhalltimeSpecified;
		}

		private void Resetweeklyhalltime()
		{
			this.weeklyhalltimeSpecified = false;
		}

		[ProtoMember(13, Name = "itemlist", DataFormat = DataFormat.Default)]
		public List<GuildZiCaiItemData> itemlist
		{
			get
			{
				return this._itemlist;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "weeklyhuntcount", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhuntcount
		{
			get
			{
				return this._weeklyhuntcount ?? 0U;
			}
			set
			{
				this._weeklyhuntcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhuntcountSpecified
		{
			get
			{
				return this._weeklyhuntcount != null;
			}
			set
			{
				bool flag = value == (this._weeklyhuntcount == null);
				if (flag)
				{
					this._weeklyhuntcount = (value ? new uint?(this.weeklyhuntcount) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyhuntcount()
		{
			return this.weeklyhuntcountSpecified;
		}

		private void Resetweeklyhuntcount()
		{
			this.weeklyhuntcountSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "weeklyhunttime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhunttime
		{
			get
			{
				return this._weeklyhunttime ?? 0U;
			}
			set
			{
				this._weeklyhunttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhunttimeSpecified
		{
			get
			{
				return this._weeklyhunttime != null;
			}
			set
			{
				bool flag = value == (this._weeklyhunttime == null);
				if (flag)
				{
					this._weeklyhunttime = (value ? new uint?(this.weeklyhunttime) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyhunttime()
		{
			return this.weeklyhunttimeSpecified;
		}

		private void Resetweeklyhunttime()
		{
			this.weeklyhunttimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private int? _position;

		private int? _contribute;

		private uint? _updateTime;

		private uint? _groupFightContribute;

		private uint? _joinTime;

		private GuildBindStatus? _bind_status;

		private uint? _update_bind_time;

		private uint? _weeklyschoolpoint;

		private uint? _weeklyschooltime;

		private uint? _weeklyhallpoint;

		private uint? _weeklyhalltime;

		private readonly List<GuildZiCaiItemData> _itemlist = new List<GuildZiCaiItemData>();

		private uint? _weeklyhuntcount;

		private uint? _weeklyhunttime;

		private IExtension extensionObject;
	}
}
