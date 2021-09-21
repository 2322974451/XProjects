using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000569 RID: 1385
	[ProtoContract(Name = "ItemRandAttr")]
	[Serializable]
	public class ItemRandAttr : IExtensible
	{
		// Token: 0x170015D5 RID: 5589
		// (get) Token: 0x06004753 RID: 18259 RVA: 0x00087888 File Offset: 0x00085A88
		[ProtoMember(1, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		// Token: 0x06004754 RID: 18260 RVA: 0x000878A0 File Offset: 0x00085AA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011CF RID: 4559
		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		// Token: 0x040011D0 RID: 4560
		private IExtension extensionObject;
	}
}
