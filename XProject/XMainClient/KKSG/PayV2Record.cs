using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061F RID: 1567
	[ProtoContract(Name = "PayV2Record")]
	[Serializable]
	public class PayV2Record : IExtensible
	{
		// Token: 0x17001E09 RID: 7689
		// (get) Token: 0x06005F92 RID: 24466 RVA: 0x000B64D8 File Offset: 0x000B46D8
		[ProtoMember(1, Name = "pay", DataFormat = DataFormat.Default)]
		public List<PayBaseInfo> pay
		{
			get
			{
				return this._pay;
			}
		}

		// Token: 0x17001E0A RID: 7690
		// (get) Token: 0x06005F93 RID: 24467 RVA: 0x000B64F0 File Offset: 0x000B46F0
		[ProtoMember(2, Name = "aileen", DataFormat = DataFormat.Default)]
		public List<PayAileenRecord> aileen
		{
			get
			{
				return this._aileen;
			}
		}

		// Token: 0x17001E0B RID: 7691
		// (get) Token: 0x06005F94 RID: 24468 RVA: 0x000B6508 File Offset: 0x000B4708
		// (set) Token: 0x06005F95 RID: 24469 RVA: 0x000B6534 File Offset: 0x000B4734
		[ProtoMember(3, IsRequired = false, Name = "vipPoint", DataFormat = DataFormat.TwosComplement)]
		public uint vipPoint
		{
			get
			{
				return this._vipPoint ?? 0U;
			}
			set
			{
				this._vipPoint = new uint?(value);
			}
		}

		// Token: 0x17001E0C RID: 7692
		// (get) Token: 0x06005F96 RID: 24470 RVA: 0x000B6544 File Offset: 0x000B4744
		// (set) Token: 0x06005F97 RID: 24471 RVA: 0x000B6564 File Offset: 0x000B4764
		[XmlIgnore]
		[Browsable(false)]
		public bool vipPointSpecified
		{
			get
			{
				return this._vipPoint != null;
			}
			set
			{
				bool flag = value == (this._vipPoint == null);
				if (flag)
				{
					this._vipPoint = (value ? new uint?(this.vipPoint) : null);
				}
			}
		}

		// Token: 0x06005F98 RID: 24472 RVA: 0x000B65A8 File Offset: 0x000B47A8
		private bool ShouldSerializevipPoint()
		{
			return this.vipPointSpecified;
		}

		// Token: 0x06005F99 RID: 24473 RVA: 0x000B65C0 File Offset: 0x000B47C0
		private void ResetvipPoint()
		{
			this.vipPointSpecified = false;
		}

		// Token: 0x17001E0D RID: 7693
		// (get) Token: 0x06005F9A RID: 24474 RVA: 0x000B65CC File Offset: 0x000B47CC
		// (set) Token: 0x06005F9B RID: 24475 RVA: 0x000B65F8 File Offset: 0x000B47F8
		[ProtoMember(4, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001E0E RID: 7694
		// (get) Token: 0x06005F9C RID: 24476 RVA: 0x000B6608 File Offset: 0x000B4808
		// (set) Token: 0x06005F9D RID: 24477 RVA: 0x000B6628 File Offset: 0x000B4828
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

		// Token: 0x06005F9E RID: 24478 RVA: 0x000B666C File Offset: 0x000B486C
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x06005F9F RID: 24479 RVA: 0x000B6684 File Offset: 0x000B4884
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x17001E0F RID: 7695
		// (get) Token: 0x06005FA0 RID: 24480 RVA: 0x000B6690 File Offset: 0x000B4890
		// (set) Token: 0x06005FA1 RID: 24481 RVA: 0x000B66BC File Offset: 0x000B48BC
		[ProtoMember(5, IsRequired = false, Name = "totalPay", DataFormat = DataFormat.TwosComplement)]
		public uint totalPay
		{
			get
			{
				return this._totalPay ?? 0U;
			}
			set
			{
				this._totalPay = new uint?(value);
			}
		}

		// Token: 0x17001E10 RID: 7696
		// (get) Token: 0x06005FA2 RID: 24482 RVA: 0x000B66CC File Offset: 0x000B48CC
		// (set) Token: 0x06005FA3 RID: 24483 RVA: 0x000B66EC File Offset: 0x000B48EC
		[XmlIgnore]
		[Browsable(false)]
		public bool totalPaySpecified
		{
			get
			{
				return this._totalPay != null;
			}
			set
			{
				bool flag = value == (this._totalPay == null);
				if (flag)
				{
					this._totalPay = (value ? new uint?(this.totalPay) : null);
				}
			}
		}

		// Token: 0x06005FA4 RID: 24484 RVA: 0x000B6730 File Offset: 0x000B4930
		private bool ShouldSerializetotalPay()
		{
			return this.totalPaySpecified;
		}

		// Token: 0x06005FA5 RID: 24485 RVA: 0x000B6748 File Offset: 0x000B4948
		private void ResettotalPay()
		{
			this.totalPaySpecified = false;
		}

		// Token: 0x17001E11 RID: 7697
		// (get) Token: 0x06005FA6 RID: 24486 RVA: 0x000B6754 File Offset: 0x000B4954
		// (set) Token: 0x06005FA7 RID: 24487 RVA: 0x000B6780 File Offset: 0x000B4980
		[ProtoMember(6, IsRequired = false, Name = "payCardButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint payCardButtonStatus
		{
			get
			{
				return this._payCardButtonStatus ?? 0U;
			}
			set
			{
				this._payCardButtonStatus = new uint?(value);
			}
		}

		// Token: 0x17001E12 RID: 7698
		// (get) Token: 0x06005FA8 RID: 24488 RVA: 0x000B6790 File Offset: 0x000B4990
		// (set) Token: 0x06005FA9 RID: 24489 RVA: 0x000B67B0 File Offset: 0x000B49B0
		[XmlIgnore]
		[Browsable(false)]
		public bool payCardButtonStatusSpecified
		{
			get
			{
				return this._payCardButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._payCardButtonStatus == null);
				if (flag)
				{
					this._payCardButtonStatus = (value ? new uint?(this.payCardButtonStatus) : null);
				}
			}
		}

		// Token: 0x06005FAA RID: 24490 RVA: 0x000B67F4 File Offset: 0x000B49F4
		private bool ShouldSerializepayCardButtonStatus()
		{
			return this.payCardButtonStatusSpecified;
		}

		// Token: 0x06005FAB RID: 24491 RVA: 0x000B680C File Offset: 0x000B4A0C
		private void ResetpayCardButtonStatus()
		{
			this.payCardButtonStatusSpecified = false;
		}

		// Token: 0x17001E13 RID: 7699
		// (get) Token: 0x06005FAC RID: 24492 RVA: 0x000B6818 File Offset: 0x000B4A18
		// (set) Token: 0x06005FAD RID: 24493 RVA: 0x000B6844 File Offset: 0x000B4A44
		[ProtoMember(7, IsRequired = false, Name = "payAileenButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint payAileenButtonStatus
		{
			get
			{
				return this._payAileenButtonStatus ?? 0U;
			}
			set
			{
				this._payAileenButtonStatus = new uint?(value);
			}
		}

		// Token: 0x17001E14 RID: 7700
		// (get) Token: 0x06005FAE RID: 24494 RVA: 0x000B6854 File Offset: 0x000B4A54
		// (set) Token: 0x06005FAF RID: 24495 RVA: 0x000B6874 File Offset: 0x000B4A74
		[XmlIgnore]
		[Browsable(false)]
		public bool payAileenButtonStatusSpecified
		{
			get
			{
				return this._payAileenButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._payAileenButtonStatus == null);
				if (flag)
				{
					this._payAileenButtonStatus = (value ? new uint?(this.payAileenButtonStatus) : null);
				}
			}
		}

		// Token: 0x06005FB0 RID: 24496 RVA: 0x000B68B8 File Offset: 0x000B4AB8
		private bool ShouldSerializepayAileenButtonStatus()
		{
			return this.payAileenButtonStatusSpecified;
		}

		// Token: 0x06005FB1 RID: 24497 RVA: 0x000B68D0 File Offset: 0x000B4AD0
		private void ResetpayAileenButtonStatus()
		{
			this.payAileenButtonStatusSpecified = false;
		}

		// Token: 0x17001E15 RID: 7701
		// (get) Token: 0x06005FB2 RID: 24498 RVA: 0x000B68DC File Offset: 0x000B4ADC
		// (set) Token: 0x06005FB3 RID: 24499 RVA: 0x000B6908 File Offset: 0x000B4B08
		[ProtoMember(8, IsRequired = false, Name = "lastFirstPayAwardTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastFirstPayAwardTime
		{
			get
			{
				return this._lastFirstPayAwardTime ?? 0U;
			}
			set
			{
				this._lastFirstPayAwardTime = new uint?(value);
			}
		}

		// Token: 0x17001E16 RID: 7702
		// (get) Token: 0x06005FB4 RID: 24500 RVA: 0x000B6918 File Offset: 0x000B4B18
		// (set) Token: 0x06005FB5 RID: 24501 RVA: 0x000B6938 File Offset: 0x000B4B38
		[XmlIgnore]
		[Browsable(false)]
		public bool lastFirstPayAwardTimeSpecified
		{
			get
			{
				return this._lastFirstPayAwardTime != null;
			}
			set
			{
				bool flag = value == (this._lastFirstPayAwardTime == null);
				if (flag)
				{
					this._lastFirstPayAwardTime = (value ? new uint?(this.lastFirstPayAwardTime) : null);
				}
			}
		}

		// Token: 0x06005FB6 RID: 24502 RVA: 0x000B697C File Offset: 0x000B4B7C
		private bool ShouldSerializelastFirstPayAwardTime()
		{
			return this.lastFirstPayAwardTimeSpecified;
		}

		// Token: 0x06005FB7 RID: 24503 RVA: 0x000B6994 File Offset: 0x000B4B94
		private void ResetlastFirstPayAwardTime()
		{
			this.lastFirstPayAwardTimeSpecified = false;
		}

		// Token: 0x17001E17 RID: 7703
		// (get) Token: 0x06005FB8 RID: 24504 RVA: 0x000B69A0 File Offset: 0x000B4BA0
		[ProtoMember(9, Name = "growthFundLevelInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> growthFundLevelInfo
		{
			get
			{
				return this._growthFundLevelInfo;
			}
		}

		// Token: 0x17001E18 RID: 7704
		// (get) Token: 0x06005FB9 RID: 24505 RVA: 0x000B69B8 File Offset: 0x000B4BB8
		[ProtoMember(10, Name = "growthFundLoginInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> growthFundLoginInfo
		{
			get
			{
				return this._growthFundLoginInfo;
			}
		}

		// Token: 0x17001E19 RID: 7705
		// (get) Token: 0x06005FBA RID: 24506 RVA: 0x000B69D0 File Offset: 0x000B4BD0
		[ProtoMember(11, Name = "vipLevelGiftInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> vipLevelGiftInfo
		{
			get
			{
				return this._vipLevelGiftInfo;
			}
		}

		// Token: 0x17001E1A RID: 7706
		// (get) Token: 0x06005FBB RID: 24507 RVA: 0x000B69E8 File Offset: 0x000B4BE8
		// (set) Token: 0x06005FBC RID: 24508 RVA: 0x000B6A14 File Offset: 0x000B4C14
		[ProtoMember(12, IsRequired = false, Name = "payFirstAwardButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint payFirstAwardButtonStatus
		{
			get
			{
				return this._payFirstAwardButtonStatus ?? 0U;
			}
			set
			{
				this._payFirstAwardButtonStatus = new uint?(value);
			}
		}

		// Token: 0x17001E1B RID: 7707
		// (get) Token: 0x06005FBD RID: 24509 RVA: 0x000B6A24 File Offset: 0x000B4C24
		// (set) Token: 0x06005FBE RID: 24510 RVA: 0x000B6A44 File Offset: 0x000B4C44
		[XmlIgnore]
		[Browsable(false)]
		public bool payFirstAwardButtonStatusSpecified
		{
			get
			{
				return this._payFirstAwardButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._payFirstAwardButtonStatus == null);
				if (flag)
				{
					this._payFirstAwardButtonStatus = (value ? new uint?(this.payFirstAwardButtonStatus) : null);
				}
			}
		}

		// Token: 0x06005FBF RID: 24511 RVA: 0x000B6A88 File Offset: 0x000B4C88
		private bool ShouldSerializepayFirstAwardButtonStatus()
		{
			return this.payFirstAwardButtonStatusSpecified;
		}

		// Token: 0x06005FC0 RID: 24512 RVA: 0x000B6AA0 File Offset: 0x000B4CA0
		private void ResetpayFirstAwardButtonStatus()
		{
			this.payFirstAwardButtonStatusSpecified = false;
		}

		// Token: 0x17001E1C RID: 7708
		// (get) Token: 0x06005FC1 RID: 24513 RVA: 0x000B6AAC File Offset: 0x000B4CAC
		// (set) Token: 0x06005FC2 RID: 24514 RVA: 0x000B6AD8 File Offset: 0x000B4CD8
		[ProtoMember(13, IsRequired = false, Name = "growthFundButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint growthFundButtonStatus
		{
			get
			{
				return this._growthFundButtonStatus ?? 0U;
			}
			set
			{
				this._growthFundButtonStatus = new uint?(value);
			}
		}

		// Token: 0x17001E1D RID: 7709
		// (get) Token: 0x06005FC3 RID: 24515 RVA: 0x000B6AE8 File Offset: 0x000B4CE8
		// (set) Token: 0x06005FC4 RID: 24516 RVA: 0x000B6B08 File Offset: 0x000B4D08
		[XmlIgnore]
		[Browsable(false)]
		public bool growthFundButtonStatusSpecified
		{
			get
			{
				return this._growthFundButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._growthFundButtonStatus == null);
				if (flag)
				{
					this._growthFundButtonStatus = (value ? new uint?(this.growthFundButtonStatus) : null);
				}
			}
		}

		// Token: 0x06005FC5 RID: 24517 RVA: 0x000B6B4C File Offset: 0x000B4D4C
		private bool ShouldSerializegrowthFundButtonStatus()
		{
			return this.growthFundButtonStatusSpecified;
		}

		// Token: 0x06005FC6 RID: 24518 RVA: 0x000B6B64 File Offset: 0x000B4D64
		private void ResetgrowthFundButtonStatus()
		{
			this.growthFundButtonStatusSpecified = false;
		}

		// Token: 0x17001E1E RID: 7710
		// (get) Token: 0x06005FC7 RID: 24519 RVA: 0x000B6B70 File Offset: 0x000B4D70
		[ProtoMember(14, Name = "payMemberInfo", DataFormat = DataFormat.Default)]
		public List<PayMemberRecord> payMemberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

		// Token: 0x17001E1F RID: 7711
		// (get) Token: 0x06005FC8 RID: 24520 RVA: 0x000B6B88 File Offset: 0x000B4D88
		// (set) Token: 0x06005FC9 RID: 24521 RVA: 0x000B6BA0 File Offset: 0x000B4DA0
		[ProtoMember(15, IsRequired = false, Name = "privilege", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayMemberPrivilege privilege
		{
			get
			{
				return this._privilege;
			}
			set
			{
				this._privilege = value;
			}
		}

		// Token: 0x17001E20 RID: 7712
		// (get) Token: 0x06005FCA RID: 24522 RVA: 0x000B6BAC File Offset: 0x000B4DAC
		// (set) Token: 0x06005FCB RID: 24523 RVA: 0x000B6BD8 File Offset: 0x000B4DD8
		[ProtoMember(16, IsRequired = false, Name = "lastUpdateDay", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateDay
		{
			get
			{
				return this._lastUpdateDay ?? 0U;
			}
			set
			{
				this._lastUpdateDay = new uint?(value);
			}
		}

		// Token: 0x17001E21 RID: 7713
		// (get) Token: 0x06005FCC RID: 24524 RVA: 0x000B6BE8 File Offset: 0x000B4DE8
		// (set) Token: 0x06005FCD RID: 24525 RVA: 0x000B6C08 File Offset: 0x000B4E08
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateDaySpecified
		{
			get
			{
				return this._lastUpdateDay != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateDay == null);
				if (flag)
				{
					this._lastUpdateDay = (value ? new uint?(this.lastUpdateDay) : null);
				}
			}
		}

		// Token: 0x06005FCE RID: 24526 RVA: 0x000B6C4C File Offset: 0x000B4E4C
		private bool ShouldSerializelastUpdateDay()
		{
			return this.lastUpdateDaySpecified;
		}

		// Token: 0x06005FCF RID: 24527 RVA: 0x000B6C64 File Offset: 0x000B4E64
		private void ResetlastUpdateDay()
		{
			this.lastUpdateDaySpecified = false;
		}

		// Token: 0x17001E22 RID: 7714
		// (get) Token: 0x06005FD0 RID: 24528 RVA: 0x000B6C70 File Offset: 0x000B4E70
		// (set) Token: 0x06005FD1 RID: 24529 RVA: 0x000B6C9C File Offset: 0x000B4E9C
		[ProtoMember(17, IsRequired = false, Name = "isEverPay", DataFormat = DataFormat.Default)]
		public bool isEverPay
		{
			get
			{
				return this._isEverPay ?? false;
			}
			set
			{
				this._isEverPay = new bool?(value);
			}
		}

		// Token: 0x17001E23 RID: 7715
		// (get) Token: 0x06005FD2 RID: 24530 RVA: 0x000B6CAC File Offset: 0x000B4EAC
		// (set) Token: 0x06005FD3 RID: 24531 RVA: 0x000B6CCC File Offset: 0x000B4ECC
		[XmlIgnore]
		[Browsable(false)]
		public bool isEverPaySpecified
		{
			get
			{
				return this._isEverPay != null;
			}
			set
			{
				bool flag = value == (this._isEverPay == null);
				if (flag)
				{
					this._isEverPay = (value ? new bool?(this.isEverPay) : null);
				}
			}
		}

		// Token: 0x06005FD4 RID: 24532 RVA: 0x000B6D10 File Offset: 0x000B4F10
		private bool ShouldSerializeisEverPay()
		{
			return this.isEverPaySpecified;
		}

		// Token: 0x06005FD5 RID: 24533 RVA: 0x000B6D28 File Offset: 0x000B4F28
		private void ResetisEverPay()
		{
			this.isEverPaySpecified = false;
		}

		// Token: 0x17001E24 RID: 7716
		// (get) Token: 0x06005FD6 RID: 24534 RVA: 0x000B6D34 File Offset: 0x000B4F34
		[ProtoMember(18, Name = "consumelist", DataFormat = DataFormat.Default)]
		public List<PayconsumeBrief> consumelist
		{
			get
			{
				return this._consumelist;
			}
		}

		// Token: 0x17001E25 RID: 7717
		// (get) Token: 0x06005FD7 RID: 24535 RVA: 0x000B6D4C File Offset: 0x000B4F4C
		// (set) Token: 0x06005FD8 RID: 24536 RVA: 0x000B6D64 File Offset: 0x000B4F64
		[ProtoMember(19, IsRequired = false, Name = "weekcard", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PaytssInfo weekcard
		{
			get
			{
				return this._weekcard;
			}
			set
			{
				this._weekcard = value;
			}
		}

		// Token: 0x17001E26 RID: 7718
		// (get) Token: 0x06005FD9 RID: 24537 RVA: 0x000B6D70 File Offset: 0x000B4F70
		// (set) Token: 0x06005FDA RID: 24538 RVA: 0x000B6D88 File Offset: 0x000B4F88
		[ProtoMember(20, IsRequired = false, Name = "monthcard", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PaytssInfo monthcard
		{
			get
			{
				return this._monthcard;
			}
			set
			{
				this._monthcard = value;
			}
		}

		// Token: 0x17001E27 RID: 7719
		// (get) Token: 0x06005FDB RID: 24539 RVA: 0x000B6D94 File Offset: 0x000B4F94
		// (set) Token: 0x06005FDC RID: 24540 RVA: 0x000B6DAC File Offset: 0x000B4FAC
		[ProtoMember(21, IsRequired = false, Name = "growthfund", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PaytssInfo growthfund
		{
			get
			{
				return this._growthfund;
			}
			set
			{
				this._growthfund = value;
			}
		}

		// Token: 0x17001E28 RID: 7720
		// (get) Token: 0x06005FDD RID: 24541 RVA: 0x000B6DB8 File Offset: 0x000B4FB8
		// (set) Token: 0x06005FDE RID: 24542 RVA: 0x000B6DE4 File Offset: 0x000B4FE4
		[ProtoMember(22, IsRequired = false, Name = "rewardTime", DataFormat = DataFormat.TwosComplement)]
		public uint rewardTime
		{
			get
			{
				return this._rewardTime ?? 0U;
			}
			set
			{
				this._rewardTime = new uint?(value);
			}
		}

		// Token: 0x17001E29 RID: 7721
		// (get) Token: 0x06005FDF RID: 24543 RVA: 0x000B6DF4 File Offset: 0x000B4FF4
		// (set) Token: 0x06005FE0 RID: 24544 RVA: 0x000B6E14 File Offset: 0x000B5014
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardTimeSpecified
		{
			get
			{
				return this._rewardTime != null;
			}
			set
			{
				bool flag = value == (this._rewardTime == null);
				if (flag)
				{
					this._rewardTime = (value ? new uint?(this.rewardTime) : null);
				}
			}
		}

		// Token: 0x06005FE1 RID: 24545 RVA: 0x000B6E58 File Offset: 0x000B5058
		private bool ShouldSerializerewardTime()
		{
			return this.rewardTimeSpecified;
		}

		// Token: 0x06005FE2 RID: 24546 RVA: 0x000B6E70 File Offset: 0x000B5070
		private void ResetrewardTime()
		{
			this.rewardTimeSpecified = false;
		}

		// Token: 0x17001E2A RID: 7722
		// (get) Token: 0x06005FE3 RID: 24547 RVA: 0x000B6E7C File Offset: 0x000B507C
		// (set) Token: 0x06005FE4 RID: 24548 RVA: 0x000B6EA8 File Offset: 0x000B50A8
		[ProtoMember(23, IsRequired = false, Name = "growthfundnotifytime", DataFormat = DataFormat.TwosComplement)]
		public uint growthfundnotifytime
		{
			get
			{
				return this._growthfundnotifytime ?? 0U;
			}
			set
			{
				this._growthfundnotifytime = new uint?(value);
			}
		}

		// Token: 0x17001E2B RID: 7723
		// (get) Token: 0x06005FE5 RID: 24549 RVA: 0x000B6EB8 File Offset: 0x000B50B8
		// (set) Token: 0x06005FE6 RID: 24550 RVA: 0x000B6ED8 File Offset: 0x000B50D8
		[XmlIgnore]
		[Browsable(false)]
		public bool growthfundnotifytimeSpecified
		{
			get
			{
				return this._growthfundnotifytime != null;
			}
			set
			{
				bool flag = value == (this._growthfundnotifytime == null);
				if (flag)
				{
					this._growthfundnotifytime = (value ? new uint?(this.growthfundnotifytime) : null);
				}
			}
		}

		// Token: 0x06005FE7 RID: 24551 RVA: 0x000B6F1C File Offset: 0x000B511C
		private bool ShouldSerializegrowthfundnotifytime()
		{
			return this.growthfundnotifytimeSpecified;
		}

		// Token: 0x06005FE8 RID: 24552 RVA: 0x000B6F34 File Offset: 0x000B5134
		private void Resetgrowthfundnotifytime()
		{
			this.growthfundnotifytimeSpecified = false;
		}

		// Token: 0x17001E2C RID: 7724
		// (get) Token: 0x06005FE9 RID: 24553 RVA: 0x000B6F40 File Offset: 0x000B5140
		// (set) Token: 0x06005FEA RID: 24554 RVA: 0x000B6F58 File Offset: 0x000B5158
		[ProtoMember(24, IsRequired = false, Name = "consume", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume consume
		{
			get
			{
				return this._consume;
			}
			set
			{
				this._consume = value;
			}
		}

		// Token: 0x17001E2D RID: 7725
		// (get) Token: 0x06005FEB RID: 24555 RVA: 0x000B6F64 File Offset: 0x000B5164
		// (set) Token: 0x06005FEC RID: 24556 RVA: 0x000B6F7C File Offset: 0x000B517C
		[ProtoMember(25, IsRequired = false, Name = "rebate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsumeRebate rebate
		{
			get
			{
				return this._rebate;
			}
			set
			{
				this._rebate = value;
			}
		}

		// Token: 0x17001E2E RID: 7726
		// (get) Token: 0x06005FED RID: 24557 RVA: 0x000B6F88 File Offset: 0x000B5188
		[ProtoMember(26, Name = "paygift", DataFormat = DataFormat.Default)]
		public List<PayGiftRecord> paygift
		{
			get
			{
				return this._paygift;
			}
		}

		// Token: 0x06005FEE RID: 24558 RVA: 0x000B6FA0 File Offset: 0x000B51A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001735 RID: 5941
		private readonly List<PayBaseInfo> _pay = new List<PayBaseInfo>();

		// Token: 0x04001736 RID: 5942
		private readonly List<PayAileenRecord> _aileen = new List<PayAileenRecord>();

		// Token: 0x04001737 RID: 5943
		private uint? _vipPoint;

		// Token: 0x04001738 RID: 5944
		private uint? _vipLevel;

		// Token: 0x04001739 RID: 5945
		private uint? _totalPay;

		// Token: 0x0400173A RID: 5946
		private uint? _payCardButtonStatus;

		// Token: 0x0400173B RID: 5947
		private uint? _payAileenButtonStatus;

		// Token: 0x0400173C RID: 5948
		private uint? _lastFirstPayAwardTime;

		// Token: 0x0400173D RID: 5949
		private readonly List<PayAwardRecord> _growthFundLevelInfo = new List<PayAwardRecord>();

		// Token: 0x0400173E RID: 5950
		private readonly List<PayAwardRecord> _growthFundLoginInfo = new List<PayAwardRecord>();

		// Token: 0x0400173F RID: 5951
		private readonly List<PayAwardRecord> _vipLevelGiftInfo = new List<PayAwardRecord>();

		// Token: 0x04001740 RID: 5952
		private uint? _payFirstAwardButtonStatus;

		// Token: 0x04001741 RID: 5953
		private uint? _growthFundButtonStatus;

		// Token: 0x04001742 RID: 5954
		private readonly List<PayMemberRecord> _payMemberInfo = new List<PayMemberRecord>();

		// Token: 0x04001743 RID: 5955
		private PayMemberPrivilege _privilege = null;

		// Token: 0x04001744 RID: 5956
		private uint? _lastUpdateDay;

		// Token: 0x04001745 RID: 5957
		private bool? _isEverPay;

		// Token: 0x04001746 RID: 5958
		private readonly List<PayconsumeBrief> _consumelist = new List<PayconsumeBrief>();

		// Token: 0x04001747 RID: 5959
		private PaytssInfo _weekcard = null;

		// Token: 0x04001748 RID: 5960
		private PaytssInfo _monthcard = null;

		// Token: 0x04001749 RID: 5961
		private PaytssInfo _growthfund = null;

		// Token: 0x0400174A RID: 5962
		private uint? _rewardTime;

		// Token: 0x0400174B RID: 5963
		private uint? _growthfundnotifytime;

		// Token: 0x0400174C RID: 5964
		private PayConsume _consume = null;

		// Token: 0x0400174D RID: 5965
		private PayConsumeRebate _rebate = null;

		// Token: 0x0400174E RID: 5966
		private readonly List<PayGiftRecord> _paygift = new List<PayGiftRecord>();

		// Token: 0x0400174F RID: 5967
		private IExtension extensionObject;
	}
}
