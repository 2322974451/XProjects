using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFG2CSynType")]
	public enum GCFG2CSynType
	{

		[ProtoEnum(Name = "GCF_G2C_SYN_KILL_ONE", Value = 1)]
		GCF_G2C_SYN_KILL_ONE = 1,

		[ProtoEnum(Name = "GCF_G2C_SYN_MUL_POINT", Value = 2)]
		GCF_G2C_SYN_MUL_POINT,

		[ProtoEnum(Name = "GCF_G2C_SYN_OCCUPY", Value = 3)]
		GCF_G2C_SYN_OCCUPY,

		[ProtoEnum(Name = "GCF_G2C_SYN_KILL_COUNT", Value = 4)]
		GCF_G2C_SYN_KILL_COUNT
	}
}
