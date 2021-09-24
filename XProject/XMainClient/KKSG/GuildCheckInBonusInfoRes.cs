using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCheckInBonusInfoRes")]
	[Serializable]
	public class GuildCheckInBonusInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isCheckedIn", DataFormat = DataFormat.Default)]
		public bool isCheckedIn
		{
			get
			{
				return this._isCheckedIn ?? false;
			}
			set
			{
				this._isCheckedIn = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isCheckedInSpecified
		{
			get
			{
				return this._isCheckedIn != null;
			}
			set
			{
				bool flag = value == (this._isCheckedIn == null);
				if (flag)
				{
					this._isCheckedIn = (value ? new bool?(this.isCheckedIn) : null);
				}
			}
		}

		private bool ShouldSerializeisCheckedIn()
		{
			return this.isCheckedInSpecified;
		}

		private void ResetisCheckedIn()
		{
			this.isCheckedInSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "checkInNum", DataFormat = DataFormat.TwosComplement)]
		public int checkInNum
		{
			get
			{
				return this._checkInNum ?? 0;
			}
			set
			{
				this._checkInNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool checkInNumSpecified
		{
			get
			{
				return this._checkInNum != null;
			}
			set
			{
				bool flag = value == (this._checkInNum == null);
				if (flag)
				{
					this._checkInNum = (value ? new int?(this.checkInNum) : null);
				}
			}
		}

		private bool ShouldSerializecheckInNum()
		{
			return this.checkInNumSpecified;
		}

		private void ResetcheckInNum()
		{
			this.checkInNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "onlineNum", DataFormat = DataFormat.TwosComplement)]
		public int onlineNum
		{
			get
			{
				return this._onlineNum ?? 0;
			}
			set
			{
				this._onlineNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlineNumSpecified
		{
			get
			{
				return this._onlineNum != null;
			}
			set
			{
				bool flag = value == (this._onlineNum == null);
				if (flag)
				{
					this._onlineNum = (value ? new int?(this.onlineNum) : null);
				}
			}
		}

		private bool ShouldSerializeonlineNum()
		{
			return this.onlineNumSpecified;
		}

		private void ResetonlineNum()
		{
			this.onlineNumSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildMemberNum", DataFormat = DataFormat.TwosComplement)]
		public int guildMemberNum
		{
			get
			{
				return this._guildMemberNum ?? 0;
			}
			set
			{
				this._guildMemberNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildMemberNumSpecified
		{
			get
			{
				return this._guildMemberNum != null;
			}
			set
			{
				bool flag = value == (this._guildMemberNum == null);
				if (flag)
				{
					this._guildMemberNum = (value ? new int?(this.guildMemberNum) : null);
				}
			}
		}

		private bool ShouldSerializeguildMemberNum()
		{
			return this.guildMemberNumSpecified;
		}

		private void ResetguildMemberNum()
		{
			this.guildMemberNumSpecified = false;
		}

		[ProtoMember(6, Name = "checkInBonusInfo", DataFormat = DataFormat.Default)]
		public List<GuildBonusAppear> checkInBonusInfo
		{
			get
			{
				return this._checkInBonusInfo;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "leftAskBonusTime", DataFormat = DataFormat.TwosComplement)]
		public int leftAskBonusTime
		{
			get
			{
				return this._leftAskBonusTime ?? 0;
			}
			set
			{
				this._leftAskBonusTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftAskBonusTimeSpecified
		{
			get
			{
				return this._leftAskBonusTime != null;
			}
			set
			{
				bool flag = value == (this._leftAskBonusTime == null);
				if (flag)
				{
					this._leftAskBonusTime = (value ? new int?(this.leftAskBonusTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftAskBonusTime()
		{
			return this.leftAskBonusTimeSpecified;
		}

		private void ResetleftAskBonusTime()
		{
			this.leftAskBonusTimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "timeofday", DataFormat = DataFormat.TwosComplement)]
		public int timeofday
		{
			get
			{
				return this._timeofday ?? 0;
			}
			set
			{
				this._timeofday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeofdaySpecified
		{
			get
			{
				return this._timeofday != null;
			}
			set
			{
				bool flag = value == (this._timeofday == null);
				if (flag)
				{
					this._timeofday = (value ? new int?(this.timeofday) : null);
				}
			}
		}

		private bool ShouldSerializetimeofday()
		{
			return this.timeofdaySpecified;
		}

		private void Resettimeofday()
		{
			this.timeofdaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private bool? _isCheckedIn;

		private int? _checkInNum;

		private int? _onlineNum;

		private int? _guildMemberNum;

		private readonly List<GuildBonusAppear> _checkInBonusInfo = new List<GuildBonusAppear>();

		private int? _leftAskBonusTime;

		private int? _timeofday;

		private IExtension extensionObject;
	}
}
