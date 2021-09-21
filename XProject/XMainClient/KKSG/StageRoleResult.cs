using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D0 RID: 1488
	[ProtoContract(Name = "StageRoleResult")]
	[Serializable]
	public class StageRoleResult : IExtensible
	{
		// Token: 0x17001A07 RID: 6663
		// (get) Token: 0x06005413 RID: 21523 RVA: 0x0009FFC4 File Offset: 0x0009E1C4
		// (set) Token: 0x06005414 RID: 21524 RVA: 0x0009FFF0 File Offset: 0x0009E1F0
		[ProtoMember(1, IsRequired = false, Name = "money", DataFormat = DataFormat.TwosComplement)]
		public uint money
		{
			get
			{
				return this._money ?? 0U;
			}
			set
			{
				this._money = new uint?(value);
			}
		}

		// Token: 0x17001A08 RID: 6664
		// (get) Token: 0x06005415 RID: 21525 RVA: 0x000A0000 File Offset: 0x0009E200
		// (set) Token: 0x06005416 RID: 21526 RVA: 0x000A0020 File Offset: 0x0009E220
		[XmlIgnore]
		[Browsable(false)]
		public bool moneySpecified
		{
			get
			{
				return this._money != null;
			}
			set
			{
				bool flag = value == (this._money == null);
				if (flag)
				{
					this._money = (value ? new uint?(this.money) : null);
				}
			}
		}

		// Token: 0x06005417 RID: 21527 RVA: 0x000A0064 File Offset: 0x0009E264
		private bool ShouldSerializemoney()
		{
			return this.moneySpecified;
		}

		// Token: 0x06005418 RID: 21528 RVA: 0x000A007C File Offset: 0x0009E27C
		private void Resetmoney()
		{
			this.moneySpecified = false;
		}

		// Token: 0x17001A09 RID: 6665
		// (get) Token: 0x06005419 RID: 21529 RVA: 0x000A0088 File Offset: 0x0009E288
		// (set) Token: 0x0600541A RID: 21530 RVA: 0x000A00B4 File Offset: 0x0009E2B4
		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x17001A0A RID: 6666
		// (get) Token: 0x0600541B RID: 21531 RVA: 0x000A00C4 File Offset: 0x0009E2C4
		// (set) Token: 0x0600541C RID: 21532 RVA: 0x000A00E4 File Offset: 0x0009E2E4
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x0600541D RID: 21533 RVA: 0x000A0128 File Offset: 0x0009E328
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x0600541E RID: 21534 RVA: 0x000A0140 File Offset: 0x0009E340
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x17001A0B RID: 6667
		// (get) Token: 0x0600541F RID: 21535 RVA: 0x000A014C File Offset: 0x0009E34C
		// (set) Token: 0x06005420 RID: 21536 RVA: 0x000A0178 File Offset: 0x0009E378
		[ProtoMember(3, IsRequired = false, Name = "stars", DataFormat = DataFormat.TwosComplement)]
		public uint stars
		{
			get
			{
				return this._stars ?? 0U;
			}
			set
			{
				this._stars = new uint?(value);
			}
		}

		// Token: 0x17001A0C RID: 6668
		// (get) Token: 0x06005421 RID: 21537 RVA: 0x000A0188 File Offset: 0x0009E388
		// (set) Token: 0x06005422 RID: 21538 RVA: 0x000A01A8 File Offset: 0x0009E3A8
		[XmlIgnore]
		[Browsable(false)]
		public bool starsSpecified
		{
			get
			{
				return this._stars != null;
			}
			set
			{
				bool flag = value == (this._stars == null);
				if (flag)
				{
					this._stars = (value ? new uint?(this.stars) : null);
				}
			}
		}

		// Token: 0x06005423 RID: 21539 RVA: 0x000A01EC File Offset: 0x0009E3EC
		private bool ShouldSerializestars()
		{
			return this.starsSpecified;
		}

		// Token: 0x06005424 RID: 21540 RVA: 0x000A0204 File Offset: 0x0009E404
		private void Resetstars()
		{
			this.starsSpecified = false;
		}

		// Token: 0x17001A0D RID: 6669
		// (get) Token: 0x06005425 RID: 21541 RVA: 0x000A0210 File Offset: 0x0009E410
		// (set) Token: 0x06005426 RID: 21542 RVA: 0x000A023C File Offset: 0x0009E43C
		[ProtoMember(4, IsRequired = false, Name = "firststars", DataFormat = DataFormat.TwosComplement)]
		public uint firststars
		{
			get
			{
				return this._firststars ?? 0U;
			}
			set
			{
				this._firststars = new uint?(value);
			}
		}

		// Token: 0x17001A0E RID: 6670
		// (get) Token: 0x06005427 RID: 21543 RVA: 0x000A024C File Offset: 0x0009E44C
		// (set) Token: 0x06005428 RID: 21544 RVA: 0x000A026C File Offset: 0x0009E46C
		[XmlIgnore]
		[Browsable(false)]
		public bool firststarsSpecified
		{
			get
			{
				return this._firststars != null;
			}
			set
			{
				bool flag = value == (this._firststars == null);
				if (flag)
				{
					this._firststars = (value ? new uint?(this.firststars) : null);
				}
			}
		}

		// Token: 0x06005429 RID: 21545 RVA: 0x000A02B0 File Offset: 0x0009E4B0
		private bool ShouldSerializefirststars()
		{
			return this.firststarsSpecified;
		}

		// Token: 0x0600542A RID: 21546 RVA: 0x000A02C8 File Offset: 0x0009E4C8
		private void Resetfirststars()
		{
			this.firststarsSpecified = false;
		}

		// Token: 0x17001A0F RID: 6671
		// (get) Token: 0x0600542B RID: 21547 RVA: 0x000A02D4 File Offset: 0x0009E4D4
		// (set) Token: 0x0600542C RID: 21548 RVA: 0x000A0300 File Offset: 0x0009E500
		[ProtoMember(5, IsRequired = false, Name = "startLevel", DataFormat = DataFormat.TwosComplement)]
		public uint startLevel
		{
			get
			{
				return this._startLevel ?? 0U;
			}
			set
			{
				this._startLevel = new uint?(value);
			}
		}

		// Token: 0x17001A10 RID: 6672
		// (get) Token: 0x0600542D RID: 21549 RVA: 0x000A0310 File Offset: 0x0009E510
		// (set) Token: 0x0600542E RID: 21550 RVA: 0x000A0330 File Offset: 0x0009E530
		[XmlIgnore]
		[Browsable(false)]
		public bool startLevelSpecified
		{
			get
			{
				return this._startLevel != null;
			}
			set
			{
				bool flag = value == (this._startLevel == null);
				if (flag)
				{
					this._startLevel = (value ? new uint?(this.startLevel) : null);
				}
			}
		}

		// Token: 0x0600542F RID: 21551 RVA: 0x000A0374 File Offset: 0x0009E574
		private bool ShouldSerializestartLevel()
		{
			return this.startLevelSpecified;
		}

		// Token: 0x06005430 RID: 21552 RVA: 0x000A038C File Offset: 0x0009E58C
		private void ResetstartLevel()
		{
			this.startLevelSpecified = false;
		}

		// Token: 0x17001A11 RID: 6673
		// (get) Token: 0x06005431 RID: 21553 RVA: 0x000A0398 File Offset: 0x0009E598
		// (set) Token: 0x06005432 RID: 21554 RVA: 0x000A03C4 File Offset: 0x0009E5C4
		[ProtoMember(6, IsRequired = false, Name = "startExp", DataFormat = DataFormat.TwosComplement)]
		public uint startExp
		{
			get
			{
				return this._startExp ?? 0U;
			}
			set
			{
				this._startExp = new uint?(value);
			}
		}

		// Token: 0x17001A12 RID: 6674
		// (get) Token: 0x06005433 RID: 21555 RVA: 0x000A03D4 File Offset: 0x0009E5D4
		// (set) Token: 0x06005434 RID: 21556 RVA: 0x000A03F4 File Offset: 0x0009E5F4
		[XmlIgnore]
		[Browsable(false)]
		public bool startExpSpecified
		{
			get
			{
				return this._startExp != null;
			}
			set
			{
				bool flag = value == (this._startExp == null);
				if (flag)
				{
					this._startExp = (value ? new uint?(this.startExp) : null);
				}
			}
		}

		// Token: 0x06005435 RID: 21557 RVA: 0x000A0438 File Offset: 0x0009E638
		private bool ShouldSerializestartExp()
		{
			return this.startExpSpecified;
		}

		// Token: 0x06005436 RID: 21558 RVA: 0x000A0450 File Offset: 0x0009E650
		private void ResetstartExp()
		{
			this.startExpSpecified = false;
		}

		// Token: 0x17001A13 RID: 6675
		// (get) Token: 0x06005437 RID: 21559 RVA: 0x000A045C File Offset: 0x0009E65C
		// (set) Token: 0x06005438 RID: 21560 RVA: 0x000A047D File Offset: 0x0009E67D
		[ProtoMember(7, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17001A14 RID: 6676
		// (get) Token: 0x06005439 RID: 21561 RVA: 0x000A0488 File Offset: 0x0009E688
		// (set) Token: 0x0600543A RID: 21562 RVA: 0x000A04A4 File Offset: 0x0009E6A4
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x0600543B RID: 21563 RVA: 0x000A04D4 File Offset: 0x0009E6D4
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x0600543C RID: 21564 RVA: 0x000A04EC File Offset: 0x0009E6EC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001A15 RID: 6677
		// (get) Token: 0x0600543D RID: 21565 RVA: 0x000A04F8 File Offset: 0x0009E6F8
		[ProtoMember(8, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001A16 RID: 6678
		// (get) Token: 0x0600543E RID: 21566 RVA: 0x000A0510 File Offset: 0x0009E710
		[ProtoMember(9, Name = "starreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> starreward
		{
			get
			{
				return this._starreward;
			}
		}

		// Token: 0x17001A17 RID: 6679
		// (get) Token: 0x0600543F RID: 21567 RVA: 0x000A0528 File Offset: 0x0009E728
		// (set) Token: 0x06005440 RID: 21568 RVA: 0x000A0540 File Offset: 0x0009E740
		[ProtoMember(10, IsRequired = false, Name = "guildGoblinResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildGoblinResult guildGoblinResult
		{
			get
			{
				return this._guildGoblinResult;
			}
			set
			{
				this._guildGoblinResult = value;
			}
		}

		// Token: 0x17001A18 RID: 6680
		// (get) Token: 0x06005441 RID: 21569 RVA: 0x000A054C File Offset: 0x0009E74C
		// (set) Token: 0x06005442 RID: 21570 RVA: 0x000A0564 File Offset: 0x0009E764
		[ProtoMember(11, IsRequired = false, Name = "pkresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkResult pkresult
		{
			get
			{
				return this._pkresult;
			}
			set
			{
				this._pkresult = value;
			}
		}

		// Token: 0x17001A19 RID: 6681
		// (get) Token: 0x06005443 RID: 21571 RVA: 0x000A0570 File Offset: 0x0009E770
		// (set) Token: 0x06005444 RID: 21572 RVA: 0x000A059D File Offset: 0x0009E79D
		[ProtoMember(12, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001A1A RID: 6682
		// (get) Token: 0x06005445 RID: 21573 RVA: 0x000A05AC File Offset: 0x0009E7AC
		// (set) Token: 0x06005446 RID: 21574 RVA: 0x000A05CC File Offset: 0x0009E7CC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06005447 RID: 21575 RVA: 0x000A0610 File Offset: 0x0009E810
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06005448 RID: 21576 RVA: 0x000A0628 File Offset: 0x0009E828
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001A1B RID: 6683
		// (get) Token: 0x06005449 RID: 21577 RVA: 0x000A0634 File Offset: 0x0009E834
		// (set) Token: 0x0600544A RID: 21578 RVA: 0x000A0660 File Offset: 0x0009E860
		[ProtoMember(13, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001A1C RID: 6684
		// (get) Token: 0x0600544B RID: 21579 RVA: 0x000A0670 File Offset: 0x0009E870
		// (set) Token: 0x0600544C RID: 21580 RVA: 0x000A0690 File Offset: 0x0009E890
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

		// Token: 0x0600544D RID: 21581 RVA: 0x000A06D4 File Offset: 0x0009E8D4
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x0600544E RID: 21582 RVA: 0x000A06EC File Offset: 0x0009E8EC
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001A1D RID: 6685
		// (get) Token: 0x0600544F RID: 21583 RVA: 0x000A06F8 File Offset: 0x0009E8F8
		// (set) Token: 0x06005450 RID: 21584 RVA: 0x000A0728 File Offset: 0x0009E928
		[ProtoMember(14, IsRequired = false, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public float damage
		{
			get
			{
				return this._damage ?? 0f;
			}
			set
			{
				this._damage = new float?(value);
			}
		}

		// Token: 0x17001A1E RID: 6686
		// (get) Token: 0x06005451 RID: 21585 RVA: 0x000A0738 File Offset: 0x0009E938
		// (set) Token: 0x06005452 RID: 21586 RVA: 0x000A0758 File Offset: 0x0009E958
		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new float?(this.damage) : null);
				}
			}
		}

		// Token: 0x06005453 RID: 21587 RVA: 0x000A079C File Offset: 0x0009E99C
		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		// Token: 0x06005454 RID: 21588 RVA: 0x000A07B4 File Offset: 0x0009E9B4
		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		// Token: 0x17001A1F RID: 6687
		// (get) Token: 0x06005455 RID: 21589 RVA: 0x000A07C0 File Offset: 0x0009E9C0
		// (set) Token: 0x06005456 RID: 21590 RVA: 0x000A07EC File Offset: 0x0009E9EC
		[ProtoMember(15, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		// Token: 0x17001A20 RID: 6688
		// (get) Token: 0x06005457 RID: 21591 RVA: 0x000A07FC File Offset: 0x0009E9FC
		// (set) Token: 0x06005458 RID: 21592 RVA: 0x000A081C File Offset: 0x0009EA1C
		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		// Token: 0x06005459 RID: 21593 RVA: 0x000A0860 File Offset: 0x0009EA60
		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		// Token: 0x0600545A RID: 21594 RVA: 0x000A0878 File Offset: 0x0009EA78
		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		// Token: 0x17001A21 RID: 6689
		// (get) Token: 0x0600545B RID: 21595 RVA: 0x000A0884 File Offset: 0x0009EA84
		// (set) Token: 0x0600545C RID: 21596 RVA: 0x000A08B0 File Offset: 0x0009EAB0
		[ProtoMember(16, IsRequired = false, Name = "maxcombo", DataFormat = DataFormat.TwosComplement)]
		public uint maxcombo
		{
			get
			{
				return this._maxcombo ?? 0U;
			}
			set
			{
				this._maxcombo = new uint?(value);
			}
		}

		// Token: 0x17001A22 RID: 6690
		// (get) Token: 0x0600545D RID: 21597 RVA: 0x000A08C0 File Offset: 0x0009EAC0
		// (set) Token: 0x0600545E RID: 21598 RVA: 0x000A08E0 File Offset: 0x0009EAE0
		[XmlIgnore]
		[Browsable(false)]
		public bool maxcomboSpecified
		{
			get
			{
				return this._maxcombo != null;
			}
			set
			{
				bool flag = value == (this._maxcombo == null);
				if (flag)
				{
					this._maxcombo = (value ? new uint?(this.maxcombo) : null);
				}
			}
		}

		// Token: 0x0600545F RID: 21599 RVA: 0x000A0924 File Offset: 0x0009EB24
		private bool ShouldSerializemaxcombo()
		{
			return this.maxcomboSpecified;
		}

		// Token: 0x06005460 RID: 21600 RVA: 0x000A093C File Offset: 0x0009EB3C
		private void Resetmaxcombo()
		{
			this.maxcomboSpecified = false;
		}

		// Token: 0x17001A23 RID: 6691
		// (get) Token: 0x06005461 RID: 21601 RVA: 0x000A0948 File Offset: 0x0009EB48
		// (set) Token: 0x06005462 RID: 21602 RVA: 0x000A0974 File Offset: 0x0009EB74
		[ProtoMember(17, IsRequired = false, Name = "vipscore", DataFormat = DataFormat.TwosComplement)]
		public uint vipscore
		{
			get
			{
				return this._vipscore ?? 0U;
			}
			set
			{
				this._vipscore = new uint?(value);
			}
		}

		// Token: 0x17001A24 RID: 6692
		// (get) Token: 0x06005463 RID: 21603 RVA: 0x000A0984 File Offset: 0x0009EB84
		// (set) Token: 0x06005464 RID: 21604 RVA: 0x000A09A4 File Offset: 0x0009EBA4
		[XmlIgnore]
		[Browsable(false)]
		public bool vipscoreSpecified
		{
			get
			{
				return this._vipscore != null;
			}
			set
			{
				bool flag = value == (this._vipscore == null);
				if (flag)
				{
					this._vipscore = (value ? new uint?(this.vipscore) : null);
				}
			}
		}

		// Token: 0x06005465 RID: 21605 RVA: 0x000A09E8 File Offset: 0x0009EBE8
		private bool ShouldSerializevipscore()
		{
			return this.vipscoreSpecified;
		}

		// Token: 0x06005466 RID: 21606 RVA: 0x000A0A00 File Offset: 0x0009EC00
		private void Resetvipscore()
		{
			this.vipscoreSpecified = false;
		}

		// Token: 0x17001A25 RID: 6693
		// (get) Token: 0x06005467 RID: 21607 RVA: 0x000A0A0C File Offset: 0x0009EC0C
		// (set) Token: 0x06005468 RID: 21608 RVA: 0x000A0A38 File Offset: 0x0009EC38
		[ProtoMember(18, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public int viplevel
		{
			get
			{
				return this._viplevel ?? 0;
			}
			set
			{
				this._viplevel = new int?(value);
			}
		}

		// Token: 0x17001A26 RID: 6694
		// (get) Token: 0x06005469 RID: 21609 RVA: 0x000A0A48 File Offset: 0x0009EC48
		// (set) Token: 0x0600546A RID: 21610 RVA: 0x000A0A68 File Offset: 0x0009EC68
		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new int?(this.viplevel) : null);
				}
			}
		}

		// Token: 0x0600546B RID: 21611 RVA: 0x000A0AAC File Offset: 0x0009ECAC
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x0600546C RID: 21612 RVA: 0x000A0AC4 File Offset: 0x0009ECC4
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x17001A27 RID: 6695
		// (get) Token: 0x0600546D RID: 21613 RVA: 0x000A0AD0 File Offset: 0x0009ECD0
		// (set) Token: 0x0600546E RID: 21614 RVA: 0x000A0AFC File Offset: 0x0009ECFC
		[ProtoMember(19, IsRequired = false, Name = "endlevel", DataFormat = DataFormat.TwosComplement)]
		public uint endlevel
		{
			get
			{
				return this._endlevel ?? 0U;
			}
			set
			{
				this._endlevel = new uint?(value);
			}
		}

		// Token: 0x17001A28 RID: 6696
		// (get) Token: 0x0600546F RID: 21615 RVA: 0x000A0B0C File Offset: 0x0009ED0C
		// (set) Token: 0x06005470 RID: 21616 RVA: 0x000A0B2C File Offset: 0x0009ED2C
		[XmlIgnore]
		[Browsable(false)]
		public bool endlevelSpecified
		{
			get
			{
				return this._endlevel != null;
			}
			set
			{
				bool flag = value == (this._endlevel == null);
				if (flag)
				{
					this._endlevel = (value ? new uint?(this.endlevel) : null);
				}
			}
		}

		// Token: 0x06005471 RID: 21617 RVA: 0x000A0B70 File Offset: 0x0009ED70
		private bool ShouldSerializeendlevel()
		{
			return this.endlevelSpecified;
		}

		// Token: 0x06005472 RID: 21618 RVA: 0x000A0B88 File Offset: 0x0009ED88
		private void Resetendlevel()
		{
			this.endlevelSpecified = false;
		}

		// Token: 0x17001A29 RID: 6697
		// (get) Token: 0x06005473 RID: 21619 RVA: 0x000A0B94 File Offset: 0x0009ED94
		// (set) Token: 0x06005474 RID: 21620 RVA: 0x000A0BC0 File Offset: 0x0009EDC0
		[ProtoMember(20, IsRequired = false, Name = "endexp", DataFormat = DataFormat.TwosComplement)]
		public uint endexp
		{
			get
			{
				return this._endexp ?? 0U;
			}
			set
			{
				this._endexp = new uint?(value);
			}
		}

		// Token: 0x17001A2A RID: 6698
		// (get) Token: 0x06005475 RID: 21621 RVA: 0x000A0BD0 File Offset: 0x0009EDD0
		// (set) Token: 0x06005476 RID: 21622 RVA: 0x000A0BF0 File Offset: 0x0009EDF0
		[XmlIgnore]
		[Browsable(false)]
		public bool endexpSpecified
		{
			get
			{
				return this._endexp != null;
			}
			set
			{
				bool flag = value == (this._endexp == null);
				if (flag)
				{
					this._endexp = (value ? new uint?(this.endexp) : null);
				}
			}
		}

		// Token: 0x06005477 RID: 21623 RVA: 0x000A0C34 File Offset: 0x0009EE34
		private bool ShouldSerializeendexp()
		{
			return this.endexpSpecified;
		}

		// Token: 0x06005478 RID: 21624 RVA: 0x000A0C4C File Offset: 0x0009EE4C
		private void Resetendexp()
		{
			this.endexpSpecified = false;
		}

		// Token: 0x17001A2B RID: 6699
		// (get) Token: 0x06005479 RID: 21625 RVA: 0x000A0C58 File Offset: 0x0009EE58
		// (set) Token: 0x0600547A RID: 21626 RVA: 0x000A0C85 File Offset: 0x0009EE85
		[ProtoMember(21, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		// Token: 0x17001A2C RID: 6700
		// (get) Token: 0x0600547B RID: 21627 RVA: 0x000A0C94 File Offset: 0x0009EE94
		// (set) Token: 0x0600547C RID: 21628 RVA: 0x000A0CB4 File Offset: 0x0009EEB4
		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		// Token: 0x0600547D RID: 21629 RVA: 0x000A0CF8 File Offset: 0x0009EEF8
		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		// Token: 0x0600547E RID: 21630 RVA: 0x000A0D10 File Offset: 0x0009EF10
		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		// Token: 0x17001A2D RID: 6701
		// (get) Token: 0x0600547F RID: 21631 RVA: 0x000A0D1C File Offset: 0x0009EF1C
		// (set) Token: 0x06005480 RID: 21632 RVA: 0x000A0D48 File Offset: 0x0009EF48
		[ProtoMember(22, IsRequired = false, Name = "isLeader", DataFormat = DataFormat.Default)]
		public bool isLeader
		{
			get
			{
				return this._isLeader ?? false;
			}
			set
			{
				this._isLeader = new bool?(value);
			}
		}

		// Token: 0x17001A2E RID: 6702
		// (get) Token: 0x06005481 RID: 21633 RVA: 0x000A0D58 File Offset: 0x0009EF58
		// (set) Token: 0x06005482 RID: 21634 RVA: 0x000A0D78 File Offset: 0x0009EF78
		[XmlIgnore]
		[Browsable(false)]
		public bool isLeaderSpecified
		{
			get
			{
				return this._isLeader != null;
			}
			set
			{
				bool flag = value == (this._isLeader == null);
				if (flag)
				{
					this._isLeader = (value ? new bool?(this.isLeader) : null);
				}
			}
		}

		// Token: 0x06005483 RID: 21635 RVA: 0x000A0DBC File Offset: 0x0009EFBC
		private bool ShouldSerializeisLeader()
		{
			return this.isLeaderSpecified;
		}

		// Token: 0x06005484 RID: 21636 RVA: 0x000A0DD4 File Offset: 0x0009EFD4
		private void ResetisLeader()
		{
			this.isLeaderSpecified = false;
		}

		// Token: 0x17001A2F RID: 6703
		// (get) Token: 0x06005485 RID: 21637 RVA: 0x000A0DE0 File Offset: 0x0009EFE0
		// (set) Token: 0x06005486 RID: 21638 RVA: 0x000A0E0C File Offset: 0x0009F00C
		[ProtoMember(23, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		// Token: 0x17001A30 RID: 6704
		// (get) Token: 0x06005487 RID: 21639 RVA: 0x000A0E1C File Offset: 0x0009F01C
		// (set) Token: 0x06005488 RID: 21640 RVA: 0x000A0E3C File Offset: 0x0009F03C
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		// Token: 0x06005489 RID: 21641 RVA: 0x000A0E80 File Offset: 0x0009F080
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x0600548A RID: 21642 RVA: 0x000A0E98 File Offset: 0x0009F098
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001A31 RID: 6705
		// (get) Token: 0x0600548B RID: 21643 RVA: 0x000A0EA4 File Offset: 0x0009F0A4
		// (set) Token: 0x0600548C RID: 21644 RVA: 0x000A0EBC File Offset: 0x0009F0BC
		[ProtoMember(24, IsRequired = false, Name = "towerResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TowerResult towerResult
		{
			get
			{
				return this._towerResult;
			}
			set
			{
				this._towerResult = value;
			}
		}

		// Token: 0x17001A32 RID: 6706
		// (get) Token: 0x0600548D RID: 21645 RVA: 0x000A0EC8 File Offset: 0x0009F0C8
		// (set) Token: 0x0600548E RID: 21646 RVA: 0x000A0EF4 File Offset: 0x0009F0F4
		[ProtoMember(25, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public int killcount
		{
			get
			{
				return this._killcount ?? 0;
			}
			set
			{
				this._killcount = new int?(value);
			}
		}

		// Token: 0x17001A33 RID: 6707
		// (get) Token: 0x0600548F RID: 21647 RVA: 0x000A0F04 File Offset: 0x0009F104
		// (set) Token: 0x06005490 RID: 21648 RVA: 0x000A0F24 File Offset: 0x0009F124
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new int?(this.killcount) : null);
				}
			}
		}

		// Token: 0x06005491 RID: 21649 RVA: 0x000A0F68 File Offset: 0x0009F168
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06005492 RID: 21650 RVA: 0x000A0F80 File Offset: 0x0009F180
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17001A34 RID: 6708
		// (get) Token: 0x06005493 RID: 21651 RVA: 0x000A0F8C File Offset: 0x0009F18C
		// (set) Token: 0x06005494 RID: 21652 RVA: 0x000A0FB8 File Offset: 0x0009F1B8
		[ProtoMember(26, IsRequired = false, Name = "killcontinuemax", DataFormat = DataFormat.TwosComplement)]
		public int killcontinuemax
		{
			get
			{
				return this._killcontinuemax ?? 0;
			}
			set
			{
				this._killcontinuemax = new int?(value);
			}
		}

		// Token: 0x17001A35 RID: 6709
		// (get) Token: 0x06005495 RID: 21653 RVA: 0x000A0FC8 File Offset: 0x0009F1C8
		// (set) Token: 0x06005496 RID: 21654 RVA: 0x000A0FE8 File Offset: 0x0009F1E8
		[XmlIgnore]
		[Browsable(false)]
		public bool killcontinuemaxSpecified
		{
			get
			{
				return this._killcontinuemax != null;
			}
			set
			{
				bool flag = value == (this._killcontinuemax == null);
				if (flag)
				{
					this._killcontinuemax = (value ? new int?(this.killcontinuemax) : null);
				}
			}
		}

		// Token: 0x06005497 RID: 21655 RVA: 0x000A102C File Offset: 0x0009F22C
		private bool ShouldSerializekillcontinuemax()
		{
			return this.killcontinuemaxSpecified;
		}

		// Token: 0x06005498 RID: 21656 RVA: 0x000A1044 File Offset: 0x0009F244
		private void Resetkillcontinuemax()
		{
			this.killcontinuemaxSpecified = false;
		}

		// Token: 0x17001A36 RID: 6710
		// (get) Token: 0x06005499 RID: 21657 RVA: 0x000A1050 File Offset: 0x0009F250
		// (set) Token: 0x0600549A RID: 21658 RVA: 0x000A1080 File Offset: 0x0009F280
		[ProtoMember(27, IsRequired = false, Name = "treat", DataFormat = DataFormat.FixedSize)]
		public float treat
		{
			get
			{
				return this._treat ?? 0f;
			}
			set
			{
				this._treat = new float?(value);
			}
		}

		// Token: 0x17001A37 RID: 6711
		// (get) Token: 0x0600549B RID: 21659 RVA: 0x000A1090 File Offset: 0x0009F290
		// (set) Token: 0x0600549C RID: 21660 RVA: 0x000A10B0 File Offset: 0x0009F2B0
		[XmlIgnore]
		[Browsable(false)]
		public bool treatSpecified
		{
			get
			{
				return this._treat != null;
			}
			set
			{
				bool flag = value == (this._treat == null);
				if (flag)
				{
					this._treat = (value ? new float?(this.treat) : null);
				}
			}
		}

		// Token: 0x0600549D RID: 21661 RVA: 0x000A10F4 File Offset: 0x0009F2F4
		private bool ShouldSerializetreat()
		{
			return this.treatSpecified;
		}

		// Token: 0x0600549E RID: 21662 RVA: 0x000A110C File Offset: 0x0009F30C
		private void Resettreat()
		{
			this.treatSpecified = false;
		}

		// Token: 0x17001A38 RID: 6712
		// (get) Token: 0x0600549F RID: 21663 RVA: 0x000A1118 File Offset: 0x0009F318
		// (set) Token: 0x060054A0 RID: 21664 RVA: 0x000A1130 File Offset: 0x0009F330
		[ProtoMember(28, IsRequired = false, Name = "pvpresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PVPResult pvpresult
		{
			get
			{
				return this._pvpresult;
			}
			set
			{
				this._pvpresult = value;
			}
		}

		// Token: 0x17001A39 RID: 6713
		// (get) Token: 0x060054A1 RID: 21665 RVA: 0x000A113C File Offset: 0x0009F33C
		[ProtoMember(29, Name = "box", DataFormat = DataFormat.Default)]
		public List<BattleRewardChest> box
		{
			get
			{
				return this._box;
			}
		}

		// Token: 0x17001A3A RID: 6714
		// (get) Token: 0x060054A2 RID: 21666 RVA: 0x000A1154 File Offset: 0x0009F354
		[ProtoMember(30, Name = "guildreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> guildreward
		{
			get
			{
				return this._guildreward;
			}
		}

		// Token: 0x17001A3B RID: 6715
		// (get) Token: 0x060054A3 RID: 21667 RVA: 0x000A116C File Offset: 0x0009F36C
		// (set) Token: 0x060054A4 RID: 21668 RVA: 0x000A1198 File Offset: 0x0009F398
		[ProtoMember(31, IsRequired = false, Name = "ishelper", DataFormat = DataFormat.Default)]
		public bool ishelper
		{
			get
			{
				return this._ishelper ?? false;
			}
			set
			{
				this._ishelper = new bool?(value);
			}
		}

		// Token: 0x17001A3C RID: 6716
		// (get) Token: 0x060054A5 RID: 21669 RVA: 0x000A11A8 File Offset: 0x0009F3A8
		// (set) Token: 0x060054A6 RID: 21670 RVA: 0x000A11C8 File Offset: 0x0009F3C8
		[XmlIgnore]
		[Browsable(false)]
		public bool ishelperSpecified
		{
			get
			{
				return this._ishelper != null;
			}
			set
			{
				bool flag = value == (this._ishelper == null);
				if (flag)
				{
					this._ishelper = (value ? new bool?(this.ishelper) : null);
				}
			}
		}

		// Token: 0x060054A7 RID: 21671 RVA: 0x000A120C File Offset: 0x0009F40C
		private bool ShouldSerializeishelper()
		{
			return this.ishelperSpecified;
		}

		// Token: 0x060054A8 RID: 21672 RVA: 0x000A1224 File Offset: 0x0009F424
		private void Resetishelper()
		{
			this.ishelperSpecified = false;
		}

		// Token: 0x17001A3D RID: 6717
		// (get) Token: 0x060054A9 RID: 21673 RVA: 0x000A1230 File Offset: 0x0009F430
		// (set) Token: 0x060054AA RID: 21674 RVA: 0x000A1248 File Offset: 0x0009F448
		[ProtoMember(32, IsRequired = false, Name = "deresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonExpResult deresult
		{
			get
			{
				return this._deresult;
			}
			set
			{
				this._deresult = value;
			}
		}

		// Token: 0x17001A3E RID: 6718
		// (get) Token: 0x060054AB RID: 21675 RVA: 0x000A1254 File Offset: 0x0009F454
		// (set) Token: 0x060054AC RID: 21676 RVA: 0x000A126C File Offset: 0x0009F46C
		[ProtoMember(33, IsRequired = false, Name = "skycity", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityFinalInfo skycity
		{
			get
			{
				return this._skycity;
			}
			set
			{
				this._skycity = value;
			}
		}

		// Token: 0x17001A3F RID: 6719
		// (get) Token: 0x060054AD RID: 21677 RVA: 0x000A1278 File Offset: 0x0009F478
		// (set) Token: 0x060054AE RID: 21678 RVA: 0x000A12A4 File Offset: 0x0009F4A4
		[ProtoMember(34, IsRequired = false, Name = "isexpseal", DataFormat = DataFormat.Default)]
		public bool isexpseal
		{
			get
			{
				return this._isexpseal ?? false;
			}
			set
			{
				this._isexpseal = new bool?(value);
			}
		}

		// Token: 0x17001A40 RID: 6720
		// (get) Token: 0x060054AF RID: 21679 RVA: 0x000A12B4 File Offset: 0x0009F4B4
		// (set) Token: 0x060054B0 RID: 21680 RVA: 0x000A12D4 File Offset: 0x0009F4D4
		[XmlIgnore]
		[Browsable(false)]
		public bool isexpsealSpecified
		{
			get
			{
				return this._isexpseal != null;
			}
			set
			{
				bool flag = value == (this._isexpseal == null);
				if (flag)
				{
					this._isexpseal = (value ? new bool?(this.isexpseal) : null);
				}
			}
		}

		// Token: 0x060054B1 RID: 21681 RVA: 0x000A1318 File Offset: 0x0009F518
		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		// Token: 0x060054B2 RID: 21682 RVA: 0x000A1330 File Offset: 0x0009F530
		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		// Token: 0x17001A41 RID: 6721
		// (get) Token: 0x060054B3 RID: 21683 RVA: 0x000A133C File Offset: 0x0009F53C
		// (set) Token: 0x060054B4 RID: 21684 RVA: 0x000A1368 File Offset: 0x0009F568
		[ProtoMember(35, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
		public uint guildexp
		{
			get
			{
				return this._guildexp ?? 0U;
			}
			set
			{
				this._guildexp = new uint?(value);
			}
		}

		// Token: 0x17001A42 RID: 6722
		// (get) Token: 0x060054B5 RID: 21685 RVA: 0x000A1378 File Offset: 0x0009F578
		// (set) Token: 0x060054B6 RID: 21686 RVA: 0x000A1398 File Offset: 0x0009F598
		[XmlIgnore]
		[Browsable(false)]
		public bool guildexpSpecified
		{
			get
			{
				return this._guildexp != null;
			}
			set
			{
				bool flag = value == (this._guildexp == null);
				if (flag)
				{
					this._guildexp = (value ? new uint?(this.guildexp) : null);
				}
			}
		}

		// Token: 0x060054B7 RID: 21687 RVA: 0x000A13DC File Offset: 0x0009F5DC
		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		// Token: 0x060054B8 RID: 21688 RVA: 0x000A13F4 File Offset: 0x0009F5F4
		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		// Token: 0x17001A43 RID: 6723
		// (get) Token: 0x060054B9 RID: 21689 RVA: 0x000A1400 File Offset: 0x0009F600
		// (set) Token: 0x060054BA RID: 21690 RVA: 0x000A142C File Offset: 0x0009F62C
		[ProtoMember(36, IsRequired = false, Name = "guildcon", DataFormat = DataFormat.TwosComplement)]
		public uint guildcon
		{
			get
			{
				return this._guildcon ?? 0U;
			}
			set
			{
				this._guildcon = new uint?(value);
			}
		}

		// Token: 0x17001A44 RID: 6724
		// (get) Token: 0x060054BB RID: 21691 RVA: 0x000A143C File Offset: 0x0009F63C
		// (set) Token: 0x060054BC RID: 21692 RVA: 0x000A145C File Offset: 0x0009F65C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildconSpecified
		{
			get
			{
				return this._guildcon != null;
			}
			set
			{
				bool flag = value == (this._guildcon == null);
				if (flag)
				{
					this._guildcon = (value ? new uint?(this.guildcon) : null);
				}
			}
		}

		// Token: 0x060054BD RID: 21693 RVA: 0x000A14A0 File Offset: 0x0009F6A0
		private bool ShouldSerializeguildcon()
		{
			return this.guildconSpecified;
		}

		// Token: 0x060054BE RID: 21694 RVA: 0x000A14B8 File Offset: 0x0009F6B8
		private void Resetguildcon()
		{
			this.guildconSpecified = false;
		}

		// Token: 0x17001A45 RID: 6725
		// (get) Token: 0x060054BF RID: 21695 RVA: 0x000A14C4 File Offset: 0x0009F6C4
		// (set) Token: 0x060054C0 RID: 21696 RVA: 0x000A14F0 File Offset: 0x0009F6F0
		[ProtoMember(37, IsRequired = false, Name = "guilddargon", DataFormat = DataFormat.TwosComplement)]
		public uint guilddargon
		{
			get
			{
				return this._guilddargon ?? 0U;
			}
			set
			{
				this._guilddargon = new uint?(value);
			}
		}

		// Token: 0x17001A46 RID: 6726
		// (get) Token: 0x060054C1 RID: 21697 RVA: 0x000A1500 File Offset: 0x0009F700
		// (set) Token: 0x060054C2 RID: 21698 RVA: 0x000A1520 File Offset: 0x0009F720
		[XmlIgnore]
		[Browsable(false)]
		public bool guilddargonSpecified
		{
			get
			{
				return this._guilddargon != null;
			}
			set
			{
				bool flag = value == (this._guilddargon == null);
				if (flag)
				{
					this._guilddargon = (value ? new uint?(this.guilddargon) : null);
				}
			}
		}

		// Token: 0x060054C3 RID: 21699 RVA: 0x000A1564 File Offset: 0x0009F764
		private bool ShouldSerializeguilddargon()
		{
			return this.guilddargonSpecified;
		}

		// Token: 0x060054C4 RID: 21700 RVA: 0x000A157C File Offset: 0x0009F77C
		private void Resetguilddargon()
		{
			this.guilddargonSpecified = false;
		}

		// Token: 0x17001A47 RID: 6727
		// (get) Token: 0x060054C5 RID: 21701 RVA: 0x000A1588 File Offset: 0x0009F788
		// (set) Token: 0x060054C6 RID: 21702 RVA: 0x000A15B4 File Offset: 0x0009F7B4
		[ProtoMember(38, IsRequired = false, Name = "reswar", DataFormat = DataFormat.TwosComplement)]
		public uint reswar
		{
			get
			{
				return this._reswar ?? 0U;
			}
			set
			{
				this._reswar = new uint?(value);
			}
		}

		// Token: 0x17001A48 RID: 6728
		// (get) Token: 0x060054C7 RID: 21703 RVA: 0x000A15C4 File Offset: 0x0009F7C4
		// (set) Token: 0x060054C8 RID: 21704 RVA: 0x000A15E4 File Offset: 0x0009F7E4
		[XmlIgnore]
		[Browsable(false)]
		public bool reswarSpecified
		{
			get
			{
				return this._reswar != null;
			}
			set
			{
				bool flag = value == (this._reswar == null);
				if (flag)
				{
					this._reswar = (value ? new uint?(this.reswar) : null);
				}
			}
		}

		// Token: 0x060054C9 RID: 21705 RVA: 0x000A1628 File Offset: 0x0009F828
		private bool ShouldSerializereswar()
		{
			return this.reswarSpecified;
		}

		// Token: 0x060054CA RID: 21706 RVA: 0x000A1640 File Offset: 0x0009F840
		private void Resetreswar()
		{
			this.reswarSpecified = false;
		}

		// Token: 0x17001A49 RID: 6729
		// (get) Token: 0x060054CB RID: 21707 RVA: 0x000A164C File Offset: 0x0009F84C
		// (set) Token: 0x060054CC RID: 21708 RVA: 0x000A1664 File Offset: 0x0009F864
		[ProtoMember(39, IsRequired = false, Name = "teamcostreward", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief teamcostreward
		{
			get
			{
				return this._teamcostreward;
			}
			set
			{
				this._teamcostreward = value;
			}
		}

		// Token: 0x17001A4A RID: 6730
		// (get) Token: 0x060054CD RID: 21709 RVA: 0x000A1670 File Offset: 0x0009F870
		// (set) Token: 0x060054CE RID: 21710 RVA: 0x000A169C File Offset: 0x0009F89C
		[ProtoMember(40, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x17001A4B RID: 6731
		// (get) Token: 0x060054CF RID: 21711 RVA: 0x000A16AC File Offset: 0x0009F8AC
		// (set) Token: 0x060054D0 RID: 21712 RVA: 0x000A16CC File Offset: 0x0009F8CC
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x060054D1 RID: 21713 RVA: 0x000A1710 File Offset: 0x0009F910
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x060054D2 RID: 21714 RVA: 0x000A1728 File Offset: 0x0009F928
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x17001A4C RID: 6732
		// (get) Token: 0x060054D3 RID: 21715 RVA: 0x000A1734 File Offset: 0x0009F934
		// (set) Token: 0x060054D4 RID: 21716 RVA: 0x000A174C File Offset: 0x0009F94C
		[ProtoMember(41, IsRequired = false, Name = "horse", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseAward horse
		{
			get
			{
				return this._horse;
			}
			set
			{
				this._horse = value;
			}
		}

		// Token: 0x17001A4D RID: 6733
		// (get) Token: 0x060054D5 RID: 21717 RVA: 0x000A1758 File Offset: 0x0009F958
		// (set) Token: 0x060054D6 RID: 21718 RVA: 0x000A1770 File Offset: 0x0009F970
		[ProtoMember(42, IsRequired = false, Name = "invfightresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public InvFightBattleResult invfightresult
		{
			get
			{
				return this._invfightresult;
			}
			set
			{
				this._invfightresult = value;
			}
		}

		// Token: 0x17001A4E RID: 6734
		// (get) Token: 0x060054D7 RID: 21719 RVA: 0x000A177C File Offset: 0x0009F97C
		// (set) Token: 0x060054D8 RID: 21720 RVA: 0x000A1794 File Offset: 0x0009F994
		[ProtoMember(43, IsRequired = false, Name = "heroresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroBattleResult heroresult
		{
			get
			{
				return this._heroresult;
			}
			set
			{
				this._heroresult = value;
			}
		}

		// Token: 0x17001A4F RID: 6735
		// (get) Token: 0x060054D9 RID: 21721 RVA: 0x000A17A0 File Offset: 0x0009F9A0
		// (set) Token: 0x060054DA RID: 21722 RVA: 0x000A17CC File Offset: 0x0009F9CC
		[ProtoMember(44, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		// Token: 0x17001A50 RID: 6736
		// (get) Token: 0x060054DB RID: 21723 RVA: 0x000A17DC File Offset: 0x0009F9DC
		// (set) Token: 0x060054DC RID: 21724 RVA: 0x000A17FC File Offset: 0x0009F9FC
		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		// Token: 0x060054DD RID: 21725 RVA: 0x000A1840 File Offset: 0x0009FA40
		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		// Token: 0x060054DE RID: 21726 RVA: 0x000A1858 File Offset: 0x0009FA58
		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		// Token: 0x17001A51 RID: 6737
		// (get) Token: 0x060054DF RID: 21727 RVA: 0x000A1864 File Offset: 0x0009FA64
		// (set) Token: 0x060054E0 RID: 21728 RVA: 0x000A1890 File Offset: 0x0009FA90
		[ProtoMember(45, IsRequired = false, Name = "assitnum", DataFormat = DataFormat.TwosComplement)]
		public uint assitnum
		{
			get
			{
				return this._assitnum ?? 0U;
			}
			set
			{
				this._assitnum = new uint?(value);
			}
		}

		// Token: 0x17001A52 RID: 6738
		// (get) Token: 0x060054E1 RID: 21729 RVA: 0x000A18A0 File Offset: 0x0009FAA0
		// (set) Token: 0x060054E2 RID: 21730 RVA: 0x000A18C0 File Offset: 0x0009FAC0
		[XmlIgnore]
		[Browsable(false)]
		public bool assitnumSpecified
		{
			get
			{
				return this._assitnum != null;
			}
			set
			{
				bool flag = value == (this._assitnum == null);
				if (flag)
				{
					this._assitnum = (value ? new uint?(this.assitnum) : null);
				}
			}
		}

		// Token: 0x060054E3 RID: 21731 RVA: 0x000A1904 File Offset: 0x0009FB04
		private bool ShouldSerializeassitnum()
		{
			return this.assitnumSpecified;
		}

		// Token: 0x060054E4 RID: 21732 RVA: 0x000A191C File Offset: 0x0009FB1C
		private void Resetassitnum()
		{
			this.assitnumSpecified = false;
		}

		// Token: 0x17001A53 RID: 6739
		// (get) Token: 0x060054E5 RID: 21733 RVA: 0x000A1928 File Offset: 0x0009FB28
		// (set) Token: 0x060054E6 RID: 21734 RVA: 0x000A1954 File Offset: 0x0009FB54
		[ProtoMember(46, IsRequired = false, Name = "behitdamage", DataFormat = DataFormat.TwosComplement)]
		public uint behitdamage
		{
			get
			{
				return this._behitdamage ?? 0U;
			}
			set
			{
				this._behitdamage = new uint?(value);
			}
		}

		// Token: 0x17001A54 RID: 6740
		// (get) Token: 0x060054E7 RID: 21735 RVA: 0x000A1964 File Offset: 0x0009FB64
		// (set) Token: 0x060054E8 RID: 21736 RVA: 0x000A1984 File Offset: 0x0009FB84
		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamageSpecified
		{
			get
			{
				return this._behitdamage != null;
			}
			set
			{
				bool flag = value == (this._behitdamage == null);
				if (flag)
				{
					this._behitdamage = (value ? new uint?(this.behitdamage) : null);
				}
			}
		}

		// Token: 0x060054E9 RID: 21737 RVA: 0x000A19C8 File Offset: 0x0009FBC8
		private bool ShouldSerializebehitdamage()
		{
			return this.behitdamageSpecified;
		}

		// Token: 0x060054EA RID: 21738 RVA: 0x000A19E0 File Offset: 0x0009FBE0
		private void Resetbehitdamage()
		{
			this.behitdamageSpecified = false;
		}

		// Token: 0x17001A55 RID: 6741
		// (get) Token: 0x060054EB RID: 21739 RVA: 0x000A19EC File Offset: 0x0009FBEC
		// (set) Token: 0x060054EC RID: 21740 RVA: 0x000A1A18 File Offset: 0x0009FC18
		[ProtoMember(47, IsRequired = false, Name = "multikillcountmax", DataFormat = DataFormat.TwosComplement)]
		public uint multikillcountmax
		{
			get
			{
				return this._multikillcountmax ?? 0U;
			}
			set
			{
				this._multikillcountmax = new uint?(value);
			}
		}

		// Token: 0x17001A56 RID: 6742
		// (get) Token: 0x060054ED RID: 21741 RVA: 0x000A1A28 File Offset: 0x0009FC28
		// (set) Token: 0x060054EE RID: 21742 RVA: 0x000A1A48 File Offset: 0x0009FC48
		[XmlIgnore]
		[Browsable(false)]
		public bool multikillcountmaxSpecified
		{
			get
			{
				return this._multikillcountmax != null;
			}
			set
			{
				bool flag = value == (this._multikillcountmax == null);
				if (flag)
				{
					this._multikillcountmax = (value ? new uint?(this.multikillcountmax) : null);
				}
			}
		}

		// Token: 0x060054EF RID: 21743 RVA: 0x000A1A8C File Offset: 0x0009FC8C
		private bool ShouldSerializemultikillcountmax()
		{
			return this.multikillcountmaxSpecified;
		}

		// Token: 0x060054F0 RID: 21744 RVA: 0x000A1AA4 File Offset: 0x0009FCA4
		private void Resetmultikillcountmax()
		{
			this.multikillcountmaxSpecified = false;
		}

		// Token: 0x17001A57 RID: 6743
		// (get) Token: 0x060054F1 RID: 21745 RVA: 0x000A1AB0 File Offset: 0x0009FCB0
		// (set) Token: 0x060054F2 RID: 21746 RVA: 0x000A1AC8 File Offset: 0x0009FCC8
		[ProtoMember(48, IsRequired = false, Name = "custombattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleResult custombattle
		{
			get
			{
				return this._custombattle;
			}
			set
			{
				this._custombattle = value;
			}
		}

		// Token: 0x17001A58 RID: 6744
		// (get) Token: 0x060054F3 RID: 21747 RVA: 0x000A1AD4 File Offset: 0x0009FCD4
		// (set) Token: 0x060054F4 RID: 21748 RVA: 0x000A1AEC File Offset: 0x0009FCEC
		[ProtoMember(49, IsRequired = false, Name = "mobabattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleRoleResult mobabattle
		{
			get
			{
				return this._mobabattle;
			}
			set
			{
				this._mobabattle = value;
			}
		}

		// Token: 0x17001A59 RID: 6745
		// (get) Token: 0x060054F5 RID: 21749 RVA: 0x000A1AF8 File Offset: 0x0009FCF8
		// (set) Token: 0x060054F6 RID: 21750 RVA: 0x000A1B10 File Offset: 0x0009FD10
		[ProtoMember(50, IsRequired = false, Name = "weekend4v4roledata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeekEnd4v4BattleRoleData weekend4v4roledata
		{
			get
			{
				return this._weekend4v4roledata;
			}
			set
			{
				this._weekend4v4roledata = value;
			}
		}

		// Token: 0x17001A5A RID: 6746
		// (get) Token: 0x060054F7 RID: 21751 RVA: 0x000A1B1C File Offset: 0x0009FD1C
		// (set) Token: 0x060054F8 RID: 21752 RVA: 0x000A1B34 File Offset: 0x0009FD34
		[ProtoMember(51, IsRequired = false, Name = "bigmelee", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BigMeleeBattleResult bigmelee
		{
			get
			{
				return this._bigmelee;
			}
			set
			{
				this._bigmelee = value;
			}
		}

		// Token: 0x17001A5B RID: 6747
		// (get) Token: 0x060054F9 RID: 21753 RVA: 0x000A1B40 File Offset: 0x0009FD40
		// (set) Token: 0x060054FA RID: 21754 RVA: 0x000A1B58 File Offset: 0x0009FD58
		[ProtoMember(52, IsRequired = false, Name = "battlefield", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleFieldBattleResult battlefield
		{
			get
			{
				return this._battlefield;
			}
			set
			{
				this._battlefield = value;
			}
		}

		// Token: 0x17001A5C RID: 6748
		// (get) Token: 0x060054FB RID: 21755 RVA: 0x000A1B64 File Offset: 0x0009FD64
		// (set) Token: 0x060054FC RID: 21756 RVA: 0x000A1B90 File Offset: 0x0009FD90
		[ProtoMember(53, IsRequired = false, Name = "isboxexcept", DataFormat = DataFormat.Default)]
		public bool isboxexcept
		{
			get
			{
				return this._isboxexcept ?? false;
			}
			set
			{
				this._isboxexcept = new bool?(value);
			}
		}

		// Token: 0x17001A5D RID: 6749
		// (get) Token: 0x060054FD RID: 21757 RVA: 0x000A1BA0 File Offset: 0x0009FDA0
		// (set) Token: 0x060054FE RID: 21758 RVA: 0x000A1BC0 File Offset: 0x0009FDC0
		[XmlIgnore]
		[Browsable(false)]
		public bool isboxexceptSpecified
		{
			get
			{
				return this._isboxexcept != null;
			}
			set
			{
				bool flag = value == (this._isboxexcept == null);
				if (flag)
				{
					this._isboxexcept = (value ? new bool?(this.isboxexcept) : null);
				}
			}
		}

		// Token: 0x060054FF RID: 21759 RVA: 0x000A1C04 File Offset: 0x0009FE04
		private bool ShouldSerializeisboxexcept()
		{
			return this.isboxexceptSpecified;
		}

		// Token: 0x06005500 RID: 21760 RVA: 0x000A1C1C File Offset: 0x0009FE1C
		private void Resetisboxexcept()
		{
			this.isboxexceptSpecified = false;
		}

		// Token: 0x17001A5E RID: 6750
		// (get) Token: 0x06005501 RID: 21761 RVA: 0x000A1C28 File Offset: 0x0009FE28
		// (set) Token: 0x06005502 RID: 21762 RVA: 0x000A1C40 File Offset: 0x0009FE40
		[ProtoMember(54, IsRequired = false, Name = "riftResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiftResult riftResult
		{
			get
			{
				return this._riftResult;
			}
			set
			{
				this._riftResult = value;
			}
		}

		// Token: 0x06005503 RID: 21763 RVA: 0x000A1C4C File Offset: 0x0009FE4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001485 RID: 5253
		private uint? _money;

		// Token: 0x04001486 RID: 5254
		private uint? _exp;

		// Token: 0x04001487 RID: 5255
		private uint? _stars;

		// Token: 0x04001488 RID: 5256
		private uint? _firststars;

		// Token: 0x04001489 RID: 5257
		private uint? _startLevel;

		// Token: 0x0400148A RID: 5258
		private uint? _startExp;

		// Token: 0x0400148B RID: 5259
		private string _rolename;

		// Token: 0x0400148C RID: 5260
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x0400148D RID: 5261
		private readonly List<ItemBrief> _starreward = new List<ItemBrief>();

		// Token: 0x0400148E RID: 5262
		private GuildGoblinResult _guildGoblinResult = null;

		// Token: 0x0400148F RID: 5263
		private PkResult _pkresult = null;

		// Token: 0x04001490 RID: 5264
		private ulong? _roleid;

		// Token: 0x04001491 RID: 5265
		private uint? _score;

		// Token: 0x04001492 RID: 5266
		private float? _damage;

		// Token: 0x04001493 RID: 5267
		private uint? _deathcount;

		// Token: 0x04001494 RID: 5268
		private uint? _maxcombo;

		// Token: 0x04001495 RID: 5269
		private uint? _vipscore;

		// Token: 0x04001496 RID: 5270
		private int? _viplevel;

		// Token: 0x04001497 RID: 5271
		private uint? _endlevel;

		// Token: 0x04001498 RID: 5272
		private uint? _endexp;

		// Token: 0x04001499 RID: 5273
		private ulong? _gid;

		// Token: 0x0400149A RID: 5274
		private bool? _isLeader;

		// Token: 0x0400149B RID: 5275
		private int? _profession;

		// Token: 0x0400149C RID: 5276
		private TowerResult _towerResult = null;

		// Token: 0x0400149D RID: 5277
		private int? _killcount;

		// Token: 0x0400149E RID: 5278
		private int? _killcontinuemax;

		// Token: 0x0400149F RID: 5279
		private float? _treat;

		// Token: 0x040014A0 RID: 5280
		private PVPResult _pvpresult = null;

		// Token: 0x040014A1 RID: 5281
		private readonly List<BattleRewardChest> _box = new List<BattleRewardChest>();

		// Token: 0x040014A2 RID: 5282
		private readonly List<ItemBrief> _guildreward = new List<ItemBrief>();

		// Token: 0x040014A3 RID: 5283
		private bool? _ishelper;

		// Token: 0x040014A4 RID: 5284
		private DragonExpResult _deresult = null;

		// Token: 0x040014A5 RID: 5285
		private SkyCityFinalInfo _skycity = null;

		// Token: 0x040014A6 RID: 5286
		private bool? _isexpseal;

		// Token: 0x040014A7 RID: 5287
		private uint? _guildexp;

		// Token: 0x040014A8 RID: 5288
		private uint? _guildcon;

		// Token: 0x040014A9 RID: 5289
		private uint? _guilddargon;

		// Token: 0x040014AA RID: 5290
		private uint? _reswar;

		// Token: 0x040014AB RID: 5291
		private ItemBrief _teamcostreward = null;

		// Token: 0x040014AC RID: 5292
		private uint? _serverid;

		// Token: 0x040014AD RID: 5293
		private HorseAward _horse = null;

		// Token: 0x040014AE RID: 5294
		private InvFightBattleResult _invfightresult = null;

		// Token: 0x040014AF RID: 5295
		private HeroBattleResult _heroresult = null;

		// Token: 0x040014B0 RID: 5296
		private uint? _military_rank;

		// Token: 0x040014B1 RID: 5297
		private uint? _assitnum;

		// Token: 0x040014B2 RID: 5298
		private uint? _behitdamage;

		// Token: 0x040014B3 RID: 5299
		private uint? _multikillcountmax;

		// Token: 0x040014B4 RID: 5300
		private CustomBattleResult _custombattle = null;

		// Token: 0x040014B5 RID: 5301
		private MobaBattleRoleResult _mobabattle = null;

		// Token: 0x040014B6 RID: 5302
		private WeekEnd4v4BattleRoleData _weekend4v4roledata = null;

		// Token: 0x040014B7 RID: 5303
		private BigMeleeBattleResult _bigmelee = null;

		// Token: 0x040014B8 RID: 5304
		private BattleFieldBattleResult _battlefield = null;

		// Token: 0x040014B9 RID: 5305
		private bool? _isboxexcept;

		// Token: 0x040014BA RID: 5306
		private RiftResult _riftResult = null;

		// Token: 0x040014BB RID: 5307
		private IExtension extensionObject;
	}
}
