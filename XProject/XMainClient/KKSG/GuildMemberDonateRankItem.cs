using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberDonateRankItem")]
	[Serializable]
	public class GuildMemberDonateRankItem : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "todaycount", DataFormat = DataFormat.TwosComplement)]
		public uint todaycount
		{
			get
			{
				return this._todaycount ?? 0U;
			}
			set
			{
				this._todaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todaycountSpecified
		{
			get
			{
				return this._todaycount != null;
			}
			set
			{
				bool flag = value == (this._todaycount == null);
				if (flag)
				{
					this._todaycount = (value ? new uint?(this.todaycount) : null);
				}
			}
		}

		private bool ShouldSerializetodaycount()
		{
			return this.todaycountSpecified;
		}

		private void Resettodaycount()
		{
			this.todaycountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totalcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalcount
		{
			get
			{
				return this._totalcount ?? 0U;
			}
			set
			{
				this._totalcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalcountSpecified
		{
			get
			{
				return this._totalcount != null;
			}
			set
			{
				bool flag = value == (this._totalcount == null);
				if (flag)
				{
					this._totalcount = (value ? new uint?(this.totalcount) : null);
				}
			}
		}

		private bool ShouldSerializetotalcount()
		{
			return this.totalcountSpecified;
		}

		private void Resettotalcount()
		{
			this.totalcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lasttime", DataFormat = DataFormat.TwosComplement)]
		public uint lasttime
		{
			get
			{
				return this._lasttime ?? 0U;
			}
			set
			{
				this._lasttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lasttimeSpecified
		{
			get
			{
				return this._lasttime != null;
			}
			set
			{
				bool flag = value == (this._lasttime == null);
				if (flag)
				{
					this._lasttime = (value ? new uint?(this.lasttime) : null);
				}
			}
		}

		private bool ShouldSerializelasttime()
		{
			return this.lasttimeSpecified;
		}

		private void Resetlasttime()
		{
			this.lasttimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
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
					this._profession = (value ? new uint?(this.profession) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _todaycount;

		private uint? _totalcount;

		private uint? _lasttime;

		private string _name;

		private uint? _level;

		private uint? _profession;

		private IExtension extensionObject;
	}
}
