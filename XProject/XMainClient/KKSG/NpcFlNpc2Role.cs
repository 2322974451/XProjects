using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000737 RID: 1847
	[ProtoContract(Name = "NpcFlNpc2Role")]
	[Serializable]
	public class NpcFlNpc2Role : IExtensible
	{
		// Token: 0x17002886 RID: 10374
		// (get) Token: 0x06007FD3 RID: 32723 RVA: 0x000F46EC File Offset: 0x000F28EC
		// (set) Token: 0x06007FD4 RID: 32724 RVA: 0x000F4718 File Offset: 0x000F2918
		[ProtoMember(1, IsRequired = false, Name = "npcid", DataFormat = DataFormat.TwosComplement)]
		public uint npcid
		{
			get
			{
				return this._npcid ?? 0U;
			}
			set
			{
				this._npcid = new uint?(value);
			}
		}

		// Token: 0x17002887 RID: 10375
		// (get) Token: 0x06007FD5 RID: 32725 RVA: 0x000F4728 File Offset: 0x000F2928
		// (set) Token: 0x06007FD6 RID: 32726 RVA: 0x000F4748 File Offset: 0x000F2948
		[XmlIgnore]
		[Browsable(false)]
		public bool npcidSpecified
		{
			get
			{
				return this._npcid != null;
			}
			set
			{
				bool flag = value == (this._npcid == null);
				if (flag)
				{
					this._npcid = (value ? new uint?(this.npcid) : null);
				}
			}
		}

		// Token: 0x06007FD7 RID: 32727 RVA: 0x000F478C File Offset: 0x000F298C
		private bool ShouldSerializenpcid()
		{
			return this.npcidSpecified;
		}

		// Token: 0x06007FD8 RID: 32728 RVA: 0x000F47A4 File Offset: 0x000F29A4
		private void Resetnpcid()
		{
			this.npcidSpecified = false;
		}

		// Token: 0x17002888 RID: 10376
		// (get) Token: 0x06007FD9 RID: 32729 RVA: 0x000F47B0 File Offset: 0x000F29B0
		// (set) Token: 0x06007FDA RID: 32730 RVA: 0x000F47C8 File Offset: 0x000F29C8
		[ProtoMember(2, IsRequired = false, Name = "role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public NpcFlRoleExp role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}

		// Token: 0x17002889 RID: 10377
		// (get) Token: 0x06007FDB RID: 32731 RVA: 0x000F47D4 File Offset: 0x000F29D4
		// (set) Token: 0x06007FDC RID: 32732 RVA: 0x000F47F5 File Offset: 0x000F29F5
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

		// Token: 0x1700288A RID: 10378
		// (get) Token: 0x06007FDD RID: 32733 RVA: 0x000F4800 File Offset: 0x000F2A00
		// (set) Token: 0x06007FDE RID: 32734 RVA: 0x000F481C File Offset: 0x000F2A1C
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

		// Token: 0x06007FDF RID: 32735 RVA: 0x000F484C File Offset: 0x000F2A4C
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06007FE0 RID: 32736 RVA: 0x000F4864 File Offset: 0x000F2A64
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x06007FE1 RID: 32737 RVA: 0x000F4870 File Offset: 0x000F2A70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DFA RID: 7674
		private uint? _npcid;

		// Token: 0x04001DFB RID: 7675
		private NpcFlRoleExp _role = null;

		// Token: 0x04001DFC RID: 7676
		private string _rolename;

		// Token: 0x04001DFD RID: 7677
		private IExtension extensionObject;
	}
}
