using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B4 RID: 948
	[ProtoContract(Name = "NoticeGuildTerrBattleWin")]
	[Serializable]
	public class NoticeGuildTerrBattleWin : IExtensible
	{
		// Token: 0x17000F9C RID: 3996
		// (get) Token: 0x0600329E RID: 12958 RVA: 0x00061508 File Offset: 0x0005F708
		// (set) Token: 0x0600329F RID: 12959 RVA: 0x00061534 File Offset: 0x0005F734
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000F9D RID: 3997
		// (get) Token: 0x060032A0 RID: 12960 RVA: 0x00061544 File Offset: 0x0005F744
		// (set) Token: 0x060032A1 RID: 12961 RVA: 0x00061564 File Offset: 0x0005F764
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060032A2 RID: 12962 RVA: 0x000615A8 File Offset: 0x0005F7A8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060032A3 RID: 12963 RVA: 0x000615C0 File Offset: 0x0005F7C0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17000F9E RID: 3998
		// (get) Token: 0x060032A4 RID: 12964 RVA: 0x000615CC File Offset: 0x0005F7CC
		// (set) Token: 0x060032A5 RID: 12965 RVA: 0x000615F9 File Offset: 0x0005F7F9
		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000F9F RID: 3999
		// (get) Token: 0x060032A6 RID: 12966 RVA: 0x00061608 File Offset: 0x0005F808
		// (set) Token: 0x060032A7 RID: 12967 RVA: 0x00061628 File Offset: 0x0005F828
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

		// Token: 0x060032A8 RID: 12968 RVA: 0x0006166C File Offset: 0x0005F86C
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x060032A9 RID: 12969 RVA: 0x00061684 File Offset: 0x0005F884
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x060032AA RID: 12970 RVA: 0x00061690 File Offset: 0x0005F890
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C99 RID: 3225
		private uint? _id;

		// Token: 0x04000C9A RID: 3226
		private ulong? _guildid;

		// Token: 0x04000C9B RID: 3227
		private IExtension extensionObject;
	}
}
