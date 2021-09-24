using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAileen")]
	[Serializable]
	public class PayAileen : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "remainedTime", DataFormat = DataFormat.TwosComplement)]
		public uint remainedTime
		{
			get
			{
				return this._remainedTime ?? 0U;
			}
			set
			{
				this._remainedTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remainedTimeSpecified
		{
			get
			{
				return this._remainedTime != null;
			}
			set
			{
				bool flag = value == (this._remainedTime == null);
				if (flag)
				{
					this._remainedTime = (value ? new uint?(this.remainedTime) : null);
				}
			}
		}

		private bool ShouldSerializeremainedTime()
		{
			return this.remainedTimeSpecified;
		}

		private void ResetremainedTime()
		{
			this.remainedTimeSpecified = false;
		}

		[ProtoMember(2, Name = "AileenInfo", DataFormat = DataFormat.Default)]
		public List<PayAileenInfo> AileenInfo
		{
			get
			{
				return this._AileenInfo;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "weekDays", DataFormat = DataFormat.TwosComplement)]
		public uint weekDays
		{
			get
			{
				return this._weekDays ?? 0U;
			}
			set
			{
				this._weekDays = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekDaysSpecified
		{
			get
			{
				return this._weekDays != null;
			}
			set
			{
				bool flag = value == (this._weekDays == null);
				if (flag)
				{
					this._weekDays = (value ? new uint?(this.weekDays) : null);
				}
			}
		}

		private bool ShouldSerializeweekDays()
		{
			return this.weekDaysSpecified;
		}

		private void ResetweekDays()
		{
			this.weekDaysSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _remainedTime;

		private readonly List<PayAileenInfo> _AileenInfo = new List<PayAileenInfo>();

		private uint? _weekDays;

		private IExtension extensionObject;
	}
}
