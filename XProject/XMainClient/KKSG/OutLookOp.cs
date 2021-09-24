using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookOp")]
	[Serializable]
	public class OutLookOp : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "weapon", DataFormat = DataFormat.TwosComplement)]
		public OutLookType weapon
		{
			get
			{
				return this._weapon ?? OutLookType.OutLook_Fashion;
			}
			set
			{
				this._weapon = new OutLookType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weaponSpecified
		{
			get
			{
				return this._weapon != null;
			}
			set
			{
				bool flag = value == (this._weapon == null);
				if (flag)
				{
					this._weapon = (value ? new OutLookType?(this.weapon) : null);
				}
			}
		}

		private bool ShouldSerializeweapon()
		{
			return this.weaponSpecified;
		}

		private void Resetweapon()
		{
			this.weaponSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "clothes", DataFormat = DataFormat.TwosComplement)]
		public OutLookType clothes
		{
			get
			{
				return this._clothes ?? OutLookType.OutLook_Fashion;
			}
			set
			{
				this._clothes = new OutLookType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool clothesSpecified
		{
			get
			{
				return this._clothes != null;
			}
			set
			{
				bool flag = value == (this._clothes == null);
				if (flag)
				{
					this._clothes = (value ? new OutLookType?(this.clothes) : null);
				}
			}
		}

		private bool ShouldSerializeclothes()
		{
			return this.clothesSpecified;
		}

		private void Resetclothes()
		{
			this.clothesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private OutLookType? _weapon;

		private OutLookType? _clothes;

		private IExtension extensionObject;
	}
}
