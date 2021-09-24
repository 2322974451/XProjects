using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRecord")]
	[Serializable]
	public class PkRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "week", DataFormat = DataFormat.TwosComplement)]
		public uint week
		{
			get
			{
				return this._week ?? 0U;
			}
			set
			{
				this._week = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekSpecified
		{
			get
			{
				return this._week != null;
			}
			set
			{
				bool flag = value == (this._week == null);
				if (flag)
				{
					this._week = (value ? new uint?(this.week) : null);
				}
			}
		}

		private bool ShouldSerializeweek()
		{
			return this.weekSpecified;
		}

		private void Resetweek()
		{
			this.weekSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "unused_win", DataFormat = DataFormat.TwosComplement)]
		public uint unused_win
		{
			get
			{
				return this._unused_win ?? 0U;
			}
			set
			{
				this._unused_win = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_winSpecified
		{
			get
			{
				return this._unused_win != null;
			}
			set
			{
				bool flag = value == (this._unused_win == null);
				if (flag)
				{
					this._unused_win = (value ? new uint?(this.unused_win) : null);
				}
			}
		}

		private bool ShouldSerializeunused_win()
		{
			return this.unused_winSpecified;
		}

		private void Resetunused_win()
		{
			this.unused_winSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "unused_lose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lose
		{
			get
			{
				return this._unused_lose ?? 0U;
			}
			set
			{
				this._unused_lose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_loseSpecified
		{
			get
			{
				return this._unused_lose != null;
			}
			set
			{
				bool flag = value == (this._unused_lose == null);
				if (flag)
				{
					this._unused_lose = (value ? new uint?(this.unused_lose) : null);
				}
			}
		}

		private bool ShouldSerializeunused_lose()
		{
			return this.unused_loseSpecified;
		}

		private void Resetunused_lose()
		{
			this.unused_loseSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "unused_continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint unused_continuewin
		{
			get
			{
				return this._unused_continuewin ?? 0U;
			}
			set
			{
				this._unused_continuewin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_continuewinSpecified
		{
			get
			{
				return this._unused_continuewin != null;
			}
			set
			{
				bool flag = value == (this._unused_continuewin == null);
				if (flag)
				{
					this._unused_continuewin = (value ? new uint?(this.unused_continuewin) : null);
				}
			}
		}

		private bool ShouldSerializeunused_continuewin()
		{
			return this.unused_continuewinSpecified;
		}

		private void Resetunused_continuewin()
		{
			this.unused_continuewinSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		[ProtoMember(7, Name = "boxtaken", DataFormat = DataFormat.TwosComplement)]
		public List<uint> boxtaken
		{
			get
			{
				return this._boxtaken;
			}
		}

		[ProtoMember(8, Name = "records", DataFormat = DataFormat.Default)]
		public List<PkOneRecord> records
		{
			get
			{
				return this._records;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "unused_continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_continuelose
		{
			get
			{
				return this._unused_continuelose ?? 0U;
			}
			set
			{
				this._unused_continuelose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_continueloseSpecified
		{
			get
			{
				return this._unused_continuelose != null;
			}
			set
			{
				bool flag = value == (this._unused_continuelose == null);
				if (flag)
				{
					this._unused_continuelose = (value ? new uint?(this.unused_continuelose) : null);
				}
			}
		}

		private bool ShouldSerializeunused_continuelose()
		{
			return this.unused_continueloseSpecified;
		}

		private void Resetunused_continuelose()
		{
			this.unused_continueloseSpecified = false;
		}

		[ProtoMember(10, Name = "prowin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prowin
		{
			get
			{
				return this._prowin;
			}
		}

		[ProtoMember(11, Name = "prolose", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prolose
		{
			get
			{
				return this._prolose;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "unused_lastwin", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lastwin
		{
			get
			{
				return this._unused_lastwin ?? 0U;
			}
			set
			{
				this._unused_lastwin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_lastwinSpecified
		{
			get
			{
				return this._unused_lastwin != null;
			}
			set
			{
				bool flag = value == (this._unused_lastwin == null);
				if (flag)
				{
					this._unused_lastwin = (value ? new uint?(this.unused_lastwin) : null);
				}
			}
		}

		private bool ShouldSerializeunused_lastwin()
		{
			return this.unused_lastwinSpecified;
		}

		private void Resetunused_lastwin()
		{
			this.unused_lastwinSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "unused_lastlose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lastlose
		{
			get
			{
				return this._unused_lastlose ?? 0U;
			}
			set
			{
				this._unused_lastlose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_lastloseSpecified
		{
			get
			{
				return this._unused_lastlose != null;
			}
			set
			{
				bool flag = value == (this._unused_lastlose == null);
				if (flag)
				{
					this._unused_lastlose = (value ? new uint?(this.unused_lastlose) : null);
				}
			}
		}

		private bool ShouldSerializeunused_lastlose()
		{
			return this.unused_lastloseSpecified;
		}

		private void Resetunused_lastlose()
		{
			this.unused_lastloseSpecified = false;
		}

		[ProtoMember(14, Name = "prodraw", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prodraw
		{
			get
			{
				return this._prodraw;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "unused_draw", DataFormat = DataFormat.TwosComplement)]
		public uint unused_draw
		{
			get
			{
				return this._unused_draw ?? 0U;
			}
			set
			{
				this._unused_draw = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unused_drawSpecified
		{
			get
			{
				return this._unused_draw != null;
			}
			set
			{
				bool flag = value == (this._unused_draw == null);
				if (flag)
				{
					this._unused_draw = (value ? new uint?(this.unused_draw) : null);
				}
			}
		}

		private bool ShouldSerializeunused_draw()
		{
			return this.unused_drawSpecified;
		}

		private void Resetunused_draw()
		{
			this.unused_drawSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "pointlastlose", DataFormat = DataFormat.TwosComplement)]
		public uint pointlastlose
		{
			get
			{
				return this._pointlastlose ?? 0U;
			}
			set
			{
				this._pointlastlose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointlastloseSpecified
		{
			get
			{
				return this._pointlastlose != null;
			}
			set
			{
				bool flag = value == (this._pointlastlose == null);
				if (flag)
				{
					this._pointlastlose = (value ? new uint?(this.pointlastlose) : null);
				}
			}
		}

		private bool ShouldSerializepointlastlose()
		{
			return this.pointlastloseSpecified;
		}

		private void Resetpointlastlose()
		{
			this.pointlastloseSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		private void Resetday()
		{
			this.daySpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "rewardcounttoday", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcounttoday
		{
			get
			{
				return this._rewardcounttoday ?? 0U;
			}
			set
			{
				this._rewardcounttoday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcounttodaySpecified
		{
			get
			{
				return this._rewardcounttoday != null;
			}
			set
			{
				bool flag = value == (this._rewardcounttoday == null);
				if (flag)
				{
					this._rewardcounttoday = (value ? new uint?(this.rewardcounttoday) : null);
				}
			}
		}

		private bool ShouldSerializerewardcounttoday()
		{
			return this.rewardcounttodaySpecified;
		}

		private void Resetrewardcounttoday()
		{
			this.rewardcounttodaySpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "todayplaytime", DataFormat = DataFormat.TwosComplement)]
		public uint todayplaytime
		{
			get
			{
				return this._todayplaytime ?? 0U;
			}
			set
			{
				this._todayplaytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todayplaytimeSpecified
		{
			get
			{
				return this._todayplaytime != null;
			}
			set
			{
				bool flag = value == (this._todayplaytime == null);
				if (flag)
				{
					this._todayplaytime = (value ? new uint?(this.todayplaytime) : null);
				}
			}
		}

		private bool ShouldSerializetodayplaytime()
		{
			return this.todayplaytimeSpecified;
		}

		private void Resettodayplaytime()
		{
			this.todayplaytimeSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "histweek", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histweek
		{
			get
			{
				return this._histweek;
			}
			set
			{
				this._histweek = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "histall", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histall
		{
			get
			{
				return this._histall;
			}
			set
			{
				this._histall = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "pkdaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint pkdaytimes
		{
			get
			{
				return this._pkdaytimes ?? 0U;
			}
			set
			{
				this._pkdaytimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pkdaytimesSpecified
		{
			get
			{
				return this._pkdaytimes != null;
			}
			set
			{
				bool flag = value == (this._pkdaytimes == null);
				if (flag)
				{
					this._pkdaytimes = (value ? new uint?(this.pkdaytimes) : null);
				}
			}
		}

		private bool ShouldSerializepkdaytimes()
		{
			return this.pkdaytimesSpecified;
		}

		private void Resetpkdaytimes()
		{
			this.pkdaytimesSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "weektimes", DataFormat = DataFormat.TwosComplement)]
		public uint weektimes
		{
			get
			{
				return this._weektimes ?? 0U;
			}
			set
			{
				this._weektimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weektimesSpecified
		{
			get
			{
				return this._weektimes != null;
			}
			set
			{
				bool flag = value == (this._weektimes == null);
				if (flag)
				{
					this._weektimes = (value ? new uint?(this.weektimes) : null);
				}
			}
		}

		private bool ShouldSerializeweektimes()
		{
			return this.weektimesSpecified;
		}

		private void Resetweektimes()
		{
			this.weektimesSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "last7daystime", DataFormat = DataFormat.TwosComplement)]
		public uint last7daystime
		{
			get
			{
				return this._last7daystime ?? 0U;
			}
			set
			{
				this._last7daystime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last7daystimeSpecified
		{
			get
			{
				return this._last7daystime != null;
			}
			set
			{
				bool flag = value == (this._last7daystime == null);
				if (flag)
				{
					this._last7daystime = (value ? new uint?(this.last7daystime) : null);
				}
			}
		}

		private bool ShouldSerializelast7daystime()
		{
			return this.last7daystimeSpecified;
		}

		private void Resetlast7daystime()
		{
			this.last7daystimeSpecified = false;
		}

		[ProtoMember(25, IsRequired = false, Name = "info2v2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecordSubInfo info2v2
		{
			get
			{
				return this._info2v2;
			}
			set
			{
				this._info2v2 = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "oneweekresettime", DataFormat = DataFormat.TwosComplement)]
		public uint oneweekresettime
		{
			get
			{
				return this._oneweekresettime ?? 0U;
			}
			set
			{
				this._oneweekresettime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool oneweekresettimeSpecified
		{
			get
			{
				return this._oneweekresettime != null;
			}
			set
			{
				bool flag = value == (this._oneweekresettime == null);
				if (flag)
				{
					this._oneweekresettime = (value ? new uint?(this.oneweekresettime) : null);
				}
			}
		}

		private bool ShouldSerializeoneweekresettime()
		{
			return this.oneweekresettimeSpecified;
		}

		private void Resetoneweekresettime()
		{
			this.oneweekresettimeSpecified = false;
		}

		[ProtoMember(27, IsRequired = false, Name = "lastweekpoint", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekpoint
		{
			get
			{
				return this._lastweekpoint ?? 0U;
			}
			set
			{
				this._lastweekpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekpointSpecified
		{
			get
			{
				return this._lastweekpoint != null;
			}
			set
			{
				bool flag = value == (this._lastweekpoint == null);
				if (flag)
				{
					this._lastweekpoint = (value ? new uint?(this.lastweekpoint) : null);
				}
			}
		}

		private bool ShouldSerializelastweekpoint()
		{
			return this.lastweekpointSpecified;
		}

		private void Resetlastweekpoint()
		{
			this.lastweekpointSpecified = false;
		}

		[ProtoMember(28, IsRequired = false, Name = "histday", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histday
		{
			get
			{
				return this._histday;
			}
			set
			{
				this._histday = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _point;

		private uint? _week;

		private uint? _unused_win;

		private uint? _unused_lose;

		private uint? _unused_continuewin;

		private uint? _honorpoint;

		private readonly List<uint> _boxtaken = new List<uint>();

		private readonly List<PkOneRecord> _records = new List<PkOneRecord>();

		private uint? _unused_continuelose;

		private readonly List<uint> _prowin = new List<uint>();

		private readonly List<uint> _prolose = new List<uint>();

		private uint? _unused_lastwin;

		private uint? _unused_lastlose;

		private readonly List<uint> _prodraw = new List<uint>();

		private uint? _unused_draw;

		private uint? _pointlastlose;

		private uint? _day;

		private uint? _rewardcounttoday;

		private uint? _todayplaytime;

		private PkBaseHist _histweek = null;

		private PkBaseHist _histall = null;

		private uint? _pkdaytimes;

		private uint? _weektimes;

		private uint? _last7daystime;

		private PkRecordSubInfo _info2v2 = null;

		private uint? _oneweekresettime;

		private uint? _lastweekpoint;

		private PkBaseHist _histday = null;

		private IExtension extensionObject;
	}
}
