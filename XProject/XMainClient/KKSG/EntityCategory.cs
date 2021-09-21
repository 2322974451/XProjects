using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000752 RID: 1874
	[ProtoContract(Name = "EntityCategory")]
	public enum EntityCategory
	{
		// Token: 0x0400227B RID: 8827
		[ProtoEnum(Name = "Category_Role", Value = 0)]
		Category_Role,
		// Token: 0x0400227C RID: 8828
		[ProtoEnum(Name = "Category_Enemy", Value = 1)]
		Category_Enemy,
		// Token: 0x0400227D RID: 8829
		[ProtoEnum(Name = "Category_Neutral", Value = 2)]
		Category_Neutral,
		// Token: 0x0400227E RID: 8830
		[ProtoEnum(Name = "Category_DummyRole", Value = 3)]
		Category_DummyRole,
		// Token: 0x0400227F RID: 8831
		[ProtoEnum(Name = "Category_Others", Value = 4)]
		Category_Others
	}
}
