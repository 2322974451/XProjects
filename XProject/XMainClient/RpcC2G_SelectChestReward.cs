using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200101B RID: 4123
	internal class RpcC2G_SelectChestReward : Rpc
	{
		// Token: 0x0600D511 RID: 54545 RVA: 0x00322EC4 File Offset: 0x003210C4
		public override uint GetRpcType()
		{
			return 40987U;
		}

		// Token: 0x0600D512 RID: 54546 RVA: 0x00322EDB File Offset: 0x003210DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectChestArg>(stream, this.oArg);
		}

		// Token: 0x0600D513 RID: 54547 RVA: 0x00322EEB File Offset: 0x003210EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectChestRes>(stream);
		}

		// Token: 0x0600D514 RID: 54548 RVA: 0x00322EFA File Offset: 0x003210FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectChestReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D515 RID: 54549 RVA: 0x00322F16 File Offset: 0x00321116
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectChestReward.OnTimeout(this.oArg);
		}

		// Token: 0x0400610E RID: 24846
		public SelectChestArg oArg = new SelectChestArg();

		// Token: 0x0400610F RID: 24847
		public SelectChestRes oRes = null;
	}
}
