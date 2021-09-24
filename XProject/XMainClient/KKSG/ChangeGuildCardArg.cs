using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeGuildCardArg")]
	[Serializable]
	public class ChangeGuildCardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "card", DataFormat = DataFormat.TwosComplement)]
		public uint card
		{
			get
			{
				return this._card ?? 0U;
			}
			set
			{
				this._card = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardSpecified
		{
			get
			{
				return this._card != null;
			}
			set
			{
				bool flag = value == (this._card == null);
				if (flag)
				{
					this._card = (value ? new uint?(this.card) : null);
				}
			}
		}

		private bool ShouldSerializecard()
		{
			return this.cardSpecified;
		}

		private void Resetcard()
		{
			this.cardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _card;

		private IExtension extensionObject;
	}
}
