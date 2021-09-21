using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000414 RID: 1044
	[ProtoContract(Name = "CustomBattleLoadingNtf")]
	[Serializable]
	public class CustomBattleLoadingNtf : IExtensible
	{
		// Token: 0x1700110F RID: 4367
		// (get) Token: 0x06003782 RID: 14210 RVA: 0x0006A4B8 File Offset: 0x000686B8
		[ProtoMember(1, Name = "roleinfos", DataFormat = DataFormat.Default)]
		public List<CustomBattleMatchRoleInfo> roleinfos
		{
			get
			{
				return this._roleinfos;
			}
		}

		// Token: 0x17001110 RID: 4368
		// (get) Token: 0x06003783 RID: 14211 RVA: 0x0006A4D0 File Offset: 0x000686D0
		// (set) Token: 0x06003784 RID: 14212 RVA: 0x0006A4FC File Offset: 0x000686FC
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleType type
		{
			get
			{
				return this._type ?? CustomBattleType.CustomBattle_PK_Normal;
			}
			set
			{
				this._type = new CustomBattleType?(value);
			}
		}

		// Token: 0x17001111 RID: 4369
		// (get) Token: 0x06003785 RID: 14213 RVA: 0x0006A50C File Offset: 0x0006870C
		// (set) Token: 0x06003786 RID: 14214 RVA: 0x0006A52C File Offset: 0x0006872C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new CustomBattleType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x0006A570 File Offset: 0x00068770
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x0006A588 File Offset: 0x00068788
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x0006A594 File Offset: 0x00068794
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DC2 RID: 3522
		private readonly List<CustomBattleMatchRoleInfo> _roleinfos = new List<CustomBattleMatchRoleInfo>();

		// Token: 0x04000DC3 RID: 3523
		private CustomBattleType? _type;

		// Token: 0x04000DC4 RID: 3524
		private IExtension extensionObject;
	}
}
