using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C8 RID: 1224
	[ProtoContract(Name = "ChangeDragonGuildPositionArg")]
	[Serializable]
	public class ChangeDragonGuildPositionArg : IExtensible
	{
		// Token: 0x1700137F RID: 4991
		// (get) Token: 0x06003FA2 RID: 16290 RVA: 0x000794C4 File Offset: 0x000776C4
		// (set) Token: 0x06003FA3 RID: 16291 RVA: 0x000794F1 File Offset: 0x000776F1
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001380 RID: 4992
		// (get) Token: 0x06003FA4 RID: 16292 RVA: 0x00079500 File Offset: 0x00077700
		// (set) Token: 0x06003FA5 RID: 16293 RVA: 0x00079520 File Offset: 0x00077720
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06003FA6 RID: 16294 RVA: 0x00079564 File Offset: 0x00077764
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003FA7 RID: 16295 RVA: 0x0007957C File Offset: 0x0007777C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001381 RID: 4993
		// (get) Token: 0x06003FA8 RID: 16296 RVA: 0x00079588 File Offset: 0x00077788
		// (set) Token: 0x06003FA9 RID: 16297 RVA: 0x000795B4 File Offset: 0x000777B4
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		// Token: 0x17001382 RID: 4994
		// (get) Token: 0x06003FAA RID: 16298 RVA: 0x000795C4 File Offset: 0x000777C4
		// (set) Token: 0x06003FAB RID: 16299 RVA: 0x000795E4 File Offset: 0x000777E4
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
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		// Token: 0x06003FAC RID: 16300 RVA: 0x00079628 File Offset: 0x00077828
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06003FAD RID: 16301 RVA: 0x00079640 File Offset: 0x00077840
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x06003FAE RID: 16302 RVA: 0x0007964C File Offset: 0x0007784C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FD9 RID: 4057
		private ulong? _roleid;

		// Token: 0x04000FDA RID: 4058
		private uint? _position;

		// Token: 0x04000FDB RID: 4059
		private IExtension extensionObject;
	}
}
