using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A2 RID: 418
	[ProtoContract(Name = "AskGuildArenaTeamInfoRes")]
	[Serializable]
	public class AskGuildArenaTeamInfoRes : IExtensible
	{
		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x060018CC RID: 6348 RVA: 0x000314EC File Offset: 0x0002F6EC
		[ProtoMember(1, Name = "fightUnit", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> fightUnit
		{
			get
			{
				return this._fightUnit;
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x060018CD RID: 6349 RVA: 0x00031504 File Offset: 0x0002F704
		[ProtoMember(2, Name = "guildMember", DataFormat = DataFormat.Default)]
		public List<GuildMemberData> guildMember
		{
			get
			{
				return this._guildMember;
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x060018CE RID: 6350 RVA: 0x0003151C File Offset: 0x0002F71C
		// (set) Token: 0x060018CF RID: 6351 RVA: 0x00031548 File Offset: 0x0002F748
		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x060018D0 RID: 6352 RVA: 0x00031558 File Offset: 0x0002F758
		// (set) Token: 0x060018D1 RID: 6353 RVA: 0x00031578 File Offset: 0x0002F778
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x000315BC File Offset: 0x0002F7BC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x000315D4 File Offset: 0x0002F7D4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x000315E0 File Offset: 0x0002F7E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000625 RID: 1573
		private readonly List<GuildDarenaUnit> _fightUnit = new List<GuildDarenaUnit>();

		// Token: 0x04000626 RID: 1574
		private readonly List<GuildMemberData> _guildMember = new List<GuildMemberData>();

		// Token: 0x04000627 RID: 1575
		private ErrorCode? _errorcode;

		// Token: 0x04000628 RID: 1576
		private IExtension extensionObject;
	}
}
