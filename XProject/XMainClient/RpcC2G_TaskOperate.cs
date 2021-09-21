using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001025 RID: 4133
	internal class RpcC2G_TaskOperate : Rpc
	{
		// Token: 0x0600D53C RID: 54588 RVA: 0x00323968 File Offset: 0x00321B68
		public override uint GetRpcType()
		{
			return 20029U;
		}

		// Token: 0x0600D53D RID: 54589 RVA: 0x0032397F File Offset: 0x00321B7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskOPArg>(stream, this.oArg);
		}

		// Token: 0x0600D53E RID: 54590 RVA: 0x0032398F File Offset: 0x00321B8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TaskOPRes>(stream);
		}

		// Token: 0x0600D53F RID: 54591 RVA: 0x0032399E File Offset: 0x00321B9E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TaskOperate.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D540 RID: 54592 RVA: 0x003239BA File Offset: 0x00321BBA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TaskOperate.OnTimeout(this.oArg);
		}

		// Token: 0x04006117 RID: 24855
		public TaskOPArg oArg = new TaskOPArg();

		// Token: 0x04006118 RID: 24856
		public TaskOPRes oRes = null;
	}
}
