using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200163C RID: 5692
	internal class RpcC2G_GetDragonGuildTaskChest : Rpc
	{
		// Token: 0x0600EE32 RID: 60978 RVA: 0x003496F0 File Offset: 0x003478F0
		public override uint GetRpcType()
		{
			return 15059U;
		}

		// Token: 0x0600EE33 RID: 60979 RVA: 0x00349707 File Offset: 0x00347907
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildTaskChestArg>(stream, this.oArg);
		}

		// Token: 0x0600EE34 RID: 60980 RVA: 0x00349717 File Offset: 0x00347917
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildTaskChestRes>(stream);
		}

		// Token: 0x0600EE35 RID: 60981 RVA: 0x00349726 File Offset: 0x00347926
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDragonGuildTaskChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE36 RID: 60982 RVA: 0x00349742 File Offset: 0x00347942
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDragonGuildTaskChest.OnTimeout(this.oArg);
		}

		// Token: 0x04006606 RID: 26118
		public GetDragonGuildTaskChestArg oArg = new GetDragonGuildTaskChestArg();

		// Token: 0x04006607 RID: 26119
		public GetDragonGuildTaskChestRes oRes = null;
	}
}
