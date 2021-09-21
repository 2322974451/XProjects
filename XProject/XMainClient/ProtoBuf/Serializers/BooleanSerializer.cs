using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200085D RID: 2141
	internal sealed class BooleanSerializer : IProtoSerializer
	{
		// Token: 0x06008365 RID: 33637 RVA: 0x0000311A File Offset: 0x0000131A
		public BooleanSerializer(TypeModel model)
		{
		}

		// Token: 0x17002973 RID: 10611
		// (get) Token: 0x06008366 RID: 33638 RVA: 0x000FF4C8 File Offset: 0x000FD6C8
		public Type ExpectedType
		{
			get
			{
				return BooleanSerializer.expectedType;
			}
		}

		// Token: 0x06008367 RID: 33639 RVA: 0x000FF4DF File Offset: 0x000FD6DF
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteBoolean((bool)value, dest);
		}

		// Token: 0x06008368 RID: 33640 RVA: 0x000FF4F0 File Offset: 0x000FD6F0
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadBoolean();
		}

		// Token: 0x17002974 RID: 10612
		// (get) Token: 0x06008369 RID: 33641 RVA: 0x000FF518 File Offset: 0x000FD718
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002975 RID: 10613
		// (get) Token: 0x0600836A RID: 33642 RVA: 0x000FF52C File Offset: 0x000FD72C
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x040028DC RID: 10460
		private static readonly Type expectedType = typeof(bool);
	}
}
