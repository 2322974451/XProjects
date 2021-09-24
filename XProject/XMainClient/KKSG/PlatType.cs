using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatType")]
	public enum PlatType
	{

		[ProtoEnum(Name = "PLAT_IOS", Value = 0)]
		PLAT_IOS,

		[ProtoEnum(Name = "PLAT_ANDROID", Value = 1)]
		PLAT_ANDROID
	}
}
