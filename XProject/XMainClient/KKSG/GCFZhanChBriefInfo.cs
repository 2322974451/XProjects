using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFZhanChBriefInfo")]
	[Serializable]
	public class GCFZhanChBriefInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "multipoint", DataFormat = DataFormat.TwosComplement)]
		public uint multipoint
		{
			get
			{
				return this._multipoint ?? 0U;
			}
			set
			{
				this._multipoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool multipointSpecified
		{
			get
			{
				return this._multipoint != null;
			}
			set
			{
				bool flag = value == (this._multipoint == null);
				if (flag)
				{
					this._multipoint = (value ? new uint?(this.multipoint) : null);
				}
			}
		}

		private bool ShouldSerializemultipoint()
		{
			return this.multipointSpecified;
		}

		private void Resetmultipoint()
		{
			this.multipointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "curusercount", DataFormat = DataFormat.TwosComplement)]
		public uint curusercount
		{
			get
			{
				return this._curusercount ?? 0U;
			}
			set
			{
				this._curusercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curusercountSpecified
		{
			get
			{
				return this._curusercount != null;
			}
			set
			{
				bool flag = value == (this._curusercount == null);
				if (flag)
				{
					this._curusercount = (value ? new uint?(this.curusercount) : null);
				}
			}
		}

		private bool ShouldSerializecurusercount()
		{
			return this.curusercountSpecified;
		}

		private void Resetcurusercount()
		{
			this.curusercountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "maxusercount", DataFormat = DataFormat.TwosComplement)]
		public uint maxusercount
		{
			get
			{
				return this._maxusercount ?? 0U;
			}
			set
			{
				this._maxusercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxusercountSpecified
		{
			get
			{
				return this._maxusercount != null;
			}
			set
			{
				bool flag = value == (this._maxusercount == null);
				if (flag)
				{
					this._maxusercount = (value ? new uint?(this.maxusercount) : null);
				}
			}
		}

		private bool ShouldSerializemaxusercount()
		{
			return this.maxusercountSpecified;
		}

		private void Resetmaxusercount()
		{
			this.maxusercountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _mapid;

		private uint? _multipoint;

		private uint? _curusercount;

		private uint? _maxusercount;

		private bool? _isopen;

		private IExtension extensionObject;
	}
}
