using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060D RID: 1549
	[ProtoContract(Name = "CampTaskInfo")]
	[Serializable]
	public class CampTaskInfo : IExtensible
	{
		// Token: 0x17001D46 RID: 7494
		// (get) Token: 0x06005D60 RID: 23904 RVA: 0x000B1EE8 File Offset: 0x000B00E8
		// (set) Token: 0x06005D61 RID: 23905 RVA: 0x000B1F14 File Offset: 0x000B0114
		[ProtoMember(1, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
		public uint taskID
		{
			get
			{
				return this._taskID ?? 0U;
			}
			set
			{
				this._taskID = new uint?(value);
			}
		}

		// Token: 0x17001D47 RID: 7495
		// (get) Token: 0x06005D62 RID: 23906 RVA: 0x000B1F24 File Offset: 0x000B0124
		// (set) Token: 0x06005D63 RID: 23907 RVA: 0x000B1F44 File Offset: 0x000B0144
		[XmlIgnore]
		[Browsable(false)]
		public bool taskIDSpecified
		{
			get
			{
				return this._taskID != null;
			}
			set
			{
				bool flag = value == (this._taskID == null);
				if (flag)
				{
					this._taskID = (value ? new uint?(this.taskID) : null);
				}
			}
		}

		// Token: 0x06005D64 RID: 23908 RVA: 0x000B1F88 File Offset: 0x000B0188
		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		// Token: 0x06005D65 RID: 23909 RVA: 0x000B1FA0 File Offset: 0x000B01A0
		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

		// Token: 0x17001D48 RID: 7496
		// (get) Token: 0x06005D66 RID: 23910 RVA: 0x000B1FAC File Offset: 0x000B01AC
		// (set) Token: 0x06005D67 RID: 23911 RVA: 0x000B1FD8 File Offset: 0x000B01D8
		[ProtoMember(2, IsRequired = false, Name = "taskStatus", DataFormat = DataFormat.TwosComplement)]
		public int taskStatus
		{
			get
			{
				return this._taskStatus ?? 0;
			}
			set
			{
				this._taskStatus = new int?(value);
			}
		}

		// Token: 0x17001D49 RID: 7497
		// (get) Token: 0x06005D68 RID: 23912 RVA: 0x000B1FE8 File Offset: 0x000B01E8
		// (set) Token: 0x06005D69 RID: 23913 RVA: 0x000B2008 File Offset: 0x000B0208
		[XmlIgnore]
		[Browsable(false)]
		public bool taskStatusSpecified
		{
			get
			{
				return this._taskStatus != null;
			}
			set
			{
				bool flag = value == (this._taskStatus == null);
				if (flag)
				{
					this._taskStatus = (value ? new int?(this.taskStatus) : null);
				}
			}
		}

		// Token: 0x06005D6A RID: 23914 RVA: 0x000B204C File Offset: 0x000B024C
		private bool ShouldSerializetaskStatus()
		{
			return this.taskStatusSpecified;
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x000B2064 File Offset: 0x000B0264
		private void ResettaskStatus()
		{
			this.taskStatusSpecified = false;
		}

		// Token: 0x06005D6C RID: 23916 RVA: 0x000B2070 File Offset: 0x000B0270
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016B2 RID: 5810
		private uint? _taskID;

		// Token: 0x040016B3 RID: 5811
		private int? _taskStatus;

		// Token: 0x040016B4 RID: 5812
		private IExtension extensionObject;
	}
}
