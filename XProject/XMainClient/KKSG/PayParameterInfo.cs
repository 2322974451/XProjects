using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034D RID: 845
	[ProtoContract(Name = "PayParameterInfo")]
	[Serializable]
	public class PayParameterInfo : IExtensible
	{
		// Token: 0x17000E4E RID: 3662
		// (get) Token: 0x06002E1C RID: 11804 RVA: 0x000592E8 File Offset: 0x000574E8
		// (set) Token: 0x06002E1D RID: 11805 RVA: 0x00059309 File Offset: 0x00057509
		[ProtoMember(1, IsRequired = false, Name = "openkey", DataFormat = DataFormat.Default)]
		public string openkey
		{
			get
			{
				return this._openkey ?? "";
			}
			set
			{
				this._openkey = value;
			}
		}

		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x06002E1E RID: 11806 RVA: 0x00059314 File Offset: 0x00057514
		// (set) Token: 0x06002E1F RID: 11807 RVA: 0x00059330 File Offset: 0x00057530
		[XmlIgnore]
		[Browsable(false)]
		public bool openkeySpecified
		{
			get
			{
				return this._openkey != null;
			}
			set
			{
				bool flag = value == (this._openkey == null);
				if (flag)
				{
					this._openkey = (value ? this.openkey : null);
				}
			}
		}

		// Token: 0x06002E20 RID: 11808 RVA: 0x00059360 File Offset: 0x00057560
		private bool ShouldSerializeopenkey()
		{
			return this.openkeySpecified;
		}

		// Token: 0x06002E21 RID: 11809 RVA: 0x00059378 File Offset: 0x00057578
		private void Resetopenkey()
		{
			this.openkeySpecified = false;
		}

		// Token: 0x17000E50 RID: 3664
		// (get) Token: 0x06002E22 RID: 11810 RVA: 0x00059384 File Offset: 0x00057584
		// (set) Token: 0x06002E23 RID: 11811 RVA: 0x000593A5 File Offset: 0x000575A5
		[ProtoMember(2, IsRequired = false, Name = "sessionId", DataFormat = DataFormat.Default)]
		public string sessionId
		{
			get
			{
				return this._sessionId ?? "";
			}
			set
			{
				this._sessionId = value;
			}
		}

		// Token: 0x17000E51 RID: 3665
		// (get) Token: 0x06002E24 RID: 11812 RVA: 0x000593B0 File Offset: 0x000575B0
		// (set) Token: 0x06002E25 RID: 11813 RVA: 0x000593CC File Offset: 0x000575CC
		[XmlIgnore]
		[Browsable(false)]
		public bool sessionIdSpecified
		{
			get
			{
				return this._sessionId != null;
			}
			set
			{
				bool flag = value == (this._sessionId == null);
				if (flag)
				{
					this._sessionId = (value ? this.sessionId : null);
				}
			}
		}

		// Token: 0x06002E26 RID: 11814 RVA: 0x000593FC File Offset: 0x000575FC
		private bool ShouldSerializesessionId()
		{
			return this.sessionIdSpecified;
		}

		// Token: 0x06002E27 RID: 11815 RVA: 0x00059414 File Offset: 0x00057614
		private void ResetsessionId()
		{
			this.sessionIdSpecified = false;
		}

		// Token: 0x17000E52 RID: 3666
		// (get) Token: 0x06002E28 RID: 11816 RVA: 0x00059420 File Offset: 0x00057620
		// (set) Token: 0x06002E29 RID: 11817 RVA: 0x00059441 File Offset: 0x00057641
		[ProtoMember(3, IsRequired = false, Name = "sessionType", DataFormat = DataFormat.Default)]
		public string sessionType
		{
			get
			{
				return this._sessionType ?? "";
			}
			set
			{
				this._sessionType = value;
			}
		}

		// Token: 0x17000E53 RID: 3667
		// (get) Token: 0x06002E2A RID: 11818 RVA: 0x0005944C File Offset: 0x0005764C
		// (set) Token: 0x06002E2B RID: 11819 RVA: 0x00059468 File Offset: 0x00057668
		[XmlIgnore]
		[Browsable(false)]
		public bool sessionTypeSpecified
		{
			get
			{
				return this._sessionType != null;
			}
			set
			{
				bool flag = value == (this._sessionType == null);
				if (flag)
				{
					this._sessionType = (value ? this.sessionType : null);
				}
			}
		}

		// Token: 0x06002E2C RID: 11820 RVA: 0x00059498 File Offset: 0x00057698
		private bool ShouldSerializesessionType()
		{
			return this.sessionTypeSpecified;
		}

		// Token: 0x06002E2D RID: 11821 RVA: 0x000594B0 File Offset: 0x000576B0
		private void ResetsessionType()
		{
			this.sessionTypeSpecified = false;
		}

		// Token: 0x17000E54 RID: 3668
		// (get) Token: 0x06002E2E RID: 11822 RVA: 0x000594BC File Offset: 0x000576BC
		// (set) Token: 0x06002E2F RID: 11823 RVA: 0x000594DD File Offset: 0x000576DD
		[ProtoMember(4, IsRequired = false, Name = "pf", DataFormat = DataFormat.Default)]
		public string pf
		{
			get
			{
				return this._pf ?? "";
			}
			set
			{
				this._pf = value;
			}
		}

		// Token: 0x17000E55 RID: 3669
		// (get) Token: 0x06002E30 RID: 11824 RVA: 0x000594E8 File Offset: 0x000576E8
		// (set) Token: 0x06002E31 RID: 11825 RVA: 0x00059504 File Offset: 0x00057704
		[XmlIgnore]
		[Browsable(false)]
		public bool pfSpecified
		{
			get
			{
				return this._pf != null;
			}
			set
			{
				bool flag = value == (this._pf == null);
				if (flag)
				{
					this._pf = (value ? this.pf : null);
				}
			}
		}

		// Token: 0x06002E32 RID: 11826 RVA: 0x00059534 File Offset: 0x00057734
		private bool ShouldSerializepf()
		{
			return this.pfSpecified;
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x0005954C File Offset: 0x0005774C
		private void Resetpf()
		{
			this.pfSpecified = false;
		}

		// Token: 0x17000E56 RID: 3670
		// (get) Token: 0x06002E34 RID: 11828 RVA: 0x00059558 File Offset: 0x00057758
		// (set) Token: 0x06002E35 RID: 11829 RVA: 0x00059579 File Offset: 0x00057779
		[ProtoMember(5, IsRequired = false, Name = "pfKey", DataFormat = DataFormat.Default)]
		public string pfKey
		{
			get
			{
				return this._pfKey ?? "";
			}
			set
			{
				this._pfKey = value;
			}
		}

		// Token: 0x17000E57 RID: 3671
		// (get) Token: 0x06002E36 RID: 11830 RVA: 0x00059584 File Offset: 0x00057784
		// (set) Token: 0x06002E37 RID: 11831 RVA: 0x000595A0 File Offset: 0x000577A0
		[XmlIgnore]
		[Browsable(false)]
		public bool pfKeySpecified
		{
			get
			{
				return this._pfKey != null;
			}
			set
			{
				bool flag = value == (this._pfKey == null);
				if (flag)
				{
					this._pfKey = (value ? this.pfKey : null);
				}
			}
		}

		// Token: 0x06002E38 RID: 11832 RVA: 0x000595D0 File Offset: 0x000577D0
		private bool ShouldSerializepfKey()
		{
			return this.pfKeySpecified;
		}

		// Token: 0x06002E39 RID: 11833 RVA: 0x000595E8 File Offset: 0x000577E8
		private void ResetpfKey()
		{
			this.pfKeySpecified = false;
		}

		// Token: 0x17000E58 RID: 3672
		// (get) Token: 0x06002E3A RID: 11834 RVA: 0x000595F4 File Offset: 0x000577F4
		// (set) Token: 0x06002E3B RID: 11835 RVA: 0x00059615 File Offset: 0x00057815
		[ProtoMember(6, IsRequired = false, Name = "appid", DataFormat = DataFormat.Default)]
		public string appid
		{
			get
			{
				return this._appid ?? "";
			}
			set
			{
				this._appid = value;
			}
		}

		// Token: 0x17000E59 RID: 3673
		// (get) Token: 0x06002E3C RID: 11836 RVA: 0x00059620 File Offset: 0x00057820
		// (set) Token: 0x06002E3D RID: 11837 RVA: 0x0005963C File Offset: 0x0005783C
		[XmlIgnore]
		[Browsable(false)]
		public bool appidSpecified
		{
			get
			{
				return this._appid != null;
			}
			set
			{
				bool flag = value == (this._appid == null);
				if (flag)
				{
					this._appid = (value ? this.appid : null);
				}
			}
		}

		// Token: 0x06002E3E RID: 11838 RVA: 0x0005966C File Offset: 0x0005786C
		private bool ShouldSerializeappid()
		{
			return this.appidSpecified;
		}

		// Token: 0x06002E3F RID: 11839 RVA: 0x00059684 File Offset: 0x00057884
		private void Resetappid()
		{
			this.appidSpecified = false;
		}

		// Token: 0x06002E40 RID: 11840 RVA: 0x00059690 File Offset: 0x00057890
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B79 RID: 2937
		private string _openkey;

		// Token: 0x04000B7A RID: 2938
		private string _sessionId;

		// Token: 0x04000B7B RID: 2939
		private string _sessionType;

		// Token: 0x04000B7C RID: 2940
		private string _pf;

		// Token: 0x04000B7D RID: 2941
		private string _pfKey;

		// Token: 0x04000B7E RID: 2942
		private string _appid;

		// Token: 0x04000B7F RID: 2943
		private IExtension extensionObject;
	}
}
