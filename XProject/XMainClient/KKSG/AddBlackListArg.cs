using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AddBlackListArg")]
	[Serializable]
	public class AddBlackListArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong otherroleid
		{
			get
			{
				return this._otherroleid ?? 0UL;
			}
			set
			{
				this._otherroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool otherroleidSpecified
		{
			get
			{
				return this._otherroleid != null;
			}
			set
			{
				bool flag = value == (this._otherroleid == null);
				if (flag)
				{
					this._otherroleid = (value ? new ulong?(this.otherroleid) : null);
				}
			}
		}

		private bool ShouldSerializeotherroleid()
		{
			return this.otherroleidSpecified;
		}

		private void Resetotherroleid()
		{
			this.otherroleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _otherroleid;

		private string _name;

		private IExtension extensionObject;
	}
}
