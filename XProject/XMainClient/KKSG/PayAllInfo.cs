using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAllInfo")]
	[Serializable]
	public class PayAllInfo : IExtensible
	{

		[ProtoMember(1, Name = "pay", DataFormat = DataFormat.Default)]
		public List<PayBaseInfo> pay
		{
			get
			{
				return this._pay;
			}
		}

		[ProtoMember(2, Name = "card", DataFormat = DataFormat.Default)]
		public List<PayCard> card
		{
			get
			{
				return this._card;
			}
		}

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

		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

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

		private bool ShouldSerializetotalPay()
		{
			return this.totalPaySpecified;
		}

		private void ResettotalPay()
		{
			this.totalPaySpecified = false;
		}

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

		private bool ShouldSerializepayCardFirstClick()
		{
			return this.payCardFirstClickSpecified;
		}

		private void ResetpayCardFirstClick()
		{
			this.payCardFirstClickSpecified = false;
		}

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

		private bool ShouldSerializepayAileenFirstClick()
		{
			return this.payAileenFirstClickSpecified;
		}

		private void ResetpayAileenFirstClick()
		{
			this.payAileenFirstClickSpecified = false;
		}

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

		private bool ShouldSerializepayFirstAward()
		{
			return this.payFirstAwardSpecified;
		}

		private void ResetpayFirstAward()
		{
			this.payFirstAwardSpecified = false;
		}

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

		private bool ShouldSerializepayFirstAwardClick()
		{
			return this.payFirstAwardClickSpecified;
		}

		private void ResetpayFirstAwardClick()
		{
			this.payFirstAwardClickSpecified = false;
		}

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

		private bool ShouldSerializebuyGrowthFund()
		{
			return this.buyGrowthFundSpecified;
		}

		private void ResetbuyGrowthFund()
		{
			this.buyGrowthFundSpecified = false;
		}

		[ProtoMember(11, Name = "growthFundLevelInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLevelInfo
		{
			get
			{
				return this._growthFundLevelInfo;
			}
		}

		[ProtoMember(12, Name = "growthFundLoginInfo", DataFormat = DataFormat.TwosComplement)]
		public List<int> growthFundLoginInfo
		{
			get
			{
				return this._growthFundLoginInfo;
			}
		}

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

		private bool ShouldSerializegrowthFundClick()
		{
			return this.growthFundClickSpecified;
		}

		private void ResetgrowthFundClick()
		{
			this.growthFundClickSpecified = false;
		}

		[ProtoMember(14, Name = "VipLevelGift", DataFormat = DataFormat.TwosComplement)]
		public List<int> VipLevelGift
		{
			get
			{
				return this._VipLevelGift;
			}
		}

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

		private bool ShouldSerializepayCardRemainTime()
		{
			return this.payCardRemainTimeSpecified;
		}

		private void ResetpayCardRemainTime()
		{
			this.payCardRemainTimeSpecified = false;
		}

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

		private bool ShouldSerializetotalLoginDays()
		{
			return this.totalLoginDaysSpecified;
		}

		private void ResettotalLoginDays()
		{
			this.totalLoginDaysSpecified = false;
		}

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

		private bool ShouldSerializepayType()
		{
			return this.payTypeSpecified;
		}

		private void ResetpayType()
		{
			this.payTypeSpecified = false;
		}

		[ProtoMember(18, Name = "payMemberInfo", DataFormat = DataFormat.Default)]
		public List<PayMember> payMemberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

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

		private bool ShouldSerializeisIosOpen()
		{
			return this.isIosOpenSpecified;
		}

		private void ResetisIosOpen()
		{
			this.isIosOpenSpecified = false;
		}

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

		private bool ShouldSerializerewardCoolTime()
		{
			return this.rewardCoolTimeSpecified;
		}

		private void ResetrewardCoolTime()
		{
			this.rewardCoolTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PayBaseInfo> _pay = new List<PayBaseInfo>();

		private readonly List<PayCard> _card = new List<PayCard>();

		private PayAileen _aileen = null;

		private uint? _vipLevel;

		private uint? _totalPay;

		private bool? _payCardFirstClick;

		private bool? _payAileenFirstClick;

		private bool? _payFirstAward;

		private bool? _payFirstAwardClick;

		private bool? _buyGrowthFund;

		private readonly List<int> _growthFundLevelInfo = new List<int>();

		private readonly List<int> _growthFundLoginInfo = new List<int>();

		private bool? _growthFundClick;

		private readonly List<int> _VipLevelGift = new List<int>();

		private uint? _payCardRemainTime;

		private uint? _totalLoginDays;

		private int? _payType;

		private readonly List<PayMember> _payMemberInfo = new List<PayMember>();

		private bool? _isIosOpen;

		private uint? _rewardCoolTime;

		private IExtension extensionObject;
	}
}
