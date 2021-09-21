using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001313 RID: 4883
	internal class RpcC2M_GuildUnBindGroup : Rpc
	{
		// Token: 0x0600E13A RID: 57658 RVA: 0x003373AC File Offset: 0x003355AC
		public override uint GetRpcType()
		{
			return 28516U;
		}

		// Token: 0x0600E13B RID: 57659 RVA: 0x003373C3 File Offset: 0x003355C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildUnBindGroupReq>(stream, this.oArg);
		}

		// Token: 0x0600E13C RID: 57660 RVA: 0x003373D3 File Offset: 0x003355D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildUnBindGroupRes>(stream);
		}

		// Token: 0x0600E13D RID: 57661 RVA: 0x003373E2 File Offset: 0x003355E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildUnBindGroup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E13E RID: 57662 RVA: 0x003373FE File Offset: 0x003355FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildUnBindGroup.OnTimeout(this.oArg);
		}

		// Token: 0x04006381 RID: 25473
		public GuildUnBindGroupReq oArg = new GuildUnBindGroupReq();

		// Token: 0x04006382 RID: 25474
		public GuildUnBindGroupRes oRes = null;
	}
}
