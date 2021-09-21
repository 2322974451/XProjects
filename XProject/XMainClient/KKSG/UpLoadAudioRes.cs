using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000151 RID: 337
	[ProtoContract(Name = "UpLoadAudioRes")]
	[Serializable]
	public class UpLoadAudioRes : IExtensible
	{
		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x00029708 File Offset: 0x00027908
		// (set) Token: 0x06001493 RID: 5267 RVA: 0x00029734 File Offset: 0x00027934
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

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x00029744 File Offset: 0x00027944
		// (set) Token: 0x06001495 RID: 5269 RVA: 0x00029764 File Offset: 0x00027964
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

		// Token: 0x06001496 RID: 5270 RVA: 0x000297A8 File Offset: 0x000279A8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x000297C0 File Offset: 0x000279C0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06001498 RID: 5272 RVA: 0x000297CC File Offset: 0x000279CC
		// (set) Token: 0x06001499 RID: 5273 RVA: 0x000297F9 File Offset: 0x000279F9
		[ProtoMember(2, IsRequired = false, Name = "audiodownuid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiodownuid
		{
			get
			{
				return this._audiodownuid ?? 0UL;
			}
			set
			{
				this._audiodownuid = new ulong?(value);
			}
		}

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x00029808 File Offset: 0x00027A08
		// (set) Token: 0x0600149B RID: 5275 RVA: 0x00029828 File Offset: 0x00027A28
		[XmlIgnore]
		[Browsable(false)]
		public bool audiodownuidSpecified
		{
			get
			{
				return this._audiodownuid != null;
			}
			set
			{
				bool flag = value == (this._audiodownuid == null);
				if (flag)
				{
					this._audiodownuid = (value ? new ulong?(this.audiodownuid) : null);
				}
			}
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0002986C File Offset: 0x00027A6C
		private bool ShouldSerializeaudiodownuid()
		{
			return this.audiodownuidSpecified;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x00029884 File Offset: 0x00027A84
		private void Resetaudiodownuid()
		{
			this.audiodownuidSpecified = false;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x00029890 File Offset: 0x00027A90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400051F RID: 1311
		private ErrorCode? _result;

		// Token: 0x04000520 RID: 1312
		private ulong? _audiodownuid;

		// Token: 0x04000521 RID: 1313
		private IExtension extensionObject;
	}
}
