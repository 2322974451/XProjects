using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkReqArg")]
	[Serializable]
	public class PkReqArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PkReqType type
		{
			get
			{
				return this._type ?? PkReqType.PKREQ_ADDPK;
			}
			set
			{
				this._type = new PkReqType?(value);
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
					this._type = (value ? new PkReqType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "nvntype", DataFormat = DataFormat.TwosComplement)]
		public PkNVNType nvntype
		{
			get
			{
				return this._nvntype ?? PkNVNType.PK_1v1;
			}
			set
			{
				this._nvntype = new PkNVNType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nvntypeSpecified
		{
			get
			{
				return this._nvntype != null;
			}
			set
			{
				bool flag = value == (this._nvntype == null);
				if (flag)
				{
					this._nvntype = (value ? new PkNVNType?(this.nvntype) : null);
				}
			}
		}

		private bool ShouldSerializenvntype()
		{
			return this.nvntypeSpecified;
		}

		private void Resetnvntype()
		{
			this.nvntypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkReqType? _type;

		private uint? _index;

		private PkNVNType? _nvntype;

		private IExtension extensionObject;
	}
}
