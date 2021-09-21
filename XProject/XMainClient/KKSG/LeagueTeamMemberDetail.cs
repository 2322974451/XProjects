using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006ED RID: 1773
	[ProtoContract(Name = "LeagueTeamMemberDetail")]
	[Serializable]
	public class LeagueTeamMemberDetail : IExtensible
	{
		// Token: 0x17002596 RID: 9622
		// (get) Token: 0x060076B9 RID: 30393 RVA: 0x000E3240 File Offset: 0x000E1440
		// (set) Token: 0x060076BA RID: 30394 RVA: 0x000E3258 File Offset: 0x000E1458
		[ProtoMember(1, IsRequired = false, Name = "brief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief brief
		{
			get
			{
				return this._brief;
			}
			set
			{
				this._brief = value;
			}
		}

		// Token: 0x17002597 RID: 9623
		// (get) Token: 0x060076BB RID: 30395 RVA: 0x000E3264 File Offset: 0x000E1464
		// (set) Token: 0x060076BC RID: 30396 RVA: 0x000E3290 File Offset: 0x000E1490
		[ProtoMember(2, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		// Token: 0x17002598 RID: 9624
		// (get) Token: 0x060076BD RID: 30397 RVA: 0x000E32A0 File Offset: 0x000E14A0
		// (set) Token: 0x060076BE RID: 30398 RVA: 0x000E32C0 File Offset: 0x000E14C0
		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		// Token: 0x060076BF RID: 30399 RVA: 0x000E3304 File Offset: 0x000E1504
		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		// Token: 0x060076C0 RID: 30400 RVA: 0x000E331C File Offset: 0x000E151C
		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		// Token: 0x060076C1 RID: 30401 RVA: 0x000E3328 File Offset: 0x000E1528
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C1F RID: 7199
		private RoleOutLookBrief _brief = null;

		// Token: 0x04001C20 RID: 7200
		private uint? _pkpoint;

		// Token: 0x04001C21 RID: 7201
		private IExtension extensionObject;
	}
}
