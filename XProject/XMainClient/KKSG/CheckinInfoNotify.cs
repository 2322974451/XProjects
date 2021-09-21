using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000046 RID: 70
	[ProtoContract(Name = "CheckinInfoNotify")]
	[Serializable]
	public class CheckinInfoNotify : IExtensible
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0000BD68 File Offset: 0x00009F68
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x0000BD94 File Offset: 0x00009F94
		[ProtoMember(1, IsRequired = false, Name = "DayCheckInfo", DataFormat = DataFormat.TwosComplement)]
		public uint DayCheckInfo
		{
			get
			{
				return this._DayCheckInfo ?? 0U;
			}
			set
			{
				this._DayCheckInfo = new uint?(value);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0000BDA4 File Offset: 0x00009FA4
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0000BDC4 File Offset: 0x00009FC4
		[XmlIgnore]
		[Browsable(false)]
		public bool DayCheckInfoSpecified
		{
			get
			{
				return this._DayCheckInfo != null;
			}
			set
			{
				bool flag = value == (this._DayCheckInfo == null);
				if (flag)
				{
					this._DayCheckInfo = (value ? new uint?(this.DayCheckInfo) : null);
				}
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000BE08 File Offset: 0x0000A008
		private bool ShouldSerializeDayCheckInfo()
		{
			return this.DayCheckInfoSpecified;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000BE20 File Offset: 0x0000A020
		private void ResetDayCheckInfo()
		{
			this.DayCheckInfoSpecified = false;
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x0000BE2C File Offset: 0x0000A02C
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x0000BE58 File Offset: 0x0000A058
		[ProtoMember(2, IsRequired = false, Name = "DayCanCheck", DataFormat = DataFormat.TwosComplement)]
		public uint DayCanCheck
		{
			get
			{
				return this._DayCanCheck ?? 0U;
			}
			set
			{
				this._DayCanCheck = new uint?(value);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0000BE68 File Offset: 0x0000A068
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0000BE88 File Offset: 0x0000A088
		[XmlIgnore]
		[Browsable(false)]
		public bool DayCanCheckSpecified
		{
			get
			{
				return this._DayCanCheck != null;
			}
			set
			{
				bool flag = value == (this._DayCanCheck == null);
				if (flag)
				{
					this._DayCanCheck = (value ? new uint?(this.DayCanCheck) : null);
				}
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000BECC File Offset: 0x0000A0CC
		private bool ShouldSerializeDayCanCheck()
		{
			return this.DayCanCheckSpecified;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000BEE4 File Offset: 0x0000A0E4
		private void ResetDayCanCheck()
		{
			this.DayCanCheckSpecified = false;
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0000BF1C File Offset: 0x0000A11C
		[ProtoMember(3, IsRequired = false, Name = "DayMakeUp", DataFormat = DataFormat.TwosComplement)]
		public uint DayMakeUp
		{
			get
			{
				return this._DayMakeUp ?? 0U;
			}
			set
			{
				this._DayMakeUp = new uint?(value);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000BF2C File Offset: 0x0000A12C
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0000BF4C File Offset: 0x0000A14C
		[XmlIgnore]
		[Browsable(false)]
		public bool DayMakeUpSpecified
		{
			get
			{
				return this._DayMakeUp != null;
			}
			set
			{
				bool flag = value == (this._DayMakeUp == null);
				if (flag)
				{
					this._DayMakeUp = (value ? new uint?(this.DayMakeUp) : null);
				}
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000BF90 File Offset: 0x0000A190
		private bool ShouldSerializeDayMakeUp()
		{
			return this.DayMakeUpSpecified;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000BFA8 File Offset: 0x0000A1A8
		private void ResetDayMakeUp()
		{
			this.DayMakeUpSpecified = false;
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000BFB4 File Offset: 0x0000A1B4
		[ProtoMember(4, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemId
		{
			get
			{
				return this._ItemId;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000BFCC File Offset: 0x0000A1CC
		[ProtoMember(5, Name = "ItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000BFE4 File Offset: 0x0000A1E4
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0000C010 File Offset: 0x0000A210
		[ProtoMember(6, IsRequired = false, Name = "StartDay", DataFormat = DataFormat.TwosComplement)]
		public uint StartDay
		{
			get
			{
				return this._StartDay ?? 0U;
			}
			set
			{
				this._StartDay = new uint?(value);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000C020 File Offset: 0x0000A220
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0000C040 File Offset: 0x0000A240
		[XmlIgnore]
		[Browsable(false)]
		public bool StartDaySpecified
		{
			get
			{
				return this._StartDay != null;
			}
			set
			{
				bool flag = value == (this._StartDay == null);
				if (flag)
				{
					this._StartDay = (value ? new uint?(this.StartDay) : null);
				}
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000C084 File Offset: 0x0000A284
		private bool ShouldSerializeStartDay()
		{
			return this.StartDaySpecified;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000C09C File Offset: 0x0000A29C
		private void ResetStartDay()
		{
			this.StartDaySpecified = false;
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x0000C0A8 File Offset: 0x0000A2A8
		// (set) Token: 0x060004E0 RID: 1248 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
		[ProtoMember(7, IsRequired = false, Name = "IsOddMonth", DataFormat = DataFormat.Default)]
		public bool IsOddMonth
		{
			get
			{
				return this._IsOddMonth ?? false;
			}
			set
			{
				this._IsOddMonth = new bool?(value);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000C0E4 File Offset: 0x0000A2E4
		// (set) Token: 0x060004E2 RID: 1250 RVA: 0x0000C104 File Offset: 0x0000A304
		[XmlIgnore]
		[Browsable(false)]
		public bool IsOddMonthSpecified
		{
			get
			{
				return this._IsOddMonth != null;
			}
			set
			{
				bool flag = value == (this._IsOddMonth == null);
				if (flag)
				{
					this._IsOddMonth = (value ? new bool?(this.IsOddMonth) : null);
				}
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000C148 File Offset: 0x0000A348
		private bool ShouldSerializeIsOddMonth()
		{
			return this.IsOddMonthSpecified;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0000C160 File Offset: 0x0000A360
		private void ResetIsOddMonth()
		{
			this.IsOddMonthSpecified = false;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0000C16C File Offset: 0x0000A36C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400013A RID: 314
		private uint? _DayCheckInfo;

		// Token: 0x0400013B RID: 315
		private uint? _DayCanCheck;

		// Token: 0x0400013C RID: 316
		private uint? _DayMakeUp;

		// Token: 0x0400013D RID: 317
		private readonly List<uint> _ItemId = new List<uint>();

		// Token: 0x0400013E RID: 318
		private readonly List<uint> _ItemCount = new List<uint>();

		// Token: 0x0400013F RID: 319
		private uint? _StartDay;

		// Token: 0x04000140 RID: 320
		private bool? _IsOddMonth;

		// Token: 0x04000141 RID: 321
		private IExtension extensionObject;
	}
}
