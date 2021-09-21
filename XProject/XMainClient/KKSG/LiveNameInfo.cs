using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061E RID: 1566
	[ProtoContract(Name = "LiveNameInfo")]
	[Serializable]
	public class LiveNameInfo : IExtensible
	{
		// Token: 0x17001DF8 RID: 7672
		// (get) Token: 0x06005F5E RID: 24414 RVA: 0x000B5E54 File Offset: 0x000B4054
		// (set) Token: 0x06005F5F RID: 24415 RVA: 0x000B5E81 File Offset: 0x000B4081
		[ProtoMember(1, IsRequired = false, Name = "guildID", DataFormat = DataFormat.TwosComplement)]
		public ulong guildID
		{
			get
			{
				return this._guildID ?? 0UL;
			}
			set
			{
				this._guildID = new ulong?(value);
			}
		}

		// Token: 0x17001DF9 RID: 7673
		// (get) Token: 0x06005F60 RID: 24416 RVA: 0x000B5E90 File Offset: 0x000B4090
		// (set) Token: 0x06005F61 RID: 24417 RVA: 0x000B5EB0 File Offset: 0x000B40B0
		[XmlIgnore]
		[Browsable(false)]
		public bool guildIDSpecified
		{
			get
			{
				return this._guildID != null;
			}
			set
			{
				bool flag = value == (this._guildID == null);
				if (flag)
				{
					this._guildID = (value ? new ulong?(this.guildID) : null);
				}
			}
		}

		// Token: 0x06005F62 RID: 24418 RVA: 0x000B5EF4 File Offset: 0x000B40F4
		private bool ShouldSerializeguildID()
		{
			return this.guildIDSpecified;
		}

		// Token: 0x06005F63 RID: 24419 RVA: 0x000B5F0C File Offset: 0x000B410C
		private void ResetguildID()
		{
			this.guildIDSpecified = false;
		}

		// Token: 0x17001DFA RID: 7674
		// (get) Token: 0x06005F64 RID: 24420 RVA: 0x000B5F18 File Offset: 0x000B4118
		// (set) Token: 0x06005F65 RID: 24421 RVA: 0x000B5F39 File Offset: 0x000B4139
		[ProtoMember(2, IsRequired = false, Name = "guildName", DataFormat = DataFormat.Default)]
		public string guildName
		{
			get
			{
				return this._guildName ?? "";
			}
			set
			{
				this._guildName = value;
			}
		}

		// Token: 0x17001DFB RID: 7675
		// (get) Token: 0x06005F66 RID: 24422 RVA: 0x000B5F44 File Offset: 0x000B4144
		// (set) Token: 0x06005F67 RID: 24423 RVA: 0x000B5F60 File Offset: 0x000B4160
		[XmlIgnore]
		[Browsable(false)]
		public bool guildNameSpecified
		{
			get
			{
				return this._guildName != null;
			}
			set
			{
				bool flag = value == (this._guildName == null);
				if (flag)
				{
					this._guildName = (value ? this.guildName : null);
				}
			}
		}

		// Token: 0x06005F68 RID: 24424 RVA: 0x000B5F90 File Offset: 0x000B4190
		private bool ShouldSerializeguildName()
		{
			return this.guildNameSpecified;
		}

		// Token: 0x06005F69 RID: 24425 RVA: 0x000B5FA8 File Offset: 0x000B41A8
		private void ResetguildName()
		{
			this.guildNameSpecified = false;
		}

		// Token: 0x17001DFC RID: 7676
		// (get) Token: 0x06005F6A RID: 24426 RVA: 0x000B5FB4 File Offset: 0x000B41B4
		// (set) Token: 0x06005F6B RID: 24427 RVA: 0x000B5FE0 File Offset: 0x000B41E0
		[ProtoMember(3, IsRequired = false, Name = "guildIcon", DataFormat = DataFormat.TwosComplement)]
		public int guildIcon
		{
			get
			{
				return this._guildIcon ?? 0;
			}
			set
			{
				this._guildIcon = new int?(value);
			}
		}

		// Token: 0x17001DFD RID: 7677
		// (get) Token: 0x06005F6C RID: 24428 RVA: 0x000B5FF0 File Offset: 0x000B41F0
		// (set) Token: 0x06005F6D RID: 24429 RVA: 0x000B6010 File Offset: 0x000B4210
		[XmlIgnore]
		[Browsable(false)]
		public bool guildIconSpecified
		{
			get
			{
				return this._guildIcon != null;
			}
			set
			{
				bool flag = value == (this._guildIcon == null);
				if (flag)
				{
					this._guildIcon = (value ? new int?(this.guildIcon) : null);
				}
			}
		}

		// Token: 0x06005F6E RID: 24430 RVA: 0x000B6054 File Offset: 0x000B4254
		private bool ShouldSerializeguildIcon()
		{
			return this.guildIconSpecified;
		}

		// Token: 0x06005F6F RID: 24431 RVA: 0x000B606C File Offset: 0x000B426C
		private void ResetguildIcon()
		{
			this.guildIconSpecified = false;
		}

		// Token: 0x17001DFE RID: 7678
		// (get) Token: 0x06005F70 RID: 24432 RVA: 0x000B6078 File Offset: 0x000B4278
		// (set) Token: 0x06005F71 RID: 24433 RVA: 0x000B6090 File Offset: 0x000B4290
		[ProtoMember(4, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		// Token: 0x17001DFF RID: 7679
		// (get) Token: 0x06005F72 RID: 24434 RVA: 0x000B609C File Offset: 0x000B429C
		// (set) Token: 0x06005F73 RID: 24435 RVA: 0x000B60BD File Offset: 0x000B42BD
		[ProtoMember(5, IsRequired = false, Name = "teamLeaderName", DataFormat = DataFormat.Default)]
		public string teamLeaderName
		{
			get
			{
				return this._teamLeaderName ?? "";
			}
			set
			{
				this._teamLeaderName = value;
			}
		}

		// Token: 0x17001E00 RID: 7680
		// (get) Token: 0x06005F74 RID: 24436 RVA: 0x000B60C8 File Offset: 0x000B42C8
		// (set) Token: 0x06005F75 RID: 24437 RVA: 0x000B60E4 File Offset: 0x000B42E4
		[XmlIgnore]
		[Browsable(false)]
		public bool teamLeaderNameSpecified
		{
			get
			{
				return this._teamLeaderName != null;
			}
			set
			{
				bool flag = value == (this._teamLeaderName == null);
				if (flag)
				{
					this._teamLeaderName = (value ? this.teamLeaderName : null);
				}
			}
		}

		// Token: 0x06005F76 RID: 24438 RVA: 0x000B6114 File Offset: 0x000B4314
		private bool ShouldSerializeteamLeaderName()
		{
			return this.teamLeaderNameSpecified;
		}

		// Token: 0x06005F77 RID: 24439 RVA: 0x000B612C File Offset: 0x000B432C
		private void ResetteamLeaderName()
		{
			this.teamLeaderNameSpecified = false;
		}

		// Token: 0x17001E01 RID: 7681
		// (get) Token: 0x06005F78 RID: 24440 RVA: 0x000B6138 File Offset: 0x000B4338
		// (set) Token: 0x06005F79 RID: 24441 RVA: 0x000B6164 File Offset: 0x000B4364
		[ProtoMember(6, IsRequired = false, Name = "isLeft", DataFormat = DataFormat.Default)]
		public bool isLeft
		{
			get
			{
				return this._isLeft ?? false;
			}
			set
			{
				this._isLeft = new bool?(value);
			}
		}

		// Token: 0x17001E02 RID: 7682
		// (get) Token: 0x06005F7A RID: 24442 RVA: 0x000B6174 File Offset: 0x000B4374
		// (set) Token: 0x06005F7B RID: 24443 RVA: 0x000B6194 File Offset: 0x000B4394
		[XmlIgnore]
		[Browsable(false)]
		public bool isLeftSpecified
		{
			get
			{
				return this._isLeft != null;
			}
			set
			{
				bool flag = value == (this._isLeft == null);
				if (flag)
				{
					this._isLeft = (value ? new bool?(this.isLeft) : null);
				}
			}
		}

		// Token: 0x06005F7C RID: 24444 RVA: 0x000B61D8 File Offset: 0x000B43D8
		private bool ShouldSerializeisLeft()
		{
			return this.isLeftSpecified;
		}

		// Token: 0x06005F7D RID: 24445 RVA: 0x000B61F0 File Offset: 0x000B43F0
		private void ResetisLeft()
		{
			this.isLeftSpecified = false;
		}

		// Token: 0x17001E03 RID: 7683
		// (get) Token: 0x06005F7E RID: 24446 RVA: 0x000B61FC File Offset: 0x000B43FC
		// (set) Token: 0x06005F7F RID: 24447 RVA: 0x000B621D File Offset: 0x000B441D
		[ProtoMember(7, IsRequired = false, Name = "teamName", DataFormat = DataFormat.Default)]
		public string teamName
		{
			get
			{
				return this._teamName ?? "";
			}
			set
			{
				this._teamName = value;
			}
		}

		// Token: 0x17001E04 RID: 7684
		// (get) Token: 0x06005F80 RID: 24448 RVA: 0x000B6228 File Offset: 0x000B4428
		// (set) Token: 0x06005F81 RID: 24449 RVA: 0x000B6244 File Offset: 0x000B4444
		[XmlIgnore]
		[Browsable(false)]
		public bool teamNameSpecified
		{
			get
			{
				return this._teamName != null;
			}
			set
			{
				bool flag = value == (this._teamName == null);
				if (flag)
				{
					this._teamName = (value ? this.teamName : null);
				}
			}
		}

		// Token: 0x06005F82 RID: 24450 RVA: 0x000B6274 File Offset: 0x000B4474
		private bool ShouldSerializeteamName()
		{
			return this.teamNameSpecified;
		}

		// Token: 0x06005F83 RID: 24451 RVA: 0x000B628C File Offset: 0x000B448C
		private void ResetteamName()
		{
			this.teamNameSpecified = false;
		}

		// Token: 0x17001E05 RID: 7685
		// (get) Token: 0x06005F84 RID: 24452 RVA: 0x000B6298 File Offset: 0x000B4498
		// (set) Token: 0x06005F85 RID: 24453 RVA: 0x000B62C5 File Offset: 0x000B44C5
		[ProtoMember(8, IsRequired = false, Name = "leagueID", DataFormat = DataFormat.TwosComplement)]
		public ulong leagueID
		{
			get
			{
				return this._leagueID ?? 0UL;
			}
			set
			{
				this._leagueID = new ulong?(value);
			}
		}

		// Token: 0x17001E06 RID: 7686
		// (get) Token: 0x06005F86 RID: 24454 RVA: 0x000B62D4 File Offset: 0x000B44D4
		// (set) Token: 0x06005F87 RID: 24455 RVA: 0x000B62F4 File Offset: 0x000B44F4
		[XmlIgnore]
		[Browsable(false)]
		public bool leagueIDSpecified
		{
			get
			{
				return this._leagueID != null;
			}
			set
			{
				bool flag = value == (this._leagueID == null);
				if (flag)
				{
					this._leagueID = (value ? new ulong?(this.leagueID) : null);
				}
			}
		}

		// Token: 0x06005F88 RID: 24456 RVA: 0x000B6338 File Offset: 0x000B4538
		private bool ShouldSerializeleagueID()
		{
			return this.leagueIDSpecified;
		}

		// Token: 0x06005F89 RID: 24457 RVA: 0x000B6350 File Offset: 0x000B4550
		private void ResetleagueID()
		{
			this.leagueIDSpecified = false;
		}

		// Token: 0x17001E07 RID: 7687
		// (get) Token: 0x06005F8A RID: 24458 RVA: 0x000B635C File Offset: 0x000B455C
		// (set) Token: 0x06005F8B RID: 24459 RVA: 0x000B6388 File Offset: 0x000B4588
		[ProtoMember(9, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001E08 RID: 7688
		// (get) Token: 0x06005F8C RID: 24460 RVA: 0x000B6398 File Offset: 0x000B4598
		// (set) Token: 0x06005F8D RID: 24461 RVA: 0x000B63B8 File Offset: 0x000B45B8
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

		// Token: 0x06005F8E RID: 24462 RVA: 0x000B63FC File Offset: 0x000B45FC
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06005F8F RID: 24463 RVA: 0x000B6414 File Offset: 0x000B4614
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x06005F90 RID: 24464 RVA: 0x000B6420 File Offset: 0x000B4620
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400172B RID: 5931
		private ulong? _guildID;

		// Token: 0x0400172C RID: 5932
		private string _guildName;

		// Token: 0x0400172D RID: 5933
		private int? _guildIcon;

		// Token: 0x0400172E RID: 5934
		private RoleBriefInfo _roleInfo = null;

		// Token: 0x0400172F RID: 5935
		private string _teamLeaderName;

		// Token: 0x04001730 RID: 5936
		private bool? _isLeft;

		// Token: 0x04001731 RID: 5937
		private string _teamName;

		// Token: 0x04001732 RID: 5938
		private ulong? _leagueID;

		// Token: 0x04001733 RID: 5939
		private uint? _serverid;

		// Token: 0x04001734 RID: 5940
		private IExtension extensionObject;
	}
}
