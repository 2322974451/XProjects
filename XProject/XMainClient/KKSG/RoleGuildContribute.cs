using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000747 RID: 1863
	[ProtoContract(Name = "RoleGuildContribute")]
	[Serializable]
	public class RoleGuildContribute : IExtensible
	{
		// Token: 0x17002937 RID: 10551
		// (get) Token: 0x060081FF RID: 33279 RVA: 0x000F8A38 File Offset: 0x000F6C38
		// (set) Token: 0x06008200 RID: 33280 RVA: 0x000F8A65 File Offset: 0x000F6C65
		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		// Token: 0x17002938 RID: 10552
		// (get) Token: 0x06008201 RID: 33281 RVA: 0x000F8A74 File Offset: 0x000F6C74
		// (set) Token: 0x06008202 RID: 33282 RVA: 0x000F8A94 File Offset: 0x000F6C94
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		// Token: 0x06008203 RID: 33283 RVA: 0x000F8AD8 File Offset: 0x000F6CD8
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x06008204 RID: 33284 RVA: 0x000F8AF0 File Offset: 0x000F6CF0
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x17002939 RID: 10553
		// (get) Token: 0x06008205 RID: 33285 RVA: 0x000F8AFC File Offset: 0x000F6CFC
		// (set) Token: 0x06008206 RID: 33286 RVA: 0x000F8B1D File Offset: 0x000F6D1D
		[ProtoMember(2, IsRequired = false, Name = "RoleName", DataFormat = DataFormat.Default)]
		public string RoleName
		{
			get
			{
				return this._RoleName ?? "";
			}
			set
			{
				this._RoleName = value;
			}
		}

		// Token: 0x1700293A RID: 10554
		// (get) Token: 0x06008207 RID: 33287 RVA: 0x000F8B28 File Offset: 0x000F6D28
		// (set) Token: 0x06008208 RID: 33288 RVA: 0x000F8B44 File Offset: 0x000F6D44
		[XmlIgnore]
		[Browsable(false)]
		public bool RoleNameSpecified
		{
			get
			{
				return this._RoleName != null;
			}
			set
			{
				bool flag = value == (this._RoleName == null);
				if (flag)
				{
					this._RoleName = (value ? this.RoleName : null);
				}
			}
		}

		// Token: 0x06008209 RID: 33289 RVA: 0x000F8B74 File Offset: 0x000F6D74
		private bool ShouldSerializeRoleName()
		{
			return this.RoleNameSpecified;
		}

		// Token: 0x0600820A RID: 33290 RVA: 0x000F8B8C File Offset: 0x000F6D8C
		private void ResetRoleName()
		{
			this.RoleNameSpecified = false;
		}

		// Token: 0x1700293B RID: 10555
		// (get) Token: 0x0600820B RID: 33291 RVA: 0x000F8B98 File Offset: 0x000F6D98
		// (set) Token: 0x0600820C RID: 33292 RVA: 0x000F8BC4 File Offset: 0x000F6DC4
		[ProtoMember(3, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
			}
		}

		// Token: 0x1700293C RID: 10556
		// (get) Token: 0x0600820D RID: 33293 RVA: 0x000F8BD4 File Offset: 0x000F6DD4
		// (set) Token: 0x0600820E RID: 33294 RVA: 0x000F8BF4 File Offset: 0x000F6DF4
		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new int?(this.contribute) : null);
				}
			}
		}

		// Token: 0x0600820F RID: 33295 RVA: 0x000F8C38 File Offset: 0x000F6E38
		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		// Token: 0x06008210 RID: 33296 RVA: 0x000F8C50 File Offset: 0x000F6E50
		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		// Token: 0x1700293D RID: 10557
		// (get) Token: 0x06008211 RID: 33297 RVA: 0x000F8C5C File Offset: 0x000F6E5C
		// (set) Token: 0x06008212 RID: 33298 RVA: 0x000F8C88 File Offset: 0x000F6E88
		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		// Token: 0x1700293E RID: 10558
		// (get) Token: 0x06008213 RID: 33299 RVA: 0x000F8C98 File Offset: 0x000F6E98
		// (set) Token: 0x06008214 RID: 33300 RVA: 0x000F8CB8 File Offset: 0x000F6EB8
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06008215 RID: 33301 RVA: 0x000F8CFC File Offset: 0x000F6EFC
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06008216 RID: 33302 RVA: 0x000F8D14 File Offset: 0x000F6F14
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x06008217 RID: 33303 RVA: 0x000F8D20 File Offset: 0x000F6F20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E65 RID: 7781
		private ulong? _roleId;

		// Token: 0x04001E66 RID: 7782
		private string _RoleName;

		// Token: 0x04001E67 RID: 7783
		private int? _contribute;

		// Token: 0x04001E68 RID: 7784
		private uint? _updateTime;

		// Token: 0x04001E69 RID: 7785
		private IExtension extensionObject;
	}
}
