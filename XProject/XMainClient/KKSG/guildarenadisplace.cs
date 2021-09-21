using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B3 RID: 435
	[ProtoContract(Name = "guildarenadisplace")]
	[Serializable]
	public class guildarenadisplace : IExtensible
	{
		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06001999 RID: 6553 RVA: 0x00032CF0 File Offset: 0x00030EF0
		[ProtoMember(1, Name = "units", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> units
		{
			get
			{
				return this._units;
			}
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x00032D08 File Offset: 0x00030F08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400065C RID: 1628
		private readonly List<GuildDarenaUnit> _units = new List<GuildDarenaUnit>();

		// Token: 0x0400065D RID: 1629
		private IExtension extensionObject;
	}
}
