using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000638 RID: 1592
	[ProtoContract(Name = "RoleTask")]
	[Serializable]
	public class RoleTask : IExtensible
	{
		// Token: 0x17001EDB RID: 7899
		// (get) Token: 0x06006202 RID: 25090 RVA: 0x000BAFDC File Offset: 0x000B91DC
		[ProtoMember(1, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<TaskInfo> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		// Token: 0x17001EDC RID: 7900
		// (get) Token: 0x06006203 RID: 25091 RVA: 0x000BAFF4 File Offset: 0x000B91F4
		[ProtoMember(2, Name = "finished", DataFormat = DataFormat.TwosComplement)]
		public List<uint> finished
		{
			get
			{
				return this._finished;
			}
		}

		// Token: 0x17001EDD RID: 7901
		// (get) Token: 0x06006204 RID: 25092 RVA: 0x000BB00C File Offset: 0x000B920C
		// (set) Token: 0x06006205 RID: 25093 RVA: 0x000BB038 File Offset: 0x000B9238
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

		// Token: 0x17001EDE RID: 7902
		// (get) Token: 0x06006206 RID: 25094 RVA: 0x000BB048 File Offset: 0x000B9248
		// (set) Token: 0x06006207 RID: 25095 RVA: 0x000BB068 File Offset: 0x000B9268
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

		// Token: 0x06006208 RID: 25096 RVA: 0x000BB0AC File Offset: 0x000B92AC
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x06006209 RID: 25097 RVA: 0x000BB0C4 File Offset: 0x000B92C4
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001EDF RID: 7903
		// (get) Token: 0x0600620A RID: 25098 RVA: 0x000BB0D0 File Offset: 0x000B92D0
		[ProtoMember(4, Name = "dailytask", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> dailytask
		{
			get
			{
				return this._dailytask;
			}
		}

		// Token: 0x17001EE0 RID: 7904
		// (get) Token: 0x0600620B RID: 25099 RVA: 0x000BB0E8 File Offset: 0x000B92E8
		// (set) Token: 0x0600620C RID: 25100 RVA: 0x000BB114 File Offset: 0x000B9314
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

		// Token: 0x17001EE1 RID: 7905
		// (get) Token: 0x0600620D RID: 25101 RVA: 0x000BB124 File Offset: 0x000B9324
		// (set) Token: 0x0600620E RID: 25102 RVA: 0x000BB144 File Offset: 0x000B9344
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

		// Token: 0x0600620F RID: 25103 RVA: 0x000BB188 File Offset: 0x000B9388
		private bool ShouldSerializedaily_count()
		{
			return this.daily_countSpecified;
		}

		// Token: 0x06006210 RID: 25104 RVA: 0x000BB1A0 File Offset: 0x000B93A0
		private void Resetdaily_count()
		{
			this.daily_countSpecified = false;
		}

		// Token: 0x17001EE2 RID: 7906
		// (get) Token: 0x06006211 RID: 25105 RVA: 0x000BB1AC File Offset: 0x000B93AC
		// (set) Token: 0x06006212 RID: 25106 RVA: 0x000BB1D8 File Offset: 0x000B93D8
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

		// Token: 0x17001EE3 RID: 7907
		// (get) Token: 0x06006213 RID: 25107 RVA: 0x000BB1E8 File Offset: 0x000B93E8
		// (set) Token: 0x06006214 RID: 25108 RVA: 0x000BB208 File Offset: 0x000B9408
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

		// Token: 0x06006215 RID: 25109 RVA: 0x000BB24C File Offset: 0x000B944C
		private bool ShouldSerializedaily_accept_level()
		{
			return this.daily_accept_levelSpecified;
		}

		// Token: 0x06006216 RID: 25110 RVA: 0x000BB264 File Offset: 0x000B9464
		private void Resetdaily_accept_level()
		{
			this.daily_accept_levelSpecified = false;
		}

		// Token: 0x17001EE4 RID: 7908
		// (get) Token: 0x06006217 RID: 25111 RVA: 0x000BB270 File Offset: 0x000B9470
		// (set) Token: 0x06006218 RID: 25112 RVA: 0x000BB29C File Offset: 0x000B949C
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

		// Token: 0x17001EE5 RID: 7909
		// (get) Token: 0x06006219 RID: 25113 RVA: 0x000BB2AC File Offset: 0x000B94AC
		// (set) Token: 0x0600621A RID: 25114 RVA: 0x000BB2CC File Offset: 0x000B94CC
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

		// Token: 0x0600621B RID: 25115 RVA: 0x000BB310 File Offset: 0x000B9510
		private bool ShouldSerializedaily_rewarded()
		{
			return this.daily_rewardedSpecified;
		}

		// Token: 0x0600621C RID: 25116 RVA: 0x000BB328 File Offset: 0x000B9528
		private void Resetdaily_rewarded()
		{
			this.daily_rewardedSpecified = false;
		}

		// Token: 0x17001EE6 RID: 7910
		// (get) Token: 0x0600621D RID: 25117 RVA: 0x000BB334 File Offset: 0x000B9534
		// (set) Token: 0x0600621E RID: 25118 RVA: 0x000BB360 File Offset: 0x000B9560
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

		// Token: 0x17001EE7 RID: 7911
		// (get) Token: 0x0600621F RID: 25119 RVA: 0x000BB370 File Offset: 0x000B9570
		// (set) Token: 0x06006220 RID: 25120 RVA: 0x000BB390 File Offset: 0x000B9590
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

		// Token: 0x06006221 RID: 25121 RVA: 0x000BB3D4 File Offset: 0x000B95D4
		private bool ShouldSerializedaily_complete_num()
		{
			return this.daily_complete_numSpecified;
		}

		// Token: 0x06006222 RID: 25122 RVA: 0x000BB3EC File Offset: 0x000B95EC
		private void Resetdaily_complete_num()
		{
			this.daily_complete_numSpecified = false;
		}

		// Token: 0x17001EE8 RID: 7912
		// (get) Token: 0x06006223 RID: 25123 RVA: 0x000BB3F8 File Offset: 0x000B95F8
		// (set) Token: 0x06006224 RID: 25124 RVA: 0x000BB424 File Offset: 0x000B9624
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

		// Token: 0x17001EE9 RID: 7913
		// (get) Token: 0x06006225 RID: 25125 RVA: 0x000BB434 File Offset: 0x000B9634
		// (set) Token: 0x06006226 RID: 25126 RVA: 0x000BB454 File Offset: 0x000B9654
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

		// Token: 0x06006227 RID: 25127 RVA: 0x000BB498 File Offset: 0x000B9698
		private bool ShouldSerializedaily_red_point()
		{
			return this.daily_red_pointSpecified;
		}

		// Token: 0x06006228 RID: 25128 RVA: 0x000BB4B0 File Offset: 0x000B96B0
		private void Resetdaily_red_point()
		{
			this.daily_red_pointSpecified = false;
		}

		// Token: 0x17001EEA RID: 7914
		// (get) Token: 0x06006229 RID: 25129 RVA: 0x000BB4BC File Offset: 0x000B96BC
		// (set) Token: 0x0600622A RID: 25130 RVA: 0x000BB4E8 File Offset: 0x000B96E8
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

		// Token: 0x17001EEB RID: 7915
		// (get) Token: 0x0600622B RID: 25131 RVA: 0x000BB4F8 File Offset: 0x000B96F8
		// (set) Token: 0x0600622C RID: 25132 RVA: 0x000BB518 File Offset: 0x000B9718
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

		// Token: 0x0600622D RID: 25133 RVA: 0x000BB55C File Offset: 0x000B975C
		private bool ShouldSerializedaily_askhelp_num()
		{
			return this.daily_askhelp_numSpecified;
		}

		// Token: 0x0600622E RID: 25134 RVA: 0x000BB574 File Offset: 0x000B9774
		private void Resetdaily_askhelp_num()
		{
			this.daily_askhelp_numSpecified = false;
		}

		// Token: 0x17001EEC RID: 7916
		// (get) Token: 0x0600622F RID: 25135 RVA: 0x000BB580 File Offset: 0x000B9780
		// (set) Token: 0x06006230 RID: 25136 RVA: 0x000BB5AC File Offset: 0x000B97AC
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

		// Token: 0x17001EED RID: 7917
		// (get) Token: 0x06006231 RID: 25137 RVA: 0x000BB5BC File Offset: 0x000B97BC
		// (set) Token: 0x06006232 RID: 25138 RVA: 0x000BB5DC File Offset: 0x000B97DC
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

		// Token: 0x06006233 RID: 25139 RVA: 0x000BB620 File Offset: 0x000B9820
		private bool ShouldSerializetoday_donate_count()
		{
			return this.today_donate_countSpecified;
		}

		// Token: 0x06006234 RID: 25140 RVA: 0x000BB638 File Offset: 0x000B9838
		private void Resettoday_donate_count()
		{
			this.today_donate_countSpecified = false;
		}

		// Token: 0x17001EEE RID: 7918
		// (get) Token: 0x06006235 RID: 25141 RVA: 0x000BB644 File Offset: 0x000B9844
		// (set) Token: 0x06006236 RID: 25142 RVA: 0x000BB670 File Offset: 0x000B9870
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

		// Token: 0x17001EEF RID: 7919
		// (get) Token: 0x06006237 RID: 25143 RVA: 0x000BB680 File Offset: 0x000B9880
		// (set) Token: 0x06006238 RID: 25144 RVA: 0x000BB6A0 File Offset: 0x000B98A0
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

		// Token: 0x06006239 RID: 25145 RVA: 0x000BB6E4 File Offset: 0x000B98E4
		private bool ShouldSerializetotal_donate_count()
		{
			return this.total_donate_countSpecified;
		}

		// Token: 0x0600623A RID: 25146 RVA: 0x000BB6FC File Offset: 0x000B98FC
		private void Resettotal_donate_count()
		{
			this.total_donate_countSpecified = false;
		}

		// Token: 0x17001EF0 RID: 7920
		// (get) Token: 0x0600623B RID: 25147 RVA: 0x000BB708 File Offset: 0x000B9908
		// (set) Token: 0x0600623C RID: 25148 RVA: 0x000BB734 File Offset: 0x000B9934
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

		// Token: 0x17001EF1 RID: 7921
		// (get) Token: 0x0600623D RID: 25149 RVA: 0x000BB744 File Offset: 0x000B9944
		// (set) Token: 0x0600623E RID: 25150 RVA: 0x000BB764 File Offset: 0x000B9964
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

		// Token: 0x0600623F RID: 25151 RVA: 0x000BB7A8 File Offset: 0x000B99A8
		private bool ShouldSerializedailyaccept()
		{
			return this.dailyacceptSpecified;
		}

		// Token: 0x06006240 RID: 25152 RVA: 0x000BB7C0 File Offset: 0x000B99C0
		private void Resetdailyaccept()
		{
			this.dailyacceptSpecified = false;
		}

		// Token: 0x17001EF2 RID: 7922
		// (get) Token: 0x06006241 RID: 25153 RVA: 0x000BB7CC File Offset: 0x000B99CC
		// (set) Token: 0x06006242 RID: 25154 RVA: 0x000BB7E4 File Offset: 0x000B99E4
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

		// Token: 0x17001EF3 RID: 7923
		// (get) Token: 0x06006243 RID: 25155 RVA: 0x000BB7F0 File Offset: 0x000B99F0
		// (set) Token: 0x06006244 RID: 25156 RVA: 0x000BB81C File Offset: 0x000B9A1C
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

		// Token: 0x17001EF4 RID: 7924
		// (get) Token: 0x06006245 RID: 25157 RVA: 0x000BB82C File Offset: 0x000B9A2C
		// (set) Token: 0x06006246 RID: 25158 RVA: 0x000BB84C File Offset: 0x000B9A4C
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

		// Token: 0x06006247 RID: 25159 RVA: 0x000BB890 File Offset: 0x000B9A90
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06006248 RID: 25160 RVA: 0x000BB8A8 File Offset: 0x000B9AA8
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001EF5 RID: 7925
		// (get) Token: 0x06006249 RID: 25161 RVA: 0x000BB8B4 File Offset: 0x000B9AB4
		// (set) Token: 0x0600624A RID: 25162 RVA: 0x000BB8E0 File Offset: 0x000B9AE0
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

		// Token: 0x17001EF6 RID: 7926
		// (get) Token: 0x0600624B RID: 25163 RVA: 0x000BB8F0 File Offset: 0x000B9AF0
		// (set) Token: 0x0600624C RID: 25164 RVA: 0x000BB910 File Offset: 0x000B9B10
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

		// Token: 0x0600624D RID: 25165 RVA: 0x000BB954 File Offset: 0x000B9B54
		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		// Token: 0x0600624E RID: 25166 RVA: 0x000BB96C File Offset: 0x000B9B6C
		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		// Token: 0x0600624F RID: 25167 RVA: 0x000BB978 File Offset: 0x000B9B78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017C8 RID: 6088
		private readonly List<TaskInfo> _tasks = new List<TaskInfo>();

		// Token: 0x040017C9 RID: 6089
		private readonly List<uint> _finished = new List<uint>();

		// Token: 0x040017CA RID: 6090
		private uint? _lastUpdateTime;

		// Token: 0x040017CB RID: 6091
		private readonly List<DailyTaskInfo> _dailytask = new List<DailyTaskInfo>();

		// Token: 0x040017CC RID: 6092
		private uint? _daily_count;

		// Token: 0x040017CD RID: 6093
		private uint? _daily_accept_level;

		// Token: 0x040017CE RID: 6094
		private bool? _daily_rewarded;

		// Token: 0x040017CF RID: 6095
		private uint? _daily_complete_num;

		// Token: 0x040017D0 RID: 6096
		private bool? _daily_red_point;

		// Token: 0x040017D1 RID: 6097
		private uint? _daily_askhelp_num;

		// Token: 0x040017D2 RID: 6098
		private uint? _today_donate_count;

		// Token: 0x040017D3 RID: 6099
		private uint? _total_donate_count;

		// Token: 0x040017D4 RID: 6100
		private bool? _dailyaccept;

		// Token: 0x040017D5 RID: 6101
		private WeeklyTaskData _weekrecord = null;

		// Token: 0x040017D6 RID: 6102
		private uint? _score;

		// Token: 0x040017D7 RID: 6103
		private uint? _luck;

		// Token: 0x040017D8 RID: 6104
		private IExtension extensionObject;
	}
}
