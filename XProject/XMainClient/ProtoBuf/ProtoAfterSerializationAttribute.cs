using System;
using System.ComponentModel;

namespace ProtoBuf
{
	// Token: 0x0200083E RID: 2110
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	[ImmutableObject(true)]
	public sealed class ProtoAfterSerializationAttribute : Attribute
	{
	}
}
