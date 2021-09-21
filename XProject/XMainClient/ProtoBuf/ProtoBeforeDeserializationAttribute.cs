using System;
using System.ComponentModel;

namespace ProtoBuf
{
	// Token: 0x0200083F RID: 2111
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	[ImmutableObject(true)]
	public sealed class ProtoBeforeDeserializationAttribute : Attribute
	{
	}
}
