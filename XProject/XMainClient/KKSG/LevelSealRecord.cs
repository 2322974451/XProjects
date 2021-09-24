using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealRecord")]
	[Serializable]
	public class LevelSealRecord : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "selfCollectCount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "selfAwardCountIndex", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "LevelSealButtonStatus", DataFormat = DataFormat.TwosComplement)]
		public uint LevelSealButtonStatus
		{
			get
			{
				return this._LevelSealButtonStatus ?? 0U;
			}
			set
			{
				this._LevelSealButtonStatus = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LevelSealButtonStatusSpecified
		{
			get
			{
				return this._LevelSealButtonStatus != null;
			}
			set
			{
				bool flag = value == (this._LevelSealButtonStatus == null);
				if (flag)
				{
					this._LevelSealButtonStatus = (value ? new uint?(this.LevelSealButtonStatus) : null);
				}
			}
		}

		private bool ShouldSerializeLevelSealButtonStatus()
		{
			return this.LevelSealButtonStatusSpecified;
		}

		private void ResetLevelSealButtonStatus()
		{
			this.LevelSealButtonStatusSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastLevelSealStatus", DataFormat = DataFormat.Default)]
		public bool lastLevelSealStatus
		{
			get
			{
				return this._lastLevelSealStatus ?? false;
			}
			set
			{
				this._lastLevelSealStatus = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastLevelSealStatusSpecified
		{
			get
			{
				return this._lastLevelSealStatus != null;
			}
			set
			{
				bool flag = value == (this._lastLevelSealStatus == null);
				if (flag)
				{
					this._lastLevelSealStatus = (value ? new bool?(this.lastLevelSealStatus) : null);
				}
			}
		}

		private bool ShouldSerializelastLevelSealStatus()
		{
			return this.lastLevelSealStatusSpecified;
		}

		private void ResetlastLevelSealStatus()
		{
			this.lastLevelSealStatusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _selfCollectCount;

		private int? _selfAwardCountIndex;

		private uint? _LevelSealButtonStatus;

		private bool? _lastLevelSealStatus;

		private IExtension extensionObject;
	}
}
