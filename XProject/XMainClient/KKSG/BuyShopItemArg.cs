using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyShopItemArg")]
	[Serializable]
	public class BuyShopItemArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ItemUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong ItemUniqueId
		{
			get
			{
				return this._ItemUniqueId ?? 0UL;
			}
			set
			{
				this._ItemUniqueId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ItemUniqueIdSpecified
		{
			get
			{
				return this._ItemUniqueId != null;
			}
			set
			{
				bool flag = value == (this._ItemUniqueId == null);
				if (flag)
				{
					this._ItemUniqueId = (value ? new ulong?(this.ItemUniqueId) : null);
				}
			}
		}

		private bool ShouldSerializeItemUniqueId()
		{
			return this.ItemUniqueIdSpecified;
		}

		private void ResetItemUniqueId()
		{
			this.ItemUniqueIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _ItemUniqueId;

		private uint? _count;

		private IExtension extensionObject;
	}
}
