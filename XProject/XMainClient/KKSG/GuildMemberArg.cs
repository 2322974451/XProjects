using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000099 RID: 153
	[ProtoContract(Name = "GuildMemberArg")]
	[Serializable]
	public class GuildMemberArg : IExtensible
	{
		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00016C20 File Offset: 0x00014E20
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00016C4D File Offset: 0x00014E4D
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

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x00016C5C File Offset: 0x00014E5C
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x00016C7C File Offset: 0x00014E7C
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

		// Token: 0x06000A93 RID: 2707 RVA: 0x00016CC0 File Offset: 0x00014EC0
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00016CD8 File Offset: 0x00014ED8
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00016CE4 File Offset: 0x00014EE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002A9 RID: 681
		private ulong? _guildid;

		// Token: 0x040002AA RID: 682
		private IExtension extensionObject;
	}
}
