using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000642 RID: 1602
	[ProtoContract(Name = "SpActivity")]
	[Serializable]
	public class SpActivity : IExtensible
	{
		// Token: 0x17001F56 RID: 8022
		// (get) Token: 0x06006370 RID: 25456 RVA: 0x000BDCB8 File Offset: 0x000BBEB8
		[ProtoMember(1, Name = "spActivity", DataFormat = DataFormat.Default)]
		public List<SpActivityOne> spActivity
		{
			get
			{
				return this._spActivity;
			}
		}

		// Token: 0x17001F57 RID: 8023
		// (get) Token: 0x06006371 RID: 25457 RVA: 0x000BDCD0 File Offset: 0x000BBED0
		// (set) Token: 0x06006372 RID: 25458 RVA: 0x000BDCFC File Offset: 0x000BBEFC
		[ProtoMember(2, IsRequired = false, Name = "lastBackFlowStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastBackFlowStartTime
		{
			get
			{
				return this._lastBackFlowStartTime ?? 0U;
			}
			set
			{
				this._lastBackFlowStartTime = new uint?(value);
			}
		}

		// Token: 0x17001F58 RID: 8024
		// (get) Token: 0x06006373 RID: 25459 RVA: 0x000BDD0C File Offset: 0x000BBF0C
		// (set) Token: 0x06006374 RID: 25460 RVA: 0x000BDD2C File Offset: 0x000BBF2C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastBackFlowStartTimeSpecified
		{
			get
			{
				return this._lastBackFlowStartTime != null;
			}
			set
			{
				bool flag = value == (this._lastBackFlowStartTime == null);
				if (flag)
				{
					this._lastBackFlowStartTime = (value ? new uint?(this.lastBackFlowStartTime) : null);
				}
			}
		}

		// Token: 0x06006375 RID: 25461 RVA: 0x000BDD70 File Offset: 0x000BBF70
		private bool ShouldSerializelastBackFlowStartTime()
		{
			return this.lastBackFlowStartTimeSpecified;
		}

		// Token: 0x06006376 RID: 25462 RVA: 0x000BDD88 File Offset: 0x000BBF88
		private void ResetlastBackFlowStartTime()
		{
			this.lastBackFlowStartTimeSpecified = false;
		}

		// Token: 0x17001F59 RID: 8025
		// (get) Token: 0x06006377 RID: 25463 RVA: 0x000BDD94 File Offset: 0x000BBF94
		// (set) Token: 0x06006378 RID: 25464 RVA: 0x000BDDAC File Offset: 0x000BBFAC
		[ProtoMember(3, IsRequired = false, Name = "argentaPreData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArgentaPreData argentaPreData
		{
			get
			{
				return this._argentaPreData;
			}
			set
			{
				this._argentaPreData = value;
			}
		}

		// Token: 0x17001F5A RID: 8026
		// (get) Token: 0x06006379 RID: 25465 RVA: 0x000BDDB8 File Offset: 0x000BBFB8
		// (set) Token: 0x0600637A RID: 25466 RVA: 0x000BDDE4 File Offset: 0x000BBFE4
		[ProtoMember(4, IsRequired = false, Name = "lastArgentaStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastArgentaStartTime
		{
			get
			{
				return this._lastArgentaStartTime ?? 0U;
			}
			set
			{
				this._lastArgentaStartTime = new uint?(value);
			}
		}

		// Token: 0x17001F5B RID: 8027
		// (get) Token: 0x0600637B RID: 25467 RVA: 0x000BDDF4 File Offset: 0x000BBFF4
		// (set) Token: 0x0600637C RID: 25468 RVA: 0x000BDE14 File Offset: 0x000BC014
		[XmlIgnore]
		[Browsable(false)]
		public bool lastArgentaStartTimeSpecified
		{
			get
			{
				return this._lastArgentaStartTime != null;
			}
			set
			{
				bool flag = value == (this._lastArgentaStartTime == null);
				if (flag)
				{
					this._lastArgentaStartTime = (value ? new uint?(this.lastArgentaStartTime) : null);
				}
			}
		}

		// Token: 0x0600637D RID: 25469 RVA: 0x000BDE58 File Offset: 0x000BC058
		private bool ShouldSerializelastArgentaStartTime()
		{
			return this.lastArgentaStartTimeSpecified;
		}

		// Token: 0x0600637E RID: 25470 RVA: 0x000BDE70 File Offset: 0x000BC070
		private void ResetlastArgentaStartTime()
		{
			this.lastArgentaStartTimeSpecified = false;
		}

		// Token: 0x17001F5C RID: 8028
		// (get) Token: 0x0600637F RID: 25471 RVA: 0x000BDE7C File Offset: 0x000BC07C
		// (set) Token: 0x06006380 RID: 25472 RVA: 0x000BDE94 File Offset: 0x000BC094
		[ProtoMember(5, IsRequired = false, Name = "backflowPreData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowPreData backflowPreData
		{
			get
			{
				return this._backflowPreData;
			}
			set
			{
				this._backflowPreData = value;
			}
		}

		// Token: 0x06006381 RID: 25473 RVA: 0x000BDEA0 File Offset: 0x000BC0A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001816 RID: 6166
		private readonly List<SpActivityOne> _spActivity = new List<SpActivityOne>();

		// Token: 0x04001817 RID: 6167
		private uint? _lastBackFlowStartTime;

		// Token: 0x04001818 RID: 6168
		private ArgentaPreData _argentaPreData = null;

		// Token: 0x04001819 RID: 6169
		private uint? _lastArgentaStartTime;

		// Token: 0x0400181A RID: 6170
		private BackFlowPreData _backflowPreData = null;

		// Token: 0x0400181B RID: 6171
		private IExtension extensionObject;
	}
}
