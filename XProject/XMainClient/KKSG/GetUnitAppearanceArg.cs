using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetUnitAppearanceArg")]
	[Serializable]
	public class GetUnitAppearanceArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "mask", DataFormat = DataFormat.TwosComplement)]
		public int mask
		{
			get
			{
				return this._mask ?? 0;
			}
			set
			{
				this._mask = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maskSpecified
		{
			get
			{
				return this._mask != null;
			}
			set
			{
				bool flag = value == (this._mask == null);
				if (flag)
				{
					this._mask = (value ? new int?(this.mask) : null);
				}
			}
		}

		private bool ShouldSerializemask()
		{
			return this.maskSpecified;
		}

		private void Resetmask()
		{
			this.maskSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "petId", DataFormat = DataFormat.TwosComplement)]
		public ulong petId
		{
			get
			{
				return this._petId ?? 0UL;
			}
			set
			{
				this._petId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petIdSpecified
		{
			get
			{
				return this._petId != null;
			}
			set
			{
				bool flag = value == (this._petId == null);
				if (flag)
				{
					this._petId = (value ? new ulong?(this.petId) : null);
				}
			}
		}

		private bool ShouldSerializepetId()
		{
			return this.petIdSpecified;
		}

		private void ResetpetId()
		{
			this.petIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private int? _mask;

		private uint? _type;

		private ulong? _petId;

		private IExtension extensionObject;
	}
}
