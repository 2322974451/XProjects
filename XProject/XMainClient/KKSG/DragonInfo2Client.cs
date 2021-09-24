using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonInfo2Client")]
	[Serializable]
	public class DragonInfo2Client : IExtensible
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

		[ProtoMember(4, IsRequired = false, Name = "refreshTimes", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "weakType", DataFormat = DataFormat.TwosComplement)]
		public DragonWeakType weakType
		{
			get
			{
				return this._weakType ?? DragonWeakType.DragonWeakType_Null;
			}
			set
			{
				this._weakType = new DragonWeakType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weakTypeSpecified
		{
			get
			{
				return this._weakType != null;
			}
			set
			{
				bool flag = value == (this._weakType == null);
				if (flag)
				{
					this._weakType = (value ? new DragonWeakType?(this.weakType) : null);
				}
			}
		}

		private bool ShouldSerializeweakType()
		{
			return this.weakTypeSpecified;
		}

		private void ResetweakType()
		{
			this.weakTypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _dragonType;

		private int? _hardLevel;

		private int? _curFloor;

		private int? _refreshTimes;

		private DragonWeakType? _weakType;

		private IExtension extensionObject;
	}
}
