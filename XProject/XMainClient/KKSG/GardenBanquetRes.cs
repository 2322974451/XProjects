using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000273 RID: 627
	[ProtoContract(Name = "GardenBanquetRes")]
	[Serializable]
	public class GardenBanquetRes : IExtensible
	{
		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x060022DC RID: 8924 RVA: 0x00044154 File Offset: 0x00042354
		// (set) Token: 0x060022DD RID: 8925 RVA: 0x00044180 File Offset: 0x00042380
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

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x060022DE RID: 8926 RVA: 0x00044190 File Offset: 0x00042390
		// (set) Token: 0x060022DF RID: 8927 RVA: 0x000441B0 File Offset: 0x000423B0
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

		// Token: 0x060022E0 RID: 8928 RVA: 0x000441F4 File Offset: 0x000423F4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060022E1 RID: 8929 RVA: 0x0004420C File Offset: 0x0004240C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x060022E2 RID: 8930 RVA: 0x00044218 File Offset: 0x00042418
		// (set) Token: 0x060022E3 RID: 8931 RVA: 0x00044244 File Offset: 0x00042444
		[ProtoMember(2, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_id
		{
			get
			{
				return this._banquet_id ?? 0U;
			}
			set
			{
				this._banquet_id = new uint?(value);
			}
		}

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x060022E4 RID: 8932 RVA: 0x00044254 File Offset: 0x00042454
		// (set) Token: 0x060022E5 RID: 8933 RVA: 0x00044274 File Offset: 0x00042474
		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_idSpecified
		{
			get
			{
				return this._banquet_id != null;
			}
			set
			{
				bool flag = value == (this._banquet_id == null);
				if (flag)
				{
					this._banquet_id = (value ? new uint?(this.banquet_id) : null);
				}
			}
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x000442B8 File Offset: 0x000424B8
		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x000442D0 File Offset: 0x000424D0
		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x060022E8 RID: 8936 RVA: 0x000442DC File Offset: 0x000424DC
		[ProtoMember(3, Name = "guests", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> guests
		{
			get
			{
				return this._guests;
			}
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x000442F4 File Offset: 0x000424F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008A7 RID: 2215
		private ErrorCode? _result;

		// Token: 0x040008A8 RID: 2216
		private uint? _banquet_id;

		// Token: 0x040008A9 RID: 2217
		private readonly List<ulong> _guests = new List<ulong>();

		// Token: 0x040008AA RID: 2218
		private IExtension extensionObject;
	}
}
