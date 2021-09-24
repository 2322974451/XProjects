using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XEmpty : XEntity
	{

		public bool Initilize(XGameObject o)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Empty;
			this._xobject = o;
			this._xobject.Name = this.ID.ToString();
			this.EngineObject.Position = Vector3.zero;
			this.EngineObject.Rotation = Quaternion.identity;
			return true;
		}

		public override void OnCreated()
		{
		}

		public override void Uninitilize()
		{
			base.Uninitilize();
		}

		public override ulong ID
		{
			get
			{
				return this._id;
			}
		}

		public override string Prefab
		{
			get
			{
				return "empty";
			}
		}

		private ulong _id = 0UL;
	}
}
