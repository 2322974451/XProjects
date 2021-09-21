using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FF RID: 511
	[ProtoContract(Name = "SpriteChanged")]
	[Serializable]
	public class SpriteChanged : IExtensible
	{
		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x06001CF7 RID: 7415 RVA: 0x000390A8 File Offset: 0x000372A8
		[ProtoMember(1, Name = "NewSprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> NewSprites
		{
			get
			{
				return this._NewSprites;
			}
		}

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x06001CF8 RID: 7416 RVA: 0x000390C0 File Offset: 0x000372C0
		[ProtoMember(2, Name = "ChangedSprites", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> ChangedSprites
		{
			get
			{
				return this._ChangedSprites;
			}
		}

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x06001CF9 RID: 7417 RVA: 0x000390D8 File Offset: 0x000372D8
		[ProtoMember(3, Name = "RemovedSprites", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemovedSprites
		{
			get
			{
				return this._RemovedSprites;
			}
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x000390F0 File Offset: 0x000372F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000736 RID: 1846
		private readonly List<SpriteInfo> _NewSprites = new List<SpriteInfo>();

		// Token: 0x04000737 RID: 1847
		private readonly List<SpriteInfo> _ChangedSprites = new List<SpriteInfo>();

		// Token: 0x04000738 RID: 1848
		private readonly List<ulong> _RemovedSprites = new List<ulong>();

		// Token: 0x04000739 RID: 1849
		private IExtension extensionObject;
	}
}
