using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001196 RID: 4502
	internal class RpcC2M_chat : Rpc
	{
		// Token: 0x0600DB1E RID: 56094 RVA: 0x0032E884 File Offset: 0x0032CA84
		public override uint GetRpcType()
		{
			return 56705U;
		}

		// Token: 0x0600DB1F RID: 56095 RVA: 0x0032E89B File Offset: 0x0032CA9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatArg>(stream, this.oArg);
		}

		// Token: 0x0600DB20 RID: 56096 RVA: 0x0032E8AB File Offset: 0x0032CAAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChatRes>(stream);
		}

		// Token: 0x0600DB21 RID: 56097 RVA: 0x0032E8BA File Offset: 0x0032CABA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_chat.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB22 RID: 56098 RVA: 0x0032E8D6 File Offset: 0x0032CAD6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_chat.OnTimeout(this.oArg);
		}

		// Token: 0x04006254 RID: 25172
		public ChatArg oArg = new ChatArg();

		// Token: 0x04006255 RID: 25173
		public ChatRes oRes = null;
	}
}
