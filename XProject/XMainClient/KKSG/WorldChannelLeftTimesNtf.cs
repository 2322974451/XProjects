using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019D RID: 413
	[ProtoContract(Name = "WorldChannelLeftTimesNtf")]
	[Serializable]
	public class WorldChannelLeftTimesNtf : IExtensible
	{
		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x060018B0 RID: 6320 RVA: 0x000311E0 File Offset: 0x0002F3E0
		// (set) Token: 0x060018B1 RID: 6321 RVA: 0x0003120C File Offset: 0x0002F40C
		[ProtoMember(1, IsRequired = false, Name = "leftTimes", DataFormat = DataFormat.TwosComplement)]
		public uint leftTimes
		{
			get
			{
				return this._leftTimes ?? 0U;
			}
			set
			{
				this._leftTimes = new uint?(value);
			}
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x060018B2 RID: 6322 RVA: 0x0003121C File Offset: 0x0002F41C
		// (set) Token: 0x060018B3 RID: 6323 RVA: 0x0003123C File Offset: 0x0002F43C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimesSpecified
		{
			get
			{
				return this._leftTimes != null;
			}
			set
			{
				bool flag = value == (this._leftTimes == null);
				if (flag)
				{
					this._leftTimes = (value ? new uint?(this.leftTimes) : null);
				}
			}
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x00031280 File Offset: 0x0002F480
		private bool ShouldSerializeleftTimes()
		{
			return this.leftTimesSpecified;
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x00031298 File Offset: 0x0002F498
		private void ResetleftTimes()
		{
			this.leftTimesSpecified = false;
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x000312A4 File Offset: 0x0002F4A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400061D RID: 1565
		private uint? _leftTimes;

		// Token: 0x0400061E RID: 1566
		private IExtension extensionObject;
	}
}
