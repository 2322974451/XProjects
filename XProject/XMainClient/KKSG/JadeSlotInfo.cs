using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JadeSlotInfo")]
	[Serializable]
	public class JadeSlotInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "operatorType", DataFormat = DataFormat.TwosComplement)]
		public uint operatorType
		{
			get
			{
				return this._operatorType ?? 0U;
			}
			set
			{
				this._operatorType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool operatorTypeSpecified
		{
			get
			{
				return this._operatorType != null;
			}
			set
			{
				bool flag = value == (this._operatorType == null);
				if (flag)
				{
					this._operatorType = (value ? new uint?(this.operatorType) : null);
				}
			}
		}

		private bool ShouldSerializeoperatorType()
		{
			return this.operatorTypeSpecified;
		}

		private void ResetoperatorType()
		{
			this.operatorTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "jadeSlot", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSlot
		{
			get
			{
				return this._jadeSlot ?? 0U;
			}
			set
			{
				this._jadeSlot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSlotSpecified
		{
			get
			{
				return this._jadeSlot != null;
			}
			set
			{
				bool flag = value == (this._jadeSlot == null);
				if (flag)
				{
					this._jadeSlot = (value ? new uint?(this.jadeSlot) : null);
				}
			}
		}

		private bool ShouldSerializejadeSlot()
		{
			return this.jadeSlotSpecified;
		}

		private void ResetjadeSlot()
		{
			this.jadeSlotSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _operatorType;

		private uint? _jadeSlot;

		private IExtension extensionObject;
	}
}
