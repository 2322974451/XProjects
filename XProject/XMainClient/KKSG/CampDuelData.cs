using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064C RID: 1612
	[ProtoContract(Name = "CampDuelData")]
	[Serializable]
	public class CampDuelData : IExtensible
	{
		// Token: 0x17001F9F RID: 8095
		// (get) Token: 0x06006443 RID: 25667 RVA: 0x000BF5B8 File Offset: 0x000BD7B8
		// (set) Token: 0x06006444 RID: 25668 RVA: 0x000BF5E4 File Offset: 0x000BD7E4
		[ProtoMember(1, IsRequired = false, Name = "campid", DataFormat = DataFormat.TwosComplement)]
		public uint campid
		{
			get
			{
				return this._campid ?? 0U;
			}
			set
			{
				this._campid = new uint?(value);
			}
		}

		// Token: 0x17001FA0 RID: 8096
		// (get) Token: 0x06006445 RID: 25669 RVA: 0x000BF5F4 File Offset: 0x000BD7F4
		// (set) Token: 0x06006446 RID: 25670 RVA: 0x000BF614 File Offset: 0x000BD814
		[XmlIgnore]
		[Browsable(false)]
		public bool campidSpecified
		{
			get
			{
				return this._campid != null;
			}
			set
			{
				bool flag = value == (this._campid == null);
				if (flag)
				{
					this._campid = (value ? new uint?(this.campid) : null);
				}
			}
		}

		// Token: 0x06006447 RID: 25671 RVA: 0x000BF658 File Offset: 0x000BD858
		private bool ShouldSerializecampid()
		{
			return this.campidSpecified;
		}

		// Token: 0x06006448 RID: 25672 RVA: 0x000BF670 File Offset: 0x000BD870
		private void Resetcampid()
		{
			this.campidSpecified = false;
		}

		// Token: 0x17001FA1 RID: 8097
		// (get) Token: 0x06006449 RID: 25673 RVA: 0x000BF67C File Offset: 0x000BD87C
		// (set) Token: 0x0600644A RID: 25674 RVA: 0x000BF6A8 File Offset: 0x000BD8A8
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001FA2 RID: 8098
		// (get) Token: 0x0600644B RID: 25675 RVA: 0x000BF6B8 File Offset: 0x000BD8B8
		// (set) Token: 0x0600644C RID: 25676 RVA: 0x000BF6D8 File Offset: 0x000BD8D8
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

		// Token: 0x0600644D RID: 25677 RVA: 0x000BF71C File Offset: 0x000BD91C
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x0600644E RID: 25678 RVA: 0x000BF734 File Offset: 0x000BD934
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001FA3 RID: 8099
		// (get) Token: 0x0600644F RID: 25679 RVA: 0x000BF740 File Offset: 0x000BD940
		// (set) Token: 0x06006450 RID: 25680 RVA: 0x000BF76C File Offset: 0x000BD96C
		[ProtoMember(3, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001FA4 RID: 8100
		// (get) Token: 0x06006451 RID: 25681 RVA: 0x000BF77C File Offset: 0x000BD97C
		// (set) Token: 0x06006452 RID: 25682 RVA: 0x000BF79C File Offset: 0x000BD99C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		// Token: 0x06006453 RID: 25683 RVA: 0x000BF7E0 File Offset: 0x000BD9E0
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x06006454 RID: 25684 RVA: 0x000BF7F8 File Offset: 0x000BD9F8
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001FA5 RID: 8101
		// (get) Token: 0x06006455 RID: 25685 RVA: 0x000BF804 File Offset: 0x000BDA04
		// (set) Token: 0x06006456 RID: 25686 RVA: 0x000BF830 File Offset: 0x000BDA30
		[ProtoMember(4, IsRequired = false, Name = "freeInspireCount", DataFormat = DataFormat.TwosComplement)]
		public uint freeInspireCount
		{
			get
			{
				return this._freeInspireCount ?? 0U;
			}
			set
			{
				this._freeInspireCount = new uint?(value);
			}
		}

		// Token: 0x17001FA6 RID: 8102
		// (get) Token: 0x06006457 RID: 25687 RVA: 0x000BF840 File Offset: 0x000BDA40
		// (set) Token: 0x06006458 RID: 25688 RVA: 0x000BF860 File Offset: 0x000BDA60
		[XmlIgnore]
		[Browsable(false)]
		public bool freeInspireCountSpecified
		{
			get
			{
				return this._freeInspireCount != null;
			}
			set
			{
				bool flag = value == (this._freeInspireCount == null);
				if (flag)
				{
					this._freeInspireCount = (value ? new uint?(this.freeInspireCount) : null);
				}
			}
		}

		// Token: 0x06006459 RID: 25689 RVA: 0x000BF8A4 File Offset: 0x000BDAA4
		private bool ShouldSerializefreeInspireCount()
		{
			return this.freeInspireCountSpecified;
		}

		// Token: 0x0600645A RID: 25690 RVA: 0x000BF8BC File Offset: 0x000BDABC
		private void ResetfreeInspireCount()
		{
			this.freeInspireCountSpecified = false;
		}

		// Token: 0x17001FA7 RID: 8103
		// (get) Token: 0x0600645B RID: 25691 RVA: 0x000BF8C8 File Offset: 0x000BDAC8
		// (set) Token: 0x0600645C RID: 25692 RVA: 0x000BF8F4 File Offset: 0x000BDAF4
		[ProtoMember(5, IsRequired = false, Name = "dragonCoinInspireCount", DataFormat = DataFormat.TwosComplement)]
		public uint dragonCoinInspireCount
		{
			get
			{
				return this._dragonCoinInspireCount ?? 0U;
			}
			set
			{
				this._dragonCoinInspireCount = new uint?(value);
			}
		}

		// Token: 0x17001FA8 RID: 8104
		// (get) Token: 0x0600645D RID: 25693 RVA: 0x000BF904 File Offset: 0x000BDB04
		// (set) Token: 0x0600645E RID: 25694 RVA: 0x000BF924 File Offset: 0x000BDB24
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonCoinInspireCountSpecified
		{
			get
			{
				return this._dragonCoinInspireCount != null;
			}
			set
			{
				bool flag = value == (this._dragonCoinInspireCount == null);
				if (flag)
				{
					this._dragonCoinInspireCount = (value ? new uint?(this.dragonCoinInspireCount) : null);
				}
			}
		}

		// Token: 0x0600645F RID: 25695 RVA: 0x000BF968 File Offset: 0x000BDB68
		private bool ShouldSerializedragonCoinInspireCount()
		{
			return this.dragonCoinInspireCountSpecified;
		}

		// Token: 0x06006460 RID: 25696 RVA: 0x000BF980 File Offset: 0x000BDB80
		private void ResetdragonCoinInspireCount()
		{
			this.dragonCoinInspireCountSpecified = false;
		}

		// Token: 0x17001FA9 RID: 8105
		// (get) Token: 0x06006461 RID: 25697 RVA: 0x000BF98C File Offset: 0x000BDB8C
		// (set) Token: 0x06006462 RID: 25698 RVA: 0x000BF9B8 File Offset: 0x000BDBB8
		[ProtoMember(6, IsRequired = false, Name = "isGiveReward", DataFormat = DataFormat.Default)]
		public bool isGiveReward
		{
			get
			{
				return this._isGiveReward ?? false;
			}
			set
			{
				this._isGiveReward = new bool?(value);
			}
		}

		// Token: 0x17001FAA RID: 8106
		// (get) Token: 0x06006463 RID: 25699 RVA: 0x000BF9C8 File Offset: 0x000BDBC8
		// (set) Token: 0x06006464 RID: 25700 RVA: 0x000BF9E8 File Offset: 0x000BDBE8
		[XmlIgnore]
		[Browsable(false)]
		public bool isGiveRewardSpecified
		{
			get
			{
				return this._isGiveReward != null;
			}
			set
			{
				bool flag = value == (this._isGiveReward == null);
				if (flag)
				{
					this._isGiveReward = (value ? new bool?(this.isGiveReward) : null);
				}
			}
		}

		// Token: 0x06006465 RID: 25701 RVA: 0x000BFA2C File Offset: 0x000BDC2C
		private bool ShouldSerializeisGiveReward()
		{
			return this.isGiveRewardSpecified;
		}

		// Token: 0x06006466 RID: 25702 RVA: 0x000BFA44 File Offset: 0x000BDC44
		private void ResetisGiveReward()
		{
			this.isGiveRewardSpecified = false;
		}

		// Token: 0x17001FAB RID: 8107
		// (get) Token: 0x06006467 RID: 25703 RVA: 0x000BFA50 File Offset: 0x000BDC50
		// (set) Token: 0x06006468 RID: 25704 RVA: 0x000BFA7C File Offset: 0x000BDC7C
		[ProtoMember(7, IsRequired = false, Name = "isSendEmail", DataFormat = DataFormat.Default)]
		public bool isSendEmail
		{
			get
			{
				return this._isSendEmail ?? false;
			}
			set
			{
				this._isSendEmail = new bool?(value);
			}
		}

		// Token: 0x17001FAC RID: 8108
		// (get) Token: 0x06006469 RID: 25705 RVA: 0x000BFA8C File Offset: 0x000BDC8C
		// (set) Token: 0x0600646A RID: 25706 RVA: 0x000BFAAC File Offset: 0x000BDCAC
		[XmlIgnore]
		[Browsable(false)]
		public bool isSendEmailSpecified
		{
			get
			{
				return this._isSendEmail != null;
			}
			set
			{
				bool flag = value == (this._isSendEmail == null);
				if (flag)
				{
					this._isSendEmail = (value ? new bool?(this.isSendEmail) : null);
				}
			}
		}

		// Token: 0x0600646B RID: 25707 RVA: 0x000BFAF0 File Offset: 0x000BDCF0
		private bool ShouldSerializeisSendEmail()
		{
			return this.isSendEmailSpecified;
		}

		// Token: 0x0600646C RID: 25708 RVA: 0x000BFB08 File Offset: 0x000BDD08
		private void ResetisSendEmail()
		{
			this.isSendEmailSpecified = false;
		}

		// Token: 0x0600646D RID: 25709 RVA: 0x000BFB14 File Offset: 0x000BDD14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400184E RID: 6222
		private uint? _campid;

		// Token: 0x0400184F RID: 6223
		private uint? _point;

		// Token: 0x04001850 RID: 6224
		private uint? _lastUpdateTime;

		// Token: 0x04001851 RID: 6225
		private uint? _freeInspireCount;

		// Token: 0x04001852 RID: 6226
		private uint? _dragonCoinInspireCount;

		// Token: 0x04001853 RID: 6227
		private bool? _isGiveReward;

		// Token: 0x04001854 RID: 6228
		private bool? _isSendEmail;

		// Token: 0x04001855 RID: 6229
		private IExtension extensionObject;
	}
}
