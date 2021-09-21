using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000869 RID: 2153
	internal sealed class Int32Serializer : IProtoSerializer
	{
		// Token: 0x060083B5 RID: 33717 RVA: 0x0000311A File Offset: 0x0000131A
		public Int32Serializer(TypeModel model)
		{
		}

		// Token: 0x17002993 RID: 10643
		// (get) Token: 0x060083B6 RID: 33718 RVA: 0x0010056C File Offset: 0x000FE76C
		public Type ExpectedType
		{
			get
			{
				return Int32Serializer.expectedType;
			}
		}

		// Token: 0x17002994 RID: 10644
		// (get) Token: 0x060083B7 RID: 33719 RVA: 0x00100584 File Offset: 0x000FE784
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002995 RID: 10645
		// (get) Token: 0x060083B8 RID: 33720 RVA: 0x00100598 File Offset: 0x000FE798
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083B9 RID: 33721 RVA: 0x001005AC File Offset: 0x000FE7AC
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadInt32();
		}

		// Token: 0x060083BA RID: 33722 RVA: 0x001005D3 File Offset: 0x000FE7D3
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteInt32((int)value, dest);
		}

		// Token: 0x040028ED RID: 10477
		private static readonly Type expectedType = typeof(int);
	}
}
