using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001081 RID: 4225
	internal class RpcC2G_EndGuildCard : Rpc
	{
		// Token: 0x0600D6C1 RID: 54977 RVA: 0x003269E8 File Offset: 0x00324BE8
		public override uint GetRpcType()
		{
			return 13212U;
		}

		// Token: 0x0600D6C2 RID: 54978 RVA: 0x003269FF File Offset: 0x00324BFF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EndGuildCardArg>(stream, this.oArg);
		}

		// Token: 0x0600D6C3 RID: 54979 RVA: 0x00326A0F File Offset: 0x00324C0F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EndGuildCardRes>(stream);
		}

		// Token: 0x0600D6C4 RID: 54980 RVA: 0x00326A1E File Offset: 0x00324C1E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EndGuildCard.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6C5 RID: 54981 RVA: 0x00326A3A File Offset: 0x00324C3A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EndGuildCard.OnTimeout(this.oArg);
		}

		// Token: 0x04006188 RID: 24968
		public EndGuildCardArg oArg = new EndGuildCardArg();

		// Token: 0x04006189 RID: 24969
		public EndGuildCardRes oRes = new EndGuildCardRes();
	}
}
