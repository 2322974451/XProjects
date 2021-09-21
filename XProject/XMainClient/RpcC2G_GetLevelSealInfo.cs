using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001100 RID: 4352
	internal class RpcC2G_GetLevelSealInfo : Rpc
	{
		// Token: 0x0600D8BE RID: 55486 RVA: 0x00329F90 File Offset: 0x00328190
		public override uint GetRpcType()
		{
			return 10497U;
		}

		// Token: 0x0600D8BF RID: 55487 RVA: 0x00329FA7 File Offset: 0x003281A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLevelSealInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600D8C0 RID: 55488 RVA: 0x00329FB7 File Offset: 0x003281B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLevelSealInfoRes>(stream);
		}

		// Token: 0x0600D8C1 RID: 55489 RVA: 0x00329FC6 File Offset: 0x003281C6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLevelSealInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8C2 RID: 55490 RVA: 0x00329FE2 File Offset: 0x003281E2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLevelSealInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040061E2 RID: 25058
		public GetLevelSealInfoArg oArg = new GetLevelSealInfoArg();

		// Token: 0x040061E3 RID: 25059
		public GetLevelSealInfoRes oRes = new GetLevelSealInfoRes();
	}
}
