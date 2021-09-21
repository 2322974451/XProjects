using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001284 RID: 4740
	internal class RpcC2G_SmeltItem : Rpc
	{
		// Token: 0x0600DEE9 RID: 57065 RVA: 0x00333D48 File Offset: 0x00331F48
		public override uint GetRpcType()
		{
			return 10028U;
		}

		// Token: 0x0600DEEA RID: 57066 RVA: 0x00333D5F File Offset: 0x00331F5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SmeltItemArg>(stream, this.oArg);
		}

		// Token: 0x0600DEEB RID: 57067 RVA: 0x00333D6F File Offset: 0x00331F6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SmeltItemRes>(stream);
		}

		// Token: 0x0600DEEC RID: 57068 RVA: 0x00333D7E File Offset: 0x00331F7E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SmeltItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DEED RID: 57069 RVA: 0x00333D9A File Offset: 0x00331F9A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SmeltItem.OnTimeout(this.oArg);
		}

		// Token: 0x0400630D RID: 25357
		public SmeltItemArg oArg = new SmeltItemArg();

		// Token: 0x0400630E RID: 25358
		public SmeltItemRes oRes = new SmeltItemRes();
	}
}
