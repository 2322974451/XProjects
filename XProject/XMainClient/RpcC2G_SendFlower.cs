using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001073 RID: 4211
	internal class RpcC2G_SendFlower : Rpc
	{
		// Token: 0x0600D686 RID: 54918 RVA: 0x003263B4 File Offset: 0x003245B4
		public override uint GetRpcType()
		{
			return 16310U;
		}

		// Token: 0x0600D687 RID: 54919 RVA: 0x003263CB File Offset: 0x003245CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendFlowerArg>(stream, this.oArg);
		}

		// Token: 0x0600D688 RID: 54920 RVA: 0x003263DB File Offset: 0x003245DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendFlowerRes>(stream);
		}

		// Token: 0x0600D689 RID: 54921 RVA: 0x003263EA File Offset: 0x003245EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SendFlower.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D68A RID: 54922 RVA: 0x00326406 File Offset: 0x00324606
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SendFlower.OnTimeout(this.oArg);
		}

		// Token: 0x0400617C RID: 24956
		public SendFlowerArg oArg = new SendFlowerArg();

		// Token: 0x0400617D RID: 24957
		public SendFlowerRes oRes = new SendFlowerRes();
	}
}
