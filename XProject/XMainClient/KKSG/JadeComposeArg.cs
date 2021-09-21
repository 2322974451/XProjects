using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000040 RID: 64
	[ProtoContract(Name = "JadeComposeArg")]
	[Serializable]
	public class JadeComposeArg : IExtensible
	{
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000AF84 File Offset: 0x00009184
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000AFB0 File Offset: 0x000091B0
		[ProtoMember(1, IsRequired = false, Name = "ComposeType", DataFormat = DataFormat.TwosComplement)]
		public uint ComposeType
		{
			get
			{
				return this._ComposeType ?? 0U;
			}
			set
			{
				this._ComposeType = new uint?(value);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000AFC0 File Offset: 0x000091C0
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x0000AFE0 File Offset: 0x000091E0
		[XmlIgnore]
		[Browsable(false)]
		public bool ComposeTypeSpecified
		{
			get
			{
				return this._ComposeType != null;
			}
			set
			{
				bool flag = value == (this._ComposeType == null);
				if (flag)
				{
					this._ComposeType = (value ? new uint?(this.ComposeType) : null);
				}
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000B024 File Offset: 0x00009224
		private bool ShouldSerializeComposeType()
		{
			return this.ComposeTypeSpecified;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000B03C File Offset: 0x0000923C
		private void ResetComposeType()
		{
			this.ComposeTypeSpecified = false;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000B048 File Offset: 0x00009248
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000B075 File Offset: 0x00009275
		[ProtoMember(2, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong JadeUniqueId
		{
			get
			{
				return this._JadeUniqueId ?? 0UL;
			}
			set
			{
				this._JadeUniqueId = new ulong?(value);
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000B084 File Offset: 0x00009284
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0000B0A4 File Offset: 0x000092A4
		[XmlIgnore]
		[Browsable(false)]
		public bool JadeUniqueIdSpecified
		{
			get
			{
				return this._JadeUniqueId != null;
			}
			set
			{
				bool flag = value == (this._JadeUniqueId == null);
				if (flag)
				{
					this._JadeUniqueId = (value ? new ulong?(this.JadeUniqueId) : null);
				}
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000B0E8 File Offset: 0x000092E8
		private bool ShouldSerializeJadeUniqueId()
		{
			return this.JadeUniqueIdSpecified;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000B100 File Offset: 0x00009300
		private void ResetJadeUniqueId()
		{
			this.JadeUniqueIdSpecified = false;
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000B10C File Offset: 0x0000930C
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0000B139 File Offset: 0x00009339
		[ProtoMember(3, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong EquipUniqueId
		{
			get
			{
				return this._EquipUniqueId ?? 0UL;
			}
			set
			{
				this._EquipUniqueId = new ulong?(value);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000B148 File Offset: 0x00009348
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x0000B168 File Offset: 0x00009368
		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUniqueIdSpecified
		{
			get
			{
				return this._EquipUniqueId != null;
			}
			set
			{
				bool flag = value == (this._EquipUniqueId == null);
				if (flag)
				{
					this._EquipUniqueId = (value ? new ulong?(this.EquipUniqueId) : null);
				}
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000B1AC File Offset: 0x000093AC
		private bool ShouldSerializeEquipUniqueId()
		{
			return this.EquipUniqueIdSpecified;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000B1C4 File Offset: 0x000093C4
		private void ResetEquipUniqueId()
		{
			this.EquipUniqueIdSpecified = false;
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000B1D0 File Offset: 0x000093D0
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0000B1FC File Offset: 0x000093FC
		[ProtoMember(4, IsRequired = false, Name = "SlotPos", DataFormat = DataFormat.TwosComplement)]
		public uint SlotPos
		{
			get
			{
				return this._SlotPos ?? 0U;
			}
			set
			{
				this._SlotPos = new uint?(value);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x0000B20C File Offset: 0x0000940C
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x0000B22C File Offset: 0x0000942C
		[XmlIgnore]
		[Browsable(false)]
		public bool SlotPosSpecified
		{
			get
			{
				return this._SlotPos != null;
			}
			set
			{
				bool flag = value == (this._SlotPos == null);
				if (flag)
				{
					this._SlotPos = (value ? new uint?(this.SlotPos) : null);
				}
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000B270 File Offset: 0x00009470
		private bool ShouldSerializeSlotPos()
		{
			return this.SlotPosSpecified;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000B288 File Offset: 0x00009488
		private void ResetSlotPos()
		{
			this.SlotPosSpecified = false;
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000B294 File Offset: 0x00009494
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x0000B2C0 File Offset: 0x000094C0
		[ProtoMember(5, IsRequired = false, Name = "AddLevel", DataFormat = DataFormat.TwosComplement)]
		public uint AddLevel
		{
			get
			{
				return this._AddLevel ?? 0U;
			}
			set
			{
				this._AddLevel = new uint?(value);
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x0000B2D0 File Offset: 0x000094D0
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x0000B2F0 File Offset: 0x000094F0
		[XmlIgnore]
		[Browsable(false)]
		public bool AddLevelSpecified
		{
			get
			{
				return this._AddLevel != null;
			}
			set
			{
				bool flag = value == (this._AddLevel == null);
				if (flag)
				{
					this._AddLevel = (value ? new uint?(this.AddLevel) : null);
				}
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000B334 File Offset: 0x00009534
		private bool ShouldSerializeAddLevel()
		{
			return this.AddLevelSpecified;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000B34C File Offset: 0x0000954C
		private void ResetAddLevel()
		{
			this.AddLevelSpecified = false;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000B358 File Offset: 0x00009558
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000123 RID: 291
		private uint? _ComposeType;

		// Token: 0x04000124 RID: 292
		private ulong? _JadeUniqueId;

		// Token: 0x04000125 RID: 293
		private ulong? _EquipUniqueId;

		// Token: 0x04000126 RID: 294
		private uint? _SlotPos;

		// Token: 0x04000127 RID: 295
		private uint? _AddLevel;

		// Token: 0x04000128 RID: 296
		private IExtension extensionObject;
	}
}
