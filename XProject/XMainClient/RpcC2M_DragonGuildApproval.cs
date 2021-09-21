using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200162E RID: 5678
	internal class RpcC2M_DragonGuildApproval : Rpc
	{
		// Token: 0x0600EDF5 RID: 60917 RVA: 0x00349178 File Offset: 0x00347378
		public override uint GetRpcType()
		{
			return 4753U;
		}

		// Token: 0x0600EDF6 RID: 60918 RVA: 0x0034918F File Offset: 0x0034738F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildApprovalArg>(stream, this.oArg);
		}

		// Token: 0x0600EDF7 RID: 60919 RVA: 0x0034919F File Offset: 0x0034739F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildApprovalRes>(stream);
		}

		// Token: 0x0600EDF8 RID: 60920 RVA: 0x003491AE File Offset: 0x003473AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildApproval.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDF9 RID: 60921 RVA: 0x003491CA File Offset: 0x003473CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildApproval.OnTimeout(this.oArg);
		}

		// Token: 0x040065F9 RID: 26105
		public DragonGuildApprovalArg oArg = new DragonGuildApprovalArg();

		// Token: 0x040065FA RID: 26106
		public DragonGuildApprovalRes oRes = null;
	}
}
