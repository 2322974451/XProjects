using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007ED RID: 2029
	[ProtoContract(Name = "CommentType")]
	public enum CommentType
	{
		// Token: 0x04002689 RID: 9865
		[ProtoEnum(Name = "COMMENT_NEST", Value = 1)]
		COMMENT_NEST = 1,
		// Token: 0x0400268A RID: 9866
		[ProtoEnum(Name = "COMMENT_DRAGON", Value = 2)]
		COMMENT_DRAGON,
		// Token: 0x0400268B RID: 9867
		[ProtoEnum(Name = "COMMENT_LADDER", Value = 3)]
		COMMENT_LADDER,
		// Token: 0x0400268C RID: 9868
		[ProtoEnum(Name = "COMMENT_ATLAS", Value = 4)]
		COMMENT_ATLAS,
		// Token: 0x0400268D RID: 9869
		[ProtoEnum(Name = "COMMENT_PANDORA", Value = 5)]
		COMMENT_PANDORA,
		// Token: 0x0400268E RID: 9870
		[ProtoEnum(Name = "COMMENT_SPRITE", Value = 6)]
		COMMENT_SPRITE
	}
}
