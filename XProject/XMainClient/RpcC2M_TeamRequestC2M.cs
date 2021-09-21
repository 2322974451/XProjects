using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011ED RID: 4589
	internal class RpcC2M_TeamRequestC2M : Rpc
	{
		// Token: 0x0600DC7B RID: 56443 RVA: 0x003306B0 File Offset: 0x0032E8B0
		public override uint GetRpcType()
		{
			return 30954U;
		}

		// Token: 0x0600DC7C RID: 56444 RVA: 0x003306C7 File Offset: 0x0032E8C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamOPArg>(stream, this.oArg);
		}

		// Token: 0x0600DC7D RID: 56445 RVA: 0x003306D7 File Offset: 0x0032E8D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TeamOPRes>(stream);
		}

		// Token: 0x0600DC7E RID: 56446 RVA: 0x003306E6 File Offset: 0x0032E8E6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TeamRequestC2M.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC7F RID: 56447 RVA: 0x00330702 File Offset: 0x0032E902
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TeamRequestC2M.OnTimeout(this.oArg);
		}

		// Token: 0x04006294 RID: 25236
		public TeamOPArg oArg = new TeamOPArg();

		// Token: 0x04006295 RID: 25237
		public TeamOPRes oRes;
	}
}
