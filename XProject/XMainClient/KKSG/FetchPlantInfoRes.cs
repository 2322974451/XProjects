using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024F RID: 591
	[ProtoContract(Name = "FetchPlantInfoRes")]
	[Serializable]
	public class FetchPlantInfoRes : IExtensible
	{
		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x0600211E RID: 8478 RVA: 0x00040DDC File Offset: 0x0003EFDC
		// (set) Token: 0x0600211F RID: 8479 RVA: 0x00040E08 File Offset: 0x0003F008
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

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06002120 RID: 8480 RVA: 0x00040E18 File Offset: 0x0003F018
		// (set) Token: 0x06002121 RID: 8481 RVA: 0x00040E38 File Offset: 0x0003F038
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

		// Token: 0x06002122 RID: 8482 RVA: 0x00040E7C File Offset: 0x0003F07C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x00040E94 File Offset: 0x0003F094
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06002124 RID: 8484 RVA: 0x00040EA0 File Offset: 0x0003F0A0
		[ProtoMember(2, Name = "plant_info", DataFormat = DataFormat.Default)]
		public List<PlantInfo> plant_info
		{
			get
			{
				return this._plant_info;
			}
		}

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06002125 RID: 8485 RVA: 0x00040EB8 File Offset: 0x0003F0B8
		// (set) Token: 0x06002126 RID: 8486 RVA: 0x00040EE4 File Offset: 0x0003F0E4
		[ProtoMember(3, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06002127 RID: 8487 RVA: 0x00040EF4 File Offset: 0x0003F0F4
		// (set) Token: 0x06002128 RID: 8488 RVA: 0x00040F14 File Offset: 0x0003F114
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

		// Token: 0x06002129 RID: 8489 RVA: 0x00040F58 File Offset: 0x0003F158
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x0600212A RID: 8490 RVA: 0x00040F70 File Offset: 0x0003F170
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x0600212B RID: 8491 RVA: 0x00040F7C File Offset: 0x0003F17C
		[ProtoMember(4, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> farmland_id
		{
			get
			{
				return this._farmland_id;
			}
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x00040F94 File Offset: 0x0003F194
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400083B RID: 2107
		private ErrorCode? _result;

		// Token: 0x0400083C RID: 2108
		private readonly List<PlantInfo> _plant_info = new List<PlantInfo>();

		// Token: 0x0400083D RID: 2109
		private uint? _sprite_id;

		// Token: 0x0400083E RID: 2110
		private readonly List<uint> _farmland_id = new List<uint>();

		// Token: 0x0400083F RID: 2111
		private IExtension extensionObject;
	}
}
