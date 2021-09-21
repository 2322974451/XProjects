using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000097 RID: 151
	[ProtoContract(Name = "GuildBriefArg")]
	[Serializable]
	public class GuildBriefArg : IExtensible
	{
		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00015C44 File Offset: 0x00013E44
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x00015C71 File Offset: 0x00013E71
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

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x00015C80 File Offset: 0x00013E80
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x00015CA0 File Offset: 0x00013EA0
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

		// Token: 0x06000A11 RID: 2577 RVA: 0x00015CE4 File Offset: 0x00013EE4
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00015CFC File Offset: 0x00013EFC
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00015D08 File Offset: 0x00013F08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000292 RID: 658
		private ulong? _guildid;

		// Token: 0x04000293 RID: 659
		private IExtension extensionObject;
	}
}
