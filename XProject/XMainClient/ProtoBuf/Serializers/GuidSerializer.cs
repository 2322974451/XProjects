using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000866 RID: 2150
	internal sealed class GuidSerializer : IProtoSerializer
	{
		// Token: 0x060083A2 RID: 33698 RVA: 0x0000311A File Offset: 0x0000131A
		public GuidSerializer(TypeModel model)
		{
		}

		// Token: 0x1700298C RID: 10636
		// (get) Token: 0x060083A3 RID: 33699 RVA: 0x000FFEB4 File Offset: 0x000FE0B4
		public Type ExpectedType
		{
			get
			{
				return GuidSerializer.expectedType;
			}
		}

		// Token: 0x1700298D RID: 10637
		// (get) Token: 0x060083A4 RID: 33700 RVA: 0x000FFECC File Offset: 0x000FE0CC
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700298E RID: 10638
		// (get) Token: 0x060083A5 RID: 33701 RVA: 0x000FFEE0 File Offset: 0x000FE0E0
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083A6 RID: 33702 RVA: 0x000FFEF3 File Offset: 0x000FE0F3
		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteGuid((Guid)value, dest);
		}

		// Token: 0x060083A7 RID: 33703 RVA: 0x000FFF04 File Offset: 0x000FE104
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return BclHelpers.ReadGuid(source);
		}

		// Token: 0x040028E7 RID: 10471
		private static readonly Type expectedType = typeof(Guid);
	}
}
