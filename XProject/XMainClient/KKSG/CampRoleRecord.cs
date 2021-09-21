using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060B RID: 1547
	[ProtoContract(Name = "CampRoleRecord")]
	[Serializable]
	public class CampRoleRecord : IExtensible
	{
		// Token: 0x17001D3A RID: 7482
		// (get) Token: 0x06005D3B RID: 23867 RVA: 0x000B1A84 File Offset: 0x000AFC84
		// (set) Token: 0x06005D3C RID: 23868 RVA: 0x000B1AB0 File Offset: 0x000AFCB0
		[ProtoMember(1, IsRequired = false, Name = "lastCampID", DataFormat = DataFormat.TwosComplement)]
		public uint lastCampID
		{
			get
			{
				return this._lastCampID ?? 0U;
			}
			set
			{
				this._lastCampID = new uint?(value);
			}
		}

		// Token: 0x17001D3B RID: 7483
		// (get) Token: 0x06005D3D RID: 23869 RVA: 0x000B1AC0 File Offset: 0x000AFCC0
		// (set) Token: 0x06005D3E RID: 23870 RVA: 0x000B1AE0 File Offset: 0x000AFCE0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastCampIDSpecified
		{
			get
			{
				return this._lastCampID != null;
			}
			set
			{
				bool flag = value == (this._lastCampID == null);
				if (flag)
				{
					this._lastCampID = (value ? new uint?(this.lastCampID) : null);
				}
			}
		}

		// Token: 0x06005D3F RID: 23871 RVA: 0x000B1B24 File Offset: 0x000AFD24
		private bool ShouldSerializelastCampID()
		{
			return this.lastCampIDSpecified;
		}

		// Token: 0x06005D40 RID: 23872 RVA: 0x000B1B3C File Offset: 0x000AFD3C
		private void ResetlastCampID()
		{
			this.lastCampIDSpecified = false;
		}

		// Token: 0x17001D3C RID: 7484
		// (get) Token: 0x06005D41 RID: 23873 RVA: 0x000B1B48 File Offset: 0x000AFD48
		// (set) Token: 0x06005D42 RID: 23874 RVA: 0x000B1B60 File Offset: 0x000AFD60
		[ProtoMember(2, IsRequired = false, Name = "taskInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampTaskInfo2DB taskInfo
		{
			get
			{
				return this._taskInfo;
			}
			set
			{
				this._taskInfo = value;
			}
		}

		// Token: 0x06005D43 RID: 23875 RVA: 0x000B1B6C File Offset: 0x000AFD6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016A9 RID: 5801
		private uint? _lastCampID;

		// Token: 0x040016AA RID: 5802
		private CampTaskInfo2DB _taskInfo = null;

		// Token: 0x040016AB RID: 5803
		private IExtension extensionObject;
	}
}
