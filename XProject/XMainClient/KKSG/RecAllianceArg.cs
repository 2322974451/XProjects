using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034E RID: 846
	[ProtoContract(Name = "RecAllianceArg")]
	[Serializable]
	public class RecAllianceArg : IExtensible
	{
		// Token: 0x17000E5A RID: 3674
		// (get) Token: 0x06002E42 RID: 11842 RVA: 0x000596B0 File Offset: 0x000578B0
		// (set) Token: 0x06002E43 RID: 11843 RVA: 0x000596DD File Offset: 0x000578DD
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000E5B RID: 3675
		// (get) Token: 0x06002E44 RID: 11844 RVA: 0x000596EC File Offset: 0x000578EC
		// (set) Token: 0x06002E45 RID: 11845 RVA: 0x0005970C File Offset: 0x0005790C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06002E46 RID: 11846 RVA: 0x00059750 File Offset: 0x00057950
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06002E47 RID: 11847 RVA: 0x00059768 File Offset: 0x00057968
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x06002E48 RID: 11848 RVA: 0x00059774 File Offset: 0x00057974
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B80 RID: 2944
		private ulong? _guildid;

		// Token: 0x04000B81 RID: 2945
		private IExtension extensionObject;
	}
}
