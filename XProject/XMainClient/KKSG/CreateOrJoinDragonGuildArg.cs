using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AB RID: 1195
	[ProtoContract(Name = "CreateOrJoinDragonGuildArg")]
	[Serializable]
	public class CreateOrJoinDragonGuildArg : IExtensible
	{
		// Token: 0x17001301 RID: 4865
		// (get) Token: 0x06003E0E RID: 15886 RVA: 0x000765F4 File Offset: 0x000747F4
		// (set) Token: 0x06003E0F RID: 15887 RVA: 0x00076620 File Offset: 0x00074820
		[ProtoMember(1, IsRequired = false, Name = "iscreate", DataFormat = DataFormat.Default)]
		public bool iscreate
		{
			get
			{
				return this._iscreate ?? false;
			}
			set
			{
				this._iscreate = new bool?(value);
			}
		}

		// Token: 0x17001302 RID: 4866
		// (get) Token: 0x06003E10 RID: 15888 RVA: 0x00076630 File Offset: 0x00074830
		// (set) Token: 0x06003E11 RID: 15889 RVA: 0x00076650 File Offset: 0x00074850
		[XmlIgnore]
		[Browsable(false)]
		public bool iscreateSpecified
		{
			get
			{
				return this._iscreate != null;
			}
			set
			{
				bool flag = value == (this._iscreate == null);
				if (flag)
				{
					this._iscreate = (value ? new bool?(this.iscreate) : null);
				}
			}
		}

		// Token: 0x06003E12 RID: 15890 RVA: 0x00076694 File Offset: 0x00074894
		private bool ShouldSerializeiscreate()
		{
			return this.iscreateSpecified;
		}

		// Token: 0x06003E13 RID: 15891 RVA: 0x000766AC File Offset: 0x000748AC
		private void Resetiscreate()
		{
			this.iscreateSpecified = false;
		}

		// Token: 0x17001303 RID: 4867
		// (get) Token: 0x06003E14 RID: 15892 RVA: 0x000766B8 File Offset: 0x000748B8
		// (set) Token: 0x06003E15 RID: 15893 RVA: 0x000766E5 File Offset: 0x000748E5
		[ProtoMember(2, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		// Token: 0x17001304 RID: 4868
		// (get) Token: 0x06003E16 RID: 15894 RVA: 0x000766F4 File Offset: 0x000748F4
		// (set) Token: 0x06003E17 RID: 15895 RVA: 0x00076714 File Offset: 0x00074914
		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		// Token: 0x06003E18 RID: 15896 RVA: 0x00076758 File Offset: 0x00074958
		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		// Token: 0x06003E19 RID: 15897 RVA: 0x00076770 File Offset: 0x00074970
		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		// Token: 0x17001305 RID: 4869
		// (get) Token: 0x06003E1A RID: 15898 RVA: 0x0007677C File Offset: 0x0007497C
		// (set) Token: 0x06003E1B RID: 15899 RVA: 0x0007679D File Offset: 0x0007499D
		[ProtoMember(3, IsRequired = false, Name = "dgname", DataFormat = DataFormat.Default)]
		public string dgname
		{
			get
			{
				return this._dgname ?? "";
			}
			set
			{
				this._dgname = value;
			}
		}

		// Token: 0x17001306 RID: 4870
		// (get) Token: 0x06003E1C RID: 15900 RVA: 0x000767A8 File Offset: 0x000749A8
		// (set) Token: 0x06003E1D RID: 15901 RVA: 0x000767C4 File Offset: 0x000749C4
		[XmlIgnore]
		[Browsable(false)]
		public bool dgnameSpecified
		{
			get
			{
				return this._dgname != null;
			}
			set
			{
				bool flag = value == (this._dgname == null);
				if (flag)
				{
					this._dgname = (value ? this.dgname : null);
				}
			}
		}

		// Token: 0x06003E1E RID: 15902 RVA: 0x000767F4 File Offset: 0x000749F4
		private bool ShouldSerializedgname()
		{
			return this.dgnameSpecified;
		}

		// Token: 0x06003E1F RID: 15903 RVA: 0x0007680C File Offset: 0x00074A0C
		private void Resetdgname()
		{
			this.dgnameSpecified = false;
		}

		// Token: 0x06003E20 RID: 15904 RVA: 0x00076818 File Offset: 0x00074A18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F75 RID: 3957
		private bool? _iscreate;

		// Token: 0x04000F76 RID: 3958
		private ulong? _dgid;

		// Token: 0x04000F77 RID: 3959
		private string _dgname;

		// Token: 0x04000F78 RID: 3960
		private IExtension extensionObject;
	}
}
