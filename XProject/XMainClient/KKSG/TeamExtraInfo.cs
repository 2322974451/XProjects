using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059A RID: 1434
	[ProtoContract(Name = "TeamExtraInfo")]
	[Serializable]
	public class TeamExtraInfo : IExtensible
	{
		// Token: 0x170017A5 RID: 6053
		// (get) Token: 0x06004CC5 RID: 19653 RVA: 0x000920C0 File Offset: 0x000902C0
		// (set) Token: 0x06004CC6 RID: 19654 RVA: 0x000920EC File Offset: 0x000902EC
		[ProtoMember(1, IsRequired = false, Name = "pptlimit", DataFormat = DataFormat.TwosComplement)]
		public uint pptlimit
		{
			get
			{
				return this._pptlimit ?? 0U;
			}
			set
			{
				this._pptlimit = new uint?(value);
			}
		}

		// Token: 0x170017A6 RID: 6054
		// (get) Token: 0x06004CC7 RID: 19655 RVA: 0x000920FC File Offset: 0x000902FC
		// (set) Token: 0x06004CC8 RID: 19656 RVA: 0x0009211C File Offset: 0x0009031C
		[XmlIgnore]
		[Browsable(false)]
		public bool pptlimitSpecified
		{
			get
			{
				return this._pptlimit != null;
			}
			set
			{
				bool flag = value == (this._pptlimit == null);
				if (flag)
				{
					this._pptlimit = (value ? new uint?(this.pptlimit) : null);
				}
			}
		}

		// Token: 0x06004CC9 RID: 19657 RVA: 0x00092160 File Offset: 0x00090360
		private bool ShouldSerializepptlimit()
		{
			return this.pptlimitSpecified;
		}

		// Token: 0x06004CCA RID: 19658 RVA: 0x00092178 File Offset: 0x00090378
		private void Resetpptlimit()
		{
			this.pptlimitSpecified = false;
		}

		// Token: 0x170017A7 RID: 6055
		// (get) Token: 0x06004CCB RID: 19659 RVA: 0x00092184 File Offset: 0x00090384
		// (set) Token: 0x06004CCC RID: 19660 RVA: 0x000921B0 File Offset: 0x000903B0
		[ProtoMember(2, IsRequired = false, Name = "costindex", DataFormat = DataFormat.TwosComplement)]
		public uint costindex
		{
			get
			{
				return this._costindex ?? 0U;
			}
			set
			{
				this._costindex = new uint?(value);
			}
		}

		// Token: 0x170017A8 RID: 6056
		// (get) Token: 0x06004CCD RID: 19661 RVA: 0x000921C0 File Offset: 0x000903C0
		// (set) Token: 0x06004CCE RID: 19662 RVA: 0x000921E0 File Offset: 0x000903E0
		[XmlIgnore]
		[Browsable(false)]
		public bool costindexSpecified
		{
			get
			{
				return this._costindex != null;
			}
			set
			{
				bool flag = value == (this._costindex == null);
				if (flag)
				{
					this._costindex = (value ? new uint?(this.costindex) : null);
				}
			}
		}

		// Token: 0x06004CCF RID: 19663 RVA: 0x00092224 File Offset: 0x00090424
		private bool ShouldSerializecostindex()
		{
			return this.costindexSpecified;
		}

		// Token: 0x06004CD0 RID: 19664 RVA: 0x0009223C File Offset: 0x0009043C
		private void Resetcostindex()
		{
			this.costindexSpecified = false;
		}

		// Token: 0x170017A9 RID: 6057
		// (get) Token: 0x06004CD1 RID: 19665 RVA: 0x00092248 File Offset: 0x00090448
		// (set) Token: 0x06004CD2 RID: 19666 RVA: 0x00092269 File Offset: 0x00090469
		[ProtoMember(3, IsRequired = false, Name = "league_teamname", DataFormat = DataFormat.Default)]
		public string league_teamname
		{
			get
			{
				return this._league_teamname ?? "";
			}
			set
			{
				this._league_teamname = value;
			}
		}

		// Token: 0x170017AA RID: 6058
		// (get) Token: 0x06004CD3 RID: 19667 RVA: 0x00092274 File Offset: 0x00090474
		// (set) Token: 0x06004CD4 RID: 19668 RVA: 0x00092290 File Offset: 0x00090490
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamnameSpecified
		{
			get
			{
				return this._league_teamname != null;
			}
			set
			{
				bool flag = value == (this._league_teamname == null);
				if (flag)
				{
					this._league_teamname = (value ? this.league_teamname : null);
				}
			}
		}

		// Token: 0x06004CD5 RID: 19669 RVA: 0x000922C0 File Offset: 0x000904C0
		private bool ShouldSerializeleague_teamname()
		{
			return this.league_teamnameSpecified;
		}

		// Token: 0x06004CD6 RID: 19670 RVA: 0x000922D8 File Offset: 0x000904D8
		private void Resetleague_teamname()
		{
			this.league_teamnameSpecified = false;
		}

		// Token: 0x170017AB RID: 6059
		// (get) Token: 0x06004CD7 RID: 19671 RVA: 0x000922E4 File Offset: 0x000904E4
		// (set) Token: 0x06004CD8 RID: 19672 RVA: 0x000922FC File Offset: 0x000904FC
		[ProtoMember(4, IsRequired = false, Name = "rift", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamSynRift rift
		{
			get
			{
				return this._rift;
			}
			set
			{
				this._rift = value;
			}
		}

		// Token: 0x06004CD9 RID: 19673 RVA: 0x00092308 File Offset: 0x00090508
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001306 RID: 4870
		private uint? _pptlimit;

		// Token: 0x04001307 RID: 4871
		private uint? _costindex;

		// Token: 0x04001308 RID: 4872
		private string _league_teamname;

		// Token: 0x04001309 RID: 4873
		private TeamSynRift _rift = null;

		// Token: 0x0400130A RID: 4874
		private IExtension extensionObject;
	}
}
