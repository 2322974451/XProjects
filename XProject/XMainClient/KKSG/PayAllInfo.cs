using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C5 RID: 453
	[ProtoContract(Name = "PayAllInfo")]
	[Serializable]
	public class PayAllInfo : IExtensible
	{
		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06001A3D RID: 6717 RVA: 0x00033F64 File Offset: 0x00032164
		[ProtoMember(1, Name = "pay", DataFormat = DataFormat.Default)]
		public List<PayBaseInfo> pay
		{
			get
			{
				return this._pay;
			}
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06001A3E RID: 6718 RVA: 0x00033F7C File Offset: 0x0003217C
		[ProtoMember(2, Name = "card", DataFormat = DataFormat.Default)]
		public List<PayCard> card
		{
			get
			{
				return this._card;
			}
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06001A3F RID: 6719 RVA: 0x00033F94 File Offset: 0x00032194
		// (set) Token: 0x06001A40 RID: 6720 RVA: 0x00033FAC File Offset: 0x000321AC
		[ProtoMember(3, IsRequired = false, Name = "aileen", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayAileen aileen
		{
			get
			{
				return this._aileen;
			}
			set
			{
				this._aileen = value;
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06001A41 RID: 6721 RVA: 0x00033FB8 File Offset: 0x000321B8
		// (set) Token: 0x06001A42 RID: 6722 RVA: 0x00033FE4 File Offset: 0x000321E4
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

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06001A43 RID: 6723 RVA: 0x00033FF4 File Offset: 0x000321F4
		// (set) Token: 0x06001A44 RID: 6724 RVA: 0x00034014 File Offset: 0x00032214
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

		// Token: 0x06001A45 RID: 6725 RVA: 0x00034058 File Offset: 0x00032258
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x00034070 File Offset: 0x00032270
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06001A47 RID: 6727 RVA: 0x0003407C File Offset: 0x0003227C
		// (set) Token: 0x06001A48 RID: 6728 RVA: 0x000340A8 File Offset: 0x000322A8
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

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06001A49 RID: 6729 RVA: 0x000340B8 File Offset: 0x000322B8
		// (set) Token: 0x06001A4A RID: 6730 RVA: 0x000340D8 File Offset: 0x000322D8
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

		// Token: 0x06001A4B RID: 6731 RVA: 0x0003411C File Offset: 0x0003231C
		private bool ShouldSerializetotalPay()
		{
			return this.totalPaySpecified;
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00034134 File Offset: 0x00032334
		private void ResettotalPay()
		{
			this.totalPaySpecified = false;
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06001A4D RID: 6733 RVA: 0x00034140 File Offset: 0x00032340
		// (set) Token: 0x06001A4E RID: 6734 RVA: 0x0003416C File Offset: 0x0003236C
		[ProtoMember(6, IsRequired = false, Name = "payCardFirstClick", DataFormat = DataFormat.Default)]
		public bool payCardFirstClick
		{
			get
			{
				return this._payCardFirstClick ?? false;
			}
			set
			{
				this._payCardFirstClick = new bool?(value);
			}
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06001A4F RID: 6735 RVA: 0x0003417C File Offset: 0x0003237C
		// (set) Token: 0x06001A50 RID: 6736 RVA: 0x0003419C File Offset: 0x0003239C
		[XmlIgnore]
		[Browsable(false)]
		public bool payCardFirstClickSpecified
		{
			get
			{
				return this._payCardFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payCardFirstClick == null);
				if (flag)
				{
					this._payCardFirstClick = (value ? new bool?(this.payCardFirstClick) : null);
				}
			}
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x000341E0 File Offset: 0x000323E0
		private bool ShouldSerializepayCardFirstClick()
		{
			return this.payCardFirstClickSpecified;
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x000341F8 File Offset: 0x000323F8
		private void ResetpayCardFirstClick()
		{
			this.payCardFirstClickSpecified = false;
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06001A53 RID: 6739 RVA: 0x00034204 File Offset: 0x00032404
		// (set) Token: 0x06001A54 RID: 6740 RVA: 0x00034230 File Offset: 0x00032430
		[ProtoMember(7, IsRequired = false, Name = "payAileenFirstClick", DataFormat = DataFormat.Default)]
		public bool payAileenFirstClick
		{
			get
			{
				return this._payAileenFirstClick ?? false;
			}
			set
			{
				this._payAileenFirstClick = new bool?(value);
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06001A55 RID: 6741 RVA: 0x00034240 File Offset: 0x00032440
		// (set) Token: 0x06001A56 RID: 6742 RVA: 0x00034260 File Offset: 0x00032460
		[XmlIgnore]
		[Browsable(false)]
		public bool payAileenFirstClickSpecified
		{
			get
			{
				return this._payAileenFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payAileenFirstClick == null);
				if (flag)
				{
					this._payAileenFirstClick = (value ? new bool?(this.payAileenFirstClick) : null);
				}
			}
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x000342A4 File Offset: 0x000324A4
		private bool ShouldSerializepayAileenFirstClick()
		{
			return this.payAileenFirstClickSpecified;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x000342BC File Offset: 0x000324BC
		private void ResetpayAileenFirstClick()
		{
			this.payAileenFirstClickSpecified = false;
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x06001A59 RID: 6745 RVA: 0x000342C8 File Offset: 0x000324C8
		// (set) Token: 0x06001A5A RID: 6746 RVA: 0x000342F4 File Offset: 0x000324F4
		[ProtoMember(8, IsRequired = false, Name = "payFirstAward", DataFormat = DataFormat.Default)]
		public bool payFirstAward
		{
			get
			{
				return this._payFirstAward ?? false;
			}
			set
			{
				this._payFirstAward = new bool?(value);
			}
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06001A5B RID: 6747 RVA: 0x00034304 File Offset: 0x00032504
		// (set) Token: 0x06001A5C RID: 6748 RVA: 0x00034324 File Offset: 0x00032524
		[XmlIgnore]
		[Browsable(false)]
		public bool payFirstAwardSpecified
		{
			get
			{
				return this._payFirstAward != null;
			}
			set
			{
				bool flag = value == (this._payFirstAward == null);
				if (flag)
				{
					this._payFirstAward = (value ? new bool?(this.payFirstAward) : null);
				}
			}
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00034368 File Offset: 0x00032568
		private bool ShouldSerializepayFirstAward()
		{
			return this.payFirstAwardSpecified;
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00034380 File Offset: 0x00032580
		private void ResetpayFirstAward()
		{
			this.payFirstAwardSpecified = false;
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06001A5F RID: 6751 RVA: 0x0003438C File Offset: 0x0003258C
		// (set) Token: 0x06001A60 RID: 6752 RVA: 0x000343B8 File Offset: 0x000325B8
		[ProtoMember(9, IsRequired = false, Name = "payFirstAwardClick", DataFormat = DataFormat.Default)]
		public bool payFirstAwardClick
		{
			get
			{
				return this._payFirstAwardClick ?? false;
			}
			set
			{
				this._payFirstAwardClick = new bool?(value);
			}
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06001A61 RID: 6753 RVA: 0x000343C8 File Offset: 0x000325C8
		// (set) Token: 0x06001A62 RID: 6754 RVA: 0x000343E8 File Offset: 0x000325E8
		[XmlIgnore]
		[Browsable(false)]
		public bool payFirstAwardClickSpecified
		{
			get
			{
				return this._payFirstAwardClick != null;
			}
			set
			{
				bool flag = value == (this._payFirstAwardClick == null);
				if (flag)
				{
					this._payFirstAwardClick = (value ? new bool?(this.payFirstAwardClick) : null);
				}
			}
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x0003442C File Offset: 0x0003262C
		private bool ShouldSerializepayFirstAwardClick()
		{
			return this.payFirstAwardClickSpecified;
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x00034444 File Offset: 0x00032644
		private void ResetpayFirstAwardClick()
		{
			this.payFirstAwardClickSpecified = false;
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06001A65 RID: 6757 RVA: 0x00034450 File Offset: 0x00032650
		// (set) Token: 0x06001A66 RID: 6758 RVA: 0x0003447C File Offset: 0x0003267C
		[ProtoMember(10, IsRequired = false, Name = "buyGrowthFund", DataFormat = DataFormat.Default)]
		public bool buyGrowthFund
		{
			get
			{
				return this._buyGrowthFund ?? false;
			}
			set
			{
				this._buyGrowthFund = new bool?(value);
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06001A67 RID: 6759 RVA: 0x0003448C File Offset: 0x0003268C
		// (set) Token: 0x06001A68 RID: 6760 RVA: 0x000344AC File Offset: 0x000326AC
		[XmlIgnore]
		[Browsable(false)]
		public bool buyGrowthFundSpecified
		{
			get
			{
				return this._buyGrowthFund != null;
			}
			set
			{
				bool flag = value == (this._buyGrowthFund == null);
				if (flag)
				{
					this._buyGrowthFund = (value ? new bool?(this.buyGrowthFund) : null);
				}
			}
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x000344F0 File Offset: 0x000326F0
		private bool ShouldSerializebuyGrowthFund()
		{
			return this.buyGrowthFundSpecified;
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x00034508 File Offset: 0x00032708
		private void ResetbuyGrowthFund()
		{
			this.buyGrowthFundSpecified = false;
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06001A6B RID: 6763 RVA: 0x00034514 File Offset: 0x00032714
		[ProtoMember(11, Name = "growthFundLevelInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLevelInfo
		{
			get
			{
				return this._growthFundLevelInfo;
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06001A6C RID: 6764 RVA: 0x0003452C File Offset: 0x0003272C
		[ProtoMember(12, Name = "growthFundLoginInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLoginInfo
		{
			get
			{
				return this._growthFundLoginInfo;
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06001A6D RID: 6765 RVA: 0x00034544 File Offset: 0x00032744
		// (set) Token: 0x06001A6E RID: 6766 RVA: 0x00034570 File Offset: 0x00032770
		[ProtoMember(13, IsRequired = false, Name = "growthFundClick", DataFormat = DataFormat.Default)]
		public bool growthFundClick
		{
			get
			{
				return this._growthFundClick ?? false;
			}
			set
			{
				this._growthFundClick = new bool?(value);
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06001A6F RID: 6767 RVA: 0x00034580 File Offset: 0x00032780
		// (set) Token: 0x06001A70 RID: 6768 RVA: 0x000345A0 File Offset: 0x000327A0
		[XmlIgnore]
		[Browsable(false)]
		public bool growthFundClickSpecified
		{
			get
			{
				return this._growthFundClick != null;
			}
			set
			{
				bool flag = value == (this._growthFundClick == null);
				if (flag)
				{
					this._growthFundClick = (value ? new bool?(this.growthFundClick) : null);
				}
			}
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x000345E4 File Offset: 0x000327E4
		private bool ShouldSerializegrowthFundClick()
		{
			return this.growthFundClickSpecified;
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x000345FC File Offset: 0x000327FC
		private void ResetgrowthFundClick()
		{
			this.growthFundClickSpecified = false;
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06001A73 RID: 6771 RVA: 0x00034608 File Offset: 0x00032808
		[ProtoMember(14, Name = "VipLevelGift", DataFormat = DataFormat.TwosComplement)]
		public List<int> VipLevelGift
		{
			get
			{
				return this._VipLevelGift;
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06001A74 RID: 6772 RVA: 0x00034620 File Offset: 0x00032820
		// (set) Token: 0x06001A75 RID: 6773 RVA: 0x0003464C File Offset: 0x0003284C
		[ProtoMember(15, IsRequired = false, Name = "payCardRemainTime", DataFormat = DataFormat.TwosComplement)]
		public uint payCardRemainTime
		{
			get
			{
				return this._payCardRemainTime ?? 0U;
			}
			set
			{
				this._payCardRemainTime = new uint?(value);
			}
		}

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06001A76 RID: 6774 RVA: 0x0003465C File Offset: 0x0003285C
		// (set) Token: 0x06001A77 RID: 6775 RVA: 0x0003467C File Offset: 0x0003287C
		[XmlIgnore]
		[Browsable(false)]
		public bool payCardRemainTimeSpecified
		{
			get
			{
				return this._payCardRemainTime != null;
			}
			set
			{
				bool flag = value == (this._payCardRemainTime == null);
				if (flag)
				{
					this._payCardRemainTime = (value ? new uint?(this.payCardRemainTime) : null);
				}
			}
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x000346C0 File Offset: 0x000328C0
		private bool ShouldSerializepayCardRemainTime()
		{
			return this.payCardRemainTimeSpecified;
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x000346D8 File Offset: 0x000328D8
		private void ResetpayCardRemainTime()
		{
			this.payCardRemainTimeSpecified = false;
		}

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06001A7A RID: 6778 RVA: 0x000346E4 File Offset: 0x000328E4
		// (set) Token: 0x06001A7B RID: 6779 RVA: 0x00034710 File Offset: 0x00032910
		[ProtoMember(16, IsRequired = false, Name = "totalLoginDays", DataFormat = DataFormat.TwosComplement)]
		public uint totalLoginDays
		{
			get
			{
				return this._totalLoginDays ?? 0U;
			}
			set
			{
				this._totalLoginDays = new uint?(value);
			}
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06001A7C RID: 6780 RVA: 0x00034720 File Offset: 0x00032920
		// (set) Token: 0x06001A7D RID: 6781 RVA: 0x00034740 File Offset: 0x00032940
		[XmlIgnore]
		[Browsable(false)]
		public bool totalLoginDaysSpecified
		{
			get
			{
				return this._totalLoginDays != null;
			}
			set
			{
				bool flag = value == (this._totalLoginDays == null);
				if (flag)
				{
					this._totalLoginDays = (value ? new uint?(this.totalLoginDays) : null);
				}
			}
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x00034784 File Offset: 0x00032984
		private bool ShouldSerializetotalLoginDays()
		{
			return this.totalLoginDaysSpecified;
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x0003479C File Offset: 0x0003299C
		private void ResettotalLoginDays()
		{
			this.totalLoginDaysSpecified = false;
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06001A80 RID: 6784 RVA: 0x000347A8 File Offset: 0x000329A8
		// (set) Token: 0x06001A81 RID: 6785 RVA: 0x000347D4 File Offset: 0x000329D4
		[ProtoMember(17, IsRequired = false, Name = "payType", DataFormat = DataFormat.TwosComplement)]
		public int payType
		{
			get
			{
				return this._payType ?? 0;
			}
			set
			{
				this._payType = new int?(value);
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06001A82 RID: 6786 RVA: 0x000347E4 File Offset: 0x000329E4
		// (set) Token: 0x06001A83 RID: 6787 RVA: 0x00034804 File Offset: 0x00032A04
		[XmlIgnore]
		[Browsable(false)]
		public bool payTypeSpecified
		{
			get
			{
				return this._payType != null;
			}
			set
			{
				bool flag = value == (this._payType == null);
				if (flag)
				{
					this._payType = (value ? new int?(this.payType) : null);
				}
			}
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x00034848 File Offset: 0x00032A48
		private bool ShouldSerializepayType()
		{
			return this.payTypeSpecified;
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00034860 File Offset: 0x00032A60
		private void ResetpayType()
		{
			this.payTypeSpecified = false;
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06001A86 RID: 6790 RVA: 0x0003486C File Offset: 0x00032A6C
		[ProtoMember(18, Name = "payMemberInfo", DataFormat = DataFormat.Default)]
		public List<PayMember> payMemberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06001A87 RID: 6791 RVA: 0x00034884 File Offset: 0x00032A84
		// (set) Token: 0x06001A88 RID: 6792 RVA: 0x000348B0 File Offset: 0x00032AB0
		[ProtoMember(19, IsRequired = false, Name = "isIosOpen", DataFormat = DataFormat.Default)]
		public bool isIosOpen
		{
			get
			{
				return this._isIosOpen ?? false;
			}
			set
			{
				this._isIosOpen = new bool?(value);
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06001A89 RID: 6793 RVA: 0x000348C0 File Offset: 0x00032AC0
		// (set) Token: 0x06001A8A RID: 6794 RVA: 0x000348E0 File Offset: 0x00032AE0
		[XmlIgnore]
		[Browsable(false)]
		public bool isIosOpenSpecified
		{
			get
			{
				return this._isIosOpen != null;
			}
			set
			{
				bool flag = value == (this._isIosOpen == null);
				if (flag)
				{
					this._isIosOpen = (value ? new bool?(this.isIosOpen) : null);
				}
			}
		}

		// Token: 0x06001A8B RID: 6795 RVA: 0x00034924 File Offset: 0x00032B24
		private bool ShouldSerializeisIosOpen()
		{
			return this.isIosOpenSpecified;
		}

		// Token: 0x06001A8C RID: 6796 RVA: 0x0003493C File Offset: 0x00032B3C
		private void ResetisIosOpen()
		{
			this.isIosOpenSpecified = false;
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06001A8D RID: 6797 RVA: 0x00034948 File Offset: 0x00032B48
		// (set) Token: 0x06001A8E RID: 6798 RVA: 0x00034974 File Offset: 0x00032B74
		[ProtoMember(20, IsRequired = false, Name = "rewardCoolTime", DataFormat = DataFormat.TwosComplement)]
		public uint rewardCoolTime
		{
			get
			{
				return this._rewardCoolTime ?? 0U;
			}
			set
			{
				this._rewardCoolTime = new uint?(value);
			}
		}

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06001A8F RID: 6799 RVA: 0x00034984 File Offset: 0x00032B84
		// (set) Token: 0x06001A90 RID: 6800 RVA: 0x000349A4 File Offset: 0x00032BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardCoolTimeSpecified
		{
			get
			{
				return this._rewardCoolTime != null;
			}
			set
			{
				bool flag = value == (this._rewardCoolTime == null);
				if (flag)
				{
					this._rewardCoolTime = (value ? new uint?(this.rewardCoolTime) : null);
				}
			}
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x000349E8 File Offset: 0x00032BE8
		private bool ShouldSerializerewardCoolTime()
		{
			return this.rewardCoolTimeSpecified;
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x00034A00 File Offset: 0x00032C00
		private void ResetrewardCoolTime()
		{
			this.rewardCoolTimeSpecified = false;
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x00034A0C File Offset: 0x00032C0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000688 RID: 1672
		private readonly List<PayBaseInfo> _pay = new List<PayBaseInfo>();

		// Token: 0x04000689 RID: 1673
		private readonly List<PayCard> _card = new List<PayCard>();

		// Token: 0x0400068A RID: 1674
		private PayAileen _aileen = null;

		// Token: 0x0400068B RID: 1675
		private uint? _vipLevel;

		// Token: 0x0400068C RID: 1676
		private uint? _totalPay;

		// Token: 0x0400068D RID: 1677
		private bool? _payCardFirstClick;

		// Token: 0x0400068E RID: 1678
		private bool? _payAileenFirstClick;

		// Token: 0x0400068F RID: 1679
		private bool? _payFirstAward;

		// Token: 0x04000690 RID: 1680
		private bool? _payFirstAwardClick;

		// Token: 0x04000691 RID: 1681
		private bool? _buyGrowthFund;

		// Token: 0x04000692 RID: 1682
		private readonly List<int> _growthFundLevelInfo = new List<int>();

		// Token: 0x04000693 RID: 1683
		private readonly List<int> _growthFundLoginInfo = new List<int>();

		// Token: 0x04000694 RID: 1684
		private bool? _growthFundClick;

		// Token: 0x04000695 RID: 1685
		private readonly List<int> _VipLevelGift = new List<int>();

		// Token: 0x04000696 RID: 1686
		private uint? _payCardRemainTime;

		// Token: 0x04000697 RID: 1687
		private uint? _totalLoginDays;

		// Token: 0x04000698 RID: 1688
		private int? _payType;

		// Token: 0x04000699 RID: 1689
		private readonly List<PayMember> _payMemberInfo = new List<PayMember>();

		// Token: 0x0400069A RID: 1690
		private bool? _isIosOpen;

		// Token: 0x0400069B RID: 1691
		private uint? _rewardCoolTime;

		// Token: 0x0400069C RID: 1692
		private IExtension extensionObject;
	}
}
