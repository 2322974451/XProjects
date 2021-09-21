using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000269 RID: 617
	[ProtoContract(Name = "FriendGardenPlantLogRes")]
	[Serializable]
	public class FriendGardenPlantLogRes : IExtensible
	{
		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x06002269 RID: 8809 RVA: 0x000433CC File Offset: 0x000415CC
		// (set) Token: 0x0600226A RID: 8810 RVA: 0x000433F8 File Offset: 0x000415F8
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

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x0600226B RID: 8811 RVA: 0x00043408 File Offset: 0x00041608
		// (set) Token: 0x0600226C RID: 8812 RVA: 0x00043428 File Offset: 0x00041628
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

		// Token: 0x0600226D RID: 8813 RVA: 0x0004346C File Offset: 0x0004166C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x00043484 File Offset: 0x00041684
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x0600226F RID: 8815 RVA: 0x00043490 File Offset: 0x00041690
		[ProtoMember(2, Name = "frinend_plant_log", DataFormat = DataFormat.Default)]
		public List<FriendPlantLog> frinend_plant_log
		{
			get
			{
				return this._frinend_plant_log;
			}
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x000434A8 File Offset: 0x000416A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000889 RID: 2185
		private ErrorCode? _result;

		// Token: 0x0400088A RID: 2186
		private readonly List<FriendPlantLog> _frinend_plant_log = new List<FriendPlantLog>();

		// Token: 0x0400088B RID: 2187
		private IExtension extensionObject;
	}
}
