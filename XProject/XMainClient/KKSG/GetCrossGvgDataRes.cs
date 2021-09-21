using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052F RID: 1327
	[ProtoContract(Name = "GetCrossGvgDataRes")]
	[Serializable]
	public class GetCrossGvgDataRes : IExtensible
	{
		// Token: 0x170014D9 RID: 5337
		// (get) Token: 0x06004434 RID: 17460 RVA: 0x00081C20 File Offset: 0x0007FE20
		// (set) Token: 0x06004435 RID: 17461 RVA: 0x00081C4C File Offset: 0x0007FE4C
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

		// Token: 0x170014DA RID: 5338
		// (get) Token: 0x06004436 RID: 17462 RVA: 0x00081C5C File Offset: 0x0007FE5C
		// (set) Token: 0x06004437 RID: 17463 RVA: 0x00081C7C File Offset: 0x0007FE7C
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

		// Token: 0x06004438 RID: 17464 RVA: 0x00081CC0 File Offset: 0x0007FEC0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004439 RID: 17465 RVA: 0x00081CD8 File Offset: 0x0007FED8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170014DB RID: 5339
		// (get) Token: 0x0600443A RID: 17466 RVA: 0x00081CE4 File Offset: 0x0007FEE4
		[ProtoMember(2, Name = "rank", DataFormat = DataFormat.Default)]
		public List<CrossGvgGuildInfo> rank
		{
			get
			{
				return this._rank;
			}
		}

		// Token: 0x170014DC RID: 5340
		// (get) Token: 0x0600443B RID: 17467 RVA: 0x00081CFC File Offset: 0x0007FEFC
		[ProtoMember(3, Name = "record", DataFormat = DataFormat.Default)]
		public List<CrossGvgRacePointRecord> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x170014DD RID: 5341
		// (get) Token: 0x0600443C RID: 17468 RVA: 0x00081D14 File Offset: 0x0007FF14
		[ProtoMember(4, Name = "rooms", DataFormat = DataFormat.Default)]
		public List<CrossGvgRoomInfo> rooms
		{
			get
			{
				return this._rooms;
			}
		}

		// Token: 0x170014DE RID: 5342
		// (get) Token: 0x0600443D RID: 17469 RVA: 0x00081D2C File Offset: 0x0007FF2C
		// (set) Token: 0x0600443E RID: 17470 RVA: 0x00081D58 File Offset: 0x0007FF58
		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState state
		{
			get
			{
				return this._state ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._state = new GuildArenaState?(value);
			}
		}

		// Token: 0x170014DF RID: 5343
		// (get) Token: 0x0600443F RID: 17471 RVA: 0x00081D68 File Offset: 0x0007FF68
		// (set) Token: 0x06004440 RID: 17472 RVA: 0x00081D88 File Offset: 0x0007FF88
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
					this._state = (value ? new GuildArenaState?(this.state) : null);
				}
			}
		}

		// Token: 0x06004441 RID: 17473 RVA: 0x00081DCC File Offset: 0x0007FFCC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06004442 RID: 17474 RVA: 0x00081DE4 File Offset: 0x0007FFE4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170014E0 RID: 5344
		// (get) Token: 0x06004443 RID: 17475 RVA: 0x00081DF0 File Offset: 0x0007FFF0
		[ProtoMember(6, Name = "support_guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> support_guildid
		{
			get
			{
				return this._support_guildid;
			}
		}

		// Token: 0x170014E1 RID: 5345
		// (get) Token: 0x06004444 RID: 17476 RVA: 0x00081E08 File Offset: 0x00080008
		// (set) Token: 0x06004445 RID: 17477 RVA: 0x00081E34 File Offset: 0x00080034
		[ProtoMember(7, IsRequired = false, Name = "season_num", DataFormat = DataFormat.TwosComplement)]
		public uint season_num
		{
			get
			{
				return this._season_num ?? 0U;
			}
			set
			{
				this._season_num = new uint?(value);
			}
		}

		// Token: 0x170014E2 RID: 5346
		// (get) Token: 0x06004446 RID: 17478 RVA: 0x00081E44 File Offset: 0x00080044
		// (set) Token: 0x06004447 RID: 17479 RVA: 0x00081E64 File Offset: 0x00080064
		[XmlIgnore]
		[Browsable(false)]
		public bool season_numSpecified
		{
			get
			{
				return this._season_num != null;
			}
			set
			{
				bool flag = value == (this._season_num == null);
				if (flag)
				{
					this._season_num = (value ? new uint?(this.season_num) : null);
				}
			}
		}

		// Token: 0x06004448 RID: 17480 RVA: 0x00081EA8 File Offset: 0x000800A8
		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		// Token: 0x06004449 RID: 17481 RVA: 0x00081EC0 File Offset: 0x000800C0
		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

		// Token: 0x0600444A RID: 17482 RVA: 0x00081ECC File Offset: 0x000800CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001102 RID: 4354
		private ErrorCode? _result;

		// Token: 0x04001103 RID: 4355
		private readonly List<CrossGvgGuildInfo> _rank = new List<CrossGvgGuildInfo>();

		// Token: 0x04001104 RID: 4356
		private readonly List<CrossGvgRacePointRecord> _record = new List<CrossGvgRacePointRecord>();

		// Token: 0x04001105 RID: 4357
		private readonly List<CrossGvgRoomInfo> _rooms = new List<CrossGvgRoomInfo>();

		// Token: 0x04001106 RID: 4358
		private GuildArenaState? _state;

		// Token: 0x04001107 RID: 4359
		private readonly List<ulong> _support_guildid = new List<ulong>();

		// Token: 0x04001108 RID: 4360
		private uint? _season_num;

		// Token: 0x04001109 RID: 4361
		private IExtension extensionObject;
	}
}
