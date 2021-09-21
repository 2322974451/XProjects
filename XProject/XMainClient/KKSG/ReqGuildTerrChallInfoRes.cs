using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033E RID: 830
	[ProtoContract(Name = "ReqGuildTerrChallInfoRes")]
	[Serializable]
	public class ReqGuildTerrChallInfoRes : IExtensible
	{
		// Token: 0x17000E27 RID: 3623
		// (get) Token: 0x06002D9B RID: 11675 RVA: 0x00058418 File Offset: 0x00056618
		[ProtoMember(1, Name = "challinfo", DataFormat = DataFormat.Default)]
		public List<GuildTerrChallInfo> challinfo
		{
			get
			{
				return this._challinfo;
			}
		}

		// Token: 0x17000E28 RID: 3624
		// (get) Token: 0x06002D9C RID: 11676 RVA: 0x00058430 File Offset: 0x00056630
		// (set) Token: 0x06002D9D RID: 11677 RVA: 0x0005845C File Offset: 0x0005665C
		[ProtoMember(2, IsRequired = false, Name = "cdtime", DataFormat = DataFormat.TwosComplement)]
		public uint cdtime
		{
			get
			{
				return this._cdtime ?? 0U;
			}
			set
			{
				this._cdtime = new uint?(value);
			}
		}

		// Token: 0x17000E29 RID: 3625
		// (get) Token: 0x06002D9E RID: 11678 RVA: 0x0005846C File Offset: 0x0005666C
		// (set) Token: 0x06002D9F RID: 11679 RVA: 0x0005848C File Offset: 0x0005668C
		[XmlIgnore]
		[Browsable(false)]
		public bool cdtimeSpecified
		{
			get
			{
				return this._cdtime != null;
			}
			set
			{
				bool flag = value == (this._cdtime == null);
				if (flag)
				{
					this._cdtime = (value ? new uint?(this.cdtime) : null);
				}
			}
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x000584D0 File Offset: 0x000566D0
		private bool ShouldSerializecdtime()
		{
			return this.cdtimeSpecified;
		}

		// Token: 0x06002DA1 RID: 11681 RVA: 0x000584E8 File Offset: 0x000566E8
		private void Resetcdtime()
		{
			this.cdtimeSpecified = false;
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x000584F4 File Offset: 0x000566F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B52 RID: 2898
		private readonly List<GuildTerrChallInfo> _challinfo = new List<GuildTerrChallInfo>();

		// Token: 0x04000B53 RID: 2899
		private uint? _cdtime;

		// Token: 0x04000B54 RID: 2900
		private IExtension extensionObject;
	}
}
