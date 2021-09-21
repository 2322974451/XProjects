using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001362 RID: 4962
	internal class RpcC2M_StartResWarPVE : Rpc
	{
		// Token: 0x0600E27B RID: 57979 RVA: 0x003391E4 File Offset: 0x003373E4
		public override uint GetRpcType()
		{
			return 35398U;
		}

		// Token: 0x0600E27C RID: 57980 RVA: 0x003391FB File Offset: 0x003373FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarPVEArg>(stream, this.oArg);
		}

		// Token: 0x0600E27D RID: 57981 RVA: 0x0033920B File Offset: 0x0033740B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarPVERes>(stream);
		}

		// Token: 0x0600E27E RID: 57982 RVA: 0x0033921A File Offset: 0x0033741A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartResWarPVE.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E27F RID: 57983 RVA: 0x00339236 File Offset: 0x00337436
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartResWarPVE.OnTimeout(this.oArg);
		}

		// Token: 0x040063BF RID: 25535
		public ResWarPVEArg oArg = new ResWarPVEArg();

		// Token: 0x040063C0 RID: 25536
		public ResWarPVERes oRes = null;
	}
}
