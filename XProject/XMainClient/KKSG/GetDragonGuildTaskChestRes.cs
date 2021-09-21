using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C1 RID: 1217
	[ProtoContract(Name = "GetDragonGuildTaskChestRes")]
	[Serializable]
	public class GetDragonGuildTaskChestRes : IExtensible
	{
		// Token: 0x1700136D RID: 4973
		// (get) Token: 0x06003F66 RID: 16230 RVA: 0x00078E00 File Offset: 0x00077000
		// (set) Token: 0x06003F67 RID: 16231 RVA: 0x00078E2C File Offset: 0x0007702C
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700136E RID: 4974
		// (get) Token: 0x06003F68 RID: 16232 RVA: 0x00078E3C File Offset: 0x0007703C
		// (set) Token: 0x06003F69 RID: 16233 RVA: 0x00078E5C File Offset: 0x0007705C
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

		// Token: 0x06003F6A RID: 16234 RVA: 0x00078EA0 File Offset: 0x000770A0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003F6B RID: 16235 RVA: 0x00078EB8 File Offset: 0x000770B8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700136F RID: 4975
		// (get) Token: 0x06003F6C RID: 16236 RVA: 0x00078EC4 File Offset: 0x000770C4
		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		// Token: 0x17001370 RID: 4976
		// (get) Token: 0x06003F6D RID: 16237 RVA: 0x00078EDC File Offset: 0x000770DC
		[ProtoMember(3, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemCount
		{
			get
			{
				return this._itemCount;
			}
		}

		// Token: 0x17001371 RID: 4977
		// (get) Token: 0x06003F6E RID: 16238 RVA: 0x00078EF4 File Offset: 0x000770F4
		// (set) Token: 0x06003F6F RID: 16239 RVA: 0x00078F20 File Offset: 0x00077120
		[ProtoMember(4, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001372 RID: 4978
		// (get) Token: 0x06003F70 RID: 16240 RVA: 0x00078F30 File Offset: 0x00077130
		// (set) Token: 0x06003F71 RID: 16241 RVA: 0x00078F50 File Offset: 0x00077150
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

		// Token: 0x06003F72 RID: 16242 RVA: 0x00078F94 File Offset: 0x00077194
		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		// Token: 0x06003F73 RID: 16243 RVA: 0x00078FAC File Offset: 0x000771AC
		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		// Token: 0x06003F74 RID: 16244 RVA: 0x00078FB8 File Offset: 0x000771B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FC7 RID: 4039
		private ErrorCode? _errorcode;

		// Token: 0x04000FC8 RID: 4040
		private readonly List<ulong> _itemid = new List<ulong>();

		// Token: 0x04000FC9 RID: 4041
		private readonly List<uint> _itemCount = new List<uint>();

		// Token: 0x04000FCA RID: 4042
		private uint? _guildexp;

		// Token: 0x04000FCB RID: 4043
		private IExtension extensionObject;
	}
}
