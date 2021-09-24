using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatNotice")]
	[Serializable]
	public class PlatNotice : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "noticeid", DataFormat = DataFormat.TwosComplement)]
		public uint noticeid
		{
			get
			{
				return this._noticeid ?? 0U;
			}
			set
			{
				this._noticeid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool noticeidSpecified
		{
			get
			{
				return this._noticeid != null;
			}
			set
			{
				bool flag = value == (this._noticeid == null);
				if (flag)
				{
					this._noticeid = (value ? new uint?(this.noticeid) : null);
				}
			}
		}

		private bool ShouldSerializenoticeid()
		{
			return this.noticeidSpecified;
		}

		private void Resetnoticeid()
		{
			this.noticeidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
		public bool isopen
		{
			get
			{
				return this._isopen ?? false;
			}
			set
			{
				this._isopen = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isopenSpecified
		{
			get
			{
				return this._isopen != null;
			}
			set
			{
				bool flag = value == (this._isopen == null);
				if (flag)
				{
					this._isopen = (value ? new bool?(this.isopen) : null);
				}
			}
		}

		private bool ShouldSerializeisopen()
		{
			return this.isopenSpecified;
		}

		private void Resetisopen()
		{
			this.isopenSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "areaid", DataFormat = DataFormat.TwosComplement)]
		public uint areaid
		{
			get
			{
				return this._areaid ?? 0U;
			}
			set
			{
				this._areaid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool areaidSpecified
		{
			get
			{
				return this._areaid != null;
			}
			set
			{
				bool flag = value == (this._areaid == null);
				if (flag)
				{
					this._areaid = (value ? new uint?(this.areaid) : null);
				}
			}
		}

		private bool ShouldSerializeareaid()
		{
			return this.areaidSpecified;
		}

		private void Resetareaid()
		{
			this.areaidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "platid", DataFormat = DataFormat.TwosComplement)]
		public uint platid
		{
			get
			{
				return this._platid ?? 0U;
			}
			set
			{
				this._platid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool platidSpecified
		{
			get
			{
				return this._platid != null;
			}
			set
			{
				bool flag = value == (this._platid == null);
				if (flag)
				{
					this._platid = (value ? new uint?(this.platid) : null);
				}
			}
		}

		private bool ShouldSerializeplatid()
		{
			return this.platidSpecified;
		}

		private void Resetplatid()
		{
			this.platidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
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

		[ProtoMember(7, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "title", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _noticeid;

		private bool? _isopen;

		private uint? _areaid;

		private uint? _platid;

		private string _content;

		private uint? _updatetime;

		private bool? _isnew;

		private string _title;

		private IExtension extensionObject;
	}
}
