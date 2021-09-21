using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000876 RID: 2166
	internal sealed class SingleSerializer : IProtoSerializer
	{
		// Token: 0x170029BC RID: 10684
		// (get) Token: 0x0600840F RID: 33807 RVA: 0x001016AC File Offset: 0x000FF8AC
		public Type ExpectedType
		{
			get
			{
				return SingleSerializer.expectedType;
			}
		}

		// Token: 0x06008410 RID: 33808 RVA: 0x0000311A File Offset: 0x0000131A
		public SingleSerializer(TypeModel model)
		{
		}

		// Token: 0x170029BD RID: 10685
		// (get) Token: 0x06008411 RID: 33809 RVA: 0x001016C4 File Offset: 0x000FF8C4
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029BE RID: 10686
		// (get) Token: 0x06008412 RID: 33810 RVA: 0x001016D8 File Offset: 0x000FF8D8
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008413 RID: 33811 RVA: 0x001016EC File Offset: 0x000FF8EC
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadSingle();
		}

		// Token: 0x06008414 RID: 33812 RVA: 0x00101713 File Offset: 0x000FF913
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteSingle((float)value, dest);
		}

		// Token: 0x0400290E RID: 10510
		private static readonly Type expectedType = typeof(float);
	}
}
