using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivityRecord")]
	[Serializable]
	public class ActivityRecord : IExtensible
	{

		[ProtoMember(1, Name = "ActivityId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ActivityId
		{
			get
			{
				return this._ActivityId;
			}
		}

		[ProtoMember(2, Name = "FinishCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> FinishCount
		{
			get
			{
				return this._FinishCount;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ActivityAllValue", DataFormat = DataFormat.TwosComplement)]
		public uint ActivityAllValue
		{
			get
			{
				return this._ActivityAllValue ?? 0U;
			}
			set
			{
				this._ActivityAllValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ActivityAllValueSpecified
		{
			get
			{
				return this._ActivityAllValue != null;
			}
			set
			{
				bool flag = value == (this._ActivityAllValue == null);
				if (flag)
				{
					this._ActivityAllValue = (value ? new uint?(this.ActivityAllValue) : null);
				}
			}
		}

		private bool ShouldSerializeActivityAllValue()
		{
			return this.ActivityAllValueSpecified;
		}

		private void ResetActivityAllValue()
		{
			this.ActivityAllValueSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "DoubleActivityId", DataFormat = DataFormat.TwosComplement)]
		public uint DoubleActivityId
		{
			get
			{
				return this._DoubleActivityId ?? 0U;
			}
			set
			{
				this._DoubleActivityId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DoubleActivityIdSpecified
		{
			get
			{
				return this._DoubleActivityId != null;
			}
			set
			{
				bool flag = value == (this._DoubleActivityId == null);
				if (flag)
				{
					this._DoubleActivityId = (value ? new uint?(this.DoubleActivityId) : null);
				}
			}
		}

		private bool ShouldSerializeDoubleActivityId()
		{
			return this.DoubleActivityIdSpecified;
		}

		private void ResetDoubleActivityId()
		{
			this.DoubleActivityIdSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "ChestGetInfo", DataFormat = DataFormat.TwosComplement)]
		public uint ChestGetInfo
		{
			get
			{
				return this._ChestGetInfo ?? 0U;
			}
			set
			{
				this._ChestGetInfo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ChestGetInfoSpecified
		{
			get
			{
				return this._ChestGetInfo != null;
			}
			set
			{
				bool flag = value == (this._ChestGetInfo == null);
				if (flag)
				{
					this._ChestGetInfo = (value ? new uint?(this.ChestGetInfo) : null);
				}
			}
		}

		private bool ShouldSerializeChestGetInfo()
		{
			return this.ChestGetInfoSpecified;
		}

		private void ResetChestGetInfo()
		{
			this.ChestGetInfoSpecified = false;
		}

		[ProtoMember(6, Name = "NeedFinishCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> NeedFinishCount
		{
			get
			{
				return this._NeedFinishCount;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "activityWeekValue", DataFormat = DataFormat.TwosComplement)]
		public uint activityWeekValue
		{
			get
			{
				return this._activityWeekValue ?? 0U;
			}
			set
			{
				this._activityWeekValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityWeekValueSpecified
		{
			get
			{
				return this._activityWeekValue != null;
			}
			set
			{
				bool flag = value == (this._activityWeekValue == null);
				if (flag)
				{
					this._activityWeekValue = (value ? new uint?(this.activityWeekValue) : null);
				}
			}
		}

		private bool ShouldSerializeactivityWeekValue()
		{
			return this.activityWeekValueSpecified;
		}

		private void ResetactivityWeekValue()
		{
			this.activityWeekValueSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "LastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public ulong LastUpdateTime
		{
			get
			{
				return this._LastUpdateTime ?? 0UL;
			}
			set
			{
				this._LastUpdateTime = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LastUpdateTimeSpecified
		{
			get
			{
				return this._LastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._LastUpdateTime == null);
				if (flag)
				{
					this._LastUpdateTime = (value ? new ulong?(this.LastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializeLastUpdateTime()
		{
			return this.LastUpdateTimeSpecified;
		}

		private void ResetLastUpdateTime()
		{
			this.LastUpdateTimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "guildladdertime", DataFormat = DataFormat.TwosComplement)]
		public uint guildladdertime
		{
			get
			{
				return this._guildladdertime ?? 0U;
			}
			set
			{
				this._guildladdertime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildladdertimeSpecified
		{
			get
			{
				return this._guildladdertime != null;
			}
			set
			{
				bool flag = value == (this._guildladdertime == null);
				if (flag)
				{
					this._guildladdertime = (value ? new uint?(this.guildladdertime) : null);
				}
			}
		}

		private bool ShouldSerializeguildladdertime()
		{
			return this.guildladdertimeSpecified;
		}

		private void Resetguildladdertime()
		{
			this.guildladdertimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _ActivityId = new List<uint>();

		private readonly List<uint> _FinishCount = new List<uint>();

		private uint? _ActivityAllValue;

		private uint? _DoubleActivityId;

		private uint? _ChestGetInfo;

		private readonly List<uint> _NeedFinishCount = new List<uint>();

		private uint? _activityWeekValue;

		private ulong? _LastUpdateTime;

		private uint? _guildladdertime;

		private IExtension extensionObject;
	}
}
