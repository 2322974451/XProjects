using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayMemberPrivilege")]
	[Serializable]
	public class PayMemberPrivilege : IExtensible
	{

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

		private bool ShouldSerializeusedReviveCount()
		{
			return this.usedReviveCountSpecified;
		}

		private void ResetusedReviveCount()
		{
			this.usedReviveCountSpecified = false;
		}

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

		private bool ShouldSerializeusedChatCount()
		{
			return this.usedChatCountSpecified;
		}

		private void ResetusedChatCount()
		{
			this.usedChatCountSpecified = false;
		}

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

		private bool ShouldSerializeusedAbyssCount()
		{
			return this.usedAbyssCountSpecified;
		}

		private void ResetusedAbyssCount()
		{
			this.usedAbyssCountSpecified = false;
		}

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

		private bool ShouldSerializeusedBossRushCount()
		{
			return this.usedBossRushCountSpecified;
		}

		private void ResetusedBossRushCount()
		{
			this.usedBossRushCountSpecified = false;
		}

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

		private bool ShouldSerializeusedBuyGreenAgateCount()
		{
			return this.usedBuyGreenAgateCountSpecified;
		}

		private void ResetusedBuyGreenAgateCount()
		{
			this.usedBuyGreenAgateCountSpecified = false;
		}

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

		private bool ShouldSerializeusedSuperRiskCount()
		{
			return this.usedSuperRiskCountSpecified;
		}

		private void ResetusedSuperRiskCount()
		{
			this.usedSuperRiskCountSpecified = false;
		}

		[ProtoMember(7, Name = "usedPrivilegeShop", DataFormat = DataFormat.Default)]
		public List<PayPrivilegeShop> usedPrivilegeShop
		{
			get
			{
				return this._usedPrivilegeShop;
			}
		}

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

		private bool ShouldSerializeusedRefreshShopCount()
		{
			return this.usedRefreshShopCountSpecified;
		}

		private void ResetusedRefreshShopCount()
		{
			this.usedRefreshShopCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _usedReviveCount;

		private int? _usedChatCount;

		private int? _usedAbyssCount;

		private int? _usedBossRushCount;

		private int? _usedBuyGreenAgateCount;

		private int? _usedSuperRiskCount;

		private readonly List<PayPrivilegeShop> _usedPrivilegeShop = new List<PayPrivilegeShop>();

		private int? _usedRefreshShopCount;

		private IExtension extensionObject;
	}
}
