using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056E RID: 1390
	[ProtoContract(Name = "ItemArtifact")]
	[Serializable]
	public class ItemArtifact : IExtensible
	{
		// Token: 0x170015E7 RID: 5607
		// (get) Token: 0x06004788 RID: 18312 RVA: 0x00087EC0 File Offset: 0x000860C0
		[ProtoMember(1, Name = "unReplacedAttr", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> unReplacedAttr
		{
			get
			{
				return this._unReplacedAttr;
			}
		}

		// Token: 0x06004789 RID: 18313 RVA: 0x00087ED8 File Offset: 0x000860D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011E0 RID: 4576
		private readonly List<AttributeInfo> _unReplacedAttr = new List<AttributeInfo>();

		// Token: 0x040011E1 RID: 4577
		private IExtension extensionObject;
	}
}
