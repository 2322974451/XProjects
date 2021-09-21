using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000283 RID: 643
	[ProtoContract(Name = "GardenFishInfoRes")]
	[Serializable]
	public class GardenFishInfoRes : IExtensible
	{
		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x060023E0 RID: 9184 RVA: 0x00046084 File Offset: 0x00044284
		// (set) Token: 0x060023E1 RID: 9185 RVA: 0x000460B0 File Offset: 0x000442B0
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

		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x060023E2 RID: 9186 RVA: 0x000460C0 File Offset: 0x000442C0
		// (set) Token: 0x060023E3 RID: 9187 RVA: 0x000460E0 File Offset: 0x000442E0
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

		// Token: 0x060023E4 RID: 9188 RVA: 0x00046124 File Offset: 0x00044324
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060023E5 RID: 9189 RVA: 0x0004613C File Offset: 0x0004433C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x060023E6 RID: 9190 RVA: 0x00046148 File Offset: 0x00044348
		// (set) Token: 0x060023E7 RID: 9191 RVA: 0x00046174 File Offset: 0x00044374
		[ProtoMember(2, IsRequired = false, Name = "fish_level", DataFormat = DataFormat.TwosComplement)]
		public uint fish_level
		{
			get
			{
				return this._fish_level ?? 0U;
			}
			set
			{
				this._fish_level = new uint?(value);
			}
		}

		// Token: 0x17000B2A RID: 2858
		// (get) Token: 0x060023E8 RID: 9192 RVA: 0x00046184 File Offset: 0x00044384
		// (set) Token: 0x060023E9 RID: 9193 RVA: 0x000461A4 File Offset: 0x000443A4
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_levelSpecified
		{
			get
			{
				return this._fish_level != null;
			}
			set
			{
				bool flag = value == (this._fish_level == null);
				if (flag)
				{
					this._fish_level = (value ? new uint?(this.fish_level) : null);
				}
			}
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x000461E8 File Offset: 0x000443E8
		private bool ShouldSerializefish_level()
		{
			return this.fish_levelSpecified;
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x00046200 File Offset: 0x00044400
		private void Resetfish_level()
		{
			this.fish_levelSpecified = false;
		}

		// Token: 0x17000B2B RID: 2859
		// (get) Token: 0x060023EC RID: 9196 RVA: 0x0004620C File Offset: 0x0004440C
		// (set) Token: 0x060023ED RID: 9197 RVA: 0x00046238 File Offset: 0x00044438
		[ProtoMember(3, IsRequired = false, Name = "experiences", DataFormat = DataFormat.TwosComplement)]
		public uint experiences
		{
			get
			{
				return this._experiences ?? 0U;
			}
			set
			{
				this._experiences = new uint?(value);
			}
		}

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x060023EE RID: 9198 RVA: 0x00046248 File Offset: 0x00044448
		// (set) Token: 0x060023EF RID: 9199 RVA: 0x00046268 File Offset: 0x00044468
		[XmlIgnore]
		[Browsable(false)]
		public bool experiencesSpecified
		{
			get
			{
				return this._experiences != null;
			}
			set
			{
				bool flag = value == (this._experiences == null);
				if (flag)
				{
					this._experiences = (value ? new uint?(this.experiences) : null);
				}
			}
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x000462AC File Offset: 0x000444AC
		private bool ShouldSerializeexperiences()
		{
			return this.experiencesSpecified;
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x000462C4 File Offset: 0x000444C4
		private void Resetexperiences()
		{
			this.experiencesSpecified = false;
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x000462D0 File Offset: 0x000444D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008E2 RID: 2274
		private ErrorCode? _result;

		// Token: 0x040008E3 RID: 2275
		private uint? _fish_level;

		// Token: 0x040008E4 RID: 2276
		private uint? _experiences;

		// Token: 0x040008E5 RID: 2277
		private IExtension extensionObject;
	}
}
