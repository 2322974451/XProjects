using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamOperate")]
	public enum TeamOperate
	{

		[ProtoEnum(Name = "TEAM_CREATE", Value = 1)]
		TEAM_CREATE = 1,

		[ProtoEnum(Name = "TEAM_JOIN", Value = 2)]
		TEAM_JOIN,

		[ProtoEnum(Name = "TEAM_LEAVE", Value = 3)]
		TEAM_LEAVE,

		[ProtoEnum(Name = "TEAM_TOGGLE_READY", Value = 4)]
		TEAM_TOGGLE_READY,

		[ProtoEnum(Name = "TEAM_QUERYCOUNT", Value = 5)]
		TEAM_QUERYCOUNT,

		[ProtoEnum(Name = "TEAM_KICK", Value = 6)]
		TEAM_KICK,

		[ProtoEnum(Name = "TEAM_START_BATTLE", Value = 7)]
		TEAM_START_BATTLE,

		[ProtoEnum(Name = "TEAM_START_BATTLE_AGREE", Value = 8)]
		TEAM_START_BATTLE_AGREE,

		[ProtoEnum(Name = "TEAM_START_BATTLE_DISAGREE", Value = 9)]
		TEAM_START_BATTLE_DISAGREE,

		[ProtoEnum(Name = "TEAM_CHANGE_EPXTEAMID", Value = 10)]
		TEAM_CHANGE_EPXTEAMID,

		[ProtoEnum(Name = "TEAM_START_BATTLE_REMOVE_DISAGREE_MEMBER", Value = 11)]
		TEAM_START_BATTLE_REMOVE_DISAGREE_MEMBER,

		[ProtoEnum(Name = "TEAM_INVITE", Value = 12)]
		TEAM_INVITE,

		[ProtoEnum(Name = "TEAM_START_MATCH", Value = 13)]
		TEAM_START_MATCH,

		[ProtoEnum(Name = "TEAM_STOP_MATCH", Value = 14)]
		TEAM_STOP_MATCH,

		[ProtoEnum(Name = "TEAM_GET_FULL_DATA", Value = 15)]
		TEAM_GET_FULL_DATA,

		[ProtoEnum(Name = "TEAM_DOWN_MATCH", Value = 16)]
		TEAM_DOWN_MATCH,

		[ProtoEnum(Name = "TEAM_BE_HELPER", Value = 17)]
		TEAM_BE_HELPER,

		[ProtoEnum(Name = "TEAM_QUIT_HELPER", Value = 18)]
		TEAM_QUIT_HELPER,

		[ProtoEnum(Name = "TEAM_PPTLIMIT", Value = 19)]
		TEAM_PPTLIMIT,

		[ProtoEnum(Name = "TEAM_COSTTYPE", Value = 20)]
		TEAM_COSTTYPE,

		[ProtoEnum(Name = "TEAM_CHANGE_PASSWORD", Value = 21)]
		TEAM_CHANGE_PASSWORD,

		[ProtoEnum(Name = "TEAM_TRAHS_LEADER", Value = 22)]
		TEAM_TRAHS_LEADER,

		[ProtoEnum(Name = "TEAM_BATTLE_CONTINUE", Value = 23)]
		TEAM_BATTLE_CONTINUE,

		[ProtoEnum(Name = "TEAM_USE_TICKET", Value = 24)]
		TEAM_USE_TICKET,

		[ProtoEnum(Name = "TEAM_MEMBER_TYPE", Value = 25)]
		TEAM_MEMBER_TYPE
	}
}
