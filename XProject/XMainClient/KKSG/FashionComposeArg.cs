using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionComposeArg")]
	[Serializable]
	public class FashionComposeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "fashion_id", DataFormat = DataFormat.TwosComplement)]
		public uint fashion_id
		{
			get
			{
				return this._fashion_id ?? 0U;
			}
			set
			{
				this._fashion_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fashion_idSpecified
		{
			get
			{
				return this._fashion_id != null;
			}
			set
			{
				bool flag = value == (this._fashion_id == null);
				if (flag)
				{
					this._fashion_id = (value ? new uint?(this.fashion_id) : null);
				}
			}
		}

		private bool ShouldSerializefashion_id()
		{
			return this.fashion_idSpecified;
		}

		private void Resetfashion_id()
		{
			this.fashion_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid1", DataFormat = DataFormat.Default)]
		public string uid1
		{
			get
			{
				return this._uid1 ?? "";
			}
			set
			{
				this._uid1 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uid1Specified
		{
			get
			{
				return this._uid1 != null;
			}
			set
			{
				bool flag = value == (this._uid1 == null);
				if (flag)
				{
					this._uid1 = (value ? this.uid1 : null);
				}
			}
		}

		private bool ShouldSerializeuid1()
		{
			return this.uid1Specified;
		}

		private void Resetuid1()
		{
			this.uid1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "uid2", DataFormat = DataFormat.Default)]
		public string uid2
		{
			get
			{
				return this._uid2 ?? "";
			}
			set
			{
				this._uid2 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uid2Specified
		{
			get
			{
				return this._uid2 != null;
			}
			set
			{
				bool flag = value == (this._uid2 == null);
				if (flag)
				{
					this._uid2 = (value ? this.uid2 : null);
				}
			}
		}

		private bool ShouldSerializeuid2()
		{
			return this.uid2Specified;
		}

		private void Resetuid2()
		{
			this.uid2Specified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _fashion_id;

		private string _uid1;

		private string _uid2;

		private IExtension extensionObject;
	}
}
