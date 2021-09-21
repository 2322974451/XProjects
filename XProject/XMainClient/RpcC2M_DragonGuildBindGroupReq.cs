using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001648 RID: 5704
	internal class RpcC2M_DragonGuildBindGroupReq : Rpc
	{
		// Token: 0x0600EE68 RID: 61032 RVA: 0x00349B84 File Offset: 0x00347D84
		public override uint GetRpcType()
		{
			return 34774U;
		}

		// Token: 0x0600EE69 RID: 61033 RVA: 0x00349B9B File Offset: 0x00347D9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildBindReq>(stream, this.oArg);
		}

		// Token: 0x0600EE6A RID: 61034 RVA: 0x00349BAB File Offset: 0x00347DAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildBindRes>(stream);
		}

		// Token: 0x0600EE6B RID: 61035 RVA: 0x00349BBA File Offset: 0x00347DBA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildBindGroupReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE6C RID: 61036 RVA: 0x00349BD6 File Offset: 0x00347DD6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildBindGroupReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006612 RID: 26130
		public DragonGuildBindReq oArg = new DragonGuildBindReq();

		// Token: 0x04006613 RID: 26131
		public DragonGuildBindRes oRes = null;
	}
}
