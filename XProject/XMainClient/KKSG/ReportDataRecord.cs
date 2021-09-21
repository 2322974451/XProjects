using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066A RID: 1642
	[ProtoContract(Name = "ReportDataRecord")]
	[Serializable]
	public class ReportDataRecord : IExtensible
	{
		// Token: 0x170020DC RID: 8412
		// (get) Token: 0x060067F3 RID: 26611 RVA: 0x000C6A84 File Offset: 0x000C4C84
		// (set) Token: 0x060067F4 RID: 26612 RVA: 0x000C6AB0 File Offset: 0x000C4CB0
		[ProtoMember(1, IsRequired = false, Name = "weeklogindays", DataFormat = DataFormat.TwosComplement)]
		public uint weeklogindays
		{
			get
			{
				return this._weeklogindays ?? 0U;
			}
			set
			{
				this._weeklogindays = new uint?(value);
			}
		}

		// Token: 0x170020DD RID: 8413
		// (get) Token: 0x060067F5 RID: 26613 RVA: 0x000C6AC0 File Offset: 0x000C4CC0
		// (set) Token: 0x060067F6 RID: 26614 RVA: 0x000C6AE0 File Offset: 0x000C4CE0
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklogindaysSpecified
		{
			get
			{
				return this._weeklogindays != null;
			}
			set
			{
				bool flag = value == (this._weeklogindays == null);
				if (flag)
				{
					this._weeklogindays = (value ? new uint?(this.weeklogindays) : null);
				}
			}
		}

		// Token: 0x060067F7 RID: 26615 RVA: 0x000C6B24 File Offset: 0x000C4D24
		private bool ShouldSerializeweeklogindays()
		{
			return this.weeklogindaysSpecified;
		}

		// Token: 0x060067F8 RID: 26616 RVA: 0x000C6B3C File Offset: 0x000C4D3C
		private void Resetweeklogindays()
		{
			this.weeklogindaysSpecified = false;
		}

		// Token: 0x170020DE RID: 8414
		// (get) Token: 0x060067F9 RID: 26617 RVA: 0x000C6B48 File Offset: 0x000C4D48
		// (set) Token: 0x060067FA RID: 26618 RVA: 0x000C6B74 File Offset: 0x000C4D74
		[ProtoMember(2, IsRequired = false, Name = "within20minsdays", DataFormat = DataFormat.TwosComplement)]
		public uint within20minsdays
		{
			get
			{
				return this._within20minsdays ?? 0U;
			}
			set
			{
				this._within20minsdays = new uint?(value);
			}
		}

		// Token: 0x170020DF RID: 8415
		// (get) Token: 0x060067FB RID: 26619 RVA: 0x000C6B84 File Offset: 0x000C4D84
		// (set) Token: 0x060067FC RID: 26620 RVA: 0x000C6BA4 File Offset: 0x000C4DA4
		[XmlIgnore]
		[Browsable(false)]
		public bool within20minsdaysSpecified
		{
			get
			{
				return this._within20minsdays != null;
			}
			set
			{
				bool flag = value == (this._within20minsdays == null);
				if (flag)
				{
					this._within20minsdays = (value ? new uint?(this.within20minsdays) : null);
				}
			}
		}

		// Token: 0x060067FD RID: 26621 RVA: 0x000C6BE8 File Offset: 0x000C4DE8
		private bool ShouldSerializewithin20minsdays()
		{
			return this.within20minsdaysSpecified;
		}

		// Token: 0x060067FE RID: 26622 RVA: 0x000C6C00 File Offset: 0x000C4E00
		private void Resetwithin20minsdays()
		{
			this.within20minsdaysSpecified = false;
		}

		// Token: 0x170020E0 RID: 8416
		// (get) Token: 0x060067FF RID: 26623 RVA: 0x000C6C0C File Offset: 0x000C4E0C
		// (set) Token: 0x06006800 RID: 26624 RVA: 0x000C6C38 File Offset: 0x000C4E38
		[ProtoMember(3, IsRequired = false, Name = "lastdayonlinetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayonlinetime
		{
			get
			{
				return this._lastdayonlinetime ?? 0U;
			}
			set
			{
				this._lastdayonlinetime = new uint?(value);
			}
		}

		// Token: 0x170020E1 RID: 8417
		// (get) Token: 0x06006801 RID: 26625 RVA: 0x000C6C48 File Offset: 0x000C4E48
		// (set) Token: 0x06006802 RID: 26626 RVA: 0x000C6C68 File Offset: 0x000C4E68
		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayonlinetimeSpecified
		{
			get
			{
				return this._lastdayonlinetime != null;
			}
			set
			{
				bool flag = value == (this._lastdayonlinetime == null);
				if (flag)
				{
					this._lastdayonlinetime = (value ? new uint?(this.lastdayonlinetime) : null);
				}
			}
		}

		// Token: 0x06006803 RID: 26627 RVA: 0x000C6CAC File Offset: 0x000C4EAC
		private bool ShouldSerializelastdayonlinetime()
		{
			return this.lastdayonlinetimeSpecified;
		}

		// Token: 0x06006804 RID: 26628 RVA: 0x000C6CC4 File Offset: 0x000C4EC4
		private void Resetlastdayonlinetime()
		{
			this.lastdayonlinetimeSpecified = false;
		}

		// Token: 0x170020E2 RID: 8418
		// (get) Token: 0x06006805 RID: 26629 RVA: 0x000C6CD0 File Offset: 0x000C4ED0
		// (set) Token: 0x06006806 RID: 26630 RVA: 0x000C6CFC File Offset: 0x000C4EFC
		[ProtoMember(4, IsRequired = false, Name = "lastdayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint lastdayupdate
		{
			get
			{
				return this._lastdayupdate ?? 0U;
			}
			set
			{
				this._lastdayupdate = new uint?(value);
			}
		}

		// Token: 0x170020E3 RID: 8419
		// (get) Token: 0x06006807 RID: 26631 RVA: 0x000C6D0C File Offset: 0x000C4F0C
		// (set) Token: 0x06006808 RID: 26632 RVA: 0x000C6D2C File Offset: 0x000C4F2C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastdayupdateSpecified
		{
			get
			{
				return this._lastdayupdate != null;
			}
			set
			{
				bool flag = value == (this._lastdayupdate == null);
				if (flag)
				{
					this._lastdayupdate = (value ? new uint?(this.lastdayupdate) : null);
				}
			}
		}

		// Token: 0x06006809 RID: 26633 RVA: 0x000C6D70 File Offset: 0x000C4F70
		private bool ShouldSerializelastdayupdate()
		{
			return this.lastdayupdateSpecified;
		}

		// Token: 0x0600680A RID: 26634 RVA: 0x000C6D88 File Offset: 0x000C4F88
		private void Resetlastdayupdate()
		{
			this.lastdayupdateSpecified = false;
		}

		// Token: 0x170020E4 RID: 8420
		// (get) Token: 0x0600680B RID: 26635 RVA: 0x000C6D94 File Offset: 0x000C4F94
		// (set) Token: 0x0600680C RID: 26636 RVA: 0x000C6DC0 File Offset: 0x000C4FC0
		[ProtoMember(5, IsRequired = false, Name = "lastweekupdate", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekupdate
		{
			get
			{
				return this._lastweekupdate ?? 0U;
			}
			set
			{
				this._lastweekupdate = new uint?(value);
			}
		}

		// Token: 0x170020E5 RID: 8421
		// (get) Token: 0x0600680D RID: 26637 RVA: 0x000C6DD0 File Offset: 0x000C4FD0
		// (set) Token: 0x0600680E RID: 26638 RVA: 0x000C6DF0 File Offset: 0x000C4FF0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekupdateSpecified
		{
			get
			{
				return this._lastweekupdate != null;
			}
			set
			{
				bool flag = value == (this._lastweekupdate == null);
				if (flag)
				{
					this._lastweekupdate = (value ? new uint?(this.lastweekupdate) : null);
				}
			}
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x000C6E34 File Offset: 0x000C5034
		private bool ShouldSerializelastweekupdate()
		{
			return this.lastweekupdateSpecified;
		}

		// Token: 0x06006810 RID: 26640 RVA: 0x000C6E4C File Offset: 0x000C504C
		private void Resetlastweekupdate()
		{
			this.lastweekupdateSpecified = false;
		}

		// Token: 0x170020E6 RID: 8422
		// (get) Token: 0x06006811 RID: 26641 RVA: 0x000C6E58 File Offset: 0x000C5058
		// (set) Token: 0x06006812 RID: 26642 RVA: 0x000C6E84 File Offset: 0x000C5084
		[ProtoMember(6, IsRequired = false, Name = "weeknestfasttime", DataFormat = DataFormat.TwosComplement)]
		public uint weeknestfasttime
		{
			get
			{
				return this._weeknestfasttime ?? 0U;
			}
			set
			{
				this._weeknestfasttime = new uint?(value);
			}
		}

		// Token: 0x170020E7 RID: 8423
		// (get) Token: 0x06006813 RID: 26643 RVA: 0x000C6E94 File Offset: 0x000C5094
		// (set) Token: 0x06006814 RID: 26644 RVA: 0x000C6EB4 File Offset: 0x000C50B4
		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestfasttimeSpecified
		{
			get
			{
				return this._weeknestfasttime != null;
			}
			set
			{
				bool flag = value == (this._weeknestfasttime == null);
				if (flag)
				{
					this._weeknestfasttime = (value ? new uint?(this.weeknestfasttime) : null);
				}
			}
		}

		// Token: 0x06006815 RID: 26645 RVA: 0x000C6EF8 File Offset: 0x000C50F8
		private bool ShouldSerializeweeknestfasttime()
		{
			return this.weeknestfasttimeSpecified;
		}

		// Token: 0x06006816 RID: 26646 RVA: 0x000C6F10 File Offset: 0x000C5110
		private void Resetweeknestfasttime()
		{
			this.weeknestfasttimeSpecified = false;
		}

		// Token: 0x170020E8 RID: 8424
		// (get) Token: 0x06006817 RID: 26647 RVA: 0x000C6F1C File Offset: 0x000C511C
		// (set) Token: 0x06006818 RID: 26648 RVA: 0x000C6F48 File Offset: 0x000C5148
		[ProtoMember(7, IsRequired = false, Name = "weekactivedays", DataFormat = DataFormat.TwosComplement)]
		public uint weekactivedays
		{
			get
			{
				return this._weekactivedays ?? 0U;
			}
			set
			{
				this._weekactivedays = new uint?(value);
			}
		}

		// Token: 0x170020E9 RID: 8425
		// (get) Token: 0x06006819 RID: 26649 RVA: 0x000C6F58 File Offset: 0x000C5158
		// (set) Token: 0x0600681A RID: 26650 RVA: 0x000C6F78 File Offset: 0x000C5178
		[XmlIgnore]
		[Browsable(false)]
		public bool weekactivedaysSpecified
		{
			get
			{
				return this._weekactivedays != null;
			}
			set
			{
				bool flag = value == (this._weekactivedays == null);
				if (flag)
				{
					this._weekactivedays = (value ? new uint?(this.weekactivedays) : null);
				}
			}
		}

		// Token: 0x0600681B RID: 26651 RVA: 0x000C6FBC File Offset: 0x000C51BC
		private bool ShouldSerializeweekactivedays()
		{
			return this.weekactivedaysSpecified;
		}

		// Token: 0x0600681C RID: 26652 RVA: 0x000C6FD4 File Offset: 0x000C51D4
		private void Resetweekactivedays()
		{
			this.weekactivedaysSpecified = false;
		}

		// Token: 0x170020EA RID: 8426
		// (get) Token: 0x0600681D RID: 26653 RVA: 0x000C6FE0 File Offset: 0x000C51E0
		// (set) Token: 0x0600681E RID: 26654 RVA: 0x000C700C File Offset: 0x000C520C
		[ProtoMember(8, IsRequired = false, Name = "weeknestdaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint weeknestdaytimes
		{
			get
			{
				return this._weeknestdaytimes ?? 0U;
			}
			set
			{
				this._weeknestdaytimes = new uint?(value);
			}
		}

		// Token: 0x170020EB RID: 8427
		// (get) Token: 0x0600681F RID: 26655 RVA: 0x000C701C File Offset: 0x000C521C
		// (set) Token: 0x06006820 RID: 26656 RVA: 0x000C703C File Offset: 0x000C523C
		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestdaytimesSpecified
		{
			get
			{
				return this._weeknestdaytimes != null;
			}
			set
			{
				bool flag = value == (this._weeknestdaytimes == null);
				if (flag)
				{
					this._weeknestdaytimes = (value ? new uint?(this.weeknestdaytimes) : null);
				}
			}
		}

		// Token: 0x06006821 RID: 26657 RVA: 0x000C7080 File Offset: 0x000C5280
		private bool ShouldSerializeweeknestdaytimes()
		{
			return this.weeknestdaytimesSpecified;
		}

		// Token: 0x06006822 RID: 26658 RVA: 0x000C7098 File Offset: 0x000C5298
		private void Resetweeknestdaytimes()
		{
			this.weeknestdaytimesSpecified = false;
		}

		// Token: 0x170020EC RID: 8428
		// (get) Token: 0x06006823 RID: 26659 RVA: 0x000C70A4 File Offset: 0x000C52A4
		[ProtoMember(9, Name = "wxdata", DataFormat = DataFormat.Default)]
		public List<WeekReportData> wxdata
		{
			get
			{
				return this._wxdata;
			}
		}

		// Token: 0x170020ED RID: 8429
		// (get) Token: 0x06006824 RID: 26660 RVA: 0x000C70BC File Offset: 0x000C52BC
		// (set) Token: 0x06006825 RID: 26661 RVA: 0x000C70E8 File Offset: 0x000C52E8
		[ProtoMember(10, IsRequired = false, Name = "lastrecommondtime", DataFormat = DataFormat.TwosComplement)]
		public uint lastrecommondtime
		{
			get
			{
				return this._lastrecommondtime ?? 0U;
			}
			set
			{
				this._lastrecommondtime = new uint?(value);
			}
		}

		// Token: 0x170020EE RID: 8430
		// (get) Token: 0x06006826 RID: 26662 RVA: 0x000C70F8 File Offset: 0x000C52F8
		// (set) Token: 0x06006827 RID: 26663 RVA: 0x000C7118 File Offset: 0x000C5318
		[XmlIgnore]
		[Browsable(false)]
		public bool lastrecommondtimeSpecified
		{
			get
			{
				return this._lastrecommondtime != null;
			}
			set
			{
				bool flag = value == (this._lastrecommondtime == null);
				if (flag)
				{
					this._lastrecommondtime = (value ? new uint?(this.lastrecommondtime) : null);
				}
			}
		}

		// Token: 0x06006828 RID: 26664 RVA: 0x000C715C File Offset: 0x000C535C
		private bool ShouldSerializelastrecommondtime()
		{
			return this.lastrecommondtimeSpecified;
		}

		// Token: 0x06006829 RID: 26665 RVA: 0x000C7174 File Offset: 0x000C5374
		private void Resetlastrecommondtime()
		{
			this.lastrecommondtimeSpecified = false;
		}

		// Token: 0x170020EF RID: 8431
		// (get) Token: 0x0600682A RID: 26666 RVA: 0x000C7180 File Offset: 0x000C5380
		// (set) Token: 0x0600682B RID: 26667 RVA: 0x000C71AC File Offset: 0x000C53AC
		[ProtoMember(11, IsRequired = false, Name = "abyssdaycount", DataFormat = DataFormat.TwosComplement)]
		public uint abyssdaycount
		{
			get
			{
				return this._abyssdaycount ?? 0U;
			}
			set
			{
				this._abyssdaycount = new uint?(value);
			}
		}

		// Token: 0x170020F0 RID: 8432
		// (get) Token: 0x0600682C RID: 26668 RVA: 0x000C71BC File Offset: 0x000C53BC
		// (set) Token: 0x0600682D RID: 26669 RVA: 0x000C71DC File Offset: 0x000C53DC
		[XmlIgnore]
		[Browsable(false)]
		public bool abyssdaycountSpecified
		{
			get
			{
				return this._abyssdaycount != null;
			}
			set
			{
				bool flag = value == (this._abyssdaycount == null);
				if (flag)
				{
					this._abyssdaycount = (value ? new uint?(this.abyssdaycount) : null);
				}
			}
		}

		// Token: 0x0600682E RID: 26670 RVA: 0x000C7220 File Offset: 0x000C5420
		private bool ShouldSerializeabyssdaycount()
		{
			return this.abyssdaycountSpecified;
		}

		// Token: 0x0600682F RID: 26671 RVA: 0x000C7238 File Offset: 0x000C5438
		private void Resetabyssdaycount()
		{
			this.abyssdaycountSpecified = false;
		}

		// Token: 0x170020F1 RID: 8433
		// (get) Token: 0x06006830 RID: 26672 RVA: 0x000C7244 File Offset: 0x000C5444
		// (set) Token: 0x06006831 RID: 26673 RVA: 0x000C7270 File Offset: 0x000C5470
		[ProtoMember(12, IsRequired = false, Name = "superrisktodaycount", DataFormat = DataFormat.TwosComplement)]
		public uint superrisktodaycount
		{
			get
			{
				return this._superrisktodaycount ?? 0U;
			}
			set
			{
				this._superrisktodaycount = new uint?(value);
			}
		}

		// Token: 0x170020F2 RID: 8434
		// (get) Token: 0x06006832 RID: 26674 RVA: 0x000C7280 File Offset: 0x000C5480
		// (set) Token: 0x06006833 RID: 26675 RVA: 0x000C72A0 File Offset: 0x000C54A0
		[XmlIgnore]
		[Browsable(false)]
		public bool superrisktodaycountSpecified
		{
			get
			{
				return this._superrisktodaycount != null;
			}
			set
			{
				bool flag = value == (this._superrisktodaycount == null);
				if (flag)
				{
					this._superrisktodaycount = (value ? new uint?(this.superrisktodaycount) : null);
				}
			}
		}

		// Token: 0x06006834 RID: 26676 RVA: 0x000C72E4 File Offset: 0x000C54E4
		private bool ShouldSerializesuperrisktodaycount()
		{
			return this.superrisktodaycountSpecified;
		}

		// Token: 0x06006835 RID: 26677 RVA: 0x000C72FC File Offset: 0x000C54FC
		private void Resetsuperrisktodaycount()
		{
			this.superrisktodaycountSpecified = false;
		}

		// Token: 0x170020F3 RID: 8435
		// (get) Token: 0x06006836 RID: 26678 RVA: 0x000C7308 File Offset: 0x000C5508
		// (set) Token: 0x06006837 RID: 26679 RVA: 0x000C7334 File Offset: 0x000C5534
		[ProtoMember(13, IsRequired = false, Name = "buyibshopcount", DataFormat = DataFormat.TwosComplement)]
		public uint buyibshopcount
		{
			get
			{
				return this._buyibshopcount ?? 0U;
			}
			set
			{
				this._buyibshopcount = new uint?(value);
			}
		}

		// Token: 0x170020F4 RID: 8436
		// (get) Token: 0x06006838 RID: 26680 RVA: 0x000C7344 File Offset: 0x000C5544
		// (set) Token: 0x06006839 RID: 26681 RVA: 0x000C7364 File Offset: 0x000C5564
		[XmlIgnore]
		[Browsable(false)]
		public bool buyibshopcountSpecified
		{
			get
			{
				return this._buyibshopcount != null;
			}
			set
			{
				bool flag = value == (this._buyibshopcount == null);
				if (flag)
				{
					this._buyibshopcount = (value ? new uint?(this.buyibshopcount) : null);
				}
			}
		}

		// Token: 0x0600683A RID: 26682 RVA: 0x000C73A8 File Offset: 0x000C55A8
		private bool ShouldSerializebuyibshopcount()
		{
			return this.buyibshopcountSpecified;
		}

		// Token: 0x0600683B RID: 26683 RVA: 0x000C73C0 File Offset: 0x000C55C0
		private void Resetbuyibshopcount()
		{
			this.buyibshopcountSpecified = false;
		}

		// Token: 0x170020F5 RID: 8437
		// (get) Token: 0x0600683C RID: 26684 RVA: 0x000C73CC File Offset: 0x000C55CC
		// (set) Token: 0x0600683D RID: 26685 RVA: 0x000C73F8 File Offset: 0x000C55F8
		[ProtoMember(14, IsRequired = false, Name = "pokercount", DataFormat = DataFormat.TwosComplement)]
		public uint pokercount
		{
			get
			{
				return this._pokercount ?? 0U;
			}
			set
			{
				this._pokercount = new uint?(value);
			}
		}

		// Token: 0x170020F6 RID: 8438
		// (get) Token: 0x0600683E RID: 26686 RVA: 0x000C7408 File Offset: 0x000C5608
		// (set) Token: 0x0600683F RID: 26687 RVA: 0x000C7428 File Offset: 0x000C5628
		[XmlIgnore]
		[Browsable(false)]
		public bool pokercountSpecified
		{
			get
			{
				return this._pokercount != null;
			}
			set
			{
				bool flag = value == (this._pokercount == null);
				if (flag)
				{
					this._pokercount = (value ? new uint?(this.pokercount) : null);
				}
			}
		}

		// Token: 0x06006840 RID: 26688 RVA: 0x000C746C File Offset: 0x000C566C
		private bool ShouldSerializepokercount()
		{
			return this.pokercountSpecified;
		}

		// Token: 0x06006841 RID: 26689 RVA: 0x000C7484 File Offset: 0x000C5684
		private void Resetpokercount()
		{
			this.pokercountSpecified = false;
		}

		// Token: 0x170020F7 RID: 8439
		// (get) Token: 0x06006842 RID: 26690 RVA: 0x000C7490 File Offset: 0x000C5690
		// (set) Token: 0x06006843 RID: 26691 RVA: 0x000C74BC File Offset: 0x000C56BC
		[ProtoMember(15, IsRequired = false, Name = "lastpokertime", DataFormat = DataFormat.TwosComplement)]
		public uint lastpokertime
		{
			get
			{
				return this._lastpokertime ?? 0U;
			}
			set
			{
				this._lastpokertime = new uint?(value);
			}
		}

		// Token: 0x170020F8 RID: 8440
		// (get) Token: 0x06006844 RID: 26692 RVA: 0x000C74CC File Offset: 0x000C56CC
		// (set) Token: 0x06006845 RID: 26693 RVA: 0x000C74EC File Offset: 0x000C56EC
		[XmlIgnore]
		[Browsable(false)]
		public bool lastpokertimeSpecified
		{
			get
			{
				return this._lastpokertime != null;
			}
			set
			{
				bool flag = value == (this._lastpokertime == null);
				if (flag)
				{
					this._lastpokertime = (value ? new uint?(this.lastpokertime) : null);
				}
			}
		}

		// Token: 0x06006846 RID: 26694 RVA: 0x000C7530 File Offset: 0x000C5730
		private bool ShouldSerializelastpokertime()
		{
			return this.lastpokertimeSpecified;
		}

		// Token: 0x06006847 RID: 26695 RVA: 0x000C7548 File Offset: 0x000C5748
		private void Resetlastpokertime()
		{
			this.lastpokertimeSpecified = false;
		}

		// Token: 0x170020F9 RID: 8441
		// (get) Token: 0x06006848 RID: 26696 RVA: 0x000C7554 File Offset: 0x000C5754
		// (set) Token: 0x06006849 RID: 26697 RVA: 0x000C7580 File Offset: 0x000C5780
		[ProtoMember(16, IsRequired = false, Name = "horsemacthcount", DataFormat = DataFormat.TwosComplement)]
		public uint horsemacthcount
		{
			get
			{
				return this._horsemacthcount ?? 0U;
			}
			set
			{
				this._horsemacthcount = new uint?(value);
			}
		}

		// Token: 0x170020FA RID: 8442
		// (get) Token: 0x0600684A RID: 26698 RVA: 0x000C7590 File Offset: 0x000C5790
		// (set) Token: 0x0600684B RID: 26699 RVA: 0x000C75B0 File Offset: 0x000C57B0
		[XmlIgnore]
		[Browsable(false)]
		public bool horsemacthcountSpecified
		{
			get
			{
				return this._horsemacthcount != null;
			}
			set
			{
				bool flag = value == (this._horsemacthcount == null);
				if (flag)
				{
					this._horsemacthcount = (value ? new uint?(this.horsemacthcount) : null);
				}
			}
		}

		// Token: 0x0600684C RID: 26700 RVA: 0x000C75F4 File Offset: 0x000C57F4
		private bool ShouldSerializehorsemacthcount()
		{
			return this.horsemacthcountSpecified;
		}

		// Token: 0x0600684D RID: 26701 RVA: 0x000C760C File Offset: 0x000C580C
		private void Resethorsemacthcount()
		{
			this.horsemacthcountSpecified = false;
		}

		// Token: 0x0600684E RID: 26702 RVA: 0x000C7618 File Offset: 0x000C5818
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400191D RID: 6429
		private uint? _weeklogindays;

		// Token: 0x0400191E RID: 6430
		private uint? _within20minsdays;

		// Token: 0x0400191F RID: 6431
		private uint? _lastdayonlinetime;

		// Token: 0x04001920 RID: 6432
		private uint? _lastdayupdate;

		// Token: 0x04001921 RID: 6433
		private uint? _lastweekupdate;

		// Token: 0x04001922 RID: 6434
		private uint? _weeknestfasttime;

		// Token: 0x04001923 RID: 6435
		private uint? _weekactivedays;

		// Token: 0x04001924 RID: 6436
		private uint? _weeknestdaytimes;

		// Token: 0x04001925 RID: 6437
		private readonly List<WeekReportData> _wxdata = new List<WeekReportData>();

		// Token: 0x04001926 RID: 6438
		private uint? _lastrecommondtime;

		// Token: 0x04001927 RID: 6439
		private uint? _abyssdaycount;

		// Token: 0x04001928 RID: 6440
		private uint? _superrisktodaycount;

		// Token: 0x04001929 RID: 6441
		private uint? _buyibshopcount;

		// Token: 0x0400192A RID: 6442
		private uint? _pokercount;

		// Token: 0x0400192B RID: 6443
		private uint? _lastpokertime;

		// Token: 0x0400192C RID: 6444
		private uint? _horsemacthcount;

		// Token: 0x0400192D RID: 6445
		private IExtension extensionObject;
	}
}
