using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BB RID: 1211
	[ProtoContract(Name = "DragonGuildMemberArg")]
	[Serializable]
	public class DragonGuildMemberArg : IExtensible
	{
		// Token: 0x1700134E RID: 4942
		// (get) Token: 0x06003F07 RID: 16135 RVA: 0x000782BC File Offset: 0x000764BC
		// (set) Token: 0x06003F08 RID: 16136 RVA: 0x000782E9 File Offset: 0x000764E9
		[ProtoMember(1, IsRequired = false, Name = "guildId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildId
		{
			get
			{
				return this._guildId ?? 0UL;
			}
			set
			{
				this._guildId = new ulong?(value);
			}
		}

		// Token: 0x1700134F RID: 4943
		// (get) Token: 0x06003F09 RID: 16137 RVA: 0x000782F8 File Offset: 0x000764F8
		// (set) Token: 0x06003F0A RID: 16138 RVA: 0x00078318 File Offset: 0x00076518
		[XmlIgnore]
		[Browsable(false)]
		public bool guildIdSpecified
		{
			get
			{
				return this._guildId != null;
			}
			set
			{
				bool flag = value == (this._guildId == null);
				if (flag)
				{
					this._guildId = (value ? new ulong?(this.guildId) : null);
				}
			}
		}

		// Token: 0x06003F0B RID: 16139 RVA: 0x0007835C File Offset: 0x0007655C
		private bool ShouldSerializeguildId()
		{
			return this.guildIdSpecified;
		}

		// Token: 0x06003F0C RID: 16140 RVA: 0x00078374 File Offset: 0x00076574
		private void ResetguildId()
		{
			this.guildIdSpecified = false;
		}

		// Token: 0x06003F0D RID: 16141 RVA: 0x00078380 File Offset: 0x00076580
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FAF RID: 4015
		private ulong? _guildId;

		// Token: 0x04000FB0 RID: 4016
		private IExtension extensionObject;
	}
}
