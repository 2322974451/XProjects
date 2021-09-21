using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015C RID: 348
	[ProtoContract(Name = "StudyGuildSkillArg")]
	[Serializable]
	public class StudyGuildSkillArg : IExtensible
	{
		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x0600153D RID: 5437 RVA: 0x0002AB9C File Offset: 0x00028D9C
		// (set) Token: 0x0600153E RID: 5438 RVA: 0x0002ABC8 File Offset: 0x00028DC8
		[ProtoMember(1, IsRequired = false, Name = "skillId", DataFormat = DataFormat.TwosComplement)]
		public uint skillId
		{
			get
			{
				return this._skillId ?? 0U;
			}
			set
			{
				this._skillId = new uint?(value);
			}
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x0600153F RID: 5439 RVA: 0x0002ABD8 File Offset: 0x00028DD8
		// (set) Token: 0x06001540 RID: 5440 RVA: 0x0002ABF8 File Offset: 0x00028DF8
		[XmlIgnore]
		[Browsable(false)]
		public bool skillIdSpecified
		{
			get
			{
				return this._skillId != null;
			}
			set
			{
				bool flag = value == (this._skillId == null);
				if (flag)
				{
					this._skillId = (value ? new uint?(this.skillId) : null);
				}
			}
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0002AC3C File Offset: 0x00028E3C
		private bool ShouldSerializeskillId()
		{
			return this.skillIdSpecified;
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0002AC54 File Offset: 0x00028E54
		private void ResetskillId()
		{
			this.skillIdSpecified = false;
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0002AC60 File Offset: 0x00028E60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000547 RID: 1351
		private uint? _skillId;

		// Token: 0x04000548 RID: 1352
		private IExtension extensionObject;
	}
}
