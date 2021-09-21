using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000582 RID: 1410
	[ProtoContract(Name = "DoodadInfo")]
	[Serializable]
	public class DoodadInfo : IExtensible
	{
		// Token: 0x17001683 RID: 5763
		// (get) Token: 0x06004954 RID: 18772 RVA: 0x0008B61C File Offset: 0x0008981C
		// (set) Token: 0x06004955 RID: 18773 RVA: 0x0008B648 File Offset: 0x00089848
		[ProtoMember(1, IsRequired = false, Name = "waveid", DataFormat = DataFormat.TwosComplement)]
		public int waveid
		{
			get
			{
				return this._waveid ?? 0;
			}
			set
			{
				this._waveid = new int?(value);
			}
		}

		// Token: 0x17001684 RID: 5764
		// (get) Token: 0x06004956 RID: 18774 RVA: 0x0008B658 File Offset: 0x00089858
		// (set) Token: 0x06004957 RID: 18775 RVA: 0x0008B678 File Offset: 0x00089878
		[XmlIgnore]
		[Browsable(false)]
		public bool waveidSpecified
		{
			get
			{
				return this._waveid != null;
			}
			set
			{
				bool flag = value == (this._waveid == null);
				if (flag)
				{
					this._waveid = (value ? new int?(this.waveid) : null);
				}
			}
		}

		// Token: 0x06004958 RID: 18776 RVA: 0x0008B6BC File Offset: 0x000898BC
		private bool ShouldSerializewaveid()
		{
			return this.waveidSpecified;
		}

		// Token: 0x06004959 RID: 18777 RVA: 0x0008B6D4 File Offset: 0x000898D4
		private void Resetwaveid()
		{
			this.waveidSpecified = false;
		}

		// Token: 0x17001685 RID: 5765
		// (get) Token: 0x0600495A RID: 18778 RVA: 0x0008B6E0 File Offset: 0x000898E0
		// (set) Token: 0x0600495B RID: 18779 RVA: 0x0008B70C File Offset: 0x0008990C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17001686 RID: 5766
		// (get) Token: 0x0600495C RID: 18780 RVA: 0x0008B71C File Offset: 0x0008991C
		// (set) Token: 0x0600495D RID: 18781 RVA: 0x0008B73C File Offset: 0x0008993C
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
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x0600495E RID: 18782 RVA: 0x0008B780 File Offset: 0x00089980
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600495F RID: 18783 RVA: 0x0008B798 File Offset: 0x00089998
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001687 RID: 5767
		// (get) Token: 0x06004960 RID: 18784 RVA: 0x0008B7A4 File Offset: 0x000899A4
		// (set) Token: 0x06004961 RID: 18785 RVA: 0x0008B7D0 File Offset: 0x000899D0
		[ProtoMember(3, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001688 RID: 5768
		// (get) Token: 0x06004962 RID: 18786 RVA: 0x0008B7E0 File Offset: 0x000899E0
		// (set) Token: 0x06004963 RID: 18787 RVA: 0x0008B800 File Offset: 0x00089A00
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06004964 RID: 18788 RVA: 0x0008B844 File Offset: 0x00089A44
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06004965 RID: 18789 RVA: 0x0008B85C File Offset: 0x00089A5C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001689 RID: 5769
		// (get) Token: 0x06004966 RID: 18790 RVA: 0x0008B868 File Offset: 0x00089A68
		// (set) Token: 0x06004967 RID: 18791 RVA: 0x0008B894 File Offset: 0x00089A94
		[ProtoMember(4, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x1700168A RID: 5770
		// (get) Token: 0x06004968 RID: 18792 RVA: 0x0008B8A4 File Offset: 0x00089AA4
		// (set) Token: 0x06004969 RID: 18793 RVA: 0x0008B8C4 File Offset: 0x00089AC4
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x0600496A RID: 18794 RVA: 0x0008B908 File Offset: 0x00089B08
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600496B RID: 18795 RVA: 0x0008B920 File Offset: 0x00089B20
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x0600496C RID: 18796 RVA: 0x0008B92C File Offset: 0x00089B2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001251 RID: 4689
		private int? _waveid;

		// Token: 0x04001252 RID: 4690
		private int? _type;

		// Token: 0x04001253 RID: 4691
		private uint? _id;

		// Token: 0x04001254 RID: 4692
		private uint? _count;

		// Token: 0x04001255 RID: 4693
		private IExtension extensionObject;
	}
}
