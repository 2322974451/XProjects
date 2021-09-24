using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkNVNType")]
	public enum PkNVNType
	{

		[ProtoEnum(Name = "PK_1v1", Value = 1)]
		PK_1v1 = 1,

		[ProtoEnum(Name = "PK_2v2", Value = 2)]
		PK_2v2
	}
}
