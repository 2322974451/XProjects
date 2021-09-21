using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000383 RID: 899
	[ProtoContract(Name = "LeagueBattleLoadInfoNtf")]
	[Serializable]
	public class LeagueBattleLoadInfoNtf : IExtensible
	{
		// Token: 0x17000F1B RID: 3867
		// (get) Token: 0x060030D4 RID: 12500 RVA: 0x0005E26C File Offset: 0x0005C46C
		// (set) Token: 0x060030D5 RID: 12501 RVA: 0x0005E298 File Offset: 0x0005C498
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleType type
		{
			get
			{
				return this._type ?? LeagueBattleType.LeagueBattleType_RacePoint;
			}
			set
			{
				this._type = new LeagueBattleType?(value);
			}
		}

		// Token: 0x17000F1C RID: 3868
		// (get) Token: 0x060030D6 RID: 12502 RVA: 0x0005E2A8 File Offset: 0x0005C4A8
		// (set) Token: 0x060030D7 RID: 12503 RVA: 0x0005E2C8 File Offset: 0x0005C4C8
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
					this._type = (value ? new LeagueBattleType?(this.type) : null);
				}
			}
		}

		// Token: 0x060030D8 RID: 12504 RVA: 0x0005E30C File Offset: 0x0005C50C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060030D9 RID: 12505 RVA: 0x0005E324 File Offset: 0x0005C524
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000F1D RID: 3869
		// (get) Token: 0x060030DA RID: 12506 RVA: 0x0005E330 File Offset: 0x0005C530
		// (set) Token: 0x060030DB RID: 12507 RVA: 0x0005E348 File Offset: 0x0005C548
		[ProtoMember(2, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleTeamData team1
		{
			get
			{
				return this._team1;
			}
			set
			{
				this._team1 = value;
			}
		}

		// Token: 0x17000F1E RID: 3870
		// (get) Token: 0x060030DC RID: 12508 RVA: 0x0005E354 File Offset: 0x0005C554
		// (set) Token: 0x060030DD RID: 12509 RVA: 0x0005E36C File Offset: 0x0005C56C
		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleTeamData team2
		{
			get
			{
				return this._team2;
			}
			set
			{
				this._team2 = value;
			}
		}

		// Token: 0x060030DE RID: 12510 RVA: 0x0005E378 File Offset: 0x0005C578
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C1D RID: 3101
		private LeagueBattleType? _type;

		// Token: 0x04000C1E RID: 3102
		private LeagueBattleTeamData _team1 = null;

		// Token: 0x04000C1F RID: 3103
		private LeagueBattleTeamData _team2 = null;

		// Token: 0x04000C20 RID: 3104
		private IExtension extensionObject;
	}
}
