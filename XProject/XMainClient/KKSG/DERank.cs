using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A7 RID: 1703
	[ProtoContract(Name = "DERank")]
	[Serializable]
	public class DERank : IExtensible
	{
		// Token: 0x17002327 RID: 8999
		// (get) Token: 0x06006F0D RID: 28429 RVA: 0x000D4848 File Offset: 0x000D2A48
		// (set) Token: 0x06006F0E RID: 28430 RVA: 0x000D4874 File Offset: 0x000D2A74
		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17002328 RID: 9000
		// (get) Token: 0x06006F0F RID: 28431 RVA: 0x000D4884 File Offset: 0x000D2A84
		// (set) Token: 0x06006F10 RID: 28432 RVA: 0x000D48A4 File Offset: 0x000D2AA4
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x06006F11 RID: 28433 RVA: 0x000D48E8 File Offset: 0x000D2AE8
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06006F12 RID: 28434 RVA: 0x000D4900 File Offset: 0x000D2B00
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17002329 RID: 9001
		// (get) Token: 0x06006F13 RID: 28435 RVA: 0x000D490C File Offset: 0x000D2B0C
		// (set) Token: 0x06006F14 RID: 28436 RVA: 0x000D4939 File Offset: 0x000D2B39
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700232A RID: 9002
		// (get) Token: 0x06006F15 RID: 28437 RVA: 0x000D4948 File Offset: 0x000D2B48
		// (set) Token: 0x06006F16 RID: 28438 RVA: 0x000D4968 File Offset: 0x000D2B68
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

		// Token: 0x06006F17 RID: 28439 RVA: 0x000D49AC File Offset: 0x000D2BAC
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06006F18 RID: 28440 RVA: 0x000D49C4 File Offset: 0x000D2BC4
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700232B RID: 9003
		// (get) Token: 0x06006F19 RID: 28441 RVA: 0x000D49D0 File Offset: 0x000D2BD0
		// (set) Token: 0x06006F1A RID: 28442 RVA: 0x000D49F1 File Offset: 0x000D2BF1
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x1700232C RID: 9004
		// (get) Token: 0x06006F1B RID: 28443 RVA: 0x000D49FC File Offset: 0x000D2BFC
		// (set) Token: 0x06006F1C RID: 28444 RVA: 0x000D4A18 File Offset: 0x000D2C18
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06006F1D RID: 28445 RVA: 0x000D4A48 File Offset: 0x000D2C48
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06006F1E RID: 28446 RVA: 0x000D4A60 File Offset: 0x000D2C60
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700232D RID: 9005
		// (get) Token: 0x06006F1F RID: 28447 RVA: 0x000D4A6C File Offset: 0x000D2C6C
		// (set) Token: 0x06006F20 RID: 28448 RVA: 0x000D4A84 File Offset: 0x000D2C84
		[ProtoMember(4, IsRequired = false, Name = "progress", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DEProgress progress
		{
			get
			{
				return this._progress;
			}
			set
			{
				this._progress = value;
			}
		}

		// Token: 0x1700232E RID: 9006
		// (get) Token: 0x06006F21 RID: 28449 RVA: 0x000D4A90 File Offset: 0x000D2C90
		[ProtoMember(5, Name = "reward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> reward
		{
			get
			{
				return this._reward;
			}
		}

		// Token: 0x06006F22 RID: 28450 RVA: 0x000D4AA8 File Offset: 0x000D2CA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A92 RID: 6802
		private int? _rank;

		// Token: 0x04001A93 RID: 6803
		private ulong? _roleID;

		// Token: 0x04001A94 RID: 6804
		private string _rolename;

		// Token: 0x04001A95 RID: 6805
		private DEProgress _progress = null;

		// Token: 0x04001A96 RID: 6806
		private readonly List<ItemBrief> _reward = new List<ItemBrief>();

		// Token: 0x04001A97 RID: 6807
		private IExtension extensionObject;
	}
}
