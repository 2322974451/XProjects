using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005ED RID: 1517
	[ProtoContract(Name = "StageInfo")]
	[Serializable]
	public class StageInfo : IExtensible
	{
		// Token: 0x17001C09 RID: 7177
		// (get) Token: 0x060059D1 RID: 22993 RVA: 0x000AAFC4 File Offset: 0x000A91C4
		[ProtoMember(1, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public List<int> sceneID
		{
			get
			{
				return this._sceneID;
			}
		}

		// Token: 0x17001C0A RID: 7178
		// (get) Token: 0x060059D2 RID: 22994 RVA: 0x000AAFDC File Offset: 0x000A91DC
		[ProtoMember(2, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public List<int> rank
		{
			get
			{
				return this._rank;
			}
		}

		// Token: 0x17001C0B RID: 7179
		// (get) Token: 0x060059D3 RID: 22995 RVA: 0x000AAFF4 File Offset: 0x000A91F4
		[ProtoMember(3, Name = "countscenegroupid", DataFormat = DataFormat.TwosComplement)]
		public List<int> countscenegroupid
		{
			get
			{
				return this._countscenegroupid;
			}
		}

		// Token: 0x17001C0C RID: 7180
		// (get) Token: 0x060059D4 RID: 22996 RVA: 0x000AB00C File Offset: 0x000A920C
		[ProtoMember(4, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<int> count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17001C0D RID: 7181
		// (get) Token: 0x060059D5 RID: 22997 RVA: 0x000AB024 File Offset: 0x000A9224
		// (set) Token: 0x060059D6 RID: 22998 RVA: 0x000AB050 File Offset: 0x000A9250
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

		// Token: 0x17001C0E RID: 7182
		// (get) Token: 0x060059D7 RID: 22999 RVA: 0x000AB060 File Offset: 0x000A9260
		// (set) Token: 0x060059D8 RID: 23000 RVA: 0x000AB080 File Offset: 0x000A9280
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

		// Token: 0x060059D9 RID: 23001 RVA: 0x000AB0C4 File Offset: 0x000A92C4
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x060059DA RID: 23002 RVA: 0x000AB0DC File Offset: 0x000A92DC
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x17001C0F RID: 7183
		// (get) Token: 0x060059DB RID: 23003 RVA: 0x000AB0E8 File Offset: 0x000A92E8
		[ProtoMember(6, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public List<int> buycount
		{
			get
			{
				return this._buycount;
			}
		}

		// Token: 0x17001C10 RID: 7184
		// (get) Token: 0x060059DC RID: 23004 RVA: 0x000AB100 File Offset: 0x000A9300
		[ProtoMember(7, Name = "cdscenegroupid", DataFormat = DataFormat.TwosComplement)]
		public List<int> cdscenegroupid
		{
			get
			{
				return this._cdscenegroupid;
			}
		}

		// Token: 0x17001C11 RID: 7185
		// (get) Token: 0x060059DD RID: 23005 RVA: 0x000AB118 File Offset: 0x000A9318
		[ProtoMember(8, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public List<int> cooldown
		{
			get
			{
				return this._cooldown;
			}
		}

		// Token: 0x17001C12 RID: 7186
		// (get) Token: 0x060059DE RID: 23006 RVA: 0x000AB130 File Offset: 0x000A9330
		[ProtoMember(9, Name = "chapterchest", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chapterchest
		{
			get
			{
				return this._chapterchest;
			}
		}

		// Token: 0x17001C13 RID: 7187
		// (get) Token: 0x060059DF RID: 23007 RVA: 0x000AB148 File Offset: 0x000A9348
		[ProtoMember(10, Name = "chestOpenedScene", DataFormat = DataFormat.TwosComplement)]
		public List<uint> chestOpenedScene
		{
			get
			{
				return this._chestOpenedScene;
			}
		}

		// Token: 0x17001C14 RID: 7188
		// (get) Token: 0x060059E0 RID: 23008 RVA: 0x000AB160 File Offset: 0x000A9360
		// (set) Token: 0x060059E1 RID: 23009 RVA: 0x000AB18C File Offset: 0x000A938C
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

		// Token: 0x17001C15 RID: 7189
		// (get) Token: 0x060059E2 RID: 23010 RVA: 0x000AB19C File Offset: 0x000A939C
		// (set) Token: 0x060059E3 RID: 23011 RVA: 0x000AB1BC File Offset: 0x000A93BC
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

		// Token: 0x060059E4 RID: 23012 RVA: 0x000AB200 File Offset: 0x000A9400
		private bool ShouldSerializehelperwincount()
		{
			return this.helperwincountSpecified;
		}

		// Token: 0x060059E5 RID: 23013 RVA: 0x000AB218 File Offset: 0x000A9418
		private void Resethelperwincount()
		{
			this.helperwincountSpecified = false;
		}

		// Token: 0x17001C16 RID: 7190
		// (get) Token: 0x060059E6 RID: 23014 RVA: 0x000AB224 File Offset: 0x000A9424
		// (set) Token: 0x060059E7 RID: 23015 RVA: 0x000AB250 File Offset: 0x000A9450
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

		// Token: 0x17001C17 RID: 7191
		// (get) Token: 0x060059E8 RID: 23016 RVA: 0x000AB260 File Offset: 0x000A9460
		// (set) Token: 0x060059E9 RID: 23017 RVA: 0x000AB280 File Offset: 0x000A9480
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

		// Token: 0x060059EA RID: 23018 RVA: 0x000AB2C4 File Offset: 0x000A94C4
		private bool ShouldSerializehelperweekwincount()
		{
			return this.helperweekwincountSpecified;
		}

		// Token: 0x060059EB RID: 23019 RVA: 0x000AB2DC File Offset: 0x000A94DC
		private void Resethelperweekwincount()
		{
			this.helperweekwincountSpecified = false;
		}

		// Token: 0x17001C18 RID: 7192
		// (get) Token: 0x060059EC RID: 23020 RVA: 0x000AB2E8 File Offset: 0x000A94E8
		// (set) Token: 0x060059ED RID: 23021 RVA: 0x000AB314 File Offset: 0x000A9514
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

		// Token: 0x17001C19 RID: 7193
		// (get) Token: 0x060059EE RID: 23022 RVA: 0x000AB324 File Offset: 0x000A9524
		// (set) Token: 0x060059EF RID: 23023 RVA: 0x000AB344 File Offset: 0x000A9544
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

		// Token: 0x060059F0 RID: 23024 RVA: 0x000AB388 File Offset: 0x000A9588
		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		// Token: 0x060059F1 RID: 23025 RVA: 0x000AB3A0 File Offset: 0x000A95A0
		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

		// Token: 0x17001C1A RID: 7194
		// (get) Token: 0x060059F2 RID: 23026 RVA: 0x000AB3AC File Offset: 0x000A95AC
		// (set) Token: 0x060059F3 RID: 23027 RVA: 0x000AB3D8 File Offset: 0x000A95D8
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

		// Token: 0x17001C1B RID: 7195
		// (get) Token: 0x060059F4 RID: 23028 RVA: 0x000AB3E8 File Offset: 0x000A95E8
		// (set) Token: 0x060059F5 RID: 23029 RVA: 0x000AB408 File Offset: 0x000A9608
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

		// Token: 0x060059F6 RID: 23030 RVA: 0x000AB44C File Offset: 0x000A964C
		private bool ShouldSerializebossrushmax()
		{
			return this.bossrushmaxSpecified;
		}

		// Token: 0x060059F7 RID: 23031 RVA: 0x000AB464 File Offset: 0x000A9664
		private void Resetbossrushmax()
		{
			this.bossrushmaxSpecified = false;
		}

		// Token: 0x17001C1C RID: 7196
		// (get) Token: 0x060059F8 RID: 23032 RVA: 0x000AB470 File Offset: 0x000A9670
		// (set) Token: 0x060059F9 RID: 23033 RVA: 0x000AB49C File Offset: 0x000A969C
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

		// Token: 0x17001C1D RID: 7197
		// (get) Token: 0x060059FA RID: 23034 RVA: 0x000AB4AC File Offset: 0x000A96AC
		// (set) Token: 0x060059FB RID: 23035 RVA: 0x000AB4CC File Offset: 0x000A96CC
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

		// Token: 0x060059FC RID: 23036 RVA: 0x000AB510 File Offset: 0x000A9710
		private bool ShouldSerializebrupday()
		{
			return this.brupdaySpecified;
		}

		// Token: 0x060059FD RID: 23037 RVA: 0x000AB528 File Offset: 0x000A9728
		private void Resetbrupday()
		{
			this.brupdaySpecified = false;
		}

		// Token: 0x17001C1E RID: 7198
		// (get) Token: 0x060059FE RID: 23038 RVA: 0x000AB534 File Offset: 0x000A9734
		// (set) Token: 0x060059FF RID: 23039 RVA: 0x000AB560 File Offset: 0x000A9760
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

		// Token: 0x17001C1F RID: 7199
		// (get) Token: 0x06005A00 RID: 23040 RVA: 0x000AB570 File Offset: 0x000A9770
		// (set) Token: 0x06005A01 RID: 23041 RVA: 0x000AB590 File Offset: 0x000A9790
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

		// Token: 0x06005A02 RID: 23042 RVA: 0x000AB5D4 File Offset: 0x000A97D4
		private bool ShouldSerializeBRjoincounttoday()
		{
			return this.BRjoincounttodaySpecified;
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x000AB5EC File Offset: 0x000A97EC
		private void ResetBRjoincounttoday()
		{
			this.BRjoincounttodaySpecified = false;
		}

		// Token: 0x17001C20 RID: 7200
		// (get) Token: 0x06005A04 RID: 23044 RVA: 0x000AB5F8 File Offset: 0x000A97F8
		// (set) Token: 0x06005A05 RID: 23045 RVA: 0x000AB624 File Offset: 0x000A9824
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

		// Token: 0x17001C21 RID: 7201
		// (get) Token: 0x06005A06 RID: 23046 RVA: 0x000AB634 File Offset: 0x000A9834
		// (set) Token: 0x06005A07 RID: 23047 RVA: 0x000AB654 File Offset: 0x000A9854
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

		// Token: 0x06005A08 RID: 23048 RVA: 0x000AB698 File Offset: 0x000A9898
		private bool ShouldSerializeBRrefreshcounttoday()
		{
			return this.BRrefreshcounttodaySpecified;
		}

		// Token: 0x06005A09 RID: 23049 RVA: 0x000AB6B0 File Offset: 0x000A98B0
		private void ResetBRrefreshcounttoday()
		{
			this.BRrefreshcounttodaySpecified = false;
		}

		// Token: 0x17001C22 RID: 7202
		// (get) Token: 0x06005A0A RID: 23050 RVA: 0x000AB6BC File Offset: 0x000A98BC
		// (set) Token: 0x06005A0B RID: 23051 RVA: 0x000AB6D4 File Offset: 0x000A98D4
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

		// Token: 0x17001C23 RID: 7203
		// (get) Token: 0x06005A0C RID: 23052 RVA: 0x000AB6E0 File Offset: 0x000A98E0
		[ProtoMember(19, Name = "stageprogress", DataFormat = DataFormat.Default)]
		public List<DEStageProgress> stageprogress
		{
			get
			{
				return this._stageprogress;
			}
		}

		// Token: 0x17001C24 RID: 7204
		// (get) Token: 0x06005A0D RID: 23053 RVA: 0x000AB6F8 File Offset: 0x000A98F8
		[ProtoMember(20, Name = "stageassist", DataFormat = DataFormat.Default)]
		public List<StageAssistOne> stageassist
		{
			get
			{
				return this._stageassist;
			}
		}

		// Token: 0x17001C25 RID: 7205
		// (get) Token: 0x06005A0E RID: 23054 RVA: 0x000AB710 File Offset: 0x000A9910
		// (set) Token: 0x06005A0F RID: 23055 RVA: 0x000AB73C File Offset: 0x000A993C
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

		// Token: 0x17001C26 RID: 7206
		// (get) Token: 0x06005A10 RID: 23056 RVA: 0x000AB74C File Offset: 0x000A994C
		// (set) Token: 0x06005A11 RID: 23057 RVA: 0x000AB76C File Offset: 0x000A996C
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

		// Token: 0x06005A12 RID: 23058 RVA: 0x000AB7B0 File Offset: 0x000A99B0
		private bool ShouldSerializeholidayid()
		{
			return this.holidayidSpecified;
		}

		// Token: 0x06005A13 RID: 23059 RVA: 0x000AB7C8 File Offset: 0x000A99C8
		private void Resetholidayid()
		{
			this.holidayidSpecified = false;
		}

		// Token: 0x17001C27 RID: 7207
		// (get) Token: 0x06005A14 RID: 23060 RVA: 0x000AB7D4 File Offset: 0x000A99D4
		// (set) Token: 0x06005A15 RID: 23061 RVA: 0x000AB800 File Offset: 0x000A9A00
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

		// Token: 0x17001C28 RID: 7208
		// (get) Token: 0x06005A16 RID: 23062 RVA: 0x000AB810 File Offset: 0x000A9A10
		// (set) Token: 0x06005A17 RID: 23063 RVA: 0x000AB830 File Offset: 0x000A9A30
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

		// Token: 0x06005A18 RID: 23064 RVA: 0x000AB874 File Offset: 0x000A9A74
		private bool ShouldSerializeholidaytimes()
		{
			return this.holidaytimesSpecified;
		}

		// Token: 0x06005A19 RID: 23065 RVA: 0x000AB88C File Offset: 0x000A9A8C
		private void Resetholidaytimes()
		{
			this.holidaytimesSpecified = false;
		}

		// Token: 0x17001C29 RID: 7209
		// (get) Token: 0x06005A1A RID: 23066 RVA: 0x000AB898 File Offset: 0x000A9A98
		// (set) Token: 0x06005A1B RID: 23067 RVA: 0x000AB8B0 File Offset: 0x000A9AB0
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

		// Token: 0x17001C2A RID: 7210
		// (get) Token: 0x06005A1C RID: 23068 RVA: 0x000AB8BC File Offset: 0x000A9ABC
		// (set) Token: 0x06005A1D RID: 23069 RVA: 0x000AB8E8 File Offset: 0x000A9AE8
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

		// Token: 0x17001C2B RID: 7211
		// (get) Token: 0x06005A1E RID: 23070 RVA: 0x000AB8F8 File Offset: 0x000A9AF8
		// (set) Token: 0x06005A1F RID: 23071 RVA: 0x000AB918 File Offset: 0x000A9B18
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

		// Token: 0x06005A20 RID: 23072 RVA: 0x000AB95C File Offset: 0x000A9B5C
		private bool ShouldSerializekidhelpercount()
		{
			return this.kidhelpercountSpecified;
		}

		// Token: 0x06005A21 RID: 23073 RVA: 0x000AB974 File Offset: 0x000A9B74
		private void Resetkidhelpercount()
		{
			this.kidhelpercountSpecified = false;
		}

		// Token: 0x17001C2C RID: 7212
		// (get) Token: 0x06005A22 RID: 23074 RVA: 0x000AB980 File Offset: 0x000A9B80
		// (set) Token: 0x06005A23 RID: 23075 RVA: 0x000AB9AC File Offset: 0x000A9BAC
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

		// Token: 0x17001C2D RID: 7213
		// (get) Token: 0x06005A24 RID: 23076 RVA: 0x000AB9BC File Offset: 0x000A9BBC
		// (set) Token: 0x06005A25 RID: 23077 RVA: 0x000AB9DC File Offset: 0x000A9BDC
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

		// Token: 0x06005A26 RID: 23078 RVA: 0x000ABA20 File Offset: 0x000A9C20
		private bool ShouldSerializetarjatime()
		{
			return this.tarjatimeSpecified;
		}

		// Token: 0x06005A27 RID: 23079 RVA: 0x000ABA38 File Offset: 0x000A9C38
		private void Resettarjatime()
		{
			this.tarjatimeSpecified = false;
		}

		// Token: 0x17001C2E RID: 7214
		// (get) Token: 0x06005A28 RID: 23080 RVA: 0x000ABA44 File Offset: 0x000A9C44
		// (set) Token: 0x06005A29 RID: 23081 RVA: 0x000ABA70 File Offset: 0x000A9C70
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

		// Token: 0x17001C2F RID: 7215
		// (get) Token: 0x06005A2A RID: 23082 RVA: 0x000ABA80 File Offset: 0x000A9C80
		// (set) Token: 0x06005A2B RID: 23083 RVA: 0x000ABAA0 File Offset: 0x000A9CA0
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

		// Token: 0x06005A2C RID: 23084 RVA: 0x000ABAE4 File Offset: 0x000A9CE4
		private bool ShouldSerializetarjaaward()
		{
			return this.tarjaawardSpecified;
		}

		// Token: 0x06005A2D RID: 23085 RVA: 0x000ABAFC File Offset: 0x000A9CFC
		private void Resettarjaaward()
		{
			this.tarjaawardSpecified = false;
		}

		// Token: 0x17001C30 RID: 7216
		// (get) Token: 0x06005A2E RID: 23086 RVA: 0x000ABB08 File Offset: 0x000A9D08
		// (set) Token: 0x06005A2F RID: 23087 RVA: 0x000ABB20 File Offset: 0x000A9D20
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

		// Token: 0x17001C31 RID: 7217
		// (get) Token: 0x06005A30 RID: 23088 RVA: 0x000ABB2C File Offset: 0x000A9D2C
		[ProtoMember(28, Name = "dnes", DataFormat = DataFormat.Default)]
		public List<DneRecord> dnes
		{
			get
			{
				return this._dnes;
			}
		}

		// Token: 0x17001C32 RID: 7218
		// (get) Token: 0x06005A31 RID: 23089 RVA: 0x000ABB44 File Offset: 0x000A9D44
		// (set) Token: 0x06005A32 RID: 23090 RVA: 0x000ABB70 File Offset: 0x000A9D70
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

		// Token: 0x17001C33 RID: 7219
		// (get) Token: 0x06005A33 RID: 23091 RVA: 0x000ABB80 File Offset: 0x000A9D80
		// (set) Token: 0x06005A34 RID: 23092 RVA: 0x000ABBA0 File Offset: 0x000A9DA0
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

		// Token: 0x06005A35 RID: 23093 RVA: 0x000ABBE4 File Offset: 0x000A9DE4
		private bool ShouldSerializedespecialflag()
		{
			return this.despecialflagSpecified;
		}

		// Token: 0x06005A36 RID: 23094 RVA: 0x000ABBFC File Offset: 0x000A9DFC
		private void Resetdespecialflag()
		{
			this.despecialflagSpecified = false;
		}

		// Token: 0x06005A37 RID: 23095 RVA: 0x000ABC08 File Offset: 0x000A9E08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015D7 RID: 5591
		private readonly List<int> _sceneID = new List<int>();

		// Token: 0x040015D8 RID: 5592
		private readonly List<int> _rank = new List<int>();

		// Token: 0x040015D9 RID: 5593
		private readonly List<int> _countscenegroupid = new List<int>();

		// Token: 0x040015DA RID: 5594
		private readonly List<int> _count = new List<int>();

		// Token: 0x040015DB RID: 5595
		private int? _day;

		// Token: 0x040015DC RID: 5596
		private readonly List<int> _buycount = new List<int>();

		// Token: 0x040015DD RID: 5597
		private readonly List<int> _cdscenegroupid = new List<int>();

		// Token: 0x040015DE RID: 5598
		private readonly List<int> _cooldown = new List<int>();

		// Token: 0x040015DF RID: 5599
		private readonly List<uint> _chapterchest = new List<uint>();

		// Token: 0x040015E0 RID: 5600
		private readonly List<uint> _chestOpenedScene = new List<uint>();

		// Token: 0x040015E1 RID: 5601
		private int? _helperwincount;

		// Token: 0x040015E2 RID: 5602
		private int? _helperweekwincount;

		// Token: 0x040015E3 RID: 5603
		private uint? _lastweekuptime;

		// Token: 0x040015E4 RID: 5604
		private uint? _bossrushmax;

		// Token: 0x040015E5 RID: 5605
		private int? _brupday;

		// Token: 0x040015E6 RID: 5606
		private int? _BRjoincounttoday;

		// Token: 0x040015E7 RID: 5607
		private int? _BRrefreshcounttoday;

		// Token: 0x040015E8 RID: 5608
		private BRRankState _brrankstate = null;

		// Token: 0x040015E9 RID: 5609
		private readonly List<DEStageProgress> _stageprogress = new List<DEStageProgress>();

		// Token: 0x040015EA RID: 5610
		private readonly List<StageAssistOne> _stageassist = new List<StageAssistOne>();

		// Token: 0x040015EB RID: 5611
		private uint? _holidayid;

		// Token: 0x040015EC RID: 5612
		private uint? _holidaytimes;

		// Token: 0x040015ED RID: 5613
		private AbsPartyInfo _absparty = null;

		// Token: 0x040015EE RID: 5614
		private uint? _kidhelpercount;

		// Token: 0x040015EF RID: 5615
		private uint? _tarjatime;

		// Token: 0x040015F0 RID: 5616
		private uint? _tarjaaward;

		// Token: 0x040015F1 RID: 5617
		private StageTrophy _trophydata = null;

		// Token: 0x040015F2 RID: 5618
		private readonly List<DneRecord> _dnes = new List<DneRecord>();

		// Token: 0x040015F3 RID: 5619
		private bool? _despecialflag;

		// Token: 0x040015F4 RID: 5620
		private IExtension extensionObject;
	}
}
