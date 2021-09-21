using System;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200086B RID: 2155
	internal interface IProtoSerializer
	{
		// Token: 0x17002999 RID: 10649
		// (get) Token: 0x060083C3 RID: 33731
		Type ExpectedType { get; }

		// Token: 0x060083C4 RID: 33732
		void Write(object value, ProtoWriter dest);

		// Token: 0x060083C5 RID: 33733
		object Read(object value, ProtoReader source);

		// Token: 0x1700299A RID: 10650
		// (get) Token: 0x060083C6 RID: 33734
		bool RequiresOldValue { get; }

		// Token: 0x1700299B RID: 10651
		// (get) Token: 0x060083C7 RID: 33735
		bool ReturnsValue { get; }
	}
}
