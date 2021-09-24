using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBShopAllRecord")]
	[Serializable]
	public class IBShopAllRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nLastTime", DataFormat = DataFormat.TwosComplement)]
		public uint nLastTime
		{
			get
			{
				return this._nLastTime ?? 0U;
			}
			set
			{
				this._nLastTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nLastTimeSpecified
		{
			get
			{
				return this._nLastTime != null;
			}
			set
			{
				bool flag = value == (this._nLastTime == null);
				if (flag)
				{
					this._nLastTime = (value ? new uint?(this.nLastTime) : null);
				}
			}
		}

		private bool ShouldSerializenLastTime()
		{
			return this.nLastTimeSpecified;
		}

		private void ResetnLastTime()
		{
			this.nLastTimeSpecified = false;
		}

		[ProtoMember(2, Name = "allIBShopItems", DataFormat = DataFormat.Default)]
		public List<IBShopOneRecord> allIBShopItems
		{
			get
			{
				return this._allIBShopItems;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "nVipLv", DataFormat = DataFormat.TwosComplement)]
		public uint nVipLv
		{
			get
			{
				return this._nVipLv ?? 0U;
			}
			set
			{
				this._nVipLv = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nVipLvSpecified
		{
			get
			{
				return this._nVipLv != null;
			}
			set
			{
				bool flag = value == (this._nVipLv == null);
				if (flag)
				{
					this._nVipLv = (value ? new uint?(this.nVipLv) : null);
				}
			}
		}

		private bool ShouldSerializenVipLv()
		{
			return this.nVipLvSpecified;
		}

		private void ResetnVipLv()
		{
			this.nVipLvSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "bLimitHot", DataFormat = DataFormat.Default)]
		public bool bLimitHot
		{
			get
			{
				return this._bLimitHot ?? false;
			}
			set
			{
				this._bLimitHot = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bLimitHotSpecified
		{
			get
			{
				return this._bLimitHot != null;
			}
			set
			{
				bool flag = value == (this._bLimitHot == null);
				if (flag)
				{
					this._bLimitHot = (value ? new bool?(this.bLimitHot) : null);
				}
			}
		}

		private bool ShouldSerializebLimitHot()
		{
			return this.bLimitHotSpecified;
		}

		private void ResetbLimitHot()
		{
			this.bLimitHotSpecified = false;
		}

		[ProtoMember(5, Name = "orders", DataFormat = DataFormat.Default)]
		public List<IBGiftOrder> orders
		{
			get
			{
				return this._orders;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "paydegree", DataFormat = DataFormat.TwosComplement)]
		public uint paydegree
		{
			get
			{
				return this._paydegree ?? 0U;
			}
			set
			{
				this._paydegree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paydegreeSpecified
		{
			get
			{
				return this._paydegree != null;
			}
			set
			{
				bool flag = value == (this._paydegree == null);
				if (flag)
				{
					this._paydegree = (value ? new uint?(this.paydegree) : null);
				}
			}
		}

		private bool ShouldSerializepaydegree()
		{
			return this.paydegreeSpecified;
		}

		private void Resetpaydegree()
		{
			this.paydegreeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "daytime", DataFormat = DataFormat.TwosComplement)]
		public uint daytime
		{
			get
			{
				return this._daytime ?? 0U;
			}
			set
			{
				this._daytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daytimeSpecified
		{
			get
			{
				return this._daytime != null;
			}
			set
			{
				bool flag = value == (this._daytime == null);
				if (flag)
				{
					this._daytime = (value ? new uint?(this.daytime) : null);
				}
			}
		}

		private bool ShouldSerializedaytime()
		{
			return this.daytimeSpecified;
		}

		private void Resetdaytime()
		{
			this.daytimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nLastTime;

		private readonly List<IBShopOneRecord> _allIBShopItems = new List<IBShopOneRecord>();

		private uint? _nVipLv;

		private bool? _bLimitHot;

		private readonly List<IBGiftOrder> _orders = new List<IBGiftOrder>();

		private uint? _paydegree;

		private uint? _daytime;

		private IExtension extensionObject;
	}
}
