using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EntityCategory")]
	public enum EntityCategory
	{

		[ProtoEnum(Name = "Category_Role", Value = 0)]
		Category_Role,

		[ProtoEnum(Name = "Category_Enemy", Value = 1)]
		Category_Enemy,

		[ProtoEnum(Name = "Category_Neutral", Value = 2)]
		Category_Neutral,

		[ProtoEnum(Name = "Category_DummyRole", Value = 3)]
		Category_DummyRole,

		[ProtoEnum(Name = "Category_Others", Value = 4)]
		Category_Others
	}
}
