using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayV2Record")]
	[Serializable]
	public class PayV2Record : IExtensible
	{

		[ProtoMember(1, Name = "pay", DataFormat = DataFormat.Default)]
		public List<PayBaseInfo> pay
		{
			get
			{
				return this._pay;
			}
		}

		[ProtoMember(2, Name = "aileen", DataFormat = DataFormat.Default)]
		public List<PayAileenRecord> aileen
		{
			get
			{
				return this._aileen;
			}
		}

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

		private bool ShouldSerializevipPoint()
		{
			return this.vipPointSpecified;
		}

		private void ResetvipPoint()
		{
			this.vipPointSpecified = false;
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

		private bool ShouldSerializepayCardButtonStatus()
		{
			return this.payCardButtonStatusSpecified;
		}

		private void ResetpayCardButtonStatus()
		{
			this.payCardButtonStatusSpecified = false;
		}

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

		private bool ShouldSerializepayAileenButtonStatus()
		{
			return this.payAileenButtonStatusSpecified;
		}

		private void ResetpayAileenButtonStatus()
		{
			this.payAileenButtonStatusSpecified = false;
		}

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

		private bool ShouldSerializelastFirstPayAwardTime()
		{
			return this.lastFirstPayAwardTimeSpecified;
		}

		private void ResetlastFirstPayAwardTime()
		{
			this.lastFirstPayAwardTimeSpecified = false;
		}

		[ProtoMember(9, Name = "growthFundLevelInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> growthFundLevelInfo
		{
			get
			{
				return this._growthFundLevelInfo;
			}
		}

		[ProtoMember(10, Name = "growthFundLoginInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> growthFundLoginInfo
		{
			get
			{
				return this._growthFundLoginInfo;
			}
		}

		[ProtoMember(11, Name = "vipLevelGiftInfo", DataFormat = DataFormat.Default)]
		public List<PayAwardRecord> vipLevelGiftInfo
		{
			get
			{
				return this._vipLevelGiftInfo;
			}
		}

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

		private bool ShouldSerializepayFirstAwardButtonStatus()
		{
			return this.payFirstAwardButtonStatusSpecified;
		}

		private void ResetpayFirstAwardButtonStatus()
		{
			this.payFirstAwardButtonStatusSpecified = false;
		}

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

		private bool ShouldSerializegrowthFundButtonStatus()
		{
			return this.growthFundButtonStatusSpecified;
		}

		private void ResetgrowthFundButtonStatus()
		{
			this.growthFundButtonStatusSpecified = false;
		}

		[ProtoMember(14, Name = "payMemberInfo", DataFormat = DataFormat.Default)]
		public List<PayMemberRecord> payMemberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

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

		private bool ShouldSerializelastUpdateDay()
		{
			return this.lastUpdateDaySpecified;
		}

		private void ResetlastUpdateDay()
		{
			this.lastUpdateDaySpecified = false;
		}

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

		private bool ShouldSerializeisEverPay()
		{
			return this.isEverPaySpecified;
		}

		private void ResetisEverPay()
		{
			this.isEverPaySpecified = false;
		}

		[ProtoMember(18, Name = "consumelist", DataFormat = DataFormat.Default)]
		public List<PayconsumeBrief> consumelist
		{
			get
			{
				return this._consumelist;
			}
		}

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

		private bool ShouldSerializerewardTime()
		{
			return this.rewardTimeSpecified;
		}

		private void ResetrewardTime()
		{
			this.rewardTimeSpecified = false;
		}

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

		private bool ShouldSerializegrowthfundnotifytime()
		{
			return this.growthfundnotifytimeSpecified;
		}

		private void Resetgrowthfundnotifytime()
		{
			this.growthfundnotifytimeSpecified = false;
		}

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

		[ProtoMember(26, Name = "paygift", DataFormat = DataFormat.Default)]
		public List<PayGiftRecord> paygift
		{
			get
			{
				return this._paygift;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PayBaseInfo> _pay = new List<PayBaseInfo>();

		private readonly List<PayAileenRecord> _aileen = new List<PayAileenRecord>();

		private uint? _vipPoint;

		private uint? _vipLevel;

		private uint? _totalPay;

		private uint? _payCardButtonStatus;

		private uint? _payAileenButtonStatus;

		private uint? _lastFirstPayAwardTime;

		private readonly List<PayAwardRecord> _growthFundLevelInfo = new List<PayAwardRecord>();

		private readonly List<PayAwardRecord> _growthFundLoginInfo = new List<PayAwardRecord>();

		private readonly List<PayAwardRecord> _vipLevelGiftInfo = new List<PayAwardRecord>();

		private uint? _payFirstAwardButtonStatus;

		private uint? _growthFundButtonStatus;

		private readonly List<PayMemberRecord> _payMemberInfo = new List<PayMemberRecord>();

		private PayMemberPrivilege _privilege = null;

		private uint? _lastUpdateDay;

		private bool? _isEverPay;

		private readonly List<PayconsumeBrief> _consumelist = new List<PayconsumeBrief>();

		private PaytssInfo _weekcard = null;

		private PaytssInfo _monthcard = null;

		private PaytssInfo _growthfund = null;

		private uint? _rewardTime;

		private uint? _growthfundnotifytime;

		private PayConsume _consume = null;

		private PayConsumeRebate _rebate = null;

		private readonly List<PayGiftRecord> _paygift = new List<PayGiftRecord>();

		private IExtension extensionObject;
	}
}
