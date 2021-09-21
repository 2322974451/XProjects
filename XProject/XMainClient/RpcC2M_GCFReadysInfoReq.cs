using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001404 RID: 5124
	internal class RpcC2M_GCFReadysInfoReq : Rpc
	{
		// Token: 0x0600E514 RID: 58644 RVA: 0x0033C800 File Offset: 0x0033AA00
		public override uint GetRpcType()
		{
			return 19040U;
		}

		// Token: 0x0600E515 RID: 58645 RVA: 0x0033C817 File Offset: 0x0033AA17
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFReadyInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E516 RID: 58646 RVA: 0x0033C827 File Offset: 0x0033AA27
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFReadyInfoRes>(stream);
		}

		// Token: 0x0600E517 RID: 58647 RVA: 0x0033C836 File Offset: 0x0033AA36
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFReadysInfoReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E518 RID: 58648 RVA: 0x0033C852 File Offset: 0x0033AA52
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFReadysInfoReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400643F RID: 25663
		public GCFReadyInfoArg oArg = new GCFReadyInfoArg();

		// Token: 0x04006440 RID: 25664
		public GCFReadyInfoRes oRes = null;
	}
}
