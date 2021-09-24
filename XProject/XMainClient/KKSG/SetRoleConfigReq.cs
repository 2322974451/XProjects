using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SetRoleConfigReq")]
	[Serializable]
	public class SetRoleConfigReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.Default)]
		public string type
		{
			get
			{
				return this._type ?? "";
			}
			set
			{
				this._type = value;
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
					this._type = (value ? this.type : null);
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

		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.Default)]
		public string value
		{
			get
			{
				return this._value ?? "";
			}
			set
			{
				this._value = value;
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
					this._value = (value ? this.value : null);
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

		private string _type;

		private string _value;

		private IExtension extensionObject;
	}
}
