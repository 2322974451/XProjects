using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026E RID: 622
	[ProtoContract(Name = "GetSpActivityRewardArg")]
	[Serializable]
	public class GetSpActivityRewardArg : IExtensible
	{
		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x060022AE RID: 8878 RVA: 0x00043C08 File Offset: 0x00041E08
		// (set) Token: 0x060022AF RID: 8879 RVA: 0x00043C34 File Offset: 0x00041E34
		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x060022B0 RID: 8880 RVA: 0x00043C44 File Offset: 0x00041E44
		// (set) Token: 0x060022B1 RID: 8881 RVA: 0x00043C64 File Offset: 0x00041E64
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x00043CA8 File Offset: 0x00041EA8
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x00043CC0 File Offset: 0x00041EC0
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x060022B4 RID: 8884 RVA: 0x00043CCC File Offset: 0x00041ECC
		// (set) Token: 0x060022B5 RID: 8885 RVA: 0x00043CF8 File Offset: 0x00041EF8
		[ProtoMember(2, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x060022B6 RID: 8886 RVA: 0x00043D08 File Offset: 0x00041F08
		// (set) Token: 0x060022B7 RID: 8887 RVA: 0x00043D28 File Offset: 0x00041F28
		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x00043D6C File Offset: 0x00041F6C
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x00043D84 File Offset: 0x00041F84
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x00043D90 File Offset: 0x00041F90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400089C RID: 2204
		private uint? _actid;

		// Token: 0x0400089D RID: 2205
		private uint? _taskid;

		// Token: 0x0400089E RID: 2206
		private IExtension extensionObject;
	}
}
