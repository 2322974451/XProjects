using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000487 RID: 1159
	[ProtoContract(Name = "NotifyMarriageDivorceApplyData")]
	[Serializable]
	public class NotifyMarriageDivorceApplyData : IExtensible
	{
		// Token: 0x17001291 RID: 4753
		// (get) Token: 0x06003C8C RID: 15500 RVA: 0x00073A58 File Offset: 0x00071C58
		// (set) Token: 0x06003C8D RID: 15501 RVA: 0x00073A84 File Offset: 0x00071C84
		[ProtoMember(1, IsRequired = false, Name = "isApplyCancel", DataFormat = DataFormat.Default)]
		public bool isApplyCancel
		{
			get
			{
				return this._isApplyCancel ?? false;
			}
			set
			{
				this._isApplyCancel = new bool?(value);
			}
		}

		// Token: 0x17001292 RID: 4754
		// (get) Token: 0x06003C8E RID: 15502 RVA: 0x00073A94 File Offset: 0x00071C94
		// (set) Token: 0x06003C8F RID: 15503 RVA: 0x00073AB4 File Offset: 0x00071CB4
		[XmlIgnore]
		[Browsable(false)]
		public bool isApplyCancelSpecified
		{
			get
			{
				return this._isApplyCancel != null;
			}
			set
			{
				bool flag = value == (this._isApplyCancel == null);
				if (flag)
				{
					this._isApplyCancel = (value ? new bool?(this.isApplyCancel) : null);
				}
			}
		}

		// Token: 0x06003C90 RID: 15504 RVA: 0x00073AF8 File Offset: 0x00071CF8
		private bool ShouldSerializeisApplyCancel()
		{
			return this.isApplyCancelSpecified;
		}

		// Token: 0x06003C91 RID: 15505 RVA: 0x00073B10 File Offset: 0x00071D10
		private void ResetisApplyCancel()
		{
			this.isApplyCancelSpecified = false;
		}

		// Token: 0x17001293 RID: 4755
		// (get) Token: 0x06003C92 RID: 15506 RVA: 0x00073B1C File Offset: 0x00071D1C
		// (set) Token: 0x06003C93 RID: 15507 RVA: 0x00073B49 File Offset: 0x00071D49
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

		// Token: 0x17001294 RID: 4756
		// (get) Token: 0x06003C94 RID: 15508 RVA: 0x00073B58 File Offset: 0x00071D58
		// (set) Token: 0x06003C95 RID: 15509 RVA: 0x00073B78 File Offset: 0x00071D78
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

		// Token: 0x06003C96 RID: 15510 RVA: 0x00073BBC File Offset: 0x00071DBC
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06003C97 RID: 15511 RVA: 0x00073BD4 File Offset: 0x00071DD4
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17001295 RID: 4757
		// (get) Token: 0x06003C98 RID: 15512 RVA: 0x00073BE0 File Offset: 0x00071DE0
		// (set) Token: 0x06003C99 RID: 15513 RVA: 0x00073C01 File Offset: 0x00071E01
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001296 RID: 4758
		// (get) Token: 0x06003C9A RID: 15514 RVA: 0x00073C0C File Offset: 0x00071E0C
		// (set) Token: 0x06003C9B RID: 15515 RVA: 0x00073C28 File Offset: 0x00071E28
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06003C9C RID: 15516 RVA: 0x00073C58 File Offset: 0x00071E58
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003C9D RID: 15517 RVA: 0x00073C70 File Offset: 0x00071E70
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001297 RID: 4759
		// (get) Token: 0x06003C9E RID: 15518 RVA: 0x00073C7C File Offset: 0x00071E7C
		// (set) Token: 0x06003C9F RID: 15519 RVA: 0x00073CA8 File Offset: 0x00071EA8
		[ProtoMember(4, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x17001298 RID: 4760
		// (get) Token: 0x06003CA0 RID: 15520 RVA: 0x00073CB8 File Offset: 0x00071EB8
		// (set) Token: 0x06003CA1 RID: 15521 RVA: 0x00073CD8 File Offset: 0x00071ED8
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x06003CA2 RID: 15522 RVA: 0x00073D1C File Offset: 0x00071F1C
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x06003CA3 RID: 15523 RVA: 0x00073D34 File Offset: 0x00071F34
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x06003CA4 RID: 15524 RVA: 0x00073D40 File Offset: 0x00071F40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F12 RID: 3858
		private bool? _isApplyCancel;

		// Token: 0x04000F13 RID: 3859
		private ulong? _roleID;

		// Token: 0x04000F14 RID: 3860
		private string _name;

		// Token: 0x04000F15 RID: 3861
		private int? _leftTime;

		// Token: 0x04000F16 RID: 3862
		private IExtension extensionObject;
	}
}
