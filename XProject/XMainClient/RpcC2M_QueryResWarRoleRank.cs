using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001373 RID: 4979
	internal class RpcC2M_QueryResWarRoleRank : Rpc
	{
		// Token: 0x0600E2C4 RID: 58052 RVA: 0x003398BC File Offset: 0x00337ABC
		public override uint GetRpcType()
		{
			return 27001U;
		}

		// Token: 0x0600E2C5 RID: 58053 RVA: 0x003398D3 File Offset: 0x00337AD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarRoleRankArg>(stream, this.oArg);
		}

		// Token: 0x0600E2C6 RID: 58054 RVA: 0x003398E3 File Offset: 0x00337AE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarRoleRankRes>(stream);
		}

		// Token: 0x0600E2C7 RID: 58055 RVA: 0x003398F2 File Offset: 0x00337AF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryResWarRoleRank.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2C8 RID: 58056 RVA: 0x0033990E File Offset: 0x00337B0E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryResWarRoleRank.OnTimeout(this.oArg);
		}

		// Token: 0x040063CE RID: 25550
		public ResWarRoleRankArg oArg = new ResWarRoleRankArg();

		// Token: 0x040063CF RID: 25551
		public ResWarRoleRankRes oRes = null;
	}
}
