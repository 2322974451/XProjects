using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A6 RID: 1446
	[ProtoContract(Name = "ChatParamGuild")]
	[Serializable]
	public class ChatParamGuild : IExtensible
	{
		// Token: 0x17001829 RID: 6185
		// (get) Token: 0x06004E4E RID: 20046 RVA: 0x00094F48 File Offset: 0x00093148
		// (set) Token: 0x06004E4F RID: 20047 RVA: 0x00094F75 File Offset: 0x00093175
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

		// Token: 0x1700182A RID: 6186
		// (get) Token: 0x06004E50 RID: 20048 RVA: 0x00094F84 File Offset: 0x00093184
		// (set) Token: 0x06004E51 RID: 20049 RVA: 0x00094FA4 File Offset: 0x000931A4
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

		// Token: 0x06004E52 RID: 20050 RVA: 0x00094FE8 File Offset: 0x000931E8
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06004E53 RID: 20051 RVA: 0x00095000 File Offset: 0x00093200
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x1700182B RID: 6187
		// (get) Token: 0x06004E54 RID: 20052 RVA: 0x0009500C File Offset: 0x0009320C
		// (set) Token: 0x06004E55 RID: 20053 RVA: 0x0009502D File Offset: 0x0009322D
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x1700182C RID: 6188
		// (get) Token: 0x06004E56 RID: 20054 RVA: 0x00095038 File Offset: 0x00093238
		// (set) Token: 0x06004E57 RID: 20055 RVA: 0x00095054 File Offset: 0x00093254
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06004E58 RID: 20056 RVA: 0x00095084 File Offset: 0x00093284
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06004E59 RID: 20057 RVA: 0x0009509C File Offset: 0x0009329C
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x06004E5A RID: 20058 RVA: 0x000950A8 File Offset: 0x000932A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400135F RID: 4959
		private ulong? _guildid;

		// Token: 0x04001360 RID: 4960
		private string _guildname;

		// Token: 0x04001361 RID: 4961
		private IExtension extensionObject;
	}
}
