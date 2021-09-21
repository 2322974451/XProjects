using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C7 RID: 1479
	[ProtoContract(Name = "RoleSmallInfo")]
	[Serializable]
	public class RoleSmallInfo : IExtensible
	{
		// Token: 0x170019B9 RID: 6585
		// (get) Token: 0x0600531F RID: 21279 RVA: 0x0009E1C0 File Offset: 0x0009C3C0
		// (set) Token: 0x06005320 RID: 21280 RVA: 0x0009E1ED File Offset: 0x0009C3ED
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x170019BA RID: 6586
		// (get) Token: 0x06005321 RID: 21281 RVA: 0x0009E1FC File Offset: 0x0009C3FC
		// (set) Token: 0x06005322 RID: 21282 RVA: 0x0009E21C File Offset: 0x0009C41C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06005323 RID: 21283 RVA: 0x0009E260 File Offset: 0x0009C460
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06005324 RID: 21284 RVA: 0x0009E278 File Offset: 0x0009C478
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170019BB RID: 6587
		// (get) Token: 0x06005325 RID: 21285 RVA: 0x0009E284 File Offset: 0x0009C484
		// (set) Token: 0x06005326 RID: 21286 RVA: 0x0009E2A5 File Offset: 0x0009C4A5
		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x170019BC RID: 6588
		// (get) Token: 0x06005327 RID: 21287 RVA: 0x0009E2B0 File Offset: 0x0009C4B0
		// (set) Token: 0x06005328 RID: 21288 RVA: 0x0009E2CC File Offset: 0x0009C4CC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x06005329 RID: 21289 RVA: 0x0009E2FC File Offset: 0x0009C4FC
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x0600532A RID: 21290 RVA: 0x0009E314 File Offset: 0x0009C514
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x170019BD RID: 6589
		// (get) Token: 0x0600532B RID: 21291 RVA: 0x0009E320 File Offset: 0x0009C520
		// (set) Token: 0x0600532C RID: 21292 RVA: 0x0009E34C File Offset: 0x0009C54C
		[ProtoMember(3, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public uint roleLevel
		{
			get
			{
				return this._roleLevel ?? 0U;
			}
			set
			{
				this._roleLevel = new uint?(value);
			}
		}

		// Token: 0x170019BE RID: 6590
		// (get) Token: 0x0600532D RID: 21293 RVA: 0x0009E35C File Offset: 0x0009C55C
		// (set) Token: 0x0600532E RID: 21294 RVA: 0x0009E37C File Offset: 0x0009C57C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new uint?(this.roleLevel) : null);
				}
			}
		}

		// Token: 0x0600532F RID: 21295 RVA: 0x0009E3C0 File Offset: 0x0009C5C0
		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		// Token: 0x06005330 RID: 21296 RVA: 0x0009E3D8 File Offset: 0x0009C5D8
		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		// Token: 0x170019BF RID: 6591
		// (get) Token: 0x06005331 RID: 21297 RVA: 0x0009E3E4 File Offset: 0x0009C5E4
		// (set) Token: 0x06005332 RID: 21298 RVA: 0x0009E410 File Offset: 0x0009C610
		[ProtoMember(4, IsRequired = false, Name = "roleProfession", DataFormat = DataFormat.TwosComplement)]
		public uint roleProfession
		{
			get
			{
				return this._roleProfession ?? 0U;
			}
			set
			{
				this._roleProfession = new uint?(value);
			}
		}

		// Token: 0x170019C0 RID: 6592
		// (get) Token: 0x06005333 RID: 21299 RVA: 0x0009E420 File Offset: 0x0009C620
		// (set) Token: 0x06005334 RID: 21300 RVA: 0x0009E440 File Offset: 0x0009C640
		[XmlIgnore]
		[Browsable(false)]
		public bool roleProfessionSpecified
		{
			get
			{
				return this._roleProfession != null;
			}
			set
			{
				bool flag = value == (this._roleProfession == null);
				if (flag)
				{
					this._roleProfession = (value ? new uint?(this.roleProfession) : null);
				}
			}
		}

		// Token: 0x06005335 RID: 21301 RVA: 0x0009E484 File Offset: 0x0009C684
		private bool ShouldSerializeroleProfession()
		{
			return this.roleProfessionSpecified;
		}

		// Token: 0x06005336 RID: 21302 RVA: 0x0009E49C File Offset: 0x0009C69C
		private void ResetroleProfession()
		{
			this.roleProfessionSpecified = false;
		}

		// Token: 0x170019C1 RID: 6593
		// (get) Token: 0x06005337 RID: 21303 RVA: 0x0009E4A8 File Offset: 0x0009C6A8
		// (set) Token: 0x06005338 RID: 21304 RVA: 0x0009E4D4 File Offset: 0x0009C6D4
		[ProtoMember(5, IsRequired = false, Name = "rolePPT", DataFormat = DataFormat.TwosComplement)]
		public uint rolePPT
		{
			get
			{
				return this._rolePPT ?? 0U;
			}
			set
			{
				this._rolePPT = new uint?(value);
			}
		}

		// Token: 0x170019C2 RID: 6594
		// (get) Token: 0x06005339 RID: 21305 RVA: 0x0009E4E4 File Offset: 0x0009C6E4
		// (set) Token: 0x0600533A RID: 21306 RVA: 0x0009E504 File Offset: 0x0009C704
		[XmlIgnore]
		[Browsable(false)]
		public bool rolePPTSpecified
		{
			get
			{
				return this._rolePPT != null;
			}
			set
			{
				bool flag = value == (this._rolePPT == null);
				if (flag)
				{
					this._rolePPT = (value ? new uint?(this.rolePPT) : null);
				}
			}
		}

		// Token: 0x0600533B RID: 21307 RVA: 0x0009E548 File Offset: 0x0009C748
		private bool ShouldSerializerolePPT()
		{
			return this.rolePPTSpecified;
		}

		// Token: 0x0600533C RID: 21308 RVA: 0x0009E560 File Offset: 0x0009C760
		private void ResetrolePPT()
		{
			this.rolePPTSpecified = false;
		}

		// Token: 0x0600533D RID: 21309 RVA: 0x0009E56C File Offset: 0x0009C76C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001452 RID: 5202
		private ulong? _roleID;

		// Token: 0x04001453 RID: 5203
		private string _roleName;

		// Token: 0x04001454 RID: 5204
		private uint? _roleLevel;

		// Token: 0x04001455 RID: 5205
		private uint? _roleProfession;

		// Token: 0x04001456 RID: 5206
		private uint? _rolePPT;

		// Token: 0x04001457 RID: 5207
		private IExtension extensionObject;
	}
}
