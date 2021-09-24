using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonRecord")]
	[Serializable]
	public class DragonRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dragonType", DataFormat = DataFormat.TwosComplement)]
		public int dragonType
		{
			get
			{
				return this._dragonType ?? 0;
			}
			set
			{
				this._dragonType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonTypeSpecified
		{
			get
			{
				return this._dragonType != null;
			}
			set
			{
				bool flag = value == (this._dragonType == null);
				if (flag)
				{
					this._dragonType = (value ? new int?(this.dragonType) : null);
				}
			}
		}

		private bool ShouldSerializedragonType()
		{
			return this.dragonTypeSpecified;
		}

		private void ResetdragonType()
		{
			this.dragonTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hardLevel", DataFormat = DataFormat.TwosComplement)]
		public int hardLevel
		{
			get
			{
				return this._hardLevel ?? 0;
			}
			set
			{
				this._hardLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hardLevelSpecified
		{
			get
			{
				return this._hardLevel != null;
			}
			set
			{
				bool flag = value == (this._hardLevel == null);
				if (flag)
				{
					this._hardLevel = (value ? new int?(this.hardLevel) : null);
				}
			}
		}

		private bool ShouldSerializehardLevel()
		{
			return this.hardLevelSpecified;
		}

		private void ResethardLevel()
		{
			this.hardLevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "curFloor", DataFormat = DataFormat.TwosComplement)]
		public int curFloor
		{
			get
			{
				return this._curFloor ?? 0;
			}
			set
			{
				this._curFloor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curFloorSpecified
		{
			get
			{
				return this._curFloor != null;
			}
			set
			{
				bool flag = value == (this._curFloor == null);
				if (flag)
				{
					this._curFloor = (value ? new int?(this.curFloor) : null);
				}
			}
		}

		private bool ShouldSerializecurFloor()
		{
			return this.curFloorSpecified;
		}

		private void ResetcurFloor()
		{
			this.curFloorSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "dragonDiamondBoxTimes", DataFormat = DataFormat.TwosComplement)]
		public int dragonDiamondBoxTimes
		{
			get
			{
				return this._dragonDiamondBoxTimes ?? 0;
			}
			set
			{
				this._dragonDiamondBoxTimes = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonDiamondBoxTimesSpecified
		{
			get
			{
				return this._dragonDiamondBoxTimes != null;
			}
			set
			{
				bool flag = value == (this._dragonDiamondBoxTimes == null);
				if (flag)
				{
					this._dragonDiamondBoxTimes = (value ? new int?(this.dragonDiamondBoxTimes) : null);
				}
			}
		}

		private bool ShouldSerializedragonDiamondBoxTimes()
		{
			return this.dragonDiamondBoxTimesSpecified;
		}

		private void ResetdragonDiamondBoxTimes()
		{
			this.dragonDiamondBoxTimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _dragonType;

		private int? _hardLevel;

		private int? _curFloor;

		private int? _updateTime;

		private int? _dragonDiamondBoxTimes;

		private IExtension extensionObject;
	}
}
