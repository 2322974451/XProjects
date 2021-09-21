using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000045 RID: 69
	[ProtoContract(Name = "CheckinRes")]
	[Serializable]
	public class CheckinRes : IExtensible
	{
		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000B890 File Offset: 0x00009A90
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000B8BC File Offset: 0x00009ABC
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000B8CC File Offset: 0x00009ACC
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000B8EC File Offset: 0x00009AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000B930 File Offset: 0x00009B30
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000B948 File Offset: 0x00009B48
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000B954 File Offset: 0x00009B54
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000B980 File Offset: 0x00009B80
		[ProtoMember(2, IsRequired = false, Name = "DayCheckInfo", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000B990 File Offset: 0x00009B90
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x0000B9B0 File Offset: 0x00009BB0
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

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000B9F4 File Offset: 0x00009BF4
		private bool ShouldSerializeDayCheckInfo()
		{
			return this.DayCheckInfoSpecified;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000BA0C File Offset: 0x00009C0C
		private void ResetDayCheckInfo()
		{
			this.DayCheckInfoSpecified = false;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000BA18 File Offset: 0x00009C18
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0000BA44 File Offset: 0x00009C44
		[ProtoMember(3, IsRequired = false, Name = "DayCanCheck", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000BA54 File Offset: 0x00009C54
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x0000BA74 File Offset: 0x00009C74
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

		// Token: 0x060004AF RID: 1199 RVA: 0x0000BAB8 File Offset: 0x00009CB8
		private bool ShouldSerializeDayCanCheck()
		{
			return this.DayCanCheckSpecified;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		private void ResetDayCanCheck()
		{
			this.DayCanCheckSpecified = false;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000BADC File Offset: 0x00009CDC
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000BB08 File Offset: 0x00009D08
		[ProtoMember(4, IsRequired = false, Name = "DayMakeUp", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000BB18 File Offset: 0x00009D18
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000BB38 File Offset: 0x00009D38
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

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000BB7C File Offset: 0x00009D7C
		private bool ShouldSerializeDayMakeUp()
		{
			return this.DayMakeUpSpecified;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000BB94 File Offset: 0x00009D94
		private void ResetDayMakeUp()
		{
			this.DayMakeUpSpecified = false;
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x0000BBCC File Offset: 0x00009DCC
		[ProtoMember(5, IsRequired = false, Name = "Bonus", DataFormat = DataFormat.TwosComplement)]
		public uint Bonus
		{
			get
			{
				return this._Bonus ?? 0U;
			}
			set
			{
				this._Bonus = new uint?(value);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x0000BBDC File Offset: 0x00009DDC
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x0000BBFC File Offset: 0x00009DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool BonusSpecified
		{
			get
			{
				return this._Bonus != null;
			}
			set
			{
				bool flag = value == (this._Bonus == null);
				if (flag)
				{
					this._Bonus = (value ? new uint?(this.Bonus) : null);
				}
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000BC40 File Offset: 0x00009E40
		private bool ShouldSerializeBonus()
		{
			return this.BonusSpecified;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000BC58 File Offset: 0x00009E58
		private void ResetBonus()
		{
			this.BonusSpecified = false;
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000BC64 File Offset: 0x00009E64
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x0000BC90 File Offset: 0x00009E90
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

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x0000BCA0 File Offset: 0x00009EA0
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x0000BCC0 File Offset: 0x00009EC0
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

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000BD04 File Offset: 0x00009F04
		private bool ShouldSerializeStartDay()
		{
			return this.StartDaySpecified;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000BD1C File Offset: 0x00009F1C
		private void ResetStartDay()
		{
			this.StartDaySpecified = false;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000BD28 File Offset: 0x00009F28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000133 RID: 307
		private ErrorCode? _ErrorCode;

		// Token: 0x04000134 RID: 308
		private uint? _DayCheckInfo;

		// Token: 0x04000135 RID: 309
		private uint? _DayCanCheck;

		// Token: 0x04000136 RID: 310
		private uint? _DayMakeUp;

		// Token: 0x04000137 RID: 311
		private uint? _Bonus;

		// Token: 0x04000138 RID: 312
		private uint? _StartDay;

		// Token: 0x04000139 RID: 313
		private IExtension extensionObject;
	}
}
