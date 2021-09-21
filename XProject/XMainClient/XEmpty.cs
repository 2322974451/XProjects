using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D46 RID: 3398
	internal sealed class XEmpty : XEntity
	{
		// Token: 0x0600BC1E RID: 48158 RVA: 0x0026C5BC File Offset: 0x0026A7BC
		public bool Initilize(XGameObject o)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Empty;
			this._xobject = o;
			this._xobject.Name = this.ID.ToString();
			this.EngineObject.Position = Vector3.zero;
			this.EngineObject.Rotation = Quaternion.identity;
			return true;
		}

		// Token: 0x0600BC1F RID: 48159 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnCreated()
		{
		}

		// Token: 0x0600BC20 RID: 48160 RVA: 0x0026C624 File Offset: 0x0026A824
		public override void Uninitilize()
		{
			base.Uninitilize();
		}

		// Token: 0x17003316 RID: 13078
		// (get) Token: 0x0600BC21 RID: 48161 RVA: 0x0026C630 File Offset: 0x0026A830
		public override ulong ID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17003317 RID: 13079
		// (get) Token: 0x0600BC22 RID: 48162 RVA: 0x0026C648 File Offset: 0x0026A848
		public override string Prefab
		{
			get
			{
				return "empty";
			}
		}

		// Token: 0x04004C52 RID: 19538
		private ulong _id = 0UL;
	}
}
