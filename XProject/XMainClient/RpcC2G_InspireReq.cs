using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F4 RID: 4852
	internal class RpcC2G_InspireReq : Rpc
	{
		// Token: 0x0600E0B9 RID: 57529 RVA: 0x003368B0 File Offset: 0x00334AB0
		public override uint GetRpcType()
		{
			return 54147U;
		}

		// Token: 0x0600E0BA RID: 57530 RVA: 0x003368C7 File Offset: 0x00334AC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InspireArg>(stream, this.oArg);
		}

		// Token: 0x0600E0BB RID: 57531 RVA: 0x003368D7 File Offset: 0x00334AD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InspireRes>(stream);
		}

		// Token: 0x0600E0BC RID: 57532 RVA: 0x003368E6 File Offset: 0x00334AE6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_InspireReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E0BD RID: 57533 RVA: 0x00336902 File Offset: 0x00334B02
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_InspireReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006368 RID: 25448
		public InspireArg oArg = new InspireArg();

		// Token: 0x04006369 RID: 25449
		public InspireRes oRes = new InspireRes();
	}
}
