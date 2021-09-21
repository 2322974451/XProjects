using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060E RID: 1550
	[ProtoContract(Name = "RoleFindBackRecord")]
	[Serializable]
	public class RoleFindBackRecord : IExtensible
	{
		// Token: 0x17001D4A RID: 7498
		// (get) Token: 0x06005D6E RID: 23918 RVA: 0x000B20DC File Offset: 0x000B02DC
		// (set) Token: 0x06005D6F RID: 23919 RVA: 0x000B2108 File Offset: 0x000B0308
		[ProtoMember(1, IsRequired = false, Name = "openTime", DataFormat = DataFormat.TwosComplement)]
		public int openTime
		{
			get
			{
				return this._openTime ?? 0;
			}
			set
			{
				this._openTime = new int?(value);
			}
		}

		// Token: 0x17001D4B RID: 7499
		// (get) Token: 0x06005D70 RID: 23920 RVA: 0x000B2118 File Offset: 0x000B0318
		// (set) Token: 0x06005D71 RID: 23921 RVA: 0x000B2138 File Offset: 0x000B0338
		[XmlIgnore]
		[Browsable(false)]
		public bool openTimeSpecified
		{
			get
			{
				return this._openTime != null;
			}
			set
			{
				bool flag = value == (this._openTime == null);
				if (flag)
				{
					this._openTime = (value ? new int?(this.openTime) : null);
				}
			}
		}

		// Token: 0x06005D72 RID: 23922 RVA: 0x000B217C File Offset: 0x000B037C
		private bool ShouldSerializeopenTime()
		{
			return this.openTimeSpecified;
		}

		// Token: 0x06005D73 RID: 23923 RVA: 0x000B2194 File Offset: 0x000B0394
		private void ResetopenTime()
		{
			this.openTimeSpecified = false;
		}

		// Token: 0x17001D4C RID: 7500
		// (get) Token: 0x06005D74 RID: 23924 RVA: 0x000B21A0 File Offset: 0x000B03A0
		// (set) Token: 0x06005D75 RID: 23925 RVA: 0x000B21CC File Offset: 0x000B03CC
		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		// Token: 0x17001D4D RID: 7501
		// (get) Token: 0x06005D76 RID: 23926 RVA: 0x000B21DC File Offset: 0x000B03DC
		// (set) Token: 0x06005D77 RID: 23927 RVA: 0x000B21FC File Offset: 0x000B03FC
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06005D78 RID: 23928 RVA: 0x000B2240 File Offset: 0x000B0440
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06005D79 RID: 23929 RVA: 0x000B2258 File Offset: 0x000B0458
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x17001D4E RID: 7502
		// (get) Token: 0x06005D7A RID: 23930 RVA: 0x000B2264 File Offset: 0x000B0464
		// (set) Token: 0x06005D7B RID: 23931 RVA: 0x000B2290 File Offset: 0x000B0490
		[ProtoMember(3, IsRequired = false, Name = "isFoundBack", DataFormat = DataFormat.Default)]
		public bool isFoundBack
		{
			get
			{
				return this._isFoundBack ?? false;
			}
			set
			{
				this._isFoundBack = new bool?(value);
			}
		}

		// Token: 0x17001D4F RID: 7503
		// (get) Token: 0x06005D7C RID: 23932 RVA: 0x000B22A0 File Offset: 0x000B04A0
		// (set) Token: 0x06005D7D RID: 23933 RVA: 0x000B22C0 File Offset: 0x000B04C0
		[XmlIgnore]
		[Browsable(false)]
		public bool isFoundBackSpecified
		{
			get
			{
				return this._isFoundBack != null;
			}
			set
			{
				bool flag = value == (this._isFoundBack == null);
				if (flag)
				{
					this._isFoundBack = (value ? new bool?(this.isFoundBack) : null);
				}
			}
		}

		// Token: 0x06005D7E RID: 23934 RVA: 0x000B2304 File Offset: 0x000B0504
		private bool ShouldSerializeisFoundBack()
		{
			return this.isFoundBackSpecified;
		}

		// Token: 0x06005D7F RID: 23935 RVA: 0x000B231C File Offset: 0x000B051C
		private void ResetisFoundBack()
		{
			this.isFoundBackSpecified = false;
		}

		// Token: 0x17001D50 RID: 7504
		// (get) Token: 0x06005D80 RID: 23936 RVA: 0x000B2328 File Offset: 0x000B0528
		[ProtoMember(4, Name = "usedInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> usedInfos
		{
			get
			{
				return this._usedInfos;
			}
		}

		// Token: 0x17001D51 RID: 7505
		// (get) Token: 0x06005D81 RID: 23937 RVA: 0x000B2340 File Offset: 0x000B0540
		[ProtoMember(5, Name = "curUsedInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> curUsedInfos
		{
			get
			{
				return this._curUsedInfos;
			}
		}

		// Token: 0x17001D52 RID: 7506
		// (get) Token: 0x06005D82 RID: 23938 RVA: 0x000B2358 File Offset: 0x000B0558
		// (set) Token: 0x06005D83 RID: 23939 RVA: 0x000B2384 File Offset: 0x000B0584
		[ProtoMember(6, IsRequired = false, Name = "findBackOpenTime", DataFormat = DataFormat.TwosComplement)]
		public int findBackOpenTime
		{
			get
			{
				return this._findBackOpenTime ?? 0;
			}
			set
			{
				this._findBackOpenTime = new int?(value);
			}
		}

		// Token: 0x17001D53 RID: 7507
		// (get) Token: 0x06005D84 RID: 23940 RVA: 0x000B2394 File Offset: 0x000B0594
		// (set) Token: 0x06005D85 RID: 23941 RVA: 0x000B23B4 File Offset: 0x000B05B4
		[XmlIgnore]
		[Browsable(false)]
		public bool findBackOpenTimeSpecified
		{
			get
			{
				return this._findBackOpenTime != null;
			}
			set
			{
				bool flag = value == (this._findBackOpenTime == null);
				if (flag)
				{
					this._findBackOpenTime = (value ? new int?(this.findBackOpenTime) : null);
				}
			}
		}

		// Token: 0x06005D86 RID: 23942 RVA: 0x000B23F8 File Offset: 0x000B05F8
		private bool ShouldSerializefindBackOpenTime()
		{
			return this.findBackOpenTimeSpecified;
		}

		// Token: 0x06005D87 RID: 23943 RVA: 0x000B2410 File Offset: 0x000B0610
		private void ResetfindBackOpenTime()
		{
			this.findBackOpenTimeSpecified = false;
		}

		// Token: 0x17001D54 RID: 7508
		// (get) Token: 0x06005D88 RID: 23944 RVA: 0x000B241C File Offset: 0x000B061C
		// (set) Token: 0x06005D89 RID: 23945 RVA: 0x000B2448 File Offset: 0x000B0648
		[ProtoMember(7, IsRequired = false, Name = "itemBackUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public int itemBackUpdateTime
		{
			get
			{
				return this._itemBackUpdateTime ?? 0;
			}
			set
			{
				this._itemBackUpdateTime = new int?(value);
			}
		}

		// Token: 0x17001D55 RID: 7509
		// (get) Token: 0x06005D8A RID: 23946 RVA: 0x000B2458 File Offset: 0x000B0658
		// (set) Token: 0x06005D8B RID: 23947 RVA: 0x000B2478 File Offset: 0x000B0678
		[XmlIgnore]
		[Browsable(false)]
		public bool itemBackUpdateTimeSpecified
		{
			get
			{
				return this._itemBackUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._itemBackUpdateTime == null);
				if (flag)
				{
					this._itemBackUpdateTime = (value ? new int?(this.itemBackUpdateTime) : null);
				}
			}
		}

		// Token: 0x06005D8C RID: 23948 RVA: 0x000B24BC File Offset: 0x000B06BC
		private bool ShouldSerializeitemBackUpdateTime()
		{
			return this.itemBackUpdateTimeSpecified;
		}

		// Token: 0x06005D8D RID: 23949 RVA: 0x000B24D4 File Offset: 0x000B06D4
		private void ResetitemBackUpdateTime()
		{
			this.itemBackUpdateTimeSpecified = false;
		}

		// Token: 0x17001D56 RID: 7510
		// (get) Token: 0x06005D8E RID: 23950 RVA: 0x000B24E0 File Offset: 0x000B06E0
		[ProtoMember(8, Name = "itemFindBackInfosHis", DataFormat = DataFormat.Default)]
		public List<ItemFindBackInfo> itemFindBackInfosHis
		{
			get
			{
				return this._itemFindBackInfosHis;
			}
		}

		// Token: 0x17001D57 RID: 7511
		// (get) Token: 0x06005D8F RID: 23951 RVA: 0x000B24F8 File Offset: 0x000B06F8
		[ProtoMember(9, Name = "itemFindBackInfoCur", DataFormat = DataFormat.Default)]
		public List<ItemFindBackInfo> itemFindBackInfoCur
		{
			get
			{
				return this._itemFindBackInfoCur;
			}
		}

		// Token: 0x17001D58 RID: 7512
		// (get) Token: 0x06005D90 RID: 23952 RVA: 0x000B2510 File Offset: 0x000B0710
		// (set) Token: 0x06005D91 RID: 23953 RVA: 0x000B253C File Offset: 0x000B073C
		[ProtoMember(10, IsRequired = false, Name = "unlockSealTime", DataFormat = DataFormat.TwosComplement)]
		public uint unlockSealTime
		{
			get
			{
				return this._unlockSealTime ?? 0U;
			}
			set
			{
				this._unlockSealTime = new uint?(value);
			}
		}

		// Token: 0x17001D59 RID: 7513
		// (get) Token: 0x06005D92 RID: 23954 RVA: 0x000B254C File Offset: 0x000B074C
		// (set) Token: 0x06005D93 RID: 23955 RVA: 0x000B256C File Offset: 0x000B076C
		[XmlIgnore]
		[Browsable(false)]
		public bool unlockSealTimeSpecified
		{
			get
			{
				return this._unlockSealTime != null;
			}
			set
			{
				bool flag = value == (this._unlockSealTime == null);
				if (flag)
				{
					this._unlockSealTime = (value ? new uint?(this.unlockSealTime) : null);
				}
			}
		}

		// Token: 0x06005D94 RID: 23956 RVA: 0x000B25B0 File Offset: 0x000B07B0
		private bool ShouldSerializeunlockSealTime()
		{
			return this.unlockSealTimeSpecified;
		}

		// Token: 0x06005D95 RID: 23957 RVA: 0x000B25C8 File Offset: 0x000B07C8
		private void ResetunlockSealTime()
		{
			this.unlockSealTimeSpecified = false;
		}

		// Token: 0x17001D5A RID: 7514
		// (get) Token: 0x06005D96 RID: 23958 RVA: 0x000B25D4 File Offset: 0x000B07D4
		[ProtoMember(11, Name = "unlockSealData", DataFormat = DataFormat.Default)]
		public List<UnlockSealFindBackData> unlockSealData
		{
			get
			{
				return this._unlockSealData;
			}
		}

		// Token: 0x17001D5B RID: 7515
		// (get) Token: 0x06005D97 RID: 23959 RVA: 0x000B25EC File Offset: 0x000B07EC
		// (set) Token: 0x06005D98 RID: 23960 RVA: 0x000B2618 File Offset: 0x000B0818
		[ProtoMember(12, IsRequired = false, Name = "notifyBackTime", DataFormat = DataFormat.TwosComplement)]
		public int notifyBackTime
		{
			get
			{
				return this._notifyBackTime ?? 0;
			}
			set
			{
				this._notifyBackTime = new int?(value);
			}
		}

		// Token: 0x17001D5C RID: 7516
		// (get) Token: 0x06005D99 RID: 23961 RVA: 0x000B2628 File Offset: 0x000B0828
		// (set) Token: 0x06005D9A RID: 23962 RVA: 0x000B2648 File Offset: 0x000B0848
		[XmlIgnore]
		[Browsable(false)]
		public bool notifyBackTimeSpecified
		{
			get
			{
				return this._notifyBackTime != null;
			}
			set
			{
				bool flag = value == (this._notifyBackTime == null);
				if (flag)
				{
					this._notifyBackTime = (value ? new int?(this.notifyBackTime) : null);
				}
			}
		}

		// Token: 0x06005D9B RID: 23963 RVA: 0x000B268C File Offset: 0x000B088C
		private bool ShouldSerializenotifyBackTime()
		{
			return this.notifyBackTimeSpecified;
		}

		// Token: 0x06005D9C RID: 23964 RVA: 0x000B26A4 File Offset: 0x000B08A4
		private void ResetnotifyBackTime()
		{
			this.notifyBackTimeSpecified = false;
		}

		// Token: 0x06005D9D RID: 23965 RVA: 0x000B26B0 File Offset: 0x000B08B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016B5 RID: 5813
		private int? _openTime;

		// Token: 0x040016B6 RID: 5814
		private int? _updateTime;

		// Token: 0x040016B7 RID: 5815
		private bool? _isFoundBack;

		// Token: 0x040016B8 RID: 5816
		private readonly List<ExpFindBackInfo> _usedInfos = new List<ExpFindBackInfo>();

		// Token: 0x040016B9 RID: 5817
		private readonly List<ExpFindBackInfo> _curUsedInfos = new List<ExpFindBackInfo>();

		// Token: 0x040016BA RID: 5818
		private int? _findBackOpenTime;

		// Token: 0x040016BB RID: 5819
		private int? _itemBackUpdateTime;

		// Token: 0x040016BC RID: 5820
		private readonly List<ItemFindBackInfo> _itemFindBackInfosHis = new List<ItemFindBackInfo>();

		// Token: 0x040016BD RID: 5821
		private readonly List<ItemFindBackInfo> _itemFindBackInfoCur = new List<ItemFindBackInfo>();

		// Token: 0x040016BE RID: 5822
		private uint? _unlockSealTime;

		// Token: 0x040016BF RID: 5823
		private readonly List<UnlockSealFindBackData> _unlockSealData = new List<UnlockSealFindBackData>();

		// Token: 0x040016C0 RID: 5824
		private int? _notifyBackTime;

		// Token: 0x040016C1 RID: 5825
		private IExtension extensionObject;
	}
}
