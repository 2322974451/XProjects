using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RankData")]
	[Serializable]
	public class RankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "RoleId", DataFormat = DataFormat.TwosComplement)]
		public ulong RoleId
		{
			get
			{
				return this._RoleId ?? 0UL;
			}
			set
			{
				this._RoleId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RoleIdSpecified
		{
			get
			{
				return this._RoleId != null;
			}
			set
			{
				bool flag = value == (this._RoleId == null);
				if (flag)
				{
					this._RoleId = (value ? new ulong?(this.RoleId) : null);
				}
			}
		}

		private bool ShouldSerializeRoleId()
		{
			return this.RoleIdSpecified;
		}

		private void ResetRoleId()
		{
			this.RoleIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "RoleName", DataFormat = DataFormat.Default)]
		public string RoleName
		{
			get
			{
				return this._RoleName ?? "";
			}
			set
			{
				this._RoleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RoleNameSpecified
		{
			get
			{
				return this._RoleName != null;
			}
			set
			{
				bool flag = value == (this._RoleName == null);
				if (flag)
				{
					this._RoleName = (value ? this.RoleName : null);
				}
			}
		}

		private bool ShouldSerializeRoleName()
		{
			return this.RoleNameSpecified;
		}

		private void ResetRoleName()
		{
			this.RoleNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "RoleLevel", DataFormat = DataFormat.TwosComplement)]
		public uint RoleLevel
		{
			get
			{
				return this._RoleLevel ?? 0U;
			}
			set
			{
				this._RoleLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RoleLevelSpecified
		{
			get
			{
				return this._RoleLevel != null;
			}
			set
			{
				bool flag = value == (this._RoleLevel == null);
				if (flag)
				{
					this._RoleLevel = (value ? new uint?(this.RoleLevel) : null);
				}
			}
		}

		private bool ShouldSerializeRoleLevel()
		{
			return this.RoleLevelSpecified;
		}

		private void ResetRoleLevel()
		{
			this.RoleLevelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "damage", DataFormat = DataFormat.FixedSize)]
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

		[ProtoMember(6, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "flowercount", DataFormat = DataFormat.TwosComplement)]
		public uint flowercount
		{
			get
			{
				return this._flowercount ?? 0U;
			}
			set
			{
				this._flowercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool flowercountSpecified
		{
			get
			{
				return this._flowercount != null;
			}
			set
			{
				bool flag = value == (this._flowercount == null);
				if (flag)
				{
					this._flowercount = (value ? new uint?(this.flowercount) : null);
				}
			}
		}

		private bool ShouldSerializeflowercount()
		{
			return this.flowercountSpecified;
		}

		private void Resetflowercount()
		{
			this.flowercountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "Rank", DataFormat = DataFormat.TwosComplement)]
		public uint Rank
		{
			get
			{
				return this._Rank ?? 0U;
			}
			set
			{
				this._Rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RankSpecified
		{
			get
			{
				return this._Rank != null;
			}
			set
			{
				bool flag = value == (this._Rank == null);
				if (flag)
				{
					this._Rank = (value ? new uint?(this.Rank) : null);
				}
			}
		}

		private bool ShouldSerializeRank()
		{
			return this.RankSpecified;
		}

		private void ResetRank()
		{
			this.RankSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "tshowvotecount", DataFormat = DataFormat.TwosComplement)]
		public uint tshowvotecount
		{
			get
			{
				return this._tshowvotecount ?? 0U;
			}
			set
			{
				this._tshowvotecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tshowvotecountSpecified
		{
			get
			{
				return this._tshowvotecount != null;
			}
			set
			{
				bool flag = value == (this._tshowvotecount == null);
				if (flag)
				{
					this._tshowvotecount = (value ? new uint?(this.tshowvotecount) : null);
				}
			}
		}

		private bool ShouldSerializetshowvotecount()
		{
			return this.tshowvotecountSpecified;
		}

		private void Resettshowvotecount()
		{
			this.tshowvotecountSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "intervaltimestamp", DataFormat = DataFormat.TwosComplement)]
		public uint intervaltimestamp
		{
			get
			{
				return this._intervaltimestamp ?? 0U;
			}
			set
			{
				this._intervaltimestamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool intervaltimestampSpecified
		{
			get
			{
				return this._intervaltimestamp != null;
			}
			set
			{
				bool flag = value == (this._intervaltimestamp == null);
				if (flag)
				{
					this._intervaltimestamp = (value ? new uint?(this.intervaltimestamp) : null);
				}
			}
		}

		private bool ShouldSerializeintervaltimestamp()
		{
			return this.intervaltimestampSpecified;
		}

		private void Resetintervaltimestamp()
		{
			this.intervaltimestampSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
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
					this._profession = (value ? new uint?(this.profession) : null);
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

		[ProtoMember(15, Name = "RoleIds", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RoleIds
		{
			get
			{
				return this._RoleIds;
			}
		}

		[ProtoMember(16, Name = "RoleNames", DataFormat = DataFormat.Default)]
		public List<string> RoleNames
		{
			get
			{
				return this._RoleNames;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "towerHardLevel", DataFormat = DataFormat.TwosComplement)]
		public uint towerHardLevel
		{
			get
			{
				return this._towerHardLevel ?? 0U;
			}
			set
			{
				this._towerHardLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool towerHardLevelSpecified
		{
			get
			{
				return this._towerHardLevel != null;
			}
			set
			{
				bool flag = value == (this._towerHardLevel == null);
				if (flag)
				{
					this._towerHardLevel = (value ? new uint?(this.towerHardLevel) : null);
				}
			}
		}

		private bool ShouldSerializetowerHardLevel()
		{
			return this.towerHardLevelSpecified;
		}

		private void ResettowerHardLevel()
		{
			this.towerHardLevelSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "towerFloor", DataFormat = DataFormat.TwosComplement)]
		public uint towerFloor
		{
			get
			{
				return this._towerFloor ?? 0U;
			}
			set
			{
				this._towerFloor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool towerFloorSpecified
		{
			get
			{
				return this._towerFloor != null;
			}
			set
			{
				bool flag = value == (this._towerFloor == null);
				if (flag)
				{
					this._towerFloor = (value ? new uint?(this.towerFloor) : null);
				}
			}
		}

		private bool ShouldSerializetowerFloor()
		{
			return this.towerFloorSpecified;
		}

		private void ResettowerFloor()
		{
			this.towerFloorSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "towerThroughTime", DataFormat = DataFormat.TwosComplement)]
		public uint towerThroughTime
		{
			get
			{
				return this._towerThroughTime ?? 0U;
			}
			set
			{
				this._towerThroughTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool towerThroughTimeSpecified
		{
			get
			{
				return this._towerThroughTime != null;
			}
			set
			{
				bool flag = value == (this._towerThroughTime == null);
				if (flag)
				{
					this._towerThroughTime = (value ? new uint?(this.towerThroughTime) : null);
				}
			}
		}

		private bool ShouldSerializetowerThroughTime()
		{
			return this.towerThroughTimeSpecified;
		}

		private void ResettowerThroughTime()
		{
			this.towerThroughTimeSpecified = false;
		}

		[ProtoMember(20, Name = "receiveFlowers", DataFormat = DataFormat.Default)]
		public List<MapIntItem> receiveFlowers
		{
			get
			{
				return this._receiveFlowers;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "guildBossIndex", DataFormat = DataFormat.TwosComplement)]
		public uint guildBossIndex
		{
			get
			{
				return this._guildBossIndex ?? 0U;
			}
			set
			{
				this._guildBossIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossIndexSpecified
		{
			get
			{
				return this._guildBossIndex != null;
			}
			set
			{
				bool flag = value == (this._guildBossIndex == null);
				if (flag)
				{
					this._guildBossIndex = (value ? new uint?(this.guildBossIndex) : null);
				}
			}
		}

		private bool ShouldSerializeguildBossIndex()
		{
			return this.guildBossIndexSpecified;
		}

		private void ResetguildBossIndex()
		{
			this.guildBossIndexSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "guildBossName", DataFormat = DataFormat.Default)]
		public string guildBossName
		{
			get
			{
				return this._guildBossName ?? "";
			}
			set
			{
				this._guildBossName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossNameSpecified
		{
			get
			{
				return this._guildBossName != null;
			}
			set
			{
				bool flag = value == (this._guildBossName == null);
				if (flag)
				{
					this._guildBossName = (value ? this.guildBossName : null);
				}
			}
		}

		private bool ShouldSerializeguildBossName()
		{
			return this.guildBossNameSpecified;
		}

		private void ResetguildBossName()
		{
			this.guildBossNameSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "guildBossDpsMax", DataFormat = DataFormat.Default)]
		public string guildBossDpsMax
		{
			get
			{
				return this._guildBossDpsMax ?? "";
			}
			set
			{
				this._guildBossDpsMax = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildBossDpsMaxSpecified
		{
			get
			{
				return this._guildBossDpsMax != null;
			}
			set
			{
				bool flag = value == (this._guildBossDpsMax == null);
				if (flag)
				{
					this._guildBossDpsMax = (value ? this.guildBossDpsMax : null);
				}
			}
		}

		private bool ShouldSerializeguildBossDpsMax()
		{
			return this.guildBossDpsMaxSpecified;
		}

		private void ResetguildBossDpsMax()
		{
			this.guildBossDpsMaxSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		[ProtoMember(25, Name = "titleIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> titleIDs
		{
			get
			{
				return this._titleIDs;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		[ProtoMember(27, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(28, IsRequired = false, Name = "bossavghppercent", DataFormat = DataFormat.TwosComplement)]
		public uint bossavghppercent
		{
			get
			{
				return this._bossavghppercent ?? 0U;
			}
			set
			{
				this._bossavghppercent = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bossavghppercentSpecified
		{
			get
			{
				return this._bossavghppercent != null;
			}
			set
			{
				bool flag = value == (this._bossavghppercent == null);
				if (flag)
				{
					this._bossavghppercent = (value ? new uint?(this.bossavghppercent) : null);
				}
			}
		}

		private bool ShouldSerializebossavghppercent()
		{
			return this.bossavghppercentSpecified;
		}

		private void Resetbossavghppercent()
		{
			this.bossavghppercentSpecified = false;
		}

		[ProtoMember(29, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public int groupid
		{
			get
			{
				return this._groupid ?? 0;
			}
			set
			{
				this._groupid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new int?(this.groupid) : null);
				}
			}
		}

		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		[ProtoMember(30, IsRequired = false, Name = "petuid", DataFormat = DataFormat.TwosComplement)]
		public ulong petuid
		{
			get
			{
				return this._petuid ?? 0UL;
			}
			set
			{
				this._petuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petuidSpecified
		{
			get
			{
				return this._petuid != null;
			}
			set
			{
				bool flag = value == (this._petuid == null);
				if (flag)
				{
					this._petuid = (value ? new ulong?(this.petuid) : null);
				}
			}
		}

		private bool ShouldSerializepetuid()
		{
			return this.petuidSpecified;
		}

		private void Resetpetuid()
		{
			this.petuidSpecified = false;
		}

		[ProtoMember(31, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public uint petid
		{
			get
			{
				return this._petid ?? 0U;
			}
			set
			{
				this._petid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new uint?(this.petid) : null);
				}
			}
		}

		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		[ProtoMember(32, IsRequired = false, Name = "headpic", DataFormat = DataFormat.Default)]
		public string headpic
		{
			get
			{
				return this._headpic ?? "";
			}
			set
			{
				this._headpic = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool headpicSpecified
		{
			get
			{
				return this._headpic != null;
			}
			set
			{
				bool flag = value == (this._headpic == null);
				if (flag)
				{
					this._headpic = (value ? this.headpic : null);
				}
			}
		}

		private bool ShouldSerializeheadpic()
		{
			return this.headpicSpecified;
		}

		private void Resetheadpic()
		{
			this.headpicSpecified = false;
		}

		[ProtoMember(33, IsRequired = false, Name = "starttype", DataFormat = DataFormat.TwosComplement)]
		public StartUpType starttype
		{
			get
			{
				return this._starttype ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._starttype = new StartUpType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starttypeSpecified
		{
			get
			{
				return this._starttype != null;
			}
			set
			{
				bool flag = value == (this._starttype == null);
				if (flag)
				{
					this._starttype = (value ? new StartUpType?(this.starttype) : null);
				}
			}
		}

		private bool ShouldSerializestarttype()
		{
			return this.starttypeSpecified;
		}

		private void Resetstarttype()
		{
			this.starttypeSpecified = false;
		}

		[ProtoMember(34, IsRequired = false, Name = "is_vip", DataFormat = DataFormat.Default)]
		public bool is_vip
		{
			get
			{
				return this._is_vip ?? false;
			}
			set
			{
				this._is_vip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_vipSpecified
		{
			get
			{
				return this._is_vip != null;
			}
			set
			{
				bool flag = value == (this._is_vip == null);
				if (flag)
				{
					this._is_vip = (value ? new bool?(this.is_vip) : null);
				}
			}
		}

		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		[ProtoMember(35, IsRequired = false, Name = "is_svip", DataFormat = DataFormat.Default)]
		public bool is_svip
		{
			get
			{
				return this._is_svip ?? false;
			}
			set
			{
				this._is_svip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_svipSpecified
		{
			get
			{
				return this._is_svip != null;
			}
			set
			{
				bool flag = value == (this._is_svip == null);
				if (flag)
				{
					this._is_svip = (value ? new bool?(this.is_svip) : null);
				}
			}
		}

		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		[ProtoMember(36, IsRequired = false, Name = "usetime", DataFormat = DataFormat.TwosComplement)]
		public uint usetime
		{
			get
			{
				return this._usetime ?? 0U;
			}
			set
			{
				this._usetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool usetimeSpecified
		{
			get
			{
				return this._usetime != null;
			}
			set
			{
				bool flag = value == (this._usetime == null);
				if (flag)
				{
					this._usetime = (value ? new uint?(this.usetime) : null);
				}
			}
		}

		private bool ShouldSerializeusetime()
		{
			return this.usetimeSpecified;
		}

		private void Resetusetime()
		{
			this.usetimeSpecified = false;
		}

		[ProtoMember(37, IsRequired = false, Name = "leagueinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueRankData leagueinfo
		{
			get
			{
				return this._leagueinfo;
			}
			set
			{
				this._leagueinfo = value;
			}
		}

		[ProtoMember(38, IsRequired = false, Name = "heroinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroRankData heroinfo
		{
			get
			{
				return this._heroinfo;
			}
			set
			{
				this._heroinfo = value;
			}
		}

		[ProtoMember(39, IsRequired = false, Name = "strRoleid", DataFormat = DataFormat.Default)]
		public string strRoleid
		{
			get
			{
				return this._strRoleid ?? "";
			}
			set
			{
				this._strRoleid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool strRoleidSpecified
		{
			get
			{
				return this._strRoleid != null;
			}
			set
			{
				bool flag = value == (this._strRoleid == null);
				if (flag)
				{
					this._strRoleid = (value ? this.strRoleid : null);
				}
			}
		}

		private bool ShouldSerializestrRoleid()
		{
			return this.strRoleidSpecified;
		}

		private void ResetstrRoleid()
		{
			this.strRoleidSpecified = false;
		}

		[ProtoMember(40, IsRequired = false, Name = "starlevel", DataFormat = DataFormat.TwosComplement)]
		public uint starlevel
		{
			get
			{
				return this._starlevel ?? 0U;
			}
			set
			{
				this._starlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starlevelSpecified
		{
			get
			{
				return this._starlevel != null;
			}
			set
			{
				bool flag = value == (this._starlevel == null);
				if (flag)
				{
					this._starlevel = (value ? new uint?(this.starlevel) : null);
				}
			}
		}

		private bool ShouldSerializestarlevel()
		{
			return this.starlevelSpecified;
		}

		private void Resetstarlevel()
		{
			this.starlevelSpecified = false;
		}

		[ProtoMember(41, IsRequired = false, Name = "usectime", DataFormat = DataFormat.TwosComplement)]
		public uint usectime
		{
			get
			{
				return this._usectime ?? 0U;
			}
			set
			{
				this._usectime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool usectimeSpecified
		{
			get
			{
				return this._usectime != null;
			}
			set
			{
				bool flag = value == (this._usectime == null);
				if (flag)
				{
					this._usectime = (value ? new uint?(this.usectime) : null);
				}
			}
		}

		private bool ShouldSerializeusectime()
		{
			return this.usectimeSpecified;
		}

		private void Resetusectime()
		{
			this.usectimeSpecified = false;
		}

		[ProtoMember(42, IsRequired = false, Name = "military_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MilitaryRankData military_info
		{
			get
			{
				return this._military_info;
			}
			set
			{
				this._military_info = value;
			}
		}

		[ProtoMember(43, IsRequired = false, Name = "pkextradata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRankExtraData pkextradata
		{
			get
			{
				return this._pkextradata;
			}
			set
			{
				this._pkextradata = value;
			}
		}

		[ProtoMember(44, IsRequired = false, Name = "scdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCraftRankData scdata
		{
			get
			{
				return this._scdata;
			}
			set
			{
				this._scdata = value;
			}
		}

		[ProtoMember(45, IsRequired = false, Name = "survive", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SurviveRankData survive
		{
			get
			{
				return this._survive;
			}
			set
			{
				this._survive = value;
			}
		}

		[ProtoMember(46, IsRequired = false, Name = "skycity", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyCityRankData skycity
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

		[ProtoMember(47, IsRequired = false, Name = "riftRankData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiftRankData riftRankData
		{
			get
			{
				return this._riftRankData;
			}
			set
			{
				this._riftRankData = value;
			}
		}

		[ProtoMember(48, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _RoleId;

		private string _RoleName;

		private uint? _RoleLevel;

		private uint? _time;

		private float? _damage;

		private uint? _powerpoint;

		private uint? _flowercount;

		private uint? _Rank;

		private uint? _guildicon;

		private string _guildname;

		private uint? _pkpoint;

		private uint? _tshowvotecount;

		private uint? _intervaltimestamp;

		private uint? _profession;

		private readonly List<ulong> _RoleIds = new List<ulong>();

		private readonly List<string> _RoleNames = new List<string>();

		private uint? _towerHardLevel;

		private uint? _towerFloor;

		private uint? _towerThroughTime;

		private readonly List<MapIntItem> _receiveFlowers = new List<MapIntItem>();

		private uint? _guildBossIndex;

		private string _guildBossName;

		private string _guildBossDpsMax;

		private uint? _titleID;

		private readonly List<uint> _titleIDs = new List<uint>();

		private int? _commendNum;

		private uint? _sceneid;

		private uint? _bossavghppercent;

		private int? _groupid;

		private ulong? _petuid;

		private uint? _petid;

		private string _headpic;

		private StartUpType? _starttype;

		private bool? _is_vip;

		private bool? _is_svip;

		private uint? _usetime;

		private LeagueRankData _leagueinfo = null;

		private HeroRankData _heroinfo = null;

		private string _strRoleid;

		private uint? _starlevel;

		private uint? _usectime;

		private MilitaryRankData _military_info = null;

		private PkRankExtraData _pkextradata = null;

		private SkyCraftRankData _scdata = null;

		private SurviveRankData _survive = null;

		private SkyCityRankData _skycity = null;

		private RiftRankData _riftRankData = null;

		private PayConsume _pre = null;

		private IExtension extensionObject;
	}
}
