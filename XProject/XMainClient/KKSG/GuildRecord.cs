using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildRecord")]
	[Serializable]
	public class GuildRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "cardplaycount", DataFormat = DataFormat.TwosComplement)]
		public uint cardplaycount
		{
			get
			{
				return this._cardplaycount ?? 0U;
			}
			set
			{
				this._cardplaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardplaycountSpecified
		{
			get
			{
				return this._cardplaycount != null;
			}
			set
			{
				bool flag = value == (this._cardplaycount == null);
				if (flag)
				{
					this._cardplaycount = (value ? new uint?(this.cardplaycount) : null);
				}
			}
		}

		private bool ShouldSerializecardplaycount()
		{
			return this.cardplaycountSpecified;
		}

		private void Resetcardplaycount()
		{
			this.cardplaycountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "cardchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint cardchangecount
		{
			get
			{
				return this._cardchangecount ?? 0U;
			}
			set
			{
				this._cardchangecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardchangecountSpecified
		{
			get
			{
				return this._cardchangecount != null;
			}
			set
			{
				bool flag = value == (this._cardchangecount == null);
				if (flag)
				{
					this._cardchangecount = (value ? new uint?(this.cardchangecount) : null);
				}
			}
		}

		private bool ShouldSerializecardchangecount()
		{
			return this.cardchangecountSpecified;
		}

		private void Resetcardchangecount()
		{
			this.cardchangecountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "checkin", DataFormat = DataFormat.TwosComplement)]
		public uint checkin
		{
			get
			{
				return this._checkin ?? 0U;
			}
			set
			{
				this._checkin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool checkinSpecified
		{
			get
			{
				return this._checkin != null;
			}
			set
			{
				bool flag = value == (this._checkin == null);
				if (flag)
				{
					this._checkin = (value ? new uint?(this.checkin) : null);
				}
			}
		}

		private bool ShouldSerializecheckin()
		{
			return this.checkinSpecified;
		}

		private void Resetcheckin()
		{
			this.checkinSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
		public uint boxmask
		{
			get
			{
				return this._boxmask ?? 0U;
			}
			set
			{
				this._boxmask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool boxmaskSpecified
		{
			get
			{
				return this._boxmask != null;
			}
			set
			{
				bool flag = value == (this._boxmask == null);
				if (flag)
				{
					this._boxmask = (value ? new uint?(this.boxmask) : null);
				}
			}
		}

		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "cardbuychangecount", DataFormat = DataFormat.TwosComplement)]
		public uint cardbuychangecount
		{
			get
			{
				return this._cardbuychangecount ?? 0U;
			}
			set
			{
				this._cardbuychangecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardbuychangecountSpecified
		{
			get
			{
				return this._cardbuychangecount != null;
			}
			set
			{
				bool flag = value == (this._cardbuychangecount == null);
				if (flag)
				{
					this._cardbuychangecount = (value ? new uint?(this.cardbuychangecount) : null);
				}
			}
		}

		private bool ShouldSerializecardbuychangecount()
		{
			return this.cardbuychangecountSpecified;
		}

		private void Resetcardbuychangecount()
		{
			this.cardbuychangecountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "recvFatigue", DataFormat = DataFormat.TwosComplement)]
		public uint recvFatigue
		{
			get
			{
				return this._recvFatigue ?? 0U;
			}
			set
			{
				this._recvFatigue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool recvFatigueSpecified
		{
			get
			{
				return this._recvFatigue != null;
			}
			set
			{
				bool flag = value == (this._recvFatigue == null);
				if (flag)
				{
					this._recvFatigue = (value ? new uint?(this.recvFatigue) : null);
				}
			}
		}

		private bool ShouldSerializerecvFatigue()
		{
			return this.recvFatigueSpecified;
		}

		private void ResetrecvFatigue()
		{
			this.recvFatigueSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "askBonusTime", DataFormat = DataFormat.TwosComplement)]
		public uint askBonusTime
		{
			get
			{
				return this._askBonusTime ?? 0U;
			}
			set
			{
				this._askBonusTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool askBonusTimeSpecified
		{
			get
			{
				return this._askBonusTime != null;
			}
			set
			{
				bool flag = value == (this._askBonusTime == null);
				if (flag)
				{
					this._askBonusTime = (value ? new uint?(this.askBonusTime) : null);
				}
			}
		}

		private bool ShouldSerializeaskBonusTime()
		{
			return this.askBonusTimeSpecified;
		}

		private void ResetaskBonusTime()
		{
			this.askBonusTimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "getCheckInBonusNum", DataFormat = DataFormat.TwosComplement)]
		public uint getCheckInBonusNum
		{
			get
			{
				return this._getCheckInBonusNum ?? 0U;
			}
			set
			{
				this._getCheckInBonusNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getCheckInBonusNumSpecified
		{
			get
			{
				return this._getCheckInBonusNum != null;
			}
			set
			{
				bool flag = value == (this._getCheckInBonusNum == null);
				if (flag)
				{
					this._getCheckInBonusNum = (value ? new uint?(this.getCheckInBonusNum) : null);
				}
			}
		}

		private bool ShouldSerializegetCheckInBonusNum()
		{
			return this.getCheckInBonusNumSpecified;
		}

		private void ResetgetCheckInBonusNum()
		{
			this.getCheckInBonusNumSpecified = false;
		}

		[ProtoMember(10, Name = "darereward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> darereward
		{
			get
			{
				return this._darereward;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "ishintcard", DataFormat = DataFormat.Default)]
		public bool ishintcard
		{
			get
			{
				return this._ishintcard ?? false;
			}
			set
			{
				this._ishintcard = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishintcardSpecified
		{
			get
			{
				return this._ishintcard != null;
			}
			set
			{
				bool flag = value == (this._ishintcard == null);
				if (flag)
				{
					this._ishintcard = (value ? new bool?(this.ishintcard) : null);
				}
			}
		}

		private bool ShouldSerializeishintcard()
		{
			return this.ishintcardSpecified;
		}

		private void Resetishintcard()
		{
			this.ishintcardSpecified = false;
		}

		[ProtoMember(12, Name = "guildskills", DataFormat = DataFormat.Default)]
		public List<GuildSkill> guildskills
		{
			get
			{
				return this._guildskills;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "cardmatchid", DataFormat = DataFormat.TwosComplement)]
		public ulong cardmatchid
		{
			get
			{
				return this._cardmatchid ?? 0UL;
			}
			set
			{
				this._cardmatchid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardmatchidSpecified
		{
			get
			{
				return this._cardmatchid != null;
			}
			set
			{
				bool flag = value == (this._cardmatchid == null);
				if (flag)
				{
					this._cardmatchid = (value ? new ulong?(this.cardmatchid) : null);
				}
			}
		}

		private bool ShouldSerializecardmatchid()
		{
			return this.cardmatchidSpecified;
		}

		private void Resetcardmatchid()
		{
			this.cardmatchidSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "inheritTeaTime", DataFormat = DataFormat.TwosComplement)]
		public uint inheritTeaTime
		{
			get
			{
				return this._inheritTeaTime ?? 0U;
			}
			set
			{
				this._inheritTeaTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inheritTeaTimeSpecified
		{
			get
			{
				return this._inheritTeaTime != null;
			}
			set
			{
				bool flag = value == (this._inheritTeaTime == null);
				if (flag)
				{
					this._inheritTeaTime = (value ? new uint?(this.inheritTeaTime) : null);
				}
			}
		}

		private bool ShouldSerializeinheritTeaTime()
		{
			return this.inheritTeaTimeSpecified;
		}

		private void ResetinheritTeaTime()
		{
			this.inheritTeaTimeSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "inheritStuTime", DataFormat = DataFormat.TwosComplement)]
		public uint inheritStuTime
		{
			get
			{
				return this._inheritStuTime ?? 0U;
			}
			set
			{
				this._inheritStuTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inheritStuTimeSpecified
		{
			get
			{
				return this._inheritStuTime != null;
			}
			set
			{
				bool flag = value == (this._inheritStuTime == null);
				if (flag)
				{
					this._inheritStuTime = (value ? new uint?(this.inheritStuTime) : null);
				}
			}
		}

		private bool ShouldSerializeinheritStuTime()
		{
			return this.inheritStuTimeSpecified;
		}

		private void ResetinheritStuTime()
		{
			this.inheritStuTimeSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "bonusData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleGuildBonusData bonusData
		{
			get
			{
				return this._bonusData;
			}
			set
			{
				this._bonusData = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "guildinheritcdtime", DataFormat = DataFormat.TwosComplement)]
		public uint guildinheritcdtime
		{
			get
			{
				return this._guildinheritcdtime ?? 0U;
			}
			set
			{
				this._guildinheritcdtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildinheritcdtimeSpecified
		{
			get
			{
				return this._guildinheritcdtime != null;
			}
			set
			{
				bool flag = value == (this._guildinheritcdtime == null);
				if (flag)
				{
					this._guildinheritcdtime = (value ? new uint?(this.guildinheritcdtime) : null);
				}
			}
		}

		private bool ShouldSerializeguildinheritcdtime()
		{
			return this.guildinheritcdtimeSpecified;
		}

		private void Resetguildinheritcdtime()
		{
			this.guildinheritcdtimeSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "teacherinherittime", DataFormat = DataFormat.TwosComplement)]
		public uint teacherinherittime
		{
			get
			{
				return this._teacherinherittime ?? 0U;
			}
			set
			{
				this._teacherinherittime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teacherinherittimeSpecified
		{
			get
			{
				return this._teacherinherittime != null;
			}
			set
			{
				bool flag = value == (this._teacherinherittime == null);
				if (flag)
				{
					this._teacherinherittime = (value ? new uint?(this.teacherinherittime) : null);
				}
			}
		}

		private bool ShouldSerializeteacherinherittime()
		{
			return this.teacherinherittimeSpecified;
		}

		private void Resetteacherinherittime()
		{
			this.teacherinherittimeSpecified = false;
		}

		[ProtoMember(19, Name = "partyreward", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> partyreward
		{
			get
			{
				return this._partyreward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _cardplaycount;

		private uint? _cardchangecount;

		private uint? _updateday;

		private uint? _checkin;

		private uint? _boxmask;

		private uint? _cardbuychangecount;

		private uint? _recvFatigue;

		private uint? _askBonusTime;

		private uint? _getCheckInBonusNum;

		private readonly List<uint> _darereward = new List<uint>();

		private bool? _ishintcard;

		private readonly List<GuildSkill> _guildskills = new List<GuildSkill>();

		private ulong? _cardmatchid;

		private uint? _inheritTeaTime;

		private uint? _inheritStuTime;

		private RoleGuildBonusData _bonusData = null;

		private uint? _guildinheritcdtime;

		private uint? _teacherinherittime;

		private readonly List<MapKeyValue> _partyreward = new List<MapKeyValue>();

		private IExtension extensionObject;
	}
}
