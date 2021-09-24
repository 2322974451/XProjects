using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AddFriendArg")]
	[Serializable]
	public class AddFriendArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "friendroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong friendroleid
		{
			get
			{
				return this._friendroleid ?? 0UL;
			}
			set
			{
				this._friendroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool friendroleidSpecified
		{
			get
			{
				return this._friendroleid != null;
			}
			set
			{
				bool flag = value == (this._friendroleid == null);
				if (flag)
				{
					this._friendroleid = (value ? new ulong?(this.friendroleid) : null);
				}
			}
		}

		private bool ShouldSerializefriendroleid()
		{
			return this.friendroleidSpecified;
		}

		private void Resetfriendroleid()
		{
			this.friendroleidSpecified = false;
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

		private ulong? _friendroleid;

		private string _name;

		private IExtension extensionObject;
	}
}
