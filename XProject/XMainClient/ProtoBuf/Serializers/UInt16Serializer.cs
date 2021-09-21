using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087F RID: 2175
	internal class UInt16Serializer : IProtoSerializer
	{
		// Token: 0x06008467 RID: 33895 RVA: 0x0000311A File Offset: 0x0000131A
		public UInt16Serializer(TypeModel model)
		{
		}

		// Token: 0x170029D9 RID: 10713
		// (get) Token: 0x06008468 RID: 33896 RVA: 0x00102C54 File Offset: 0x00100E54
		public virtual Type ExpectedType
		{
			get
			{
				return UInt16Serializer.expectedType;
			}
		}

		// Token: 0x170029DA RID: 10714
		// (get) Token: 0x06008469 RID: 33897 RVA: 0x00102C6C File Offset: 0x00100E6C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029DB RID: 10715
		// (get) Token: 0x0600846A RID: 33898 RVA: 0x00102C80 File Offset: 0x00100E80
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600846B RID: 33899 RVA: 0x00102C94 File Offset: 0x00100E94
		public virtual object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadUInt16();
		}

		// Token: 0x0600846C RID: 33900 RVA: 0x00102CBB File Offset: 0x00100EBB
		public virtual void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteUInt16((ushort)value, dest);
		}

		// Token: 0x0400292D RID: 10541
		private static readonly Type expectedType = typeof(ushort);
	}
}
