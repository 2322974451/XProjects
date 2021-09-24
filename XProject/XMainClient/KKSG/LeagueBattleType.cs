using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleType")]
	public enum LeagueBattleType
	{

		[ProtoEnum(Name = "LeagueBattleType_RacePoint", Value = 1)]
		LeagueBattleType_RacePoint = 1,

		[ProtoEnum(Name = "LeagueBattleType_Eliminate", Value = 2)]
		LeagueBattleType_Eliminate,

		[ProtoEnum(Name = "LeagueBattleType_CrossRacePoint", Value = 3)]
		LeagueBattleType_CrossRacePoint,

		[ProtoEnum(Name = "LeagueBattleType_CrossEliminate", Value = 4)]
		LeagueBattleType_CrossEliminate
	}
}
