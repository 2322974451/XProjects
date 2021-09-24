using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CheckinRecord")]
	[Serializable]
	public class CheckinRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "CheckinInfo", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinInfo
		{
			get
			{
				return this._CheckinInfo ?? 0U;
			}
			set
			{
				this._CheckinInfo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinInfoSpecified
		{
			get
			{
				return this._CheckinInfo != null;
			}
			set
			{
				bool flag = value == (this._CheckinInfo == null);
				if (flag)
				{
					this._CheckinInfo = (value ? new uint?(this.CheckinInfo) : null);
				}
			}
		}

		private bool ShouldSerializeCheckinInfo()
		{
			return this.CheckinInfoSpecified;
		}

		private void ResetCheckinInfo()
		{
			this.CheckinInfoSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "CheckinTime", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinTime
		{
			get
			{
				return this._CheckinTime ?? 0U;
			}
			set
			{
				this._CheckinTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinTimeSpecified
		{
			get
			{
				return this._CheckinTime != null;
			}
			set
			{
				bool flag = value == (this._CheckinTime == null);
				if (flag)
				{
					this._CheckinTime = (value ? new uint?(this.CheckinTime) : null);
				}
			}
		}

		private bool ShouldSerializeCheckinTime()
		{
			return this.CheckinTimeSpecified;
		}

		private void ResetCheckinTime()
		{
			this.CheckinTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "CheckinCount", DataFormat = DataFormat.TwosComplement)]
		public uint CheckinCount
		{
			get
			{
				return this._CheckinCount ?? 0U;
			}
			set
			{
				this._CheckinCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CheckinCountSpecified
		{
			get
			{
				return this._CheckinCount != null;
			}
			set
			{
				bool flag = value == (this._CheckinCount == null);
				if (flag)
				{
					this._CheckinCount = (value ? new uint?(this.CheckinCount) : null);
				}
			}
		}

		private bool ShouldSerializeCheckinCount()
		{
			return this.CheckinCountSpecified;
		}

		private void ResetCheckinCount()
		{
			this.CheckinCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _CheckinInfo;

		private uint? _CheckinTime;

		private uint? _CheckinCount;

		private IExtension extensionObject;
	}
}
