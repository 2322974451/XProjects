using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D6 RID: 1238
	[ProtoContract(Name = "GoalAwardsGetAwards_M2C")]
	[Serializable]
	public class GoalAwardsGetAwards_M2C : IExtensible
	{
		// Token: 0x170013A2 RID: 5026
		// (get) Token: 0x06004025 RID: 16421 RVA: 0x0007A2C4 File Offset: 0x000784C4
		// (set) Token: 0x06004026 RID: 16422 RVA: 0x0007A2F0 File Offset: 0x000784F0
		[ProtoMember(1, IsRequired = false, Name = "gottenAwardsIndex", DataFormat = DataFormat.TwosComplement)]
		public uint gottenAwardsIndex
		{
			get
			{
				return this._gottenAwardsIndex ?? 0U;
			}
			set
			{
				this._gottenAwardsIndex = new uint?(value);
			}
		}

		// Token: 0x170013A3 RID: 5027
		// (get) Token: 0x06004027 RID: 16423 RVA: 0x0007A300 File Offset: 0x00078500
		// (set) Token: 0x06004028 RID: 16424 RVA: 0x0007A320 File Offset: 0x00078520
		[XmlIgnore]
		[Browsable(false)]
		public bool gottenAwardsIndexSpecified
		{
			get
			{
				return this._gottenAwardsIndex != null;
			}
			set
			{
				bool flag = value == (this._gottenAwardsIndex == null);
				if (flag)
				{
					this._gottenAwardsIndex = (value ? new uint?(this.gottenAwardsIndex) : null);
				}
			}
		}

		// Token: 0x06004029 RID: 16425 RVA: 0x0007A364 File Offset: 0x00078564
		private bool ShouldSerializegottenAwardsIndex()
		{
			return this.gottenAwardsIndexSpecified;
		}

		// Token: 0x0600402A RID: 16426 RVA: 0x0007A37C File Offset: 0x0007857C
		private void ResetgottenAwardsIndex()
		{
			this.gottenAwardsIndexSpecified = false;
		}

		// Token: 0x170013A4 RID: 5028
		// (get) Token: 0x0600402B RID: 16427 RVA: 0x0007A388 File Offset: 0x00078588
		// (set) Token: 0x0600402C RID: 16428 RVA: 0x0007A3B4 File Offset: 0x000785B4
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170013A5 RID: 5029
		// (get) Token: 0x0600402D RID: 16429 RVA: 0x0007A3C4 File Offset: 0x000785C4
		// (set) Token: 0x0600402E RID: 16430 RVA: 0x0007A3E4 File Offset: 0x000785E4
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

		// Token: 0x0600402F RID: 16431 RVA: 0x0007A428 File Offset: 0x00078628
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004030 RID: 16432 RVA: 0x0007A440 File Offset: 0x00078640
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06004031 RID: 16433 RVA: 0x0007A44C File Offset: 0x0007864C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FF9 RID: 4089
		private uint? _gottenAwardsIndex;

		// Token: 0x04000FFA RID: 4090
		private ErrorCode? _errorcode;

		// Token: 0x04000FFB RID: 4091
		private IExtension extensionObject;
	}
}
