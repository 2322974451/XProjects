using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001568 RID: 5480
	internal class RpcC2M_GetMobaBattleInfo : Rpc
	{
		// Token: 0x0600EAB7 RID: 60087 RVA: 0x00344B98 File Offset: 0x00342D98
		public override uint GetRpcType()
		{
			return 64051U;
		}

		// Token: 0x0600EAB8 RID: 60088 RVA: 0x00344BAF File Offset: 0x00342DAF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EAB9 RID: 60089 RVA: 0x00344BBF File Offset: 0x00342DBF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleInfoRes>(stream);
		}

		// Token: 0x0600EABA RID: 60090 RVA: 0x00344BCE File Offset: 0x00342DCE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EABB RID: 60091 RVA: 0x00344BEA File Offset: 0x00342DEA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006555 RID: 25941
		public GetMobaBattleInfoArg oArg = new GetMobaBattleInfoArg();

		// Token: 0x04006556 RID: 25942
		public GetMobaBattleInfoRes oRes = null;
	}
}
