using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnemyDoodadInfo")]
	[Serializable]
	public class EnemyDoodadInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "waveid", DataFormat = DataFormat.TwosComplement)]
		public int waveid
		{
			get
			{
				return this._waveid ?? 0;
			}
			set
			{
				this._waveid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool waveidSpecified
		{
			get
			{
				return this._waveid != null;
			}
			set
			{
				bool flag = value == (this._waveid == null);
				if (flag)
				{
					this._waveid = (value ? new int?(this.waveid) : null);
				}
			}
		}

		private bool ShouldSerializewaveid()
		{
			return this.waveidSpecified;
		}

		private void Resetwaveid()
		{
			this.waveidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
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
					this._type = (value ? new int?(this.type) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "pos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 pos
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "dropperTemplateID", DataFormat = DataFormat.TwosComplement)]
		public uint dropperTemplateID
		{
			get
			{
				return this._dropperTemplateID ?? 0U;
			}
			set
			{
				this._dropperTemplateID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dropperTemplateIDSpecified
		{
			get
			{
				return this._dropperTemplateID != null;
			}
			set
			{
				bool flag = value == (this._dropperTemplateID == null);
				if (flag)
				{
					this._dropperTemplateID = (value ? new uint?(this.dropperTemplateID) : null);
				}
			}
		}

		private bool ShouldSerializedropperTemplateID()
		{
			return this.dropperTemplateIDSpecified;
		}

		private void ResetdropperTemplateID()
		{
			this.dropperTemplateIDSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _waveid;

		private int? _type;

		private uint? _id;

		private uint? _count;

		private Vec3 _pos = null;

		private uint? _index;

		private uint? _dropperTemplateID;

		private ulong? _roleid;

		private IExtension extensionObject;
	}
}
