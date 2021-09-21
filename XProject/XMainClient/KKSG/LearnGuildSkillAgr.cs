using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000228 RID: 552
	[ProtoContract(Name = "LearnGuildSkillAgr")]
	[Serializable]
	public class LearnGuildSkillAgr : IExtensible
	{
		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06001EED RID: 7917 RVA: 0x0003CB54 File Offset: 0x0003AD54
		// (set) Token: 0x06001EEE RID: 7918 RVA: 0x0003CB80 File Offset: 0x0003AD80
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

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06001EEF RID: 7919 RVA: 0x0003CB90 File Offset: 0x0003AD90
		// (set) Token: 0x06001EF0 RID: 7920 RVA: 0x0003CBB0 File Offset: 0x0003ADB0
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

		// Token: 0x06001EF1 RID: 7921 RVA: 0x0003CBF4 File Offset: 0x0003ADF4
		private bool ShouldSerializeskillId()
		{
			return this.skillIdSpecified;
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x0003CC0C File Offset: 0x0003AE0C
		private void ResetskillId()
		{
			this.skillIdSpecified = false;
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x0003CC18 File Offset: 0x0003AE18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007B8 RID: 1976
		private uint? _skillId;

		// Token: 0x040007B9 RID: 1977
		private IExtension extensionObject;
	}
}
