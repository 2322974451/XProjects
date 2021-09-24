using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageInfo")]
	[Serializable]
	public class StageInfo : IExtensible
	{

		[ProtoMember(1, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public List<int> sceneID
		{
			get
			{
				return this._sceneID;
			}
		}

		[ProtoMember(2, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public List<int> rank
		{
			get
			{
				return this._rank;
			}
		}

		[ProtoMember(3, Name = "countscenegroupid", DataFormat = DataFormat.TwosComplement)]
		public List<int> countscenegroupid
		{
			get
			{
				return this._countscenegroupid;
			}
		}

		[ProtoMember(4, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<int> count
		{
			get
			{
				return this._count;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public int day
		{
			get
			{
				return this._day ?? 0;
			}
			set
			{
				this._day = new int?(value);
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
					this._day = (value ? new int?(this.day) : null);
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

		[ProtoMember(6, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public List<int> buycount
		{
			get
			{
				return this._buycount;
			}
		}

		[ProtoMember(7, Name = "cdscenegroupid", DataFormat = DataFormat.TwosComplement)]
		public List<int> cdscenegroupid
		{
			get
			{
				return this._cdscenegroupid;
			}
		}

		[ProtoMember(8, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public List<int> cooldown
		{
			get
			{
				return this._cooldown;
			}
		}

		[ProtoMember(9, Name = "chapterchest", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chapterchest
		{
			get
			{
				return this._chapterchest;
			}
		}

		[ProtoMember(10, Name = "chestOpenedScene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chestOpenedScene
		{
			get
			{
				return this._chestOpenedScene;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "helperwincount", DataFormat = DataFormat.TwosComplement)]
		public int helperwincount
		{
			get
			{
				return this._helperwincount ?? 0;
			}
			set
			{
				this._helperwincount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool helperwincountSpecified
		{
			get
			{
				return this._helperwincount != null;
			}
			set
			{
				bool flag = value == (this._helperwincount == null);
				if (flag)
				{
					this._helperwincount = (value ? new int?(this.helperwincount) : null);
				}
			}
		}

		private bool ShouldSerializehelperwincount()
		{
			return this.helperwincountSpecified;
		}

		private void Resethelperwincount()
		{
			this.helperwincountSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "helperweekwincount", DataFormat = DataFormat.TwosComplement)]
		public int helperweekwincount
		{
			get
			{
				return this._helperweekwincount ?? 0;
			}
			set
			{
				this._helperweekwincount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool helperweekwincountSpecified
		{
			get
			{
				return this._helperweekwincount != null;
			}
			set
			{
				bool flag = value == (this._helperweekwincount == null);
				if (flag)
				{
					this._helperweekwincount = (value ? new int?(this.helperweekwincount) : null);
				}
			}
		}

		private bool ShouldSerializehelperweekwincount()
		{
			return this.helperweekwincountSpecified;
		}

		private void Resethelperweekwincount()
		{
			this.helperweekwincountSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "lastweekuptime", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekuptime
		{
			get
			{
				return this._lastweekuptime ?? 0U;
			}
			set
			{
				this._lastweekuptime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekuptimeSpecified
		{
			get
			{
				return this._lastweekuptime != null;
			}
			set
			{
				bool flag = value == (this._lastweekuptime == null);
				if (flag)
				{
					this._lastweekuptime = (value ? new uint?(this.lastweekuptime) : null);
				}
			}
		}

		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "bossrushmax", DataFormat = DataFormat.TwosComplement)]
		public uint bossrushmax
		{
			get
			{
				return this._bossrushmax ?? 0U;
			}
			set
			{
				this._bossrushmax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bossrushmaxSpecified
		{
			get
			{
				return this._bossrushmax != null;
			}
			set
			{
				bool flag = value == (this._bossrushmax == null);
				if (flag)
				{
					this._bossrushmax = (value ? new uint?(this.bossrushmax) : null);
				}
			}
		}

		private bool ShouldSerializebossrushmax()
		{
			return this.bossrushmaxSpecified;
		}

		private void Resetbossrushmax()
		{
			this.bossrushmaxSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "brupday", DataFormat = DataFormat.TwosComplement)]
		public int brupday
		{
			get
			{
				return this._brupday ?? 0;
			}
			set
			{
				this._brupday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool brupdaySpecified
		{
			get
			{
				return this._brupday != null;
			}
			set
			{
				bool flag = value == (this._brupday == null);
				if (flag)
				{
					this._brupday = (value ? new int?(this.brupday) : null);
				}
			}
		}

		private bool ShouldSerializebrupday()
		{
			return this.brupdaySpecified;
		}

		private void Resetbrupday()
		{
			this.brupdaySpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "BRjoincounttoday", DataFormat = DataFormat.TwosComplement)]
		public int BRjoincounttoday
		{
			get
			{
				return this._BRjoincounttoday ?? 0;
			}
			set
			{
				this._BRjoincounttoday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BRjoincounttodaySpecified
		{
			get
			{
				return this._BRjoincounttoday != null;
			}
			set
			{
				bool flag = value == (this._BRjoincounttoday == null);
				if (flag)
				{
					this._BRjoincounttoday = (value ? new int?(this.BRjoincounttoday) : null);
				}
			}
		}

		private bool ShouldSerializeBRjoincounttoday()
		{
			return this.BRjoincounttodaySpecified;
		}

		private void ResetBRjoincounttoday()
		{
			this.BRjoincounttodaySpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "BRrefreshcounttoday", DataFormat = DataFormat.TwosComplement)]
		public int BRrefreshcounttoday
		{
			get
			{
				return this._BRrefreshcounttoday ?? 0;
			}
			set
			{
				this._BRrefreshcounttoday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BRrefreshcounttodaySpecified
		{
			get
			{
				return this._BRrefreshcounttoday != null;
			}
			set
			{
				bool flag = value == (this._BRrefreshcounttoday == null);
				if (flag)
				{
					this._BRrefreshcounttoday = (value ? new int?(this.BRrefreshcounttoday) : null);
				}
			}
		}

		private bool ShouldSerializeBRrefreshcounttoday()
		{
			return this.BRrefreshcounttodaySpecified;
		}

		private void ResetBRrefreshcounttoday()
		{
			this.BRrefreshcounttodaySpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "brrankstate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BRRankState brrankstate
		{
			get
			{
				return this._brrankstate;
			}
			set
			{
				this._brrankstate = value;
			}
		}

		[ProtoMember(19, Name = "stageprogress", DataFormat = DataFormat.Default)]
		public List<DEStageProgress> stageprogress
		{
			get
			{
				return this._stageprogress;
			}
		}

		[ProtoMember(20, Name = "stageassist", DataFormat = DataFormat.Default)]
		public List<StageAssistOne> stageassist
		{
			get
			{
				return this._stageassist;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "holidayid", DataFormat = DataFormat.TwosComplement)]
		public uint holidayid
		{
			get
			{
				return this._holidayid ?? 0U;
			}
			set
			{
				this._holidayid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool holidayidSpecified
		{
			get
			{
				return this._holidayid != null;
			}
			set
			{
				bool flag = value == (this._holidayid == null);
				if (flag)
				{
					this._holidayid = (value ? new uint?(this.holidayid) : null);
				}
			}
		}

		private bool ShouldSerializeholidayid()
		{
			return this.holidayidSpecified;
		}

		private void Resetholidayid()
		{
			this.holidayidSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "holidaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint holidaytimes
		{
			get
			{
				return this._holidaytimes ?? 0U;
			}
			set
			{
				this._holidaytimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool holidaytimesSpecified
		{
			get
			{
				return this._holidaytimes != null;
			}
			set
			{
				bool flag = value == (this._holidaytimes == null);
				if (flag)
				{
					this._holidaytimes = (value ? new uint?(this.holidaytimes) : null);
				}
			}
		}

		private bool ShouldSerializeholidaytimes()
		{
			return this.holidaytimesSpecified;
		}

		private void Resetholidaytimes()
		{
			this.holidaytimesSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "absparty", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AbsPartyInfo absparty
		{
			get
			{
				return this._absparty;
			}
			set
			{
				this._absparty = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "kidhelpercount", DataFormat = DataFormat.TwosComplement)]
		public uint kidhelpercount
		{
			get
			{
				return this._kidhelpercount ?? 0U;
			}
			set
			{
				this._kidhelpercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kidhelpercountSpecified
		{
			get
			{
				return this._kidhelpercount != null;
			}
			set
			{
				bool flag = value == (this._kidhelpercount == null);
				if (flag)
				{
					this._kidhelpercount = (value ? new uint?(this.kidhelpercount) : null);
				}
			}
		}

		private bool ShouldSerializekidhelpercount()
		{
			return this.kidhelpercountSpecified;
		}

		private void Resetkidhelpercount()
		{
			this.kidhelpercountSpecified = false;
		}

		[ProtoMember(25, IsRequired = false, Name = "tarjatime", DataFormat = DataFormat.TwosComplement)]
		public uint tarjatime
		{
			get
			{
				return this._tarjatime ?? 0U;
			}
			set
			{
				this._tarjatime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tarjatimeSpecified
		{
			get
			{
				return this._tarjatime != null;
			}
			set
			{
				bool flag = value == (this._tarjatime == null);
				if (flag)
				{
					this._tarjatime = (value ? new uint?(this.tarjatime) : null);
				}
			}
		}

		private bool ShouldSerializetarjatime()
		{
			return this.tarjatimeSpecified;
		}

		private void Resettarjatime()
		{
			this.tarjatimeSpecified = false;
		}

		[ProtoMember(26, IsRequired = false, Name = "tarjaaward", DataFormat = DataFormat.TwosComplement)]
		public uint tarjaaward
		{
			get
			{
				return this._tarjaaward ?? 0U;
			}
			set
			{
				this._tarjaaward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tarjaawardSpecified
		{
			get
			{
				return this._tarjaaward != null;
			}
			set
			{
				bool flag = value == (this._tarjaaward == null);
				if (flag)
				{
					this._tarjaaward = (value ? new uint?(this.tarjaaward) : null);
				}
			}
		}

		private bool ShouldSerializetarjaaward()
		{
			return this.tarjaawardSpecified;
		}

		private void Resettarjaaward()
		{
			this.tarjaawardSpecified = false;
		}

		[ProtoMember(27, IsRequired = false, Name = "trophydata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageTrophy trophydata
		{
			get
			{
				return this._trophydata;
			}
			set
			{
				this._trophydata = value;
			}
		}

		[ProtoMember(28, Name = "dnes", DataFormat = DataFormat.Default)]
		public List<DneRecord> dnes
		{
			get
			{
				return this._dnes;
			}
		}

		[ProtoMember(29, IsRequired = false, Name = "despecialflag", DataFormat = DataFormat.Default)]
		public bool despecialflag
		{
			get
			{
				return this._despecialflag ?? false;
			}
			set
			{
				this._despecialflag = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool despecialflagSpecified
		{
			get
			{
				return this._despecialflag != null;
			}
			set
			{
				bool flag = value == (this._despecialflag == null);
				if (flag)
				{
					this._despecialflag = (value ? new bool?(this.despecialflag) : null);
				}
			}
		}

		private bool ShouldSerializedespecialflag()
		{
			return this.despecialflagSpecified;
		}

		private void Resetdespecialflag()
		{
			this.despecialflagSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<int> _sceneID = new List<int>();

		private readonly List<int> _rank = new List<int>();

		private readonly List<int> _countscenegroupid = new List<int>();

		private readonly List<int> _count = new List<int>();

		private int? _day;

		private readonly List<int> _buycount = new List<int>();

		private readonly List<int> _cdscenegroupid = new List<int>();

		private readonly List<int> _cooldown = new List<int>();

		private readonly List<uint> _chapterchest = new List<uint>();

		private readonly List<uint> _chestOpenedScene = new List<uint>();

		private int? _helperwincount;

		private int? _helperweekwincount;

		private uint? _lastweekuptime;

		private uint? _bossrushmax;

		private int? _brupday;

		private int? _BRjoincounttoday;

		private int? _BRrefreshcounttoday;

		private BRRankState _brrankstate = null;

		private readonly List<DEStageProgress> _stageprogress = new List<DEStageProgress>();

		private readonly List<StageAssistOne> _stageassist = new List<StageAssistOne>();

		private uint? _holidayid;

		private uint? _holidaytimes;

		private AbsPartyInfo _absparty = null;

		private uint? _kidhelpercount;

		private uint? _tarjatime;

		private uint? _tarjaaward;

		private StageTrophy _trophydata = null;

		private readonly List<DneRecord> _dnes = new List<DneRecord>();

		private bool? _despecialflag;

		private IExtension extensionObject;
	}
}
