using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003ED RID: 1005
	[ProtoContract(Name = "TalkGuildCampSpriteRes")]
	[Serializable]
	public class TalkGuildCampSpriteRes : IExtensible
	{
		// Token: 0x1700106D RID: 4205
		// (get) Token: 0x06003568 RID: 13672 RVA: 0x000665C0 File Offset: 0x000647C0
		[ProtoMember(1, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06003569 RID: 13673 RVA: 0x000665D8 File Offset: 0x000647D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D43 RID: 3395
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000D44 RID: 3396
		private IExtension extensionObject;
	}
}
