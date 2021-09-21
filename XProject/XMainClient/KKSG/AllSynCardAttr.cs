using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000203 RID: 515
	[ProtoContract(Name = "AllSynCardAttr")]
	[Serializable]
	public class AllSynCardAttr : IExtensible
	{
		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x06001D3B RID: 7483 RVA: 0x000398BC File Offset: 0x00037ABC
		[ProtoMember(1, Name = "allAttrs", DataFormat = DataFormat.Default)]
		public List<SynCardAttr> allAttrs
		{
			get
			{
				return this._allAttrs;
			}
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x000398D4 File Offset: 0x00037AD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400074C RID: 1868
		private readonly List<SynCardAttr> _allAttrs = new List<SynCardAttr>();

		// Token: 0x0400074D RID: 1869
		private IExtension extensionObject;
	}
}
