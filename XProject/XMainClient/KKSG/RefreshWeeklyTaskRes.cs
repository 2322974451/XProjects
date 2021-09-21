using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E4 RID: 1252
	[ProtoContract(Name = "RefreshWeeklyTaskRes")]
	[Serializable]
	public class RefreshWeeklyTaskRes : IExtensible
	{
		// Token: 0x170013CD RID: 5069
		// (get) Token: 0x060040B4 RID: 16564 RVA: 0x0007B380 File Offset: 0x00079580
		// (set) Token: 0x060040B5 RID: 16565 RVA: 0x0007B3AC File Offset: 0x000795AC
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170013CE RID: 5070
		// (get) Token: 0x060040B6 RID: 16566 RVA: 0x0007B3BC File Offset: 0x000795BC
		// (set) Token: 0x060040B7 RID: 16567 RVA: 0x0007B3DC File Offset: 0x000795DC
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060040B8 RID: 16568 RVA: 0x0007B420 File Offset: 0x00079620
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060040B9 RID: 16569 RVA: 0x0007B438 File Offset: 0x00079638
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170013CF RID: 5071
		// (get) Token: 0x060040BA RID: 16570 RVA: 0x0007B444 File Offset: 0x00079644
		// (set) Token: 0x060040BB RID: 16571 RVA: 0x0007B45C File Offset: 0x0007965C
		[ProtoMember(2, IsRequired = false, Name = "task", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeeklyTaskInfo task
		{
			get
			{
				return this._task;
			}
			set
			{
				this._task = value;
			}
		}

		// Token: 0x060040BC RID: 16572 RVA: 0x0007B468 File Offset: 0x00079668
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001020 RID: 4128
		private ErrorCode? _result;

		// Token: 0x04001021 RID: 4129
		private WeeklyTaskInfo _task = null;

		// Token: 0x04001022 RID: 4130
		private IExtension extensionObject;
	}
}
