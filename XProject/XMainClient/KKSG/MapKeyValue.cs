using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MapKeyValue")]
	[Serializable]
	public class MapKeyValue : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "key", DataFormat = DataFormat.TwosComplement)]
		public ulong key
		{
			get
			{
				return this._key ?? 0UL;
			}
			set
			{
				this._key = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool keySpecified
		{
			get
			{
				return this._key != null;
			}
			set
			{
				bool flag = value == (this._key == null);
				if (flag)
				{
					this._key = (value ? new ulong?(this.key) : null);
				}
			}
		}

		private bool ShouldSerializekey()
		{
			return this.keySpecified;
		}

		private void Resetkey()
		{
			this.keySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public ulong value
		{
			get
			{
				return this._value ?? 0UL;
			}
			set
			{
				this._value = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new ulong?(this.value) : null);
				}
			}
		}

		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _key;

		private ulong? _value;

		private IExtension extensionObject;
	}
}
