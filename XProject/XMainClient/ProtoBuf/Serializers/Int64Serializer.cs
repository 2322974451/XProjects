using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200086A RID: 2154
	internal sealed class Int64Serializer : IProtoSerializer
	{
		// Token: 0x060083BC RID: 33724 RVA: 0x0000311A File Offset: 0x0000131A
		public Int64Serializer(TypeModel model)
		{
		}

		// Token: 0x17002996 RID: 10646
		// (get) Token: 0x060083BD RID: 33725 RVA: 0x001005F4 File Offset: 0x000FE7F4
		public Type ExpectedType
		{
			get
			{
				return Int64Serializer.expectedType;
			}
		}

		// Token: 0x17002997 RID: 10647
		// (get) Token: 0x060083BE RID: 33726 RVA: 0x0010060C File Offset: 0x000FE80C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002998 RID: 10648
		// (get) Token: 0x060083BF RID: 33727 RVA: 0x00100620 File Offset: 0x000FE820
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083C0 RID: 33728 RVA: 0x00100634 File Offset: 0x000FE834
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadInt64();
		}

		// Token: 0x060083C1 RID: 33729 RVA: 0x0010065B File Offset: 0x000FE85B
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteInt64((long)value, dest);
		}

		// Token: 0x040028EE RID: 10478
		private static readonly Type expectedType = typeof(long);
	}
}
