using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E8 RID: 1512
	[ProtoContract(Name = "RoleAllInfo")]
	[Serializable]
	public class RoleAllInfo : IExtensible
	{
		// Token: 0x17001B62 RID: 7010
		// (get) Token: 0x06005822 RID: 22562 RVA: 0x000A7FF8 File Offset: 0x000A61F8
		// (set) Token: 0x06005823 RID: 22563 RVA: 0x000A8010 File Offset: 0x000A6210
		[ProtoMember(1, IsRequired = false, Name = "Brief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBrief Brief
		{
			get
			{
				return this._Brief;
			}
			set
			{
				this._Brief = value;
			}
		}

		// Token: 0x17001B63 RID: 7011
		// (get) Token: 0x06005824 RID: 22564 RVA: 0x000A801C File Offset: 0x000A621C
		// (set) Token: 0x06005825 RID: 22565 RVA: 0x000A8034 File Offset: 0x000A6234
		[ProtoMember(2, IsRequired = false, Name = "Attributes", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Attribute Attributes
		{
			get
			{
				return this._Attributes;
			}
			set
			{
				this._Attributes = value;
			}
		}

		// Token: 0x17001B64 RID: 7012
		// (get) Token: 0x06005826 RID: 22566 RVA: 0x000A8040 File Offset: 0x000A6240
		// (set) Token: 0x06005827 RID: 22567 RVA: 0x000A8058 File Offset: 0x000A6258
		[ProtoMember(3, IsRequired = false, Name = "Bag", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BagContent Bag
		{
			get
			{
				return this._Bag;
			}
			set
			{
				this._Bag = value;
			}
		}

		// Token: 0x17001B65 RID: 7013
		// (get) Token: 0x06005828 RID: 22568 RVA: 0x000A8064 File Offset: 0x000A6264
		// (set) Token: 0x06005829 RID: 22569 RVA: 0x000A807C File Offset: 0x000A627C
		[ProtoMember(4, IsRequired = false, Name = "Lottery", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleLotteryInfo Lottery
		{
			get
			{
				return this._Lottery;
			}
			set
			{
				this._Lottery = value;
			}
		}

		// Token: 0x17001B66 RID: 7014
		// (get) Token: 0x0600582A RID: 22570 RVA: 0x000A8088 File Offset: 0x000A6288
		// (set) Token: 0x0600582B RID: 22571 RVA: 0x000A80A0 File Offset: 0x000A62A0
		[ProtoMember(5, IsRequired = false, Name = "Stages", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageInfo Stages
		{
			get
			{
				return this._Stages;
			}
			set
			{
				this._Stages = value;
			}
		}

		// Token: 0x17001B67 RID: 7015
		// (get) Token: 0x0600582C RID: 22572 RVA: 0x000A80AC File Offset: 0x000A62AC
		// (set) Token: 0x0600582D RID: 22573 RVA: 0x000A80C4 File Offset: 0x000A62C4
		[ProtoMember(6, IsRequired = false, Name = "CheckinRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CheckinRecord CheckinRecord
		{
			get
			{
				return this._CheckinRecord;
			}
			set
			{
				this._CheckinRecord = value;
			}
		}

		// Token: 0x17001B68 RID: 7016
		// (get) Token: 0x0600582E RID: 22574 RVA: 0x000A80D0 File Offset: 0x000A62D0
		// (set) Token: 0x0600582F RID: 22575 RVA: 0x000A80E8 File Offset: 0x000A62E8
		[ProtoMember(7, IsRequired = false, Name = "ActivityRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ActivityRecord ActivityRecord
		{
			get
			{
				return this._ActivityRecord;
			}
			set
			{
				this._ActivityRecord = value;
			}
		}

		// Token: 0x17001B69 RID: 7017
		// (get) Token: 0x06005830 RID: 22576 RVA: 0x000A80F4 File Offset: 0x000A62F4
		// (set) Token: 0x06005831 RID: 22577 RVA: 0x000A810C File Offset: 0x000A630C
		[ProtoMember(8, IsRequired = false, Name = "ArenaRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArenaRecord ArenaRecord
		{
			get
			{
				return this._ArenaRecord;
			}
			set
			{
				this._ArenaRecord = value;
			}
		}

		// Token: 0x17001B6A RID: 7018
		// (get) Token: 0x06005832 RID: 22578 RVA: 0x000A8118 File Offset: 0x000A6318
		// (set) Token: 0x06005833 RID: 22579 RVA: 0x000A8130 File Offset: 0x000A6330
		[ProtoMember(9, IsRequired = false, Name = "RewardRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RewardRecord RewardRecord
		{
			get
			{
				return this._RewardRecord;
			}
			set
			{
				this._RewardRecord = value;
			}
		}

		// Token: 0x17001B6B RID: 7019
		// (get) Token: 0x06005834 RID: 22580 RVA: 0x000A813C File Offset: 0x000A633C
		// (set) Token: 0x06005835 RID: 22581 RVA: 0x000A8154 File Offset: 0x000A6354
		[ProtoMember(10, IsRequired = false, Name = "BuyInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuyGoldFatInfo BuyInfo
		{
			get
			{
				return this._BuyInfo;
			}
			set
			{
				this._BuyInfo = value;
			}
		}

		// Token: 0x17001B6C RID: 7020
		// (get) Token: 0x06005836 RID: 22582 RVA: 0x000A8160 File Offset: 0x000A6360
		// (set) Token: 0x06005837 RID: 22583 RVA: 0x000A8178 File Offset: 0x000A6378
		[ProtoMember(11, IsRequired = false, Name = "shoprecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ShopRecord shoprecord
		{
			get
			{
				return this._shoprecord;
			}
			set
			{
				this._shoprecord = value;
			}
		}

		// Token: 0x17001B6D RID: 7021
		// (get) Token: 0x06005838 RID: 22584 RVA: 0x000A8184 File Offset: 0x000A6384
		// (set) Token: 0x06005839 RID: 22585 RVA: 0x000A819C File Offset: 0x000A639C
		[ProtoMember(12, IsRequired = false, Name = "flowerrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public FlowerRecord flowerrecord
		{
			get
			{
				return this._flowerrecord;
			}
			set
			{
				this._flowerrecord = value;
			}
		}

		// Token: 0x17001B6E RID: 7022
		// (get) Token: 0x0600583A RID: 22586 RVA: 0x000A81A8 File Offset: 0x000A63A8
		// (set) Token: 0x0600583B RID: 22587 RVA: 0x000A81C0 File Offset: 0x000A63C0
		[ProtoMember(13, IsRequired = false, Name = "guildrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildRecord guildrecord
		{
			get
			{
				return this._guildrecord;
			}
			set
			{
				this._guildrecord = value;
			}
		}

		// Token: 0x17001B6F RID: 7023
		// (get) Token: 0x0600583C RID: 22588 RVA: 0x000A81CC File Offset: 0x000A63CC
		// (set) Token: 0x0600583D RID: 22589 RVA: 0x000A81E4 File Offset: 0x000A63E4
		[ProtoMember(14, IsRequired = false, Name = "pkrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecord pkrecord
		{
			get
			{
				return this._pkrecord;
			}
			set
			{
				this._pkrecord = value;
			}
		}

		// Token: 0x17001B70 RID: 7024
		// (get) Token: 0x0600583E RID: 22590 RVA: 0x000A81F0 File Offset: 0x000A63F0
		// (set) Token: 0x0600583F RID: 22591 RVA: 0x000A8208 File Offset: 0x000A6408
		[ProtoMember(15, IsRequired = false, Name = "config", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleConfig config
		{
			get
			{
				return this._config;
			}
			set
			{
				this._config = value;
			}
		}

		// Token: 0x17001B71 RID: 7025
		// (get) Token: 0x06005840 RID: 22592 RVA: 0x000A8214 File Offset: 0x000A6414
		// (set) Token: 0x06005841 RID: 22593 RVA: 0x000A822C File Offset: 0x000A642C
		[ProtoMember(16, IsRequired = false, Name = "tshowVoteRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TShowVoteRecord tshowVoteRecord
		{
			get
			{
				return this._tshowVoteRecord;
			}
			set
			{
				this._tshowVoteRecord = value;
			}
		}

		// Token: 0x17001B72 RID: 7026
		// (get) Token: 0x06005842 RID: 22594 RVA: 0x000A8238 File Offset: 0x000A6438
		// (set) Token: 0x06005843 RID: 22595 RVA: 0x000A8250 File Offset: 0x000A6450
		[ProtoMember(17, IsRequired = false, Name = "campRoleRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampRoleRecord campRoleRecord
		{
			get
			{
				return this._campRoleRecord;
			}
			set
			{
				this._campRoleRecord = value;
			}
		}

		// Token: 0x17001B73 RID: 7027
		// (get) Token: 0x06005844 RID: 22596 RVA: 0x000A825C File Offset: 0x000A645C
		// (set) Token: 0x06005845 RID: 22597 RVA: 0x000A8274 File Offset: 0x000A6474
		[ProtoMember(18, IsRequired = false, Name = "findBackRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleFindBackRecord findBackRecord
		{
			get
			{
				return this._findBackRecord;
			}
			set
			{
				this._findBackRecord = value;
			}
		}

		// Token: 0x17001B74 RID: 7028
		// (get) Token: 0x06005846 RID: 22598 RVA: 0x000A8280 File Offset: 0x000A6480
		// (set) Token: 0x06005847 RID: 22599 RVA: 0x000A8298 File Offset: 0x000A6498
		[ProtoMember(19, IsRequired = false, Name = "ExtraInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleExtraInfo ExtraInfo
		{
			get
			{
				return this._ExtraInfo;
			}
			set
			{
				this._ExtraInfo = value;
			}
		}

		// Token: 0x17001B75 RID: 7029
		// (get) Token: 0x06005848 RID: 22600 RVA: 0x000A82A4 File Offset: 0x000A64A4
		// (set) Token: 0x06005849 RID: 22601 RVA: 0x000A82BC File Offset: 0x000A64BC
		[ProtoMember(20, IsRequired = false, Name = "towerRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TowerRecord2DB towerRecord
		{
			get
			{
				return this._towerRecord;
			}
			set
			{
				this._towerRecord = value;
			}
		}

		// Token: 0x17001B76 RID: 7030
		// (get) Token: 0x0600584A RID: 22602 RVA: 0x000A82C8 File Offset: 0x000A64C8
		// (set) Token: 0x0600584B RID: 22603 RVA: 0x000A82E0 File Offset: 0x000A64E0
		[ProtoMember(21, IsRequired = false, Name = "loginrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginRecord loginrecord
		{
			get
			{
				return this._loginrecord;
			}
			set
			{
				this._loginrecord = value;
			}
		}

		// Token: 0x17001B77 RID: 7031
		// (get) Token: 0x0600584C RID: 22604 RVA: 0x000A82EC File Offset: 0x000A64EC
		// (set) Token: 0x0600584D RID: 22605 RVA: 0x000A8304 File Offset: 0x000A6504
		[ProtoMember(22, IsRequired = false, Name = "pvpdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PvpData pvpdata
		{
			get
			{
				return this._pvpdata;
			}
			set
			{
				this._pvpdata = value;
			}
		}

		// Token: 0x17001B78 RID: 7032
		// (get) Token: 0x0600584E RID: 22606 RVA: 0x000A8310 File Offset: 0x000A6510
		// (set) Token: 0x0600584F RID: 22607 RVA: 0x000A8328 File Offset: 0x000A6528
		[ProtoMember(23, IsRequired = false, Name = "qaRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SQARecord qaRecord
		{
			get
			{
				return this._qaRecord;
			}
			set
			{
				this._qaRecord = value;
			}
		}

		// Token: 0x17001B79 RID: 7033
		// (get) Token: 0x06005850 RID: 22608 RVA: 0x000A8334 File Offset: 0x000A6534
		// (set) Token: 0x06005851 RID: 22609 RVA: 0x000A834C File Offset: 0x000A654C
		[ProtoMember(24, IsRequired = false, Name = "dragonInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonRecord2DB dragonInfo
		{
			get
			{
				return this._dragonInfo;
			}
			set
			{
				this._dragonInfo = value;
			}
		}

		// Token: 0x17001B7A RID: 7034
		// (get) Token: 0x06005852 RID: 22610 RVA: 0x000A8358 File Offset: 0x000A6558
		// (set) Token: 0x06005853 RID: 22611 RVA: 0x000A8370 File Offset: 0x000A6570
		[ProtoMember(25, IsRequired = false, Name = "fashionrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public FashionRecord fashionrecord
		{
			get
			{
				return this._fashionrecord;
			}
			set
			{
				this._fashionrecord = value;
			}
		}

		// Token: 0x17001B7B RID: 7035
		// (get) Token: 0x06005854 RID: 22612 RVA: 0x000A837C File Offset: 0x000A657C
		// (set) Token: 0x06005855 RID: 22613 RVA: 0x000A8394 File Offset: 0x000A6594
		[ProtoMember(26, IsRequired = false, Name = "liverecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LiveRecord liverecord
		{
			get
			{
				return this._liverecord;
			}
			set
			{
				this._liverecord = value;
			}
		}

		// Token: 0x17001B7C RID: 7036
		// (get) Token: 0x06005856 RID: 22614 RVA: 0x000A83A0 File Offset: 0x000A65A0
		// (set) Token: 0x06005857 RID: 22615 RVA: 0x000A83B8 File Offset: 0x000A65B8
		[ProtoMember(27, IsRequired = false, Name = "payv2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayV2Record payv2
		{
			get
			{
				return this._payv2;
			}
			set
			{
				this._payv2 = value;
			}
		}

		// Token: 0x17001B7D RID: 7037
		// (get) Token: 0x06005858 RID: 22616 RVA: 0x000A83C4 File Offset: 0x000A65C4
		// (set) Token: 0x06005859 RID: 22617 RVA: 0x000A83DC File Offset: 0x000A65DC
		[ProtoMember(28, IsRequired = false, Name = "petsys", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PetSysData petsys
		{
			get
			{
				return this._petsys;
			}
			set
			{
				this._petsys = value;
			}
		}

		// Token: 0x17001B7E RID: 7038
		// (get) Token: 0x0600585A RID: 22618 RVA: 0x000A83E8 File Offset: 0x000A65E8
		// (set) Token: 0x0600585B RID: 22619 RVA: 0x000A8400 File Offset: 0x000A6600
		[ProtoMember(29, IsRequired = false, Name = "firstPassRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public FirstPassRecord firstPassRecord
		{
			get
			{
				return this._firstPassRecord;
			}
			set
			{
				this._firstPassRecord = value;
			}
		}

		// Token: 0x17001B7F RID: 7039
		// (get) Token: 0x0600585C RID: 22620 RVA: 0x000A840C File Offset: 0x000A660C
		// (set) Token: 0x0600585D RID: 22621 RVA: 0x000A8424 File Offset: 0x000A6624
		[ProtoMember(30, IsRequired = false, Name = "ibShopItems", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public IBShopAllRecord ibShopItems
		{
			get
			{
				return this._ibShopItems;
			}
			set
			{
				this._ibShopItems = value;
			}
		}

		// Token: 0x17001B80 RID: 7040
		// (get) Token: 0x0600585E RID: 22622 RVA: 0x000A8430 File Offset: 0x000A6630
		// (set) Token: 0x0600585F RID: 22623 RVA: 0x000A8448 File Offset: 0x000A6648
		[ProtoMember(31, IsRequired = false, Name = "SpriteRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteRecord SpriteRecord
		{
			get
			{
				return this._SpriteRecord;
			}
			set
			{
				this._SpriteRecord = value;
			}
		}

		// Token: 0x17001B81 RID: 7041
		// (get) Token: 0x06005860 RID: 22624 RVA: 0x000A8454 File Offset: 0x000A6654
		// (set) Token: 0x06005861 RID: 22625 RVA: 0x000A846C File Offset: 0x000A666C
		[ProtoMember(32, IsRequired = false, Name = "atlas", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SAtlasRecord atlas
		{
			get
			{
				return this._atlas;
			}
			set
			{
				this._atlas = value;
			}
		}

		// Token: 0x17001B82 RID: 7042
		// (get) Token: 0x06005862 RID: 22626 RVA: 0x000A8478 File Offset: 0x000A6678
		// (set) Token: 0x06005863 RID: 22627 RVA: 0x000A8490 File Offset: 0x000A6690
		[ProtoMember(33, IsRequired = false, Name = "riskRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskInfo2DB riskRecord
		{
			get
			{
				return this._riskRecord;
			}
			set
			{
				this._riskRecord = value;
			}
		}

		// Token: 0x17001B83 RID: 7043
		// (get) Token: 0x06005864 RID: 22628 RVA: 0x000A849C File Offset: 0x000A669C
		// (set) Token: 0x06005865 RID: 22629 RVA: 0x000A84B4 File Offset: 0x000A66B4
		[ProtoMember(34, IsRequired = false, Name = "task_record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleTask task_record
		{
			get
			{
				return this._task_record;
			}
			set
			{
				this._task_record = value;
			}
		}

		// Token: 0x17001B84 RID: 7044
		// (get) Token: 0x06005866 RID: 22630 RVA: 0x000A84C0 File Offset: 0x000A66C0
		// (set) Token: 0x06005867 RID: 22631 RVA: 0x000A84D8 File Offset: 0x000A66D8
		[ProtoMember(35, IsRequired = false, Name = "idipRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public IdipData idipRecord
		{
			get
			{
				return this._idipRecord;
			}
			set
			{
				this._idipRecord = value;
			}
		}

		// Token: 0x17001B85 RID: 7045
		// (get) Token: 0x06005868 RID: 22632 RVA: 0x000A84E4 File Offset: 0x000A66E4
		// (set) Token: 0x06005869 RID: 22633 RVA: 0x000A84FC File Offset: 0x000A66FC
		[ProtoMember(36, IsRequired = false, Name = "spActivityRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpActivity spActivityRecord
		{
			get
			{
				return this._spActivityRecord;
			}
			set
			{
				this._spActivityRecord = value;
			}
		}

		// Token: 0x17001B86 RID: 7046
		// (get) Token: 0x0600586A RID: 22634 RVA: 0x000A8508 File Offset: 0x000A6708
		// (set) Token: 0x0600586B RID: 22635 RVA: 0x000A8520 File Offset: 0x000A6720
		[ProtoMember(37, IsRequired = false, Name = "designatinoRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Designation2DB designatinoRecord
		{
			get
			{
				return this._designatinoRecord;
			}
			set
			{
				this._designatinoRecord = value;
			}
		}

		// Token: 0x17001B87 RID: 7047
		// (get) Token: 0x0600586C RID: 22636 RVA: 0x000A852C File Offset: 0x000A672C
		// (set) Token: 0x0600586D RID: 22637 RVA: 0x000A8544 File Offset: 0x000A6744
		[ProtoMember(38, IsRequired = false, Name = "levelsealData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LevelSealRecord levelsealData
		{
			get
			{
				return this._levelsealData;
			}
			set
			{
				this._levelsealData = value;
			}
		}

		// Token: 0x17001B88 RID: 7048
		// (get) Token: 0x0600586E RID: 22638 RVA: 0x000A8550 File Offset: 0x000A6750
		// (set) Token: 0x0600586F RID: 22639 RVA: 0x000A8568 File Offset: 0x000A6768
		[ProtoMember(39, IsRequired = false, Name = "buffrecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SBuffRecord buffrecord
		{
			get
			{
				return this._buffrecord;
			}
			set
			{
				this._buffrecord = value;
			}
		}

		// Token: 0x17001B89 RID: 7049
		// (get) Token: 0x06005870 RID: 22640 RVA: 0x000A8574 File Offset: 0x000A6774
		// (set) Token: 0x06005871 RID: 22641 RVA: 0x000A858C File Offset: 0x000A678C
		[ProtoMember(40, IsRequired = false, Name = "pushInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RolePushInfo pushInfo
		{
			get
			{
				return this._pushInfo;
			}
			set
			{
				this._pushInfo = value;
			}
		}

		// Token: 0x17001B8A RID: 7050
		// (get) Token: 0x06005872 RID: 22642 RVA: 0x000A8598 File Offset: 0x000A6798
		// (set) Token: 0x06005873 RID: 22643 RVA: 0x000A85B0 File Offset: 0x000A67B0
		[ProtoMember(41, IsRequired = false, Name = "qqvip", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public QQVipInfo qqvip
		{
			get
			{
				return this._qqvip;
			}
			set
			{
				this._qqvip = value;
			}
		}

		// Token: 0x17001B8B RID: 7051
		// (get) Token: 0x06005874 RID: 22644 RVA: 0x000A85BC File Offset: 0x000A67BC
		// (set) Token: 0x06005875 RID: 22645 RVA: 0x000A85D4 File Offset: 0x000A67D4
		[ProtoMember(42, IsRequired = false, Name = "teamdbinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamRecord teamdbinfo
		{
			get
			{
				return this._teamdbinfo;
			}
			set
			{
				this._teamdbinfo = value;
			}
		}

		// Token: 0x17001B8C RID: 7052
		// (get) Token: 0x06005876 RID: 22646 RVA: 0x000A85E0 File Offset: 0x000A67E0
		// (set) Token: 0x06005877 RID: 22647 RVA: 0x000A85F8 File Offset: 0x000A67F8
		[ProtoMember(43, IsRequired = false, Name = "misc", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleMiscData misc
		{
			get
			{
				return this._misc;
			}
			set
			{
				this._misc = value;
			}
		}

		// Token: 0x17001B8D RID: 7053
		// (get) Token: 0x06005878 RID: 22648 RVA: 0x000A8604 File Offset: 0x000A6804
		// (set) Token: 0x06005879 RID: 22649 RVA: 0x000A861C File Offset: 0x000A681C
		[ProtoMember(44, IsRequired = false, Name = "partner", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RolePartnerData partner
		{
			get
			{
				return this._partner;
			}
			set
			{
				this._partner = value;
			}
		}

		// Token: 0x17001B8E RID: 7054
		// (get) Token: 0x0600587A RID: 22650 RVA: 0x000A8628 File Offset: 0x000A6828
		// (set) Token: 0x0600587B RID: 22651 RVA: 0x000A8640 File Offset: 0x000A6840
		[ProtoMember(45, IsRequired = false, Name = "achieve", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AchieveDbInfo achieve
		{
			get
			{
				return this._achieve;
			}
			set
			{
				this._achieve = value;
			}
		}

		// Token: 0x17001B8F RID: 7055
		// (get) Token: 0x0600587C RID: 22652 RVA: 0x000A864C File Offset: 0x000A684C
		// (set) Token: 0x0600587D RID: 22653 RVA: 0x000A8664 File Offset: 0x000A6864
		[ProtoMember(46, IsRequired = false, Name = "skill", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkillRecord skill
		{
			get
			{
				return this._skill;
			}
			set
			{
				this._skill = value;
			}
		}

		// Token: 0x17001B90 RID: 7056
		// (get) Token: 0x0600587E RID: 22654 RVA: 0x000A8670 File Offset: 0x000A6870
		// (set) Token: 0x0600587F RID: 22655 RVA: 0x000A8688 File Offset: 0x000A6888
		[ProtoMember(47, IsRequired = false, Name = "chat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SChatRecord chat
		{
			get
			{
				return this._chat;
			}
			set
			{
				this._chat = value;
			}
		}

		// Token: 0x17001B91 RID: 7057
		// (get) Token: 0x06005880 RID: 22656 RVA: 0x000A8694 File Offset: 0x000A6894
		// (set) Token: 0x06005881 RID: 22657 RVA: 0x000A86AC File Offset: 0x000A68AC
		[ProtoMember(48, IsRequired = false, Name = "herobattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroBattleRecord herobattle
		{
			get
			{
				return this._herobattle;
			}
			set
			{
				this._herobattle = value;
			}
		}

		// Token: 0x17001B92 RID: 7058
		// (get) Token: 0x06005882 RID: 22658 RVA: 0x000A86B8 File Offset: 0x000A68B8
		// (set) Token: 0x06005883 RID: 22659 RVA: 0x000A86D0 File Offset: 0x000A68D0
		[ProtoMember(49, IsRequired = false, Name = "reportdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ReportDataRecord reportdata
		{
			get
			{
				return this._reportdata;
			}
			set
			{
				this._reportdata = value;
			}
		}

		// Token: 0x17001B93 RID: 7059
		// (get) Token: 0x06005884 RID: 22660 RVA: 0x000A86DC File Offset: 0x000A68DC
		// (set) Token: 0x06005885 RID: 22661 RVA: 0x000A86F4 File Offset: 0x000A68F4
		[ProtoMember(50, IsRequired = false, Name = "system", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleSystem system
		{
			get
			{
				return this._system;
			}
			set
			{
				this._system = value;
			}
		}

		// Token: 0x17001B94 RID: 7060
		// (get) Token: 0x06005886 RID: 22662 RVA: 0x000A8700 File Offset: 0x000A6900
		// (set) Token: 0x06005887 RID: 22663 RVA: 0x000A8718 File Offset: 0x000A6918
		[ProtoMember(51, IsRequired = false, Name = "military", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MilitaryRecord military
		{
			get
			{
				return this._military;
			}
			set
			{
				this._military = value;
			}
		}

		// Token: 0x17001B95 RID: 7061
		// (get) Token: 0x06005888 RID: 22664 RVA: 0x000A8724 File Offset: 0x000A6924
		// (set) Token: 0x06005889 RID: 22665 RVA: 0x000A873C File Offset: 0x000A693C
		[ProtoMember(52, IsRequired = false, Name = "platformshareresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatformShareResult platformshareresult
		{
			get
			{
				return this._platformshareresult;
			}
			set
			{
				this._platformshareresult = value;
			}
		}

		// Token: 0x17001B96 RID: 7062
		// (get) Token: 0x0600588A RID: 22666 RVA: 0x000A8748 File Offset: 0x000A6948
		// (set) Token: 0x0600588B RID: 22667 RVA: 0x000A8760 File Offset: 0x000A6960
		[ProtoMember(53, IsRequired = false, Name = "weekend4v4Data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeekEnd4v4Data weekend4v4Data
		{
			get
			{
				return this._weekend4v4Data;
			}
			set
			{
				this._weekend4v4Data = value;
			}
		}

		// Token: 0x17001B97 RID: 7063
		// (get) Token: 0x0600588C RID: 22668 RVA: 0x000A876C File Offset: 0x000A696C
		// (set) Token: 0x0600588D RID: 22669 RVA: 0x000A8784 File Offset: 0x000A6984
		[ProtoMember(54, IsRequired = false, Name = "tajieHelpRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TajieHelp2DB tajieHelpRecord
		{
			get
			{
				return this._tajieHelpRecord;
			}
			set
			{
				this._tajieHelpRecord = value;
			}
		}

		// Token: 0x17001B98 RID: 7064
		// (get) Token: 0x0600588E RID: 22670 RVA: 0x000A8790 File Offset: 0x000A6990
		// (set) Token: 0x0600588F RID: 22671 RVA: 0x000A87A8 File Offset: 0x000A69A8
		[ProtoMember(55, IsRequired = false, Name = "dragongroupdb", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGroupDB dragongroupdb
		{
			get
			{
				return this._dragongroupdb;
			}
			set
			{
				this._dragongroupdb = value;
			}
		}

		// Token: 0x17001B99 RID: 7065
		// (get) Token: 0x06005890 RID: 22672 RVA: 0x000A87B4 File Offset: 0x000A69B4
		// (set) Token: 0x06005891 RID: 22673 RVA: 0x000A87CC File Offset: 0x000A69CC
		[ProtoMember(56, IsRequired = false, Name = "battlefield", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleFieldData battlefield
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

		// Token: 0x17001B9A RID: 7066
		// (get) Token: 0x06005892 RID: 22674 RVA: 0x000A87D8 File Offset: 0x000A69D8
		// (set) Token: 0x06005893 RID: 22675 RVA: 0x000A87F0 File Offset: 0x000A69F0
		[ProtoMember(57, IsRequired = false, Name = "npcflrec", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public NpcFeelingRecord npcflrec
		{
			get
			{
				return this._npcflrec;
			}
			set
			{
				this._npcflrec = value;
			}
		}

		// Token: 0x17001B9B RID: 7067
		// (get) Token: 0x06005894 RID: 22676 RVA: 0x000A87FC File Offset: 0x000A69FC
		// (set) Token: 0x06005895 RID: 22677 RVA: 0x000A8814 File Offset: 0x000A6A14
		[ProtoMember(58, IsRequired = false, Name = "competeDragonInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CompeteDragonInfo2DB competeDragonInfo
		{
			get
			{
				return this._competeDragonInfo;
			}
			set
			{
				this._competeDragonInfo = value;
			}
		}

		// Token: 0x17001B9C RID: 7068
		// (get) Token: 0x06005896 RID: 22678 RVA: 0x000A8820 File Offset: 0x000A6A20
		// (set) Token: 0x06005897 RID: 22679 RVA: 0x000A8838 File Offset: 0x000A6A38
		[ProtoMember(59, IsRequired = false, Name = "dragonguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGuildRecordData dragonguild
		{
			get
			{
				return this._dragonguild;
			}
			set
			{
				this._dragonguild = value;
			}
		}

		// Token: 0x17001B9D RID: 7069
		// (get) Token: 0x06005898 RID: 22680 RVA: 0x000A8844 File Offset: 0x000A6A44
		// (set) Token: 0x06005899 RID: 22681 RVA: 0x000A885C File Offset: 0x000A6A5C
		[ProtoMember(60, IsRequired = false, Name = "riftRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiftRecord2Db riftRecord
		{
			get
			{
				return this._riftRecord;
			}
			set
			{
				this._riftRecord = value;
			}
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x000A8868 File Offset: 0x000A6A68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400155B RID: 5467
		private RoleBrief _Brief = null;

		// Token: 0x0400155C RID: 5468
		private Attribute _Attributes = null;

		// Token: 0x0400155D RID: 5469
		private BagContent _Bag = null;

		// Token: 0x0400155E RID: 5470
		private RoleLotteryInfo _Lottery = null;

		// Token: 0x0400155F RID: 5471
		private StageInfo _Stages = null;

		// Token: 0x04001560 RID: 5472
		private CheckinRecord _CheckinRecord = null;

		// Token: 0x04001561 RID: 5473
		private ActivityRecord _ActivityRecord = null;

		// Token: 0x04001562 RID: 5474
		private ArenaRecord _ArenaRecord = null;

		// Token: 0x04001563 RID: 5475
		private RewardRecord _RewardRecord = null;

		// Token: 0x04001564 RID: 5476
		private BuyGoldFatInfo _BuyInfo = null;

		// Token: 0x04001565 RID: 5477
		private ShopRecord _shoprecord = null;

		// Token: 0x04001566 RID: 5478
		private FlowerRecord _flowerrecord = null;

		// Token: 0x04001567 RID: 5479
		private GuildRecord _guildrecord = null;

		// Token: 0x04001568 RID: 5480
		private PkRecord _pkrecord = null;

		// Token: 0x04001569 RID: 5481
		private RoleConfig _config = null;

		// Token: 0x0400156A RID: 5482
		private TShowVoteRecord _tshowVoteRecord = null;

		// Token: 0x0400156B RID: 5483
		private CampRoleRecord _campRoleRecord = null;

		// Token: 0x0400156C RID: 5484
		private RoleFindBackRecord _findBackRecord = null;

		// Token: 0x0400156D RID: 5485
		private RoleExtraInfo _ExtraInfo = null;

		// Token: 0x0400156E RID: 5486
		private TowerRecord2DB _towerRecord = null;

		// Token: 0x0400156F RID: 5487
		private LoginRecord _loginrecord = null;

		// Token: 0x04001570 RID: 5488
		private PvpData _pvpdata = null;

		// Token: 0x04001571 RID: 5489
		private SQARecord _qaRecord = null;

		// Token: 0x04001572 RID: 5490
		private DragonRecord2DB _dragonInfo = null;

		// Token: 0x04001573 RID: 5491
		private FashionRecord _fashionrecord = null;

		// Token: 0x04001574 RID: 5492
		private LiveRecord _liverecord = null;

		// Token: 0x04001575 RID: 5493
		private PayV2Record _payv2 = null;

		// Token: 0x04001576 RID: 5494
		private PetSysData _petsys = null;

		// Token: 0x04001577 RID: 5495
		private FirstPassRecord _firstPassRecord = null;

		// Token: 0x04001578 RID: 5496
		private IBShopAllRecord _ibShopItems = null;

		// Token: 0x04001579 RID: 5497
		private SpriteRecord _SpriteRecord = null;

		// Token: 0x0400157A RID: 5498
		private SAtlasRecord _atlas = null;

		// Token: 0x0400157B RID: 5499
		private RiskInfo2DB _riskRecord = null;

		// Token: 0x0400157C RID: 5500
		private RoleTask _task_record = null;

		// Token: 0x0400157D RID: 5501
		private IdipData _idipRecord = null;

		// Token: 0x0400157E RID: 5502
		private SpActivity _spActivityRecord = null;

		// Token: 0x0400157F RID: 5503
		private Designation2DB _designatinoRecord = null;

		// Token: 0x04001580 RID: 5504
		private LevelSealRecord _levelsealData = null;

		// Token: 0x04001581 RID: 5505
		private SBuffRecord _buffrecord = null;

		// Token: 0x04001582 RID: 5506
		private RolePushInfo _pushInfo = null;

		// Token: 0x04001583 RID: 5507
		private QQVipInfo _qqvip = null;

		// Token: 0x04001584 RID: 5508
		private TeamRecord _teamdbinfo = null;

		// Token: 0x04001585 RID: 5509
		private RoleMiscData _misc = null;

		// Token: 0x04001586 RID: 5510
		private RolePartnerData _partner = null;

		// Token: 0x04001587 RID: 5511
		private AchieveDbInfo _achieve = null;

		// Token: 0x04001588 RID: 5512
		private SkillRecord _skill = null;

		// Token: 0x04001589 RID: 5513
		private SChatRecord _chat = null;

		// Token: 0x0400158A RID: 5514
		private HeroBattleRecord _herobattle = null;

		// Token: 0x0400158B RID: 5515
		private ReportDataRecord _reportdata = null;

		// Token: 0x0400158C RID: 5516
		private RoleSystem _system = null;

		// Token: 0x0400158D RID: 5517
		private MilitaryRecord _military = null;

		// Token: 0x0400158E RID: 5518
		private PlatformShareResult _platformshareresult = null;

		// Token: 0x0400158F RID: 5519
		private WeekEnd4v4Data _weekend4v4Data = null;

		// Token: 0x04001590 RID: 5520
		private TajieHelp2DB _tajieHelpRecord = null;

		// Token: 0x04001591 RID: 5521
		private DragonGroupDB _dragongroupdb = null;

		// Token: 0x04001592 RID: 5522
		private BattleFieldData _battlefield = null;

		// Token: 0x04001593 RID: 5523
		private NpcFeelingRecord _npcflrec = null;

		// Token: 0x04001594 RID: 5524
		private CompeteDragonInfo2DB _competeDragonInfo = null;

		// Token: 0x04001595 RID: 5525
		private DragonGuildRecordData _dragonguild = null;

		// Token: 0x04001596 RID: 5526
		private RiftRecord2Db _riftRecord = null;

		// Token: 0x04001597 RID: 5527
		private IExtension extensionObject;
	}
}
