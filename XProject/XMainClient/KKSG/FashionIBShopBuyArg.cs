using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FashionIBShopBuyArg")]
	[Serializable]
	public class FashionIBShopBuyArg : IExtensible
	{

		[ProtoMember(1, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
