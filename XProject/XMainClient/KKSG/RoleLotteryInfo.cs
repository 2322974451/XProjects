using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleLotteryInfo")]
	[Serializable]
	public class RoleLotteryInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastDrawTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastDrawTime
		{
			get
			{
				return this._lastDrawTime ?? 0U;
			}
			set
			{
				this._lastDrawTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastDrawTimeSpecified
		{
			get
			{
				return this._lastDrawTime != null;
			}
			set
			{
				bool flag = value == (this._lastDrawTime == null);
				if (flag)
				{
					this._lastDrawTime = (value ? new uint?(this.lastDrawTime) : null);
				}
			}
		}

		private bool ShouldSerializelastDrawTime()
		{
			return this.lastDrawTimeSpecified;
		}

		private void ResetlastDrawTime()
		{
			this.lastDrawTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "OneDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint OneDrawCount
		{
			get
			{
				return this._OneDrawCount ?? 0U;
			}
			set
			{
				this._OneDrawCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool OneDrawCountSpecified
		{
			get
			{
				return this._OneDrawCount != null;
			}
			set
			{
				bool flag = value == (this._OneDrawCount == null);
				if (flag)
				{
					this._OneDrawCount = (value ? new uint?(this.OneDrawCount) : null);
				}
			}
		}

		private bool ShouldSerializeOneDrawCount()
		{
			return this.OneDrawCountSpecified;
		}

		private void ResetOneDrawCount()
		{
			this.OneDrawCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "MinimumRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint MinimumRewardCount
		{
			get
			{
				return this._MinimumRewardCount ?? 0U;
			}
			set
			{
				this._MinimumRewardCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool MinimumRewardCountSpecified
		{
			get
			{
				return this._MinimumRewardCount != null;
			}
			set
			{
				bool flag = value == (this._MinimumRewardCount == null);
				if (flag)
				{
					this._MinimumRewardCount = (value ? new uint?(this.MinimumRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializeMinimumRewardCount()
		{
			return this.MinimumRewardCountSpecified;
		}

		private void ResetMinimumRewardCount()
		{
			this.MinimumRewardCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "goldFreeDrawTime", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawTime
		{
			get
			{
				return this._goldFreeDrawTime ?? 0U;
			}
			set
			{
				this._goldFreeDrawTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawTimeSpecified
		{
			get
			{
				return this._goldFreeDrawTime != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawTime == null);
				if (flag)
				{
					this._goldFreeDrawTime = (value ? new uint?(this.goldFreeDrawTime) : null);
				}
			}
		}

		private bool ShouldSerializegoldFreeDrawTime()
		{
			return this.goldFreeDrawTimeSpecified;
		}

		private void ResetgoldFreeDrawTime()
		{
			this.goldFreeDrawTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "goldFreeDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawCount
		{
			get
			{
				return this._goldFreeDrawCount ?? 0U;
			}
			set
			{
				this._goldFreeDrawCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawCountSpecified
		{
			get
			{
				return this._goldFreeDrawCount != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawCount == null);
				if (flag)
				{
					this._goldFreeDrawCount = (value ? new uint?(this.goldFreeDrawCount) : null);
				}
			}
		}

		private bool ShouldSerializegoldFreeDrawCount()
		{
			return this.goldFreeDrawCountSpecified;
		}

		private void ResetgoldFreeDrawCount()
		{
			this.goldFreeDrawCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "goldFreeDrawDay", DataFormat = DataFormat.TwosComplement)]
		public uint goldFreeDrawDay
		{
			get
			{
				return this._goldFreeDrawDay ?? 0U;
			}
			set
			{
				this._goldFreeDrawDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldFreeDrawDaySpecified
		{
			get
			{
				return this._goldFreeDrawDay != null;
			}
			set
			{
				bool flag = value == (this._goldFreeDrawDay == null);
				if (flag)
				{
					this._goldFreeDrawDay = (value ? new uint?(this.goldFreeDrawDay) : null);
				}
			}
		}

		private bool ShouldSerializegoldFreeDrawDay()
		{
			return this.goldFreeDrawDaySpecified;
		}

		private void ResetgoldFreeDrawDay()
		{
			this.goldFreeDrawDaySpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "goldOneDrawCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldOneDrawCount
		{
			get
			{
				return this._goldOneDrawCount ?? 0U;
			}
			set
			{
				this._goldOneDrawCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldOneDrawCountSpecified
		{
			get
			{
				return this._goldOneDrawCount != null;
			}
			set
			{
				bool flag = value == (this._goldOneDrawCount == null);
				if (flag)
				{
					this._goldOneDrawCount = (value ? new uint?(this.goldOneDrawCount) : null);
				}
			}
		}

		private bool ShouldSerializegoldOneDrawCount()
		{
			return this.goldOneDrawCountSpecified;
		}

		private void ResetgoldOneDrawCount()
		{
			this.goldOneDrawCountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "goldMinimumRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint goldMinimumRewardCount
		{
			get
			{
				return this._goldMinimumRewardCount ?? 0U;
			}
			set
			{
				this._goldMinimumRewardCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldMinimumRewardCountSpecified
		{
			get
			{
				return this._goldMinimumRewardCount != null;
			}
			set
			{
				bool flag = value == (this._goldMinimumRewardCount == null);
				if (flag)
				{
					this._goldMinimumRewardCount = (value ? new uint?(this.goldMinimumRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializegoldMinimumRewardCount()
		{
			return this.goldMinimumRewardCountSpecified;
		}

		private void ResetgoldMinimumRewardCount()
		{
			this.goldMinimumRewardCountSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "clickday", DataFormat = DataFormat.TwosComplement)]
		public uint clickday
		{
			get
			{
				return this._clickday ?? 0U;
			}
			set
			{
				this._clickday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool clickdaySpecified
		{
			get
			{
				return this._clickday != null;
			}
			set
			{
				bool flag = value == (this._clickday == null);
				if (flag)
				{
					this._clickday = (value ? new uint?(this.clickday) : null);
				}
			}
		}

		private bool ShouldSerializeclickday()
		{
			return this.clickdaySpecified;
		}

		private void Resetclickday()
		{
			this.clickdaySpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "clickfreetime", DataFormat = DataFormat.TwosComplement)]
		public uint clickfreetime
		{
			get
			{
				return this._clickfreetime ?? 0U;
			}
			set
			{
				this._clickfreetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool clickfreetimeSpecified
		{
			get
			{
				return this._clickfreetime != null;
			}
			set
			{
				bool flag = value == (this._clickfreetime == null);
				if (flag)
				{
					this._clickfreetime = (value ? new uint?(this.clickfreetime) : null);
				}
			}
		}

		private bool ShouldSerializeclickfreetime()
		{
			return this.clickfreetimeSpecified;
		}

		private void Resetclickfreetime()
		{
			this.clickfreetimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "clickfreecount", DataFormat = DataFormat.TwosComplement)]
		public uint clickfreecount
		{
			get
			{
				return this._clickfreecount ?? 0U;
			}
			set
			{
				this._clickfreecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool clickfreecountSpecified
		{
			get
			{
				return this._clickfreecount != null;
			}
			set
			{
				bool flag = value == (this._clickfreecount == null);
				if (flag)
				{
					this._clickfreecount = (value ? new uint?(this.clickfreecount) : null);
				}
			}
		}

		private bool ShouldSerializeclickfreecount()
		{
			return this.clickfreecountSpecified;
		}

		private void Resetclickfreecount()
		{
			this.clickfreecountSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "clickcostcount", DataFormat = DataFormat.TwosComplement)]
		public uint clickcostcount
		{
			get
			{
				return this._clickcostcount ?? 0U;
			}
			set
			{
				this._clickcostcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool clickcostcountSpecified
		{
			get
			{
				return this._clickcostcount != null;
			}
			set
			{
				bool flag = value == (this._clickcostcount == null);
				if (flag)
				{
					this._clickcostcount = (value ? new uint?(this.clickcostcount) : null);
				}
			}
		}

		private bool ShouldSerializeclickcostcount()
		{
			return this.clickcostcountSpecified;
		}

		private void Resetclickcostcount()
		{
			this.clickcostcountSpecified = false;
		}

		[ProtoMember(13, Name = "pandora", DataFormat = DataFormat.Default)]
		public List<PandoraDrop> pandora
		{
			get
			{
				return this._pandora;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "lastGiftUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastGiftUpdateTime
		{
			get
			{
				return this._lastGiftUpdateTime ?? 0U;
			}
			set
			{
				this._lastGiftUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastGiftUpdateTimeSpecified
		{
			get
			{
				return this._lastGiftUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastGiftUpdateTime == null);
				if (flag)
				{
					this._lastGiftUpdateTime = (value ? new uint?(this.lastGiftUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastGiftUpdateTime()
		{
			return this.lastGiftUpdateTimeSpecified;
		}

		private void ResetlastGiftUpdateTime()
		{
			this.lastGiftUpdateTimeSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "shareGiftCount", DataFormat = DataFormat.TwosComplement)]
		public uint shareGiftCount
		{
			get
			{
				return this._shareGiftCount ?? 0U;
			}
			set
			{
				this._shareGiftCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool shareGiftCountSpecified
		{
			get
			{
				return this._shareGiftCount != null;
			}
			set
			{
				bool flag = value == (this._shareGiftCount == null);
				if (flag)
				{
					this._shareGiftCount = (value ? new uint?(this.shareGiftCount) : null);
				}
			}
		}

		private bool ShouldSerializeshareGiftCount()
		{
			return this.shareGiftCountSpecified;
		}

		private void ResetshareGiftCount()
		{
			this.shareGiftCountSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "spriteMinGuarantee", DataFormat = DataFormat.TwosComplement)]
		public uint spriteMinGuarantee
		{
			get
			{
				return this._spriteMinGuarantee ?? 0U;
			}
			set
			{
				this._spriteMinGuarantee = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool spriteMinGuaranteeSpecified
		{
			get
			{
				return this._spriteMinGuarantee != null;
			}
			set
			{
				bool flag = value == (this._spriteMinGuarantee == null);
				if (flag)
				{
					this._spriteMinGuarantee = (value ? new uint?(this.spriteMinGuarantee) : null);
				}
			}
		}

		private bool ShouldSerializespriteMinGuarantee()
		{
			return this.spriteMinGuaranteeSpecified;
		}

		private void ResetspriteMinGuarantee()
		{
			this.spriteMinGuaranteeSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "spriteNextMinGuarantee", DataFormat = DataFormat.TwosComplement)]
		public uint spriteNextMinGuarantee
		{
			get
			{
				return this._spriteNextMinGuarantee ?? 0U;
			}
			set
			{
				this._spriteNextMinGuarantee = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool spriteNextMinGuaranteeSpecified
		{
			get
			{
				return this._spriteNextMinGuarantee != null;
			}
			set
			{
				bool flag = value == (this._spriteNextMinGuarantee == null);
				if (flag)
				{
					this._spriteNextMinGuarantee = (value ? new uint?(this.spriteNextMinGuarantee) : null);
				}
			}
		}

		private bool ShouldSerializespriteNextMinGuarantee()
		{
			return this.spriteNextMinGuaranteeSpecified;
		}

		private void ResetspriteNextMinGuarantee()
		{
			this.spriteNextMinGuaranteeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastDrawTime;

		private uint? _OneDrawCount;

		private uint? _MinimumRewardCount;

		private uint? _goldFreeDrawTime;

		private uint? _goldFreeDrawCount;

		private uint? _goldFreeDrawDay;

		private uint? _goldOneDrawCount;

		private uint? _goldMinimumRewardCount;

		private uint? _clickday;

		private uint? _clickfreetime;

		private uint? _clickfreecount;

		private uint? _clickcostcount;

		private readonly List<PandoraDrop> _pandora = new List<PandoraDrop>();

		private uint? _lastGiftUpdateTime;

		private uint? _shareGiftCount;

		private uint? _spriteMinGuarantee;

		private uint? _spriteNextMinGuarantee;

		private IExtension extensionObject;
	}
}
