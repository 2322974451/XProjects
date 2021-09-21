using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000860 RID: 2144
	internal sealed class DateTimeSerializer : IProtoSerializer
	{
		// Token: 0x1700297A RID: 10618
		// (get) Token: 0x06008378 RID: 33656 RVA: 0x000FF644 File Offset: 0x000FD844
		public Type ExpectedType
		{
			get
			{
				return DateTimeSerializer.expectedType;
			}
		}

		// Token: 0x1700297B RID: 10619
		// (get) Token: 0x06008379 RID: 33657 RVA: 0x000FF65C File Offset: 0x000FD85C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700297C RID: 10620
		// (get) Token: 0x0600837A RID: 33658 RVA: 0x000FF670 File Offset: 0x000FD870
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600837B RID: 33659 RVA: 0x0000311A File Offset: 0x0000131A
		public DateTimeSerializer(TypeModel model)
		{
		}

		// Token: 0x0600837C RID: 33660 RVA: 0x000FF684 File Offset: 0x000FD884
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return BclHelpers.ReadDateTime(source);
		}

		// Token: 0x0600837D RID: 33661 RVA: 0x000FF6AB File Offset: 0x000FD8AB
		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteDateTime((DateTime)value, dest);
		}

		// Token: 0x040028DF RID: 10463
		private static readonly Type expectedType = typeof(DateTime);
	}
}
