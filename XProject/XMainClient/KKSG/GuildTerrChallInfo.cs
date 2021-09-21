using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E6 RID: 1766
	[ProtoContract(Name = "GuildTerrChallInfo")]
	[Serializable]
	public class GuildTerrChallInfo : IExtensible
	{
		// Token: 0x1700255F RID: 9567
		// (get) Token: 0x06007608 RID: 30216 RVA: 0x000E1D54 File Offset: 0x000DFF54
		// (set) Token: 0x06007609 RID: 30217 RVA: 0x000E1D81 File Offset: 0x000DFF81
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17002560 RID: 9568
		// (get) Token: 0x0600760A RID: 30218 RVA: 0x000E1D90 File Offset: 0x000DFF90
		// (set) Token: 0x0600760B RID: 30219 RVA: 0x000E1DB0 File Offset: 0x000DFFB0
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x0600760C RID: 30220 RVA: 0x000E1DF4 File Offset: 0x000DFFF4
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x0600760D RID: 30221 RVA: 0x000E1E0C File Offset: 0x000E000C
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002561 RID: 9569
		// (get) Token: 0x0600760E RID: 30222 RVA: 0x000E1E18 File Offset: 0x000E0018
		// (set) Token: 0x0600760F RID: 30223 RVA: 0x000E1E39 File Offset: 0x000E0039
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x17002562 RID: 9570
		// (get) Token: 0x06007610 RID: 30224 RVA: 0x000E1E44 File Offset: 0x000E0044
		// (set) Token: 0x06007611 RID: 30225 RVA: 0x000E1E60 File Offset: 0x000E0060
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06007612 RID: 30226 RVA: 0x000E1E90 File Offset: 0x000E0090
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007613 RID: 30227 RVA: 0x000E1EA8 File Offset: 0x000E00A8
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002563 RID: 9571
		// (get) Token: 0x06007614 RID: 30228 RVA: 0x000E1EB4 File Offset: 0x000E00B4
		// (set) Token: 0x06007615 RID: 30229 RVA: 0x000E1EE1 File Offset: 0x000E00E1
		[ProtoMember(3, IsRequired = false, Name = "allianceid", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceid
		{
			get
			{
				return this._allianceid ?? 0UL;
			}
			set
			{
				this._allianceid = new ulong?(value);
			}
		}

		// Token: 0x17002564 RID: 9572
		// (get) Token: 0x06007616 RID: 30230 RVA: 0x000E1EF0 File Offset: 0x000E00F0
		// (set) Token: 0x06007617 RID: 30231 RVA: 0x000E1F10 File Offset: 0x000E0110
		[XmlIgnore]
		[Browsable(false)]
		public bool allianceidSpecified
		{
			get
			{
				return this._allianceid != null;
			}
			set
			{
				bool flag = value == (this._allianceid == null);
				if (flag)
				{
					this._allianceid = (value ? new ulong?(this.allianceid) : null);
				}
			}
		}

		// Token: 0x06007618 RID: 30232 RVA: 0x000E1F54 File Offset: 0x000E0154
		private bool ShouldSerializeallianceid()
		{
			return this.allianceidSpecified;
		}

		// Token: 0x06007619 RID: 30233 RVA: 0x000E1F6C File Offset: 0x000E016C
		private void Resetallianceid()
		{
			this.allianceidSpecified = false;
		}

		// Token: 0x17002565 RID: 9573
		// (get) Token: 0x0600761A RID: 30234 RVA: 0x000E1F78 File Offset: 0x000E0178
		[ProtoMember(4, Name = "tryallianceid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> tryallianceid
		{
			get
			{
				return this._tryallianceid;
			}
		}

		// Token: 0x0600761B RID: 30235 RVA: 0x000E1F90 File Offset: 0x000E0190
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BFC RID: 7164
		private ulong? _guildid;

		// Token: 0x04001BFD RID: 7165
		private string _guildname;

		// Token: 0x04001BFE RID: 7166
		private ulong? _allianceid;

		// Token: 0x04001BFF RID: 7167
		private readonly List<ulong> _tryallianceid = new List<ulong>();

		// Token: 0x04001C00 RID: 7168
		private IExtension extensionObject;
	}
}
