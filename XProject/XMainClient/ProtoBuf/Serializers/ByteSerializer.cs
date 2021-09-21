using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200085E RID: 2142
	internal sealed class ByteSerializer : IProtoSerializer
	{
		// Token: 0x17002976 RID: 10614
		// (get) Token: 0x0600836C RID: 33644 RVA: 0x000FF550 File Offset: 0x000FD750
		public Type ExpectedType
		{
			get
			{
				return ByteSerializer.expectedType;
			}
		}

		// Token: 0x0600836D RID: 33645 RVA: 0x0000311A File Offset: 0x0000131A
		public ByteSerializer(TypeModel model)
		{
		}

		// Token: 0x17002977 RID: 10615
		// (get) Token: 0x0600836E RID: 33646 RVA: 0x000FF568 File Offset: 0x000FD768
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002978 RID: 10616
		// (get) Token: 0x0600836F RID: 33647 RVA: 0x000FF57C File Offset: 0x000FD77C
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008370 RID: 33648 RVA: 0x000FF58F File Offset: 0x000FD78F
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteByte((byte)value, dest);
		}

		// Token: 0x06008371 RID: 33649 RVA: 0x000FF5A0 File Offset: 0x000FD7A0
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadByte();
		}

		// Token: 0x040028DD RID: 10461
		private static readonly Type expectedType = typeof(byte);
	}
}
