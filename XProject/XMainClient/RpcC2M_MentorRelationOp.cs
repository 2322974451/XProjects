using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013DA RID: 5082
	internal class RpcC2M_MentorRelationOp : Rpc
	{
		// Token: 0x0600E466 RID: 58470 RVA: 0x0033BB38 File Offset: 0x00339D38
		public override uint GetRpcType()
		{
			return 10644U;
		}

		// Token: 0x0600E467 RID: 58471 RVA: 0x0033BB4F File Offset: 0x00339D4F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MentorRelationOpArg>(stream, this.oArg);
		}

		// Token: 0x0600E468 RID: 58472 RVA: 0x0033BB5F File Offset: 0x00339D5F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MentorRelationOpRes>(stream);
		}

		// Token: 0x0600E469 RID: 58473 RVA: 0x0033BB6E File Offset: 0x00339D6E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MentorRelationOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E46A RID: 58474 RVA: 0x0033BB8A File Offset: 0x00339D8A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MentorRelationOp.OnTimeout(this.oArg);
		}

		// Token: 0x0400641D RID: 25629
		public MentorRelationOpArg oArg = new MentorRelationOpArg();

		// Token: 0x0400641E RID: 25630
		public MentorRelationOpRes oRes = null;
	}
}
