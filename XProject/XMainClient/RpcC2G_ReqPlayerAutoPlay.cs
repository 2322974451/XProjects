using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010F9 RID: 4345
	internal class RpcC2G_ReqPlayerAutoPlay : Rpc
	{
		// Token: 0x0600D8A0 RID: 55456 RVA: 0x00329D90 File Offset: 0x00327F90
		public override uint GetRpcType()
		{
			return 3718U;
		}

		// Token: 0x0600D8A1 RID: 55457 RVA: 0x00329DA7 File Offset: 0x00327FA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqAutoPlay>(stream, this.oArg);
		}

		// Token: 0x0600D8A2 RID: 55458 RVA: 0x00329DB7 File Offset: 0x00327FB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RetAutoPlay>(stream);
		}

		// Token: 0x0600D8A3 RID: 55459 RVA: 0x00329DC6 File Offset: 0x00327FC6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqPlayerAutoPlay.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8A4 RID: 55460 RVA: 0x00329DE2 File Offset: 0x00327FE2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqPlayerAutoPlay.OnTimeout(this.oArg);
		}

		// Token: 0x040061DD RID: 25053
		public ReqAutoPlay oArg = new ReqAutoPlay();

		// Token: 0x040061DE RID: 25054
		public RetAutoPlay oRes = new RetAutoPlay();
	}
}
