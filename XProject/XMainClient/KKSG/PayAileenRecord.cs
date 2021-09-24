using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAileenRecord")]
	[Serializable]
	public class PayAileenRecord : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "lastBuyTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastBuyTime
		{
			get
			{
				return this._lastBuyTime ?? 0U;
			}
			set
			{
				this._lastBuyTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastBuyTimeSpecified
		{
			get
			{
				return this._lastBuyTime != null;
			}
			set
			{
				bool flag = value == (this._lastBuyTime == null);
				if (flag)
				{
					this._lastBuyTime = (value ? new uint?(this.lastBuyTime) : null);
				}
			}
		}

		private bool ShouldSerializelastBuyTime()
		{
			return this.lastBuyTimeSpecified;
		}

		private void ResetlastBuyTime()
		{
			this.lastBuyTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "detail", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PaytssInfo detail
		{
			get
			{
				return this._detail;
			}
			set
			{
				this._detail = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "lastdelivertime", DataFormat = DataFormat.TwosComplement)]
		public uint lastdelivertime
		{
			get
			{
				return this._lastdelivertime ?? 0U;
			}
			set
			{
				this._lastdelivertime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastdelivertimeSpecified
		{
			get
			{
				return this._lastdelivertime != null;
			}
			set
			{
				bool flag = value == (this._lastdelivertime == null);
				if (flag)
				{
					this._lastdelivertime = (value ? new uint?(this.lastdelivertime) : null);
				}
			}
		}

		private bool ShouldSerializelastdelivertime()
		{
			return this.lastdelivertimeSpecified;
		}

		private void Resetlastdelivertime()
		{
			this.lastdelivertimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _paramID;

		private int? _itemID;

		private uint? _lastBuyTime;

		private PaytssInfo _detail = null;

		private uint? _lastdelivertime;

		private IExtension extensionObject;
	}
}
