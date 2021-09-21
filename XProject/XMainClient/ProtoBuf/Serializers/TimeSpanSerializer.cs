using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087C RID: 2172
	internal sealed class TimeSpanSerializer : IProtoSerializer
	{
		// Token: 0x06008445 RID: 33861 RVA: 0x0000311A File Offset: 0x0000131A
		public TimeSpanSerializer(TypeModel model)
		{
		}

		// Token: 0x170029CF RID: 10703
		// (get) Token: 0x06008446 RID: 33862 RVA: 0x00101F28 File Offset: 0x00100128
		public Type ExpectedType
		{
			get
			{
				return TimeSpanSerializer.expectedType;
			}
		}

		// Token: 0x170029D0 RID: 10704
		// (get) Token: 0x06008447 RID: 33863 RVA: 0x00101F40 File Offset: 0x00100140
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029D1 RID: 10705
		// (get) Token: 0x06008448 RID: 33864 RVA: 0x00101F54 File Offset: 0x00100154
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008449 RID: 33865 RVA: 0x00101F68 File Offset: 0x00100168
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return BclHelpers.ReadTimeSpan(source);
		}

		// Token: 0x0600844A RID: 33866 RVA: 0x00101F8F File Offset: 0x0010018F
		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteTimeSpan((TimeSpan)value, dest);
		}

		// Token: 0x0400291D RID: 10525
		private static readonly Type expectedType = typeof(TimeSpan);
	}
}
