using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B9 RID: 697
	[ProtoContract(Name = "PayMemberPrivilege")]
	[Serializable]
	public class PayMemberPrivilege : IExtensible
	{
		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x060026A3 RID: 9891 RVA: 0x0004B2A4 File Offset: 0x000494A4
		// (set) Token: 0x060026A4 RID: 9892 RVA: 0x0004B2D0 File Offset: 0x000494D0
		[ProtoMember(1, IsRequired = false, Name = "usedReviveCount", DataFormat = DataFormat.TwosComplement)]
		public int usedReviveCount
		{
			get
			{
				return this._usedReviveCount ?? 0;
			}
			set
			{
				this._usedReviveCount = new int?(value);
			}
		}

		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x060026A5 RID: 9893 RVA: 0x0004B2E0 File Offset: 0x000494E0
		// (set) Token: 0x060026A6 RID: 9894 RVA: 0x0004B300 File Offset: 0x00049500
		[XmlIgnore]
		[Browsable(false)]
		public bool usedReviveCountSpecified
		{
			get
			{
				return this._usedReviveCount != null;
			}
			set
			{
				bool flag = value == (this._usedReviveCount == null);
				if (flag)
				{
					this._usedReviveCount = (value ? new int?(this.usedReviveCount) : null);
				}
			}
		}

		// Token: 0x060026A7 RID: 9895 RVA: 0x0004B344 File Offset: 0x00049544
		private bool ShouldSerializeusedReviveCount()
		{
			return this.usedReviveCountSpecified;
		}

		// Token: 0x060026A8 RID: 9896 RVA: 0x0004B35C File Offset: 0x0004955C
		private void ResetusedReviveCount()
		{
			this.usedReviveCountSpecified = false;
		}

		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x060026A9 RID: 9897 RVA: 0x0004B368 File Offset: 0x00049568
		// (set) Token: 0x060026AA RID: 9898 RVA: 0x0004B394 File Offset: 0x00049594
		[ProtoMember(2, IsRequired = false, Name = "usedChatCount", DataFormat = DataFormat.TwosComplement)]
		public int usedChatCount
		{
			get
			{
				return this._usedChatCount ?? 0;
			}
			set
			{
				this._usedChatCount = new int?(value);
			}
		}

		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x060026AB RID: 9899 RVA: 0x0004B3A4 File Offset: 0x000495A4
		// (set) Token: 0x060026AC RID: 9900 RVA: 0x0004B3C4 File Offset: 0x000495C4
		[XmlIgnore]
		[Browsable(false)]
		public bool usedChatCountSpecified
		{
			get
			{
				return this._usedChatCount != null;
			}
			set
			{
				bool flag = value == (this._usedChatCount == null);
				if (flag)
				{
					this._usedChatCount = (value ? new int?(this.usedChatCount) : null);
				}
			}
		}

		// Token: 0x060026AD RID: 9901 RVA: 0x0004B408 File Offset: 0x00049608
		private bool ShouldSerializeusedChatCount()
		{
			return this.usedChatCountSpecified;
		}

		// Token: 0x060026AE RID: 9902 RVA: 0x0004B420 File Offset: 0x00049620
		private void ResetusedChatCount()
		{
			this.usedChatCountSpecified = false;
		}

		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x060026AF RID: 9903 RVA: 0x0004B42C File Offset: 0x0004962C
		// (set) Token: 0x060026B0 RID: 9904 RVA: 0x0004B458 File Offset: 0x00049658
		[ProtoMember(3, IsRequired = false, Name = "usedAbyssCount", DataFormat = DataFormat.TwosComplement)]
		public int usedAbyssCount
		{
			get
			{
				return this._usedAbyssCount ?? 0;
			}
			set
			{
				this._usedAbyssCount = new int?(value);
			}
		}

		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x060026B1 RID: 9905 RVA: 0x0004B468 File Offset: 0x00049668
		// (set) Token: 0x060026B2 RID: 9906 RVA: 0x0004B488 File Offset: 0x00049688
		[XmlIgnore]
		[Browsable(false)]
		public bool usedAbyssCountSpecified
		{
			get
			{
				return this._usedAbyssCount != null;
			}
			set
			{
				bool flag = value == (this._usedAbyssCount == null);
				if (flag)
				{
					this._usedAbyssCount = (value ? new int?(this.usedAbyssCount) : null);
				}
			}
		}

		// Token: 0x060026B3 RID: 9907 RVA: 0x0004B4CC File Offset: 0x000496CC
		private bool ShouldSerializeusedAbyssCount()
		{
			return this.usedAbyssCountSpecified;
		}

		// Token: 0x060026B4 RID: 9908 RVA: 0x0004B4E4 File Offset: 0x000496E4
		private void ResetusedAbyssCount()
		{
			this.usedAbyssCountSpecified = false;
		}

		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x060026B5 RID: 9909 RVA: 0x0004B4F0 File Offset: 0x000496F0
		// (set) Token: 0x060026B6 RID: 9910 RVA: 0x0004B51C File Offset: 0x0004971C
		[ProtoMember(4, IsRequired = false, Name = "usedBossRushCount", DataFormat = DataFormat.TwosComplement)]
		public int usedBossRushCount
		{
			get
			{
				return this._usedBossRushCount ?? 0;
			}
			set
			{
				this._usedBossRushCount = new int?(value);
			}
		}

		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x060026B7 RID: 9911 RVA: 0x0004B52C File Offset: 0x0004972C
		// (set) Token: 0x060026B8 RID: 9912 RVA: 0x0004B54C File Offset: 0x0004974C
		[XmlIgnore]
		[Browsable(false)]
		public bool usedBossRushCountSpecified
		{
			get
			{
				return this._usedBossRushCount != null;
			}
			set
			{
				bool flag = value == (this._usedBossRushCount == null);
				if (flag)
				{
					this._usedBossRushCount = (value ? new int?(this.usedBossRushCount) : null);
				}
			}
		}

		// Token: 0x060026B9 RID: 9913 RVA: 0x0004B590 File Offset: 0x00049790
		private bool ShouldSerializeusedBossRushCount()
		{
			return this.usedBossRushCountSpecified;
		}

		// Token: 0x060026BA RID: 9914 RVA: 0x0004B5A8 File Offset: 0x000497A8
		private void ResetusedBossRushCount()
		{
			this.usedBossRushCountSpecified = false;
		}

		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x060026BB RID: 9915 RVA: 0x0004B5B4 File Offset: 0x000497B4
		// (set) Token: 0x060026BC RID: 9916 RVA: 0x0004B5E0 File Offset: 0x000497E0
		[ProtoMember(5, IsRequired = false, Name = "usedBuyGreenAgateCount", DataFormat = DataFormat.TwosComplement)]
		public int usedBuyGreenAgateCount
		{
			get
			{
				return this._usedBuyGreenAgateCount ?? 0;
			}
			set
			{
				this._usedBuyGreenAgateCount = new int?(value);
			}
		}

		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x060026BD RID: 9917 RVA: 0x0004B5F0 File Offset: 0x000497F0
		// (set) Token: 0x060026BE RID: 9918 RVA: 0x0004B610 File Offset: 0x00049810
		[XmlIgnore]
		[Browsable(false)]
		public bool usedBuyGreenAgateCountSpecified
		{
			get
			{
				return this._usedBuyGreenAgateCount != null;
			}
			set
			{
				bool flag = value == (this._usedBuyGreenAgateCount == null);
				if (flag)
				{
					this._usedBuyGreenAgateCount = (value ? new int?(this.usedBuyGreenAgateCount) : null);
				}
			}
		}

		// Token: 0x060026BF RID: 9919 RVA: 0x0004B654 File Offset: 0x00049854
		private bool ShouldSerializeusedBuyGreenAgateCount()
		{
			return this.usedBuyGreenAgateCountSpecified;
		}

		// Token: 0x060026C0 RID: 9920 RVA: 0x0004B66C File Offset: 0x0004986C
		private void ResetusedBuyGreenAgateCount()
		{
			this.usedBuyGreenAgateCountSpecified = false;
		}

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x060026C1 RID: 9921 RVA: 0x0004B678 File Offset: 0x00049878
		// (set) Token: 0x060026C2 RID: 9922 RVA: 0x0004B6A4 File Offset: 0x000498A4
		[ProtoMember(6, IsRequired = false, Name = "usedSuperRiskCount", DataFormat = DataFormat.TwosComplement)]
		public int usedSuperRiskCount
		{
			get
			{
				return this._usedSuperRiskCount ?? 0;
			}
			set
			{
				this._usedSuperRiskCount = new int?(value);
			}
		}

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x060026C3 RID: 9923 RVA: 0x0004B6B4 File Offset: 0x000498B4
		// (set) Token: 0x060026C4 RID: 9924 RVA: 0x0004B6D4 File Offset: 0x000498D4
		[XmlIgnore]
		[Browsable(false)]
		public bool usedSuperRiskCountSpecified
		{
			get
			{
				return this._usedSuperRiskCount != null;
			}
			set
			{
				bool flag = value == (this._usedSuperRiskCount == null);
				if (flag)
				{
					this._usedSuperRiskCount = (value ? new int?(this.usedSuperRiskCount) : null);
				}
			}
		}

		// Token: 0x060026C5 RID: 9925 RVA: 0x0004B718 File Offset: 0x00049918
		private bool ShouldSerializeusedSuperRiskCount()
		{
			return this.usedSuperRiskCountSpecified;
		}

		// Token: 0x060026C6 RID: 9926 RVA: 0x0004B730 File Offset: 0x00049930
		private void ResetusedSuperRiskCount()
		{
			this.usedSuperRiskCountSpecified = false;
		}

		// Token: 0x17000C10 RID: 3088
		// (get) Token: 0x060026C7 RID: 9927 RVA: 0x0004B73C File Offset: 0x0004993C
		[ProtoMember(7, Name = "usedPrivilegeShop", DataFormat = DataFormat.Default)]
		public List<PayPrivilegeShop> usedPrivilegeShop
		{
			get
			{
				return this._usedPrivilegeShop;
			}
		}

		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x060026C8 RID: 9928 RVA: 0x0004B754 File Offset: 0x00049954
		// (set) Token: 0x060026C9 RID: 9929 RVA: 0x0004B780 File Offset: 0x00049980
		[ProtoMember(8, IsRequired = false, Name = "usedRefreshShopCount", DataFormat = DataFormat.TwosComplement)]
		public int usedRefreshShopCount
		{
			get
			{
				return this._usedRefreshShopCount ?? 0;
			}
			set
			{
				this._usedRefreshShopCount = new int?(value);
			}
		}

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x060026CA RID: 9930 RVA: 0x0004B790 File Offset: 0x00049990
		// (set) Token: 0x060026CB RID: 9931 RVA: 0x0004B7B0 File Offset: 0x000499B0
		[XmlIgnore]
		[Browsable(false)]
		public bool usedRefreshShopCountSpecified
		{
			get
			{
				return this._usedRefreshShopCount != null;
			}
			set
			{
				bool flag = value == (this._usedRefreshShopCount == null);
				if (flag)
				{
					this._usedRefreshShopCount = (value ? new int?(this.usedRefreshShopCount) : null);
				}
			}
		}

		// Token: 0x060026CC RID: 9932 RVA: 0x0004B7F4 File Offset: 0x000499F4
		private bool ShouldSerializeusedRefreshShopCount()
		{
			return this.usedRefreshShopCountSpecified;
		}

		// Token: 0x060026CD RID: 9933 RVA: 0x0004B80C File Offset: 0x00049A0C
		private void ResetusedRefreshShopCount()
		{
			this.usedRefreshShopCountSpecified = false;
		}

		// Token: 0x060026CE RID: 9934 RVA: 0x0004B818 File Offset: 0x00049A18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400099A RID: 2458
		private int? _usedReviveCount;

		// Token: 0x0400099B RID: 2459
		private int? _usedChatCount;

		// Token: 0x0400099C RID: 2460
		private int? _usedAbyssCount;

		// Token: 0x0400099D RID: 2461
		private int? _usedBossRushCount;

		// Token: 0x0400099E RID: 2462
		private int? _usedBuyGreenAgateCount;

		// Token: 0x0400099F RID: 2463
		private int? _usedSuperRiskCount;

		// Token: 0x040009A0 RID: 2464
		private readonly List<PayPrivilegeShop> _usedPrivilegeShop = new List<PayPrivilegeShop>();

		// Token: 0x040009A1 RID: 2465
		private int? _usedRefreshShopCount;

		// Token: 0x040009A2 RID: 2466
		private IExtension extensionObject;
	}
}
