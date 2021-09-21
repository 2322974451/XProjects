using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000423 RID: 1059
	[ProtoContract(Name = "MobaBattleTeamRoleData")]
	[Serializable]
	public class MobaBattleTeamRoleData : IExtensible
	{
		// Token: 0x17001142 RID: 4418
		// (get) Token: 0x06003831 RID: 14385 RVA: 0x0006B91C File Offset: 0x00069B1C
		// (set) Token: 0x06003832 RID: 14386 RVA: 0x0006B948 File Offset: 0x00069B48
		[ProtoMember(1, IsRequired = false, Name = "team1", DataFormat = DataFormat.TwosComplement)]
		public uint team1
		{
			get
			{
				return this._team1 ?? 0U;
			}
			set
			{
				this._team1 = new uint?(value);
			}
		}

		// Token: 0x17001143 RID: 4419
		// (get) Token: 0x06003833 RID: 14387 RVA: 0x0006B958 File Offset: 0x00069B58
		// (set) Token: 0x06003834 RID: 14388 RVA: 0x0006B978 File Offset: 0x00069B78
		[XmlIgnore]
		[Browsable(false)]
		public bool team1Specified
		{
			get
			{
				return this._team1 != null;
			}
			set
			{
				bool flag = value == (this._team1 == null);
				if (flag)
				{
					this._team1 = (value ? new uint?(this.team1) : null);
				}
			}
		}

		// Token: 0x06003835 RID: 14389 RVA: 0x0006B9BC File Offset: 0x00069BBC
		private bool ShouldSerializeteam1()
		{
			return this.team1Specified;
		}

		// Token: 0x06003836 RID: 14390 RVA: 0x0006B9D4 File Offset: 0x00069BD4
		private void Resetteam1()
		{
			this.team1Specified = false;
		}

		// Token: 0x17001144 RID: 4420
		// (get) Token: 0x06003837 RID: 14391 RVA: 0x0006B9E0 File Offset: 0x00069BE0
		[ProtoMember(2, Name = "datalist1", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> datalist1
		{
			get
			{
				return this._datalist1;
			}
		}

		// Token: 0x17001145 RID: 4421
		// (get) Token: 0x06003838 RID: 14392 RVA: 0x0006B9F8 File Offset: 0x00069BF8
		// (set) Token: 0x06003839 RID: 14393 RVA: 0x0006BA24 File Offset: 0x00069C24
		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.TwosComplement)]
		public uint team2
		{
			get
			{
				return this._team2 ?? 0U;
			}
			set
			{
				this._team2 = new uint?(value);
			}
		}

		// Token: 0x17001146 RID: 4422
		// (get) Token: 0x0600383A RID: 14394 RVA: 0x0006BA34 File Offset: 0x00069C34
		// (set) Token: 0x0600383B RID: 14395 RVA: 0x0006BA54 File Offset: 0x00069C54
		[XmlIgnore]
		[Browsable(false)]
		public bool team2Specified
		{
			get
			{
				return this._team2 != null;
			}
			set
			{
				bool flag = value == (this._team2 == null);
				if (flag)
				{
					this._team2 = (value ? new uint?(this.team2) : null);
				}
			}
		}

		// Token: 0x0600383C RID: 14396 RVA: 0x0006BA98 File Offset: 0x00069C98
		private bool ShouldSerializeteam2()
		{
			return this.team2Specified;
		}

		// Token: 0x0600383D RID: 14397 RVA: 0x0006BAB0 File Offset: 0x00069CB0
		private void Resetteam2()
		{
			this.team2Specified = false;
		}

		// Token: 0x17001147 RID: 4423
		// (get) Token: 0x0600383E RID: 14398 RVA: 0x0006BABC File Offset: 0x00069CBC
		[ProtoMember(4, Name = "datalist2", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> datalist2
		{
			get
			{
				return this._datalist2;
			}
		}

		// Token: 0x0600383F RID: 14399 RVA: 0x0006BAD4 File Offset: 0x00069CD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DED RID: 3565
		private uint? _team1;

		// Token: 0x04000DEE RID: 3566
		private readonly List<MobaRoleData> _datalist1 = new List<MobaRoleData>();

		// Token: 0x04000DEF RID: 3567
		private uint? _team2;

		// Token: 0x04000DF0 RID: 3568
		private readonly List<MobaRoleData> _datalist2 = new List<MobaRoleData>();

		// Token: 0x04000DF1 RID: 3569
		private IExtension extensionObject;
	}
}
