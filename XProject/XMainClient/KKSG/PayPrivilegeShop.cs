using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayPrivilegeShop")]
	[Serializable]
	public class PayPrivilegeShop : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "goodsID", DataFormat = DataFormat.TwosComplement)]
		public int goodsID
		{
			get
			{
				return this._goodsID ?? 0;
			}
			set
			{
				this._goodsID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goodsIDSpecified
		{
			get
			{
				return this._goodsID != null;
			}
			set
			{
				bool flag = value == (this._goodsID == null);
				if (flag)
				{
					this._goodsID = (value ? new int?(this.goodsID) : null);
				}
			}
		}

		private bool ShouldSerializegoodsID()
		{
			return this.goodsIDSpecified;
		}

		private void ResetgoodsID()
		{
			this.goodsIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "totalCount", DataFormat = DataFormat.TwosComplement)]
		public int totalCount
		{
			get
			{
				return this._totalCount ?? 0;
			}
			set
			{
				this._totalCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalCountSpecified
		{
			get
			{
				return this._totalCount != null;
			}
			set
			{
				bool flag = value == (this._totalCount == null);
				if (flag)
				{
					this._totalCount = (value ? new int?(this.totalCount) : null);
				}
			}
		}

		private bool ShouldSerializetotalCount()
		{
			return this.totalCountSpecified;
		}

		private void ResettotalCount()
		{
			this.totalCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "usedCount", DataFormat = DataFormat.TwosComplement)]
		public int usedCount
		{
			get
			{
				return this._usedCount ?? 0;
			}
			set
			{
				this._usedCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool usedCountSpecified
		{
			get
			{
				return this._usedCount != null;
			}
			set
			{
				bool flag = value == (this._usedCount == null);
				if (flag)
				{
					this._usedCount = (value ? new int?(this.usedCount) : null);
				}
			}
		}

		private bool ShouldSerializeusedCount()
		{
			return this.usedCountSpecified;
		}

		private void ResetusedCount()
		{
			this.usedCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _goodsID;

		private int? _totalCount;

		private int? _usedCount;

		private IExtension extensionObject;
	}
}
