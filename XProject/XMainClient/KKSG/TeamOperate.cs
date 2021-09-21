using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000757 RID: 1879
	[ProtoContract(Name = "TeamOperate")]
	public enum TeamOperate
	{
		// Token: 0x040022C6 RID: 8902
		[ProtoEnum(Name = "TEAM_CREATE", Value = 1)]
		TEAM_CREATE = 1,
		// Token: 0x040022C7 RID: 8903
		[ProtoEnum(Name = "TEAM_JOIN", Value = 2)]
		TEAM_JOIN,
		// Token: 0x040022C8 RID: 8904
		[ProtoEnum(Name = "TEAM_LEAVE", Value = 3)]
		TEAM_LEAVE,
		// Token: 0x040022C9 RID: 8905
		[ProtoEnum(Name = "TEAM_TOGGLE_READY", Value = 4)]
		TEAM_TOGGLE_READY,
		// Token: 0x040022CA RID: 8906
		[ProtoEnum(Name = "TEAM_QUERYCOUNT", Value = 5)]
		TEAM_QUERYCOUNT,
		// Token: 0x040022CB RID: 8907
		[ProtoEnum(Name = "TEAM_KICK", Value = 6)]
		TEAM_KICK,
		// Token: 0x040022CC RID: 8908
		[ProtoEnum(Name = "TEAM_START_BATTLE", Value = 7)]
		TEAM_START_BATTLE,
		// Token: 0x040022CD RID: 8909
		[ProtoEnum(Name = "TEAM_START_BATTLE_AGREE", Value = 8)]
		TEAM_START_BATTLE_AGREE,
		// Token: 0x040022CE RID: 8910
		[ProtoEnum(Name = "TEAM_START_BATTLE_DISAGREE", Value = 9)]
		TEAM_START_BATTLE_DISAGREE,
		// Token: 0x040022CF RID: 8911
		[ProtoEnum(Name = "TEAM_CHANGE_EPXTEAMID", Value = 10)]
		TEAM_CHANGE_EPXTEAMID,
		// Token: 0x040022D0 RID: 8912
		[ProtoEnum(Name = "TEAM_START_BATTLE_REMOVE_DISAGREE_MEMBER", Value = 11)]
		TEAM_START_BATTLE_REMOVE_DISAGREE_MEMBER,
		// Token: 0x040022D1 RID: 8913
		[ProtoEnum(Name = "TEAM_INVITE", Value = 12)]
		TEAM_INVITE,
		// Token: 0x040022D2 RID: 8914
		[ProtoEnum(Name = "TEAM_START_MATCH", Value = 13)]
		TEAM_START_MATCH,
		// Token: 0x040022D3 RID: 8915
		[ProtoEnum(Name = "TEAM_STOP_MATCH", Value = 14)]
		TEAM_STOP_MATCH,
		// Token: 0x040022D4 RID: 8916
		[ProtoEnum(Name = "TEAM_GET_FULL_DATA", Value = 15)]
		TEAM_GET_FULL_DATA,
		// Token: 0x040022D5 RID: 8917
		[ProtoEnum(Name = "TEAM_DOWN_MATCH", Value = 16)]
		TEAM_DOWN_MATCH,
		// Token: 0x040022D6 RID: 8918
		[ProtoEnum(Name = "TEAM_BE_HELPER", Value = 17)]
		TEAM_BE_HELPER,
		// Token: 0x040022D7 RID: 8919
		[ProtoEnum(Name = "TEAM_QUIT_HELPER", Value = 18)]
		TEAM_QUIT_HELPER,
		// Token: 0x040022D8 RID: 8920
		[ProtoEnum(Name = "TEAM_PPTLIMIT", Value = 19)]
		TEAM_PPTLIMIT,
		// Token: 0x040022D9 RID: 8921
		[ProtoEnum(Name = "TEAM_COSTTYPE", Value = 20)]
		TEAM_COSTTYPE,
		// Token: 0x040022DA RID: 8922
		[ProtoEnum(Name = "TEAM_CHANGE_PASSWORD", Value = 21)]
		TEAM_CHANGE_PASSWORD,
		// Token: 0x040022DB RID: 8923
		[ProtoEnum(Name = "TEAM_TRAHS_LEADER", Value = 22)]
		TEAM_TRAHS_LEADER,
		// Token: 0x040022DC RID: 8924
		[ProtoEnum(Name = "TEAM_BATTLE_CONTINUE", Value = 23)]
		TEAM_BATTLE_CONTINUE,
		// Token: 0x040022DD RID: 8925
		[ProtoEnum(Name = "TEAM_USE_TICKET", Value = 24)]
		TEAM_USE_TICKET,
		// Token: 0x040022DE RID: 8926
		[ProtoEnum(Name = "TEAM_MEMBER_TYPE", Value = 25)]
		TEAM_MEMBER_TYPE
	}
}
