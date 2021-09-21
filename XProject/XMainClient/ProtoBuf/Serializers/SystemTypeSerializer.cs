using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087A RID: 2170
	internal sealed class SystemTypeSerializer : IProtoSerializer
	{
		// Token: 0x06008433 RID: 33843 RVA: 0x0000311A File Offset: 0x0000131A
		public SystemTypeSerializer(TypeModel model)
		{
		}

		// Token: 0x170029C8 RID: 10696
		// (get) Token: 0x06008434 RID: 33844 RVA: 0x00101CD0 File Offset: 0x000FFED0
		public Type ExpectedType
		{
			get
			{
				return SystemTypeSerializer.expectedType;
			}
		}

		// Token: 0x06008435 RID: 33845 RVA: 0x00101CE7 File Offset: 0x000FFEE7
		void IProtoSerializer.Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteType((Type)value, dest);
		}

		// Token: 0x06008436 RID: 33846 RVA: 0x00101CF8 File Offset: 0x000FFEF8
		object IProtoSerializer.Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadType();
		}

		// Token: 0x170029C9 RID: 10697
		// (get) Token: 0x06008437 RID: 33847 RVA: 0x00101D1C File Offset: 0x000FFF1C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029CA RID: 10698
		// (get) Token: 0x06008438 RID: 33848 RVA: 0x00101D30 File Offset: 0x000FFF30
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x04002919 RID: 10521
		private static readonly Type expectedType = typeof(Type);
	}
}
