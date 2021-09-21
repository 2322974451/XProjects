using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000381 RID: 897
	[ProtoContract(Name = "AtlasUpStarArg")]
	[Serializable]
	public class AtlasUpStarArg : IExtensible
	{
		// Token: 0x17000F13 RID: 3859
		// (get) Token: 0x060030B8 RID: 12472 RVA: 0x0005DF04 File Offset: 0x0005C104
		// (set) Token: 0x060030B9 RID: 12473 RVA: 0x0005DF30 File Offset: 0x0005C130
		[ProtoMember(1, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		// Token: 0x17000F14 RID: 3860
		// (get) Token: 0x060030BA RID: 12474 RVA: 0x0005DF40 File Offset: 0x0005C140
		// (set) Token: 0x060030BB RID: 12475 RVA: 0x0005DF60 File Offset: 0x0005C160
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		// Token: 0x060030BC RID: 12476 RVA: 0x0005DFA4 File Offset: 0x0005C1A4
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x0005DFBC File Offset: 0x0005C1BC
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x060030BE RID: 12478 RVA: 0x0005DFC8 File Offset: 0x0005C1C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C17 RID: 3095
		private uint? _groupid;

		// Token: 0x04000C18 RID: 3096
		private IExtension extensionObject;
	}
}
