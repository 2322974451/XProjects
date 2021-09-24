using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageResultInfo")]
	[Serializable]
	public class StageResultInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "stageType", DataFormat = DataFormat.TwosComplement)]
		public uint stageType
		{
			get
			{
				return this._stageType ?? 0U;
			}
			set
			{
				this._stageType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageTypeSpecified
		{
			get
			{
				return this._stageType != null;
			}
			set
			{
				bool flag = value == (this._stageType == null);
				if (flag)
				{
					this._stageType = (value ? new uint?(this.stageType) : null);
				}
			}
		}

		private bool ShouldSerializestageType()
		{
			return this.stageTypeSpecified;
		}

		private void ResetstageType()
		{
			this.stageTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
		public uint stageID
		{
			get
			{
				return this._stageID ?? 0U;
			}
			set
			{
				this._stageID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageIDSpecified
		{
			get
			{
				return this._stageID != null;
			}
			set
			{
				bool flag = value == (this._stageID == null);
				if (flag)
				{
					this._stageID = (value ? new uint?(this.stageID) : null);
				}
			}
		}

		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isStageFailed", DataFormat = DataFormat.Default)]
		public bool isStageFailed
		{
			get
			{
				return this._isStageFailed ?? false;
			}
			set
			{
				this._isStageFailed = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isStageFailedSpecified
		{
			get
			{
				return this._isStageFailed != null;
			}
			set
			{
				bool flag = value == (this._isStageFailed == null);
				if (flag)
				{
					this._isStageFailed = (value ? new bool?(this.isStageFailed) : null);
				}
			}
		}

		private bool ShouldSerializeisStageFailed()
		{
			return this.isStageFailedSpecified;
		}

		private void ResetisStageFailed()
		{
			this.isStageFailedSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public uint timespan
		{
			get
			{
				return this._timespan ?? 0U;
			}
			set
			{
				this._timespan = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new uint?(this.timespan) : null);
				}
			}
		}

		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "abyssid", DataFormat = DataFormat.TwosComplement)]
		public uint abyssid
		{
			get
			{
				return this._abyssid ?? 0U;
			}
			set
			{
				this._abyssid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abyssidSpecified
		{
			get
			{
				return this._abyssid != null;
			}
			set
			{
				bool flag = value == (this._abyssid == null);
				if (flag)
				{
					this._abyssid = (value ? new uint?(this.abyssid) : null);
				}
			}
		}

		private bool ShouldSerializeabyssid()
		{
			return this.abyssidSpecified;
		}

		private void Resetabyssid()
		{
			this.abyssidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "mobabattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleResult mobabattle
		{
			get
			{
				return this._mobabattle;
			}
			set
			{
				this._mobabattle = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "weekend4v4tmresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeekEnd4v4TeamResult weekend4v4tmresult
		{
			get
			{
				return this._weekend4v4tmresult;
			}
			set
			{
				this._weekend4v4tmresult = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "end", DataFormat = DataFormat.Default)]
		public bool end
		{
			get
			{
				return this._end ?? false;
			}
			set
			{
				this._end = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endSpecified
		{
			get
			{
				return this._end != null;
			}
			set
			{
				bool flag = value == (this._end == null);
				if (flag)
				{
					this._end = (value ? new bool?(this.end) : null);
				}
			}
		}

		private bool ShouldSerializeend()
		{
			return this.endSpecified;
		}

		private void Resetend()
		{
			this.endSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _stageType;

		private uint? _stageID;

		private bool? _isStageFailed;

		private uint? _timespan;

		private uint? _abyssid;

		private MobaBattleResult _mobabattle = null;

		private WeekEnd4v4TeamResult _weekend4v4tmresult = null;

		private bool? _end;

		private IExtension extensionObject;
	}
}
