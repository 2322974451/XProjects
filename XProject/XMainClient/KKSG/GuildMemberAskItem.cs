using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberAskItem")]
	[Serializable]
	public class GuildMemberAskItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
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
					this._id = (value ? new uint?(this.id) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "publishtime", DataFormat = DataFormat.TwosComplement)]
		public uint publishtime
		{
			get
			{
				return this._publishtime ?? 0U;
			}
			set
			{
				this._publishtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool publishtimeSpecified
		{
			get
			{
				return this._publishtime != null;
			}
			set
			{
				bool flag = value == (this._publishtime == null);
				if (flag)
				{
					this._publishtime = (value ? new uint?(this.publishtime) : null);
				}
			}
		}

		private bool ShouldSerializepublishtime()
		{
			return this.publishtimeSpecified;
		}

		private void Resetpublishtime()
		{
			this.publishtimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "needCount", DataFormat = DataFormat.TwosComplement)]
		public uint needCount
		{
			get
			{
				return this._needCount ?? 0U;
			}
			set
			{
				this._needCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needCountSpecified
		{
			get
			{
				return this._needCount != null;
			}
			set
			{
				bool flag = value == (this._needCount == null);
				if (flag)
				{
					this._needCount = (value ? new uint?(this.needCount) : null);
				}
			}
		}

		private bool ShouldSerializeneedCount()
		{
			return this.needCountSpecified;
		}

		private void ResetneedCount()
		{
			this.needCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "getCount", DataFormat = DataFormat.TwosComplement)]
		public uint getCount
		{
			get
			{
				return this._getCount ?? 0U;
			}
			set
			{
				this._getCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getCountSpecified
		{
			get
			{
				return this._getCount != null;
			}
			set
			{
				bool flag = value == (this._getCount == null);
				if (flag)
				{
					this._getCount = (value ? new uint?(this.getCount) : null);
				}
			}
		}

		private bool ShouldSerializegetCount()
		{
			return this.getCountSpecified;
		}

		private void ResetgetCount()
		{
			this.getCountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
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
					this._level = (value ? new uint?(this.level) : null);
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

		[ProtoMember(8, IsRequired = false, Name = "quality", DataFormat = DataFormat.TwosComplement)]
		public uint quality
		{
			get
			{
				return this._quality ?? 0U;
			}
			set
			{
				this._quality = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qualitySpecified
		{
			get
			{
				return this._quality != null;
			}
			set
			{
				bool flag = value == (this._quality == null);
				if (flag)
				{
					this._quality = (value ? new uint?(this.quality) : null);
				}
			}
		}

		private bool ShouldSerializequality()
		{
			return this.qualitySpecified;
		}

		private void Resetquality()
		{
			this.qualitySpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "tasktype", DataFormat = DataFormat.TwosComplement)]
		public PeriodTaskType tasktype
		{
			get
			{
				return this._tasktype ?? PeriodTaskType.PeriodTaskType_Daily;
			}
			set
			{
				this._tasktype = new PeriodTaskType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tasktypeSpecified
		{
			get
			{
				return this._tasktype != null;
			}
			set
			{
				bool flag = value == (this._tasktype == null);
				if (flag)
				{
					this._tasktype = (value ? new PeriodTaskType?(this.tasktype) : null);
				}
			}
		}

		private bool ShouldSerializetasktype()
		{
			return this.tasktypeSpecified;
		}

		private void Resettasktype()
		{
			this.tasktypeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "itemtype", DataFormat = DataFormat.TwosComplement)]
		public uint itemtype
		{
			get
			{
				return this._itemtype ?? 0U;
			}
			set
			{
				this._itemtype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemtypeSpecified
		{
			get
			{
				return this._itemtype != null;
			}
			set
			{
				bool flag = value == (this._itemtype == null);
				if (flag)
				{
					this._itemtype = (value ? new uint?(this.itemtype) : null);
				}
			}
		}

		private bool ShouldSerializeitemtype()
		{
			return this.itemtypeSpecified;
		}

		private void Resetitemtype()
		{
			this.itemtypeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "itemquality", DataFormat = DataFormat.TwosComplement)]
		public uint itemquality
		{
			get
			{
				return this._itemquality ?? 0U;
			}
			set
			{
				this._itemquality = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemqualitySpecified
		{
			get
			{
				return this._itemquality != null;
			}
			set
			{
				bool flag = value == (this._itemquality == null);
				if (flag)
				{
					this._itemquality = (value ? new uint?(this.itemquality) : null);
				}
			}
		}

		private bool ShouldSerializeitemquality()
		{
			return this.itemqualitySpecified;
		}

		private void Resetitemquality()
		{
			this.itemqualitySpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private ulong? _roleid;

		private uint? _publishtime;

		private uint? _itemid;

		private uint? _needCount;

		private uint? _getCount;

		private uint? _level;

		private uint? _quality;

		private uint? _taskid;

		private PeriodTaskType? _tasktype;

		private uint? _itemtype;

		private uint? _itemquality;

		private uint? _index;

		private IExtension extensionObject;
	}
}
