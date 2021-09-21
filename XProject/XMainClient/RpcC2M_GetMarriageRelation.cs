using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200159A RID: 5530
	internal class RpcC2M_GetMarriageRelation : Rpc
	{
		// Token: 0x0600EB8E RID: 60302 RVA: 0x00345F4C File Offset: 0x0034414C
		public override uint GetRpcType()
		{
			return 13460U;
		}

		// Token: 0x0600EB8F RID: 60303 RVA: 0x00345F63 File Offset: 0x00344163
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriageRelationArg>(stream, this.oArg);
		}

		// Token: 0x0600EB90 RID: 60304 RVA: 0x00345F73 File Offset: 0x00344173
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriageRelationRes>(stream);
		}

		// Token: 0x0600EB91 RID: 60305 RVA: 0x00345F82 File Offset: 0x00344182
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriageRelation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB92 RID: 60306 RVA: 0x00345F9E File Offset: 0x0034419E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriageRelation.OnTimeout(this.oArg);
		}

		// Token: 0x04006582 RID: 25986
		public GetMarriageRelationArg oArg = new GetMarriageRelationArg();

		// Token: 0x04006583 RID: 25987
		public GetMarriageRelationRes oRes = null;
	}
}
