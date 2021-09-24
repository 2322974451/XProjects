using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CheckinRes")]
	[Serializable]
	public class CheckinRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "DayCheckInfo", DataFormat = DataFormat.TwosComplement)]
		public uint DayCheckInfo
		{
			get
			{
				return this._DayCheckInfo ?? 0U;
			}
			set
			{
				this._DayCheckInfo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DayCheckInfoSpecified
		{
			get
			{
				return this._DayCheckInfo != null;
			}
			set
			{
				bool flag = value == (this._DayCheckInfo == null);
				if (flag)
				{
					this._DayCheckInfo = (value ? new uint?(this.DayCheckInfo) : null);
				}
			}
		}

		private bool ShouldSerializeDayCheckInfo()
		{
			return this.DayCheckInfoSpecified;
		}

		private void ResetDayCheckInfo()
		{
			this.DayCheckInfoSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "DayCanCheck", DataFormat = DataFormat.TwosComplement)]
		public uint DayCanCheck
		{
			get
			{
				return this._DayCanCheck ?? 0U;
			}
			set
			{
				this._DayCanCheck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DayCanCheckSpecified
		{
			get
			{
				return this._DayCanCheck != null;
			}
			set
			{
				bool flag = value == (this._DayCanCheck == null);
				if (flag)
				{
					this._DayCanCheck = (value ? new uint?(this.DayCanCheck) : null);
				}
			}
		}

		private bool ShouldSerializeDayCanCheck()
		{
			return this.DayCanCheckSpecified;
		}

		private void ResetDayCanCheck()
		{
			this.DayCanCheckSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "DayMakeUp", DataFormat = DataFormat.TwosComplement)]
		public uint DayMakeUp
		{
			get
			{
				return this._DayMakeUp ?? 0U;
			}
			set
			{
				this._DayMakeUp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DayMakeUpSpecified
		{
			get
			{
				return this._DayMakeUp != null;
			}
			set
			{
				bool flag = value == (this._DayMakeUp == null);
				if (flag)
				{
					this._DayMakeUp = (value ? new uint?(this.DayMakeUp) : null);
				}
			}
		}

		private bool ShouldSerializeDayMakeUp()
		{
			return this.DayMakeUpSpecified;
		}

		private void ResetDayMakeUp()
		{
			this.DayMakeUpSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "Bonus", DataFormat = DataFormat.TwosComplement)]
		public uint Bonus
		{
			get
			{
				return this._Bonus ?? 0U;
			}
			set
			{
				this._Bonus = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BonusSpecified
		{
			get
			{
				return this._Bonus != null;
			}
			set
			{
				bool flag = value == (this._Bonus == null);
				if (flag)
				{
					this._Bonus = (value ? new uint?(this.Bonus) : null);
				}
			}
		}

		private bool ShouldSerializeBonus()
		{
			return this.BonusSpecified;
		}

		private void ResetBonus()
		{
			this.BonusSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "StartDay", DataFormat = DataFormat.TwosComplement)]
		public uint StartDay
		{
			get
			{
				return this._StartDay ?? 0U;
			}
			set
			{
				this._StartDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool StartDaySpecified
		{
			get
			{
				return this._StartDay != null;
			}
			set
			{
				bool flag = value == (this._StartDay == null);
				if (flag)
				{
					this._StartDay = (value ? new uint?(this.StartDay) : null);
				}
			}
		}

		private bool ShouldSerializeStartDay()
		{
			return this.StartDaySpecified;
		}

		private void ResetStartDay()
		{
			this.StartDaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private uint? _DayCheckInfo;

		private uint? _DayCanCheck;

		private uint? _DayMakeUp;

		private uint? _Bonus;

		private uint? _StartDay;

		private IExtension extensionObject;
	}
}
