using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000350 RID: 848
	[ProtoContract(Name = "TryAllianceArg")]
	[Serializable]
	public class TryAllianceArg : IExtensible
	{
		// Token: 0x17000E60 RID: 3680
		// (get) Token: 0x06002E58 RID: 11864 RVA: 0x0005993C File Offset: 0x00057B3C
		// (set) Token: 0x06002E59 RID: 11865 RVA: 0x00059969 File Offset: 0x00057B69
		[ProtoMember(1, IsRequired = false, Name = "guild", DataFormat = DataFormat.TwosComplement)]
		public ulong guild
		{
			get
			{
				return this._guild ?? 0UL;
			}
			set
			{
				this._guild = new ulong?(value);
			}
		}

		// Token: 0x17000E61 RID: 3681
		// (get) Token: 0x06002E5A RID: 11866 RVA: 0x00059978 File Offset: 0x00057B78
		// (set) Token: 0x06002E5B RID: 11867 RVA: 0x00059998 File Offset: 0x00057B98
		[XmlIgnore]
		[Browsable(false)]
		public bool guildSpecified
		{
			get
			{
				return this._guild != null;
			}
			set
			{
				bool flag = value == (this._guild == null);
				if (flag)
				{
					this._guild = (value ? new ulong?(this.guild) : null);
				}
			}
		}

		// Token: 0x06002E5C RID: 11868 RVA: 0x000599DC File Offset: 0x00057BDC
		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		// Token: 0x06002E5D RID: 11869 RVA: 0x000599F4 File Offset: 0x00057BF4
		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		// Token: 0x06002E5E RID: 11870 RVA: 0x00059A00 File Offset: 0x00057C00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B85 RID: 2949
		private ulong? _guild;

		// Token: 0x04000B86 RID: 2950
		private IExtension extensionObject;
	}
}
