using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000868 RID: 2152
	internal sealed class Int16Serializer : IProtoSerializer
	{
		// Token: 0x060083AE RID: 33710 RVA: 0x0000311A File Offset: 0x0000131A
		public Int16Serializer(TypeModel model)
		{
		}

		// Token: 0x17002990 RID: 10640
		// (get) Token: 0x060083AF RID: 33711 RVA: 0x001004E4 File Offset: 0x000FE6E4
		public Type ExpectedType
		{
			get
			{
				return Int16Serializer.expectedType;
			}
		}

		// Token: 0x17002991 RID: 10641
		// (get) Token: 0x060083B0 RID: 33712 RVA: 0x001004FC File Offset: 0x000FE6FC
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002992 RID: 10642
		// (get) Token: 0x060083B1 RID: 33713 RVA: 0x00100510 File Offset: 0x000FE710
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083B2 RID: 33714 RVA: 0x00100524 File Offset: 0x000FE724
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadInt16();
		}

		// Token: 0x060083B3 RID: 33715 RVA: 0x0010054B File Offset: 0x000FE74B
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteInt16((short)value, dest);
		}

		// Token: 0x040028EC RID: 10476
		private static readonly Type expectedType = typeof(short);
	}
}
