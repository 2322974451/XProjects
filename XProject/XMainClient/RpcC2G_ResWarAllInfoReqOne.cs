using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200135F RID: 4959
	internal class RpcC2G_ResWarAllInfoReqOne : Rpc
	{
		// Token: 0x0600E270 RID: 57968 RVA: 0x00339038 File Offset: 0x00337238
		public override uint GetRpcType()
		{
			return 8828U;
		}

		// Token: 0x0600E271 RID: 57969 RVA: 0x0033904F File Offset: 0x0033724F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarArg>(stream, this.oArg);
		}

		// Token: 0x0600E272 RID: 57970 RVA: 0x0033905F File Offset: 0x0033725F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarRes>(stream);
		}

		// Token: 0x0600E273 RID: 57971 RVA: 0x0033906E File Offset: 0x0033726E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResWarAllInfoReqOne.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E274 RID: 57972 RVA: 0x0033908A File Offset: 0x0033728A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResWarAllInfoReqOne.OnTimeout(this.oArg);
		}

		// Token: 0x040063BD RID: 25533
		public ResWarArg oArg = new ResWarArg();

		// Token: 0x040063BE RID: 25534
		public ResWarRes oRes = new ResWarRes();
	}
}
