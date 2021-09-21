using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CF RID: 1487
	[ProtoContract(Name = "BossRushResult")]
	[Serializable]
	public class BossRushResult : IExtensible
	{
		// Token: 0x17001A03 RID: 6659
		// (get) Token: 0x06005405 RID: 21509 RVA: 0x0009FD68 File Offset: 0x0009DF68
		// (set) Token: 0x06005406 RID: 21510 RVA: 0x0009FD94 File Offset: 0x0009DF94
		[ProtoMember(1, IsRequired = false, Name = "currentmax", DataFormat = DataFormat.TwosComplement)]
		public uint currentmax
		{
			get
			{
				return this._currentmax ?? 0U;
			}
			set
			{
				this._currentmax = new uint?(value);
			}
		}

		// Token: 0x17001A04 RID: 6660
		// (get) Token: 0x06005407 RID: 21511 RVA: 0x0009FDA4 File Offset: 0x0009DFA4
		// (set) Token: 0x06005408 RID: 21512 RVA: 0x0009FDC4 File Offset: 0x0009DFC4
		[XmlIgnore]
		[Browsable(false)]
		public bool currentmaxSpecified
		{
			get
			{
				return this._currentmax != null;
			}
			set
			{
				bool flag = value == (this._currentmax == null);
				if (flag)
				{
					this._currentmax = (value ? new uint?(this.currentmax) : null);
				}
			}
		}

		// Token: 0x06005409 RID: 21513 RVA: 0x0009FE08 File Offset: 0x0009E008
		private bool ShouldSerializecurrentmax()
		{
			return this.currentmaxSpecified;
		}

		// Token: 0x0600540A RID: 21514 RVA: 0x0009FE20 File Offset: 0x0009E020
		private void Resetcurrentmax()
		{
			this.currentmaxSpecified = false;
		}

		// Token: 0x17001A05 RID: 6661
		// (get) Token: 0x0600540B RID: 21515 RVA: 0x0009FE2C File Offset: 0x0009E02C
		// (set) Token: 0x0600540C RID: 21516 RVA: 0x0009FE58 File Offset: 0x0009E058
		[ProtoMember(2, IsRequired = false, Name = "lastmax", DataFormat = DataFormat.TwosComplement)]
		public uint lastmax
		{
			get
			{
				return this._lastmax ?? 0U;
			}
			set
			{
				this._lastmax = new uint?(value);
			}
		}

		// Token: 0x17001A06 RID: 6662
		// (get) Token: 0x0600540D RID: 21517 RVA: 0x0009FE68 File Offset: 0x0009E068
		// (set) Token: 0x0600540E RID: 21518 RVA: 0x0009FE88 File Offset: 0x0009E088
		[XmlIgnore]
		[Browsable(false)]
		public bool lastmaxSpecified
		{
			get
			{
				return this._lastmax != null;
			}
			set
			{
				bool flag = value == (this._lastmax == null);
				if (flag)
				{
					this._lastmax = (value ? new uint?(this.lastmax) : null);
				}
			}
		}

		// Token: 0x0600540F RID: 21519 RVA: 0x0009FECC File Offset: 0x0009E0CC
		private bool ShouldSerializelastmax()
		{
			return this.lastmaxSpecified;
		}

		// Token: 0x06005410 RID: 21520 RVA: 0x0009FEE4 File Offset: 0x0009E0E4
		private void Resetlastmax()
		{
			this.lastmaxSpecified = false;
		}

		// Token: 0x06005411 RID: 21521 RVA: 0x0009FEF0 File Offset: 0x0009E0F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001482 RID: 5250
		private uint? _currentmax;

		// Token: 0x04001483 RID: 5251
		private uint? _lastmax;

		// Token: 0x04001484 RID: 5252
		private IExtension extensionObject;
	}
}
