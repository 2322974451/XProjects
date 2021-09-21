using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072C RID: 1836
	[ProtoContract(Name = "CreateCrossBattleSceneData")]
	[Serializable]
	public class CreateCrossBattleSceneData : IExtensible
	{
		// Token: 0x17002815 RID: 10261
		// (get) Token: 0x06007E6C RID: 32364 RVA: 0x000F1B78 File Offset: 0x000EFD78
		// (set) Token: 0x06007E6D RID: 32365 RVA: 0x000F1BA5 File Offset: 0x000EFDA5
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

		// Token: 0x17002816 RID: 10262
		// (get) Token: 0x06007E6E RID: 32366 RVA: 0x000F1BB4 File Offset: 0x000EFDB4
		// (set) Token: 0x06007E6F RID: 32367 RVA: 0x000F1BD4 File Offset: 0x000EFDD4
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

		// Token: 0x06007E70 RID: 32368 RVA: 0x000F1C18 File Offset: 0x000EFE18
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007E71 RID: 32369 RVA: 0x000F1C30 File Offset: 0x000EFE30
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002817 RID: 10263
		// (get) Token: 0x06007E72 RID: 32370 RVA: 0x000F1C3C File Offset: 0x000EFE3C
		// (set) Token: 0x06007E73 RID: 32371 RVA: 0x000F1C68 File Offset: 0x000EFE68
		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x17002818 RID: 10264
		// (get) Token: 0x06007E74 RID: 32372 RVA: 0x000F1C78 File Offset: 0x000EFE78
		// (set) Token: 0x06007E75 RID: 32373 RVA: 0x000F1C98 File Offset: 0x000EFE98
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06007E76 RID: 32374 RVA: 0x000F1CDC File Offset: 0x000EFEDC
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007E77 RID: 32375 RVA: 0x000F1CF4 File Offset: 0x000EFEF4
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x06007E78 RID: 32376 RVA: 0x000F1D00 File Offset: 0x000EFF00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DB6 RID: 7606
		private ulong? _roleid;

		// Token: 0x04001DB7 RID: 7607
		private uint? _serverid;

		// Token: 0x04001DB8 RID: 7608
		private IExtension extensionObject;
	}
}
