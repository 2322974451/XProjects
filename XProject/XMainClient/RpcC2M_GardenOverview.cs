using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001325 RID: 4901
	internal class RpcC2M_GardenOverview : Rpc
	{
		// Token: 0x0600E183 RID: 57731 RVA: 0x00337B04 File Offset: 0x00335D04
		public override uint GetRpcType()
		{
			return 20766U;
		}

		// Token: 0x0600E184 RID: 57732 RVA: 0x00337B1B File Offset: 0x00335D1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenOverviewArg>(stream, this.oArg);
		}

		// Token: 0x0600E185 RID: 57733 RVA: 0x00337B2B File Offset: 0x00335D2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenOverviewRes>(stream);
		}

		// Token: 0x0600E186 RID: 57734 RVA: 0x00337B3A File Offset: 0x00335D3A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenOverview.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E187 RID: 57735 RVA: 0x00337B56 File Offset: 0x00335D56
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenOverview.OnTimeout(this.oArg);
		}

		// Token: 0x0400638F RID: 25487
		public GardenOverviewArg oArg = new GardenOverviewArg();

		// Token: 0x04006390 RID: 25488
		public GardenOverviewRes oRes = null;
	}
}
