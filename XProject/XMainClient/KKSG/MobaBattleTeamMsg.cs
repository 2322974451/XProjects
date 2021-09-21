using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000425 RID: 1061
	[ProtoContract(Name = "MobaBattleTeamMsg")]
	[Serializable]
	public class MobaBattleTeamMsg : IExtensible
	{
		// Token: 0x17001149 RID: 4425
		// (get) Token: 0x06003844 RID: 14404 RVA: 0x0006BB54 File Offset: 0x00069D54
		[ProtoMember(1, Name = "teamdata", DataFormat = DataFormat.Default)]
		public List<MobaBattleTeamData> teamdata
		{
			get
			{
				return this._teamdata;
			}
		}

		// Token: 0x06003845 RID: 14405 RVA: 0x0006BB6C File Offset: 0x00069D6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DF4 RID: 3572
		private readonly List<MobaBattleTeamData> _teamdata = new List<MobaBattleTeamData>();

		// Token: 0x04000DF5 RID: 3573
		private IExtension extensionObject;
	}
}
