using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayGiftRecord")]
	[Serializable]
	public class PayGiftRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		private void Resetbuycount()
		{
			this.buycountSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "reqTime", DataFormat = DataFormat.TwosComplement)]
		public uint reqTime
		{
			get
			{
				return this._reqTime ?? 0U;
			}
			set
			{
				this._reqTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqTimeSpecified
		{
			get
			{
				return this._reqTime != null;
			}
			set
			{
				bool flag = value == (this._reqTime == null);
				if (flag)
				{
					this._reqTime = (value ? new uint?(this.reqTime) : null);
				}
			}
		}

		private bool ShouldSerializereqTime()
		{
			return this.reqTimeSpecified;
		}

		private void ResetreqTime()
		{
			this.reqTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private uint? _buycount;

		private uint? _lastBuyTime;

		private uint? _reqTime;

		private IExtension extensionObject;
	}
}
