using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000692 RID: 1682
	[ProtoContract(Name = "GuildArenaGroupData")]
	[Serializable]
	public class GuildArenaGroupData : IExtensible
	{
		// Token: 0x17002279 RID: 8825
		// (get) Token: 0x06006CEA RID: 27882 RVA: 0x000D0634 File Offset: 0x000CE834
		// (set) Token: 0x06006CEB RID: 27883 RVA: 0x000D0660 File Offset: 0x000CE860
		[ProtoMember(1, IsRequired = false, Name = "battleId", DataFormat = DataFormat.TwosComplement)]
		public uint battleId
		{
			get
			{
				return this._battleId ?? 0U;
			}
			set
			{
				this._battleId = new uint?(value);
			}
		}

		// Token: 0x1700227A RID: 8826
		// (get) Token: 0x06006CEC RID: 27884 RVA: 0x000D0670 File Offset: 0x000CE870
		// (set) Token: 0x06006CED RID: 27885 RVA: 0x000D0690 File Offset: 0x000CE890
		[XmlIgnore]
		[Browsable(false)]
		public bool battleIdSpecified
		{
			get
			{
				return this._battleId != null;
			}
			set
			{
				bool flag = value == (this._battleId == null);
				if (flag)
				{
					this._battleId = (value ? new uint?(this.battleId) : null);
				}
			}
		}

		// Token: 0x06006CEE RID: 27886 RVA: 0x000D06D4 File Offset: 0x000CE8D4
		private bool ShouldSerializebattleId()
		{
			return this.battleIdSpecified;
		}

		// Token: 0x06006CEF RID: 27887 RVA: 0x000D06EC File Offset: 0x000CE8EC
		private void ResetbattleId()
		{
			this.battleIdSpecified = false;
		}

		// Token: 0x1700227B RID: 8827
		// (get) Token: 0x06006CF0 RID: 27888 RVA: 0x000D06F8 File Offset: 0x000CE8F8
		// (set) Token: 0x06006CF1 RID: 27889 RVA: 0x000D0725 File Offset: 0x000CE925
		[ProtoMember(2, IsRequired = false, Name = "guildOneId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildOneId
		{
			get
			{
				return this._guildOneId ?? 0UL;
			}
			set
			{
				this._guildOneId = new ulong?(value);
			}
		}

		// Token: 0x1700227C RID: 8828
		// (get) Token: 0x06006CF2 RID: 27890 RVA: 0x000D0734 File Offset: 0x000CE934
		// (set) Token: 0x06006CF3 RID: 27891 RVA: 0x000D0754 File Offset: 0x000CE954
		[XmlIgnore]
		[Browsable(false)]
		public bool guildOneIdSpecified
		{
			get
			{
				return this._guildOneId != null;
			}
			set
			{
				bool flag = value == (this._guildOneId == null);
				if (flag)
				{
					this._guildOneId = (value ? new ulong?(this.guildOneId) : null);
				}
			}
		}

		// Token: 0x06006CF4 RID: 27892 RVA: 0x000D0798 File Offset: 0x000CE998
		private bool ShouldSerializeguildOneId()
		{
			return this.guildOneIdSpecified;
		}

		// Token: 0x06006CF5 RID: 27893 RVA: 0x000D07B0 File Offset: 0x000CE9B0
		private void ResetguildOneId()
		{
			this.guildOneIdSpecified = false;
		}

		// Token: 0x1700227D RID: 8829
		// (get) Token: 0x06006CF6 RID: 27894 RVA: 0x000D07BC File Offset: 0x000CE9BC
		// (set) Token: 0x06006CF7 RID: 27895 RVA: 0x000D07E9 File Offset: 0x000CE9E9
		[ProtoMember(3, IsRequired = false, Name = "guildTwoId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildTwoId
		{
			get
			{
				return this._guildTwoId ?? 0UL;
			}
			set
			{
				this._guildTwoId = new ulong?(value);
			}
		}

		// Token: 0x1700227E RID: 8830
		// (get) Token: 0x06006CF8 RID: 27896 RVA: 0x000D07F8 File Offset: 0x000CE9F8
		// (set) Token: 0x06006CF9 RID: 27897 RVA: 0x000D0818 File Offset: 0x000CEA18
		[XmlIgnore]
		[Browsable(false)]
		public bool guildTwoIdSpecified
		{
			get
			{
				return this._guildTwoId != null;
			}
			set
			{
				bool flag = value == (this._guildTwoId == null);
				if (flag)
				{
					this._guildTwoId = (value ? new ulong?(this.guildTwoId) : null);
				}
			}
		}

		// Token: 0x06006CFA RID: 27898 RVA: 0x000D085C File Offset: 0x000CEA5C
		private bool ShouldSerializeguildTwoId()
		{
			return this.guildTwoIdSpecified;
		}

		// Token: 0x06006CFB RID: 27899 RVA: 0x000D0874 File Offset: 0x000CEA74
		private void ResetguildTwoId()
		{
			this.guildTwoIdSpecified = false;
		}

		// Token: 0x1700227F RID: 8831
		// (get) Token: 0x06006CFC RID: 27900 RVA: 0x000D0880 File Offset: 0x000CEA80
		// (set) Token: 0x06006CFD RID: 27901 RVA: 0x000D08AD File Offset: 0x000CEAAD
		[ProtoMember(4, IsRequired = false, Name = "winerId", DataFormat = DataFormat.TwosComplement)]
		public ulong winerId
		{
			get
			{
				return this._winerId ?? 0UL;
			}
			set
			{
				this._winerId = new ulong?(value);
			}
		}

		// Token: 0x17002280 RID: 8832
		// (get) Token: 0x06006CFE RID: 27902 RVA: 0x000D08BC File Offset: 0x000CEABC
		// (set) Token: 0x06006CFF RID: 27903 RVA: 0x000D08DC File Offset: 0x000CEADC
		[XmlIgnore]
		[Browsable(false)]
		public bool winerIdSpecified
		{
			get
			{
				return this._winerId != null;
			}
			set
			{
				bool flag = value == (this._winerId == null);
				if (flag)
				{
					this._winerId = (value ? new ulong?(this.winerId) : null);
				}
			}
		}

		// Token: 0x06006D00 RID: 27904 RVA: 0x000D0920 File Offset: 0x000CEB20
		private bool ShouldSerializewinerId()
		{
			return this.winerIdSpecified;
		}

		// Token: 0x06006D01 RID: 27905 RVA: 0x000D0938 File Offset: 0x000CEB38
		private void ResetwinerId()
		{
			this.winerIdSpecified = false;
		}

		// Token: 0x17002281 RID: 8833
		// (get) Token: 0x06006D02 RID: 27906 RVA: 0x000D0944 File Offset: 0x000CEB44
		// (set) Token: 0x06006D03 RID: 27907 RVA: 0x000D0970 File Offset: 0x000CEB70
		[ProtoMember(5, IsRequired = false, Name = "warstate", DataFormat = DataFormat.TwosComplement)]
		public uint warstate
		{
			get
			{
				return this._warstate ?? 0U;
			}
			set
			{
				this._warstate = new uint?(value);
			}
		}

		// Token: 0x17002282 RID: 8834
		// (get) Token: 0x06006D04 RID: 27908 RVA: 0x000D0980 File Offset: 0x000CEB80
		// (set) Token: 0x06006D05 RID: 27909 RVA: 0x000D09A0 File Offset: 0x000CEBA0
		[XmlIgnore]
		[Browsable(false)]
		public bool warstateSpecified
		{
			get
			{
				return this._warstate != null;
			}
			set
			{
				bool flag = value == (this._warstate == null);
				if (flag)
				{
					this._warstate = (value ? new uint?(this.warstate) : null);
				}
			}
		}

		// Token: 0x06006D06 RID: 27910 RVA: 0x000D09E4 File Offset: 0x000CEBE4
		private bool ShouldSerializewarstate()
		{
			return this.warstateSpecified;
		}

		// Token: 0x06006D07 RID: 27911 RVA: 0x000D09FC File Offset: 0x000CEBFC
		private void Resetwarstate()
		{
			this.warstateSpecified = false;
		}

		// Token: 0x17002283 RID: 8835
		// (get) Token: 0x06006D08 RID: 27912 RVA: 0x000D0A08 File Offset: 0x000CEC08
		// (set) Token: 0x06006D09 RID: 27913 RVA: 0x000D0A34 File Offset: 0x000CEC34
		[ProtoMember(6, IsRequired = false, Name = "watchId", DataFormat = DataFormat.TwosComplement)]
		public uint watchId
		{
			get
			{
				return this._watchId ?? 0U;
			}
			set
			{
				this._watchId = new uint?(value);
			}
		}

		// Token: 0x17002284 RID: 8836
		// (get) Token: 0x06006D0A RID: 27914 RVA: 0x000D0A44 File Offset: 0x000CEC44
		// (set) Token: 0x06006D0B RID: 27915 RVA: 0x000D0A64 File Offset: 0x000CEC64
		[XmlIgnore]
		[Browsable(false)]
		public bool watchIdSpecified
		{
			get
			{
				return this._watchId != null;
			}
			set
			{
				bool flag = value == (this._watchId == null);
				if (flag)
				{
					this._watchId = (value ? new uint?(this.watchId) : null);
				}
			}
		}

		// Token: 0x06006D0C RID: 27916 RVA: 0x000D0AA8 File Offset: 0x000CECA8
		private bool ShouldSerializewatchId()
		{
			return this.watchIdSpecified;
		}

		// Token: 0x06006D0D RID: 27917 RVA: 0x000D0AC0 File Offset: 0x000CECC0
		private void ResetwatchId()
		{
			this.watchIdSpecified = false;
		}

		// Token: 0x17002285 RID: 8837
		// (get) Token: 0x06006D0E RID: 27918 RVA: 0x000D0ACC File Offset: 0x000CECCC
		// (set) Token: 0x06006D0F RID: 27919 RVA: 0x000D0AF8 File Offset: 0x000CECF8
		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17002286 RID: 8838
		// (get) Token: 0x06006D10 RID: 27920 RVA: 0x000D0B08 File Offset: 0x000CED08
		// (set) Token: 0x06006D11 RID: 27921 RVA: 0x000D0B28 File Offset: 0x000CED28
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06006D12 RID: 27922 RVA: 0x000D0B6C File Offset: 0x000CED6C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006D13 RID: 27923 RVA: 0x000D0B84 File Offset: 0x000CED84
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06006D14 RID: 27924 RVA: 0x000D0B90 File Offset: 0x000CED90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A21 RID: 6689
		private uint? _battleId;

		// Token: 0x04001A22 RID: 6690
		private ulong? _guildOneId;

		// Token: 0x04001A23 RID: 6691
		private ulong? _guildTwoId;

		// Token: 0x04001A24 RID: 6692
		private ulong? _winerId;

		// Token: 0x04001A25 RID: 6693
		private uint? _warstate;

		// Token: 0x04001A26 RID: 6694
		private uint? _watchId;

		// Token: 0x04001A27 RID: 6695
		private uint? _state;

		// Token: 0x04001A28 RID: 6696
		private IExtension extensionObject;
	}
}
