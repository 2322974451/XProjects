using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000340 RID: 832
	[ProtoContract(Name = "ReqGuildTerrAllianceInfoRes")]
	[Serializable]
	public class ReqGuildTerrAllianceInfoRes : IExtensible
	{
		// Token: 0x17000E2A RID: 3626
		// (get) Token: 0x06002DA6 RID: 11686 RVA: 0x00058548 File Offset: 0x00056748
		// (set) Token: 0x06002DA7 RID: 11687 RVA: 0x00058575 File Offset: 0x00056775
		[ProtoMember(1, IsRequired = false, Name = "allianceid", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceid
		{
			get
			{
				return this._allianceid ?? 0UL;
			}
			set
			{
				this._allianceid = new ulong?(value);
			}
		}

		// Token: 0x17000E2B RID: 3627
		// (get) Token: 0x06002DA8 RID: 11688 RVA: 0x00058584 File Offset: 0x00056784
		// (set) Token: 0x06002DA9 RID: 11689 RVA: 0x000585A4 File Offset: 0x000567A4
		[XmlIgnore]
		[Browsable(false)]
		public bool allianceidSpecified
		{
			get
			{
				return this._allianceid != null;
			}
			set
			{
				bool flag = value == (this._allianceid == null);
				if (flag)
				{
					this._allianceid = (value ? new ulong?(this.allianceid) : null);
				}
			}
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x000585E8 File Offset: 0x000567E8
		private bool ShouldSerializeallianceid()
		{
			return this.allianceidSpecified;
		}

		// Token: 0x06002DAB RID: 11691 RVA: 0x00058600 File Offset: 0x00056800
		private void Resetallianceid()
		{
			this.allianceidSpecified = false;
		}

		// Token: 0x17000E2C RID: 3628
		// (get) Token: 0x06002DAC RID: 11692 RVA: 0x0005860C File Offset: 0x0005680C
		[ProtoMember(2, Name = "allianceinfo", DataFormat = DataFormat.Default)]
		public List<GuildTerrAllianceInfo> allianceinfo
		{
			get
			{
				return this._allianceinfo;
			}
		}

		// Token: 0x06002DAD RID: 11693 RVA: 0x00058624 File Offset: 0x00056824
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B56 RID: 2902
		private ulong? _allianceid;

		// Token: 0x04000B57 RID: 2903
		private readonly List<GuildTerrAllianceInfo> _allianceinfo = new List<GuildTerrAllianceInfo>();

		// Token: 0x04000B58 RID: 2904
		private IExtension extensionObject;
	}
}
