using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062C RID: 1580
	[ProtoContract(Name = "IBShopAllRecord")]
	[Serializable]
	public class IBShopAllRecord : IExtensible
	{
		// Token: 0x17001E83 RID: 7811
		// (get) Token: 0x060060FD RID: 24829 RVA: 0x000B9040 File Offset: 0x000B7240
		// (set) Token: 0x060060FE RID: 24830 RVA: 0x000B906C File Offset: 0x000B726C
		[ProtoMember(1, IsRequired = false, Name = "nLastTime", DataFormat = DataFormat.TwosComplement)]
		public uint nLastTime
		{
			get
			{
				return this._nLastTime ?? 0U;
			}
			set
			{
				this._nLastTime = new uint?(value);
			}
		}

		// Token: 0x17001E84 RID: 7812
		// (get) Token: 0x060060FF RID: 24831 RVA: 0x000B907C File Offset: 0x000B727C
		// (set) Token: 0x06006100 RID: 24832 RVA: 0x000B909C File Offset: 0x000B729C
		[XmlIgnore]
		[Browsable(false)]
		public bool nLastTimeSpecified
		{
			get
			{
				return this._nLastTime != null;
			}
			set
			{
				bool flag = value == (this._nLastTime == null);
				if (flag)
				{
					this._nLastTime = (value ? new uint?(this.nLastTime) : null);
				}
			}
		}

		// Token: 0x06006101 RID: 24833 RVA: 0x000B90E0 File Offset: 0x000B72E0
		private bool ShouldSerializenLastTime()
		{
			return this.nLastTimeSpecified;
		}

		// Token: 0x06006102 RID: 24834 RVA: 0x000B90F8 File Offset: 0x000B72F8
		private void ResetnLastTime()
		{
			this.nLastTimeSpecified = false;
		}

		// Token: 0x17001E85 RID: 7813
		// (get) Token: 0x06006103 RID: 24835 RVA: 0x000B9104 File Offset: 0x000B7304
		[ProtoMember(2, Name = "allIBShopItems", DataFormat = DataFormat.Default)]
		public List<IBShopOneRecord> allIBShopItems
		{
			get
			{
				return this._allIBShopItems;
			}
		}

		// Token: 0x17001E86 RID: 7814
		// (get) Token: 0x06006104 RID: 24836 RVA: 0x000B911C File Offset: 0x000B731C
		// (set) Token: 0x06006105 RID: 24837 RVA: 0x000B9148 File Offset: 0x000B7348
		[ProtoMember(3, IsRequired = false, Name = "nVipLv", DataFormat = DataFormat.TwosComplement)]
		public uint nVipLv
		{
			get
			{
				return this._nVipLv ?? 0U;
			}
			set
			{
				this._nVipLv = new uint?(value);
			}
		}

		// Token: 0x17001E87 RID: 7815
		// (get) Token: 0x06006106 RID: 24838 RVA: 0x000B9158 File Offset: 0x000B7358
		// (set) Token: 0x06006107 RID: 24839 RVA: 0x000B9178 File Offset: 0x000B7378
		[XmlIgnore]
		[Browsable(false)]
		public bool nVipLvSpecified
		{
			get
			{
				return this._nVipLv != null;
			}
			set
			{
				bool flag = value == (this._nVipLv == null);
				if (flag)
				{
					this._nVipLv = (value ? new uint?(this.nVipLv) : null);
				}
			}
		}

		// Token: 0x06006108 RID: 24840 RVA: 0x000B91BC File Offset: 0x000B73BC
		private bool ShouldSerializenVipLv()
		{
			return this.nVipLvSpecified;
		}

		// Token: 0x06006109 RID: 24841 RVA: 0x000B91D4 File Offset: 0x000B73D4
		private void ResetnVipLv()
		{
			this.nVipLvSpecified = false;
		}

		// Token: 0x17001E88 RID: 7816
		// (get) Token: 0x0600610A RID: 24842 RVA: 0x000B91E0 File Offset: 0x000B73E0
		// (set) Token: 0x0600610B RID: 24843 RVA: 0x000B920C File Offset: 0x000B740C
		[ProtoMember(4, IsRequired = false, Name = "bLimitHot", DataFormat = DataFormat.Default)]
		public bool bLimitHot
		{
			get
			{
				return this._bLimitHot ?? false;
			}
			set
			{
				this._bLimitHot = new bool?(value);
			}
		}

		// Token: 0x17001E89 RID: 7817
		// (get) Token: 0x0600610C RID: 24844 RVA: 0x000B921C File Offset: 0x000B741C
		// (set) Token: 0x0600610D RID: 24845 RVA: 0x000B923C File Offset: 0x000B743C
		[XmlIgnore]
		[Browsable(false)]
		public bool bLimitHotSpecified
		{
			get
			{
				return this._bLimitHot != null;
			}
			set
			{
				bool flag = value == (this._bLimitHot == null);
				if (flag)
				{
					this._bLimitHot = (value ? new bool?(this.bLimitHot) : null);
				}
			}
		}

		// Token: 0x0600610E RID: 24846 RVA: 0x000B9280 File Offset: 0x000B7480
		private bool ShouldSerializebLimitHot()
		{
			return this.bLimitHotSpecified;
		}

		// Token: 0x0600610F RID: 24847 RVA: 0x000B9298 File Offset: 0x000B7498
		private void ResetbLimitHot()
		{
			this.bLimitHotSpecified = false;
		}

		// Token: 0x17001E8A RID: 7818
		// (get) Token: 0x06006110 RID: 24848 RVA: 0x000B92A4 File Offset: 0x000B74A4
		[ProtoMember(5, Name = "orders", DataFormat = DataFormat.Default)]
		public List<IBGiftOrder> orders
		{
			get
			{
				return this._orders;
			}
		}

		// Token: 0x17001E8B RID: 7819
		// (get) Token: 0x06006111 RID: 24849 RVA: 0x000B92BC File Offset: 0x000B74BC
		// (set) Token: 0x06006112 RID: 24850 RVA: 0x000B92E8 File Offset: 0x000B74E8
		[ProtoMember(6, IsRequired = false, Name = "paydegree", DataFormat = DataFormat.TwosComplement)]
		public uint paydegree
		{
			get
			{
				return this._paydegree ?? 0U;
			}
			set
			{
				this._paydegree = new uint?(value);
			}
		}

		// Token: 0x17001E8C RID: 7820
		// (get) Token: 0x06006113 RID: 24851 RVA: 0x000B92F8 File Offset: 0x000B74F8
		// (set) Token: 0x06006114 RID: 24852 RVA: 0x000B9318 File Offset: 0x000B7518
		[XmlIgnore]
		[Browsable(false)]
		public bool paydegreeSpecified
		{
			get
			{
				return this._paydegree != null;
			}
			set
			{
				bool flag = value == (this._paydegree == null);
				if (flag)
				{
					this._paydegree = (value ? new uint?(this.paydegree) : null);
				}
			}
		}

		// Token: 0x06006115 RID: 24853 RVA: 0x000B935C File Offset: 0x000B755C
		private bool ShouldSerializepaydegree()
		{
			return this.paydegreeSpecified;
		}

		// Token: 0x06006116 RID: 24854 RVA: 0x000B9374 File Offset: 0x000B7574
		private void Resetpaydegree()
		{
			this.paydegreeSpecified = false;
		}

		// Token: 0x17001E8D RID: 7821
		// (get) Token: 0x06006117 RID: 24855 RVA: 0x000B9380 File Offset: 0x000B7580
		// (set) Token: 0x06006118 RID: 24856 RVA: 0x000B93AC File Offset: 0x000B75AC
		[ProtoMember(7, IsRequired = false, Name = "daytime", DataFormat = DataFormat.TwosComplement)]
		public uint daytime
		{
			get
			{
				return this._daytime ?? 0U;
			}
			set
			{
				this._daytime = new uint?(value);
			}
		}

		// Token: 0x17001E8E RID: 7822
		// (get) Token: 0x06006119 RID: 24857 RVA: 0x000B93BC File Offset: 0x000B75BC
		// (set) Token: 0x0600611A RID: 24858 RVA: 0x000B93DC File Offset: 0x000B75DC
		[XmlIgnore]
		[Browsable(false)]
		public bool daytimeSpecified
		{
			get
			{
				return this._daytime != null;
			}
			set
			{
				bool flag = value == (this._daytime == null);
				if (flag)
				{
					this._daytime = (value ? new uint?(this.daytime) : null);
				}
			}
		}

		// Token: 0x0600611B RID: 24859 RVA: 0x000B9420 File Offset: 0x000B7620
		private bool ShouldSerializedaytime()
		{
			return this.daytimeSpecified;
		}

		// Token: 0x0600611C RID: 24860 RVA: 0x000B9438 File Offset: 0x000B7638
		private void Resetdaytime()
		{
			this.daytimeSpecified = false;
		}

		// Token: 0x0600611D RID: 24861 RVA: 0x000B9444 File Offset: 0x000B7644
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001788 RID: 6024
		private uint? _nLastTime;

		// Token: 0x04001789 RID: 6025
		private readonly List<IBShopOneRecord> _allIBShopItems = new List<IBShopOneRecord>();

		// Token: 0x0400178A RID: 6026
		private uint? _nVipLv;

		// Token: 0x0400178B RID: 6027
		private bool? _bLimitHot;

		// Token: 0x0400178C RID: 6028
		private readonly List<IBGiftOrder> _orders = new List<IBGiftOrder>();

		// Token: 0x0400178D RID: 6029
		private uint? _paydegree;

		// Token: 0x0400178E RID: 6030
		private uint? _daytime;

		// Token: 0x0400178F RID: 6031
		private IExtension extensionObject;
	}
}
