using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CD RID: 1485
	[ProtoContract(Name = "WeekEnd4v4TeamResult")]
	[Serializable]
	public class WeekEnd4v4TeamResult : IExtensible
	{
		// Token: 0x170019F7 RID: 6647
		// (get) Token: 0x060053E0 RID: 21472 RVA: 0x0009F908 File Offset: 0x0009DB08
		// (set) Token: 0x060053E1 RID: 21473 RVA: 0x0009F934 File Offset: 0x0009DB34
		[ProtoMember(1, IsRequired = false, Name = "teamSeconds", DataFormat = DataFormat.TwosComplement)]
		public uint teamSeconds
		{
			get
			{
				return this._teamSeconds ?? 0U;
			}
			set
			{
				this._teamSeconds = new uint?(value);
			}
		}

		// Token: 0x170019F8 RID: 6648
		// (get) Token: 0x060053E2 RID: 21474 RVA: 0x0009F944 File Offset: 0x0009DB44
		// (set) Token: 0x060053E3 RID: 21475 RVA: 0x0009F964 File Offset: 0x0009DB64
		[XmlIgnore]
		[Browsable(false)]
		public bool teamSecondsSpecified
		{
			get
			{
				return this._teamSeconds != null;
			}
			set
			{
				bool flag = value == (this._teamSeconds == null);
				if (flag)
				{
					this._teamSeconds = (value ? new uint?(this.teamSeconds) : null);
				}
			}
		}

		// Token: 0x060053E4 RID: 21476 RVA: 0x0009F9A8 File Offset: 0x0009DBA8
		private bool ShouldSerializeteamSeconds()
		{
			return this.teamSecondsSpecified;
		}

		// Token: 0x060053E5 RID: 21477 RVA: 0x0009F9C0 File Offset: 0x0009DBC0
		private void ResetteamSeconds()
		{
			this.teamSecondsSpecified = false;
		}

		// Token: 0x170019F9 RID: 6649
		// (get) Token: 0x060053E6 RID: 21478 RVA: 0x0009F9CC File Offset: 0x0009DBCC
		// (set) Token: 0x060053E7 RID: 21479 RVA: 0x0009F9F8 File Offset: 0x0009DBF8
		[ProtoMember(2, IsRequired = false, Name = "redTeamScore", DataFormat = DataFormat.TwosComplement)]
		public uint redTeamScore
		{
			get
			{
				return this._redTeamScore ?? 0U;
			}
			set
			{
				this._redTeamScore = new uint?(value);
			}
		}

		// Token: 0x170019FA RID: 6650
		// (get) Token: 0x060053E8 RID: 21480 RVA: 0x0009FA08 File Offset: 0x0009DC08
		// (set) Token: 0x060053E9 RID: 21481 RVA: 0x0009FA28 File Offset: 0x0009DC28
		[XmlIgnore]
		[Browsable(false)]
		public bool redTeamScoreSpecified
		{
			get
			{
				return this._redTeamScore != null;
			}
			set
			{
				bool flag = value == (this._redTeamScore == null);
				if (flag)
				{
					this._redTeamScore = (value ? new uint?(this.redTeamScore) : null);
				}
			}
		}

		// Token: 0x060053EA RID: 21482 RVA: 0x0009FA6C File Offset: 0x0009DC6C
		private bool ShouldSerializeredTeamScore()
		{
			return this.redTeamScoreSpecified;
		}

		// Token: 0x060053EB RID: 21483 RVA: 0x0009FA84 File Offset: 0x0009DC84
		private void ResetredTeamScore()
		{
			this.redTeamScoreSpecified = false;
		}

		// Token: 0x170019FB RID: 6651
		// (get) Token: 0x060053EC RID: 21484 RVA: 0x0009FA90 File Offset: 0x0009DC90
		// (set) Token: 0x060053ED RID: 21485 RVA: 0x0009FABC File Offset: 0x0009DCBC
		[ProtoMember(3, IsRequired = false, Name = "blueTeamScore", DataFormat = DataFormat.TwosComplement)]
		public uint blueTeamScore
		{
			get
			{
				return this._blueTeamScore ?? 0U;
			}
			set
			{
				this._blueTeamScore = new uint?(value);
			}
		}

		// Token: 0x170019FC RID: 6652
		// (get) Token: 0x060053EE RID: 21486 RVA: 0x0009FACC File Offset: 0x0009DCCC
		// (set) Token: 0x060053EF RID: 21487 RVA: 0x0009FAEC File Offset: 0x0009DCEC
		[XmlIgnore]
		[Browsable(false)]
		public bool blueTeamScoreSpecified
		{
			get
			{
				return this._blueTeamScore != null;
			}
			set
			{
				bool flag = value == (this._blueTeamScore == null);
				if (flag)
				{
					this._blueTeamScore = (value ? new uint?(this.blueTeamScore) : null);
				}
			}
		}

		// Token: 0x060053F0 RID: 21488 RVA: 0x0009FB30 File Offset: 0x0009DD30
		private bool ShouldSerializeblueTeamScore()
		{
			return this.blueTeamScoreSpecified;
		}

		// Token: 0x060053F1 RID: 21489 RVA: 0x0009FB48 File Offset: 0x0009DD48
		private void ResetblueTeamScore()
		{
			this.blueTeamScoreSpecified = false;
		}

		// Token: 0x170019FD RID: 6653
		// (get) Token: 0x060053F2 RID: 21490 RVA: 0x0009FB54 File Offset: 0x0009DD54
		[ProtoMember(4, Name = "hasRewardsID", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> hasRewardsID
		{
			get
			{
				return this._hasRewardsID;
			}
		}

		// Token: 0x060053F3 RID: 21491 RVA: 0x0009FB6C File Offset: 0x0009DD6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001479 RID: 5241
		private uint? _teamSeconds;

		// Token: 0x0400147A RID: 5242
		private uint? _redTeamScore;

		// Token: 0x0400147B RID: 5243
		private uint? _blueTeamScore;

		// Token: 0x0400147C RID: 5244
		private readonly List<ulong> _hasRewardsID = new List<ulong>();

		// Token: 0x0400147D RID: 5245
		private IExtension extensionObject;
	}
}
