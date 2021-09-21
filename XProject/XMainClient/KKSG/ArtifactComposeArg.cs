using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FC RID: 1020
	[ProtoContract(Name = "ArtifactComposeArg")]
	[Serializable]
	public class ArtifactComposeArg : IExtensible
	{
		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x060035FE RID: 13822 RVA: 0x000676E8 File Offset: 0x000658E8
		// (set) Token: 0x060035FF RID: 13823 RVA: 0x00067714 File Offset: 0x00065914
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ArtifactComposeType type
		{
			get
			{
				return this._type ?? ArtifactComposeType.ArtifactCompose_Single;
			}
			set
			{
				this._type = new ArtifactComposeType?(value);
			}
		}

		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06003600 RID: 13824 RVA: 0x00067724 File Offset: 0x00065924
		// (set) Token: 0x06003601 RID: 13825 RVA: 0x00067744 File Offset: 0x00065944
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ArtifactComposeType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003602 RID: 13826 RVA: 0x00067788 File Offset: 0x00065988
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003603 RID: 13827 RVA: 0x000677A0 File Offset: 0x000659A0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06003604 RID: 13828 RVA: 0x000677AC File Offset: 0x000659AC
		[ProtoMember(2, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06003605 RID: 13829 RVA: 0x000677C4 File Offset: 0x000659C4
		// (set) Token: 0x06003606 RID: 13830 RVA: 0x000677F0 File Offset: 0x000659F0
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06003607 RID: 13831 RVA: 0x00067800 File Offset: 0x00065A00
		// (set) Token: 0x06003608 RID: 13832 RVA: 0x00067820 File Offset: 0x00065A20
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06003609 RID: 13833 RVA: 0x00067864 File Offset: 0x00065A64
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600360A RID: 13834 RVA: 0x0006787C File Offset: 0x00065A7C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x0600360B RID: 13835 RVA: 0x00067888 File Offset: 0x00065A88
		[ProtoMember(4, Name = "qualitys", DataFormat = DataFormat.TwosComplement)]
		public List<uint> qualitys
		{
			get
			{
				return this._qualitys;
			}
		}

		// Token: 0x0600360C RID: 13836 RVA: 0x000678A0 File Offset: 0x00065AA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D6B RID: 3435
		private ArtifactComposeType? _type;

		// Token: 0x04000D6C RID: 3436
		private readonly List<ulong> _uids = new List<ulong>();

		// Token: 0x04000D6D RID: 3437
		private uint? _level;

		// Token: 0x04000D6E RID: 3438
		private readonly List<uint> _qualitys = new List<uint>();

		// Token: 0x04000D6F RID: 3439
		private IExtension extensionObject;
	}
}
