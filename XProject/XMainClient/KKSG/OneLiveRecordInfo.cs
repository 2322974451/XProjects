using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneLiveRecordInfo")]
	[Serializable]
	public class OneLiveRecordInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "liveID", DataFormat = DataFormat.TwosComplement)]
		public uint liveID
		{
			get
			{
				return this._liveID ?? 0U;
			}
			set
			{
				this._liveID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveIDSpecified
		{
			get
			{
				return this._liveID != null;
			}
			set
			{
				bool flag = value == (this._liveID == null);
				if (flag)
				{
					this._liveID = (value ? new uint?(this.liveID) : null);
				}
			}
		}

		private bool ShouldSerializeliveID()
		{
			return this.liveIDSpecified;
		}

		private void ResetliveID()
		{
			this.liveIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "DNExpID", DataFormat = DataFormat.TwosComplement)]
		public int DNExpID
		{
			get
			{
				return this._DNExpID ?? 0;
			}
			set
			{
				this._DNExpID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DNExpIDSpecified
		{
			get
			{
				return this._DNExpID != null;
			}
			set
			{
				bool flag = value == (this._DNExpID == null);
				if (flag)
				{
					this._DNExpID = (value ? new int?(this.DNExpID) : null);
				}
			}
		}

		private bool ShouldSerializeDNExpID()
		{
			return this.DNExpIDSpecified;
		}

		private void ResetDNExpID()
		{
			this.DNExpIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "watchNum", DataFormat = DataFormat.TwosComplement)]
		public int watchNum
		{
			get
			{
				return this._watchNum ?? 0;
			}
			set
			{
				this._watchNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool watchNumSpecified
		{
			get
			{
				return this._watchNum != null;
			}
			set
			{
				bool flag = value == (this._watchNum == null);
				if (flag)
				{
					this._watchNum = (value ? new int?(this.watchNum) : null);
				}
			}
		}

		private bool ShouldSerializewatchNum()
		{
			return this.watchNumSpecified;
		}

		private void ResetwatchNum()
		{
			this.watchNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "hasFriend", DataFormat = DataFormat.Default)]
		public bool hasFriend
		{
			get
			{
				return this._hasFriend ?? false;
			}
			set
			{
				this._hasFriend = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasFriendSpecified
		{
			get
			{
				return this._hasFriend != null;
			}
			set
			{
				bool flag = value == (this._hasFriend == null);
				if (flag)
				{
					this._hasFriend = (value ? new bool?(this.hasFriend) : null);
				}
			}
		}

		private bool ShouldSerializehasFriend()
		{
			return this.hasFriendSpecified;
		}

		private void ResethasFriend()
		{
			this.hasFriendSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "beginTime", DataFormat = DataFormat.TwosComplement)]
		public int beginTime
		{
			get
			{
				return this._beginTime ?? 0;
			}
			set
			{
				this._beginTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool beginTimeSpecified
		{
			get
			{
				return this._beginTime != null;
			}
			set
			{
				bool flag = value == (this._beginTime == null);
				if (flag)
				{
					this._beginTime = (value ? new int?(this.beginTime) : null);
				}
			}
		}

		private bool ShouldSerializebeginTime()
		{
			return this.beginTimeSpecified;
		}

		private void ResetbeginTime()
		{
			this.beginTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "tianTiLevel", DataFormat = DataFormat.TwosComplement)]
		public int tianTiLevel
		{
			get
			{
				return this._tianTiLevel ?? 0;
			}
			set
			{
				this._tianTiLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tianTiLevelSpecified
		{
			get
			{
				return this._tianTiLevel != null;
			}
			set
			{
				bool flag = value == (this._tianTiLevel == null);
				if (flag)
				{
					this._tianTiLevel = (value ? new int?(this.tianTiLevel) : null);
				}
			}
		}

		private bool ShouldSerializetianTiLevel()
		{
			return this.tianTiLevelSpecified;
		}

		private void ResettianTiLevel()
		{
			this.tianTiLevelSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "guildBattleLevel", DataFormat = DataFormat.TwosComplement)]
		public int guildBattleLevel
		{
			get
			{
				return this._guildBattleLevel ?? 0;
			}
			set
			{
				this._guildBattleLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildBattleLevelSpecified
		{
			get
			{
				return this._guildBattleLevel != null;
			}
			set
			{
				bool flag = value == (this._guildBattleLevel == null);
				if (flag)
				{
					this._guildBattleLevel = (value ? new int?(this.guildBattleLevel) : null);
				}
			}
		}

		private bool ShouldSerializeguildBattleLevel()
		{
			return this.guildBattleLevelSpecified;
		}

		private void ResetguildBattleLevel()
		{
			this.guildBattleLevelSpecified = false;
		}

		[ProtoMember(9, Name = "nameInfos", DataFormat = DataFormat.Default)]
		public List<LiveNameInfo> nameInfos
		{
			get
			{
				return this._nameInfos;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "liveType", DataFormat = DataFormat.TwosComplement)]
		public LiveType liveType
		{
			get
			{
				return this._liveType ?? LiveType.LIVE_RECOMMEND;
			}
			set
			{
				this._liveType = new LiveType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveTypeSpecified
		{
			get
			{
				return this._liveType != null;
			}
			set
			{
				bool flag = value == (this._liveType == null);
				if (flag)
				{
					this._liveType = (value ? new LiveType?(this.liveType) : null);
				}
			}
		}

		private bool ShouldSerializeliveType()
		{
			return this.liveTypeSpecified;
		}

		private void ResetliveType()
		{
			this.liveTypeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "hasGuild", DataFormat = DataFormat.Default)]
		public bool hasGuild
		{
			get
			{
				return this._hasGuild ?? false;
			}
			set
			{
				this._hasGuild = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasGuildSpecified
		{
			get
			{
				return this._hasGuild != null;
			}
			set
			{
				bool flag = value == (this._hasGuild == null);
				if (flag)
				{
					this._hasGuild = (value ? new bool?(this.hasGuild) : null);
				}
			}
		}

		private bool ShouldSerializehasGuild()
		{
			return this.hasGuildSpecified;
		}

		private void ResethasGuild()
		{
			this.hasGuildSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "canEnter", DataFormat = DataFormat.Default)]
		public bool canEnter
		{
			get
			{
				return this._canEnter ?? false;
			}
			set
			{
				this._canEnter = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canEnterSpecified
		{
			get
			{
				return this._canEnter != null;
			}
			set
			{
				bool flag = value == (this._canEnter == null);
				if (flag)
				{
					this._canEnter = (value ? new bool?(this.canEnter) : null);
				}
			}
		}

		private bool ShouldSerializecanEnter()
		{
			return this.canEnterSpecified;
		}

		private void ResetcanEnter()
		{
			this.canEnterSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "curWatchNum", DataFormat = DataFormat.TwosComplement)]
		public uint curWatchNum
		{
			get
			{
				return this._curWatchNum ?? 0U;
			}
			set
			{
				this._curWatchNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curWatchNumSpecified
		{
			get
			{
				return this._curWatchNum != null;
			}
			set
			{
				bool flag = value == (this._curWatchNum == null);
				if (flag)
				{
					this._curWatchNum = (value ? new uint?(this.curWatchNum) : null);
				}
			}
		}

		private bool ShouldSerializecurWatchNum()
		{
			return this.curWatchNumSpecified;
		}

		private void ResetcurWatchNum()
		{
			this.curWatchNumSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public uint mapID
		{
			get
			{
				return this._mapID ?? 0U;
			}
			set
			{
				this._mapID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new uint?(this.mapID) : null);
				}
			}
		}

		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "isCross", DataFormat = DataFormat.Default)]
		public bool isCross
		{
			get
			{
				return this._isCross ?? false;
			}
			set
			{
				this._isCross = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isCrossSpecified
		{
			get
			{
				return this._isCross != null;
			}
			set
			{
				bool flag = value == (this._isCross == null);
				if (flag)
				{
					this._isCross = (value ? new bool?(this.isCross) : null);
				}
			}
		}

		private bool ShouldSerializeisCross()
		{
			return this.isCrossSpecified;
		}

		private void ResetisCross()
		{
			this.isCrossSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _liveID;

		private int? _DNExpID;

		private int? _watchNum;

		private int? _commendNum;

		private bool? _hasFriend;

		private int? _beginTime;

		private int? _tianTiLevel;

		private int? _guildBattleLevel;

		private readonly List<LiveNameInfo> _nameInfos = new List<LiveNameInfo>();

		private LiveType? _liveType;

		private bool? _hasGuild;

		private bool? _canEnter;

		private uint? _sceneID;

		private uint? _curWatchNum;

		private uint? _mapID;

		private bool? _isCross;

		private IExtension extensionObject;
	}
}
