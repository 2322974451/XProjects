using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CheckinInfoNotify")]
	[Serializable]
	public class CheckinInfoNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "DayCheckInfo", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "DayCanCheck", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "DayMakeUp", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemId
		{
			get
			{
				return this._ItemId;
			}
		}

		[ProtoMember(5, Name = "ItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
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

		[ProtoMember(7, IsRequired = false, Name = "IsOddMonth", DataFormat = DataFormat.Default)]
		public bool IsOddMonth
		{
			get
			{
				return this._IsOddMonth ?? false;
			}
			set
			{
				this._IsOddMonth = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsOddMonthSpecified
		{
			get
			{
				return this._IsOddMonth != null;
			}
			set
			{
				bool flag = value == (this._IsOddMonth == null);
				if (flag)
				{
					this._IsOddMonth = (value ? new bool?(this.IsOddMonth) : null);
				}
			}
		}

		private bool ShouldSerializeIsOddMonth()
		{
			return this.IsOddMonthSpecified;
		}

		private void ResetIsOddMonth()
		{
			this.IsOddMonthSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _DayCheckInfo;

		private uint? _DayCanCheck;

		private uint? _DayMakeUp;

		private readonly List<uint> _ItemId = new List<uint>();

		private readonly List<uint> _ItemCount = new List<uint>();

		private uint? _StartDay;

		private bool? _IsOddMonth;

		private IExtension extensionObject;
	}
}
