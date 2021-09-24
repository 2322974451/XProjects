using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleOneGame")]
	[Serializable]
	public class MobaBattleOneGame : IExtensible
	{

		[ProtoMember(1, Name = "team1", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameRole> team1
		{
			get
			{
				return this._team1;
			}
		}

		[ProtoMember(2, Name = "team2", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameRole> team2
		{
			get
			{
				return this._team2;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		private void Resettag()
		{
			this.tagSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "date", DataFormat = DataFormat.TwosComplement)]
		public uint date
		{
			get
			{
				return this._date ?? 0U;
			}
			set
			{
				this._date = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dateSpecified
		{
			get
			{
				return this._date != null;
			}
			set
			{
				bool flag = value == (this._date == null);
				if (flag)
				{
					this._date = (value ? new uint?(this.date) : null);
				}
			}
		}

		private bool ShouldSerializedate()
		{
			return this.dateSpecified;
		}

		private void Resetdate()
		{
			this.dateSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "timeSpan", DataFormat = DataFormat.TwosComplement)]
		public uint timeSpan
		{
			get
			{
				return this._timeSpan ?? 0U;
			}
			set
			{
				this._timeSpan = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpanSpecified
		{
			get
			{
				return this._timeSpan != null;
			}
			set
			{
				bool flag = value == (this._timeSpan == null);
				if (flag)
				{
					this._timeSpan = (value ? new uint?(this.timeSpan) : null);
				}
			}
		}

		private bool ShouldSerializetimeSpan()
		{
			return this.timeSpanSpecified;
		}

		private void ResettimeSpan()
		{
			this.timeSpanSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "winteamid", DataFormat = DataFormat.TwosComplement)]
		public uint winteamid
		{
			get
			{
				return this._winteamid ?? 0U;
			}
			set
			{
				this._winteamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winteamidSpecified
		{
			get
			{
				return this._winteamid != null;
			}
			set
			{
				bool flag = value == (this._winteamid == null);
				if (flag)
				{
					this._winteamid = (value ? new uint?(this.winteamid) : null);
				}
			}
		}

		private bool ShouldSerializewinteamid()
		{
			return this.winteamidSpecified;
		}

		private void Resetwinteamid()
		{
			this.winteamidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong losemvpid
		{
			get
			{
				return this._losemvpid ?? 0UL;
			}
			set
			{
				this._losemvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losemvpidSpecified
		{
			get
			{
				return this._losemvpid != null;
			}
			set
			{
				bool flag = value == (this._losemvpid == null);
				if (flag)
				{
					this._losemvpid = (value ? new ulong?(this.losemvpid) : null);
				}
			}
		}

		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "damagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong damagemaxid
		{
			get
			{
				return this._damagemaxid ?? 0UL;
			}
			set
			{
				this._damagemaxid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool damagemaxidSpecified
		{
			get
			{
				return this._damagemaxid != null;
			}
			set
			{
				bool flag = value == (this._damagemaxid == null);
				if (flag)
				{
					this._damagemaxid = (value ? new ulong?(this.damagemaxid) : null);
				}
			}
		}

		private bool ShouldSerializedamagemaxid()
		{
			return this.damagemaxidSpecified;
		}

		private void Resetdamagemaxid()
		{
			this.damagemaxidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "behitdamagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong behitdamagemaxid
		{
			get
			{
				return this._behitdamagemaxid ?? 0UL;
			}
			set
			{
				this._behitdamagemaxid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamagemaxidSpecified
		{
			get
			{
				return this._behitdamagemaxid != null;
			}
			set
			{
				bool flag = value == (this._behitdamagemaxid == null);
				if (flag)
				{
					this._behitdamagemaxid = (value ? new ulong?(this.behitdamagemaxid) : null);
				}
			}
		}

		private bool ShouldSerializebehitdamagemaxid()
		{
			return this.behitdamagemaxidSpecified;
		}

		private void Resetbehitdamagemaxid()
		{
			this.behitdamagemaxidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<MobaBattleOneGameRole> _team1 = new List<MobaBattleOneGameRole>();

		private readonly List<MobaBattleOneGameRole> _team2 = new List<MobaBattleOneGameRole>();

		private uint? _tag;

		private uint? _date;

		private uint? _timeSpan;

		private uint? _winteamid;

		private ulong? _mvpid;

		private ulong? _losemvpid;

		private ulong? _damagemaxid;

		private ulong? _behitdamagemaxid;

		private IExtension extensionObject;
	}
}
