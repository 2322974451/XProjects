using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200151C RID: 5404
	internal class RpcC2G_ReturnSmeltStone : Rpc
	{
		// Token: 0x0600E98A RID: 59786 RVA: 0x00342E84 File Offset: 0x00341084
		public override uint GetRpcType()
		{
			return 16978U;
		}

		// Token: 0x0600E98B RID: 59787 RVA: 0x00342E9B File Offset: 0x0034109B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReturnSmeltStoneArg>(stream, this.oArg);
		}

		// Token: 0x0600E98C RID: 59788 RVA: 0x00342EAB File Offset: 0x003410AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReturnSmeltStoneRes>(stream);
		}

		// Token: 0x0600E98D RID: 59789 RVA: 0x00342EBA File Offset: 0x003410BA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReturnSmeltStone.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E98E RID: 59790 RVA: 0x00342ED6 File Offset: 0x003410D6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReturnSmeltStone.OnTimeout(this.oArg);
		}

		// Token: 0x04006517 RID: 25879
		public ReturnSmeltStoneArg oArg = new ReturnSmeltStoneArg();

		// Token: 0x04006518 RID: 25880
		public ReturnSmeltStoneRes oRes = null;
	}
}
