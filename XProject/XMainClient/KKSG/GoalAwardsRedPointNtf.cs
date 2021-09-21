using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D7 RID: 1239
	[ProtoContract(Name = "GoalAwardsRedPointNtf")]
	[Serializable]
	public class GoalAwardsRedPointNtf : IExtensible
	{
		// Token: 0x170013A6 RID: 5030
		// (get) Token: 0x06004033 RID: 16435 RVA: 0x0007A480 File Offset: 0x00078680
		[ProtoMember(1, Name = "typelist", DataFormat = DataFormat.TwosComplement)]
		public List<uint> typelist
		{
			get
			{
				return this._typelist;
			}
		}

		// Token: 0x06004034 RID: 16436 RVA: 0x0007A498 File Offset: 0x00078698
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FFC RID: 4092
		private readonly List<uint> _typelist = new List<uint>();

		// Token: 0x04000FFD RID: 4093
		private IExtension extensionObject;
	}
}
