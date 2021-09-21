using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000121 RID: 289
	[ProtoContract(Name = "ReconectSync")]
	[Serializable]
	public class ReconectSync : IExtensible
	{
		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x060011EF RID: 4591 RVA: 0x00024828 File Offset: 0x00022A28
		// (set) Token: 0x060011F0 RID: 4592 RVA: 0x00024840 File Offset: 0x00022A40
		[ProtoMember(1, IsRequired = false, Name = "self", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleAllInfo self
		{
			get
			{
				return this._self;
			}
			set
			{
				this._self = value;
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x060011F1 RID: 4593 RVA: 0x0002484C File Offset: 0x00022A4C
		[ProtoMember(2, Name = "units", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> units
		{
			get
			{
				return this._units;
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x060011F2 RID: 4594 RVA: 0x00024864 File Offset: 0x00022A64
		// (set) Token: 0x060011F3 RID: 4595 RVA: 0x0002487C File Offset: 0x00022A7C
		[ProtoMember(3, IsRequired = false, Name = "selfAppearance", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance selfAppearance
		{
			get
			{
				return this._selfAppearance;
			}
			set
			{
				this._selfAppearance = value;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x060011F4 RID: 4596 RVA: 0x00024888 File Offset: 0x00022A88
		// (set) Token: 0x060011F5 RID: 4597 RVA: 0x000248A0 File Offset: 0x00022AA0
		[ProtoMember(4, IsRequired = false, Name = "deathinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DeathInfo deathinfo
		{
			get
			{
				return this._deathinfo;
			}
			set
			{
				this._deathinfo = value;
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x060011F6 RID: 4598 RVA: 0x000248AC File Offset: 0x00022AAC
		// (set) Token: 0x060011F7 RID: 4599 RVA: 0x000248D8 File Offset: 0x00022AD8
		[ProtoMember(5, IsRequired = false, Name = "isautofight", DataFormat = DataFormat.Default)]
		public bool isautofight
		{
			get
			{
				return this._isautofight ?? false;
			}
			set
			{
				this._isautofight = new bool?(value);
			}
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x000248E8 File Offset: 0x00022AE8
		// (set) Token: 0x060011F9 RID: 4601 RVA: 0x00024908 File Offset: 0x00022B08
		[XmlIgnore]
		[Browsable(false)]
		public bool isautofightSpecified
		{
			get
			{
				return this._isautofight != null;
			}
			set
			{
				bool flag = value == (this._isautofight == null);
				if (flag)
				{
					this._isautofight = (value ? new bool?(this.isautofight) : null);
				}
			}
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x0002494C File Offset: 0x00022B4C
		private bool ShouldSerializeisautofight()
		{
			return this.isautofightSpecified;
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x00024964 File Offset: 0x00022B64
		private void Resetisautofight()
		{
			this.isautofightSpecified = false;
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x00024970 File Offset: 0x00022B70
		// (set) Token: 0x060011FD RID: 4605 RVA: 0x00024988 File Offset: 0x00022B88
		[ProtoMember(6, IsRequired = false, Name = "scene", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ReconnectScene scene
		{
			get
			{
				return this._scene;
			}
			set
			{
				this._scene = value;
			}
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00024994 File Offset: 0x00022B94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400047B RID: 1147
		private RoleAllInfo _self = null;

		// Token: 0x0400047C RID: 1148
		private readonly List<UnitAppearance> _units = new List<UnitAppearance>();

		// Token: 0x0400047D RID: 1149
		private UnitAppearance _selfAppearance = null;

		// Token: 0x0400047E RID: 1150
		private DeathInfo _deathinfo = null;

		// Token: 0x0400047F RID: 1151
		private bool? _isautofight;

		// Token: 0x04000480 RID: 1152
		private ReconnectScene _scene = null;

		// Token: 0x04000481 RID: 1153
		private IExtension extensionObject;
	}
}
