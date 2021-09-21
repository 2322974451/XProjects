using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000191 RID: 401
	[ProtoContract(Name = "AskGuildArenaInfoReq")]
	[Serializable]
	public class AskGuildArenaInfoReq : IExtensible
	{
		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06001827 RID: 6183 RVA: 0x0003027C File Offset: 0x0002E47C
		[ProtoMember(1, Name = "warData", DataFormat = DataFormat.Default)]
		public List<guildArenaWarData> warData
		{
			get
			{
				return this._warData;
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06001828 RID: 6184 RVA: 0x00030294 File Offset: 0x0002E494
		[ProtoMember(2, Name = "allguildInfo", DataFormat = DataFormat.Default)]
		public List<GuildInfo> allguildInfo
		{
			get
			{
				return this._allguildInfo;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06001829 RID: 6185 RVA: 0x000302AC File Offset: 0x0002E4AC
		// (set) Token: 0x0600182A RID: 6186 RVA: 0x000302D8 File Offset: 0x0002E4D8
		[ProtoMember(3, IsRequired = false, Name = "timeState", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState timeState
		{
			get
			{
				return this._timeState ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._timeState = new GuildArenaState?(value);
			}
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x0600182B RID: 6187 RVA: 0x000302E8 File Offset: 0x0002E4E8
		// (set) Token: 0x0600182C RID: 6188 RVA: 0x00030308 File Offset: 0x0002E508
		[XmlIgnore]
		[Browsable(false)]
		public bool timeStateSpecified
		{
			get
			{
				return this._timeState != null;
			}
			set
			{
				bool flag = value == (this._timeState == null);
				if (flag)
				{
					this._timeState = (value ? new GuildArenaState?(this.timeState) : null);
				}
			}
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x0003034C File Offset: 0x0002E54C
		private bool ShouldSerializetimeState()
		{
			return this.timeStateSpecified;
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x00030364 File Offset: 0x0002E564
		private void ResettimeState()
		{
			this.timeStateSpecified = false;
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x0600182F RID: 6191 RVA: 0x00030370 File Offset: 0x0002E570
		// (set) Token: 0x06001830 RID: 6192 RVA: 0x0003039C File Offset: 0x0002E59C
		[ProtoMember(4, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06001831 RID: 6193 RVA: 0x000303AC File Offset: 0x0002E5AC
		// (set) Token: 0x06001832 RID: 6194 RVA: 0x000303CC File Offset: 0x0002E5CC
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

		// Token: 0x06001833 RID: 6195 RVA: 0x00030410 File Offset: 0x0002E610
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x00030428 File Offset: 0x0002E628
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x00030434 File Offset: 0x0002E634
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005F7 RID: 1527
		private readonly List<guildArenaWarData> _warData = new List<guildArenaWarData>();

		// Token: 0x040005F8 RID: 1528
		private readonly List<GuildInfo> _allguildInfo = new List<GuildInfo>();

		// Token: 0x040005F9 RID: 1529
		private GuildArenaState? _timeState;

		// Token: 0x040005FA RID: 1530
		private ErrorCode? _errorcode;

		// Token: 0x040005FB RID: 1531
		private IExtension extensionObject;
	}
}
