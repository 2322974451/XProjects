using System;
using System.ComponentModel;

namespace ProtoBuf
{
	// Token: 0x0200083D RID: 2109
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	[ImmutableObject(true)]
	public sealed class ProtoBeforeSerializationAttribute : Attribute
	{
	}
}
