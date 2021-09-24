using System;

namespace ProtoBuf.Serializers
{

	internal abstract class ProtoDecoratorBase : IProtoSerializer
	{

		public abstract Type ExpectedType { get; }

		protected ProtoDecoratorBase(IProtoSerializer tail)
		{
			this.Tail = tail;
		}

		public abstract bool ReturnsValue { get; }

		public abstract bool RequiresOldValue { get; }

		public abstract void Write(object value, ProtoWriter dest);

		public abstract object Read(object value, ProtoReader source);

		protected readonly IProtoSerializer Tail;

		public static Type[] s_propertyType = new Type[1];

		public static object[] s_argsRead = new object[1];

		public static object[] s_argsWrite = new object[1];
	}
}
