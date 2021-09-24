using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionSynthesisInfoRes")]
	[Serializable]
	public class FashionSynthesisInfoRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "add_succes_rate", DataFormat = DataFormat.TwosComplement)]
		public uint add_succes_rate
		{
			get
			{
				return this._add_succes_rate ?? 0U;
			}
			set
			{
				this._add_succes_rate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool add_succes_rateSpecified
		{
			get
			{
				return this._add_succes_rate != null;
			}
			set
			{
				bool flag = value == (this._add_succes_rate == null);
				if (flag)
				{
					this._add_succes_rate = (value ? new uint?(this.add_succes_rate) : null);
				}
			}
		}

		private bool ShouldSerializeadd_succes_rate()
		{
			return this.add_succes_rateSpecified;
		}

		private void Resetadd_succes_rate()
		{
			this.add_succes_rateSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _fashion_id;

		private uint? _add_succes_rate;

		private ErrorCode? _result;

		private IExtension extensionObject;
	}
}
