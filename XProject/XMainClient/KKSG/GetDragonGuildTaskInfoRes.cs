using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BF RID: 1215
	[ProtoContract(Name = "GetDragonGuildTaskInfoRes")]
	[Serializable]
	public class GetDragonGuildTaskInfoRes : IExtensible
	{
		// Token: 0x1700135F RID: 4959
		// (get) Token: 0x06003F40 RID: 16192 RVA: 0x00078994 File Offset: 0x00076B94
		// (set) Token: 0x06003F41 RID: 16193 RVA: 0x000789C0 File Offset: 0x00076BC0
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001360 RID: 4960
		// (get) Token: 0x06003F42 RID: 16194 RVA: 0x000789D0 File Offset: 0x00076BD0
		// (set) Token: 0x06003F43 RID: 16195 RVA: 0x000789F0 File Offset: 0x00076BF0
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

		// Token: 0x06003F44 RID: 16196 RVA: 0x00078A34 File Offset: 0x00076C34
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003F45 RID: 16197 RVA: 0x00078A4C File Offset: 0x00076C4C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001361 RID: 4961
		// (get) Token: 0x06003F46 RID: 16198 RVA: 0x00078A58 File Offset: 0x00076C58
		// (set) Token: 0x06003F47 RID: 16199 RVA: 0x00078A84 File Offset: 0x00076C84
		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x17001362 RID: 4962
		// (get) Token: 0x06003F48 RID: 16200 RVA: 0x00078A94 File Offset: 0x00076C94
		// (set) Token: 0x06003F49 RID: 16201 RVA: 0x00078AB4 File Offset: 0x00076CB4
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x06003F4A RID: 16202 RVA: 0x00078AF8 File Offset: 0x00076CF8
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06003F4B RID: 16203 RVA: 0x00078B10 File Offset: 0x00076D10
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x17001363 RID: 4963
		// (get) Token: 0x06003F4C RID: 16204 RVA: 0x00078B1C File Offset: 0x00076D1C
		[ProtoMember(3, Name = "taskrecord", DataFormat = DataFormat.Default)]
		public List<DragonGuildTaskInfo> taskrecord
		{
			get
			{
				return this._taskrecord;
			}
		}

		// Token: 0x17001364 RID: 4964
		// (get) Token: 0x06003F4D RID: 16205 RVA: 0x00078B34 File Offset: 0x00076D34
		[ProtoMember(4, Name = "taskcompleted", DataFormat = DataFormat.Default)]
		public List<bool> taskcompleted
		{
			get
			{
				return this._taskcompleted;
			}
		}

		// Token: 0x17001365 RID: 4965
		// (get) Token: 0x06003F4E RID: 16206 RVA: 0x00078B4C File Offset: 0x00076D4C
		[ProtoMember(5, Name = "achiverecord", DataFormat = DataFormat.Default)]
		public List<DragonGuildTaskInfo> achiverecord
		{
			get
			{
				return this._achiverecord;
			}
		}

		// Token: 0x17001366 RID: 4966
		// (get) Token: 0x06003F4F RID: 16207 RVA: 0x00078B64 File Offset: 0x00076D64
		[ProtoMember(6, Name = "achivecompleted", DataFormat = DataFormat.Default)]
		public List<bool> achivecompleted
		{
			get
			{
				return this._achivecompleted;
			}
		}

		// Token: 0x17001367 RID: 4967
		// (get) Token: 0x06003F50 RID: 16208 RVA: 0x00078B7C File Offset: 0x00076D7C
		// (set) Token: 0x06003F51 RID: 16209 RVA: 0x00078B9D File Offset: 0x00076D9D
		[ProtoMember(7, IsRequired = false, Name = "task_refreshtime", DataFormat = DataFormat.Default)]
		public string task_refreshtime
		{
			get
			{
				return this._task_refreshtime ?? "";
			}
			set
			{
				this._task_refreshtime = value;
			}
		}

		// Token: 0x17001368 RID: 4968
		// (get) Token: 0x06003F52 RID: 16210 RVA: 0x00078BA8 File Offset: 0x00076DA8
		// (set) Token: 0x06003F53 RID: 16211 RVA: 0x00078BC4 File Offset: 0x00076DC4
		[XmlIgnore]
		[Browsable(false)]
		public bool task_refreshtimeSpecified
		{
			get
			{
				return this._task_refreshtime != null;
			}
			set
			{
				bool flag = value == (this._task_refreshtime == null);
				if (flag)
				{
					this._task_refreshtime = (value ? this.task_refreshtime : null);
				}
			}
		}

		// Token: 0x06003F54 RID: 16212 RVA: 0x00078BF4 File Offset: 0x00076DF4
		private bool ShouldSerializetask_refreshtime()
		{
			return this.task_refreshtimeSpecified;
		}

		// Token: 0x06003F55 RID: 16213 RVA: 0x00078C0C File Offset: 0x00076E0C
		private void Resettask_refreshtime()
		{
			this.task_refreshtimeSpecified = false;
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x00078C18 File Offset: 0x00076E18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FBC RID: 4028
		private ErrorCode? _errorcode;

		// Token: 0x04000FBD RID: 4029
		private uint? _exp;

		// Token: 0x04000FBE RID: 4030
		private readonly List<DragonGuildTaskInfo> _taskrecord = new List<DragonGuildTaskInfo>();

		// Token: 0x04000FBF RID: 4031
		private readonly List<bool> _taskcompleted = new List<bool>();

		// Token: 0x04000FC0 RID: 4032
		private readonly List<DragonGuildTaskInfo> _achiverecord = new List<DragonGuildTaskInfo>();

		// Token: 0x04000FC1 RID: 4033
		private readonly List<bool> _achivecompleted = new List<bool>();

		// Token: 0x04000FC2 RID: 4034
		private string _task_refreshtime;

		// Token: 0x04000FC3 RID: 4035
		private IExtension extensionObject;
	}
}
