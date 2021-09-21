using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000017 RID: 23
	[ProtoContract(Name = "SkillLevelupArg")]
	[Serializable]
	public class SkillLevelupArg : IExtensible
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00006930 File Offset: 0x00004B30
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000695C File Offset: 0x00004B5C
		[ProtoMember(1, IsRequired = false, Name = "skillHash", DataFormat = DataFormat.TwosComplement)]
		public uint skillHash
		{
			get
			{
				return this._skillHash ?? 0U;
			}
			set
			{
				this._skillHash = new uint?(value);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000696C File Offset: 0x00004B6C
		// (set) Token: 0x06000208 RID: 520 RVA: 0x0000698C File Offset: 0x00004B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool skillHashSpecified
		{
			get
			{
				return this._skillHash != null;
			}
			set
			{
				bool flag = value == (this._skillHash == null);
				if (flag)
				{
					this._skillHash = (value ? new uint?(this.skillHash) : null);
				}
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000069D0 File Offset: 0x00004BD0
		private bool ShouldSerializeskillHash()
		{
			return this.skillHashSpecified;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000069E8 File Offset: 0x00004BE8
		private void ResetskillHash()
		{
			this.skillHashSpecified = false;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000069F4 File Offset: 0x00004BF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000082 RID: 130
		private uint? _skillHash;

		// Token: 0x04000083 RID: 131
		private IExtension extensionObject;
	}
}
