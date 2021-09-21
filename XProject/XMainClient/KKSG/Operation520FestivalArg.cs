using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055C RID: 1372
	[ProtoContract(Name = "Operation520FestivalArg")]
	[Serializable]
	public class Operation520FestivalArg : IExtensible
	{
		// Token: 0x17001570 RID: 5488
		// (get) Token: 0x06004635 RID: 17973 RVA: 0x000855B0 File Offset: 0x000837B0
		// (set) Token: 0x06004636 RID: 17974 RVA: 0x000855DC File Offset: 0x000837DC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public Festival520Type type
		{
			get
			{
				return this._type ?? Festival520Type.Festival520_NormalDonate;
			}
			set
			{
				this._type = new Festival520Type?(value);
			}
		}

		// Token: 0x17001571 RID: 5489
		// (get) Token: 0x06004637 RID: 17975 RVA: 0x000855EC File Offset: 0x000837EC
		// (set) Token: 0x06004638 RID: 17976 RVA: 0x0008560C File Offset: 0x0008380C
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
					this._type = (value ? new Festival520Type?(this.type) : null);
				}
			}
		}

		// Token: 0x06004639 RID: 17977 RVA: 0x00085650 File Offset: 0x00083850
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600463A RID: 17978 RVA: 0x00085668 File Offset: 0x00083868
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001572 RID: 5490
		// (get) Token: 0x0600463B RID: 17979 RVA: 0x00085674 File Offset: 0x00083874
		// (set) Token: 0x0600463C RID: 17980 RVA: 0x000856A0 File Offset: 0x000838A0
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x17001573 RID: 5491
		// (get) Token: 0x0600463D RID: 17981 RVA: 0x000856B0 File Offset: 0x000838B0
		// (set) Token: 0x0600463E RID: 17982 RVA: 0x000856D0 File Offset: 0x000838D0
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x0600463F RID: 17983 RVA: 0x00085714 File Offset: 0x00083914
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06004640 RID: 17984 RVA: 0x0008572C File Offset: 0x0008392C
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x06004641 RID: 17985 RVA: 0x00085738 File Offset: 0x00083938
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001183 RID: 4483
		private Festival520Type? _type;

		// Token: 0x04001184 RID: 4484
		private uint? _num;

		// Token: 0x04001185 RID: 4485
		private IExtension extensionObject;
	}
}
