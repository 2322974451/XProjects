using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000701 RID: 1793
	[ProtoContract(Name = "IBGiftHistAllItem")]
	[Serializable]
	public class IBGiftHistAllItem : IExtensible
	{
		// Token: 0x1700266C RID: 9836
		// (get) Token: 0x0600794C RID: 31052 RVA: 0x000E7EB8 File Offset: 0x000E60B8
		[ProtoMember(1, Name = "allitem", DataFormat = DataFormat.Default)]
		public List<IBGiftHistItem> allitem
		{
			get
			{
				return this._allitem;
			}
		}

		// Token: 0x0600794D RID: 31053 RVA: 0x000E7ED0 File Offset: 0x000E60D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CA6 RID: 7334
		private readonly List<IBGiftHistItem> _allitem = new List<IBGiftHistItem>();

		// Token: 0x04001CA7 RID: 7335
		private IExtension extensionObject;
	}
}
