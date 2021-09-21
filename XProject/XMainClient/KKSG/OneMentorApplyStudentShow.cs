using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D7 RID: 1751
	[ProtoContract(Name = "OneMentorApplyStudentShow")]
	[Serializable]
	public class OneMentorApplyStudentShow : IExtensible
	{
		// Token: 0x170024D8 RID: 9432
		// (get) Token: 0x0600745E RID: 29790 RVA: 0x000DEAB4 File Offset: 0x000DCCB4
		// (set) Token: 0x0600745F RID: 29791 RVA: 0x000DEACC File Offset: 0x000DCCCC
		[ProtoMember(1, IsRequired = false, Name = "oneStudent", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo oneStudent
		{
			get
			{
				return this._oneStudent;
			}
			set
			{
				this._oneStudent = value;
			}
		}

		// Token: 0x170024D9 RID: 9433
		// (get) Token: 0x06007460 RID: 29792 RVA: 0x000DEAD8 File Offset: 0x000DCCD8
		// (set) Token: 0x06007461 RID: 29793 RVA: 0x000DEB04 File Offset: 0x000DCD04
		[ProtoMember(2, IsRequired = false, Name = "hasApply", DataFormat = DataFormat.Default)]
		public bool hasApply
		{
			get
			{
				return this._hasApply ?? false;
			}
			set
			{
				this._hasApply = new bool?(value);
			}
		}

		// Token: 0x170024DA RID: 9434
		// (get) Token: 0x06007462 RID: 29794 RVA: 0x000DEB14 File Offset: 0x000DCD14
		// (set) Token: 0x06007463 RID: 29795 RVA: 0x000DEB34 File Offset: 0x000DCD34
		[XmlIgnore]
		[Browsable(false)]
		public bool hasApplySpecified
		{
			get
			{
				return this._hasApply != null;
			}
			set
			{
				bool flag = value == (this._hasApply == null);
				if (flag)
				{
					this._hasApply = (value ? new bool?(this.hasApply) : null);
				}
			}
		}

		// Token: 0x06007464 RID: 29796 RVA: 0x000DEB78 File Offset: 0x000DCD78
		private bool ShouldSerializehasApply()
		{
			return this.hasApplySpecified;
		}

		// Token: 0x06007465 RID: 29797 RVA: 0x000DEB90 File Offset: 0x000DCD90
		private void ResethasApply()
		{
			this.hasApplySpecified = false;
		}

		// Token: 0x170024DB RID: 9435
		// (get) Token: 0x06007466 RID: 29798 RVA: 0x000DEB9C File Offset: 0x000DCD9C
		// (set) Token: 0x06007467 RID: 29799 RVA: 0x000DEBBD File Offset: 0x000DCDBD
		[ProtoMember(3, IsRequired = false, Name = "applyWords", DataFormat = DataFormat.Default)]
		public string applyWords
		{
			get
			{
				return this._applyWords ?? "";
			}
			set
			{
				this._applyWords = value;
			}
		}

		// Token: 0x170024DC RID: 9436
		// (get) Token: 0x06007468 RID: 29800 RVA: 0x000DEBC8 File Offset: 0x000DCDC8
		// (set) Token: 0x06007469 RID: 29801 RVA: 0x000DEBE4 File Offset: 0x000DCDE4
		[XmlIgnore]
		[Browsable(false)]
		public bool applyWordsSpecified
		{
			get
			{
				return this._applyWords != null;
			}
			set
			{
				bool flag = value == (this._applyWords == null);
				if (flag)
				{
					this._applyWords = (value ? this.applyWords : null);
				}
			}
		}

		// Token: 0x0600746A RID: 29802 RVA: 0x000DEC14 File Offset: 0x000DCE14
		private bool ShouldSerializeapplyWords()
		{
			return this.applyWordsSpecified;
		}

		// Token: 0x0600746B RID: 29803 RVA: 0x000DEC2C File Offset: 0x000DCE2C
		private void ResetapplyWords()
		{
			this.applyWordsSpecified = false;
		}

		// Token: 0x0600746C RID: 29804 RVA: 0x000DEC38 File Offset: 0x000DCE38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BA6 RID: 7078
		private RoleBriefInfo _oneStudent = null;

		// Token: 0x04001BA7 RID: 7079
		private bool? _hasApply;

		// Token: 0x04001BA8 RID: 7080
		private string _applyWords;

		// Token: 0x04001BA9 RID: 7081
		private IExtension extensionObject;
	}
}
