using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000344 RID: 836
	[ProtoContract(Name = "HeroBattleTeamMsg")]
	[Serializable]
	public class HeroBattleTeamMsg : IExtensible
	{
		// Token: 0x17000E31 RID: 3633
		// (get) Token: 0x06002DBD RID: 11709 RVA: 0x000587D4 File Offset: 0x000569D4
		[ProtoMember(1, Name = "teamdata", DataFormat = DataFormat.Default)]
		public List<HeroBattleTeamData> teamdata
		{
			get
			{
				return this._teamdata;
			}
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x000587EC File Offset: 0x000569EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B5F RID: 2911
		private readonly List<HeroBattleTeamData> _teamdata = new List<HeroBattleTeamData>();

		// Token: 0x04000B60 RID: 2912
		private IExtension extensionObject;
	}
}
