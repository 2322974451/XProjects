using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001EC RID: 492
	[ProtoContract(Name = "FightGroupChangeNtf")]
	[Serializable]
	public class FightGroupChangeNtf : IExtensible
	{
		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x06001C35 RID: 7221 RVA: 0x00037A44 File Offset: 0x00035C44
		// (set) Token: 0x06001C36 RID: 7222 RVA: 0x00037A71 File Offset: 0x00035C71
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x06001C37 RID: 7223 RVA: 0x00037A80 File Offset: 0x00035C80
		// (set) Token: 0x06001C38 RID: 7224 RVA: 0x00037AA0 File Offset: 0x00035CA0
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00037AE4 File Offset: 0x00035CE4
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x00037AFC File Offset: 0x00035CFC
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x06001C3B RID: 7227 RVA: 0x00037B08 File Offset: 0x00035D08
		// (set) Token: 0x06001C3C RID: 7228 RVA: 0x00037B34 File Offset: 0x00035D34
		[ProtoMember(2, IsRequired = false, Name = "fightgroup", DataFormat = DataFormat.TwosComplement)]
		public uint fightgroup
		{
			get
			{
				return this._fightgroup ?? 0U;
			}
			set
			{
				this._fightgroup = new uint?(value);
			}
		}

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x06001C3D RID: 7229 RVA: 0x00037B44 File Offset: 0x00035D44
		// (set) Token: 0x06001C3E RID: 7230 RVA: 0x00037B64 File Offset: 0x00035D64
		[XmlIgnore]
		[Browsable(false)]
		public bool fightgroupSpecified
		{
			get
			{
				return this._fightgroup != null;
			}
			set
			{
				bool flag = value == (this._fightgroup == null);
				if (flag)
				{
					this._fightgroup = (value ? new uint?(this.fightgroup) : null);
				}
			}
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x00037BA8 File Offset: 0x00035DA8
		private bool ShouldSerializefightgroup()
		{
			return this.fightgroupSpecified;
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x00037BC0 File Offset: 0x00035DC0
		private void Resetfightgroup()
		{
			this.fightgroupSpecified = false;
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x00037BCC File Offset: 0x00035DCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000705 RID: 1797
		private ulong? _uid;

		// Token: 0x04000706 RID: 1798
		private uint? _fightgroup;

		// Token: 0x04000707 RID: 1799
		private IExtension extensionObject;
	}
}
