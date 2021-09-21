using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DC RID: 1244
	[ProtoContract(Name = "BattleFieldRankRes")]
	[Serializable]
	public class BattleFieldRankRes : IExtensible
	{
		// Token: 0x170013B0 RID: 5040
		// (get) Token: 0x06004057 RID: 16471 RVA: 0x0007A888 File Offset: 0x00078A88
		[ProtoMember(1, Name = "ranks", DataFormat = DataFormat.Default)]
		public List<BattleFieldRank> ranks
		{
			get
			{
				return this._ranks;
			}
		}

		// Token: 0x06004058 RID: 16472 RVA: 0x0007A8A0 File Offset: 0x00078AA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001007 RID: 4103
		private readonly List<BattleFieldRank> _ranks = new List<BattleFieldRank>();

		// Token: 0x04001008 RID: 4104
		private IExtension extensionObject;
	}
}
