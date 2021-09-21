using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000881 RID: 2177
	internal sealed class UInt64Serializer : IProtoSerializer
	{
		// Token: 0x06008475 RID: 33909 RVA: 0x0000311A File Offset: 0x0000131A
		public UInt64Serializer(TypeModel model)
		{
		}

		// Token: 0x170029DF RID: 10719
		// (get) Token: 0x06008476 RID: 33910 RVA: 0x00102D64 File Offset: 0x00100F64
		public Type ExpectedType
		{
			get
			{
				return UInt64Serializer.expectedType;
			}
		}

		// Token: 0x170029E0 RID: 10720
		// (get) Token: 0x06008477 RID: 33911 RVA: 0x00102D7C File Offset: 0x00100F7C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029E1 RID: 10721
		// (get) Token: 0x06008478 RID: 33912 RVA: 0x00102D90 File Offset: 0x00100F90
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008479 RID: 33913 RVA: 0x00102DA4 File Offset: 0x00100FA4
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadUInt64();
		}

		// Token: 0x0600847A RID: 33914 RVA: 0x00102DCB File Offset: 0x00100FCB
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteUInt64((ulong)value, dest);
		}

		// Token: 0x0400292F RID: 10543
		private static readonly Type expectedType = typeof(ulong);
	}
}
