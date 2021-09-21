using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029A RID: 666
	[ProtoContract(Name = "GprOneBattleEnd")]
	[Serializable]
	public class GprOneBattleEnd : IExtensible
	{
		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06002526 RID: 9510 RVA: 0x0004863C File Offset: 0x0004683C
		// (set) Token: 0x06002527 RID: 9511 RVA: 0x00048654 File Offset: 0x00046854
		[ProtoMember(1, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06002528 RID: 9512 RVA: 0x00048660 File Offset: 0x00046860
		// (set) Token: 0x06002529 RID: 9513 RVA: 0x00048678 File Offset: 0x00046878
		[ProtoMember(2, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x0600252A RID: 9514 RVA: 0x00048684 File Offset: 0x00046884
		[ProtoMember(3, Name = "winrolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> winrolecombat
		{
			get
			{
				return this._winrolecombat;
			}
		}

		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x0600252B RID: 9515 RVA: 0x0004869C File Offset: 0x0004689C
		[ProtoMember(4, Name = "loserolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> loserolecombat
		{
			get
			{
				return this._loserolecombat;
			}
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x000486B4 File Offset: 0x000468B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000930 RID: 2352
		private GmfGuildBrief _winguild = null;

		// Token: 0x04000931 RID: 2353
		private GmfGuildBrief _loseguild = null;

		// Token: 0x04000932 RID: 2354
		private readonly List<GmfRoleCombat> _winrolecombat = new List<GmfRoleCombat>();

		// Token: 0x04000933 RID: 2355
		private readonly List<GmfRoleCombat> _loserolecombat = new List<GmfRoleCombat>();

		// Token: 0x04000934 RID: 2356
		private IExtension extensionObject;
	}
}
