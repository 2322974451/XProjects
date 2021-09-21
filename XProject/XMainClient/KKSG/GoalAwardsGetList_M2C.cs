using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D4 RID: 1236
	[ProtoContract(Name = "GoalAwardsGetList_M2C")]
	[Serializable]
	public class GoalAwardsGetList_M2C : IExtensible
	{
		// Token: 0x1700139D RID: 5021
		// (get) Token: 0x06004014 RID: 16404 RVA: 0x0007A0E4 File Offset: 0x000782E4
		[ProtoMember(1, Name = "goalAwardsList", DataFormat = DataFormat.Default)]
		public List<GoalAwardsInfo> goalAwardsList
		{
			get
			{
				return this._goalAwardsList;
			}
		}

		// Token: 0x1700139E RID: 5022
		// (get) Token: 0x06004015 RID: 16405 RVA: 0x0007A0FC File Offset: 0x000782FC
		// (set) Token: 0x06004016 RID: 16406 RVA: 0x0007A128 File Offset: 0x00078328
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700139F RID: 5023
		// (get) Token: 0x06004017 RID: 16407 RVA: 0x0007A138 File Offset: 0x00078338
		// (set) Token: 0x06004018 RID: 16408 RVA: 0x0007A158 File Offset: 0x00078358
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06004019 RID: 16409 RVA: 0x0007A19C File Offset: 0x0007839C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600401A RID: 16410 RVA: 0x0007A1B4 File Offset: 0x000783B4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600401B RID: 16411 RVA: 0x0007A1C0 File Offset: 0x000783C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FF4 RID: 4084
		private readonly List<GoalAwardsInfo> _goalAwardsList = new List<GoalAwardsInfo>();

		// Token: 0x04000FF5 RID: 4085
		private ErrorCode? _errorcode;

		// Token: 0x04000FF6 RID: 4086
		private IExtension extensionObject;
	}
}
