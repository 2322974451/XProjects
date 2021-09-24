using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivateFashionArg")]
	[Serializable]
	public class ActivateFashionArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
		public uint suit_id
		{
			get
			{
				return this._suit_id ?? 0U;
			}
			set
			{
				this._suit_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool suit_idSpecified
		{
			get
			{
				return this._suit_id != null;
			}
			set
			{
				bool flag = value == (this._suit_id == null);
				if (flag)
				{
					this._suit_id = (value ? new uint?(this.suit_id) : null);
				}
			}
		}

		private bool ShouldSerializesuit_id()
		{
			return this.suit_idSpecified;
		}

		private void Resetsuit_id()
		{
			this.suit_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _suit_id;

		private IExtension extensionObject;
	}
}
