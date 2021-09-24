using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleRecord")]
	[Serializable]
	public class HeroBattleRecord : IExtensible
	{

		[ProtoMember(1, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "cangetprize", DataFormat = DataFormat.Default)]
		public bool cangetprize
		{
			get
			{
				return this._cangetprize ?? false;
			}
			set
			{
				this._cangetprize = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cangetprizeSpecified
		{
			get
			{
				return this._cangetprize != null;
			}
			set
			{
				bool flag = value == (this._cangetprize == null);
				if (flag)
				{
					this._cangetprize = (value ? new bool?(this.cangetprize) : null);
				}
			}
		}

		private bool ShouldSerializecangetprize()
		{
			return this.cangetprizeSpecified;
		}

		private void Resetcangetprize()
		{
			this.cangetprizeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "alreadygetprize", DataFormat = DataFormat.Default)]
		public bool alreadygetprize
		{
			get
			{
				return this._alreadygetprize ?? false;
			}
			set
			{
				this._alreadygetprize = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool alreadygetprizeSpecified
		{
			get
			{
				return this._alreadygetprize != null;
			}
			set
			{
				bool flag = value == (this._alreadygetprize == null);
				if (flag)
				{
					this._alreadygetprize = (value ? new bool?(this.alreadygetprize) : null);
				}
			}
		}

		private bool ShouldSerializealreadygetprize()
		{
			return this.alreadygetprizeSpecified;
		}

		private void Resetalreadygetprize()
		{
			this.alreadygetprizeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "totalnum", DataFormat = DataFormat.TwosComplement)]
		public uint totalnum
		{
			get
			{
				return this._totalnum ?? 0U;
			}
			set
			{
				this._totalnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalnumSpecified
		{
			get
			{
				return this._totalnum != null;
			}
			set
			{
				bool flag = value == (this._totalnum == null);
				if (flag)
				{
					this._totalnum = (value ? new uint?(this.totalnum) : null);
				}
			}
		}

		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "losenum", DataFormat = DataFormat.TwosComplement)]
		public uint losenum
		{
			get
			{
				return this._losenum ?? 0U;
			}
			set
			{
				this._losenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losenumSpecified
		{
			get
			{
				return this._losenum != null;
			}
			set
			{
				bool flag = value == (this._losenum == null);
				if (flag)
				{
					this._losenum = (value ? new uint?(this.losenum) : null);
				}
			}
		}

		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "winthisweek", DataFormat = DataFormat.TwosComplement)]
		public uint winthisweek
		{
			get
			{
				return this._winthisweek ?? 0U;
			}
			set
			{
				this._winthisweek = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winthisweekSpecified
		{
			get
			{
				return this._winthisweek != null;
			}
			set
			{
				bool flag = value == (this._winthisweek == null);
				if (flag)
				{
					this._winthisweek = (value ? new uint?(this.winthisweek) : null);
				}
			}
		}

		private bool ShouldSerializewinthisweek()
		{
			return this.winthisweekSpecified;
		}

		private void Resetwinthisweek()
		{
			this.winthisweekSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "lastupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdatetime
		{
			get
			{
				return this._lastupdatetime ?? 0U;
			}
			set
			{
				this._lastupdatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdatetimeSpecified
		{
			get
			{
				return this._lastupdatetime != null;
			}
			set
			{
				bool flag = value == (this._lastupdatetime == null);
				if (flag)
				{
					this._lastupdatetime = (value ? new uint?(this.lastupdatetime) : null);
				}
			}
		}

		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		[ProtoMember(9, Name = "gamerecord", DataFormat = DataFormat.Default)]
		public List<HeroBattleOneGame> gamerecord
		{
			get
			{
				return this._gamerecord;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "todayspcount", DataFormat = DataFormat.TwosComplement)]
		public uint todayspcount
		{
			get
			{
				return this._todayspcount ?? 0U;
			}
			set
			{
				this._todayspcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todayspcountSpecified
		{
			get
			{
				return this._todayspcount != null;
			}
			set
			{
				bool flag = value == (this._todayspcount == null);
				if (flag)
				{
					this._todayspcount = (value ? new uint?(this.todayspcount) : null);
				}
			}
		}

		private bool ShouldSerializetodayspcount()
		{
			return this.todayspcountSpecified;
		}

		private void Resettodayspcount()
		{
			this.todayspcountSpecified = false;
		}

		[ProtoMember(11, Name = "freeweekhero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> freeweekhero
		{
			get
			{
				return this._freeweekhero;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "bigrewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint bigrewardcount
		{
			get
			{
				return this._bigrewardcount ?? 0U;
			}
			set
			{
				this._bigrewardcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bigrewardcountSpecified
		{
			get
			{
				return this._bigrewardcount != null;
			}
			set
			{
				bool flag = value == (this._bigrewardcount == null);
				if (flag)
				{
					this._bigrewardcount = (value ? new uint?(this.bigrewardcount) : null);
				}
			}
		}

		private bool ShouldSerializebigrewardcount()
		{
			return this.bigrewardcountSpecified;
		}

		private void Resetbigrewardcount()
		{
			this.bigrewardcountSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "elopoint", DataFormat = DataFormat.TwosComplement)]
		public double elopoint
		{
			get
			{
				return this._elopoint ?? 0.0;
			}
			set
			{
				this._elopoint = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool elopointSpecified
		{
			get
			{
				return this._elopoint != null;
			}
			set
			{
				bool flag = value == (this._elopoint == null);
				if (flag)
				{
					this._elopoint = (value ? new double?(this.elopoint) : null);
				}
			}
		}

		private bool ShouldSerializeelopoint()
		{
			return this.elopointSpecified;
		}

		private void Resetelopoint()
		{
			this.elopointSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "daytime", DataFormat = DataFormat.TwosComplement)]
		public uint daytime
		{
			get
			{
				return this._daytime ?? 0U;
			}
			set
			{
				this._daytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daytimeSpecified
		{
			get
			{
				return this._daytime != null;
			}
			set
			{
				bool flag = value == (this._daytime == null);
				if (flag)
				{
					this._daytime = (value ? new uint?(this.daytime) : null);
				}
			}
		}

		private bool ShouldSerializedaytime()
		{
			return this.daytimeSpecified;
		}

		private void Resetdaytime()
		{
			this.daytimeSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "daytimes", DataFormat = DataFormat.TwosComplement)]
		public uint daytimes
		{
			get
			{
				return this._daytimes ?? 0U;
			}
			set
			{
				this._daytimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daytimesSpecified
		{
			get
			{
				return this._daytimes != null;
			}
			set
			{
				bool flag = value == (this._daytimes == null);
				if (flag)
				{
					this._daytimes = (value ? new uint?(this.daytimes) : null);
				}
			}
		}

		private bool ShouldSerializedaytimes()
		{
			return this.daytimesSpecified;
		}

		private void Resetdaytimes()
		{
			this.daytimesSpecified = false;
		}

		[ProtoMember(17, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		[ProtoMember(18, Name = "experienceherotime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experienceherotime
		{
			get
			{
				return this._experienceherotime;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "continuewinnum", DataFormat = DataFormat.TwosComplement)]
		public uint continuewinnum
		{
			get
			{
				return this._continuewinnum ?? 0U;
			}
			set
			{
				this._continuewinnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinnumSpecified
		{
			get
			{
				return this._continuewinnum != null;
			}
			set
			{
				bool flag = value == (this._continuewinnum == null);
				if (flag)
				{
					this._continuewinnum = (value ? new uint?(this.continuewinnum) : null);
				}
			}
		}

		private bool ShouldSerializecontinuewinnum()
		{
			return this.continuewinnumSpecified;
		}

		private void Resetcontinuewinnum()
		{
			this.continuewinnumSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "maxkillnum", DataFormat = DataFormat.TwosComplement)]
		public uint maxkillnum
		{
			get
			{
				return this._maxkillnum ?? 0U;
			}
			set
			{
				this._maxkillnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxkillnumSpecified
		{
			get
			{
				return this._maxkillnum != null;
			}
			set
			{
				bool flag = value == (this._maxkillnum == null);
				if (flag)
				{
					this._maxkillnum = (value ? new uint?(this.maxkillnum) : null);
				}
			}
		}

		private bool ShouldSerializemaxkillnum()
		{
			return this.maxkillnumSpecified;
		}

		private void Resetmaxkillnum()
		{
			this.maxkillnumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _havehero = new List<uint>();

		private bool? _cangetprize;

		private bool? _alreadygetprize;

		private uint? _totalnum;

		private uint? _winnum;

		private uint? _losenum;

		private uint? _winthisweek;

		private uint? _lastupdatetime;

		private readonly List<HeroBattleOneGame> _gamerecord = new List<HeroBattleOneGame>();

		private uint? _todayspcount;

		private readonly List<uint> _freeweekhero = new List<uint>();

		private uint? _bigrewardcount;

		private uint? _weekprize;

		private double? _elopoint;

		private uint? _daytime;

		private uint? _daytimes;

		private readonly List<uint> _experiencehero = new List<uint>();

		private readonly List<uint> _experienceherotime = new List<uint>();

		private uint? _continuewinnum;

		private uint? _maxkillnum;

		private IExtension extensionObject;
	}
}
