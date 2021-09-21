using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E8 RID: 232
	[ProtoContract(Name = "SceneLeftDoodad")]
	[Serializable]
	public class SceneLeftDoodad : IExtensible
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0001ED94 File Offset: 0x0001CF94
		[ProtoMember(1, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x0001EDAC File Offset: 0x0001CFAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003BF RID: 959
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040003C0 RID: 960
		private IExtension extensionObject;
	}
}
