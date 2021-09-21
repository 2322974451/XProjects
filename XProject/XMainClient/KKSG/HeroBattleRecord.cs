using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000668 RID: 1640
	[ProtoContract(Name = "HeroBattleRecord")]
	[Serializable]
	public class HeroBattleRecord : IExtensible
	{
		// Token: 0x170020B1 RID: 8369
		// (get) Token: 0x0600677C RID: 26492 RVA: 0x000C5B98 File Offset: 0x000C3D98
		[ProtoMember(1, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		// Token: 0x170020B2 RID: 8370
		// (get) Token: 0x0600677D RID: 26493 RVA: 0x000C5BB0 File Offset: 0x000C3DB0
		// (set) Token: 0x0600677E RID: 26494 RVA: 0x000C5BDC File Offset: 0x000C3DDC
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

		// Token: 0x170020B3 RID: 8371
		// (get) Token: 0x0600677F RID: 26495 RVA: 0x000C5BEC File Offset: 0x000C3DEC
		// (set) Token: 0x06006780 RID: 26496 RVA: 0x000C5C0C File Offset: 0x000C3E0C
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

		// Token: 0x06006781 RID: 26497 RVA: 0x000C5C50 File Offset: 0x000C3E50
		private bool ShouldSerializecangetprize()
		{
			return this.cangetprizeSpecified;
		}

		// Token: 0x06006782 RID: 26498 RVA: 0x000C5C68 File Offset: 0x000C3E68
		private void Resetcangetprize()
		{
			this.cangetprizeSpecified = false;
		}

		// Token: 0x170020B4 RID: 8372
		// (get) Token: 0x06006783 RID: 26499 RVA: 0x000C5C74 File Offset: 0x000C3E74
		// (set) Token: 0x06006784 RID: 26500 RVA: 0x000C5CA0 File Offset: 0x000C3EA0
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

		// Token: 0x170020B5 RID: 8373
		// (get) Token: 0x06006785 RID: 26501 RVA: 0x000C5CB0 File Offset: 0x000C3EB0
		// (set) Token: 0x06006786 RID: 26502 RVA: 0x000C5CD0 File Offset: 0x000C3ED0
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

		// Token: 0x06006787 RID: 26503 RVA: 0x000C5D14 File Offset: 0x000C3F14
		private bool ShouldSerializealreadygetprize()
		{
			return this.alreadygetprizeSpecified;
		}

		// Token: 0x06006788 RID: 26504 RVA: 0x000C5D2C File Offset: 0x000C3F2C
		private void Resetalreadygetprize()
		{
			this.alreadygetprizeSpecified = false;
		}

		// Token: 0x170020B6 RID: 8374
		// (get) Token: 0x06006789 RID: 26505 RVA: 0x000C5D38 File Offset: 0x000C3F38
		// (set) Token: 0x0600678A RID: 26506 RVA: 0x000C5D64 File Offset: 0x000C3F64
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

		// Token: 0x170020B7 RID: 8375
		// (get) Token: 0x0600678B RID: 26507 RVA: 0x000C5D74 File Offset: 0x000C3F74
		// (set) Token: 0x0600678C RID: 26508 RVA: 0x000C5D94 File Offset: 0x000C3F94
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

		// Token: 0x0600678D RID: 26509 RVA: 0x000C5DD8 File Offset: 0x000C3FD8
		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		// Token: 0x0600678E RID: 26510 RVA: 0x000C5DF0 File Offset: 0x000C3FF0
		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		// Token: 0x170020B8 RID: 8376
		// (get) Token: 0x0600678F RID: 26511 RVA: 0x000C5DFC File Offset: 0x000C3FFC
		// (set) Token: 0x06006790 RID: 26512 RVA: 0x000C5E28 File Offset: 0x000C4028
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

		// Token: 0x170020B9 RID: 8377
		// (get) Token: 0x06006791 RID: 26513 RVA: 0x000C5E38 File Offset: 0x000C4038
		// (set) Token: 0x06006792 RID: 26514 RVA: 0x000C5E58 File Offset: 0x000C4058
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

		// Token: 0x06006793 RID: 26515 RVA: 0x000C5E9C File Offset: 0x000C409C
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x06006794 RID: 26516 RVA: 0x000C5EB4 File Offset: 0x000C40B4
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x170020BA RID: 8378
		// (get) Token: 0x06006795 RID: 26517 RVA: 0x000C5EC0 File Offset: 0x000C40C0
		// (set) Token: 0x06006796 RID: 26518 RVA: 0x000C5EEC File Offset: 0x000C40EC
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

		// Token: 0x170020BB RID: 8379
		// (get) Token: 0x06006797 RID: 26519 RVA: 0x000C5EFC File Offset: 0x000C40FC
		// (set) Token: 0x06006798 RID: 26520 RVA: 0x000C5F1C File Offset: 0x000C411C
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

		// Token: 0x06006799 RID: 26521 RVA: 0x000C5F60 File Offset: 0x000C4160
		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		// Token: 0x0600679A RID: 26522 RVA: 0x000C5F78 File Offset: 0x000C4178
		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		// Token: 0x170020BC RID: 8380
		// (get) Token: 0x0600679B RID: 26523 RVA: 0x000C5F84 File Offset: 0x000C4184
		// (set) Token: 0x0600679C RID: 26524 RVA: 0x000C5FB0 File Offset: 0x000C41B0
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

		// Token: 0x170020BD RID: 8381
		// (get) Token: 0x0600679D RID: 26525 RVA: 0x000C5FC0 File Offset: 0x000C41C0
		// (set) Token: 0x0600679E RID: 26526 RVA: 0x000C5FE0 File Offset: 0x000C41E0
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

		// Token: 0x0600679F RID: 26527 RVA: 0x000C6024 File Offset: 0x000C4224
		private bool ShouldSerializewinthisweek()
		{
			return this.winthisweekSpecified;
		}

		// Token: 0x060067A0 RID: 26528 RVA: 0x000C603C File Offset: 0x000C423C
		private void Resetwinthisweek()
		{
			this.winthisweekSpecified = false;
		}

		// Token: 0x170020BE RID: 8382
		// (get) Token: 0x060067A1 RID: 26529 RVA: 0x000C6048 File Offset: 0x000C4248
		// (set) Token: 0x060067A2 RID: 26530 RVA: 0x000C6074 File Offset: 0x000C4274
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

		// Token: 0x170020BF RID: 8383
		// (get) Token: 0x060067A3 RID: 26531 RVA: 0x000C6084 File Offset: 0x000C4284
		// (set) Token: 0x060067A4 RID: 26532 RVA: 0x000C60A4 File Offset: 0x000C42A4
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

		// Token: 0x060067A5 RID: 26533 RVA: 0x000C60E8 File Offset: 0x000C42E8
		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		// Token: 0x060067A6 RID: 26534 RVA: 0x000C6100 File Offset: 0x000C4300
		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		// Token: 0x170020C0 RID: 8384
		// (get) Token: 0x060067A7 RID: 26535 RVA: 0x000C610C File Offset: 0x000C430C
		[ProtoMember(9, Name = "gamerecord", DataFormat = DataFormat.Default)]
		public List<HeroBattleOneGame> gamerecord
		{
			get
			{
				return this._gamerecord;
			}
		}

		// Token: 0x170020C1 RID: 8385
		// (get) Token: 0x060067A8 RID: 26536 RVA: 0x000C6124 File Offset: 0x000C4324
		// (set) Token: 0x060067A9 RID: 26537 RVA: 0x000C6150 File Offset: 0x000C4350
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

		// Token: 0x170020C2 RID: 8386
		// (get) Token: 0x060067AA RID: 26538 RVA: 0x000C6160 File Offset: 0x000C4360
		// (set) Token: 0x060067AB RID: 26539 RVA: 0x000C6180 File Offset: 0x000C4380
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

		// Token: 0x060067AC RID: 26540 RVA: 0x000C61C4 File Offset: 0x000C43C4
		private bool ShouldSerializetodayspcount()
		{
			return this.todayspcountSpecified;
		}

		// Token: 0x060067AD RID: 26541 RVA: 0x000C61DC File Offset: 0x000C43DC
		private void Resettodayspcount()
		{
			this.todayspcountSpecified = false;
		}

		// Token: 0x170020C3 RID: 8387
		// (get) Token: 0x060067AE RID: 26542 RVA: 0x000C61E8 File Offset: 0x000C43E8
		[ProtoMember(11, Name = "freeweekhero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> freeweekhero
		{
			get
			{
				return this._freeweekhero;
			}
		}

		// Token: 0x170020C4 RID: 8388
		// (get) Token: 0x060067AF RID: 26543 RVA: 0x000C6200 File Offset: 0x000C4400
		// (set) Token: 0x060067B0 RID: 26544 RVA: 0x000C622C File Offset: 0x000C442C
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

		// Token: 0x170020C5 RID: 8389
		// (get) Token: 0x060067B1 RID: 26545 RVA: 0x000C623C File Offset: 0x000C443C
		// (set) Token: 0x060067B2 RID: 26546 RVA: 0x000C625C File Offset: 0x000C445C
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

		// Token: 0x060067B3 RID: 26547 RVA: 0x000C62A0 File Offset: 0x000C44A0
		private bool ShouldSerializebigrewardcount()
		{
			return this.bigrewardcountSpecified;
		}

		// Token: 0x060067B4 RID: 26548 RVA: 0x000C62B8 File Offset: 0x000C44B8
		private void Resetbigrewardcount()
		{
			this.bigrewardcountSpecified = false;
		}

		// Token: 0x170020C6 RID: 8390
		// (get) Token: 0x060067B5 RID: 26549 RVA: 0x000C62C4 File Offset: 0x000C44C4
		// (set) Token: 0x060067B6 RID: 26550 RVA: 0x000C62F0 File Offset: 0x000C44F0
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

		// Token: 0x170020C7 RID: 8391
		// (get) Token: 0x060067B7 RID: 26551 RVA: 0x000C6300 File Offset: 0x000C4500
		// (set) Token: 0x060067B8 RID: 26552 RVA: 0x000C6320 File Offset: 0x000C4520
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

		// Token: 0x060067B9 RID: 26553 RVA: 0x000C6364 File Offset: 0x000C4564
		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		// Token: 0x060067BA RID: 26554 RVA: 0x000C637C File Offset: 0x000C457C
		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		// Token: 0x170020C8 RID: 8392
		// (get) Token: 0x060067BB RID: 26555 RVA: 0x000C6388 File Offset: 0x000C4588
		// (set) Token: 0x060067BC RID: 26556 RVA: 0x000C63BC File Offset: 0x000C45BC
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

		// Token: 0x170020C9 RID: 8393
		// (get) Token: 0x060067BD RID: 26557 RVA: 0x000C63CC File Offset: 0x000C45CC
		// (set) Token: 0x060067BE RID: 26558 RVA: 0x000C63EC File Offset: 0x000C45EC
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

		// Token: 0x060067BF RID: 26559 RVA: 0x000C6430 File Offset: 0x000C4630
		private bool ShouldSerializeelopoint()
		{
			return this.elopointSpecified;
		}

		// Token: 0x060067C0 RID: 26560 RVA: 0x000C6448 File Offset: 0x000C4648
		private void Resetelopoint()
		{
			this.elopointSpecified = false;
		}

		// Token: 0x170020CA RID: 8394
		// (get) Token: 0x060067C1 RID: 26561 RVA: 0x000C6454 File Offset: 0x000C4654
		// (set) Token: 0x060067C2 RID: 26562 RVA: 0x000C6480 File Offset: 0x000C4680
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

		// Token: 0x170020CB RID: 8395
		// (get) Token: 0x060067C3 RID: 26563 RVA: 0x000C6490 File Offset: 0x000C4690
		// (set) Token: 0x060067C4 RID: 26564 RVA: 0x000C64B0 File Offset: 0x000C46B0
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

		// Token: 0x060067C5 RID: 26565 RVA: 0x000C64F4 File Offset: 0x000C46F4
		private bool ShouldSerializedaytime()
		{
			return this.daytimeSpecified;
		}

		// Token: 0x060067C6 RID: 26566 RVA: 0x000C650C File Offset: 0x000C470C
		private void Resetdaytime()
		{
			this.daytimeSpecified = false;
		}

		// Token: 0x170020CC RID: 8396
		// (get) Token: 0x060067C7 RID: 26567 RVA: 0x000C6518 File Offset: 0x000C4718
		// (set) Token: 0x060067C8 RID: 26568 RVA: 0x000C6544 File Offset: 0x000C4744
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

		// Token: 0x170020CD RID: 8397
		// (get) Token: 0x060067C9 RID: 26569 RVA: 0x000C6554 File Offset: 0x000C4754
		// (set) Token: 0x060067CA RID: 26570 RVA: 0x000C6574 File Offset: 0x000C4774
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

		// Token: 0x060067CB RID: 26571 RVA: 0x000C65B8 File Offset: 0x000C47B8
		private bool ShouldSerializedaytimes()
		{
			return this.daytimesSpecified;
		}

		// Token: 0x060067CC RID: 26572 RVA: 0x000C65D0 File Offset: 0x000C47D0
		private void Resetdaytimes()
		{
			this.daytimesSpecified = false;
		}

		// Token: 0x170020CE RID: 8398
		// (get) Token: 0x060067CD RID: 26573 RVA: 0x000C65DC File Offset: 0x000C47DC
		[ProtoMember(17, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		// Token: 0x170020CF RID: 8399
		// (get) Token: 0x060067CE RID: 26574 RVA: 0x000C65F4 File Offset: 0x000C47F4
		[ProtoMember(18, Name = "experienceherotime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experienceherotime
		{
			get
			{
				return this._experienceherotime;
			}
		}

		// Token: 0x170020D0 RID: 8400
		// (get) Token: 0x060067CF RID: 26575 RVA: 0x000C660C File Offset: 0x000C480C
		// (set) Token: 0x060067D0 RID: 26576 RVA: 0x000C6638 File Offset: 0x000C4838
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

		// Token: 0x170020D1 RID: 8401
		// (get) Token: 0x060067D1 RID: 26577 RVA: 0x000C6648 File Offset: 0x000C4848
		// (set) Token: 0x060067D2 RID: 26578 RVA: 0x000C6668 File Offset: 0x000C4868
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

		// Token: 0x060067D3 RID: 26579 RVA: 0x000C66AC File Offset: 0x000C48AC
		private bool ShouldSerializecontinuewinnum()
		{
			return this.continuewinnumSpecified;
		}

		// Token: 0x060067D4 RID: 26580 RVA: 0x000C66C4 File Offset: 0x000C48C4
		private void Resetcontinuewinnum()
		{
			this.continuewinnumSpecified = false;
		}

		// Token: 0x170020D2 RID: 8402
		// (get) Token: 0x060067D5 RID: 26581 RVA: 0x000C66D0 File Offset: 0x000C48D0
		// (set) Token: 0x060067D6 RID: 26582 RVA: 0x000C66FC File Offset: 0x000C48FC
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

		// Token: 0x170020D3 RID: 8403
		// (get) Token: 0x060067D7 RID: 26583 RVA: 0x000C670C File Offset: 0x000C490C
		// (set) Token: 0x060067D8 RID: 26584 RVA: 0x000C672C File Offset: 0x000C492C
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

		// Token: 0x060067D9 RID: 26585 RVA: 0x000C6770 File Offset: 0x000C4970
		private bool ShouldSerializemaxkillnum()
		{
			return this.maxkillnumSpecified;
		}

		// Token: 0x060067DA RID: 26586 RVA: 0x000C6788 File Offset: 0x000C4988
		private void Resetmaxkillnum()
		{
			this.maxkillnumSpecified = false;
		}

		// Token: 0x060067DB RID: 26587 RVA: 0x000C6794 File Offset: 0x000C4994
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001902 RID: 6402
		private readonly List<uint> _havehero = new List<uint>();

		// Token: 0x04001903 RID: 6403
		private bool? _cangetprize;

		// Token: 0x04001904 RID: 6404
		private bool? _alreadygetprize;

		// Token: 0x04001905 RID: 6405
		private uint? _totalnum;

		// Token: 0x04001906 RID: 6406
		private uint? _winnum;

		// Token: 0x04001907 RID: 6407
		private uint? _losenum;

		// Token: 0x04001908 RID: 6408
		private uint? _winthisweek;

		// Token: 0x04001909 RID: 6409
		private uint? _lastupdatetime;

		// Token: 0x0400190A RID: 6410
		private readonly List<HeroBattleOneGame> _gamerecord = new List<HeroBattleOneGame>();

		// Token: 0x0400190B RID: 6411
		private uint? _todayspcount;

		// Token: 0x0400190C RID: 6412
		private readonly List<uint> _freeweekhero = new List<uint>();

		// Token: 0x0400190D RID: 6413
		private uint? _bigrewardcount;

		// Token: 0x0400190E RID: 6414
		private uint? _weekprize;

		// Token: 0x0400190F RID: 6415
		private double? _elopoint;

		// Token: 0x04001910 RID: 6416
		private uint? _daytime;

		// Token: 0x04001911 RID: 6417
		private uint? _daytimes;

		// Token: 0x04001912 RID: 6418
		private readonly List<uint> _experiencehero = new List<uint>();

		// Token: 0x04001913 RID: 6419
		private readonly List<uint> _experienceherotime = new List<uint>();

		// Token: 0x04001914 RID: 6420
		private uint? _continuewinnum;

		// Token: 0x04001915 RID: 6421
		private uint? _maxkillnum;

		// Token: 0x04001916 RID: 6422
		private IExtension extensionObject;
	}
}
