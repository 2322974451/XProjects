using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000875 RID: 2165
	internal sealed class SByteSerializer : IProtoSerializer
	{
		// Token: 0x06008408 RID: 33800 RVA: 0x0000311A File Offset: 0x0000131A
		public SByteSerializer(TypeModel model)
		{
		}

		// Token: 0x170029B9 RID: 10681
		// (get) Token: 0x06008409 RID: 33801 RVA: 0x00101624 File Offset: 0x000FF824
		public Type ExpectedType
		{
			get
			{
				return SByteSerializer.expectedType;
			}
		}

		// Token: 0x170029BA RID: 10682
		// (get) Token: 0x0600840A RID: 33802 RVA: 0x0010163C File Offset: 0x000FF83C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029BB RID: 10683
		// (get) Token: 0x0600840B RID: 33803 RVA: 0x00101650 File Offset: 0x000FF850
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600840C RID: 33804 RVA: 0x00101664 File Offset: 0x000FF864
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadSByte();
		}

		// Token: 0x0600840D RID: 33805 RVA: 0x0010168B File Offset: 0x000FF88B
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteSByte((sbyte)value, dest);
		}

		// Token: 0x0400290D RID: 10509
		private static readonly Type expectedType = typeof(sbyte);
	}
}
