using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCardMatchReq")]
	[Serializable]
	public class GuildCardMatchReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public CardMatchOp op
		{
			get
			{
				return this._op ?? CardMatchOp.CardMatch_Begin;
			}
			set
			{
				this._op = new CardMatchOp?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new CardMatchOp?(this.op) : null);
				}
			}
		}

		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		private void Resetop()
		{
			this.opSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "card", DataFormat = DataFormat.TwosComplement)]
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

		private CardMatchOp? _op;

		private uint? _card;

		private IExtension extensionObject;
	}
}
