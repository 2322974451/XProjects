using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageRoleResult")]
	[Serializable]
	public class StageRoleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "money", DataFormat = DataFormat.TwosComplement)]
		public uint money
		{
			get
			{
				return this._money ?? 0U;
			}
			set
			{
				this._money = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moneySpecified
		{
			get
			{
				return this._money != null;
			}
			set
			{
				bool flag = value == (this._money == null);
				if (flag)
				{
					this._money = (value ? new uint?(this.money) : null);
				}
			}
		}

		private bool ShouldSerializemoney()
		{
			return this.moneySpecified;
		}

		private void Resetmoney()
		{
			this.moneySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "stars", DataFormat = DataFormat.TwosComplement)]
		public uint stars
		{
			get
			{
				return this._stars ?? 0U;
			}
			set
			{
				this._stars = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starsSpecified
		{
			get
			{
				return this._stars != null;
			}
			set
			{
				bool flag = value == (this._stars == null);
				if (flag)
				{
					this._stars = (value ? new uint?(this.stars) : null);
				}
			}
		}

		private bool ShouldSerializestars()
		{
			return this.starsSpecified;
		}

		private void Resetstars()
		{
			this.starsSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "firststars", DataFormat = DataFormat.TwosComplement)]
		public uint firststars
		{
			get
			{
				return this._firststars ?? 0U;
			}
			set
			{
				this._firststars = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firststarsSpecified
		{
			get
			{
				return this._firststars != null;
			}
			set
			{
				bool flag = value == (this._firststars == null);
				if (flag)
				{
					this._firststars = (value ? new uint?(this.firststars) : null);
				}
			}
		}

		private bool ShouldSerializefirststars()
		{
			return this.firststarsSpecified;
		}

		private void Resetfirststars()
		{
			this.firststarsSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "startLevel", DataFormat = DataFormat.TwosComplement)]
		public uint startLevel
		{
			get
			{
				return this._startLevel ?? 0U;
			}
			set
			{
				this._startLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startLevelSpecified
		{
			get
			{
				return this._startLevel != null;
			}
			set
			{
				bool flag = value == (this._startLevel == null);
				if (flag)
				{
					this._startLevel = (value ? new uint?(this.startLevel) : null);
				}
			}
		}

		private bool ShouldSerializestartLevel()
		{
			return this.startLevelSpecified;
		}

		private void ResetstartLevel()
		{
			this.startLevelSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "startExp", DataFormat = DataFormat.TwosComplement)]
		public uint startExp
		{
			get
			{
				return this._startExp ?? 0U;
			}
			set
			{
				this._startExp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startExpSpecified
		{
			get
			{
				return this._startExp != null;
			}
			set
			{
				bool flag = value == (this._startExp == null);
				if (flag)
				{
					this._startExp = (value ? new uint?(this.startExp) : null);
				}
			}
		}

		private bool ShouldSerializestartExp()
		{
			return this.startExpSpecified;
		}

		private void ResetstartExp()
		{
			this.startExpSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		[ProtoMember(8, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(9, Name = "starreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> starreward
		{
			get
			{
				return this._starreward;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "guildGoblinResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildGoblinResult guildGoblinResult
		{
			get
			{
				return this._guildGoblinResult;
			}
			set
			{
				this._guildGoblinResult = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "pkresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkResult pkresult
		{
			get
			{
				return this._pkresult;
			}
			set
			{
				this._pkresult = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public float damage
		{
			get
			{
				return this._damage ?? 0f;
			}
			set
			{
				this._damage = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new float?(this.damage) : null);
				}
			}
		}

		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "maxcombo", DataFormat = DataFormat.TwosComplement)]
		public uint maxcombo
		{
			get
			{
				return this._maxcombo ?? 0U;
			}
			set
			{
				this._maxcombo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxcomboSpecified
		{
			get
			{
				return this._maxcombo != null;
			}
			set
			{
				bool flag = value == (this._maxcombo == null);
				if (flag)
				{
					this._maxcombo = (value ? new uint?(this.maxcombo) : null);
				}
			}
		}

		private bool ShouldSerializemaxcombo()
		{
			return this.maxcomboSpecified;
		}

		private void Resetmaxcombo()
		{
			this.maxcomboSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "vipscore", DataFormat = DataFormat.TwosComplement)]
		public uint vipscore
		{
			get
			{
				return this._vipscore ?? 0U;
			}
			set
			{
				this._vipscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipscoreSpecified
		{
			get
			{
				return this._vipscore != null;
			}
			set
			{
				bool flag = value == (this._vipscore == null);
				if (flag)
				{
					this._vipscore = (value ? new uint?(this.vipscore) : null);
				}
			}
		}

		private bool ShouldSerializevipscore()
		{
			return this.vipscoreSpecified;
		}

		private void Resetvipscore()
		{
			this.vipscoreSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public int viplevel
		{
			get
			{
				return this._viplevel ?? 0;
			}
			set
			{
				this._viplevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new int?(this.viplevel) : null);
				}
			}
		}

		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "endlevel", DataFormat = DataFormat.TwosComplement)]
		public uint endlevel
		{
			get
			{
				return this._endlevel ?? 0U;
			}
			set
			{
				this._endlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endlevelSpecified
		{
			get
			{
				return this._endlevel != null;
			}
			set
			{
				bool flag = value == (this._endlevel == null);
				if (flag)
				{
					this._endlevel = (value ? new uint?(this.endlevel) : null);
				}
			}
		}

		private bool ShouldSerializeendlevel()
		{
			return this.endlevelSpecified;
		}

		private void Resetendlevel()
		{
			this.endlevelSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "endexp", DataFormat = DataFormat.TwosComplement)]
		public uint endexp
		{
			get
			{
				return this._endexp ?? 0U;
			}
			set
			{
				this._endexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endexpSpecified
		{
			get
			{
				return this._endexp != null;
			}
			set
			{
				bool flag = value == (this._endexp == null);
				if (flag)
				{
					this._endexp = (value ? new uint?(this.endexp) : null);
				}
			}
		}

		private bool ShouldSerializeendexp()
		{
			return this.endexpSpecified;
		}

		private void Resetendexp()
		{
			this.endexpSpecified = false;
		}

		[ProtoMember(21, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "isLeader", DataFormat = DataFormat.Default)]
		public bool isLeader
		{
			get
			{
				return this._isLeader ?? false;
			}
			set
			{
				this._isLeader = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isLeaderSpecified
		{
			get
			{
				return this._isLeader != null;
			}
			set
			{
				bool flag = value == (this._isLeader == null);
				if (flag)
				{
					this._isLeader = (value ? new bool?(this.isLeader) : null);
				}
			}
		}

		private bool ShouldSerializeisLeader()
		{
			return this.isLeaderSpecified;
		}

		private void ResetisLeader()
		{
			this.isLeaderSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "towerResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TowerResult towerResult
		{
			get
			{
				return this._towerResult;
			}
			set
			{
				this._towerResult = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public int killcount
		{
			get
			{
				return this._killcount ?? 0;
			}
			set
			{
				this._killcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new int?(this.killcount) : null);
				}
			}
		}

		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		[ProtoMember(26, IsRequired = false, Name = "killcontinuemax", DataFormat = DataFormat.TwosComplement)]
		public int killcontinuemax
		{
			get
			{
				return this._killcontinuemax ?? 0;
			}
			set
			{
				this._killcontinuemax = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcontinuemaxSpecified
		{
			get
			{
				return this._killcontinuemax != null;
			}
			set
			{
				bool flag = value == (this._killcontinuemax == null);
				if (flag)
				{
					this._killcontinuemax = (value ? new int?(this.killcontinuemax) : null);
				}
			}
		}

		private bool ShouldSerializekillcontinuemax()
		{
			return this.killcontinuemaxSpecified;
		}

		private void Resetkillcontinuemax()
		{
			this.killcontinuemaxSpecified = false;
		}

		[ProtoMember(27, IsRequired = false, Name = "treat", DataFormat = DataFormat.FixedSize)]
		public float treat
		{
			get
			{
				return this._treat ?? 0f;
			}
			set
			{
				this._treat = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool treatSpecified
		{
			get
			{
				return this._treat != null;
			}
			set
			{
				bool flag = value == (this._treat == null);
				if (flag)
				{
					this._treat = (value ? new float?(this.treat) : null);
				}
			}
		}

		private bool ShouldSerializetreat()
		{
			return this.treatSpecified;
		}

		private void Resettreat()
		{
			this.treatSpecified = false;
		}

		[ProtoMember(28, IsRequired = false, Name = "pvpresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PVPResult pvpresult
		{
			get
			{
				return this._pvpresult;
			}
			set
			{
				this._pvpresult = value;
			}
		}

		[ProtoMember(29, Name = "box", DataFormat = DataFormat.Default)]
		public List<BattleRewardChest> box
		{
			get
			{
				return this._box;
			}
		}

		[ProtoMember(30, Name = "guildreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> guildreward
		{
			get
			{
				return this._guildreward;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "ishelper", DataFormat = DataFormat.Default)]
		public bool ishelper
		{
			get
			{
				return this._ishelper ?? false;
			}
			set
			{
				this._ishelper = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishelperSpecified
		{
			get
			{
				return this._ishelper != null;
			}
			set
			{
				bool flag = value == (this._ishelper == null);
				if (flag)
				{
					this._ishelper = (value ? new bool?(this.ishelper) : null);
				}
			}
		}

		private bool ShouldSerializeishelper()
		{
			return this.ishelperSpecified;
		}

		private void Resetishelper()
		{
			this.ishelperSpecified = false;
		}

		[ProtoMember(32, IsRequired = false, Name = "deresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonExpResult deresult
		{
			get
			{
				return this._deresult;
			}
			set
			{
				this._deresult = value;
			}
		}

		[ProtoMember(33, IsRequired = false, Name = "skycity", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityFinalInfo skycity
		{
			get
			{
				return this._skycity;
			}
			set
			{
				this._skycity = value;
			}
		}

		[ProtoMember(34, IsRequired = false, Name = "isexpseal", DataFormat = DataFormat.Default)]
		public bool isexpseal
		{
			get
			{
				return this._isexpseal ?? false;
			}
			set
			{
				this._isexpseal = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isexpsealSpecified
		{
			get
			{
				return this._isexpseal != null;
			}
			set
			{
				bool flag = value == (this._isexpseal == null);
				if (flag)
				{
					this._isexpseal = (value ? new bool?(this.isexpseal) : null);
				}
			}
		}

		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		[ProtoMember(35, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
		public uint guildexp
		{
			get
			{
				return this._guildexp ?? 0U;
			}
			set
			{
				this._guildexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildexpSpecified
		{
			get
			{
				return this._guildexp != null;
			}
			set
			{
				bool flag = value == (this._guildexp == null);
				if (flag)
				{
					this._guildexp = (value ? new uint?(this.guildexp) : null);
				}
			}
		}

		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		[ProtoMember(36, IsRequired = false, Name = "guildcon", DataFormat = DataFormat.TwosComplement)]
		public uint guildcon
		{
			get
			{
				return this._guildcon ?? 0U;
			}
			set
			{
				this._guildcon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildconSpecified
		{
			get
			{
				return this._guildcon != null;
			}
			set
			{
				bool flag = value == (this._guildcon == null);
				if (flag)
				{
					this._guildcon = (value ? new uint?(this.guildcon) : null);
				}
			}
		}

		private bool ShouldSerializeguildcon()
		{
			return this.guildconSpecified;
		}

		private void Resetguildcon()
		{
			this.guildconSpecified = false;
		}

		[ProtoMember(37, IsRequired = false, Name = "guilddargon", DataFormat = DataFormat.TwosComplement)]
		public uint guilddargon
		{
			get
			{
				return this._guilddargon ?? 0U;
			}
			set
			{
				this._guilddargon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guilddargonSpecified
		{
			get
			{
				return this._guilddargon != null;
			}
			set
			{
				bool flag = value == (this._guilddargon == null);
				if (flag)
				{
					this._guilddargon = (value ? new uint?(this.guilddargon) : null);
				}
			}
		}

		private bool ShouldSerializeguilddargon()
		{
			return this.guilddargonSpecified;
		}

		private void Resetguilddargon()
		{
			this.guilddargonSpecified = false;
		}

		[ProtoMember(38, IsRequired = false, Name = "reswar", DataFormat = DataFormat.TwosComplement)]
		public uint reswar
		{
			get
			{
				return this._reswar ?? 0U;
			}
			set
			{
				this._reswar = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reswarSpecified
		{
			get
			{
				return this._reswar != null;
			}
			set
			{
				bool flag = value == (this._reswar == null);
				if (flag)
				{
					this._reswar = (value ? new uint?(this.reswar) : null);
				}
			}
		}

		private bool ShouldSerializereswar()
		{
			return this.reswarSpecified;
		}

		private void Resetreswar()
		{
			this.reswarSpecified = false;
		}

		[ProtoMember(39, IsRequired = false, Name = "teamcostreward", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief teamcostreward
		{
			get
			{
				return this._teamcostreward;
			}
			set
			{
				this._teamcostreward = value;
			}
		}

		[ProtoMember(40, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		[ProtoMember(41, IsRequired = false, Name = "horse", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseAward horse
		{
			get
			{
				return this._horse;
			}
			set
			{
				this._horse = value;
			}
		}

		[ProtoMember(42, IsRequired = false, Name = "invfightresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public InvFightBattleResult invfightresult
		{
			get
			{
				return this._invfightresult;
			}
			set
			{
				this._invfightresult = value;
			}
		}

		[ProtoMember(43, IsRequired = false, Name = "heroresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroBattleResult heroresult
		{
			get
			{
				return this._heroresult;
			}
			set
			{
				this._heroresult = value;
			}
		}

		[ProtoMember(44, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		[ProtoMember(45, IsRequired = false, Name = "assitnum", DataFormat = DataFormat.TwosComplement)]
		public uint assitnum
		{
			get
			{
				return this._assitnum ?? 0U;
			}
			set
			{
				this._assitnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool assitnumSpecified
		{
			get
			{
				return this._assitnum != null;
			}
			set
			{
				bool flag = value == (this._assitnum == null);
				if (flag)
				{
					this._assitnum = (value ? new uint?(this.assitnum) : null);
				}
			}
		}

		private bool ShouldSerializeassitnum()
		{
			return this.assitnumSpecified;
		}

		private void Resetassitnum()
		{
			this.assitnumSpecified = false;
		}

		[ProtoMember(46, IsRequired = false, Name = "behitdamage", DataFormat = DataFormat.TwosComplement)]
		public uint behitdamage
		{
			get
			{
				return this._behitdamage ?? 0U;
			}
			set
			{
				this._behitdamage = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamageSpecified
		{
			get
			{
				return this._behitdamage != null;
			}
			set
			{
				bool flag = value == (this._behitdamage == null);
				if (flag)
				{
					this._behitdamage = (value ? new uint?(this.behitdamage) : null);
				}
			}
		}

		private bool ShouldSerializebehitdamage()
		{
			return this.behitdamageSpecified;
		}

		private void Resetbehitdamage()
		{
			this.behitdamageSpecified = false;
		}

		[ProtoMember(47, IsRequired = false, Name = "multikillcountmax", DataFormat = DataFormat.TwosComplement)]
		public uint multikillcountmax
		{
			get
			{
				return this._multikillcountmax ?? 0U;
			}
			set
			{
				this._multikillcountmax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool multikillcountmaxSpecified
		{
			get
			{
				return this._multikillcountmax != null;
			}
			set
			{
				bool flag = value == (this._multikillcountmax == null);
				if (flag)
				{
					this._multikillcountmax = (value ? new uint?(this.multikillcountmax) : null);
				}
			}
		}

		private bool ShouldSerializemultikillcountmax()
		{
			return this.multikillcountmaxSpecified;
		}

		private void Resetmultikillcountmax()
		{
			this.multikillcountmaxSpecified = false;
		}

		[ProtoMember(48, IsRequired = false, Name = "custombattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleResult custombattle
		{
			get
			{
				return this._custombattle;
			}
			set
			{
				this._custombattle = value;
			}
		}

		[ProtoMember(49, IsRequired = false, Name = "mobabattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleRoleResult mobabattle
		{
			get
			{
				return this._mobabattle;
			}
			set
			{
				this._mobabattle = value;
			}
		}

		[ProtoMember(50, IsRequired = false, Name = "weekend4v4roledata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeekEnd4v4BattleRoleData weekend4v4roledata
		{
			get
			{
				return this._weekend4v4roledata;
			}
			set
			{
				this._weekend4v4roledata = value;
			}
		}

		[ProtoMember(51, IsRequired = false, Name = "bigmelee", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BigMeleeBattleResult bigmelee
		{
			get
			{
				return this._bigmelee;
			}
			set
			{
				this._bigmelee = value;
			}
		}

		[ProtoMember(52, IsRequired = false, Name = "battlefield", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleFieldBattleResult battlefield
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

		[ProtoMember(53, IsRequired = false, Name = "isboxexcept", DataFormat = DataFormat.Default)]
		public bool isboxexcept
		{
			get
			{
				return this._isboxexcept ?? false;
			}
			set
			{
				this._isboxexcept = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isboxexceptSpecified
		{
			get
			{
				return this._isboxexcept != null;
			}
			set
			{
				bool flag = value == (this._isboxexcept == null);
				if (flag)
				{
					this._isboxexcept = (value ? new bool?(this.isboxexcept) : null);
				}
			}
		}

		private bool ShouldSerializeisboxexcept()
		{
			return this.isboxexceptSpecified;
		}

		private void Resetisboxexcept()
		{
			this.isboxexceptSpecified = false;
		}

		[ProtoMember(54, IsRequired = false, Name = "riftResult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiftResult riftResult
		{
			get
			{
				return this._riftResult;
			}
			set
			{
				this._riftResult = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _money;

		private uint? _exp;

		private uint? _stars;

		private uint? _firststars;

		private uint? _startLevel;

		private uint? _startExp;

		private string _rolename;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private readonly List<ItemBrief> _starreward = new List<ItemBrief>();

		private GuildGoblinResult _guildGoblinResult = null;

		private PkResult _pkresult = null;

		private ulong? _roleid;

		private uint? _score;

		private float? _damage;

		private uint? _deathcount;

		private uint? _maxcombo;

		private uint? _vipscore;

		private int? _viplevel;

		private uint? _endlevel;

		private uint? _endexp;

		private ulong? _gid;

		private bool? _isLeader;

		private int? _profession;

		private TowerResult _towerResult = null;

		private int? _killcount;

		private int? _killcontinuemax;

		private float? _treat;

		private PVPResult _pvpresult = null;

		private readonly List<BattleRewardChest> _box = new List<BattleRewardChest>();

		private readonly List<ItemBrief> _guildreward = new List<ItemBrief>();

		private bool? _ishelper;

		private DragonExpResult _deresult = null;

		private SkyCityFinalInfo _skycity = null;

		private bool? _isexpseal;

		private uint? _guildexp;

		private uint? _guildcon;

		private uint? _guilddargon;

		private uint? _reswar;

		private ItemBrief _teamcostreward = null;

		private uint? _serverid;

		private HorseAward _horse = null;

		private InvFightBattleResult _invfightresult = null;

		private HeroBattleResult _heroresult = null;

		private uint? _military_rank;

		private uint? _assitnum;

		private uint? _behitdamage;

		private uint? _multikillcountmax;

		private CustomBattleResult _custombattle = null;

		private MobaBattleRoleResult _mobabattle = null;

		private WeekEnd4v4BattleRoleData _weekend4v4roledata = null;

		private BigMeleeBattleResult _bigmelee = null;

		private BattleFieldBattleResult _battlefield = null;

		private bool? _isboxexcept;

		private RiftResult _riftResult = null;

		private IExtension extensionObject;
	}
}
