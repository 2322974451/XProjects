using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000729 RID: 1833
	[ProtoContract(Name = "WarningItemSet")]
	[Serializable]
	public class WarningItemSet : IExtensible
	{
		// Token: 0x1700280E RID: 10254
		// (get) Token: 0x06007E59 RID: 32345 RVA: 0x000F1994 File Offset: 0x000EFB94
		[ProtoMember(1, Name = "WarningItem", DataFormat = DataFormat.Default)]
		public List<WarningPackage> WarningItem
		{
			get
			{
				return this._WarningItem;
			}
		}

		// Token: 0x06007E5A RID: 32346 RVA: 0x000F19AC File Offset: 0x000EFBAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DAD RID: 7597
		private readonly List<WarningPackage> _WarningItem = new List<WarningPackage>();

		// Token: 0x04001DAE RID: 7598
		private IExtension extensionObject;
	}
}
