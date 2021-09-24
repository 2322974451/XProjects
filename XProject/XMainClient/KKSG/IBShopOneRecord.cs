using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBShopOneRecord")]
	[Serializable]
	public class IBShopOneRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nGoodsID", DataFormat = DataFormat.TwosComplement)]
		public uint nGoodsID
		{
			get
			{
				return this._nGoodsID ?? 0U;
			}
			set
			{
				this._nGoodsID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nGoodsIDSpecified
		{
			get
			{
				return this._nGoodsID != null;
			}
			set
			{
				bool flag = value == (this._nGoodsID == null);
				if (flag)
				{
					this._nGoodsID = (value ? new uint?(this.nGoodsID) : null);
				}
			}
		}

		private bool ShouldSerializenGoodsID()
		{
			return this.nGoodsIDSpecified;
		}

		private void ResetnGoodsID()
		{
			this.nGoodsIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "activitytime", DataFormat = DataFormat.TwosComplement)]
		public uint activitytime
		{
			get
			{
				return this._activitytime ?? 0U;
			}
			set
			{
				this._activitytime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activitytimeSpecified
		{
			get
			{
				return this._activitytime != null;
			}
			set
			{
				bool flag = value == (this._activitytime == null);
				if (flag)
				{
					this._activitytime = (value ? new uint?(this.activitytime) : null);
				}
			}
		}

		private bool ShouldSerializeactivitytime()
		{
			return this.activitytimeSpecified;
		}

		private void Resetactivitytime()
		{
			this.activitytimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nItemCount", DataFormat = DataFormat.TwosComplement)]
		public uint nItemCount
		{
			get
			{
				return this._nItemCount ?? 0U;
			}
			set
			{
				this._nItemCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nItemCountSpecified
		{
			get
			{
				return this._nItemCount != null;
			}
			set
			{
				bool flag = value == (this._nItemCount == null);
				if (flag)
				{
					this._nItemCount = (value ? new uint?(this.nItemCount) : null);
				}
			}
		}

		private bool ShouldSerializenItemCount()
		{
			return this.nItemCountSpecified;
		}

		private void ResetnItemCount()
		{
			this.nItemCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "nUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint nUpdateTime
		{
			get
			{
				return this._nUpdateTime ?? 0U;
			}
			set
			{
				this._nUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nUpdateTimeSpecified
		{
			get
			{
				return this._nUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._nUpdateTime == null);
				if (flag)
				{
					this._nUpdateTime = (value ? new uint?(this.nUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializenUpdateTime()
		{
			return this.nUpdateTimeSpecified;
		}

		private void ResetnUpdateTime()
		{
			this.nUpdateTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nGoodsID;

		private uint? _activity;

		private uint? _activitytime;

		private uint? _nItemCount;

		private uint? _nUpdateTime;

		private IExtension extensionObject;
	}
}
