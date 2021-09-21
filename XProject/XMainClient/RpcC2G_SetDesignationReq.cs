using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010ED RID: 4333
	internal class RpcC2G_SetDesignationReq : Rpc
	{
		// Token: 0x0600D86E RID: 55406 RVA: 0x00329890 File Offset: 0x00327A90
		public override uint GetRpcType()
		{
			return 7673U;
		}

		// Token: 0x0600D86F RID: 55407 RVA: 0x003298A7 File Offset: 0x00327AA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetDesignationReq>(stream, this.oArg);
		}

		// Token: 0x0600D870 RID: 55408 RVA: 0x003298B7 File Offset: 0x00327AB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetDesignationRes>(stream);
		}

		// Token: 0x0600D871 RID: 55409 RVA: 0x003298C6 File Offset: 0x00327AC6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetDesignationReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D872 RID: 55410 RVA: 0x003298E2 File Offset: 0x00327AE2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetDesignationReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061D3 RID: 25043
		public SetDesignationReq oArg = new SetDesignationReq();

		// Token: 0x040061D4 RID: 25044
		public SetDesignationRes oRes = new SetDesignationRes();
	}
}
