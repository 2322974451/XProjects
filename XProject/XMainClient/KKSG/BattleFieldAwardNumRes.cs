using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D9 RID: 1241
	[ProtoContract(Name = "BattleFieldAwardNumRes")]
	[Serializable]
	public class BattleFieldAwardNumRes : IExtensible
	{
		// Token: 0x170013A7 RID: 5031
		// (get) Token: 0x06004038 RID: 16440 RVA: 0x0007A4EC File Offset: 0x000786EC
		[ProtoMember(1, Name = "award", DataFormat = DataFormat.Default)]
		public List<BattleFieldLeftAward> award
		{
			get
			{
				return this._award;
			}
		}

		// Token: 0x06004039 RID: 16441 RVA: 0x0007A504 File Offset: 0x00078704
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FFF RID: 4095
		private readonly List<BattleFieldLeftAward> _award = new List<BattleFieldLeftAward>();

		// Token: 0x04001000 RID: 4096
		private IExtension extensionObject;
	}
}
