using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBQueryItemReq")]
	[Serializable]
	public class IBQueryItemReq : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "subtype", DataFormat = DataFormat.TwosComplement)]
		public uint subtype
		{
			get
			{
				return this._subtype ?? 0U;
			}
			set
			{
				this._subtype = new uint?(value);
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
					this._subtype = (value ? new uint?(this.subtype) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _subtype;

		private IExtension extensionObject;
	}
}
