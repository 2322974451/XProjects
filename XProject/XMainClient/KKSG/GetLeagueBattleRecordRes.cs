using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039A RID: 922
	[ProtoContract(Name = "GetLeagueBattleRecordRes")]
	[Serializable]
	public class GetLeagueBattleRecordRes : IExtensible
	{
		// Token: 0x17000F5F RID: 3935
		// (get) Token: 0x060031C2 RID: 12738 RVA: 0x0005FD0C File Offset: 0x0005DF0C
		// (set) Token: 0x060031C3 RID: 12739 RVA: 0x0005FD38 File Offset: 0x0005DF38
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000F60 RID: 3936
		// (get) Token: 0x060031C4 RID: 12740 RVA: 0x0005FD48 File Offset: 0x0005DF48
		// (set) Token: 0x060031C5 RID: 12741 RVA: 0x0005FD68 File Offset: 0x0005DF68
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060031C6 RID: 12742 RVA: 0x0005FDAC File Offset: 0x0005DFAC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060031C7 RID: 12743 RVA: 0x0005FDC4 File Offset: 0x0005DFC4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000F61 RID: 3937
		// (get) Token: 0x060031C8 RID: 12744 RVA: 0x0005FDD0 File Offset: 0x0005DFD0
		// (set) Token: 0x060031C9 RID: 12745 RVA: 0x0005FDFC File Offset: 0x0005DFFC
		[ProtoMember(2, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		// Token: 0x17000F62 RID: 3938
		// (get) Token: 0x060031CA RID: 12746 RVA: 0x0005FE0C File Offset: 0x0005E00C
		// (set) Token: 0x060031CB RID: 12747 RVA: 0x0005FE2C File Offset: 0x0005E02C
		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		// Token: 0x060031CC RID: 12748 RVA: 0x0005FE70 File Offset: 0x0005E070
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x060031CD RID: 12749 RVA: 0x0005FE88 File Offset: 0x0005E088
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x17000F63 RID: 3939
		// (get) Token: 0x060031CE RID: 12750 RVA: 0x0005FE94 File Offset: 0x0005E094
		// (set) Token: 0x060031CF RID: 12751 RVA: 0x0005FEC0 File Offset: 0x0005E0C0
		[ProtoMember(3, IsRequired = false, Name = "losenum", DataFormat = DataFormat.TwosComplement)]
		public uint losenum
		{
			get
			{
				return this._losenum ?? 0U;
			}
			set
			{
				this._losenum = new uint?(value);
			}
		}

		// Token: 0x17000F64 RID: 3940
		// (get) Token: 0x060031D0 RID: 12752 RVA: 0x0005FED0 File Offset: 0x0005E0D0
		// (set) Token: 0x060031D1 RID: 12753 RVA: 0x0005FEF0 File Offset: 0x0005E0F0
		[XmlIgnore]
		[Browsable(false)]
		public bool losenumSpecified
		{
			get
			{
				return this._losenum != null;
			}
			set
			{
				bool flag = value == (this._losenum == null);
				if (flag)
				{
					this._losenum = (value ? new uint?(this.losenum) : null);
				}
			}
		}

		// Token: 0x060031D2 RID: 12754 RVA: 0x0005FF34 File Offset: 0x0005E134
		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x0005FF4C File Offset: 0x0005E14C
		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		// Token: 0x17000F65 RID: 3941
		// (get) Token: 0x060031D4 RID: 12756 RVA: 0x0005FF58 File Offset: 0x0005E158
		// (set) Token: 0x060031D5 RID: 12757 RVA: 0x0005FF88 File Offset: 0x0005E188
		[ProtoMember(4, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x17000F66 RID: 3942
		// (get) Token: 0x060031D6 RID: 12758 RVA: 0x0005FF98 File Offset: 0x0005E198
		// (set) Token: 0x060031D7 RID: 12759 RVA: 0x0005FFB8 File Offset: 0x0005E1B8
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x0005FFFC File Offset: 0x0005E1FC
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x00060014 File Offset: 0x0005E214
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x060031DA RID: 12762 RVA: 0x00060020 File Offset: 0x0005E220
		// (set) Token: 0x060031DB RID: 12763 RVA: 0x0006004C File Offset: 0x0005E24C
		[ProtoMember(5, IsRequired = false, Name = "max_continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuewin
		{
			get
			{
				return this._max_continuewin ?? 0U;
			}
			set
			{
				this._max_continuewin = new uint?(value);
			}
		}

		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x060031DC RID: 12764 RVA: 0x0006005C File Offset: 0x0005E25C
		// (set) Token: 0x060031DD RID: 12765 RVA: 0x0006007C File Offset: 0x0005E27C
		[XmlIgnore]
		[Browsable(false)]
		public bool max_continuewinSpecified
		{
			get
			{
				return this._max_continuewin != null;
			}
			set
			{
				bool flag = value == (this._max_continuewin == null);
				if (flag)
				{
					this._max_continuewin = (value ? new uint?(this.max_continuewin) : null);
				}
			}
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000600C0 File Offset: 0x0005E2C0
		private bool ShouldSerializemax_continuewin()
		{
			return this.max_continuewinSpecified;
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x000600D8 File Offset: 0x0005E2D8
		private void Resetmax_continuewin()
		{
			this.max_continuewinSpecified = false;
		}

		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x060031E0 RID: 12768 RVA: 0x000600E4 File Offset: 0x0005E2E4
		// (set) Token: 0x060031E1 RID: 12769 RVA: 0x00060110 File Offset: 0x0005E310
		[ProtoMember(6, IsRequired = false, Name = "max_continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuelose
		{
			get
			{
				return this._max_continuelose ?? 0U;
			}
			set
			{
				this._max_continuelose = new uint?(value);
			}
		}

		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x060031E2 RID: 12770 RVA: 0x00060120 File Offset: 0x0005E320
		// (set) Token: 0x060031E3 RID: 12771 RVA: 0x00060140 File Offset: 0x0005E340
		[XmlIgnore]
		[Browsable(false)]
		public bool max_continueloseSpecified
		{
			get
			{
				return this._max_continuelose != null;
			}
			set
			{
				bool flag = value == (this._max_continuelose == null);
				if (flag)
				{
					this._max_continuelose = (value ? new uint?(this.max_continuelose) : null);
				}
			}
		}

		// Token: 0x060031E4 RID: 12772 RVA: 0x00060184 File Offset: 0x0005E384
		private bool ShouldSerializemax_continuelose()
		{
			return this.max_continueloseSpecified;
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x0006019C File Offset: 0x0005E39C
		private void Resetmax_continuelose()
		{
			this.max_continueloseSpecified = false;
		}

		// Token: 0x17000F6B RID: 3947
		// (get) Token: 0x060031E6 RID: 12774 RVA: 0x000601A8 File Offset: 0x0005E3A8
		[ProtoMember(7, Name = "records", DataFormat = DataFormat.Default)]
		public List<LeagueBattleOneRecord> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x060031E7 RID: 12775 RVA: 0x000601C0 File Offset: 0x0005E3C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C5B RID: 3163
		private ErrorCode? _result;

		// Token: 0x04000C5C RID: 3164
		private uint? _winnum;

		// Token: 0x04000C5D RID: 3165
		private uint? _losenum;

		// Token: 0x04000C5E RID: 3166
		private float? _winrate;

		// Token: 0x04000C5F RID: 3167
		private uint? _max_continuewin;

		// Token: 0x04000C60 RID: 3168
		private uint? _max_continuelose;

		// Token: 0x04000C61 RID: 3169
		private readonly List<LeagueBattleOneRecord> _records = new List<LeagueBattleOneRecord>();

		// Token: 0x04000C62 RID: 3170
		private IExtension extensionObject;
	}
}
