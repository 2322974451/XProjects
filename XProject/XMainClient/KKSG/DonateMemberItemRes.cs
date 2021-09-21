using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D7 RID: 727
	[ProtoContract(Name = "DonateMemberItemRes")]
	[Serializable]
	public class DonateMemberItemRes : IExtensible
	{
		// Token: 0x17000C75 RID: 3189
		// (get) Token: 0x06002810 RID: 10256 RVA: 0x0004DDE4 File Offset: 0x0004BFE4
		// (set) Token: 0x06002811 RID: 10257 RVA: 0x0004DE10 File Offset: 0x0004C010
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

		// Token: 0x17000C76 RID: 3190
		// (get) Token: 0x06002812 RID: 10258 RVA: 0x0004DE20 File Offset: 0x0004C020
		// (set) Token: 0x06002813 RID: 10259 RVA: 0x0004DE40 File Offset: 0x0004C040
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

		// Token: 0x06002814 RID: 10260 RVA: 0x0004DE84 File Offset: 0x0004C084
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002815 RID: 10261 RVA: 0x0004DE9C File Offset: 0x0004C09C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000C77 RID: 3191
		// (get) Token: 0x06002816 RID: 10262 RVA: 0x0004DEA8 File Offset: 0x0004C0A8
		// (set) Token: 0x06002817 RID: 10263 RVA: 0x0004DED4 File Offset: 0x0004C0D4
		[ProtoMember(2, IsRequired = false, Name = "dailycount", DataFormat = DataFormat.TwosComplement)]
		public uint dailycount
		{
			get
			{
				return this._dailycount ?? 0U;
			}
			set
			{
				this._dailycount = new uint?(value);
			}
		}

		// Token: 0x17000C78 RID: 3192
		// (get) Token: 0x06002818 RID: 10264 RVA: 0x0004DEE4 File Offset: 0x0004C0E4
		// (set) Token: 0x06002819 RID: 10265 RVA: 0x0004DF04 File Offset: 0x0004C104
		[XmlIgnore]
		[Browsable(false)]
		public bool dailycountSpecified
		{
			get
			{
				return this._dailycount != null;
			}
			set
			{
				bool flag = value == (this._dailycount == null);
				if (flag)
				{
					this._dailycount = (value ? new uint?(this.dailycount) : null);
				}
			}
		}

		// Token: 0x0600281A RID: 10266 RVA: 0x0004DF48 File Offset: 0x0004C148
		private bool ShouldSerializedailycount()
		{
			return this.dailycountSpecified;
		}

		// Token: 0x0600281B RID: 10267 RVA: 0x0004DF60 File Offset: 0x0004C160
		private void Resetdailycount()
		{
			this.dailycountSpecified = false;
		}

		// Token: 0x17000C79 RID: 3193
		// (get) Token: 0x0600281C RID: 10268 RVA: 0x0004DF6C File Offset: 0x0004C16C
		// (set) Token: 0x0600281D RID: 10269 RVA: 0x0004DF98 File Offset: 0x0004C198
		[ProtoMember(3, IsRequired = false, Name = "totalcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalcount
		{
			get
			{
				return this._totalcount ?? 0U;
			}
			set
			{
				this._totalcount = new uint?(value);
			}
		}

		// Token: 0x17000C7A RID: 3194
		// (get) Token: 0x0600281E RID: 10270 RVA: 0x0004DFA8 File Offset: 0x0004C1A8
		// (set) Token: 0x0600281F RID: 10271 RVA: 0x0004DFC8 File Offset: 0x0004C1C8
		[XmlIgnore]
		[Browsable(false)]
		public bool totalcountSpecified
		{
			get
			{
				return this._totalcount != null;
			}
			set
			{
				bool flag = value == (this._totalcount == null);
				if (flag)
				{
					this._totalcount = (value ? new uint?(this.totalcount) : null);
				}
			}
		}

		// Token: 0x06002820 RID: 10272 RVA: 0x0004E00C File Offset: 0x0004C20C
		private bool ShouldSerializetotalcount()
		{
			return this.totalcountSpecified;
		}

		// Token: 0x06002821 RID: 10273 RVA: 0x0004E024 File Offset: 0x0004C224
		private void Resettotalcount()
		{
			this.totalcountSpecified = false;
		}

		// Token: 0x17000C7B RID: 3195
		// (get) Token: 0x06002822 RID: 10274 RVA: 0x0004E030 File Offset: 0x0004C230
		[ProtoMember(4, Name = "rankitem", DataFormat = DataFormat.Default)]
		public List<GuildMemberDonateRankItem> rankitem
		{
			get
			{
				return this._rankitem;
			}
		}

		// Token: 0x17000C7C RID: 3196
		// (get) Token: 0x06002823 RID: 10275 RVA: 0x0004E048 File Offset: 0x0004C248
		// (set) Token: 0x06002824 RID: 10276 RVA: 0x0004E074 File Offset: 0x0004C274
		[ProtoMember(5, IsRequired = false, Name = "getcount", DataFormat = DataFormat.TwosComplement)]
		public uint getcount
		{
			get
			{
				return this._getcount ?? 0U;
			}
			set
			{
				this._getcount = new uint?(value);
			}
		}

		// Token: 0x17000C7D RID: 3197
		// (get) Token: 0x06002825 RID: 10277 RVA: 0x0004E084 File Offset: 0x0004C284
		// (set) Token: 0x06002826 RID: 10278 RVA: 0x0004E0A4 File Offset: 0x0004C2A4
		[XmlIgnore]
		[Browsable(false)]
		public bool getcountSpecified
		{
			get
			{
				return this._getcount != null;
			}
			set
			{
				bool flag = value == (this._getcount == null);
				if (flag)
				{
					this._getcount = (value ? new uint?(this.getcount) : null);
				}
			}
		}

		// Token: 0x06002827 RID: 10279 RVA: 0x0004E0E8 File Offset: 0x0004C2E8
		private bool ShouldSerializegetcount()
		{
			return this.getcountSpecified;
		}

		// Token: 0x06002828 RID: 10280 RVA: 0x0004E100 File Offset: 0x0004C300
		private void Resetgetcount()
		{
			this.getcountSpecified = false;
		}

		// Token: 0x06002829 RID: 10281 RVA: 0x0004E10C File Offset: 0x0004C30C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009F9 RID: 2553
		private ErrorCode? _result;

		// Token: 0x040009FA RID: 2554
		private uint? _dailycount;

		// Token: 0x040009FB RID: 2555
		private uint? _totalcount;

		// Token: 0x040009FC RID: 2556
		private readonly List<GuildMemberDonateRankItem> _rankitem = new List<GuildMemberDonateRankItem>();

		// Token: 0x040009FD RID: 2557
		private uint? _getcount;

		// Token: 0x040009FE RID: 2558
		private IExtension extensionObject;
	}
}
