using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000FF8 RID: 4088
	internal class PtcC2G_EnterSceneReq : Protocol
	{
		// Token: 0x0600D486 RID: 54406 RVA: 0x00321890 File Offset: 0x0031FA90
		public override uint GetProtoType()
		{
			return 9036U;
		}

		// Token: 0x0600D487 RID: 54407 RVA: 0x003218A7 File Offset: 0x0031FAA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneRequest>(stream, this.Data);
		}

		// Token: 0x0600D488 RID: 54408 RVA: 0x003218B7 File Offset: 0x0031FAB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneRequest>(stream);
		}

		// Token: 0x0600D489 RID: 54409 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040060F3 RID: 24819
		public SceneRequest Data = new SceneRequest();
	}
}
