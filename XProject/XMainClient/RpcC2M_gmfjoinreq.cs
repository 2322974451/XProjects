using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001315 RID: 4885
	internal class RpcC2M_gmfjoinreq : Rpc
	{
		// Token: 0x0600E143 RID: 57667 RVA: 0x00337498 File Offset: 0x00335698
		public override uint GetRpcType()
		{
			return 37651U;
		}

		// Token: 0x0600E144 RID: 57668 RVA: 0x003374AF File Offset: 0x003356AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<gmfjoinarg>(stream, this.oArg);
		}

		// Token: 0x0600E145 RID: 57669 RVA: 0x003374BF File Offset: 0x003356BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<gmfjoinres>(stream);
		}

		// Token: 0x0600E146 RID: 57670 RVA: 0x003374CE File Offset: 0x003356CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_gmfjoinreq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E147 RID: 57671 RVA: 0x003374EA File Offset: 0x003356EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_gmfjoinreq.OnTimeout(this.oArg);
		}

		// Token: 0x04006383 RID: 25475
		public gmfjoinarg oArg = new gmfjoinarg();

		// Token: 0x04006384 RID: 25476
		public gmfjoinres oRes = null;
	}
}
