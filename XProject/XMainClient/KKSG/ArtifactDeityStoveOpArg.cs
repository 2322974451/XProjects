using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000498 RID: 1176
	[ProtoContract(Name = "ArtifactDeityStoveOpArg")]
	[Serializable]
	public class ArtifactDeityStoveOpArg : IExtensible
	{
		// Token: 0x170012C7 RID: 4807
		// (get) Token: 0x06003D42 RID: 15682 RVA: 0x00074EE4 File Offset: 0x000730E4
		// (set) Token: 0x06003D43 RID: 15683 RVA: 0x00074F10 File Offset: 0x00073110
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ArtifactDeityStoveOpType type
		{
			get
			{
				return this._type ?? ArtifactDeityStoveOpType.ArtifactDeityStove_Recast;
			}
			set
			{
				this._type = new ArtifactDeityStoveOpType?(value);
			}
		}

		// Token: 0x170012C8 RID: 4808
		// (get) Token: 0x06003D44 RID: 15684 RVA: 0x00074F20 File Offset: 0x00073120
		// (set) Token: 0x06003D45 RID: 15685 RVA: 0x00074F40 File Offset: 0x00073140
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
					this._type = (value ? new ArtifactDeityStoveOpType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003D46 RID: 15686 RVA: 0x00074F84 File Offset: 0x00073184
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003D47 RID: 15687 RVA: 0x00074F9C File Offset: 0x0007319C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170012C9 RID: 4809
		// (get) Token: 0x06003D48 RID: 15688 RVA: 0x00074FA8 File Offset: 0x000731A8
		// (set) Token: 0x06003D49 RID: 15689 RVA: 0x00074FD5 File Offset: 0x000731D5
		[ProtoMember(2, IsRequired = false, Name = "uid1", DataFormat = DataFormat.TwosComplement)]
		public ulong uid1
		{
			get
			{
				return this._uid1 ?? 0UL;
			}
			set
			{
				this._uid1 = new ulong?(value);
			}
		}

		// Token: 0x170012CA RID: 4810
		// (get) Token: 0x06003D4A RID: 15690 RVA: 0x00074FE4 File Offset: 0x000731E4
		// (set) Token: 0x06003D4B RID: 15691 RVA: 0x00075004 File Offset: 0x00073204
		[XmlIgnore]
		[Browsable(false)]
		public bool uid1Specified
		{
			get
			{
				return this._uid1 != null;
			}
			set
			{
				bool flag = value == (this._uid1 == null);
				if (flag)
				{
					this._uid1 = (value ? new ulong?(this.uid1) : null);
				}
			}
		}

		// Token: 0x06003D4C RID: 15692 RVA: 0x00075048 File Offset: 0x00073248
		private bool ShouldSerializeuid1()
		{
			return this.uid1Specified;
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x00075060 File Offset: 0x00073260
		private void Resetuid1()
		{
			this.uid1Specified = false;
		}

		// Token: 0x170012CB RID: 4811
		// (get) Token: 0x06003D4E RID: 15694 RVA: 0x0007506C File Offset: 0x0007326C
		// (set) Token: 0x06003D4F RID: 15695 RVA: 0x00075099 File Offset: 0x00073299
		[ProtoMember(3, IsRequired = false, Name = "uid2", DataFormat = DataFormat.TwosComplement)]
		public ulong uid2
		{
			get
			{
				return this._uid2 ?? 0UL;
			}
			set
			{
				this._uid2 = new ulong?(value);
			}
		}

		// Token: 0x170012CC RID: 4812
		// (get) Token: 0x06003D50 RID: 15696 RVA: 0x000750A8 File Offset: 0x000732A8
		// (set) Token: 0x06003D51 RID: 15697 RVA: 0x000750C8 File Offset: 0x000732C8
		[XmlIgnore]
		[Browsable(false)]
		public bool uid2Specified
		{
			get
			{
				return this._uid2 != null;
			}
			set
			{
				bool flag = value == (this._uid2 == null);
				if (flag)
				{
					this._uid2 = (value ? new ulong?(this.uid2) : null);
				}
			}
		}

		// Token: 0x06003D52 RID: 15698 RVA: 0x0007510C File Offset: 0x0007330C
		private bool ShouldSerializeuid2()
		{
			return this.uid2Specified;
		}

		// Token: 0x06003D53 RID: 15699 RVA: 0x00075124 File Offset: 0x00073324
		private void Resetuid2()
		{
			this.uid2Specified = false;
		}

		// Token: 0x170012CD RID: 4813
		// (get) Token: 0x06003D54 RID: 15700 RVA: 0x00075130 File Offset: 0x00073330
		// (set) Token: 0x06003D55 RID: 15701 RVA: 0x0007515C File Offset: 0x0007335C
		[ProtoMember(4, IsRequired = false, Name = "isUsedStone", DataFormat = DataFormat.Default)]
		public bool isUsedStone
		{
			get
			{
				return this._isUsedStone ?? false;
			}
			set
			{
				this._isUsedStone = new bool?(value);
			}
		}

		// Token: 0x170012CE RID: 4814
		// (get) Token: 0x06003D56 RID: 15702 RVA: 0x0007516C File Offset: 0x0007336C
		// (set) Token: 0x06003D57 RID: 15703 RVA: 0x0007518C File Offset: 0x0007338C
		[XmlIgnore]
		[Browsable(false)]
		public bool isUsedStoneSpecified
		{
			get
			{
				return this._isUsedStone != null;
			}
			set
			{
				bool flag = value == (this._isUsedStone == null);
				if (flag)
				{
					this._isUsedStone = (value ? new bool?(this.isUsedStone) : null);
				}
			}
		}

		// Token: 0x06003D58 RID: 15704 RVA: 0x000751D0 File Offset: 0x000733D0
		private bool ShouldSerializeisUsedStone()
		{
			return this.isUsedStoneSpecified;
		}

		// Token: 0x06003D59 RID: 15705 RVA: 0x000751E8 File Offset: 0x000733E8
		private void ResetisUsedStone()
		{
			this.isUsedStoneSpecified = false;
		}

		// Token: 0x06003D5A RID: 15706 RVA: 0x000751F4 File Offset: 0x000733F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F42 RID: 3906
		private ArtifactDeityStoveOpType? _type;

		// Token: 0x04000F43 RID: 3907
		private ulong? _uid1;

		// Token: 0x04000F44 RID: 3908
		private ulong? _uid2;

		// Token: 0x04000F45 RID: 3909
		private bool? _isUsedStone;

		// Token: 0x04000F46 RID: 3910
		private IExtension extensionObject;
	}
}
