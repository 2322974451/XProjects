using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealInfo")]
	[Serializable]
	public class LevelSealInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public uint endTime
		{
			get
			{
				return this._endTime ?? 0U;
			}
			set
			{
				this._endTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new uint?(this.endTime) : null);
				}
			}
		}

		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "unLockBossCount", DataFormat = DataFormat.TwosComplement)]
		public uint unLockBossCount
		{
			get
			{
				return this._unLockBossCount ?? 0U;
			}
			set
			{
				this._unLockBossCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unLockBossCountSpecified
		{
			get
			{
				return this._unLockBossCount != null;
			}
			set
			{
				bool flag = value == (this._unLockBossCount == null);
				if (flag)
				{
					this._unLockBossCount = (value ? new uint?(this.unLockBossCount) : null);
				}
			}
		}

		private bool ShouldSerializeunLockBossCount()
		{
			return this.unLockBossCountSpecified;
		}

		private void ResetunLockBossCount()
		{
			this.unLockBossCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public uint status
		{
			get
			{
				return this._status ?? 0U;
			}
			set
			{
				this._status = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new uint?(this.status) : null);
				}
			}
		}

		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "totalCollectCount", DataFormat = DataFormat.TwosComplement)]
		public uint totalCollectCount
		{
			get
			{
				return this._totalCollectCount ?? 0U;
			}
			set
			{
				this._totalCollectCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalCollectCountSpecified
		{
			get
			{
				return this._totalCollectCount != null;
			}
			set
			{
				bool flag = value == (this._totalCollectCount == null);
				if (flag)
				{
					this._totalCollectCount = (value ? new uint?(this.totalCollectCount) : null);
				}
			}
		}

		private bool ShouldSerializetotalCollectCount()
		{
			return this.totalCollectCountSpecified;
		}

		private void ResettotalCollectCount()
		{
			this.totalCollectCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "selfCollectCount", DataFormat = DataFormat.TwosComplement)]
		public uint selfCollectCount
		{
			get
			{
				return this._selfCollectCount ?? 0U;
			}
			set
			{
				this._selfCollectCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selfCollectCountSpecified
		{
			get
			{
				return this._selfCollectCount != null;
			}
			set
			{
				bool flag = value == (this._selfCollectCount == null);
				if (flag)
				{
					this._selfCollectCount = (value ? new uint?(this.selfCollectCount) : null);
				}
			}
		}

		private bool ShouldSerializeselfCollectCount()
		{
			return this.selfCollectCountSpecified;
		}

		private void ResetselfCollectCount()
		{
			this.selfCollectCountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "selfAwardCountIndex", DataFormat = DataFormat.TwosComplement)]
		public int selfAwardCountIndex
		{
			get
			{
				return this._selfAwardCountIndex ?? 0;
			}
			set
			{
				this._selfAwardCountIndex = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selfAwardCountIndexSpecified
		{
			get
			{
				return this._selfAwardCountIndex != null;
			}
			set
			{
				bool flag = value == (this._selfAwardCountIndex == null);
				if (flag)
				{
					this._selfAwardCountIndex = (value ? new int?(this.selfAwardCountIndex) : null);
				}
			}
		}

		private bool ShouldSerializeselfAwardCountIndex()
		{
			return this.selfAwardCountIndexSpecified;
		}

		private void ResetselfAwardCountIndex()
		{
			this.selfAwardCountIndexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _endTime;

		private uint? _unLockBossCount;

		private uint? _status;

		private uint? _totalCollectCount;

		private uint? _selfCollectCount;

		private int? _selfAwardCountIndex;

		private IExtension extensionObject;
	}
}
