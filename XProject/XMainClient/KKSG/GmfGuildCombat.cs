using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B9 RID: 1721
	[ProtoContract(Name = "GmfGuildCombat")]
	[Serializable]
	public class GmfGuildCombat : IExtensible
	{
		// Token: 0x170023D3 RID: 9171
		// (get) Token: 0x0600712B RID: 28971 RVA: 0x000D88B8 File Offset: 0x000D6AB8
		// (set) Token: 0x0600712C RID: 28972 RVA: 0x000D88D0 File Offset: 0x000D6AD0
		[ProtoMember(1, IsRequired = false, Name = "gmfguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief gmfguild
		{
			get
			{
				return this._gmfguild;
			}
			set
			{
				this._gmfguild = value;
			}
		}

		// Token: 0x170023D4 RID: 9172
		// (get) Token: 0x0600712D RID: 28973 RVA: 0x000D88DC File Offset: 0x000D6ADC
		// (set) Token: 0x0600712E RID: 28974 RVA: 0x000D88F4 File Offset: 0x000D6AF4
		[ProtoMember(2, IsRequired = false, Name = "combat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfCombat combat
		{
			get
			{
				return this._combat;
			}
			set
			{
				this._combat = value;
			}
		}

		// Token: 0x170023D5 RID: 9173
		// (get) Token: 0x0600712F RID: 28975 RVA: 0x000D8900 File Offset: 0x000D6B00
		// (set) Token: 0x06007130 RID: 28976 RVA: 0x000D892C File Offset: 0x000D6B2C
		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170023D6 RID: 9174
		// (get) Token: 0x06007131 RID: 28977 RVA: 0x000D893C File Offset: 0x000D6B3C
		// (set) Token: 0x06007132 RID: 28978 RVA: 0x000D895C File Offset: 0x000D6B5C
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06007133 RID: 28979 RVA: 0x000D89A0 File Offset: 0x000D6BA0
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007134 RID: 28980 RVA: 0x000D89B8 File Offset: 0x000D6BB8
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170023D7 RID: 9175
		// (get) Token: 0x06007135 RID: 28981 RVA: 0x000D89C4 File Offset: 0x000D6BC4
		[ProtoMember(4, Name = "rolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> rolecombat
		{
			get
			{
				return this._rolecombat;
			}
		}

		// Token: 0x06007136 RID: 28982 RVA: 0x000D89DC File Offset: 0x000D6BDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AFE RID: 6910
		private GmfGuildBrief _gmfguild = null;

		// Token: 0x04001AFF RID: 6911
		private GmfCombat _combat = null;

		// Token: 0x04001B00 RID: 6912
		private uint? _score;

		// Token: 0x04001B01 RID: 6913
		private readonly List<GmfRoleCombat> _rolecombat = new List<GmfRoleCombat>();

		// Token: 0x04001B02 RID: 6914
		private IExtension extensionObject;
	}
}
