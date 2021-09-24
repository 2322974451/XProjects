using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatFriendRankInfo2Client")]
	[Serializable]
	public class PlatFriendRankInfo2Client : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "platfriendBaseInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriend platfriendBaseInfo
		{
			get
			{
				return this._platfriendBaseInfo;
			}
			set
			{
				this._platfriendBaseInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "hasGiveGift", DataFormat = DataFormat.Default)]
		public bool hasGiveGift
		{
			get
			{
				return this._hasGiveGift ?? false;
			}
			set
			{
				this._hasGiveGift = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasGiveGiftSpecified
		{
			get
			{
				return this._hasGiveGift != null;
			}
			set
			{
				bool flag = value == (this._hasGiveGift == null);
				if (flag)
				{
					this._hasGiveGift = (value ? new bool?(this.hasGiveGift) : null);
				}
			}
		}

		private bool ShouldSerializehasGiveGift()
		{
			return this.hasGiveGiftSpecified;
		}

		private void ResethasGiveGift()
		{
			this.hasGiveGiftSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "maxAbility", DataFormat = DataFormat.TwosComplement)]
		public uint maxAbility
		{
			get
			{
				return this._maxAbility ?? 0U;
			}
			set
			{
				this._maxAbility = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxAbilitySpecified
		{
			get
			{
				return this._maxAbility != null;
			}
			set
			{
				bool flag = value == (this._maxAbility == null);
				if (flag)
				{
					this._maxAbility = (value ? new uint?(this.maxAbility) : null);
				}
			}
		}

		private bool ShouldSerializemaxAbility()
		{
			return this.maxAbilitySpecified;
		}

		private void ResetmaxAbility()
		{
			this.maxAbilitySpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isOnline", DataFormat = DataFormat.Default)]
		public bool isOnline
		{
			get
			{
				return this._isOnline ?? false;
			}
			set
			{
				this._isOnline = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isOnlineSpecified
		{
			get
			{
				return this._isOnline != null;
			}
			set
			{
				bool flag = value == (this._isOnline == null);
				if (flag)
				{
					this._isOnline = (value ? new bool?(this.isOnline) : null);
				}
			}
		}

		private bool ShouldSerializeisOnline()
		{
			return this.isOnlineSpecified;
		}

		private void ResetisOnline()
		{
			this.isOnlineSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "startType", DataFormat = DataFormat.TwosComplement)]
		public int startType
		{
			get
			{
				return this._startType ?? 0;
			}
			set
			{
				this._startType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startTypeSpecified
		{
			get
			{
				return this._startType != null;
			}
			set
			{
				bool flag = value == (this._startType == null);
				if (flag)
				{
					this._startType = (value ? new int?(this.startType) : null);
				}
			}
		}

		private bool ShouldSerializestartType()
		{
			return this.startTypeSpecified;
		}

		private void ResetstartType()
		{
			this.startTypeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
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

		private PlatFriend _platfriendBaseInfo = null;

		private uint? _rank;

		private bool? _hasGiveGift;

		private uint? _maxAbility;

		private uint? _vipLevel;

		private uint? _level;

		private bool? _isOnline;

		private int? _startType;

		private int? _profession;

		private PayConsume _pre = null;

		private IExtension extensionObject;
	}
}
