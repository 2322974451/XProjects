using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D5 RID: 725
	[ProtoContract(Name = "GetGuildDonateInfoRes")]
	[Serializable]
	public class GetGuildDonateInfoRes : IExtensible
	{
		// Token: 0x17000C6A RID: 3178
		// (get) Token: 0x060027F1 RID: 10225 RVA: 0x0004DA24 File Offset: 0x0004BC24
		// (set) Token: 0x060027F2 RID: 10226 RVA: 0x0004DA50 File Offset: 0x0004BC50
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

		// Token: 0x17000C6B RID: 3179
		// (get) Token: 0x060027F3 RID: 10227 RVA: 0x0004DA60 File Offset: 0x0004BC60
		// (set) Token: 0x060027F4 RID: 10228 RVA: 0x0004DA80 File Offset: 0x0004BC80
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

		// Token: 0x060027F5 RID: 10229 RVA: 0x0004DAC4 File Offset: 0x0004BCC4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060027F6 RID: 10230 RVA: 0x0004DADC File Offset: 0x0004BCDC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000C6C RID: 3180
		// (get) Token: 0x060027F7 RID: 10231 RVA: 0x0004DAE8 File Offset: 0x0004BCE8
		[ProtoMember(2, Name = "info", DataFormat = DataFormat.Default)]
		public List<GuildMemberAskInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x17000C6D RID: 3181
		// (get) Token: 0x060027F8 RID: 10232 RVA: 0x0004DB00 File Offset: 0x0004BD00
		[ProtoMember(3, Name = "rankitem", DataFormat = DataFormat.Default)]
		public List<GuildMemberDonateRankItem> rankitem
		{
			get
			{
				return this._rankitem;
			}
		}

		// Token: 0x17000C6E RID: 3182
		// (get) Token: 0x060027F9 RID: 10233 RVA: 0x0004DB18 File Offset: 0x0004BD18
		// (set) Token: 0x060027FA RID: 10234 RVA: 0x0004DB44 File Offset: 0x0004BD44
		[ProtoMember(4, IsRequired = false, Name = "donatenum", DataFormat = DataFormat.TwosComplement)]
		public uint donatenum
		{
			get
			{
				return this._donatenum ?? 0U;
			}
			set
			{
				this._donatenum = new uint?(value);
			}
		}

		// Token: 0x17000C6F RID: 3183
		// (get) Token: 0x060027FB RID: 10235 RVA: 0x0004DB54 File Offset: 0x0004BD54
		// (set) Token: 0x060027FC RID: 10236 RVA: 0x0004DB74 File Offset: 0x0004BD74
		[XmlIgnore]
		[Browsable(false)]
		public bool donatenumSpecified
		{
			get
			{
				return this._donatenum != null;
			}
			set
			{
				bool flag = value == (this._donatenum == null);
				if (flag)
				{
					this._donatenum = (value ? new uint?(this.donatenum) : null);
				}
			}
		}

		// Token: 0x060027FD RID: 10237 RVA: 0x0004DBB8 File Offset: 0x0004BDB8
		private bool ShouldSerializedonatenum()
		{
			return this.donatenumSpecified;
		}

		// Token: 0x060027FE RID: 10238 RVA: 0x0004DBD0 File Offset: 0x0004BDD0
		private void Resetdonatenum()
		{
			this.donatenumSpecified = false;
		}

		// Token: 0x060027FF RID: 10239 RVA: 0x0004DBDC File Offset: 0x0004BDDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009F0 RID: 2544
		private ErrorCode? _result;

		// Token: 0x040009F1 RID: 2545
		private readonly List<GuildMemberAskInfo> _info = new List<GuildMemberAskInfo>();

		// Token: 0x040009F2 RID: 2546
		private readonly List<GuildMemberDonateRankItem> _rankitem = new List<GuildMemberDonateRankItem>();

		// Token: 0x040009F3 RID: 2547
		private uint? _donatenum;

		// Token: 0x040009F4 RID: 2548
		private IExtension extensionObject;
	}
}
