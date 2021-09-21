using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000239 RID: 569
	[ProtoContract(Name = "SkyCityEstimateInfo")]
	[Serializable]
	public class SkyCityEstimateInfo : IExtensible
	{
		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06001F9E RID: 8094 RVA: 0x0003DFB8 File Offset: 0x0003C1B8
		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityEstimateBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x0003DFD0 File Offset: 0x0003C1D0
		// (set) Token: 0x06001FA0 RID: 8096 RVA: 0x0003DFFC File Offset: 0x0003C1FC
		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x0003E00C File Offset: 0x0003C20C
		// (set) Token: 0x06001FA2 RID: 8098 RVA: 0x0003E02C File Offset: 0x0003C22C
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		// Token: 0x06001FA3 RID: 8099 RVA: 0x0003E070 File Offset: 0x0003C270
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06001FA4 RID: 8100 RVA: 0x0003E088 File Offset: 0x0003C288
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x0003E094 File Offset: 0x0003C294
		// (set) Token: 0x06001FA6 RID: 8102 RVA: 0x0003E0C0 File Offset: 0x0003C2C0
		[ProtoMember(3, IsRequired = false, Name = "winteamid", DataFormat = DataFormat.TwosComplement)]
		public uint winteamid
		{
			get
			{
				return this._winteamid ?? 0U;
			}
			set
			{
				this._winteamid = new uint?(value);
			}
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06001FA7 RID: 8103 RVA: 0x0003E0D0 File Offset: 0x0003C2D0
		// (set) Token: 0x06001FA8 RID: 8104 RVA: 0x0003E0F0 File Offset: 0x0003C2F0
		[XmlIgnore]
		[Browsable(false)]
		public bool winteamidSpecified
		{
			get
			{
				return this._winteamid != null;
			}
			set
			{
				bool flag = value == (this._winteamid == null);
				if (flag)
				{
					this._winteamid = (value ? new uint?(this.winteamid) : null);
				}
			}
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x0003E134 File Offset: 0x0003C334
		private bool ShouldSerializewinteamid()
		{
			return this.winteamidSpecified;
		}

		// Token: 0x06001FAA RID: 8106 RVA: 0x0003E14C File Offset: 0x0003C34C
		private void Resetwinteamid()
		{
			this.winteamidSpecified = false;
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06001FAB RID: 8107 RVA: 0x0003E158 File Offset: 0x0003C358
		[ProtoMember(4, Name = "teamscore", DataFormat = DataFormat.Default)]
		public List<SkyCityTeamScore> teamscore
		{
			get
			{
				return this._teamscore;
			}
		}

		// Token: 0x06001FAC RID: 8108 RVA: 0x0003E170 File Offset: 0x0003C370
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007E4 RID: 2020
		private readonly List<SkyCityEstimateBaseInfo> _info = new List<SkyCityEstimateBaseInfo>();

		// Token: 0x040007E5 RID: 2021
		private uint? _floor;

		// Token: 0x040007E6 RID: 2022
		private uint? _winteamid;

		// Token: 0x040007E7 RID: 2023
		private readonly List<SkyCityTeamScore> _teamscore = new List<SkyCityTeamScore>();

		// Token: 0x040007E8 RID: 2024
		private IExtension extensionObject;
	}
}
