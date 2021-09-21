using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019F RID: 415
	[ProtoContract(Name = "GetGoddessTrialRewardsRes")]
	[Serializable]
	public class GetGoddessTrialRewardsRes : IExtensible
	{
		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x060018BA RID: 6330 RVA: 0x000312E4 File Offset: 0x0002F4E4
		// (set) Token: 0x060018BB RID: 6331 RVA: 0x00031310 File Offset: 0x0002F510
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

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x060018BC RID: 6332 RVA: 0x00031320 File Offset: 0x0002F520
		// (set) Token: 0x060018BD RID: 6333 RVA: 0x00031340 File Offset: 0x0002F540
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

		// Token: 0x060018BE RID: 6334 RVA: 0x00031384 File Offset: 0x0002F584
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x0003139C File Offset: 0x0002F59C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x060018C0 RID: 6336 RVA: 0x000313A8 File Offset: 0x0002F5A8
		// (set) Token: 0x060018C1 RID: 6337 RVA: 0x000313D4 File Offset: 0x0002F5D4
		[ProtoMember(2, IsRequired = false, Name = "leftGoddessReward", DataFormat = DataFormat.TwosComplement)]
		public uint leftGoddessReward
		{
			get
			{
				return this._leftGoddessReward ?? 0U;
			}
			set
			{
				this._leftGoddessReward = new uint?(value);
			}
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x060018C2 RID: 6338 RVA: 0x000313E4 File Offset: 0x0002F5E4
		// (set) Token: 0x060018C3 RID: 6339 RVA: 0x00031404 File Offset: 0x0002F604
		[XmlIgnore]
		[Browsable(false)]
		public bool leftGoddessRewardSpecified
		{
			get
			{
				return this._leftGoddessReward != null;
			}
			set
			{
				bool flag = value == (this._leftGoddessReward == null);
				if (flag)
				{
					this._leftGoddessReward = (value ? new uint?(this.leftGoddessReward) : null);
				}
			}
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00031448 File Offset: 0x0002F648
		private bool ShouldSerializeleftGoddessReward()
		{
			return this.leftGoddessRewardSpecified;
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x00031460 File Offset: 0x0002F660
		private void ResetleftGoddessReward()
		{
			this.leftGoddessRewardSpecified = false;
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x0003146C File Offset: 0x0002F66C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000620 RID: 1568
		private ErrorCode? _errorcode;

		// Token: 0x04000621 RID: 1569
		private uint? _leftGoddessReward;

		// Token: 0x04000622 RID: 1570
		private IExtension extensionObject;
	}
}
