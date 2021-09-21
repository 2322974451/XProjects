using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064B RID: 1611
	[ProtoContract(Name = "BackFlowShopGood")]
	[Serializable]
	public class BackFlowShopGood : IExtensible
	{
		// Token: 0x17001F99 RID: 8089
		// (get) Token: 0x0600642F RID: 25647 RVA: 0x000BF34C File Offset: 0x000BD54C
		// (set) Token: 0x06006430 RID: 25648 RVA: 0x000BF378 File Offset: 0x000BD578
		[ProtoMember(1, IsRequired = false, Name = "GoodID", DataFormat = DataFormat.TwosComplement)]
		public uint GoodID
		{
			get
			{
				return this._GoodID ?? 0U;
			}
			set
			{
				this._GoodID = new uint?(value);
			}
		}

		// Token: 0x17001F9A RID: 8090
		// (get) Token: 0x06006431 RID: 25649 RVA: 0x000BF388 File Offset: 0x000BD588
		// (set) Token: 0x06006432 RID: 25650 RVA: 0x000BF3A8 File Offset: 0x000BD5A8
		[XmlIgnore]
		[Browsable(false)]
		public bool GoodIDSpecified
		{
			get
			{
				return this._GoodID != null;
			}
			set
			{
				bool flag = value == (this._GoodID == null);
				if (flag)
				{
					this._GoodID = (value ? new uint?(this.GoodID) : null);
				}
			}
		}

		// Token: 0x06006433 RID: 25651 RVA: 0x000BF3EC File Offset: 0x000BD5EC
		private bool ShouldSerializeGoodID()
		{
			return this.GoodIDSpecified;
		}

		// Token: 0x06006434 RID: 25652 RVA: 0x000BF404 File Offset: 0x000BD604
		private void ResetGoodID()
		{
			this.GoodIDSpecified = false;
		}

		// Token: 0x17001F9B RID: 8091
		// (get) Token: 0x06006435 RID: 25653 RVA: 0x000BF410 File Offset: 0x000BD610
		// (set) Token: 0x06006436 RID: 25654 RVA: 0x000BF43C File Offset: 0x000BD63C
		[ProtoMember(2, IsRequired = false, Name = "IsBuy", DataFormat = DataFormat.Default)]
		public bool IsBuy
		{
			get
			{
				return this._IsBuy ?? false;
			}
			set
			{
				this._IsBuy = new bool?(value);
			}
		}

		// Token: 0x17001F9C RID: 8092
		// (get) Token: 0x06006437 RID: 25655 RVA: 0x000BF44C File Offset: 0x000BD64C
		// (set) Token: 0x06006438 RID: 25656 RVA: 0x000BF46C File Offset: 0x000BD66C
		[XmlIgnore]
		[Browsable(false)]
		public bool IsBuySpecified
		{
			get
			{
				return this._IsBuy != null;
			}
			set
			{
				bool flag = value == (this._IsBuy == null);
				if (flag)
				{
					this._IsBuy = (value ? new bool?(this.IsBuy) : null);
				}
			}
		}

		// Token: 0x06006439 RID: 25657 RVA: 0x000BF4B0 File Offset: 0x000BD6B0
		private bool ShouldSerializeIsBuy()
		{
			return this.IsBuySpecified;
		}

		// Token: 0x0600643A RID: 25658 RVA: 0x000BF4C8 File Offset: 0x000BD6C8
		private void ResetIsBuy()
		{
			this.IsBuySpecified = false;
		}

		// Token: 0x17001F9D RID: 8093
		// (get) Token: 0x0600643B RID: 25659 RVA: 0x000BF4D4 File Offset: 0x000BD6D4
		// (set) Token: 0x0600643C RID: 25660 RVA: 0x000BF500 File Offset: 0x000BD700
		[ProtoMember(3, IsRequired = false, Name = "LockTime", DataFormat = DataFormat.TwosComplement)]
		public uint LockTime
		{
			get
			{
				return this._LockTime ?? 0U;
			}
			set
			{
				this._LockTime = new uint?(value);
			}
		}

		// Token: 0x17001F9E RID: 8094
		// (get) Token: 0x0600643D RID: 25661 RVA: 0x000BF510 File Offset: 0x000BD710
		// (set) Token: 0x0600643E RID: 25662 RVA: 0x000BF530 File Offset: 0x000BD730
		[XmlIgnore]
		[Browsable(false)]
		public bool LockTimeSpecified
		{
			get
			{
				return this._LockTime != null;
			}
			set
			{
				bool flag = value == (this._LockTime == null);
				if (flag)
				{
					this._LockTime = (value ? new uint?(this.LockTime) : null);
				}
			}
		}

		// Token: 0x0600643F RID: 25663 RVA: 0x000BF574 File Offset: 0x000BD774
		private bool ShouldSerializeLockTime()
		{
			return this.LockTimeSpecified;
		}

		// Token: 0x06006440 RID: 25664 RVA: 0x000BF58C File Offset: 0x000BD78C
		private void ResetLockTime()
		{
			this.LockTimeSpecified = false;
		}

		// Token: 0x06006441 RID: 25665 RVA: 0x000BF598 File Offset: 0x000BD798
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400184A RID: 6218
		private uint? _GoodID;

		// Token: 0x0400184B RID: 6219
		private bool? _IsBuy;

		// Token: 0x0400184C RID: 6220
		private uint? _LockTime;

		// Token: 0x0400184D RID: 6221
		private IExtension extensionObject;
	}
}
