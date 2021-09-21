using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000024 RID: 36
	[ProtoContract(Name = "ResetSkillArg")]
	[Serializable]
	public class ResetSkillArg : IExtensible
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00007A14 File Offset: 0x00005C14
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00007A40 File Offset: 0x00005C40
		[ProtoMember(1, IsRequired = false, Name = "resetType", DataFormat = DataFormat.TwosComplement)]
		public ResetType resetType
		{
			get
			{
				return this._resetType ?? ResetType.RESET_SKILL;
			}
			set
			{
				this._resetType = new ResetType?(value);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00007A50 File Offset: 0x00005C50
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00007A70 File Offset: 0x00005C70
		[XmlIgnore]
		[Browsable(false)]
		public bool resetTypeSpecified
		{
			get
			{
				return this._resetType != null;
			}
			set
			{
				bool flag = value == (this._resetType == null);
				if (flag)
				{
					this._resetType = (value ? new ResetType?(this.resetType) : null);
				}
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00007AB4 File Offset: 0x00005CB4
		private bool ShouldSerializeresetType()
		{
			return this.resetTypeSpecified;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00007ACC File Offset: 0x00005CCC
		private void ResetresetType()
		{
			this.resetTypeSpecified = false;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00007AD8 File Offset: 0x00005CD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000AF RID: 175
		private ResetType? _resetType;

		// Token: 0x040000B0 RID: 176
		private IExtension extensionObject;
	}
}
