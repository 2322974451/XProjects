using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000227 RID: 551
	[ProtoContract(Name = "GetSweepTowerRewardRes")]
	[Serializable]
	public class GetSweepTowerRewardRes : IExtensible
	{
		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06001EE5 RID: 7909 RVA: 0x0003CA70 File Offset: 0x0003AC70
		// (set) Token: 0x06001EE6 RID: 7910 RVA: 0x0003CA9C File Offset: 0x0003AC9C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x06001EE7 RID: 7911 RVA: 0x0003CAAC File Offset: 0x0003ACAC
		// (set) Token: 0x06001EE8 RID: 7912 RVA: 0x0003CACC File Offset: 0x0003ACCC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001EE9 RID: 7913 RVA: 0x0003CB10 File Offset: 0x0003AD10
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001EEA RID: 7914 RVA: 0x0003CB28 File Offset: 0x0003AD28
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001EEB RID: 7915 RVA: 0x0003CB34 File Offset: 0x0003AD34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007B6 RID: 1974
		private ErrorCode? _error;

		// Token: 0x040007B7 RID: 1975
		private IExtension extensionObject;
	}
}
