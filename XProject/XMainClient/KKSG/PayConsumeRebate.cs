using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayConsumeRebate")]
	[Serializable]
	public class PayConsumeRebate : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "consumenum", DataFormat = DataFormat.TwosComplement)]
		public uint consumenum
		{
			get
			{
				return this._consumenum ?? 0U;
			}
			set
			{
				this._consumenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consumenumSpecified
		{
			get
			{
				return this._consumenum != null;
			}
			set
			{
				bool flag = value == (this._consumenum == null);
				if (flag)
				{
					this._consumenum = (value ? new uint?(this.consumenum) : null);
				}
			}
		}

		private bool ShouldSerializeconsumenum()
		{
			return this.consumenumSpecified;
		}

		private void Resetconsumenum()
		{
			this.consumenumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lastconsumetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastconsumetime
		{
			get
			{
				return this._lastconsumetime ?? 0U;
			}
			set
			{
				this._lastconsumetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastconsumetimeSpecified
		{
			get
			{
				return this._lastconsumetime != null;
			}
			set
			{
				bool flag = value == (this._lastconsumetime == null);
				if (flag)
				{
					this._lastconsumetime = (value ? new uint?(this.lastconsumetime) : null);
				}
			}
		}

		private bool ShouldSerializelastconsumetime()
		{
			return this.lastconsumetimeSpecified;
		}

		private void Resetlastconsumetime()
		{
			this.lastconsumetimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "rate", DataFormat = DataFormat.TwosComplement)]
		public uint rate
		{
			get
			{
				return this._rate ?? 0U;
			}
			set
			{
				this._rate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rateSpecified
		{
			get
			{
				return this._rate != null;
			}
			set
			{
				bool flag = value == (this._rate == null);
				if (flag)
				{
					this._rate = (value ? new uint?(this.rate) : null);
				}
			}
		}

		private bool ShouldSerializerate()
		{
			return this.rateSpecified;
		}

		private void Resetrate()
		{
			this.rateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _consumenum;

		private uint? _lastconsumetime;

		private uint? _rate;

		private IExtension extensionObject;
	}
}
