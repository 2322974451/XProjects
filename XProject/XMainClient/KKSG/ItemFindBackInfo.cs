using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackInfo")]
	[Serializable]
	public class ItemFindBackInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ItemFindBackType id
		{
			get
			{
				return this._id ?? ItemFindBackType.TOWER;
			}
			set
			{
				this._id = new ItemFindBackType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ItemFindBackType?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "subtype", DataFormat = DataFormat.TwosComplement)]
		public int subtype
		{
			get
			{
				return this._subtype ?? 0;
			}
			set
			{
				this._subtype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool subtypeSpecified
		{
			get
			{
				return this._subtype != null;
			}
			set
			{
				bool flag = value == (this._subtype == null);
				if (flag)
				{
					this._subtype = (value ? new int?(this.subtype) : null);
				}
			}
		}

		private bool ShouldSerializesubtype()
		{
			return this.subtypeSpecified;
		}

		private void Resetsubtype()
		{
			this.subtypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "useCount", DataFormat = DataFormat.TwosComplement)]
		public int useCount
		{
			get
			{
				return this._useCount ?? 0;
			}
			set
			{
				this._useCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool useCountSpecified
		{
			get
			{
				return this._useCount != null;
			}
			set
			{
				bool flag = value == (this._useCount == null);
				if (flag)
				{
					this._useCount = (value ? new int?(this.useCount) : null);
				}
			}
		}

		private bool ShouldSerializeuseCount()
		{
			return this.useCountSpecified;
		}

		private void ResetuseCount()
		{
			this.useCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "towerLevel", DataFormat = DataFormat.TwosComplement)]
		public int towerLevel
		{
			get
			{
				return this._towerLevel ?? 0;
			}
			set
			{
				this._towerLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool towerLevelSpecified
		{
			get
			{
				return this._towerLevel != null;
			}
			set
			{
				bool flag = value == (this._towerLevel == null);
				if (flag)
				{
					this._towerLevel = (value ? new int?(this.towerLevel) : null);
				}
			}
		}

		private bool ShouldSerializetowerLevel()
		{
			return this.towerLevelSpecified;
		}

		private void ResettowerLevel()
		{
			this.towerLevelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "dayTime", DataFormat = DataFormat.TwosComplement)]
		public int dayTime
		{
			get
			{
				return this._dayTime ?? 0;
			}
			set
			{
				this._dayTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayTimeSpecified
		{
			get
			{
				return this._dayTime != null;
			}
			set
			{
				bool flag = value == (this._dayTime == null);
				if (flag)
				{
					this._dayTime = (value ? new int?(this.dayTime) : null);
				}
			}
		}

		private bool ShouldSerializedayTime()
		{
			return this.dayTimeSpecified;
		}

		private void ResetdayTime()
		{
			this.dayTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "findBackCount", DataFormat = DataFormat.TwosComplement)]
		public int findBackCount
		{
			get
			{
				return this._findBackCount ?? 0;
			}
			set
			{
				this._findBackCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool findBackCountSpecified
		{
			get
			{
				return this._findBackCount != null;
			}
			set
			{
				bool flag = value == (this._findBackCount == null);
				if (flag)
				{
					this._findBackCount = (value ? new int?(this.findBackCount) : null);
				}
			}
		}

		private bool ShouldSerializefindBackCount()
		{
			return this.findBackCountSpecified;
		}

		private void ResetfindBackCount()
		{
			this.findBackCountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(8, Name = "onceBackExp", DataFormat = DataFormat.Default)]
		public List<MapIntItem> onceBackExp
		{
			get
			{
				return this._onceBackExp;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ItemFindBackType? _id;

		private int? _subtype;

		private int? _useCount;

		private int? _towerLevel;

		private int? _dayTime;

		private int? _findBackCount;

		private int? _level;

		private readonly List<MapIntItem> _onceBackExp = new List<MapIntItem>();

		private IExtension extensionObject;
	}
}
