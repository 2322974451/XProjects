using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CommentType")]
	public enum CommentType
	{

		[ProtoEnum(Name = "COMMENT_NEST", Value = 1)]
		COMMENT_NEST = 1,

		[ProtoEnum(Name = "COMMENT_DRAGON", Value = 2)]
		COMMENT_DRAGON,

		[ProtoEnum(Name = "COMMENT_LADDER", Value = 3)]
		COMMENT_LADDER,

		[ProtoEnum(Name = "COMMENT_ATLAS", Value = 4)]
		COMMENT_ATLAS,

		[ProtoEnum(Name = "COMMENT_PANDORA", Value = 5)]
		COMMENT_PANDORA,

		[ProtoEnum(Name = "COMMENT_SPRITE", Value = 6)]
		COMMENT_SPRITE
	}
}
