using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001293 RID: 4755
	internal class RpcC2M_FetchGuildApp : Rpc
	{
		// Token: 0x0600DF2B RID: 57131 RVA: 0x00334264 File Offset: 0x00332464
		public override uint GetRpcType()
		{
			return 3668U;
		}

		// Token: 0x0600DF2C RID: 57132 RVA: 0x0033427B File Offset: 0x0033247B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchGAPPArg>(stream, this.oArg);
		}

		// Token: 0x0600DF2D RID: 57133 RVA: 0x0033428B File Offset: 0x0033248B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchGAPPRes>(stream);
		}

		// Token: 0x0600DF2E RID: 57134 RVA: 0x0033429A File Offset: 0x0033249A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchGuildApp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF2F RID: 57135 RVA: 0x003342B6 File Offset: 0x003324B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchGuildApp.OnTimeout(this.oArg);
		}

		// Token: 0x0400631B RID: 25371
		public FetchGAPPArg oArg = new FetchGAPPArg();

		// Token: 0x0400631C RID: 25372
		public FetchGAPPRes oRes = null;
	}
}
