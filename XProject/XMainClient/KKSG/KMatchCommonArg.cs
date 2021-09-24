using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KMatchCommonArg")]
	[Serializable]
	public class KMatchCommonArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public KMatchType type
		{
			get
			{
				return this._type ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._type = new KMatchType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new KMatchType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public KMatchOp op
		{
			get
			{
				return this._op ?? KMatchOp.KMATCH_OP_START;
			}
			set
			{
				this._op = new KMatchOp?(value);
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
					this._op = (value ? new KMatchOp?(this.op) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "isteam", DataFormat = DataFormat.Default)]
		public bool isteam
		{
			get
			{
				return this._isteam ?? false;
			}
			set
			{
				this._isteam = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isteamSpecified
		{
			get
			{
				return this._isteam != null;
			}
			set
			{
				bool flag = value == (this._isteam == null);
				if (flag)
				{
					this._isteam = (value ? new bool?(this.isteam) : null);
				}
			}
		}

		private bool ShouldSerializeisteam()
		{
			return this.isteamSpecified;
		}

		private void Resetisteam()
		{
			this.isteamSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private KMatchType? _type;

		private KMatchOp? _op;

		private bool? _isteam;

		private IExtension extensionObject;
	}
}
