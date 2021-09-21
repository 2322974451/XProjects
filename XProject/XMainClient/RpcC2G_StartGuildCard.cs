using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200107B RID: 4219
	internal class RpcC2G_StartGuildCard : Rpc
	{
		// Token: 0x0600D6A6 RID: 54950 RVA: 0x003266B4 File Offset: 0x003248B4
		public override uint GetRpcType()
		{
			return 35743U;
		}

		// Token: 0x0600D6A7 RID: 54951 RVA: 0x003266CB File Offset: 0x003248CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartGuildCardArg>(stream, this.oArg);
		}

		// Token: 0x0600D6A8 RID: 54952 RVA: 0x003266DB File Offset: 0x003248DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartGuildCardRes>(stream);
		}

		// Token: 0x0600D6A9 RID: 54953 RVA: 0x003266EA File Offset: 0x003248EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_StartGuildCard.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6AA RID: 54954 RVA: 0x00326706 File Offset: 0x00324906
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_StartGuildCard.OnTimeout(this.oArg);
		}

		// Token: 0x04006182 RID: 24962
		public StartGuildCardArg oArg = new StartGuildCardArg();

		// Token: 0x04006183 RID: 24963
		public StartGuildCardRes oRes = new StartGuildCardRes();
	}
}
