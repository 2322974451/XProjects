using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBGiftTips")]
	[Serializable]
	public class IBGiftTips : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "orderid", DataFormat = DataFormat.Default)]
		public string orderid
		{
			get
			{
				return this._orderid ?? "";
			}
			set
			{
				this._orderid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool orderidSpecified
		{
			get
			{
				return this._orderid != null;
			}
			set
			{
				bool flag = value == (this._orderid == null);
				if (flag)
				{
					this._orderid = (value ? this.orderid : null);
				}
			}
		}

		private bool ShouldSerializeorderid()
		{
			return this.orderidSpecified;
		}

		private void Resetorderid()
		{
			this.orderidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _orderid;

		private IExtension extensionObject;
	}
}
