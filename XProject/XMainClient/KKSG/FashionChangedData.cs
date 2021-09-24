using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionChangedData")]
	[Serializable]
	public class FashionChangedData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "changeType", DataFormat = DataFormat.TwosComplement)]
		public FashionNTFType changeType
		{
			get
			{
				return this._changeType ?? FashionNTFType.ADD_FASHION;
			}
			set
			{
				this._changeType = new FashionNTFType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool changeTypeSpecified
		{
			get
			{
				return this._changeType != null;
			}
			set
			{
				bool flag = value == (this._changeType == null);
				if (flag)
				{
					this._changeType = (value ? new FashionNTFType?(this.changeType) : null);
				}
			}
		}

		private bool ShouldSerializechangeType()
		{
			return this.changeTypeSpecified;
		}

		private void ResetchangeType()
		{
			this.changeTypeSpecified = false;
		}

		[ProtoMember(2, Name = "fashion", DataFormat = DataFormat.Default)]
		public List<FashionData> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
		public uint special_effects_id
		{
			get
			{
				return this._special_effects_id ?? 0U;
			}
			set
			{
				this._special_effects_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool special_effects_idSpecified
		{
			get
			{
				return this._special_effects_id != null;
			}
			set
			{
				bool flag = value == (this._special_effects_id == null);
				if (flag)
				{
					this._special_effects_id = (value ? new uint?(this.special_effects_id) : null);
				}
			}
		}

		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private FashionNTFType? _changeType;

		private readonly List<FashionData> _fashion = new List<FashionData>();

		private uint? _special_effects_id;

		private IExtension extensionObject;
	}
}
