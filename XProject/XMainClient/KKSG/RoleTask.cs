using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleTask")]
	[Serializable]
	public class RoleTask : IExtensible
	{

		[ProtoMember(1, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<TaskInfo> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		[ProtoMember(2, Name = "finished", DataFormat = DataFormat.TwosComplement)]
		public List<uint> finished
		{
			get
			{
				return this._finished;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		[ProtoMember(4, Name = "dailytask", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> dailytask
		{
			get
			{
				return this._dailytask;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "daily_count", DataFormat = DataFormat.TwosComplement)]
		public uint daily_count
		{
			get
			{
				return this._daily_count ?? 0U;
			}
			set
			{
				this._daily_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_countSpecified
		{
			get
			{
				return this._daily_count != null;
			}
			set
			{
				bool flag = value == (this._daily_count == null);
				if (flag)
				{
					this._daily_count = (value ? new uint?(this.daily_count) : null);
				}
			}
		}

		private bool ShouldSerializedaily_count()
		{
			return this.daily_countSpecified;
		}

		private void Resetdaily_count()
		{
			this.daily_countSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "daily_accept_level", DataFormat = DataFormat.TwosComplement)]
		public uint daily_accept_level
		{
			get
			{
				return this._daily_accept_level ?? 0U;
			}
			set
			{
				this._daily_accept_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_accept_levelSpecified
		{
			get
			{
				return this._daily_accept_level != null;
			}
			set
			{
				bool flag = value == (this._daily_accept_level == null);
				if (flag)
				{
					this._daily_accept_level = (value ? new uint?(this.daily_accept_level) : null);
				}
			}
		}

		private bool ShouldSerializedaily_accept_level()
		{
			return this.daily_accept_levelSpecified;
		}

		private void Resetdaily_accept_level()
		{
			this.daily_accept_levelSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "daily_rewarded", DataFormat = DataFormat.Default)]
		public bool daily_rewarded
		{
			get
			{
				return this._daily_rewarded ?? false;
			}
			set
			{
				this._daily_rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_rewardedSpecified
		{
			get
			{
				return this._daily_rewarded != null;
			}
			set
			{
				bool flag = value == (this._daily_rewarded == null);
				if (flag)
				{
					this._daily_rewarded = (value ? new bool?(this.daily_rewarded) : null);
				}
			}
		}

		private bool ShouldSerializedaily_rewarded()
		{
			return this.daily_rewardedSpecified;
		}

		private void Resetdaily_rewarded()
		{
			this.daily_rewardedSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "daily_complete_num", DataFormat = DataFormat.TwosComplement)]
		public uint daily_complete_num
		{
			get
			{
				return this._daily_complete_num ?? 0U;
			}
			set
			{
				this._daily_complete_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_complete_numSpecified
		{
			get
			{
				return this._daily_complete_num != null;
			}
			set
			{
				bool flag = value == (this._daily_complete_num == null);
				if (flag)
				{
					this._daily_complete_num = (value ? new uint?(this.daily_complete_num) : null);
				}
			}
		}

		private bool ShouldSerializedaily_complete_num()
		{
			return this.daily_complete_numSpecified;
		}

		private void Resetdaily_complete_num()
		{
			this.daily_complete_numSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "daily_red_point", DataFormat = DataFormat.Default)]
		public bool daily_red_point
		{
			get
			{
				return this._daily_red_point ?? false;
			}
			set
			{
				this._daily_red_point = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_red_pointSpecified
		{
			get
			{
				return this._daily_red_point != null;
			}
			set
			{
				bool flag = value == (this._daily_red_point == null);
				if (flag)
				{
					this._daily_red_point = (value ? new bool?(this.daily_red_point) : null);
				}
			}
		}

		private bool ShouldSerializedaily_red_point()
		{
			return this.daily_red_pointSpecified;
		}

		private void Resetdaily_red_point()
		{
			this.daily_red_pointSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "daily_askhelp_num", DataFormat = DataFormat.TwosComplement)]
		public uint daily_askhelp_num
		{
			get
			{
				return this._daily_askhelp_num ?? 0U;
			}
			set
			{
				this._daily_askhelp_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daily_askhelp_numSpecified
		{
			get
			{
				return this._daily_askhelp_num != null;
			}
			set
			{
				bool flag = value == (this._daily_askhelp_num == null);
				if (flag)
				{
					this._daily_askhelp_num = (value ? new uint?(this.daily_askhelp_num) : null);
				}
			}
		}

		private bool ShouldSerializedaily_askhelp_num()
		{
			return this.daily_askhelp_numSpecified;
		}

		private void Resetdaily_askhelp_num()
		{
			this.daily_askhelp_numSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "today_donate_count", DataFormat = DataFormat.TwosComplement)]
		public uint today_donate_count
		{
			get
			{
				return this._today_donate_count ?? 0U;
			}
			set
			{
				this._today_donate_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool today_donate_countSpecified
		{
			get
			{
				return this._today_donate_count != null;
			}
			set
			{
				bool flag = value == (this._today_donate_count == null);
				if (flag)
				{
					this._today_donate_count = (value ? new uint?(this.today_donate_count) : null);
				}
			}
		}

		private bool ShouldSerializetoday_donate_count()
		{
			return this.today_donate_countSpecified;
		}

		private void Resettoday_donate_count()
		{
			this.today_donate_countSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "total_donate_count", DataFormat = DataFormat.TwosComplement)]
		public uint total_donate_count
		{
			get
			{
				return this._total_donate_count ?? 0U;
			}
			set
			{
				this._total_donate_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_donate_countSpecified
		{
			get
			{
				return this._total_donate_count != null;
			}
			set
			{
				bool flag = value == (this._total_donate_count == null);
				if (flag)
				{
					this._total_donate_count = (value ? new uint?(this.total_donate_count) : null);
				}
			}
		}

		private bool ShouldSerializetotal_donate_count()
		{
			return this.total_donate_countSpecified;
		}

		private void Resettotal_donate_count()
		{
			this.total_donate_countSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "dailyaccept", DataFormat = DataFormat.Default)]
		public bool dailyaccept
		{
			get
			{
				return this._dailyaccept ?? false;
			}
			set
			{
				this._dailyaccept = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dailyacceptSpecified
		{
			get
			{
				return this._dailyaccept != null;
			}
			set
			{
				bool flag = value == (this._dailyaccept == null);
				if (flag)
				{
					this._dailyaccept = (value ? new bool?(this.dailyaccept) : null);
				}
			}
		}

		private bool ShouldSerializedailyaccept()
		{
			return this.dailyacceptSpecified;
		}

		private void Resetdailyaccept()
		{
			this.dailyacceptSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "weekrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeeklyTaskData weekrecord
		{
			get
			{
				return this._weekrecord;
			}
			set
			{
				this._weekrecord = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(16, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TaskInfo> _tasks = new List<TaskInfo>();

		private readonly List<uint> _finished = new List<uint>();

		private uint? _lastUpdateTime;

		private readonly List<DailyTaskInfo> _dailytask = new List<DailyTaskInfo>();

		private uint? _daily_count;

		private uint? _daily_accept_level;

		private bool? _daily_rewarded;

		private uint? _daily_complete_num;

		private bool? _daily_red_point;

		private uint? _daily_askhelp_num;

		private uint? _today_donate_count;

		private uint? _total_donate_count;

		private bool? _dailyaccept;

		private WeeklyTaskData _weekrecord = null;

		private uint? _score;

		private uint? _luck;

		private IExtension extensionObject;
	}
}
