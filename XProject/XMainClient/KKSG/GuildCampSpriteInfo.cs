using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000713 RID: 1811
	[ProtoContract(Name = "GuildCampSpriteInfo")]
	[Serializable]
	public class GuildCampSpriteInfo : IExtensible
	{
		// Token: 0x170026FC RID: 9980
		// (get) Token: 0x06007B01 RID: 31489 RVA: 0x000EB1EC File Offset: 0x000E93EC
		// (set) Token: 0x06007B02 RID: 31490 RVA: 0x000EB218 File Offset: 0x000E9418
		[ProtoMember(1, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		// Token: 0x170026FD RID: 9981
		// (get) Token: 0x06007B03 RID: 31491 RVA: 0x000EB228 File Offset: 0x000E9428
		// (set) Token: 0x06007B04 RID: 31492 RVA: 0x000EB248 File Offset: 0x000E9448
		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		// Token: 0x06007B05 RID: 31493 RVA: 0x000EB28C File Offset: 0x000E948C
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x06007B06 RID: 31494 RVA: 0x000EB2A4 File Offset: 0x000E94A4
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x170026FE RID: 9982
		// (get) Token: 0x06007B07 RID: 31495 RVA: 0x000EB2B0 File Offset: 0x000E94B0
		// (set) Token: 0x06007B08 RID: 31496 RVA: 0x000EB2DC File Offset: 0x000E94DC
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		// Token: 0x170026FF RID: 9983
		// (get) Token: 0x06007B09 RID: 31497 RVA: 0x000EB2EC File Offset: 0x000E94EC
		// (set) Token: 0x06007B0A RID: 31498 RVA: 0x000EB30C File Offset: 0x000E950C
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		// Token: 0x06007B0B RID: 31499 RVA: 0x000EB350 File Offset: 0x000E9550
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06007B0C RID: 31500 RVA: 0x000EB368 File Offset: 0x000E9568
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x17002700 RID: 9984
		// (get) Token: 0x06007B0D RID: 31501 RVA: 0x000EB374 File Offset: 0x000E9574
		// (set) Token: 0x06007B0E RID: 31502 RVA: 0x000EB395 File Offset: 0x000E9595
		[ProtoMember(3, IsRequired = false, Name = "summoner", DataFormat = DataFormat.Default)]
		public string summoner
		{
			get
			{
				return this._summoner ?? "";
			}
			set
			{
				this._summoner = value;
			}
		}

		// Token: 0x17002701 RID: 9985
		// (get) Token: 0x06007B0F RID: 31503 RVA: 0x000EB3A0 File Offset: 0x000E95A0
		// (set) Token: 0x06007B10 RID: 31504 RVA: 0x000EB3BC File Offset: 0x000E95BC
		[XmlIgnore]
		[Browsable(false)]
		public bool summonerSpecified
		{
			get
			{
				return this._summoner != null;
			}
			set
			{
				bool flag = value == (this._summoner == null);
				if (flag)
				{
					this._summoner = (value ? this.summoner : null);
				}
			}
		}

		// Token: 0x06007B11 RID: 31505 RVA: 0x000EB3EC File Offset: 0x000E95EC
		private bool ShouldSerializesummoner()
		{
			return this.summonerSpecified;
		}

		// Token: 0x06007B12 RID: 31506 RVA: 0x000EB404 File Offset: 0x000E9604
		private void Resetsummoner()
		{
			this.summonerSpecified = false;
		}

		// Token: 0x06007B13 RID: 31507 RVA: 0x000EB410 File Offset: 0x000E9610
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D0B RID: 7435
		private uint? _sprite_id;

		// Token: 0x04001D0C RID: 7436
		private int? _position;

		// Token: 0x04001D0D RID: 7437
		private string _summoner;

		// Token: 0x04001D0E RID: 7438
		private IExtension extensionObject;
	}
}
