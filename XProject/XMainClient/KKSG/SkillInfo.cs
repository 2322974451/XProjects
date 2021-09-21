using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000562 RID: 1378
	[ProtoContract(Name = "SkillInfo")]
	[Serializable]
	public class SkillInfo : IExtensible
	{
		// Token: 0x17001589 RID: 5513
		// (get) Token: 0x06004683 RID: 18051 RVA: 0x00085EF8 File Offset: 0x000840F8
		// (set) Token: 0x06004684 RID: 18052 RVA: 0x00085F24 File Offset: 0x00084124
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

		// Token: 0x1700158A RID: 5514
		// (get) Token: 0x06004685 RID: 18053 RVA: 0x00085F34 File Offset: 0x00084134
		// (set) Token: 0x06004686 RID: 18054 RVA: 0x00085F54 File Offset: 0x00084154
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

		// Token: 0x06004687 RID: 18055 RVA: 0x00085F98 File Offset: 0x00084198
		private bool ShouldSerializeskillHash()
		{
			return this.skillHashSpecified;
		}

		// Token: 0x06004688 RID: 18056 RVA: 0x00085FB0 File Offset: 0x000841B0
		private void ResetskillHash()
		{
			this.skillHashSpecified = false;
		}

		// Token: 0x1700158B RID: 5515
		// (get) Token: 0x06004689 RID: 18057 RVA: 0x00085FBC File Offset: 0x000841BC
		// (set) Token: 0x0600468A RID: 18058 RVA: 0x00085FE8 File Offset: 0x000841E8
		[ProtoMember(2, IsRequired = false, Name = "skillLevel", DataFormat = DataFormat.TwosComplement)]
		public uint skillLevel
		{
			get
			{
				return this._skillLevel ?? 0U;
			}
			set
			{
				this._skillLevel = new uint?(value);
			}
		}

		// Token: 0x1700158C RID: 5516
		// (get) Token: 0x0600468B RID: 18059 RVA: 0x00085FF8 File Offset: 0x000841F8
		// (set) Token: 0x0600468C RID: 18060 RVA: 0x00086018 File Offset: 0x00084218
		[XmlIgnore]
		[Browsable(false)]
		public bool skillLevelSpecified
		{
			get
			{
				return this._skillLevel != null;
			}
			set
			{
				bool flag = value == (this._skillLevel == null);
				if (flag)
				{
					this._skillLevel = (value ? new uint?(this.skillLevel) : null);
				}
			}
		}

		// Token: 0x0600468D RID: 18061 RVA: 0x0008605C File Offset: 0x0008425C
		private bool ShouldSerializeskillLevel()
		{
			return this.skillLevelSpecified;
		}

		// Token: 0x0600468E RID: 18062 RVA: 0x00086074 File Offset: 0x00084274
		private void ResetskillLevel()
		{
			this.skillLevelSpecified = false;
		}

		// Token: 0x1700158D RID: 5517
		// (get) Token: 0x0600468F RID: 18063 RVA: 0x00086080 File Offset: 0x00084280
		// (set) Token: 0x06004690 RID: 18064 RVA: 0x000860AC File Offset: 0x000842AC
		[ProtoMember(3, IsRequired = false, Name = "skillpoint", DataFormat = DataFormat.TwosComplement)]
		public uint skillpoint
		{
			get
			{
				return this._skillpoint ?? 0U;
			}
			set
			{
				this._skillpoint = new uint?(value);
			}
		}

		// Token: 0x1700158E RID: 5518
		// (get) Token: 0x06004691 RID: 18065 RVA: 0x000860BC File Offset: 0x000842BC
		// (set) Token: 0x06004692 RID: 18066 RVA: 0x000860DC File Offset: 0x000842DC
		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointSpecified
		{
			get
			{
				return this._skillpoint != null;
			}
			set
			{
				bool flag = value == (this._skillpoint == null);
				if (flag)
				{
					this._skillpoint = (value ? new uint?(this.skillpoint) : null);
				}
			}
		}

		// Token: 0x06004693 RID: 18067 RVA: 0x00086120 File Offset: 0x00084320
		private bool ShouldSerializeskillpoint()
		{
			return this.skillpointSpecified;
		}

		// Token: 0x06004694 RID: 18068 RVA: 0x00086138 File Offset: 0x00084338
		private void Resetskillpoint()
		{
			this.skillpointSpecified = false;
		}

		// Token: 0x1700158F RID: 5519
		// (get) Token: 0x06004695 RID: 18069 RVA: 0x00086144 File Offset: 0x00084344
		// (set) Token: 0x06004696 RID: 18070 RVA: 0x00086170 File Offset: 0x00084370
		[ProtoMember(4, IsRequired = false, Name = "isbasic", DataFormat = DataFormat.Default)]
		public bool isbasic
		{
			get
			{
				return this._isbasic ?? false;
			}
			set
			{
				this._isbasic = new bool?(value);
			}
		}

		// Token: 0x17001590 RID: 5520
		// (get) Token: 0x06004697 RID: 18071 RVA: 0x00086180 File Offset: 0x00084380
		// (set) Token: 0x06004698 RID: 18072 RVA: 0x000861A0 File Offset: 0x000843A0
		[XmlIgnore]
		[Browsable(false)]
		public bool isbasicSpecified
		{
			get
			{
				return this._isbasic != null;
			}
			set
			{
				bool flag = value == (this._isbasic == null);
				if (flag)
				{
					this._isbasic = (value ? new bool?(this.isbasic) : null);
				}
			}
		}

		// Token: 0x06004699 RID: 18073 RVA: 0x000861E4 File Offset: 0x000843E4
		private bool ShouldSerializeisbasic()
		{
			return this.isbasicSpecified;
		}

		// Token: 0x0600469A RID: 18074 RVA: 0x000861FC File Offset: 0x000843FC
		private void Resetisbasic()
		{
			this.isbasicSpecified = false;
		}

		// Token: 0x0600469B RID: 18075 RVA: 0x00086208 File Offset: 0x00084408
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001198 RID: 4504
		private uint? _skillHash;

		// Token: 0x04001199 RID: 4505
		private uint? _skillLevel;

		// Token: 0x0400119A RID: 4506
		private uint? _skillpoint;

		// Token: 0x0400119B RID: 4507
		private bool? _isbasic;

		// Token: 0x0400119C RID: 4508
		private IExtension extensionObject;
	}
}
