using System;
using System.ComponentModel;

namespace ProtoBuf
{
	// Token: 0x02000840 RID: 2112
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	[ImmutableObject(true)]
	public sealed class ProtoAfterDeserializationAttribute : Attribute
	{
	}
}
