using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001249 RID: 4681
	internal class PtcG2C_SpriteChangedNtf : Protocol
	{
		// Token: 0x0600DDF8 RID: 56824 RVA: 0x00332A68 File Offset: 0x00330C68
		public override uint GetProtoType()
		{
			return 197U;
		}

		// Token: 0x0600DDF9 RID: 56825 RVA: 0x00332A7F File Offset: 0x00330C7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteChanged>(stream, this.Data);
		}

		// Token: 0x0600DDFA RID: 56826 RVA: 0x00332A8F File Offset: 0x00330C8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpriteChanged>(stream);
		}

		// Token: 0x0600DDFB RID: 56827 RVA: 0x00332A9E File Offset: 0x00330C9E
		public override void Process()
		{
			Process_PtcG2C_SpriteChangedNtf.Process(this);
		}

		// Token: 0x040062DF RID: 25311
		public SpriteChanged Data = new SpriteChanged();
	}
}
