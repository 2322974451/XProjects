using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000640 RID: 1600
	[ProtoContract(Name = "IdipHintData")]
	[Serializable]
	public class IdipHintData : IExtensible
	{
		// Token: 0x17001F4F RID: 8015
		// (get) Token: 0x06006358 RID: 25432 RVA: 0x000BD9D4 File Offset: 0x000BBBD4
		// (set) Token: 0x06006359 RID: 25433 RVA: 0x000BDA00 File Offset: 0x000BBC00
		[ProtoMember(1, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public uint systemid
		{
			get
			{
				return this._systemid ?? 0U;
			}
			set
			{
				this._systemid = new uint?(value);
			}
		}

		// Token: 0x17001F50 RID: 8016
		// (get) Token: 0x0600635A RID: 25434 RVA: 0x000BDA10 File Offset: 0x000BBC10
		// (set) Token: 0x0600635B RID: 25435 RVA: 0x000BDA30 File Offset: 0x000BBC30
		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new uint?(this.systemid) : null);
				}
			}
		}

		// Token: 0x0600635C RID: 25436 RVA: 0x000BDA74 File Offset: 0x000BBC74
		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		// Token: 0x0600635D RID: 25437 RVA: 0x000BDA8C File Offset: 0x000BBC8C
		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		// Token: 0x17001F51 RID: 8017
		// (get) Token: 0x0600635E RID: 25438 RVA: 0x000BDA98 File Offset: 0x000BBC98
		// (set) Token: 0x0600635F RID: 25439 RVA: 0x000BDAC4 File Offset: 0x000BBCC4
		[ProtoMember(2, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		// Token: 0x17001F52 RID: 8018
		// (get) Token: 0x06006360 RID: 25440 RVA: 0x000BDAD4 File Offset: 0x000BBCD4
		// (set) Token: 0x06006361 RID: 25441 RVA: 0x000BDAF4 File Offset: 0x000BBCF4
		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		// Token: 0x06006362 RID: 25442 RVA: 0x000BDB38 File Offset: 0x000BBD38
		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		// Token: 0x06006363 RID: 25443 RVA: 0x000BDB50 File Offset: 0x000BBD50
		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		// Token: 0x06006364 RID: 25444 RVA: 0x000BDB5C File Offset: 0x000BBD5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001810 RID: 6160
		private uint? _systemid;

		// Token: 0x04001811 RID: 6161
		private bool? _ishint;

		// Token: 0x04001812 RID: 6162
		private IExtension extensionObject;
	}
}
