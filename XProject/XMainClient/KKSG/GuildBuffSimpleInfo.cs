using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BF RID: 1727
	[ProtoContract(Name = "GuildBuffSimpleInfo")]
	[Serializable]
	public class GuildBuffSimpleInfo : IExtensible
	{
		// Token: 0x170023F2 RID: 9202
		// (get) Token: 0x0600718E RID: 29070 RVA: 0x000D9420 File Offset: 0x000D7620
		// (set) Token: 0x0600718F RID: 29071 RVA: 0x000D944D File Offset: 0x000D764D
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

		// Token: 0x170023F3 RID: 9203
		// (get) Token: 0x06007190 RID: 29072 RVA: 0x000D945C File Offset: 0x000D765C
		// (set) Token: 0x06007191 RID: 29073 RVA: 0x000D947C File Offset: 0x000D767C
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

		// Token: 0x06007192 RID: 29074 RVA: 0x000D94C0 File Offset: 0x000D76C0
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06007193 RID: 29075 RVA: 0x000D94D8 File Offset: 0x000D76D8
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x170023F4 RID: 9204
		// (get) Token: 0x06007194 RID: 29076 RVA: 0x000D94E4 File Offset: 0x000D76E4
		[ProtoMember(2, Name = "buff", DataFormat = DataFormat.Default)]
		public List<GuildBuff> buff
		{
			get
			{
				return this._buff;
			}
		}

		// Token: 0x06007195 RID: 29077 RVA: 0x000D94FC File Offset: 0x000D76FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B16 RID: 6934
		private ulong? _guildid;

		// Token: 0x04001B17 RID: 6935
		private readonly List<GuildBuff> _buff = new List<GuildBuff>();

		// Token: 0x04001B18 RID: 6936
		private IExtension extensionObject;
	}
}
