using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000863 RID: 2147
	internal sealed class DoubleSerializer : IProtoSerializer
	{
		// Token: 0x0600838C RID: 33676 RVA: 0x0000311A File Offset: 0x0000131A
		public DoubleSerializer(TypeModel model)
		{
		}

		// Token: 0x17002983 RID: 10627
		// (get) Token: 0x0600838D RID: 33677 RVA: 0x000FF868 File Offset: 0x000FDA68
		public Type ExpectedType
		{
			get
			{
				return DoubleSerializer.expectedType;
			}
		}

		// Token: 0x17002984 RID: 10628
		// (get) Token: 0x0600838E RID: 33678 RVA: 0x000FF880 File Offset: 0x000FDA80
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002985 RID: 10629
		// (get) Token: 0x0600838F RID: 33679 RVA: 0x000FF894 File Offset: 0x000FDA94
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008390 RID: 33680 RVA: 0x000FF8A8 File Offset: 0x000FDAA8
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadDouble();
		}

		// Token: 0x06008391 RID: 33681 RVA: 0x000FF8CF File Offset: 0x000FDACF
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteDouble((double)value, dest);
		}

		// Token: 0x040028E2 RID: 10466
		private static readonly Type expectedType = typeof(double);
	}
}
