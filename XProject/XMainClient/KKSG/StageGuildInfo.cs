using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E1 RID: 1505
	[ProtoContract(Name = "StageGuildInfo")]
	[Serializable]
	public class StageGuildInfo : IExtensible
	{
		// Token: 0x17001B09 RID: 6921
		// (get) Token: 0x0600570F RID: 22287 RVA: 0x000A5CBC File Offset: 0x000A3EBC
		// (set) Token: 0x06005710 RID: 22288 RVA: 0x000A5CE8 File Offset: 0x000A3EE8
		[ProtoMember(1, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
		public uint guildexp
		{
			get
			{
				return this._guildexp ?? 0U;
			}
			set
			{
				this._guildexp = new uint?(value);
			}
		}

		// Token: 0x17001B0A RID: 6922
		// (get) Token: 0x06005711 RID: 22289 RVA: 0x000A5CF8 File Offset: 0x000A3EF8
		// (set) Token: 0x06005712 RID: 22290 RVA: 0x000A5D18 File Offset: 0x000A3F18
		[XmlIgnore]
		[Browsable(false)]
		public bool guildexpSpecified
		{
			get
			{
				return this._guildexp != null;
			}
			set
			{
				bool flag = value == (this._guildexp == null);
				if (flag)
				{
					this._guildexp = (value ? new uint?(this.guildexp) : null);
				}
			}
		}

		// Token: 0x06005713 RID: 22291 RVA: 0x000A5D5C File Offset: 0x000A3F5C
		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		// Token: 0x06005714 RID: 22292 RVA: 0x000A5D74 File Offset: 0x000A3F74
		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		// Token: 0x17001B0B RID: 6923
		// (get) Token: 0x06005715 RID: 22293 RVA: 0x000A5D80 File Offset: 0x000A3F80
		// (set) Token: 0x06005716 RID: 22294 RVA: 0x000A5DAC File Offset: 0x000A3FAC
		[ProtoMember(2, IsRequired = false, Name = "guildcon", DataFormat = DataFormat.TwosComplement)]
		public uint guildcon
		{
			get
			{
				return this._guildcon ?? 0U;
			}
			set
			{
				this._guildcon = new uint?(value);
			}
		}

		// Token: 0x17001B0C RID: 6924
		// (get) Token: 0x06005717 RID: 22295 RVA: 0x000A5DBC File Offset: 0x000A3FBC
		// (set) Token: 0x06005718 RID: 22296 RVA: 0x000A5DDC File Offset: 0x000A3FDC
		[XmlIgnore]
		[Browsable(false)]
		public bool guildconSpecified
		{
			get
			{
				return this._guildcon != null;
			}
			set
			{
				bool flag = value == (this._guildcon == null);
				if (flag)
				{
					this._guildcon = (value ? new uint?(this.guildcon) : null);
				}
			}
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x000A5E20 File Offset: 0x000A4020
		private bool ShouldSerializeguildcon()
		{
			return this.guildconSpecified;
		}

		// Token: 0x0600571A RID: 22298 RVA: 0x000A5E38 File Offset: 0x000A4038
		private void Resetguildcon()
		{
			this.guildconSpecified = false;
		}

		// Token: 0x17001B0D RID: 6925
		// (get) Token: 0x0600571B RID: 22299 RVA: 0x000A5E44 File Offset: 0x000A4044
		// (set) Token: 0x0600571C RID: 22300 RVA: 0x000A5E70 File Offset: 0x000A4070
		[ProtoMember(3, IsRequired = false, Name = "dragon", DataFormat = DataFormat.TwosComplement)]
		public uint dragon
		{
			get
			{
				return this._dragon ?? 0U;
			}
			set
			{
				this._dragon = new uint?(value);
			}
		}

		// Token: 0x17001B0E RID: 6926
		// (get) Token: 0x0600571D RID: 22301 RVA: 0x000A5E80 File Offset: 0x000A4080
		// (set) Token: 0x0600571E RID: 22302 RVA: 0x000A5EA0 File Offset: 0x000A40A0
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonSpecified
		{
			get
			{
				return this._dragon != null;
			}
			set
			{
				bool flag = value == (this._dragon == null);
				if (flag)
				{
					this._dragon = (value ? new uint?(this.dragon) : null);
				}
			}
		}

		// Token: 0x0600571F RID: 22303 RVA: 0x000A5EE4 File Offset: 0x000A40E4
		private bool ShouldSerializedragon()
		{
			return this.dragonSpecified;
		}

		// Token: 0x06005720 RID: 22304 RVA: 0x000A5EFC File Offset: 0x000A40FC
		private void Resetdragon()
		{
			this.dragonSpecified = false;
		}

		// Token: 0x06005721 RID: 22305 RVA: 0x000A5F08 File Offset: 0x000A4108
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001526 RID: 5414
		private uint? _guildexp;

		// Token: 0x04001527 RID: 5415
		private uint? _guildcon;

		// Token: 0x04001528 RID: 5416
		private uint? _dragon;

		// Token: 0x04001529 RID: 5417
		private IExtension extensionObject;
	}
}
