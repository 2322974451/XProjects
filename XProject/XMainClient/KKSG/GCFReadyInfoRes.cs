using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000331 RID: 817
	[ProtoContract(Name = "GCFReadyInfoRes")]
	[Serializable]
	public class GCFReadyInfoRes : IExtensible
	{
		// Token: 0x17000DF8 RID: 3576
		// (get) Token: 0x06002D05 RID: 11525 RVA: 0x0005726C File Offset: 0x0005546C
		[ProtoMember(1, Name = "allinfo", DataFormat = DataFormat.Default)]
		public List<GCFZhanChBriefInfo> allinfo
		{
			get
			{
				return this._allinfo;
			}
		}

		// Token: 0x17000DF9 RID: 3577
		// (get) Token: 0x06002D06 RID: 11526 RVA: 0x00057284 File Offset: 0x00055484
		// (set) Token: 0x06002D07 RID: 11527 RVA: 0x000572B0 File Offset: 0x000554B0
		[ProtoMember(2, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000DFA RID: 3578
		// (get) Token: 0x06002D08 RID: 11528 RVA: 0x000572C0 File Offset: 0x000554C0
		// (set) Token: 0x06002D09 RID: 11529 RVA: 0x000572E0 File Offset: 0x000554E0
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06002D0A RID: 11530 RVA: 0x00057324 File Offset: 0x00055524
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002D0B RID: 11531 RVA: 0x0005733C File Offset: 0x0005553C
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06002D0C RID: 11532 RVA: 0x00057348 File Offset: 0x00055548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B29 RID: 2857
		private readonly List<GCFZhanChBriefInfo> _allinfo = new List<GCFZhanChBriefInfo>();

		// Token: 0x04000B2A RID: 2858
		private uint? _lefttime;

		// Token: 0x04000B2B RID: 2859
		private IExtension extensionObject;
	}
}
