using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FD RID: 1533
	[ProtoContract(Name = "GuildRecord")]
	[Serializable]
	public class GuildRecord : IExtensible
	{
		// Token: 0x17001C9D RID: 7325
		// (get) Token: 0x06005B70 RID: 23408 RVA: 0x000AE244 File Offset: 0x000AC444
		// (set) Token: 0x06005B71 RID: 23409 RVA: 0x000AE270 File Offset: 0x000AC470
		[ProtoMember(1, IsRequired = false, Name = "cardplaycount", DataFormat = DataFormat.TwosComplement)]
		public uint cardplaycount
		{
			get
			{
				return this._cardplaycount ?? 0U;
			}
			set
			{
				this._cardplaycount = new uint?(value);
			}
		}

		// Token: 0x17001C9E RID: 7326
		// (get) Token: 0x06005B72 RID: 23410 RVA: 0x000AE280 File Offset: 0x000AC480
		// (set) Token: 0x06005B73 RID: 23411 RVA: 0x000AE2A0 File Offset: 0x000AC4A0
		[XmlIgnore]
		[Browsable(false)]
		public bool cardplaycountSpecified
		{
			get
			{
				return this._cardplaycount != null;
			}
			set
			{
				bool flag = value == (this._cardplaycount == null);
				if (flag)
				{
					this._cardplaycount = (value ? new uint?(this.cardplaycount) : null);
				}
			}
		}

		// Token: 0x06005B74 RID: 23412 RVA: 0x000AE2E4 File Offset: 0x000AC4E4
		private bool ShouldSerializecardplaycount()
		{
			return this.cardplaycountSpecified;
		}

		// Token: 0x06005B75 RID: 23413 RVA: 0x000AE2FC File Offset: 0x000AC4FC
		private void Resetcardplaycount()
		{
			this.cardplaycountSpecified = false;
		}

		// Token: 0x17001C9F RID: 7327
		// (get) Token: 0x06005B76 RID: 23414 RVA: 0x000AE308 File Offset: 0x000AC508
		// (set) Token: 0x06005B77 RID: 23415 RVA: 0x000AE334 File Offset: 0x000AC534
		[ProtoMember(2, IsRequired = false, Name = "cardchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint cardchangecount
		{
			get
			{
				return this._cardchangecount ?? 0U;
			}
			set
			{
				this._cardchangecount = new uint?(value);
			}
		}

		// Token: 0x17001CA0 RID: 7328
		// (get) Token: 0x06005B78 RID: 23416 RVA: 0x000AE344 File Offset: 0x000AC544
		// (set) Token: 0x06005B79 RID: 23417 RVA: 0x000AE364 File Offset: 0x000AC564
		[XmlIgnore]
		[Browsable(false)]
		public bool cardchangecountSpecified
		{
			get
			{
				return this._cardchangecount != null;
			}
			set
			{
				bool flag = value == (this._cardchangecount == null);
				if (flag)
				{
					this._cardchangecount = (value ? new uint?(this.cardchangecount) : null);
				}
			}
		}

		// Token: 0x06005B7A RID: 23418 RVA: 0x000AE3A8 File Offset: 0x000AC5A8
		private bool ShouldSerializecardchangecount()
		{
			return this.cardchangecountSpecified;
		}

		// Token: 0x06005B7B RID: 23419 RVA: 0x000AE3C0 File Offset: 0x000AC5C0
		private void Resetcardchangecount()
		{
			this.cardchangecountSpecified = false;
		}

		// Token: 0x17001CA1 RID: 7329
		// (get) Token: 0x06005B7C RID: 23420 RVA: 0x000AE3CC File Offset: 0x000AC5CC
		// (set) Token: 0x06005B7D RID: 23421 RVA: 0x000AE3F8 File Offset: 0x000AC5F8
		[ProtoMember(3, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		// Token: 0x17001CA2 RID: 7330
		// (get) Token: 0x06005B7E RID: 23422 RVA: 0x000AE408 File Offset: 0x000AC608
		// (set) Token: 0x06005B7F RID: 23423 RVA: 0x000AE428 File Offset: 0x000AC628
		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		// Token: 0x06005B80 RID: 23424 RVA: 0x000AE46C File Offset: 0x000AC66C
		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		// Token: 0x06005B81 RID: 23425 RVA: 0x000AE484 File Offset: 0x000AC684
		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		// Token: 0x17001CA3 RID: 7331
		// (get) Token: 0x06005B82 RID: 23426 RVA: 0x000AE490 File Offset: 0x000AC690
		// (set) Token: 0x06005B83 RID: 23427 RVA: 0x000AE4BC File Offset: 0x000AC6BC
		[ProtoMember(4, IsRequired = false, Name = "checkin", DataFormat = DataFormat.TwosComplement)]
		public uint checkin
		{
			get
			{
				return this._checkin ?? 0U;
			}
			set
			{
				this._checkin = new uint?(value);
			}
		}

		// Token: 0x17001CA4 RID: 7332
		// (get) Token: 0x06005B84 RID: 23428 RVA: 0x000AE4CC File Offset: 0x000AC6CC
		// (set) Token: 0x06005B85 RID: 23429 RVA: 0x000AE4EC File Offset: 0x000AC6EC
		[XmlIgnore]
		[Browsable(false)]
		public bool checkinSpecified
		{
			get
			{
				return this._checkin != null;
			}
			set
			{
				bool flag = value == (this._checkin == null);
				if (flag)
				{
					this._checkin = (value ? new uint?(this.checkin) : null);
				}
			}
		}

		// Token: 0x06005B86 RID: 23430 RVA: 0x000AE530 File Offset: 0x000AC730
		private bool ShouldSerializecheckin()
		{
			return this.checkinSpecified;
		}

		// Token: 0x06005B87 RID: 23431 RVA: 0x000AE548 File Offset: 0x000AC748
		private void Resetcheckin()
		{
			this.checkinSpecified = false;
		}

		// Token: 0x17001CA5 RID: 7333
		// (get) Token: 0x06005B88 RID: 23432 RVA: 0x000AE554 File Offset: 0x000AC754
		// (set) Token: 0x06005B89 RID: 23433 RVA: 0x000AE580 File Offset: 0x000AC780
		[ProtoMember(5, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
		public uint boxmask
		{
			get
			{
				return this._boxmask ?? 0U;
			}
			set
			{
				this._boxmask = new uint?(value);
			}
		}

		// Token: 0x17001CA6 RID: 7334
		// (get) Token: 0x06005B8A RID: 23434 RVA: 0x000AE590 File Offset: 0x000AC790
		// (set) Token: 0x06005B8B RID: 23435 RVA: 0x000AE5B0 File Offset: 0x000AC7B0
		[XmlIgnore]
		[Browsable(false)]
		public bool boxmaskSpecified
		{
			get
			{
				return this._boxmask != null;
			}
			set
			{
				bool flag = value == (this._boxmask == null);
				if (flag)
				{
					this._boxmask = (value ? new uint?(this.boxmask) : null);
				}
			}
		}

		// Token: 0x06005B8C RID: 23436 RVA: 0x000AE5F4 File Offset: 0x000AC7F4
		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		// Token: 0x06005B8D RID: 23437 RVA: 0x000AE60C File Offset: 0x000AC80C
		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		// Token: 0x17001CA7 RID: 7335
		// (get) Token: 0x06005B8E RID: 23438 RVA: 0x000AE618 File Offset: 0x000AC818
		// (set) Token: 0x06005B8F RID: 23439 RVA: 0x000AE644 File Offset: 0x000AC844
		[ProtoMember(6, IsRequired = false, Name = "cardbuychangecount", DataFormat = DataFormat.TwosComplement)]
		public uint cardbuychangecount
		{
			get
			{
				return this._cardbuychangecount ?? 0U;
			}
			set
			{
				this._cardbuychangecount = new uint?(value);
			}
		}

		// Token: 0x17001CA8 RID: 7336
		// (get) Token: 0x06005B90 RID: 23440 RVA: 0x000AE654 File Offset: 0x000AC854
		// (set) Token: 0x06005B91 RID: 23441 RVA: 0x000AE674 File Offset: 0x000AC874
		[XmlIgnore]
		[Browsable(false)]
		public bool cardbuychangecountSpecified
		{
			get
			{
				return this._cardbuychangecount != null;
			}
			set
			{
				bool flag = value == (this._cardbuychangecount == null);
				if (flag)
				{
					this._cardbuychangecount = (value ? new uint?(this.cardbuychangecount) : null);
				}
			}
		}

		// Token: 0x06005B92 RID: 23442 RVA: 0x000AE6B8 File Offset: 0x000AC8B8
		private bool ShouldSerializecardbuychangecount()
		{
			return this.cardbuychangecountSpecified;
		}

		// Token: 0x06005B93 RID: 23443 RVA: 0x000AE6D0 File Offset: 0x000AC8D0
		private void Resetcardbuychangecount()
		{
			this.cardbuychangecountSpecified = false;
		}

		// Token: 0x17001CA9 RID: 7337
		// (get) Token: 0x06005B94 RID: 23444 RVA: 0x000AE6DC File Offset: 0x000AC8DC
		// (set) Token: 0x06005B95 RID: 23445 RVA: 0x000AE708 File Offset: 0x000AC908
		[ProtoMember(7, IsRequired = false, Name = "recvFatigue", DataFormat = DataFormat.TwosComplement)]
		public uint recvFatigue
		{
			get
			{
				return this._recvFatigue ?? 0U;
			}
			set
			{
				this._recvFatigue = new uint?(value);
			}
		}

		// Token: 0x17001CAA RID: 7338
		// (get) Token: 0x06005B96 RID: 23446 RVA: 0x000AE718 File Offset: 0x000AC918
		// (set) Token: 0x06005B97 RID: 23447 RVA: 0x000AE738 File Offset: 0x000AC938
		[XmlIgnore]
		[Browsable(false)]
		public bool recvFatigueSpecified
		{
			get
			{
				return this._recvFatigue != null;
			}
			set
			{
				bool flag = value == (this._recvFatigue == null);
				if (flag)
				{
					this._recvFatigue = (value ? new uint?(this.recvFatigue) : null);
				}
			}
		}

		// Token: 0x06005B98 RID: 23448 RVA: 0x000AE77C File Offset: 0x000AC97C
		private bool ShouldSerializerecvFatigue()
		{
			return this.recvFatigueSpecified;
		}

		// Token: 0x06005B99 RID: 23449 RVA: 0x000AE794 File Offset: 0x000AC994
		private void ResetrecvFatigue()
		{
			this.recvFatigueSpecified = false;
		}

		// Token: 0x17001CAB RID: 7339
		// (get) Token: 0x06005B9A RID: 23450 RVA: 0x000AE7A0 File Offset: 0x000AC9A0
		// (set) Token: 0x06005B9B RID: 23451 RVA: 0x000AE7CC File Offset: 0x000AC9CC
		[ProtoMember(8, IsRequired = false, Name = "askBonusTime", DataFormat = DataFormat.TwosComplement)]
		public uint askBonusTime
		{
			get
			{
				return this._askBonusTime ?? 0U;
			}
			set
			{
				this._askBonusTime = new uint?(value);
			}
		}

		// Token: 0x17001CAC RID: 7340
		// (get) Token: 0x06005B9C RID: 23452 RVA: 0x000AE7DC File Offset: 0x000AC9DC
		// (set) Token: 0x06005B9D RID: 23453 RVA: 0x000AE7FC File Offset: 0x000AC9FC
		[XmlIgnore]
		[Browsable(false)]
		public bool askBonusTimeSpecified
		{
			get
			{
				return this._askBonusTime != null;
			}
			set
			{
				bool flag = value == (this._askBonusTime == null);
				if (flag)
				{
					this._askBonusTime = (value ? new uint?(this.askBonusTime) : null);
				}
			}
		}

		// Token: 0x06005B9E RID: 23454 RVA: 0x000AE840 File Offset: 0x000ACA40
		private bool ShouldSerializeaskBonusTime()
		{
			return this.askBonusTimeSpecified;
		}

		// Token: 0x06005B9F RID: 23455 RVA: 0x000AE858 File Offset: 0x000ACA58
		private void ResetaskBonusTime()
		{
			this.askBonusTimeSpecified = false;
		}

		// Token: 0x17001CAD RID: 7341
		// (get) Token: 0x06005BA0 RID: 23456 RVA: 0x000AE864 File Offset: 0x000ACA64
		// (set) Token: 0x06005BA1 RID: 23457 RVA: 0x000AE890 File Offset: 0x000ACA90
		[ProtoMember(9, IsRequired = false, Name = "getCheckInBonusNum", DataFormat = DataFormat.TwosComplement)]
		public uint getCheckInBonusNum
		{
			get
			{
				return this._getCheckInBonusNum ?? 0U;
			}
			set
			{
				this._getCheckInBonusNum = new uint?(value);
			}
		}

		// Token: 0x17001CAE RID: 7342
		// (get) Token: 0x06005BA2 RID: 23458 RVA: 0x000AE8A0 File Offset: 0x000ACAA0
		// (set) Token: 0x06005BA3 RID: 23459 RVA: 0x000AE8C0 File Offset: 0x000ACAC0
		[XmlIgnore]
		[Browsable(false)]
		public bool getCheckInBonusNumSpecified
		{
			get
			{
				return this._getCheckInBonusNum != null;
			}
			set
			{
				bool flag = value == (this._getCheckInBonusNum == null);
				if (flag)
				{
					this._getCheckInBonusNum = (value ? new uint?(this.getCheckInBonusNum) : null);
				}
			}
		}

		// Token: 0x06005BA4 RID: 23460 RVA: 0x000AE904 File Offset: 0x000ACB04
		private bool ShouldSerializegetCheckInBonusNum()
		{
			return this.getCheckInBonusNumSpecified;
		}

		// Token: 0x06005BA5 RID: 23461 RVA: 0x000AE91C File Offset: 0x000ACB1C
		private void ResetgetCheckInBonusNum()
		{
			this.getCheckInBonusNumSpecified = false;
		}

		// Token: 0x17001CAF RID: 7343
		// (get) Token: 0x06005BA6 RID: 23462 RVA: 0x000AE928 File Offset: 0x000ACB28
		[ProtoMember(10, Name = "darereward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> darereward
		{
			get
			{
				return this._darereward;
			}
		}

		// Token: 0x17001CB0 RID: 7344
		// (get) Token: 0x06005BA7 RID: 23463 RVA: 0x000AE940 File Offset: 0x000ACB40
		// (set) Token: 0x06005BA8 RID: 23464 RVA: 0x000AE96C File Offset: 0x000ACB6C
		[ProtoMember(11, IsRequired = false, Name = "ishintcard", DataFormat = DataFormat.Default)]
		public bool ishintcard
		{
			get
			{
				return this._ishintcard ?? false;
			}
			set
			{
				this._ishintcard = new bool?(value);
			}
		}

		// Token: 0x17001CB1 RID: 7345
		// (get) Token: 0x06005BA9 RID: 23465 RVA: 0x000AE97C File Offset: 0x000ACB7C
		// (set) Token: 0x06005BAA RID: 23466 RVA: 0x000AE99C File Offset: 0x000ACB9C
		[XmlIgnore]
		[Browsable(false)]
		public bool ishintcardSpecified
		{
			get
			{
				return this._ishintcard != null;
			}
			set
			{
				bool flag = value == (this._ishintcard == null);
				if (flag)
				{
					this._ishintcard = (value ? new bool?(this.ishintcard) : null);
				}
			}
		}

		// Token: 0x06005BAB RID: 23467 RVA: 0x000AE9E0 File Offset: 0x000ACBE0
		private bool ShouldSerializeishintcard()
		{
			return this.ishintcardSpecified;
		}

		// Token: 0x06005BAC RID: 23468 RVA: 0x000AE9F8 File Offset: 0x000ACBF8
		private void Resetishintcard()
		{
			this.ishintcardSpecified = false;
		}

		// Token: 0x17001CB2 RID: 7346
		// (get) Token: 0x06005BAD RID: 23469 RVA: 0x000AEA04 File Offset: 0x000ACC04
		[ProtoMember(12, Name = "guildskills", DataFormat = DataFormat.Default)]
		public List<GuildSkill> guildskills
		{
			get
			{
				return this._guildskills;
			}
		}

		// Token: 0x17001CB3 RID: 7347
		// (get) Token: 0x06005BAE RID: 23470 RVA: 0x000AEA1C File Offset: 0x000ACC1C
		// (set) Token: 0x06005BAF RID: 23471 RVA: 0x000AEA49 File Offset: 0x000ACC49
		[ProtoMember(13, IsRequired = false, Name = "cardmatchid", DataFormat = DataFormat.TwosComplement)]
		public ulong cardmatchid
		{
			get
			{
				return this._cardmatchid ?? 0UL;
			}
			set
			{
				this._cardmatchid = new ulong?(value);
			}
		}

		// Token: 0x17001CB4 RID: 7348
		// (get) Token: 0x06005BB0 RID: 23472 RVA: 0x000AEA58 File Offset: 0x000ACC58
		// (set) Token: 0x06005BB1 RID: 23473 RVA: 0x000AEA78 File Offset: 0x000ACC78
		[XmlIgnore]
		[Browsable(false)]
		public bool cardmatchidSpecified
		{
			get
			{
				return this._cardmatchid != null;
			}
			set
			{
				bool flag = value == (this._cardmatchid == null);
				if (flag)
				{
					this._cardmatchid = (value ? new ulong?(this.cardmatchid) : null);
				}
			}
		}

		// Token: 0x06005BB2 RID: 23474 RVA: 0x000AEABC File Offset: 0x000ACCBC
		private bool ShouldSerializecardmatchid()
		{
			return this.cardmatchidSpecified;
		}

		// Token: 0x06005BB3 RID: 23475 RVA: 0x000AEAD4 File Offset: 0x000ACCD4
		private void Resetcardmatchid()
		{
			this.cardmatchidSpecified = false;
		}

		// Token: 0x17001CB5 RID: 7349
		// (get) Token: 0x06005BB4 RID: 23476 RVA: 0x000AEAE0 File Offset: 0x000ACCE0
		// (set) Token: 0x06005BB5 RID: 23477 RVA: 0x000AEB0C File Offset: 0x000ACD0C
		[ProtoMember(14, IsRequired = false, Name = "inheritTeaTime", DataFormat = DataFormat.TwosComplement)]
		public uint inheritTeaTime
		{
			get
			{
				return this._inheritTeaTime ?? 0U;
			}
			set
			{
				this._inheritTeaTime = new uint?(value);
			}
		}

		// Token: 0x17001CB6 RID: 7350
		// (get) Token: 0x06005BB6 RID: 23478 RVA: 0x000AEB1C File Offset: 0x000ACD1C
		// (set) Token: 0x06005BB7 RID: 23479 RVA: 0x000AEB3C File Offset: 0x000ACD3C
		[XmlIgnore]
		[Browsable(false)]
		public bool inheritTeaTimeSpecified
		{
			get
			{
				return this._inheritTeaTime != null;
			}
			set
			{
				bool flag = value == (this._inheritTeaTime == null);
				if (flag)
				{
					this._inheritTeaTime = (value ? new uint?(this.inheritTeaTime) : null);
				}
			}
		}

		// Token: 0x06005BB8 RID: 23480 RVA: 0x000AEB80 File Offset: 0x000ACD80
		private bool ShouldSerializeinheritTeaTime()
		{
			return this.inheritTeaTimeSpecified;
		}

		// Token: 0x06005BB9 RID: 23481 RVA: 0x000AEB98 File Offset: 0x000ACD98
		private void ResetinheritTeaTime()
		{
			this.inheritTeaTimeSpecified = false;
		}

		// Token: 0x17001CB7 RID: 7351
		// (get) Token: 0x06005BBA RID: 23482 RVA: 0x000AEBA4 File Offset: 0x000ACDA4
		// (set) Token: 0x06005BBB RID: 23483 RVA: 0x000AEBD0 File Offset: 0x000ACDD0
		[ProtoMember(15, IsRequired = false, Name = "inheritStuTime", DataFormat = DataFormat.TwosComplement)]
		public uint inheritStuTime
		{
			get
			{
				return this._inheritStuTime ?? 0U;
			}
			set
			{
				this._inheritStuTime = new uint?(value);
			}
		}

		// Token: 0x17001CB8 RID: 7352
		// (get) Token: 0x06005BBC RID: 23484 RVA: 0x000AEBE0 File Offset: 0x000ACDE0
		// (set) Token: 0x06005BBD RID: 23485 RVA: 0x000AEC00 File Offset: 0x000ACE00
		[XmlIgnore]
		[Browsable(false)]
		public bool inheritStuTimeSpecified
		{
			get
			{
				return this._inheritStuTime != null;
			}
			set
			{
				bool flag = value == (this._inheritStuTime == null);
				if (flag)
				{
					this._inheritStuTime = (value ? new uint?(this.inheritStuTime) : null);
				}
			}
		}

		// Token: 0x06005BBE RID: 23486 RVA: 0x000AEC44 File Offset: 0x000ACE44
		private bool ShouldSerializeinheritStuTime()
		{
			return this.inheritStuTimeSpecified;
		}

		// Token: 0x06005BBF RID: 23487 RVA: 0x000AEC5C File Offset: 0x000ACE5C
		private void ResetinheritStuTime()
		{
			this.inheritStuTimeSpecified = false;
		}

		// Token: 0x17001CB9 RID: 7353
		// (get) Token: 0x06005BC0 RID: 23488 RVA: 0x000AEC68 File Offset: 0x000ACE68
		// (set) Token: 0x06005BC1 RID: 23489 RVA: 0x000AEC80 File Offset: 0x000ACE80
		[ProtoMember(16, IsRequired = false, Name = "bonusData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleGuildBonusData bonusData
		{
			get
			{
				return this._bonusData;
			}
			set
			{
				this._bonusData = value;
			}
		}

		// Token: 0x17001CBA RID: 7354
		// (get) Token: 0x06005BC2 RID: 23490 RVA: 0x000AEC8C File Offset: 0x000ACE8C
		// (set) Token: 0x06005BC3 RID: 23491 RVA: 0x000AECB8 File Offset: 0x000ACEB8
		[ProtoMember(17, IsRequired = false, Name = "guildinheritcdtime", DataFormat = DataFormat.TwosComplement)]
		public uint guildinheritcdtime
		{
			get
			{
				return this._guildinheritcdtime ?? 0U;
			}
			set
			{
				this._guildinheritcdtime = new uint?(value);
			}
		}

		// Token: 0x17001CBB RID: 7355
		// (get) Token: 0x06005BC4 RID: 23492 RVA: 0x000AECC8 File Offset: 0x000ACEC8
		// (set) Token: 0x06005BC5 RID: 23493 RVA: 0x000AECE8 File Offset: 0x000ACEE8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildinheritcdtimeSpecified
		{
			get
			{
				return this._guildinheritcdtime != null;
			}
			set
			{
				bool flag = value == (this._guildinheritcdtime == null);
				if (flag)
				{
					this._guildinheritcdtime = (value ? new uint?(this.guildinheritcdtime) : null);
				}
			}
		}

		// Token: 0x06005BC6 RID: 23494 RVA: 0x000AED2C File Offset: 0x000ACF2C
		private bool ShouldSerializeguildinheritcdtime()
		{
			return this.guildinheritcdtimeSpecified;
		}

		// Token: 0x06005BC7 RID: 23495 RVA: 0x000AED44 File Offset: 0x000ACF44
		private void Resetguildinheritcdtime()
		{
			this.guildinheritcdtimeSpecified = false;
		}

		// Token: 0x17001CBC RID: 7356
		// (get) Token: 0x06005BC8 RID: 23496 RVA: 0x000AED50 File Offset: 0x000ACF50
		// (set) Token: 0x06005BC9 RID: 23497 RVA: 0x000AED7C File Offset: 0x000ACF7C
		[ProtoMember(18, IsRequired = false, Name = "teacherinherittime", DataFormat = DataFormat.TwosComplement)]
		public uint teacherinherittime
		{
			get
			{
				return this._teacherinherittime ?? 0U;
			}
			set
			{
				this._teacherinherittime = new uint?(value);
			}
		}

		// Token: 0x17001CBD RID: 7357
		// (get) Token: 0x06005BCA RID: 23498 RVA: 0x000AED8C File Offset: 0x000ACF8C
		// (set) Token: 0x06005BCB RID: 23499 RVA: 0x000AEDAC File Offset: 0x000ACFAC
		[XmlIgnore]
		[Browsable(false)]
		public bool teacherinherittimeSpecified
		{
			get
			{
				return this._teacherinherittime != null;
			}
			set
			{
				bool flag = value == (this._teacherinherittime == null);
				if (flag)
				{
					this._teacherinherittime = (value ? new uint?(this.teacherinherittime) : null);
				}
			}
		}

		// Token: 0x06005BCC RID: 23500 RVA: 0x000AEDF0 File Offset: 0x000ACFF0
		private bool ShouldSerializeteacherinherittime()
		{
			return this.teacherinherittimeSpecified;
		}

		// Token: 0x06005BCD RID: 23501 RVA: 0x000AEE08 File Offset: 0x000AD008
		private void Resetteacherinherittime()
		{
			this.teacherinherittimeSpecified = false;
		}

		// Token: 0x17001CBE RID: 7358
		// (get) Token: 0x06005BCE RID: 23502 RVA: 0x000AEE14 File Offset: 0x000AD014
		[ProtoMember(19, Name = "partyreward", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> partyreward
		{
			get
			{
				return this._partyreward;
			}
		}

		// Token: 0x06005BCF RID: 23503 RVA: 0x000AEE2C File Offset: 0x000AD02C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001641 RID: 5697
		private uint? _cardplaycount;

		// Token: 0x04001642 RID: 5698
		private uint? _cardchangecount;

		// Token: 0x04001643 RID: 5699
		private uint? _updateday;

		// Token: 0x04001644 RID: 5700
		private uint? _checkin;

		// Token: 0x04001645 RID: 5701
		private uint? _boxmask;

		// Token: 0x04001646 RID: 5702
		private uint? _cardbuychangecount;

		// Token: 0x04001647 RID: 5703
		private uint? _recvFatigue;

		// Token: 0x04001648 RID: 5704
		private uint? _askBonusTime;

		// Token: 0x04001649 RID: 5705
		private uint? _getCheckInBonusNum;

		// Token: 0x0400164A RID: 5706
		private readonly List<uint> _darereward = new List<uint>();

		// Token: 0x0400164B RID: 5707
		private bool? _ishintcard;

		// Token: 0x0400164C RID: 5708
		private readonly List<GuildSkill> _guildskills = new List<GuildSkill>();

		// Token: 0x0400164D RID: 5709
		private ulong? _cardmatchid;

		// Token: 0x0400164E RID: 5710
		private uint? _inheritTeaTime;

		// Token: 0x0400164F RID: 5711
		private uint? _inheritStuTime;

		// Token: 0x04001650 RID: 5712
		private RoleGuildBonusData _bonusData = null;

		// Token: 0x04001651 RID: 5713
		private uint? _guildinheritcdtime;

		// Token: 0x04001652 RID: 5714
		private uint? _teacherinherittime;

		// Token: 0x04001653 RID: 5715
		private readonly List<MapKeyValue> _partyreward = new List<MapKeyValue>();

		// Token: 0x04001654 RID: 5716
		private IExtension extensionObject;
	}
}
