using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B8 RID: 4280
	internal class PtcG2C_SceneFinishStateChanged : Protocol
	{
		// Token: 0x0600D79D RID: 55197 RVA: 0x00328694 File Offset: 0x00326894
		public override uint GetProtoType()
		{
			return 60400U;
		}

		// Token: 0x0600D79E RID: 55198 RVA: 0x003286AB File Offset: 0x003268AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FinishStateInfo>(stream, this.Data);
		}

		// Token: 0x0600D79F RID: 55199 RVA: 0x003286BB File Offset: 0x003268BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FinishStateInfo>(stream);
		}

		// Token: 0x0600D7A0 RID: 55200 RVA: 0x003286CA File Offset: 0x003268CA
		public override void Process()
		{
			Process_PtcG2C_SceneFinishStateChanged.Process(this);
		}

		// Token: 0x040061AF RID: 25007
		public FinishStateInfo Data = new FinishStateInfo();
	}
}
