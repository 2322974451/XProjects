using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021E RID: 542
	[ProtoContract(Name = "SetVoipMemberState")]
	[Serializable]
	public class SetVoipMemberState : IExtensible
	{
		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06001E3A RID: 7738 RVA: 0x0003B5B8 File Offset: 0x000397B8
		// (set) Token: 0x06001E3B RID: 7739 RVA: 0x0003B5E4 File Offset: 0x000397E4
		[ProtoMember(1, IsRequired = false, Name = "nstate", DataFormat = DataFormat.TwosComplement)]
		public uint nstate
		{
			get
			{
				return this._nstate ?? 0U;
			}
			set
			{
				this._nstate = new uint?(value);
			}
		}

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06001E3C RID: 7740 RVA: 0x0003B5F4 File Offset: 0x000397F4
		// (set) Token: 0x06001E3D RID: 7741 RVA: 0x0003B614 File Offset: 0x00039814
		[XmlIgnore]
		[Browsable(false)]
		public bool nstateSpecified
		{
			get
			{
				return this._nstate != null;
			}
			set
			{
				bool flag = value == (this._nstate == null);
				if (flag)
				{
					this._nstate = (value ? new uint?(this.nstate) : null);
				}
			}
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x0003B658 File Offset: 0x00039858
		private bool ShouldSerializenstate()
		{
			return this.nstateSpecified;
		}

		// Token: 0x06001E3F RID: 7743 RVA: 0x0003B670 File Offset: 0x00039870
		private void Resetnstate()
		{
			this.nstateSpecified = false;
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x0003B67C File Offset: 0x0003987C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000791 RID: 1937
		private uint? _nstate;

		// Token: 0x04000792 RID: 1938
		private IExtension extensionObject;
	}
}
