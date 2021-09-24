using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatParamRole")]
	[Serializable]
	public class ChatParamRole : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong uniqueid
		{
			get
			{
				return this._uniqueid ?? 0UL;
			}
			set
			{
				this._uniqueid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uniqueidSpecified
		{
			get
			{
				return this._uniqueid != null;
			}
			set
			{
				bool flag = value == (this._uniqueid == null);
				if (flag)
				{
					this._uniqueid = (value ? new ulong?(this.uniqueid) : null);
				}
			}
		}

		private bool ShouldSerializeuniqueid()
		{
			return this.uniqueidSpecified;
		}

		private void Resetuniqueid()
		{
			this.uniqueidSpecified = false;
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

		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uniqueid;

		private string _name;

		private uint? _profession;

		private IExtension extensionObject;
	}
}
