using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200086C RID: 2156
	internal interface IProtoTypeSerializer : IProtoSerializer
	{
		// Token: 0x060083C8 RID: 33736
		bool HasCallbacks(TypeModel.CallbackType callbackType);

		// Token: 0x060083C9 RID: 33737
		bool CanCreateInstance();

		// Token: 0x060083CA RID: 33738
		object CreateInstance(ProtoReader source);

		// Token: 0x060083CB RID: 33739
		void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context);
	}
}
