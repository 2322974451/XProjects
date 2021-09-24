using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DoorState")]
	[Serializable]
	public class DoorState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "isOn", DataFormat = DataFormat.Default)]
		public bool isOn
		{
			get
			{
				return this._isOn ?? false;
			}
			set
			{
				this._isOn = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isOnSpecified
		{
			get
			{
				return this._isOn != null;
			}
			set
			{
				bool flag = value == (this._isOn == null);
				if (flag)
				{
					this._isOn = (value ? new bool?(this.isOn) : null);
				}
			}
		}

		private bool ShouldSerializeisOn()
		{
			return this.isOnSpecified;
		}

		private void ResetisOn()
		{
			this.isOnSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private bool? _isOn;

		private IExtension extensionObject;
	}
}
