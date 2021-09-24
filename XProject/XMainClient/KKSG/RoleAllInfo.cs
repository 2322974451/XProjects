using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleAllInfo")]
	[Serializable]
	public class RoleAllInfo : IExtensible
	{

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleBrief _Brief = null;

		private Attribute _Attributes = null;

		private BagContent _Bag = null;

		private RoleLotteryInfo _Lottery = null;

		private StageInfo _Stages = null;

		private CheckinRecord _CheckinRecord = null;

		private ActivityRecord _ActivityRecord = null;

		private ArenaRecord _ArenaRecord = null;

		private RewardRecord _RewardRecord = null;

		private BuyGoldFatInfo _BuyInfo = null;

		private ShopRecord _shoprecord = null;

		private FlowerRecord _flowerrecord = null;

		private GuildRecord _guildrecord = null;

		private PkRecord _pkrecord = null;

		private RoleConfig _config = null;

		private TShowVoteRecord _tshowVoteRecord = null;

		private CampRoleRecord _campRoleRecord = null;

		private RoleFindBackRecord _findBackRecord = null;

		private RoleExtraInfo _ExtraInfo = null;

		private TowerRecord2DB _towerRecord = null;

		private LoginRecord _loginrecord = null;

		private PvpData _pvpdata = null;

		private SQARecord _qaRecord = null;

		private DragonRecord2DB _dragonInfo = null;

		private FashionRecord _fashionrecord = null;

		private LiveRecord _liverecord = null;

		private PayV2Record _payv2 = null;

		private PetSysData _petsys = null;

		private FirstPassRecord _firstPassRecord = null;

		private IBShopAllRecord _ibShopItems = null;

		private SpriteRecord _SpriteRecord = null;

		private SAtlasRecord _atlas = null;

		private RiskInfo2DB _riskRecord = null;

		private RoleTask _task_record = null;

		private IdipData _idipRecord = null;

		private SpActivity _spActivityRecord = null;

		private Designation2DB _designatinoRecord = null;

		private LevelSealRecord _levelsealData = null;

		private SBuffRecord _buffrecord = null;

		private RolePushInfo _pushInfo = null;

		private QQVipInfo _qqvip = null;

		private TeamRecord _teamdbinfo = null;

		private RoleMiscData _misc = null;

		private RolePartnerData _partner = null;

		private AchieveDbInfo _achieve = null;

		private SkillRecord _skill = null;

		private SChatRecord _chat = null;

		private HeroBattleRecord _herobattle = null;

		private ReportDataRecord _reportdata = null;

		private RoleSystem _system = null;

		private MilitaryRecord _military = null;

		private PlatformShareResult _platformshareresult = null;

		private WeekEnd4v4Data _weekend4v4Data = null;

		private TajieHelp2DB _tajieHelpRecord = null;

		private DragonGroupDB _dragongroupdb = null;

		private BattleFieldData _battlefield = null;

		private NpcFeelingRecord _npcflrec = null;

		private CompeteDragonInfo2DB _competeDragonInfo = null;

		private DragonGuildRecordData _dragonguild = null;

		private RiftRecord2Db _riftRecord = null;

		private IExtension extensionObject;
	}
}
