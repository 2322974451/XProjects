using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023F RID: 575
	[ProtoContract(Name = "ReqGuildLadderRnakInfoRes")]
	[Serializable]
	public class ReqGuildLadderRnakInfoRes : IExtensible
	{
		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06001FF7 RID: 8183 RVA: 0x0003EA68 File Offset: 0x0003CC68
		[ProtoMember(1, Name = "guildrank", DataFormat = DataFormat.Default)]
		public List<GuildLadderRank> guildrank
		{
			get
			{
				return this._guildrank;
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06001FF8 RID: 8184 RVA: 0x0003EA80 File Offset: 0x0003CC80
		// (set) Token: 0x06001FF9 RID: 8185 RVA: 0x0003EAAC File Offset: 0x0003CCAC
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06001FFA RID: 8186 RVA: 0x0003EABC File Offset: 0x0003CCBC
		// (set) Token: 0x06001FFB RID: 8187 RVA: 0x0003EADC File Offset: 0x0003CCDC
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

		// Token: 0x06001FFC RID: 8188 RVA: 0x0003EB20 File Offset: 0x0003CD20
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001FFD RID: 8189 RVA: 0x0003EB38 File Offset: 0x0003CD38
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06001FFE RID: 8190 RVA: 0x0003EB44 File Offset: 0x0003CD44
		// (set) Token: 0x06001FFF RID: 8191 RVA: 0x0003EB70 File Offset: 0x0003CD70
		[ProtoMember(3, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastTime
		{
			get
			{
				return this._lastTime ?? 0U;
			}
			set
			{
				this._lastTime = new uint?(value);
			}
		}

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06002000 RID: 8192 RVA: 0x0003EB80 File Offset: 0x0003CD80
		// (set) Token: 0x06002001 RID: 8193 RVA: 0x0003EBA0 File Offset: 0x0003CDA0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastTimeSpecified
		{
			get
			{
				return this._lastTime != null;
			}
			set
			{
				bool flag = value == (this._lastTime == null);
				if (flag)
				{
					this._lastTime = (value ? new uint?(this.lastTime) : null);
				}
			}
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x0003EBE4 File Offset: 0x0003CDE4
		private bool ShouldSerializelastTime()
		{
			return this.lastTimeSpecified;
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x0003EBFC File Offset: 0x0003CDFC
		private void ResetlastTime()
		{
			this.lastTimeSpecified = false;
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x0003EC08 File Offset: 0x0003CE08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007FB RID: 2043
		private readonly List<GuildLadderRank> _guildrank = new List<GuildLadderRank>();

		// Token: 0x040007FC RID: 2044
		private ErrorCode? _errorcode;

		// Token: 0x040007FD RID: 2045
		private uint? _lastTime;

		// Token: 0x040007FE RID: 2046
		private IExtension extensionObject;
	}
}
