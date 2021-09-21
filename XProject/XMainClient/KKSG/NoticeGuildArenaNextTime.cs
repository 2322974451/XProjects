using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000278 RID: 632
	[ProtoContract(Name = "NoticeGuildArenaNextTime")]
	[Serializable]
	public class NoticeGuildArenaNextTime : IExtensible
	{
		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06002345 RID: 9029 RVA: 0x00044E20 File Offset: 0x00043020
		// (set) Token: 0x06002346 RID: 9030 RVA: 0x00044E4C File Offset: 0x0004304C
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06002347 RID: 9031 RVA: 0x00044E5C File Offset: 0x0004305C
		// (set) Token: 0x06002348 RID: 9032 RVA: 0x00044E7C File Offset: 0x0004307C
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

		// Token: 0x06002349 RID: 9033 RVA: 0x00044EC0 File Offset: 0x000430C0
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x00044ED8 File Offset: 0x000430D8
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x00044EE4 File Offset: 0x000430E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008C0 RID: 2240
		private GuildArenaState? _state;

		// Token: 0x040008C1 RID: 2241
		private IExtension extensionObject;
	}
}
