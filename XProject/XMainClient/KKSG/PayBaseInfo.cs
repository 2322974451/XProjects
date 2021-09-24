using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayBaseInfo")]
	[Serializable]
	public class PayBaseInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "isPay", DataFormat = DataFormat.Default)]
		public bool isPay
		{
			get
			{
				return this._isPay ?? false;
			}
			set
			{
				this._isPay = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isPaySpecified
		{
			get
			{
				return this._isPay != null;
			}
			set
			{
				bool flag = value == (this._isPay == null);
				if (flag)
				{
					this._isPay = (value ? new bool?(this.isPay) : null);
				}
			}
		}

		private bool ShouldSerializeisPay()
		{
			return this.isPaySpecified;
		}

		private void ResetisPay()
		{
			this.isPaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _paramID;

		private bool? _isPay;

		private IExtension extensionObject;
	}
}
