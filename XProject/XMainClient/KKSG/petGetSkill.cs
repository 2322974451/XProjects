using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CA RID: 1482
	[ProtoContract(Name = "petGetSkill")]
	[Serializable]
	public class petGetSkill : IExtensible
	{
		// Token: 0x170019DD RID: 6621
		// (get) Token: 0x0600538E RID: 21390 RVA: 0x0009EF04 File Offset: 0x0009D104
		// (set) Token: 0x0600538F RID: 21391 RVA: 0x0009EF30 File Offset: 0x0009D130
		[ProtoMember(1, IsRequired = false, Name = "petLvl", DataFormat = DataFormat.TwosComplement)]
		public uint petLvl
		{
			get
			{
				return this._petLvl ?? 0U;
			}
			set
			{
				this._petLvl = new uint?(value);
			}
		}

		// Token: 0x170019DE RID: 6622
		// (get) Token: 0x06005390 RID: 21392 RVA: 0x0009EF40 File Offset: 0x0009D140
		// (set) Token: 0x06005391 RID: 21393 RVA: 0x0009EF60 File Offset: 0x0009D160
		[XmlIgnore]
		[Browsable(false)]
		public bool petLvlSpecified
		{
			get
			{
				return this._petLvl != null;
			}
			set
			{
				bool flag = value == (this._petLvl == null);
				if (flag)
				{
					this._petLvl = (value ? new uint?(this.petLvl) : null);
				}
			}
		}

		// Token: 0x06005392 RID: 21394 RVA: 0x0009EFA4 File Offset: 0x0009D1A4
		private bool ShouldSerializepetLvl()
		{
			return this.petLvlSpecified;
		}

		// Token: 0x06005393 RID: 21395 RVA: 0x0009EFBC File Offset: 0x0009D1BC
		private void ResetpetLvl()
		{
			this.petLvlSpecified = false;
		}

		// Token: 0x170019DF RID: 6623
		// (get) Token: 0x06005394 RID: 21396 RVA: 0x0009EFC8 File Offset: 0x0009D1C8
		// (set) Token: 0x06005395 RID: 21397 RVA: 0x0009EFF4 File Offset: 0x0009D1F4
		[ProtoMember(2, IsRequired = false, Name = "skillid", DataFormat = DataFormat.TwosComplement)]
		public uint skillid
		{
			get
			{
				return this._skillid ?? 0U;
			}
			set
			{
				this._skillid = new uint?(value);
			}
		}

		// Token: 0x170019E0 RID: 6624
		// (get) Token: 0x06005396 RID: 21398 RVA: 0x0009F004 File Offset: 0x0009D204
		// (set) Token: 0x06005397 RID: 21399 RVA: 0x0009F024 File Offset: 0x0009D224
		[XmlIgnore]
		[Browsable(false)]
		public bool skillidSpecified
		{
			get
			{
				return this._skillid != null;
			}
			set
			{
				bool flag = value == (this._skillid == null);
				if (flag)
				{
					this._skillid = (value ? new uint?(this.skillid) : null);
				}
			}
		}

		// Token: 0x06005398 RID: 21400 RVA: 0x0009F068 File Offset: 0x0009D268
		private bool ShouldSerializeskillid()
		{
			return this.skillidSpecified;
		}

		// Token: 0x06005399 RID: 21401 RVA: 0x0009F080 File Offset: 0x0009D280
		private void Resetskillid()
		{
			this.skillidSpecified = false;
		}

		// Token: 0x0600539A RID: 21402 RVA: 0x0009F08C File Offset: 0x0009D28C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001468 RID: 5224
		private uint? _petLvl;

		// Token: 0x04001469 RID: 5225
		private uint? _skillid;

		// Token: 0x0400146A RID: 5226
		private IExtension extensionObject;
	}
}
