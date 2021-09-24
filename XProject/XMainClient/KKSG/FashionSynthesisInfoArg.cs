using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionSynthesisInfoArg")]
	[Serializable]
	public class FashionSynthesisInfoArg : IExtensible
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _fashion_id;

		private IExtension extensionObject;
	}
}
