using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012DE RID: 4830
	internal class RpcC2M_PlantHarvest : Rpc
	{
		// Token: 0x0600E05D RID: 57437 RVA: 0x00335EA4 File Offset: 0x003340A4
		public override uint GetRpcType()
		{
			return 39568U;
		}

		// Token: 0x0600E05E RID: 57438 RVA: 0x00335EBB File Offset: 0x003340BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlantHarvestArg>(stream, this.oArg);
		}

		// Token: 0x0600E05F RID: 57439 RVA: 0x00335ECB File Offset: 0x003340CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlantHarvestRes>(stream);
		}

		// Token: 0x0600E060 RID: 57440 RVA: 0x00335EDA File Offset: 0x003340DA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PlantHarvest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E061 RID: 57441 RVA: 0x00335EF6 File Offset: 0x003340F6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PlantHarvest.OnTimeout(this.oArg);
		}

		// Token: 0x04006356 RID: 25430
		public PlantHarvestArg oArg = new PlantHarvestArg();

		// Token: 0x04006357 RID: 25431
		public PlantHarvestRes oRes = null;
	}
}
