using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000192 RID: 402
	[ProtoContract(Name = "AdjustGuildArenaRolePosArg")]
	[Serializable]
	public class AdjustGuildArenaRolePosArg : IExtensible
	{
		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06001837 RID: 6199 RVA: 0x00030454 File Offset: 0x0002E654
		// (set) Token: 0x06001838 RID: 6200 RVA: 0x00030480 File Offset: 0x0002E680
		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public uint pos
		{
			get
			{
				return this._pos ?? 0U;
			}
			set
			{
				this._pos = new uint?(value);
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06001839 RID: 6201 RVA: 0x00030490 File Offset: 0x0002E690
		// (set) Token: 0x0600183A RID: 6202 RVA: 0x000304B0 File Offset: 0x0002E6B0
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new uint?(this.pos) : null);
				}
			}
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x000304F4 File Offset: 0x0002E6F4
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x0003050C File Offset: 0x0002E70C
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x0600183D RID: 6205 RVA: 0x00030518 File Offset: 0x0002E718
		// (set) Token: 0x0600183E RID: 6206 RVA: 0x00030545 File Offset: 0x0002E745
		[ProtoMember(2, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x0600183F RID: 6207 RVA: 0x00030554 File Offset: 0x0002E754
		// (set) Token: 0x06001840 RID: 6208 RVA: 0x00030574 File Offset: 0x0002E774
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

		// Token: 0x06001841 RID: 6209 RVA: 0x000305B8 File Offset: 0x0002E7B8
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x000305D0 File Offset: 0x0002E7D0
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x000305DC File Offset: 0x0002E7DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005FC RID: 1532
		private uint? _pos;

		// Token: 0x040005FD RID: 1533
		private ulong? _roleId;

		// Token: 0x040005FE RID: 1534
		private IExtension extensionObject;
	}
}
