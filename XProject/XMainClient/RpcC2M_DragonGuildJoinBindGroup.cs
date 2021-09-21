using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200164A RID: 5706
	internal class RpcC2M_DragonGuildJoinBindGroup : Rpc
	{
		// Token: 0x0600EE71 RID: 61041 RVA: 0x00349C68 File Offset: 0x00347E68
		public override uint GetRpcType()
		{
			return 33949U;
		}

		// Token: 0x0600EE72 RID: 61042 RVA: 0x00349C7F File Offset: 0x00347E7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildJoinBindGroupArg>(stream, this.oArg);
		}

		// Token: 0x0600EE73 RID: 61043 RVA: 0x00349C8F File Offset: 0x00347E8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildJoinBindGroupRes>(stream);
		}

		// Token: 0x0600EE74 RID: 61044 RVA: 0x00349C9E File Offset: 0x00347E9E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildJoinBindGroup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE75 RID: 61045 RVA: 0x00349CBA File Offset: 0x00347EBA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildJoinBindGroup.OnTimeout(this.oArg);
		}

		// Token: 0x04006614 RID: 26132
		public DragonGuildJoinBindGroupArg oArg = new DragonGuildJoinBindGroupArg();

		// Token: 0x04006615 RID: 26133
		public DragonGuildJoinBindGroupRes oRes = null;
	}
}
