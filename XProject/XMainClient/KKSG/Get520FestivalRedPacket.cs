using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Get520FestivalRedPacket")]
	[Serializable]
	public class Get520FestivalRedPacket : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		private void Resetnum()
		{
			this.numSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "headpic", DataFormat = DataFormat.Default)]
		public string headpic
		{
			get
			{
				return this._headpic ?? "";
			}
			set
			{
				this._headpic = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool headpicSpecified
		{
			get
			{
				return this._headpic != null;
			}
			set
			{
				bool flag = value == (this._headpic == null);
				if (flag)
				{
					this._headpic = (value ? this.headpic : null);
				}
			}
		}

		private bool ShouldSerializeheadpic()
		{
			return this.headpicSpecified;
		}

		private void Resetheadpic()
		{
			this.headpicSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _num;

		private string _name;

		private string _headpic;

		private IExtension extensionObject;
	}
}
