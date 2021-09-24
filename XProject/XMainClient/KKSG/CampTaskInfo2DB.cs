using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampTaskInfo2DB")]
	[Serializable]
	public class CampTaskInfo2DB : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "resetTime", DataFormat = DataFormat.TwosComplement)]
		public int resetTime
		{
			get
			{
				return this._resetTime ?? 0;
			}
			set
			{
				this._resetTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resetTimeSpecified
		{
			get
			{
				return this._resetTime != null;
			}
			set
			{
				bool flag = value == (this._resetTime == null);
				if (flag)
				{
					this._resetTime = (value ? new int?(this.resetTime) : null);
				}
			}
		}

		private bool ShouldSerializeresetTime()
		{
			return this.resetTimeSpecified;
		}

		private void ResetresetTime()
		{
			this.resetTimeSpecified = false;
		}

		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<CampTaskInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "refreshTimes", DataFormat = DataFormat.TwosComplement)]
		public int refreshTimes
		{
			get
			{
				return this._refreshTimes ?? 0;
			}
			set
			{
				this._refreshTimes = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshTimesSpecified
		{
			get
			{
				return this._refreshTimes != null;
			}
			set
			{
				bool flag = value == (this._refreshTimes == null);
				if (flag)
				{
					this._refreshTimes = (value ? new int?(this.refreshTimes) : null);
				}
			}
		}

		private bool ShouldSerializerefreshTimes()
		{
			return this.refreshTimesSpecified;
		}

		private void ResetrefreshTimes()
		{
			this.refreshTimesSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rewardTimes", DataFormat = DataFormat.TwosComplement)]
		public int rewardTimes
		{
			get
			{
				return this._rewardTimes ?? 0;
			}
			set
			{
				this._rewardTimes = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardTimesSpecified
		{
			get
			{
				return this._rewardTimes != null;
			}
			set
			{
				bool flag = value == (this._rewardTimes == null);
				if (flag)
				{
					this._rewardTimes = (value ? new int?(this.rewardTimes) : null);
				}
			}
		}

		private bool ShouldSerializerewardTimes()
		{
			return this.rewardTimesSpecified;
		}

		private void ResetrewardTimes()
		{
			this.rewardTimesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "rewardTime", DataFormat = DataFormat.TwosComplement)]
		public int rewardTime
		{
			get
			{
				return this._rewardTime ?? 0;
			}
			set
			{
				this._rewardTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardTimeSpecified
		{
			get
			{
				return this._rewardTime != null;
			}
			set
			{
				bool flag = value == (this._rewardTime == null);
				if (flag)
				{
					this._rewardTime = (value ? new int?(this.rewardTime) : null);
				}
			}
		}

		private bool ShouldSerializerewardTime()
		{
			return this.rewardTimeSpecified;
		}

		private void ResetrewardTime()
		{
			this.rewardTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _resetTime;

		private readonly List<CampTaskInfo> _infos = new List<CampTaskInfo>();

		private int? _refreshTimes;

		private int? _rewardTimes;

		private int? _rewardTime;

		private IExtension extensionObject;
	}
}
