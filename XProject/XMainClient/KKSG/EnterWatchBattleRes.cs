using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017E RID: 382
	[ProtoContract(Name = "EnterWatchBattleRes")]
	[Serializable]
	public class EnterWatchBattleRes : IExtensible
	{
		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x0600172A RID: 5930 RVA: 0x0002E570 File Offset: 0x0002C770
		// (set) Token: 0x0600172B RID: 5931 RVA: 0x0002E59C File Offset: 0x0002C79C
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

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x0600172C RID: 5932 RVA: 0x0002E5AC File Offset: 0x0002C7AC
		// (set) Token: 0x0600172D RID: 5933 RVA: 0x0002E5CC File Offset: 0x0002C7CC
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

		// Token: 0x0600172E RID: 5934 RVA: 0x0002E610 File Offset: 0x0002C810
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x0002E628 File Offset: 0x0002C828
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06001730 RID: 5936 RVA: 0x0002E634 File Offset: 0x0002C834
		// (set) Token: 0x06001731 RID: 5937 RVA: 0x0002E64C File Offset: 0x0002C84C
		[ProtoMember(2, IsRequired = false, Name = "liveInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo liveInfo
		{
			get
			{
				return this._liveInfo;
			}
			set
			{
				this._liveInfo = value;
			}
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x0002E658 File Offset: 0x0002C858
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005BA RID: 1466
		private ErrorCode? _error;

		// Token: 0x040005BB RID: 1467
		private OneLiveRecordInfo _liveInfo = null;

		// Token: 0x040005BC RID: 1468
		private IExtension extensionObject;
	}
}
