using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000050 RID: 80
	[ProtoContract(Name = "PayInfo")]
	[Serializable]
	public class PayInfo : IExtensible
	{
		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000CDCC File Offset: 0x0000AFCC
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000CDF9 File Offset: 0x0000AFF9
		[ProtoMember(1, IsRequired = false, Name = "TotalPay", DataFormat = DataFormat.TwosComplement)]
		public ulong TotalPay
		{
			get
			{
				return this._TotalPay ?? 0UL;
			}
			set
			{
				this._TotalPay = new ulong?(value);
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000CE08 File Offset: 0x0000B008
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000CE28 File Offset: 0x0000B028
		[XmlIgnore]
		[Browsable(false)]
		public bool TotalPaySpecified
		{
			get
			{
				return this._TotalPay != null;
			}
			set
			{
				bool flag = value == (this._TotalPay == null);
				if (flag)
				{
					this._TotalPay = (value ? new ulong?(this.TotalPay) : null);
				}
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0000CE6C File Offset: 0x0000B06C
		private bool ShouldSerializeTotalPay()
		{
			return this.TotalPaySpecified;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0000CE84 File Offset: 0x0000B084
		private void ResetTotalPay()
		{
			this.TotalPaySpecified = false;
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0000CE90 File Offset: 0x0000B090
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x0000CEBC File Offset: 0x0000B0BC
		[ProtoMember(2, IsRequired = false, Name = "PayIDFlag", DataFormat = DataFormat.TwosComplement)]
		public uint PayIDFlag
		{
			get
			{
				return this._PayIDFlag ?? 0U;
			}
			set
			{
				this._PayIDFlag = new uint?(value);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0000CECC File Offset: 0x0000B0CC
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		[XmlIgnore]
		[Browsable(false)]
		public bool PayIDFlagSpecified
		{
			get
			{
				return this._PayIDFlag != null;
			}
			set
			{
				bool flag = value == (this._PayIDFlag == null);
				if (flag)
				{
					this._PayIDFlag = (value ? new uint?(this.PayIDFlag) : null);
				}
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000CF30 File Offset: 0x0000B130
		private bool ShouldSerializePayIDFlag()
		{
			return this.PayIDFlagSpecified;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000CF48 File Offset: 0x0000B148
		private void ResetPayIDFlag()
		{
			this.PayIDFlagSpecified = false;
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000CF54 File Offset: 0x0000B154
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x0000CF80 File Offset: 0x0000B180
		[ProtoMember(3, IsRequired = false, Name = "MonthCardLeftDay", DataFormat = DataFormat.TwosComplement)]
		public uint MonthCardLeftDay
		{
			get
			{
				return this._MonthCardLeftDay ?? 0U;
			}
			set
			{
				this._MonthCardLeftDay = new uint?(value);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0000CF90 File Offset: 0x0000B190
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x0000CFB0 File Offset: 0x0000B1B0
		[XmlIgnore]
		[Browsable(false)]
		public bool MonthCardLeftDaySpecified
		{
			get
			{
				return this._MonthCardLeftDay != null;
			}
			set
			{
				bool flag = value == (this._MonthCardLeftDay == null);
				if (flag)
				{
					this._MonthCardLeftDay = (value ? new uint?(this.MonthCardLeftDay) : null);
				}
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000CFF4 File Offset: 0x0000B1F4
		private bool ShouldSerializeMonthCardLeftDay()
		{
			return this.MonthCardLeftDaySpecified;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0000D00C File Offset: 0x0000B20C
		private void ResetMonthCardLeftDay()
		{
			this.MonthCardLeftDaySpecified = false;
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0000D018 File Offset: 0x0000B218
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x0000D044 File Offset: 0x0000B244
		[ProtoMember(4, IsRequired = false, Name = "LastMonthCardTimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint LastMonthCardTimeStamp
		{
			get
			{
				return this._LastMonthCardTimeStamp ?? 0U;
			}
			set
			{
				this._LastMonthCardTimeStamp = new uint?(value);
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0000D054 File Offset: 0x0000B254
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0000D074 File Offset: 0x0000B274
		[XmlIgnore]
		[Browsable(false)]
		public bool LastMonthCardTimeStampSpecified
		{
			get
			{
				return this._LastMonthCardTimeStamp != null;
			}
			set
			{
				bool flag = value == (this._LastMonthCardTimeStamp == null);
				if (flag)
				{
					this._LastMonthCardTimeStamp = (value ? new uint?(this.LastMonthCardTimeStamp) : null);
				}
			}
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000D0B8 File Offset: 0x0000B2B8
		private bool ShouldSerializeLastMonthCardTimeStamp()
		{
			return this.LastMonthCardTimeStampSpecified;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0000D0D0 File Offset: 0x0000B2D0
		private void ResetLastMonthCardTimeStamp()
		{
			this.LastMonthCardTimeStampSpecified = false;
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x0000D108 File Offset: 0x0000B308
		[ProtoMember(5, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public uint vipLevel
		{
			get
			{
				return this._vipLevel ?? 0U;
			}
			set
			{
				this._vipLevel = new uint?(value);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x0000D118 File Offset: 0x0000B318
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x0000D138 File Offset: 0x0000B338
		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new uint?(this.vipLevel) : null);
				}
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0000D17C File Offset: 0x0000B37C
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0000D194 File Offset: 0x0000B394
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000D1A0 File Offset: 0x0000B3A0
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x0000D1CC File Offset: 0x0000B3CC
		[ProtoMember(6, IsRequired = false, Name = "vippoint", DataFormat = DataFormat.TwosComplement)]
		public uint vippoint
		{
			get
			{
				return this._vippoint ?? 0U;
			}
			set
			{
				this._vippoint = new uint?(value);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x0000D1FC File Offset: 0x0000B3FC
		[XmlIgnore]
		[Browsable(false)]
		public bool vippointSpecified
		{
			get
			{
				return this._vippoint != null;
			}
			set
			{
				bool flag = value == (this._vippoint == null);
				if (flag)
				{
					this._vippoint = (value ? new uint?(this.vippoint) : null);
				}
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000D240 File Offset: 0x0000B440
		private bool ShouldSerializevippoint()
		{
			return this.vippointSpecified;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000D258 File Offset: 0x0000B458
		private void Resetvippoint()
		{
			this.vippointSpecified = false;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000D264 File Offset: 0x0000B464
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400015D RID: 349
		private ulong? _TotalPay;

		// Token: 0x0400015E RID: 350
		private uint? _PayIDFlag;

		// Token: 0x0400015F RID: 351
		private uint? _MonthCardLeftDay;

		// Token: 0x04000160 RID: 352
		private uint? _LastMonthCardTimeStamp;

		// Token: 0x04000161 RID: 353
		private uint? _vipLevel;

		// Token: 0x04000162 RID: 354
		private uint? _vippoint;

		// Token: 0x04000163 RID: 355
		private IExtension extensionObject;
	}
}
