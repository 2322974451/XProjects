using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001399 RID: 5017
	internal class RpcC2M_AddGuildInherit : Rpc
	{
		// Token: 0x0600E35E RID: 58206 RVA: 0x0033A440 File Offset: 0x00338640
		public override uint GetRpcType()
		{
			return 15845U;
		}

		// Token: 0x0600E35F RID: 58207 RVA: 0x0033A457 File Offset: 0x00338657
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddGuildInheritArg>(stream, this.oArg);
		}

		// Token: 0x0600E360 RID: 58208 RVA: 0x0033A467 File Offset: 0x00338667
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddGuildInheritRes>(stream);
		}

		// Token: 0x0600E361 RID: 58209 RVA: 0x0033A476 File Offset: 0x00338676
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddGuildInherit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E362 RID: 58210 RVA: 0x0033A492 File Offset: 0x00338692
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddGuildInherit.OnTimeout(this.oArg);
		}

		// Token: 0x040063EB RID: 25579
		public AddGuildInheritArg oArg = new AddGuildInheritArg();

		// Token: 0x040063EC RID: 25580
		public AddGuildInheritRes oRes = null;
	}
}
