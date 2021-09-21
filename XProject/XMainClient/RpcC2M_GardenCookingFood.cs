using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012E4 RID: 4836
	internal class RpcC2M_GardenCookingFood : Rpc
	{
		// Token: 0x0600E078 RID: 57464 RVA: 0x003361B8 File Offset: 0x003343B8
		public override uint GetRpcType()
		{
			return 31406U;
		}

		// Token: 0x0600E079 RID: 57465 RVA: 0x003361CF File Offset: 0x003343CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenCookingFoodArg>(stream, this.oArg);
		}

		// Token: 0x0600E07A RID: 57466 RVA: 0x003361DF File Offset: 0x003343DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenCookingFoodRes>(stream);
		}

		// Token: 0x0600E07B RID: 57467 RVA: 0x003361EE File Offset: 0x003343EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenCookingFood.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E07C RID: 57468 RVA: 0x0033620A File Offset: 0x0033440A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenCookingFood.OnTimeout(this.oArg);
		}

		// Token: 0x0400635C RID: 25436
		public GardenCookingFoodArg oArg = new GardenCookingFoodArg();

		// Token: 0x0400635D RID: 25437
		public GardenCookingFoodRes oRes = null;
	}
}
