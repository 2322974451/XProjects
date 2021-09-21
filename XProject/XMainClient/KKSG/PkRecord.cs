using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000602 RID: 1538
	[ProtoContract(Name = "PkRecord")]
	[Serializable]
	public class PkRecord : IExtensible
	{
		// Token: 0x17001CCE RID: 7374
		// (get) Token: 0x06005C00 RID: 23552 RVA: 0x000AF440 File Offset: 0x000AD640
		// (set) Token: 0x06005C01 RID: 23553 RVA: 0x000AF46C File Offset: 0x000AD66C
		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001CCF RID: 7375
		// (get) Token: 0x06005C02 RID: 23554 RVA: 0x000AF47C File Offset: 0x000AD67C
		// (set) Token: 0x06005C03 RID: 23555 RVA: 0x000AF49C File Offset: 0x000AD69C
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06005C04 RID: 23556 RVA: 0x000AF4E0 File Offset: 0x000AD6E0
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005C05 RID: 23557 RVA: 0x000AF4F8 File Offset: 0x000AD6F8
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001CD0 RID: 7376
		// (get) Token: 0x06005C06 RID: 23558 RVA: 0x000AF504 File Offset: 0x000AD704
		// (set) Token: 0x06005C07 RID: 23559 RVA: 0x000AF530 File Offset: 0x000AD730
		[ProtoMember(2, IsRequired = false, Name = "week", DataFormat = DataFormat.TwosComplement)]
		public uint week
		{
			get
			{
				return this._week ?? 0U;
			}
			set
			{
				this._week = new uint?(value);
			}
		}

		// Token: 0x17001CD1 RID: 7377
		// (get) Token: 0x06005C08 RID: 23560 RVA: 0x000AF540 File Offset: 0x000AD740
		// (set) Token: 0x06005C09 RID: 23561 RVA: 0x000AF560 File Offset: 0x000AD760
		[XmlIgnore]
		[Browsable(false)]
		public bool weekSpecified
		{
			get
			{
				return this._week != null;
			}
			set
			{
				bool flag = value == (this._week == null);
				if (flag)
				{
					this._week = (value ? new uint?(this.week) : null);
				}
			}
		}

		// Token: 0x06005C0A RID: 23562 RVA: 0x000AF5A4 File Offset: 0x000AD7A4
		private bool ShouldSerializeweek()
		{
			return this.weekSpecified;
		}

		// Token: 0x06005C0B RID: 23563 RVA: 0x000AF5BC File Offset: 0x000AD7BC
		private void Resetweek()
		{
			this.weekSpecified = false;
		}

		// Token: 0x17001CD2 RID: 7378
		// (get) Token: 0x06005C0C RID: 23564 RVA: 0x000AF5C8 File Offset: 0x000AD7C8
		// (set) Token: 0x06005C0D RID: 23565 RVA: 0x000AF5F4 File Offset: 0x000AD7F4
		[ProtoMember(3, IsRequired = false, Name = "unused_win", DataFormat = DataFormat.TwosComplement)]
		public uint unused_win
		{
			get
			{
				return this._unused_win ?? 0U;
			}
			set
			{
				this._unused_win = new uint?(value);
			}
		}

		// Token: 0x17001CD3 RID: 7379
		// (get) Token: 0x06005C0E RID: 23566 RVA: 0x000AF604 File Offset: 0x000AD804
		// (set) Token: 0x06005C0F RID: 23567 RVA: 0x000AF624 File Offset: 0x000AD824
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_winSpecified
		{
			get
			{
				return this._unused_win != null;
			}
			set
			{
				bool flag = value == (this._unused_win == null);
				if (flag)
				{
					this._unused_win = (value ? new uint?(this.unused_win) : null);
				}
			}
		}

		// Token: 0x06005C10 RID: 23568 RVA: 0x000AF668 File Offset: 0x000AD868
		private bool ShouldSerializeunused_win()
		{
			return this.unused_winSpecified;
		}

		// Token: 0x06005C11 RID: 23569 RVA: 0x000AF680 File Offset: 0x000AD880
		private void Resetunused_win()
		{
			this.unused_winSpecified = false;
		}

		// Token: 0x17001CD4 RID: 7380
		// (get) Token: 0x06005C12 RID: 23570 RVA: 0x000AF68C File Offset: 0x000AD88C
		// (set) Token: 0x06005C13 RID: 23571 RVA: 0x000AF6B8 File Offset: 0x000AD8B8
		[ProtoMember(4, IsRequired = false, Name = "unused_lose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lose
		{
			get
			{
				return this._unused_lose ?? 0U;
			}
			set
			{
				this._unused_lose = new uint?(value);
			}
		}

		// Token: 0x17001CD5 RID: 7381
		// (get) Token: 0x06005C14 RID: 23572 RVA: 0x000AF6C8 File Offset: 0x000AD8C8
		// (set) Token: 0x06005C15 RID: 23573 RVA: 0x000AF6E8 File Offset: 0x000AD8E8
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_loseSpecified
		{
			get
			{
				return this._unused_lose != null;
			}
			set
			{
				bool flag = value == (this._unused_lose == null);
				if (flag)
				{
					this._unused_lose = (value ? new uint?(this.unused_lose) : null);
				}
			}
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x000AF72C File Offset: 0x000AD92C
		private bool ShouldSerializeunused_lose()
		{
			return this.unused_loseSpecified;
		}

		// Token: 0x06005C17 RID: 23575 RVA: 0x000AF744 File Offset: 0x000AD944
		private void Resetunused_lose()
		{
			this.unused_loseSpecified = false;
		}

		// Token: 0x17001CD6 RID: 7382
		// (get) Token: 0x06005C18 RID: 23576 RVA: 0x000AF750 File Offset: 0x000AD950
		// (set) Token: 0x06005C19 RID: 23577 RVA: 0x000AF77C File Offset: 0x000AD97C
		[ProtoMember(5, IsRequired = false, Name = "unused_continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint unused_continuewin
		{
			get
			{
				return this._unused_continuewin ?? 0U;
			}
			set
			{
				this._unused_continuewin = new uint?(value);
			}
		}

		// Token: 0x17001CD7 RID: 7383
		// (get) Token: 0x06005C1A RID: 23578 RVA: 0x000AF78C File Offset: 0x000AD98C
		// (set) Token: 0x06005C1B RID: 23579 RVA: 0x000AF7AC File Offset: 0x000AD9AC
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_continuewinSpecified
		{
			get
			{
				return this._unused_continuewin != null;
			}
			set
			{
				bool flag = value == (this._unused_continuewin == null);
				if (flag)
				{
					this._unused_continuewin = (value ? new uint?(this.unused_continuewin) : null);
				}
			}
		}

		// Token: 0x06005C1C RID: 23580 RVA: 0x000AF7F0 File Offset: 0x000AD9F0
		private bool ShouldSerializeunused_continuewin()
		{
			return this.unused_continuewinSpecified;
		}

		// Token: 0x06005C1D RID: 23581 RVA: 0x000AF808 File Offset: 0x000ADA08
		private void Resetunused_continuewin()
		{
			this.unused_continuewinSpecified = false;
		}

		// Token: 0x17001CD8 RID: 7384
		// (get) Token: 0x06005C1E RID: 23582 RVA: 0x000AF814 File Offset: 0x000ADA14
		// (set) Token: 0x06005C1F RID: 23583 RVA: 0x000AF840 File Offset: 0x000ADA40
		[ProtoMember(6, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		// Token: 0x17001CD9 RID: 7385
		// (get) Token: 0x06005C20 RID: 23584 RVA: 0x000AF850 File Offset: 0x000ADA50
		// (set) Token: 0x06005C21 RID: 23585 RVA: 0x000AF870 File Offset: 0x000ADA70
		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		// Token: 0x06005C22 RID: 23586 RVA: 0x000AF8B4 File Offset: 0x000ADAB4
		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		// Token: 0x06005C23 RID: 23587 RVA: 0x000AF8CC File Offset: 0x000ADACC
		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		// Token: 0x17001CDA RID: 7386
		// (get) Token: 0x06005C24 RID: 23588 RVA: 0x000AF8D8 File Offset: 0x000ADAD8
		[ProtoMember(7, Name = "boxtaken", DataFormat = DataFormat.TwosComplement)]
		public List<uint> boxtaken
		{
			get
			{
				return this._boxtaken;
			}
		}

		// Token: 0x17001CDB RID: 7387
		// (get) Token: 0x06005C25 RID: 23589 RVA: 0x000AF8F0 File Offset: 0x000ADAF0
		[ProtoMember(8, Name = "records", DataFormat = DataFormat.Default)]
		public List<PkOneRecord> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x17001CDC RID: 7388
		// (get) Token: 0x06005C26 RID: 23590 RVA: 0x000AF908 File Offset: 0x000ADB08
		// (set) Token: 0x06005C27 RID: 23591 RVA: 0x000AF934 File Offset: 0x000ADB34
		[ProtoMember(9, IsRequired = false, Name = "unused_continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_continuelose
		{
			get
			{
				return this._unused_continuelose ?? 0U;
			}
			set
			{
				this._unused_continuelose = new uint?(value);
			}
		}

		// Token: 0x17001CDD RID: 7389
		// (get) Token: 0x06005C28 RID: 23592 RVA: 0x000AF944 File Offset: 0x000ADB44
		// (set) Token: 0x06005C29 RID: 23593 RVA: 0x000AF964 File Offset: 0x000ADB64
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_continueloseSpecified
		{
			get
			{
				return this._unused_continuelose != null;
			}
			set
			{
				bool flag = value == (this._unused_continuelose == null);
				if (flag)
				{
					this._unused_continuelose = (value ? new uint?(this.unused_continuelose) : null);
				}
			}
		}

		// Token: 0x06005C2A RID: 23594 RVA: 0x000AF9A8 File Offset: 0x000ADBA8
		private bool ShouldSerializeunused_continuelose()
		{
			return this.unused_continueloseSpecified;
		}

		// Token: 0x06005C2B RID: 23595 RVA: 0x000AF9C0 File Offset: 0x000ADBC0
		private void Resetunused_continuelose()
		{
			this.unused_continueloseSpecified = false;
		}

		// Token: 0x17001CDE RID: 7390
		// (get) Token: 0x06005C2C RID: 23596 RVA: 0x000AF9CC File Offset: 0x000ADBCC
		[ProtoMember(10, Name = "prowin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prowin
		{
			get
			{
				return this._prowin;
			}
		}

		// Token: 0x17001CDF RID: 7391
		// (get) Token: 0x06005C2D RID: 23597 RVA: 0x000AF9E4 File Offset: 0x000ADBE4
		[ProtoMember(11, Name = "prolose", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prolose
		{
			get
			{
				return this._prolose;
			}
		}

		// Token: 0x17001CE0 RID: 7392
		// (get) Token: 0x06005C2E RID: 23598 RVA: 0x000AF9FC File Offset: 0x000ADBFC
		// (set) Token: 0x06005C2F RID: 23599 RVA: 0x000AFA28 File Offset: 0x000ADC28
		[ProtoMember(12, IsRequired = false, Name = "unused_lastwin", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lastwin
		{
			get
			{
				return this._unused_lastwin ?? 0U;
			}
			set
			{
				this._unused_lastwin = new uint?(value);
			}
		}

		// Token: 0x17001CE1 RID: 7393
		// (get) Token: 0x06005C30 RID: 23600 RVA: 0x000AFA38 File Offset: 0x000ADC38
		// (set) Token: 0x06005C31 RID: 23601 RVA: 0x000AFA58 File Offset: 0x000ADC58
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_lastwinSpecified
		{
			get
			{
				return this._unused_lastwin != null;
			}
			set
			{
				bool flag = value == (this._unused_lastwin == null);
				if (flag)
				{
					this._unused_lastwin = (value ? new uint?(this.unused_lastwin) : null);
				}
			}
		}

		// Token: 0x06005C32 RID: 23602 RVA: 0x000AFA9C File Offset: 0x000ADC9C
		private bool ShouldSerializeunused_lastwin()
		{
			return this.unused_lastwinSpecified;
		}

		// Token: 0x06005C33 RID: 23603 RVA: 0x000AFAB4 File Offset: 0x000ADCB4
		private void Resetunused_lastwin()
		{
			this.unused_lastwinSpecified = false;
		}

		// Token: 0x17001CE2 RID: 7394
		// (get) Token: 0x06005C34 RID: 23604 RVA: 0x000AFAC0 File Offset: 0x000ADCC0
		// (set) Token: 0x06005C35 RID: 23605 RVA: 0x000AFAEC File Offset: 0x000ADCEC
		[ProtoMember(13, IsRequired = false, Name = "unused_lastlose", DataFormat = DataFormat.TwosComplement)]
		public uint unused_lastlose
		{
			get
			{
				return this._unused_lastlose ?? 0U;
			}
			set
			{
				this._unused_lastlose = new uint?(value);
			}
		}

		// Token: 0x17001CE3 RID: 7395
		// (get) Token: 0x06005C36 RID: 23606 RVA: 0x000AFAFC File Offset: 0x000ADCFC
		// (set) Token: 0x06005C37 RID: 23607 RVA: 0x000AFB1C File Offset: 0x000ADD1C
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_lastloseSpecified
		{
			get
			{
				return this._unused_lastlose != null;
			}
			set
			{
				bool flag = value == (this._unused_lastlose == null);
				if (flag)
				{
					this._unused_lastlose = (value ? new uint?(this.unused_lastlose) : null);
				}
			}
		}

		// Token: 0x06005C38 RID: 23608 RVA: 0x000AFB60 File Offset: 0x000ADD60
		private bool ShouldSerializeunused_lastlose()
		{
			return this.unused_lastloseSpecified;
		}

		// Token: 0x06005C39 RID: 23609 RVA: 0x000AFB78 File Offset: 0x000ADD78
		private void Resetunused_lastlose()
		{
			this.unused_lastloseSpecified = false;
		}

		// Token: 0x17001CE4 RID: 7396
		// (get) Token: 0x06005C3A RID: 23610 RVA: 0x000AFB84 File Offset: 0x000ADD84
		[ProtoMember(14, Name = "prodraw", DataFormat = DataFormat.TwosComplement)]
		public List<uint> prodraw
		{
			get
			{
				return this._prodraw;
			}
		}

		// Token: 0x17001CE5 RID: 7397
		// (get) Token: 0x06005C3B RID: 23611 RVA: 0x000AFB9C File Offset: 0x000ADD9C
		// (set) Token: 0x06005C3C RID: 23612 RVA: 0x000AFBC8 File Offset: 0x000ADDC8
		[ProtoMember(15, IsRequired = false, Name = "unused_draw", DataFormat = DataFormat.TwosComplement)]
		public uint unused_draw
		{
			get
			{
				return this._unused_draw ?? 0U;
			}
			set
			{
				this._unused_draw = new uint?(value);
			}
		}

		// Token: 0x17001CE6 RID: 7398
		// (get) Token: 0x06005C3D RID: 23613 RVA: 0x000AFBD8 File Offset: 0x000ADDD8
		// (set) Token: 0x06005C3E RID: 23614 RVA: 0x000AFBF8 File Offset: 0x000ADDF8
		[XmlIgnore]
		[Browsable(false)]
		public bool unused_drawSpecified
		{
			get
			{
				return this._unused_draw != null;
			}
			set
			{
				bool flag = value == (this._unused_draw == null);
				if (flag)
				{
					this._unused_draw = (value ? new uint?(this.unused_draw) : null);
				}
			}
		}

		// Token: 0x06005C3F RID: 23615 RVA: 0x000AFC3C File Offset: 0x000ADE3C
		private bool ShouldSerializeunused_draw()
		{
			return this.unused_drawSpecified;
		}

		// Token: 0x06005C40 RID: 23616 RVA: 0x000AFC54 File Offset: 0x000ADE54
		private void Resetunused_draw()
		{
			this.unused_drawSpecified = false;
		}

		// Token: 0x17001CE7 RID: 7399
		// (get) Token: 0x06005C41 RID: 23617 RVA: 0x000AFC60 File Offset: 0x000ADE60
		// (set) Token: 0x06005C42 RID: 23618 RVA: 0x000AFC8C File Offset: 0x000ADE8C
		[ProtoMember(16, IsRequired = false, Name = "pointlastlose", DataFormat = DataFormat.TwosComplement)]
		public uint pointlastlose
		{
			get
			{
				return this._pointlastlose ?? 0U;
			}
			set
			{
				this._pointlastlose = new uint?(value);
			}
		}

		// Token: 0x17001CE8 RID: 7400
		// (get) Token: 0x06005C43 RID: 23619 RVA: 0x000AFC9C File Offset: 0x000ADE9C
		// (set) Token: 0x06005C44 RID: 23620 RVA: 0x000AFCBC File Offset: 0x000ADEBC
		[XmlIgnore]
		[Browsable(false)]
		public bool pointlastloseSpecified
		{
			get
			{
				return this._pointlastlose != null;
			}
			set
			{
				bool flag = value == (this._pointlastlose == null);
				if (flag)
				{
					this._pointlastlose = (value ? new uint?(this.pointlastlose) : null);
				}
			}
		}

		// Token: 0x06005C45 RID: 23621 RVA: 0x000AFD00 File Offset: 0x000ADF00
		private bool ShouldSerializepointlastlose()
		{
			return this.pointlastloseSpecified;
		}

		// Token: 0x06005C46 RID: 23622 RVA: 0x000AFD18 File Offset: 0x000ADF18
		private void Resetpointlastlose()
		{
			this.pointlastloseSpecified = false;
		}

		// Token: 0x17001CE9 RID: 7401
		// (get) Token: 0x06005C47 RID: 23623 RVA: 0x000AFD24 File Offset: 0x000ADF24
		// (set) Token: 0x06005C48 RID: 23624 RVA: 0x000AFD50 File Offset: 0x000ADF50
		[ProtoMember(17, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		// Token: 0x17001CEA RID: 7402
		// (get) Token: 0x06005C49 RID: 23625 RVA: 0x000AFD60 File Offset: 0x000ADF60
		// (set) Token: 0x06005C4A RID: 23626 RVA: 0x000AFD80 File Offset: 0x000ADF80
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
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x000AFDC4 File Offset: 0x000ADFC4
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x000AFDDC File Offset: 0x000ADFDC
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x17001CEB RID: 7403
		// (get) Token: 0x06005C4D RID: 23629 RVA: 0x000AFDE8 File Offset: 0x000ADFE8
		// (set) Token: 0x06005C4E RID: 23630 RVA: 0x000AFE14 File Offset: 0x000AE014
		[ProtoMember(18, IsRequired = false, Name = "rewardcounttoday", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcounttoday
		{
			get
			{
				return this._rewardcounttoday ?? 0U;
			}
			set
			{
				this._rewardcounttoday = new uint?(value);
			}
		}

		// Token: 0x17001CEC RID: 7404
		// (get) Token: 0x06005C4F RID: 23631 RVA: 0x000AFE24 File Offset: 0x000AE024
		// (set) Token: 0x06005C50 RID: 23632 RVA: 0x000AFE44 File Offset: 0x000AE044
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcounttodaySpecified
		{
			get
			{
				return this._rewardcounttoday != null;
			}
			set
			{
				bool flag = value == (this._rewardcounttoday == null);
				if (flag)
				{
					this._rewardcounttoday = (value ? new uint?(this.rewardcounttoday) : null);
				}
			}
		}

		// Token: 0x06005C51 RID: 23633 RVA: 0x000AFE88 File Offset: 0x000AE088
		private bool ShouldSerializerewardcounttoday()
		{
			return this.rewardcounttodaySpecified;
		}

		// Token: 0x06005C52 RID: 23634 RVA: 0x000AFEA0 File Offset: 0x000AE0A0
		private void Resetrewardcounttoday()
		{
			this.rewardcounttodaySpecified = false;
		}

		// Token: 0x17001CED RID: 7405
		// (get) Token: 0x06005C53 RID: 23635 RVA: 0x000AFEAC File Offset: 0x000AE0AC
		// (set) Token: 0x06005C54 RID: 23636 RVA: 0x000AFED8 File Offset: 0x000AE0D8
		[ProtoMember(19, IsRequired = false, Name = "todayplaytime", DataFormat = DataFormat.TwosComplement)]
		public uint todayplaytime
		{
			get
			{
				return this._todayplaytime ?? 0U;
			}
			set
			{
				this._todayplaytime = new uint?(value);
			}
		}

		// Token: 0x17001CEE RID: 7406
		// (get) Token: 0x06005C55 RID: 23637 RVA: 0x000AFEE8 File Offset: 0x000AE0E8
		// (set) Token: 0x06005C56 RID: 23638 RVA: 0x000AFF08 File Offset: 0x000AE108
		[XmlIgnore]
		[Browsable(false)]
		public bool todayplaytimeSpecified
		{
			get
			{
				return this._todayplaytime != null;
			}
			set
			{
				bool flag = value == (this._todayplaytime == null);
				if (flag)
				{
					this._todayplaytime = (value ? new uint?(this.todayplaytime) : null);
				}
			}
		}

		// Token: 0x06005C57 RID: 23639 RVA: 0x000AFF4C File Offset: 0x000AE14C
		private bool ShouldSerializetodayplaytime()
		{
			return this.todayplaytimeSpecified;
		}

		// Token: 0x06005C58 RID: 23640 RVA: 0x000AFF64 File Offset: 0x000AE164
		private void Resettodayplaytime()
		{
			this.todayplaytimeSpecified = false;
		}

		// Token: 0x17001CEF RID: 7407
		// (get) Token: 0x06005C59 RID: 23641 RVA: 0x000AFF70 File Offset: 0x000AE170
		// (set) Token: 0x06005C5A RID: 23642 RVA: 0x000AFF88 File Offset: 0x000AE188
		[ProtoMember(20, IsRequired = false, Name = "histweek", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histweek
		{
			get
			{
				return this._histweek;
			}
			set
			{
				this._histweek = value;
			}
		}

		// Token: 0x17001CF0 RID: 7408
		// (get) Token: 0x06005C5B RID: 23643 RVA: 0x000AFF94 File Offset: 0x000AE194
		// (set) Token: 0x06005C5C RID: 23644 RVA: 0x000AFFAC File Offset: 0x000AE1AC
		[ProtoMember(21, IsRequired = false, Name = "histall", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histall
		{
			get
			{
				return this._histall;
			}
			set
			{
				this._histall = value;
			}
		}

		// Token: 0x17001CF1 RID: 7409
		// (get) Token: 0x06005C5D RID: 23645 RVA: 0x000AFFB8 File Offset: 0x000AE1B8
		// (set) Token: 0x06005C5E RID: 23646 RVA: 0x000AFFE4 File Offset: 0x000AE1E4
		[ProtoMember(22, IsRequired = false, Name = "pkdaytimes", DataFormat = DataFormat.TwosComplement)]
		public uint pkdaytimes
		{
			get
			{
				return this._pkdaytimes ?? 0U;
			}
			set
			{
				this._pkdaytimes = new uint?(value);
			}
		}

		// Token: 0x17001CF2 RID: 7410
		// (get) Token: 0x06005C5F RID: 23647 RVA: 0x000AFFF4 File Offset: 0x000AE1F4
		// (set) Token: 0x06005C60 RID: 23648 RVA: 0x000B0014 File Offset: 0x000AE214
		[XmlIgnore]
		[Browsable(false)]
		public bool pkdaytimesSpecified
		{
			get
			{
				return this._pkdaytimes != null;
			}
			set
			{
				bool flag = value == (this._pkdaytimes == null);
				if (flag)
				{
					this._pkdaytimes = (value ? new uint?(this.pkdaytimes) : null);
				}
			}
		}

		// Token: 0x06005C61 RID: 23649 RVA: 0x000B0058 File Offset: 0x000AE258
		private bool ShouldSerializepkdaytimes()
		{
			return this.pkdaytimesSpecified;
		}

		// Token: 0x06005C62 RID: 23650 RVA: 0x000B0070 File Offset: 0x000AE270
		private void Resetpkdaytimes()
		{
			this.pkdaytimesSpecified = false;
		}

		// Token: 0x17001CF3 RID: 7411
		// (get) Token: 0x06005C63 RID: 23651 RVA: 0x000B007C File Offset: 0x000AE27C
		// (set) Token: 0x06005C64 RID: 23652 RVA: 0x000B00A8 File Offset: 0x000AE2A8
		[ProtoMember(23, IsRequired = false, Name = "weektimes", DataFormat = DataFormat.TwosComplement)]
		public uint weektimes
		{
			get
			{
				return this._weektimes ?? 0U;
			}
			set
			{
				this._weektimes = new uint?(value);
			}
		}

		// Token: 0x17001CF4 RID: 7412
		// (get) Token: 0x06005C65 RID: 23653 RVA: 0x000B00B8 File Offset: 0x000AE2B8
		// (set) Token: 0x06005C66 RID: 23654 RVA: 0x000B00D8 File Offset: 0x000AE2D8
		[XmlIgnore]
		[Browsable(false)]
		public bool weektimesSpecified
		{
			get
			{
				return this._weektimes != null;
			}
			set
			{
				bool flag = value == (this._weektimes == null);
				if (flag)
				{
					this._weektimes = (value ? new uint?(this.weektimes) : null);
				}
			}
		}

		// Token: 0x06005C67 RID: 23655 RVA: 0x000B011C File Offset: 0x000AE31C
		private bool ShouldSerializeweektimes()
		{
			return this.weektimesSpecified;
		}

		// Token: 0x06005C68 RID: 23656 RVA: 0x000B0134 File Offset: 0x000AE334
		private void Resetweektimes()
		{
			this.weektimesSpecified = false;
		}

		// Token: 0x17001CF5 RID: 7413
		// (get) Token: 0x06005C69 RID: 23657 RVA: 0x000B0140 File Offset: 0x000AE340
		// (set) Token: 0x06005C6A RID: 23658 RVA: 0x000B016C File Offset: 0x000AE36C
		[ProtoMember(24, IsRequired = false, Name = "last7daystime", DataFormat = DataFormat.TwosComplement)]
		public uint last7daystime
		{
			get
			{
				return this._last7daystime ?? 0U;
			}
			set
			{
				this._last7daystime = new uint?(value);
			}
		}

		// Token: 0x17001CF6 RID: 7414
		// (get) Token: 0x06005C6B RID: 23659 RVA: 0x000B017C File Offset: 0x000AE37C
		// (set) Token: 0x06005C6C RID: 23660 RVA: 0x000B019C File Offset: 0x000AE39C
		[XmlIgnore]
		[Browsable(false)]
		public bool last7daystimeSpecified
		{
			get
			{
				return this._last7daystime != null;
			}
			set
			{
				bool flag = value == (this._last7daystime == null);
				if (flag)
				{
					this._last7daystime = (value ? new uint?(this.last7daystime) : null);
				}
			}
		}

		// Token: 0x06005C6D RID: 23661 RVA: 0x000B01E0 File Offset: 0x000AE3E0
		private bool ShouldSerializelast7daystime()
		{
			return this.last7daystimeSpecified;
		}

		// Token: 0x06005C6E RID: 23662 RVA: 0x000B01F8 File Offset: 0x000AE3F8
		private void Resetlast7daystime()
		{
			this.last7daystimeSpecified = false;
		}

		// Token: 0x17001CF7 RID: 7415
		// (get) Token: 0x06005C6F RID: 23663 RVA: 0x000B0204 File Offset: 0x000AE404
		// (set) Token: 0x06005C70 RID: 23664 RVA: 0x000B021C File Offset: 0x000AE41C
		[ProtoMember(25, IsRequired = false, Name = "info2v2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecordSubInfo info2v2
		{
			get
			{
				return this._info2v2;
			}
			set
			{
				this._info2v2 = value;
			}
		}

		// Token: 0x17001CF8 RID: 7416
		// (get) Token: 0x06005C71 RID: 23665 RVA: 0x000B0228 File Offset: 0x000AE428
		// (set) Token: 0x06005C72 RID: 23666 RVA: 0x000B0254 File Offset: 0x000AE454
		[ProtoMember(26, IsRequired = false, Name = "oneweekresettime", DataFormat = DataFormat.TwosComplement)]
		public uint oneweekresettime
		{
			get
			{
				return this._oneweekresettime ?? 0U;
			}
			set
			{
				this._oneweekresettime = new uint?(value);
			}
		}

		// Token: 0x17001CF9 RID: 7417
		// (get) Token: 0x06005C73 RID: 23667 RVA: 0x000B0264 File Offset: 0x000AE464
		// (set) Token: 0x06005C74 RID: 23668 RVA: 0x000B0284 File Offset: 0x000AE484
		[XmlIgnore]
		[Browsable(false)]
		public bool oneweekresettimeSpecified
		{
			get
			{
				return this._oneweekresettime != null;
			}
			set
			{
				bool flag = value == (this._oneweekresettime == null);
				if (flag)
				{
					this._oneweekresettime = (value ? new uint?(this.oneweekresettime) : null);
				}
			}
		}

		// Token: 0x06005C75 RID: 23669 RVA: 0x000B02C8 File Offset: 0x000AE4C8
		private bool ShouldSerializeoneweekresettime()
		{
			return this.oneweekresettimeSpecified;
		}

		// Token: 0x06005C76 RID: 23670 RVA: 0x000B02E0 File Offset: 0x000AE4E0
		private void Resetoneweekresettime()
		{
			this.oneweekresettimeSpecified = false;
		}

		// Token: 0x17001CFA RID: 7418
		// (get) Token: 0x06005C77 RID: 23671 RVA: 0x000B02EC File Offset: 0x000AE4EC
		// (set) Token: 0x06005C78 RID: 23672 RVA: 0x000B0318 File Offset: 0x000AE518
		[ProtoMember(27, IsRequired = false, Name = "lastweekpoint", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekpoint
		{
			get
			{
				return this._lastweekpoint ?? 0U;
			}
			set
			{
				this._lastweekpoint = new uint?(value);
			}
		}

		// Token: 0x17001CFB RID: 7419
		// (get) Token: 0x06005C79 RID: 23673 RVA: 0x000B0328 File Offset: 0x000AE528
		// (set) Token: 0x06005C7A RID: 23674 RVA: 0x000B0348 File Offset: 0x000AE548
		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekpointSpecified
		{
			get
			{
				return this._lastweekpoint != null;
			}
			set
			{
				bool flag = value == (this._lastweekpoint == null);
				if (flag)
				{
					this._lastweekpoint = (value ? new uint?(this.lastweekpoint) : null);
				}
			}
		}

		// Token: 0x06005C7B RID: 23675 RVA: 0x000B038C File Offset: 0x000AE58C
		private bool ShouldSerializelastweekpoint()
		{
			return this.lastweekpointSpecified;
		}

		// Token: 0x06005C7C RID: 23676 RVA: 0x000B03A4 File Offset: 0x000AE5A4
		private void Resetlastweekpoint()
		{
			this.lastweekpointSpecified = false;
		}

		// Token: 0x17001CFC RID: 7420
		// (get) Token: 0x06005C7D RID: 23677 RVA: 0x000B03B0 File Offset: 0x000AE5B0
		// (set) Token: 0x06005C7E RID: 23678 RVA: 0x000B03C8 File Offset: 0x000AE5C8
		[ProtoMember(28, IsRequired = false, Name = "histday", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist histday
		{
			get
			{
				return this._histday;
			}
			set
			{
				this._histday = value;
			}
		}

		// Token: 0x06005C7F RID: 23679 RVA: 0x000B03D4 File Offset: 0x000AE5D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001662 RID: 5730
		private uint? _point;

		// Token: 0x04001663 RID: 5731
		private uint? _week;

		// Token: 0x04001664 RID: 5732
		private uint? _unused_win;

		// Token: 0x04001665 RID: 5733
		private uint? _unused_lose;

		// Token: 0x04001666 RID: 5734
		private uint? _unused_continuewin;

		// Token: 0x04001667 RID: 5735
		private uint? _honorpoint;

		// Token: 0x04001668 RID: 5736
		private readonly List<uint> _boxtaken = new List<uint>();

		// Token: 0x04001669 RID: 5737
		private readonly List<PkOneRecord> _records = new List<PkOneRecord>();

		// Token: 0x0400166A RID: 5738
		private uint? _unused_continuelose;

		// Token: 0x0400166B RID: 5739
		private readonly List<uint> _prowin = new List<uint>();

		// Token: 0x0400166C RID: 5740
		private readonly List<uint> _prolose = new List<uint>();

		// Token: 0x0400166D RID: 5741
		private uint? _unused_lastwin;

		// Token: 0x0400166E RID: 5742
		private uint? _unused_lastlose;

		// Token: 0x0400166F RID: 5743
		private readonly List<uint> _prodraw = new List<uint>();

		// Token: 0x04001670 RID: 5744
		private uint? _unused_draw;

		// Token: 0x04001671 RID: 5745
		private uint? _pointlastlose;

		// Token: 0x04001672 RID: 5746
		private uint? _day;

		// Token: 0x04001673 RID: 5747
		private uint? _rewardcounttoday;

		// Token: 0x04001674 RID: 5748
		private uint? _todayplaytime;

		// Token: 0x04001675 RID: 5749
		private PkBaseHist _histweek = null;

		// Token: 0x04001676 RID: 5750
		private PkBaseHist _histall = null;

		// Token: 0x04001677 RID: 5751
		private uint? _pkdaytimes;

		// Token: 0x04001678 RID: 5752
		private uint? _weektimes;

		// Token: 0x04001679 RID: 5753
		private uint? _last7daystime;

		// Token: 0x0400167A RID: 5754
		private PkRecordSubInfo _info2v2 = null;

		// Token: 0x0400167B RID: 5755
		private uint? _oneweekresettime;

		// Token: 0x0400167C RID: 5756
		private uint? _lastweekpoint;

		// Token: 0x0400167D RID: 5757
		private PkBaseHist _histday = null;

		// Token: 0x0400167E RID: 5758
		private IExtension extensionObject;
	}
}
