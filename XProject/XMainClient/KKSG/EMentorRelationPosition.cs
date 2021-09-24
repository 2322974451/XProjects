using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EMentorRelationPosition")]
	public enum EMentorRelationPosition
	{

		[ProtoEnum(Name = "EMentorPosMaster", Value = 1)]
		EMentorPosMaster = 1,

		[ProtoEnum(Name = "EMentorPosStudent", Value = 2)]
		EMentorPosStudent,

		[ProtoEnum(Name = "EMentorPosMax", Value = 3)]
		EMentorPosMax
	}
}
