using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000596 RID: 1430
	[ProtoContract(Name = "SweepResult")]
	[Serializable]
	public class SweepResult : IExtensible
	{
		// Token: 0x17001780 RID: 6016
		// (get) Token: 0x06004C52 RID: 19538 RVA: 0x000912FC File Offset: 0x0008F4FC
		[ProtoMember(1, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06004C53 RID: 19539 RVA: 0x00091314 File Offset: 0x0008F514
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012EE RID: 4846
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040012EF RID: 4847
		private IExtension extensionObject;
	}
}
