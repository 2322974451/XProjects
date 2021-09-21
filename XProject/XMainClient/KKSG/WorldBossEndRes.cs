using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000209 RID: 521
	[ProtoContract(Name = "WorldBossEndRes")]
	[Serializable]
	public class WorldBossEndRes : IExtensible
	{
		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x06001D6E RID: 7534 RVA: 0x00039EA0 File Offset: 0x000380A0
		[ProtoMember(1, Name = "damages", DataFormat = DataFormat.Default)]
		public List<WorldBossDamageInfo> damages
		{
			get
			{
				return this._damages;
			}
		}

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x06001D6F RID: 7535 RVA: 0x00039EB8 File Offset: 0x000380B8
		// (set) Token: 0x06001D70 RID: 7536 RVA: 0x00039ED0 File Offset: 0x000380D0
		[ProtoMember(2, IsRequired = false, Name = "selfdamage", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WorldBossDamageInfo selfdamage
		{
			get
			{
				return this._selfdamage;
			}
			set
			{
				this._selfdamage = value;
			}
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x00039EDC File Offset: 0x000380DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400075B RID: 1883
		private readonly List<WorldBossDamageInfo> _damages = new List<WorldBossDamageInfo>();

		// Token: 0x0400075C RID: 1884
		private WorldBossDamageInfo _selfdamage = null;

		// Token: 0x0400075D RID: 1885
		private IExtension extensionObject;
	}
}
