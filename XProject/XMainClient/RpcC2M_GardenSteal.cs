using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200133B RID: 4923
	internal class RpcC2M_GardenSteal : Rpc
	{
		// Token: 0x0600E1DC RID: 57820 RVA: 0x0033839C File Offset: 0x0033659C
		public override uint GetRpcType()
		{
			return 12696U;
		}

		// Token: 0x0600E1DD RID: 57821 RVA: 0x003383B3 File Offset: 0x003365B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenStealArg>(stream, this.oArg);
		}

		// Token: 0x0600E1DE RID: 57822 RVA: 0x003383C3 File Offset: 0x003365C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenStealRes>(stream);
		}

		// Token: 0x0600E1DF RID: 57823 RVA: 0x003383D2 File Offset: 0x003365D2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenSteal.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1E0 RID: 57824 RVA: 0x003383EE File Offset: 0x003365EE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenSteal.OnTimeout(this.oArg);
		}

		// Token: 0x040063A0 RID: 25504
		public GardenStealArg oArg = new GardenStealArg();

		// Token: 0x040063A1 RID: 25505
		public GardenStealRes oRes = null;
	}
}
