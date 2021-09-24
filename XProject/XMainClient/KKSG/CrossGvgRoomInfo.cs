using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgRoomInfo")]
	[Serializable]
	public class CrossGvgRoomInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public uint roomid
		{
			get
			{
				return this._roomid ?? 0U;
			}
			set
			{
				this._roomid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new uint?(this.roomid) : null);
				}
			}
		}

		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guild1", DataFormat = DataFormat.TwosComplement)]
		public ulong guild1
		{
			get
			{
				return this._guild1 ?? 0UL;
			}
			set
			{
				this._guild1 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guild1Specified
		{
			get
			{
				return this._guild1 != null;
			}
			set
			{
				bool flag = value == (this._guild1 == null);
				if (flag)
				{
					this._guild1 = (value ? new ulong?(this.guild1) : null);
				}
			}
		}

		private bool ShouldSerializeguild1()
		{
			return this.guild1Specified;
		}

		private void Resetguild1()
		{
			this.guild1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guild2", DataFormat = DataFormat.TwosComplement)]
		public ulong guild2
		{
			get
			{
				return this._guild2 ?? 0UL;
			}
			set
			{
				this._guild2 = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guild2Specified
		{
			get
			{
				return this._guild2 != null;
			}
			set
			{
				bool flag = value == (this._guild2 == null);
				if (flag)
				{
					this._guild2 = (value ? new ulong?(this.guild2) : null);
				}
			}
		}

		private bool ShouldSerializeguild2()
		{
			return this.guild2Specified;
		}

		private void Resetguild2()
		{
			this.guild2Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgRoomState state
		{
			get
			{
				return this._state ?? CrossGvgRoomState.CGRS_Idle;
			}
			set
			{
				this._state = new CrossGvgRoomState?(value);
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
					this._state = (value ? new CrossGvgRoomState?(this.state) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "winguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong winguildid
		{
			get
			{
				return this._winguildid ?? 0UL;
			}
			set
			{
				this._winguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winguildidSpecified
		{
			get
			{
				return this._winguildid != null;
			}
			set
			{
				bool flag = value == (this._winguildid == null);
				if (flag)
				{
					this._winguildid = (value ? new ulong?(this.winguildid) : null);
				}
			}
		}

		private bool ShouldSerializewinguildid()
		{
			return this.winguildidSpecified;
		}

		private void Resetwinguildid()
		{
			this.winguildidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "gsline", DataFormat = DataFormat.TwosComplement)]
		public uint gsline
		{
			get
			{
				return this._gsline ?? 0U;
			}
			set
			{
				this._gsline = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gslineSpecified
		{
			get
			{
				return this._gsline != null;
			}
			set
			{
				bool flag = value == (this._gsline == null);
				if (flag)
				{
					this._gsline = (value ? new uint?(this.gsline) : null);
				}
			}
		}

		private bool ShouldSerializegsline()
		{
			return this.gslineSpecified;
		}

		private void Resetgsline()
		{
			this.gslineSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = false, Name = "win_score", DataFormat = DataFormat.TwosComplement)]
		public int win_score
		{
			get
			{
				return this._win_score ?? 0;
			}
			set
			{
				this._win_score = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool win_scoreSpecified
		{
			get
			{
				return this._win_score != null;
			}
			set
			{
				bool flag = value == (this._win_score == null);
				if (flag)
				{
					this._win_score = (value ? new int?(this.win_score) : null);
				}
			}
		}

		private bool ShouldSerializewin_score()
		{
			return this.win_scoreSpecified;
		}

		private void Resetwin_score()
		{
			this.win_scoreSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "lose_score", DataFormat = DataFormat.TwosComplement)]
		public int lose_score
		{
			get
			{
				return this._lose_score ?? 0;
			}
			set
			{
				this._lose_score = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lose_scoreSpecified
		{
			get
			{
				return this._lose_score != null;
			}
			set
			{
				bool flag = value == (this._lose_score == null);
				if (flag)
				{
					this._lose_score = (value ? new int?(this.lose_score) : null);
				}
			}
		}

		private bool ShouldSerializelose_score()
		{
			return this.lose_scoreSpecified;
		}

		private void Resetlose_score()
		{
			this.lose_scoreSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "in_ready", DataFormat = DataFormat.Default)]
		public bool in_ready
		{
			get
			{
				return this._in_ready ?? false;
			}
			set
			{
				this._in_ready = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool in_readySpecified
		{
			get
			{
				return this._in_ready != null;
			}
			set
			{
				bool flag = value == (this._in_ready == null);
				if (flag)
				{
					this._in_ready = (value ? new bool?(this.in_ready) : null);
				}
			}
		}

		private bool ShouldSerializein_ready()
		{
			return this.in_readySpecified;
		}

		private void Resetin_ready()
		{
			this.in_readySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _roomid;

		private ulong? _guild1;

		private ulong? _guild2;

		private CrossGvgRoomState? _state;

		private ulong? _winguildid;

		private uint? _liveid;

		private uint? _sceneid;

		private uint? _gsline;

		private uint? _time;

		private int? _win_score;

		private int? _lose_score;

		private bool? _in_ready;

		private IExtension extensionObject;
	}
}
