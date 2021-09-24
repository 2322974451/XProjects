using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowShopGood")]
	[Serializable]
	public class BackFlowShopGood : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "GoodID", DataFormat = DataFormat.TwosComplement)]
		public uint GoodID
		{
			get
			{
				return this._GoodID ?? 0U;
			}
			set
			{
				this._GoodID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool GoodIDSpecified
		{
			get
			{
				return this._GoodID != null;
			}
			set
			{
				bool flag = value == (this._GoodID == null);
				if (flag)
				{
					this._GoodID = (value ? new uint?(this.GoodID) : null);
				}
			}
		}

		private bool ShouldSerializeGoodID()
		{
			return this.GoodIDSpecified;
		}

		private void ResetGoodID()
		{
			this.GoodIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "IsBuy", DataFormat = DataFormat.Default)]
		public bool IsBuy
		{
			get
			{
				return this._IsBuy ?? false;
			}
			set
			{
				this._IsBuy = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsBuySpecified
		{
			get
			{
				return this._IsBuy != null;
			}
			set
			{
				bool flag = value == (this._IsBuy == null);
				if (flag)
				{
					this._IsBuy = (value ? new bool?(this.IsBuy) : null);
				}
			}
		}

		private bool ShouldSerializeIsBuy()
		{
			return this.IsBuySpecified;
		}

		private void ResetIsBuy()
		{
			this.IsBuySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "LockTime", DataFormat = DataFormat.TwosComplement)]
		public uint LockTime
		{
			get
			{
				return this._LockTime ?? 0U;
			}
			set
			{
				this._LockTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LockTimeSpecified
		{
			get
			{
				return this._LockTime != null;
			}
			set
			{
				bool flag = value == (this._LockTime == null);
				if (flag)
				{
					this._LockTime = (value ? new uint?(this.LockTime) : null);
				}
			}
		}

		private bool ShouldSerializeLockTime()
		{
			return this.LockTimeSpecified;
		}

		private void ResetLockTime()
		{
			this.LockTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _GoodID;

		private bool? _IsBuy;

		private uint? _LockTime;

		private IExtension extensionObject;
	}
}
