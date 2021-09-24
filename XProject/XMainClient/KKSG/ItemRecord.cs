using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemRecord")]
	[Serializable]
	public class ItemRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
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
					this._itemID = (value ? new uint?(this.itemID) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public uint itemCount
		{
			get
			{
				return this._itemCount ?? 0U;
			}
			set
			{
				this._itemCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new uint?(this.itemCount) : null);
				}
			}
		}

		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isreceive", DataFormat = DataFormat.Default)]
		public bool isreceive
		{
			get
			{
				return this._isreceive ?? false;
			}
			set
			{
				this._isreceive = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isreceiveSpecified
		{
			get
			{
				return this._isreceive != null;
			}
			set
			{
				bool flag = value == (this._isreceive == null);
				if (flag)
				{
					this._isreceive = (value ? new bool?(this.isreceive) : null);
				}
			}
		}

		private bool ShouldSerializeisreceive()
		{
			return this.isreceiveSpecified;
		}

		private void Resetisreceive()
		{
			this.isreceiveSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _itemID;

		private uint? _itemCount;

		private bool? _isreceive;

		private IExtension extensionObject;
	}
}
