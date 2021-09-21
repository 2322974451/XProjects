using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001071 RID: 4209
	internal class RpcC2G_ShowFlowerPage : Rpc
	{
		// Token: 0x0600D67D RID: 54909 RVA: 0x00326330 File Offset: 0x00324530
		public override uint GetRpcType()
		{
			return 47831U;
		}

		// Token: 0x0600D67E RID: 54910 RVA: 0x00326347 File Offset: 0x00324547
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShowFlowerPageArg>(stream, this.oArg);
		}

		// Token: 0x0600D67F RID: 54911 RVA: 0x00326357 File Offset: 0x00324557
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ShowFlowerPageRes>(stream);
		}

		// Token: 0x0600D680 RID: 54912 RVA: 0x00326366 File Offset: 0x00324566
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ShowFlowerPage.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D681 RID: 54913 RVA: 0x00326382 File Offset: 0x00324582
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ShowFlowerPage.OnTimeout(this.oArg);
		}

		// Token: 0x0400617A RID: 24954
		public ShowFlowerPageArg oArg = new ShowFlowerPageArg();

		// Token: 0x0400617B RID: 24955
		public ShowFlowerPageRes oRes = new ShowFlowerPageRes();
	}
}
