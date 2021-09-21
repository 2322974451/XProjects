using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010C8 RID: 4296
	internal class PtcG2C_SceneLeftDoodad : Protocol
	{
		// Token: 0x0600D7D8 RID: 55256 RVA: 0x00328B90 File Offset: 0x00326D90
		public override uint GetProtoType()
		{
			return 18028U;
		}

		// Token: 0x0600D7D9 RID: 55257 RVA: 0x00328BA7 File Offset: 0x00326DA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneLeftDoodad>(stream, this.Data);
		}

		// Token: 0x0600D7DA RID: 55258 RVA: 0x00328BB7 File Offset: 0x00326DB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneLeftDoodad>(stream);
		}

		// Token: 0x0600D7DB RID: 55259 RVA: 0x00328BC6 File Offset: 0x00326DC6
		public override void Process()
		{
			Process_PtcG2C_SceneLeftDoodad.Process(this);
		}

		// Token: 0x040061B7 RID: 25015
		public SceneLeftDoodad Data = new SceneLeftDoodad();
	}
}
