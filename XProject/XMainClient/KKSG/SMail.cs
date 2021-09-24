using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SMail")]
	[Serializable]
	public class SMail : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "isread", DataFormat = DataFormat.Default)]
		public bool isread
		{
			get
			{
				return this._isread ?? false;
			}
			set
			{
				this._isread = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isreadSpecified
		{
			get
			{
				return this._isread != null;
			}
			set
			{
				bool flag = value == (this._isread == null);
				if (flag)
				{
					this._isread = (value ? new bool?(this.isread) : null);
				}
			}
		}

		private bool ShouldSerializeisread()
		{
			return this.isreadSpecified;
		}

		private void Resetisread()
		{
			this.isreadSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isdelete", DataFormat = DataFormat.Default)]
		public bool isdelete
		{
			get
			{
				return this._isdelete ?? false;
			}
			set
			{
				this._isdelete = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isdeleteSpecified
		{
			get
			{
				return this._isdelete != null;
			}
			set
			{
				bool flag = value == (this._isdelete == null);
				if (flag)
				{
					this._isdelete = (value ? new bool?(this.isdelete) : null);
				}
			}
		}

		private bool ShouldSerializeisdelete()
		{
			return this.isdeleteSpecified;
		}

		private void Resetisdelete()
		{
			this.isdeleteSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "timeexpire", DataFormat = DataFormat.TwosComplement)]
		public uint timeexpire
		{
			get
			{
				return this._timeexpire ?? 0U;
			}
			set
			{
				this._timeexpire = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeexpireSpecified
		{
			get
			{
				return this._timeexpire != null;
			}
			set
			{
				bool flag = value == (this._timeexpire == null);
				if (flag)
				{
					this._timeexpire = (value ? new uint?(this.timeexpire) : null);
				}
			}
		}

		private bool ShouldSerializetimeexpire()
		{
			return this.timeexpireSpecified;
		}

		private void Resettimeexpire()
		{
			this.timeexpireSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "istemplate", DataFormat = DataFormat.Default)]
		public bool istemplate
		{
			get
			{
				return this._istemplate ?? false;
			}
			set
			{
				this._istemplate = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool istemplateSpecified
		{
			get
			{
				return this._istemplate != null;
			}
			set
			{
				bool flag = value == (this._istemplate == null);
				if (flag)
				{
					this._istemplate = (value ? new bool?(this.istemplate) : null);
				}
			}
		}

		private bool ShouldSerializeistemplate()
		{
			return this.istemplateSpecified;
		}

		private void Resetistemplate()
		{
			this.istemplateSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "srcid", DataFormat = DataFormat.TwosComplement)]
		public ulong srcid
		{
			get
			{
				return this._srcid ?? 0UL;
			}
			set
			{
				this._srcid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool srcidSpecified
		{
			get
			{
				return this._srcid != null;
			}
			set
			{
				bool flag = value == (this._srcid == null);
				if (flag)
				{
					this._srcid = (value ? new ulong?(this.srcid) : null);
				}
			}
		}

		private bool ShouldSerializesrcid()
		{
			return this.srcidSpecified;
		}

		private void Resetsrcid()
		{
			this.srcidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "srcname", DataFormat = DataFormat.Default)]
		public string srcname
		{
			get
			{
				return this._srcname ?? "";
			}
			set
			{
				this._srcname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool srcnameSpecified
		{
			get
			{
				return this._srcname != null;
			}
			set
			{
				bool flag = value == (this._srcname == null);
				if (flag)
				{
					this._srcname = (value ? this.srcname : null);
				}
			}
		}

		private bool ShouldSerializesrcname()
		{
			return this.srcnameSpecified;
		}

		private void Resetsrcname()
		{
			this.srcnameSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
		public string title
		{
			get
			{
				return this._title ?? "";
			}
			set
			{
				this._title = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? this.title : null);
				}
			}
		}

		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
		public string content
		{
			get
			{
				return this._content ?? "";
			}
			set
			{
				this._content = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contentSpecified
		{
			get
			{
				return this._content != null;
			}
			set
			{
				bool flag = value == (this._content == null);
				if (flag)
				{
					this._content = (value ? this.content : null);
				}
			}
		}

		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		[ProtoMember(13, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public int timeleft
		{
			get
			{
				return this._timeleft ?? 0;
			}
			set
			{
				this._timeleft = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new int?(this.timeleft) : null);
				}
			}
		}

		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		[ProtoMember(15, Name = "xitems", DataFormat = DataFormat.Default)]
		public List<Item> xitems
		{
			get
			{
				return this._xitems;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public int reason
		{
			get
			{
				return this._reason ?? 0;
			}
			set
			{
				this._reason = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new int?(this.reason) : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "subreason", DataFormat = DataFormat.TwosComplement)]
		public int subreason
		{
			get
			{
				return this._subreason ?? 0;
			}
			set
			{
				this._subreason = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool subreasonSpecified
		{
			get
			{
				return this._subreason != null;
			}
			set
			{
				bool flag = value == (this._subreason == null);
				if (flag)
				{
					this._subreason = (value ? new int?(this.subreason) : null);
				}
			}
		}

		private bool ShouldSerializesubreason()
		{
			return this.subreasonSpecified;
		}

		private void Resetsubreason()
		{
			this.subreasonSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "extparam", DataFormat = DataFormat.Default)]
		public string extparam
		{
			get
			{
				return this._extparam ?? "";
			}
			set
			{
				this._extparam = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extparamSpecified
		{
			get
			{
				return this._extparam != null;
			}
			set
			{
				bool flag = value == (this._extparam == null);
				if (flag)
				{
					this._extparam = (value ? this.extparam : null);
				}
			}
		}

		private bool ShouldSerializeextparam()
		{
			return this.extparamSpecified;
		}

		private void Resetextparam()
		{
			this.extparamSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "minlevel", DataFormat = DataFormat.TwosComplement)]
		public int minlevel
		{
			get
			{
				return this._minlevel ?? 0;
			}
			set
			{
				this._minlevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool minlevelSpecified
		{
			get
			{
				return this._minlevel != null;
			}
			set
			{
				bool flag = value == (this._minlevel == null);
				if (flag)
				{
					this._minlevel = (value ? new int?(this.minlevel) : null);
				}
			}
		}

		private bool ShouldSerializeminlevel()
		{
			return this.minlevelSpecified;
		}

		private void Resetminlevel()
		{
			this.minlevelSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "maxlevel", DataFormat = DataFormat.TwosComplement)]
		public int maxlevel
		{
			get
			{
				return this._maxlevel ?? 0;
			}
			set
			{
				this._maxlevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxlevelSpecified
		{
			get
			{
				return this._maxlevel != null;
			}
			set
			{
				bool flag = value == (this._maxlevel == null);
				if (flag)
				{
					this._maxlevel = (value ? new int?(this.maxlevel) : null);
				}
			}
		}

		private bool ShouldSerializemaxlevel()
		{
			return this.maxlevelSpecified;
		}

		private void Resetmaxlevel()
		{
			this.maxlevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _type;

		private bool? _isread;

		private bool? _isdelete;

		private uint? _state;

		private uint? _timestamp;

		private uint? _timeexpire;

		private bool? _istemplate;

		private ulong? _srcid;

		private string _srcname;

		private string _title;

		private string _content;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private int? _timeleft;

		private readonly List<Item> _xitems = new List<Item>();

		private int? _reason;

		private int? _subreason;

		private string _extparam;

		private int? _minlevel;

		private int? _maxlevel;

		private IExtension extensionObject;
	}
}
