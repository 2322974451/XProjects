using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000670 RID: 1648
	[ProtoContract(Name = "TajieHelp2DB")]
	[Serializable]
	public class TajieHelp2DB : IExtensible
	{
		// Token: 0x1700212C RID: 8492
		// (get) Token: 0x060068E7 RID: 26855 RVA: 0x000C88AC File Offset: 0x000C6AAC
		[ProtoMember(1, Name = "taJieHelpSceneData", DataFormat = DataFormat.Default)]
		public List<TajieHelpSceneData> taJieHelpSceneData
		{
			get
			{
				return this._taJieHelpSceneData;
			}
		}

		// Token: 0x1700212D RID: 8493
		// (get) Token: 0x060068E8 RID: 26856 RVA: 0x000C88C4 File Offset: 0x000C6AC4
		// (set) Token: 0x060068E9 RID: 26857 RVA: 0x000C88F0 File Offset: 0x000C6AF0
		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		// Token: 0x1700212E RID: 8494
		// (get) Token: 0x060068EA RID: 26858 RVA: 0x000C8900 File Offset: 0x000C6B00
		// (set) Token: 0x060068EB RID: 26859 RVA: 0x000C8920 File Offset: 0x000C6B20
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x060068EC RID: 26860 RVA: 0x000C8964 File Offset: 0x000C6B64
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x060068ED RID: 26861 RVA: 0x000C897C File Offset: 0x000C6B7C
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x060068EE RID: 26862 RVA: 0x000C8988 File Offset: 0x000C6B88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400194D RID: 6477
		private readonly List<TajieHelpSceneData> _taJieHelpSceneData = new List<TajieHelpSceneData>();

		// Token: 0x0400194E RID: 6478
		private int? _updateTime;

		// Token: 0x0400194F RID: 6479
		private IExtension extensionObject;
	}
}
