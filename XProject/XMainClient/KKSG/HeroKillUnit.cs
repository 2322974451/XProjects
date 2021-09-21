using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000718 RID: 1816
	[ProtoContract(Name = "HeroKillUnit")]
	[Serializable]
	public class HeroKillUnit : IExtensible
	{
		// Token: 0x1700272E RID: 10030
		// (get) Token: 0x06007B9D RID: 31645 RVA: 0x000EC49C File Offset: 0x000EA69C
		// (set) Token: 0x06007B9E RID: 31646 RVA: 0x000EC4C8 File Offset: 0x000EA6C8
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public HeroKillUnitType type
		{
			get
			{
				return this._type ?? HeroKillUnitType.HeroKillUnit_Hero;
			}
			set
			{
				this._type = new HeroKillUnitType?(value);
			}
		}

		// Token: 0x1700272F RID: 10031
		// (get) Token: 0x06007B9F RID: 31647 RVA: 0x000EC4D8 File Offset: 0x000EA6D8
		// (set) Token: 0x06007BA0 RID: 31648 RVA: 0x000EC4F8 File Offset: 0x000EA6F8
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new HeroKillUnitType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007BA1 RID: 31649 RVA: 0x000EC53C File Offset: 0x000EA73C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007BA2 RID: 31650 RVA: 0x000EC554 File Offset: 0x000EA754
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17002730 RID: 10032
		// (get) Token: 0x06007BA3 RID: 31651 RVA: 0x000EC560 File Offset: 0x000EA760
		// (set) Token: 0x06007BA4 RID: 31652 RVA: 0x000EC58C File Offset: 0x000EA78C
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002731 RID: 10033
		// (get) Token: 0x06007BA5 RID: 31653 RVA: 0x000EC59C File Offset: 0x000EA79C
		// (set) Token: 0x06007BA6 RID: 31654 RVA: 0x000EC5BC File Offset: 0x000EA7BC
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

		// Token: 0x06007BA7 RID: 31655 RVA: 0x000EC600 File Offset: 0x000EA800
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007BA8 RID: 31656 RVA: 0x000EC618 File Offset: 0x000EA818
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002732 RID: 10034
		// (get) Token: 0x06007BA9 RID: 31657 RVA: 0x000EC624 File Offset: 0x000EA824
		// (set) Token: 0x06007BAA RID: 31658 RVA: 0x000EC650 File Offset: 0x000EA850
		[ProtoMember(3, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x17002733 RID: 10035
		// (get) Token: 0x06007BAB RID: 31659 RVA: 0x000EC660 File Offset: 0x000EA860
		// (set) Token: 0x06007BAC RID: 31660 RVA: 0x000EC680 File Offset: 0x000EA880
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x06007BAD RID: 31661 RVA: 0x000EC6C4 File Offset: 0x000EA8C4
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06007BAE RID: 31662 RVA: 0x000EC6DC File Offset: 0x000EA8DC
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17002734 RID: 10036
		// (get) Token: 0x06007BAF RID: 31663 RVA: 0x000EC6E8 File Offset: 0x000EA8E8
		// (set) Token: 0x06007BB0 RID: 31664 RVA: 0x000EC714 File Offset: 0x000EA914
		[ProtoMember(4, IsRequired = false, Name = "continueCounts", DataFormat = DataFormat.TwosComplement)]
		public uint continueCounts
		{
			get
			{
				return this._continueCounts ?? 0U;
			}
			set
			{
				this._continueCounts = new uint?(value);
			}
		}

		// Token: 0x17002735 RID: 10037
		// (get) Token: 0x06007BB1 RID: 31665 RVA: 0x000EC724 File Offset: 0x000EA924
		// (set) Token: 0x06007BB2 RID: 31666 RVA: 0x000EC744 File Offset: 0x000EA944
		[XmlIgnore]
		[Browsable(false)]
		public bool continueCountsSpecified
		{
			get
			{
				return this._continueCounts != null;
			}
			set
			{
				bool flag = value == (this._continueCounts == null);
				if (flag)
				{
					this._continueCounts = (value ? new uint?(this.continueCounts) : null);
				}
			}
		}

		// Token: 0x06007BB3 RID: 31667 RVA: 0x000EC788 File Offset: 0x000EA988
		private bool ShouldSerializecontinueCounts()
		{
			return this.continueCountsSpecified;
		}

		// Token: 0x06007BB4 RID: 31668 RVA: 0x000EC7A0 File Offset: 0x000EA9A0
		private void ResetcontinueCounts()
		{
			this.continueCountsSpecified = false;
		}

		// Token: 0x06007BB5 RID: 31669 RVA: 0x000EC7AC File Offset: 0x000EA9AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D2A RID: 7466
		private HeroKillUnitType? _type;

		// Token: 0x04001D2B RID: 7467
		private uint? _id;

		// Token: 0x04001D2C RID: 7468
		private uint? _teamid;

		// Token: 0x04001D2D RID: 7469
		private uint? _continueCounts;

		// Token: 0x04001D2E RID: 7470
		private IExtension extensionObject;
	}
}
