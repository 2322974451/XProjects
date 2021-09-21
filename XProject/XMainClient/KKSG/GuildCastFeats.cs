using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000518 RID: 1304
	[ProtoContract(Name = "GuildCastFeats")]
	[Serializable]
	public class GuildCastFeats : IExtensible
	{
		// Token: 0x1700147F RID: 5247
		// (get) Token: 0x0600430D RID: 17165 RVA: 0x0007F920 File Offset: 0x0007DB20
		// (set) Token: 0x0600430E RID: 17166 RVA: 0x0007F94D File Offset: 0x0007DB4D
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001480 RID: 5248
		// (get) Token: 0x0600430F RID: 17167 RVA: 0x0007F95C File Offset: 0x0007DB5C
		// (set) Token: 0x06004310 RID: 17168 RVA: 0x0007F97C File Offset: 0x0007DB7C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06004311 RID: 17169 RVA: 0x0007F9C0 File Offset: 0x0007DBC0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004312 RID: 17170 RVA: 0x0007F9D8 File Offset: 0x0007DBD8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001481 RID: 5249
		// (get) Token: 0x06004313 RID: 17171 RVA: 0x0007F9E4 File Offset: 0x0007DBE4
		// (set) Token: 0x06004314 RID: 17172 RVA: 0x0007FA10 File Offset: 0x0007DC10
		[ProtoMember(2, IsRequired = false, Name = "feats", DataFormat = DataFormat.TwosComplement)]
		public uint feats
		{
			get
			{
				return this._feats ?? 0U;
			}
			set
			{
				this._feats = new uint?(value);
			}
		}

		// Token: 0x17001482 RID: 5250
		// (get) Token: 0x06004315 RID: 17173 RVA: 0x0007FA20 File Offset: 0x0007DC20
		// (set) Token: 0x06004316 RID: 17174 RVA: 0x0007FA40 File Offset: 0x0007DC40
		[XmlIgnore]
		[Browsable(false)]
		public bool featsSpecified
		{
			get
			{
				return this._feats != null;
			}
			set
			{
				bool flag = value == (this._feats == null);
				if (flag)
				{
					this._feats = (value ? new uint?(this.feats) : null);
				}
			}
		}

		// Token: 0x06004317 RID: 17175 RVA: 0x0007FA84 File Offset: 0x0007DC84
		private bool ShouldSerializefeats()
		{
			return this.featsSpecified;
		}

		// Token: 0x06004318 RID: 17176 RVA: 0x0007FA9C File Offset: 0x0007DC9C
		private void Resetfeats()
		{
			this.featsSpecified = false;
		}

		// Token: 0x06004319 RID: 17177 RVA: 0x0007FAA8 File Offset: 0x0007DCA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010B8 RID: 4280
		private ulong? _roleid;

		// Token: 0x040010B9 RID: 4281
		private uint? _feats;

		// Token: 0x040010BA RID: 4282
		private IExtension extensionObject;
	}
}
