using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000299 RID: 665
	[ProtoContract(Name = "GmfGuildCombatPara")]
	[Serializable]
	public class GmfGuildCombatPara : IExtensible
	{
		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x06002520 RID: 9504 RVA: 0x000485A8 File Offset: 0x000467A8
		// (set) Token: 0x06002521 RID: 9505 RVA: 0x000485C0 File Offset: 0x000467C0
		[ProtoMember(1, IsRequired = false, Name = "guildcombat11", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildCombat guildcombat11
		{
			get
			{
				return this._guildcombat11;
			}
			set
			{
				this._guildcombat11 = value;
			}
		}

		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x06002522 RID: 9506 RVA: 0x000485CC File Offset: 0x000467CC
		// (set) Token: 0x06002523 RID: 9507 RVA: 0x000485E4 File Offset: 0x000467E4
		[ProtoMember(2, IsRequired = false, Name = "guildcombat22", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildCombat guildcombat22
		{
			get
			{
				return this._guildcombat22;
			}
			set
			{
				this._guildcombat22 = value;
			}
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x000485F0 File Offset: 0x000467F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400092D RID: 2349
		private GmfGuildCombat _guildcombat11 = null;

		// Token: 0x0400092E RID: 2350
		private GmfGuildCombat _guildcombat22 = null;

		// Token: 0x0400092F RID: 2351
		private IExtension extensionObject;
	}
}
