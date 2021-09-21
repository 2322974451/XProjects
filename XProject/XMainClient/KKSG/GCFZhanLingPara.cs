using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000334 RID: 820
	[ProtoContract(Name = "GCFZhanLingPara")]
	[Serializable]
	public class GCFZhanLingPara : IExtensible
	{
		// Token: 0x17000E02 RID: 3586
		// (get) Token: 0x06002D22 RID: 11554 RVA: 0x000575AC File Offset: 0x000557AC
		// (set) Token: 0x06002D23 RID: 11555 RVA: 0x000575D8 File Offset: 0x000557D8
		[ProtoMember(1, IsRequired = false, Name = "zltype", DataFormat = DataFormat.TwosComplement)]
		public GCFZhanLingType zltype
		{
			get
			{
				return this._zltype ?? GCFZhanLingType.GCFZL_BEGIN;
			}
			set
			{
				this._zltype = new GCFZhanLingType?(value);
			}
		}

		// Token: 0x17000E03 RID: 3587
		// (get) Token: 0x06002D24 RID: 11556 RVA: 0x000575E8 File Offset: 0x000557E8
		// (set) Token: 0x06002D25 RID: 11557 RVA: 0x00057608 File Offset: 0x00055808
		[XmlIgnore]
		[Browsable(false)]
		public bool zltypeSpecified
		{
			get
			{
				return this._zltype != null;
			}
			set
			{
				bool flag = value == (this._zltype == null);
				if (flag)
				{
					this._zltype = (value ? new GCFZhanLingType?(this.zltype) : null);
				}
			}
		}

		// Token: 0x06002D26 RID: 11558 RVA: 0x0005764C File Offset: 0x0005584C
		private bool ShouldSerializezltype()
		{
			return this.zltypeSpecified;
		}

		// Token: 0x06002D27 RID: 11559 RVA: 0x00057664 File Offset: 0x00055864
		private void Resetzltype()
		{
			this.zltypeSpecified = false;
		}

		// Token: 0x17000E04 RID: 3588
		// (get) Token: 0x06002D28 RID: 11560 RVA: 0x00057670 File Offset: 0x00055870
		// (set) Token: 0x06002D29 RID: 11561 RVA: 0x0005769D File Offset: 0x0005589D
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17000E05 RID: 3589
		// (get) Token: 0x06002D2A RID: 11562 RVA: 0x000576AC File Offset: 0x000558AC
		// (set) Token: 0x06002D2B RID: 11563 RVA: 0x000576CC File Offset: 0x000558CC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06002D2C RID: 11564 RVA: 0x00057710 File Offset: 0x00055910
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06002D2D RID: 11565 RVA: 0x00057728 File Offset: 0x00055928
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17000E06 RID: 3590
		// (get) Token: 0x06002D2E RID: 11566 RVA: 0x00057734 File Offset: 0x00055934
		// (set) Token: 0x06002D2F RID: 11567 RVA: 0x00057760 File Offset: 0x00055960
		[ProtoMember(3, IsRequired = false, Name = "jdtype", DataFormat = DataFormat.TwosComplement)]
		public GCFJvDianType jdtype
		{
			get
			{
				return this._jdtype ?? GCFJvDianType.GCF_JUDIAN_UP;
			}
			set
			{
				this._jdtype = new GCFJvDianType?(value);
			}
		}

		// Token: 0x17000E07 RID: 3591
		// (get) Token: 0x06002D30 RID: 11568 RVA: 0x00057770 File Offset: 0x00055970
		// (set) Token: 0x06002D31 RID: 11569 RVA: 0x00057790 File Offset: 0x00055990
		[XmlIgnore]
		[Browsable(false)]
		public bool jdtypeSpecified
		{
			get
			{
				return this._jdtype != null;
			}
			set
			{
				bool flag = value == (this._jdtype == null);
				if (flag)
				{
					this._jdtype = (value ? new GCFJvDianType?(this.jdtype) : null);
				}
			}
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x000577D4 File Offset: 0x000559D4
		private bool ShouldSerializejdtype()
		{
			return this.jdtypeSpecified;
		}

		// Token: 0x06002D33 RID: 11571 RVA: 0x000577EC File Offset: 0x000559EC
		private void Resetjdtype()
		{
			this.jdtypeSpecified = false;
		}

		// Token: 0x06002D34 RID: 11572 RVA: 0x000577F8 File Offset: 0x000559F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B33 RID: 2867
		private GCFZhanLingType? _zltype;

		// Token: 0x04000B34 RID: 2868
		private ulong? _roleID;

		// Token: 0x04000B35 RID: 2869
		private GCFJvDianType? _jdtype;

		// Token: 0x04000B36 RID: 2870
		private IExtension extensionObject;
	}
}
