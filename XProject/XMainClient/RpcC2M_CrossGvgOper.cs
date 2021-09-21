using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001686 RID: 5766
	internal class RpcC2M_CrossGvgOper : Rpc
	{
		// Token: 0x0600EF68 RID: 61288 RVA: 0x0034B484 File Offset: 0x00349684
		public override uint GetRpcType()
		{
			return 46062U;
		}

		// Token: 0x0600EF69 RID: 61289 RVA: 0x0034B49B File Offset: 0x0034969B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgOperArg>(stream, this.oArg);
		}

		// Token: 0x0600EF6A RID: 61290 RVA: 0x0034B4AB File Offset: 0x003496AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CrossGvgOperRes>(stream);
		}

		// Token: 0x0600EF6B RID: 61291 RVA: 0x0034B4BA File Offset: 0x003496BA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CrossGvgOper.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF6C RID: 61292 RVA: 0x0034B4D6 File Offset: 0x003496D6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CrossGvgOper.OnTimeout(this.oArg);
		}

		// Token: 0x0400664B RID: 26187
		public CrossGvgOperArg oArg = new CrossGvgOperArg();

		// Token: 0x0400664C RID: 26188
		public CrossGvgOperRes oRes = null;
	}
}
