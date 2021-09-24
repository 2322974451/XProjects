using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAileenInfo")]
	[Serializable]
	public class PayAileenInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "paramID", DataFormat = DataFormat.Default)]
		public string paramID
		{
			get
			{
				return this._paramID ?? "";
			}
			set
			{
				this._paramID = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramIDSpecified
		{
			get
			{
				return this._paramID != null;
			}
			set
			{
				bool flag = value == (this._paramID == null);
				if (flag)
				{
					this._paramID = (value ? this.paramID : null);
				}
			}
		}

		private bool ShouldSerializeparamID()
		{
			return this.paramIDSpecified;
		}

		private void ResetparamID()
		{
			this.paramIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isBuy", DataFormat = DataFormat.Default)]
		public bool isBuy
		{
			get
			{
				return this._isBuy ?? false;
			}
			set
			{
				this._isBuy = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isBuySpecified
		{
			get
			{
				return this._isBuy != null;
			}
			set
			{
				bool flag = value == (this._isBuy == null);
				if (flag)
				{
					this._isBuy = (value ? new bool?(this.isBuy) : null);
				}
			}
		}

		private bool ShouldSerializeisBuy()
		{
			return this.isBuySpecified;
		}

		private void ResetisBuy()
		{
			this.isBuySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _paramID;

		private int? _itemID;

		private bool? _isBuy;

		private IExtension extensionObject;
	}
}
