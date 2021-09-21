using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010DC RID: 4316
	internal class RpcC2G_PetOperation : Rpc
	{
		// Token: 0x0600D827 RID: 55335 RVA: 0x003291C0 File Offset: 0x003273C0
		public override uint GetRpcType()
		{
			return 28857U;
		}

		// Token: 0x0600D828 RID: 55336 RVA: 0x003291D7 File Offset: 0x003273D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600D829 RID: 55337 RVA: 0x003291E7 File Offset: 0x003273E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PetOperationRes>(stream);
		}

		// Token: 0x0600D82A RID: 55338 RVA: 0x003291F6 File Offset: 0x003273F6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PetOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D82B RID: 55339 RVA: 0x00329212 File Offset: 0x00327412
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PetOperation.OnTimeout(this.oArg);
		}

		// Token: 0x040061C5 RID: 25029
		public PetOperationArg oArg = new PetOperationArg();

		// Token: 0x040061C6 RID: 25030
		public PetOperationRes oRes = new PetOperationRes();
	}
}
