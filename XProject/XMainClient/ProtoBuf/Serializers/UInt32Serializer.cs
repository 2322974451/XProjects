using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000880 RID: 2176
	internal sealed class UInt32Serializer : IProtoSerializer
	{
		// Token: 0x0600846E RID: 33902 RVA: 0x0000311A File Offset: 0x0000131A
		public UInt32Serializer(TypeModel model)
		{
		}

		// Token: 0x170029DC RID: 10716
		// (get) Token: 0x0600846F RID: 33903 RVA: 0x00102CDC File Offset: 0x00100EDC
		public Type ExpectedType
		{
			get
			{
				return UInt32Serializer.expectedType;
			}
		}

		// Token: 0x170029DD RID: 10717
		// (get) Token: 0x06008470 RID: 33904 RVA: 0x00102CF4 File Offset: 0x00100EF4
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029DE RID: 10718
		// (get) Token: 0x06008471 RID: 33905 RVA: 0x00102D08 File Offset: 0x00100F08
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008472 RID: 33906 RVA: 0x00102D1C File Offset: 0x00100F1C
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadUInt32();
		}

		// Token: 0x06008473 RID: 33907 RVA: 0x00102D43 File Offset: 0x00100F43
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteUInt32((uint)value, dest);
		}

		// Token: 0x0400292E RID: 10542
		private static readonly Type expectedType = typeof(uint);
	}
}
