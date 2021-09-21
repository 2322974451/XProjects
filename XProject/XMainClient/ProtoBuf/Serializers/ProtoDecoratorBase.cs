using System;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000874 RID: 2164
	internal abstract class ProtoDecoratorBase : IProtoSerializer
	{
		// Token: 0x170029B6 RID: 10678
		// (get) Token: 0x06008401 RID: 33793
		public abstract Type ExpectedType { get; }

		// Token: 0x06008402 RID: 33794 RVA: 0x001015ED File Offset: 0x000FF7ED
		protected ProtoDecoratorBase(IProtoSerializer tail)
		{
			this.Tail = tail;
		}

		// Token: 0x170029B7 RID: 10679
		// (get) Token: 0x06008403 RID: 33795
		public abstract bool ReturnsValue { get; }

		// Token: 0x170029B8 RID: 10680
		// (get) Token: 0x06008404 RID: 33796
		public abstract bool RequiresOldValue { get; }

		// Token: 0x06008405 RID: 33797
		public abstract void Write(object value, ProtoWriter dest);

		// Token: 0x06008406 RID: 33798
		public abstract object Read(object value, ProtoReader source);

		// Token: 0x04002909 RID: 10505
		protected readonly IProtoSerializer Tail;

		// Token: 0x0400290A RID: 10506
		public static Type[] s_propertyType = new Type[1];

		// Token: 0x0400290B RID: 10507
		public static object[] s_argsRead = new object[1];

		// Token: 0x0400290C RID: 10508
		public static object[] s_argsWrite = new object[1];
	}
}
