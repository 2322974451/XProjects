using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000384 RID: 900
	[ProtoContract(Name = "LeagueBattleBaseDataNtf")]
	[Serializable]
	public class LeagueBattleBaseDataNtf : IExtensible
	{
		// Token: 0x17000F1F RID: 3871
		// (get) Token: 0x060030E0 RID: 12512 RVA: 0x0005E3B0 File Offset: 0x0005C5B0
		// (set) Token: 0x060030E1 RID: 12513 RVA: 0x0005E3C8 File Offset: 0x0005C5C8
		[ProtoMember(1, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleOneTeam team1
		{
			get
			{
				return this._team1;
			}
			set
			{
				this._team1 = value;
			}
		}

		// Token: 0x17000F20 RID: 3872
		// (get) Token: 0x060030E2 RID: 12514 RVA: 0x0005E3D4 File Offset: 0x0005C5D4
		// (set) Token: 0x060030E3 RID: 12515 RVA: 0x0005E3EC File Offset: 0x0005C5EC
		[ProtoMember(2, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleOneTeam team2
		{
			get
			{
				return this._team2;
			}
			set
			{
				this._team2 = value;
			}
		}

		// Token: 0x060030E4 RID: 12516 RVA: 0x0005E3F8 File Offset: 0x0005C5F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C21 RID: 3105
		private LeagueBattleOneTeam _team1 = null;

		// Token: 0x04000C22 RID: 3106
		private LeagueBattleOneTeam _team2 = null;

		// Token: 0x04000C23 RID: 3107
		private IExtension extensionObject;
	}
}
