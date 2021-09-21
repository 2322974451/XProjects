using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BB RID: 955
	[ProtoContract(Name = "AllGiftIBItem")]
	[Serializable]
	public class AllGiftIBItem : IExtensible
	{
		// Token: 0x17000FC6 RID: 4038
		// (get) Token: 0x06003327 RID: 13095 RVA: 0x000624E4 File Offset: 0x000606E4
		[ProtoMember(1, Name = "gift", DataFormat = DataFormat.Default)]
		public List<GiftIbItem> gift
		{
			get
			{
				return this._gift;
			}
		}

		// Token: 0x06003328 RID: 13096 RVA: 0x000624FC File Offset: 0x000606FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CB6 RID: 3254
		private readonly List<GiftIbItem> _gift = new List<GiftIbItem>();

		// Token: 0x04000CB7 RID: 3255
		private IExtension extensionObject;
	}
}
