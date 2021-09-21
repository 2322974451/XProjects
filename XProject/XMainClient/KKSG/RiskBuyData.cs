using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021B RID: 539
	[ProtoContract(Name = "RiskBuyData")]
	[Serializable]
	public class RiskBuyData : IExtensible
	{
		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06001E2B RID: 7723 RVA: 0x0003B458 File Offset: 0x00039658
		[ProtoMember(1, Name = "rewardItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> rewardItems
		{
			get
			{
				return this._rewardItems;
			}
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06001E2C RID: 7724 RVA: 0x0003B470 File Offset: 0x00039670
		// (set) Token: 0x06001E2D RID: 7725 RVA: 0x0003B488 File Offset: 0x00039688
		[ProtoMember(2, IsRequired = false, Name = "cost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				this._cost = value;
			}
		}

		// Token: 0x06001E2E RID: 7726 RVA: 0x0003B494 File Offset: 0x00039694
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400078B RID: 1931
		private readonly List<ItemBrief> _rewardItems = new List<ItemBrief>();

		// Token: 0x0400078C RID: 1932
		private ItemBrief _cost = null;

		// Token: 0x0400078D RID: 1933
		private IExtension extensionObject;
	}
}
