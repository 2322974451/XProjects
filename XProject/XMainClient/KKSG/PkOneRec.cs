using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000606 RID: 1542
	[ProtoContract(Name = "PkOneRec")]
	[Serializable]
	public class PkOneRec : IExtensible
	{
		// Token: 0x17001D1D RID: 7453
		// (get) Token: 0x06005CE4 RID: 23780 RVA: 0x000B1020 File Offset: 0x000AF220
		// (set) Token: 0x06005CE5 RID: 23781 RVA: 0x000B104C File Offset: 0x000AF24C
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public PkResultType ret
		{
			get
			{
				return this._ret ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._ret = new PkResultType?(value);
			}
		}

		// Token: 0x17001D1E RID: 7454
		// (get) Token: 0x06005CE6 RID: 23782 RVA: 0x000B105C File Offset: 0x000AF25C
		// (set) Token: 0x06005CE7 RID: 23783 RVA: 0x000B107C File Offset: 0x000AF27C
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new PkResultType?(this.ret) : null);
				}
			}
		}

		// Token: 0x06005CE8 RID: 23784 RVA: 0x000B10C0 File Offset: 0x000AF2C0
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x06005CE9 RID: 23785 RVA: 0x000B10D8 File Offset: 0x000AF2D8
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x17001D1F RID: 7455
		// (get) Token: 0x06005CEA RID: 23786 RVA: 0x000B10E4 File Offset: 0x000AF2E4
		[ProtoMember(2, Name = "myside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> myside
		{
			get
			{
				return this._myside;
			}
		}

		// Token: 0x17001D20 RID: 7456
		// (get) Token: 0x06005CEB RID: 23787 RVA: 0x000B10FC File Offset: 0x000AF2FC
		[ProtoMember(3, Name = "opside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> opside
		{
			get
			{
				return this._opside;
			}
		}

		// Token: 0x17001D21 RID: 7457
		// (get) Token: 0x06005CEC RID: 23788 RVA: 0x000B1114 File Offset: 0x000AF314
		// (set) Token: 0x06005CED RID: 23789 RVA: 0x000B1140 File Offset: 0x000AF340
		[ProtoMember(4, IsRequired = false, Name = "cpoint", DataFormat = DataFormat.TwosComplement)]
		public int cpoint
		{
			get
			{
				return this._cpoint ?? 0;
			}
			set
			{
				this._cpoint = new int?(value);
			}
		}

		// Token: 0x17001D22 RID: 7458
		// (get) Token: 0x06005CEE RID: 23790 RVA: 0x000B1150 File Offset: 0x000AF350
		// (set) Token: 0x06005CEF RID: 23791 RVA: 0x000B1170 File Offset: 0x000AF370
		[XmlIgnore]
		[Browsable(false)]
		public bool cpointSpecified
		{
			get
			{
				return this._cpoint != null;
			}
			set
			{
				bool flag = value == (this._cpoint == null);
				if (flag)
				{
					this._cpoint = (value ? new int?(this.cpoint) : null);
				}
			}
		}

		// Token: 0x06005CF0 RID: 23792 RVA: 0x000B11B4 File Offset: 0x000AF3B4
		private bool ShouldSerializecpoint()
		{
			return this.cpointSpecified;
		}

		// Token: 0x06005CF1 RID: 23793 RVA: 0x000B11CC File Offset: 0x000AF3CC
		private void Resetcpoint()
		{
			this.cpointSpecified = false;
		}

		// Token: 0x06005CF2 RID: 23794 RVA: 0x000B11D8 File Offset: 0x000AF3D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001693 RID: 5779
		private PkResultType? _ret;

		// Token: 0x04001694 RID: 5780
		private readonly List<PvpRoleBrief> _myside = new List<PvpRoleBrief>();

		// Token: 0x04001695 RID: 5781
		private readonly List<PvpRoleBrief> _opside = new List<PvpRoleBrief>();

		// Token: 0x04001696 RID: 5782
		private int? _cpoint;

		// Token: 0x04001697 RID: 5783
		private IExtension extensionObject;
	}
}
