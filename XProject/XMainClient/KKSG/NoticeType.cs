using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeType")]
	public enum NoticeType
	{

		[ProtoEnum(Name = "Notice_Role", Value = 1)]
		Notice_Role = 1,

		[ProtoEnum(Name = "Notice_Team", Value = 2)]
		Notice_Team,

		[ProtoEnum(Name = "Notice_Guild", Value = 3)]
		Notice_Guild,

		[ProtoEnum(Name = "Notice_World", Value = 4)]
		Notice_World,

		[ProtoEnum(Name = "Notice_Partner", Value = 5)]
		Notice_Partner,

		[ProtoEnum(Name = "Notice_Server", Value = 6)]
		Notice_Server
	}
}
