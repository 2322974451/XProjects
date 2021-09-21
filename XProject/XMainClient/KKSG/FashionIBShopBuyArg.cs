using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050F RID: 1295
	[ProtoContract(Name = "FashionIBShopBuyArg")]
	[Serializable]
	public class FashionIBShopBuyArg : IExtensible
	{
		// Token: 0x17001468 RID: 5224
		// (get) Token: 0x060042B8 RID: 17080 RVA: 0x0007EFCC File Offset: 0x0007D1CC
		[ProtoMember(1, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x060042B9 RID: 17081 RVA: 0x0007EFE4 File Offset: 0x0007D1E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010A3 RID: 4259
		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		// Token: 0x040010A4 RID: 4260
		private IExtension extensionObject;
	}
}
