using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayInfo")]
	[Serializable]
	public class PayInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "TotalPay", DataFormat = DataFormat.TwosComplement)]
		public ulong TotalPay
		{
			get
			{
				return this._TotalPay ?? 0UL;
			}
			set
			{
				this._TotalPay = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TotalPaySpecified
		{
			get
			{
				return this._TotalPay != null;
			}
			set
			{
				bool flag = value == (this._TotalPay == null);
				if (flag)
				{
					this._TotalPay = (value ? new ulong?(this.TotalPay) : null);
				}
			}
		}

		private bool ShouldSerializeTotalPay()
		{
			return this.TotalPaySpecified;
		}

		private void ResetTotalPay()
		{
			this.TotalPaySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "PayIDFlag", DataFormat = DataFormat.TwosComplement)]
		public uint PayIDFlag
		{
			get
			{
				return this._PayIDFlag ?? 0U;
			}
			set
			{
				this._PayIDFlag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool PayIDFlagSpecified
		{
			get
			{
				return this._PayIDFlag != null;
			}
			set
			{
				bool flag = value == (this._PayIDFlag == null);
				if (flag)
				{
					this._PayIDFlag = (value ? new uint?(this.PayIDFlag) : null);
				}
			}
		}

		private bool ShouldSerializePayIDFlag()
		{
			return this.PayIDFlagSpecified;
		}

		private void ResetPayIDFlag()
		{
			this.PayIDFlagSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "MonthCardLeftDay", DataFormat = DataFormat.TwosComplement)]
		public uint MonthCardLeftDay
		{
			get
			{
				return this._MonthCardLeftDay ?? 0U;
			}
			set
			{
				this._MonthCardLeftDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool MonthCardLeftDaySpecified
		{
			get
			{
				return this._MonthCardLeftDay != null;
			}
			set
			{
				bool flag = value == (this._MonthCardLeftDay == null);
				if (flag)
				{
					this._MonthCardLeftDay = (value ? new uint?(this.MonthCardLeftDay) : null);
				}
			}
		}

		private bool ShouldSerializeMonthCardLeftDay()
		{
			return this.MonthCardLeftDaySpecified;
		}

		private void ResetMonthCardLeftDay()
		{
			this.MonthCardLeftDaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "LastMonthCardTimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint LastMonthCardTimeStamp
		{
			get
			{
				return this._LastMonthCardTimeStamp ?? 0U;
			}
			set
			{
				this._LastMonthCardTimeStamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LastMonthCardTimeStampSpecified
		{
			get
			{
				return this._LastMonthCardTimeStamp != null;
			}
			set
			{
				bool flag = value == (this._LastMonthCardTimeStamp == null);
				if (flag)
				{
					this._LastMonthCardTimeStamp = (value ? new uint?(this.LastMonthCardTimeStamp) : null);
				}
			}
		}

		private bool ShouldSerializeLastMonthCardTimeStamp()
		{
			return this.LastMonthCardTimeStampSpecified;
		}

		private void ResetLastMonthCardTimeStamp()
		{
			this.LastMonthCardTimeStampSpecified = false;
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

		[ProtoMember(6, IsRequired = false, Name = "vippoint", DataFormat = DataFormat.TwosComplement)]
		public uint vippoint
		{
			get
			{
				return this._vippoint ?? 0U;
			}
			set
			{
				this._vippoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vippointSpecified
		{
			get
			{
				return this._vippoint != null;
			}
			set
			{
				bool flag = value == (this._vippoint == null);
				if (flag)
				{
					this._vippoint = (value ? new uint?(this.vippoint) : null);
				}
			}
		}

		private bool ShouldSerializevippoint()
		{
			return this.vippointSpecified;
		}

		private void Resetvippoint()
		{
			this.vippointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _TotalPay;

		private uint? _PayIDFlag;

		private uint? _MonthCardLeftDay;

		private uint? _LastMonthCardTimeStamp;

		private uint? _vipLevel;

		private uint? _vippoint;

		private IExtension extensionObject;
	}
}
