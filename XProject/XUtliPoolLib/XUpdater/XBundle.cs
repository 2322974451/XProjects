using System;
using System.Collections;
using UnityEngine;

namespace XUpdater
{
	// Token: 0x0200000D RID: 13
	internal sealed class XBundle : MonoBehaviour
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000029C9 File Offset: 0x00000BC9
		public void GetBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			base.StartCoroutine(this.LoadBundle(www, data, callback, load));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000029DE File Offset: 0x00000BDE
		public void GetAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			base.StartCoroutine(this.LoadAsset(bundle, package, callback));
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000029F1 File Offset: 0x00000BF1
		private IEnumerator LoadBundle(WWW www, byte[] data, HandleLoadBundle callback, bool load)
		{
			AssetBundle bundle = null;
			if (load)
			{
				bool flag = www != null;
				if (flag)
				{
					bundle = www.assetBundle;
				}
				else
				{
					bundle = AssetBundle.LoadFromMemory(data);
				}
				yield return null;
			}
			bool flag2 = callback != null;
			if (flag2)
			{
				callback(bundle);
			}
			bool flag3 = www != null;
			if (flag3)
			{
				www.Dispose();
			}
			www = null;
			yield break;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A1D File Offset: 0x00000C1D
		private IEnumerator LoadAsset(AssetBundle bundle, XResPackage package, HandleLoadAsset callback)
		{
			this._assetloader = bundle.LoadAssetAsync(base.name, XUpdater.Ass.GetType(package.type));
			yield return this._assetloader;
			bool flag = callback != null;
			if (flag)
			{
				callback(package, this._assetloader.asset);
			}
			this._assetloader = null;
			yield break;
		}

		// Token: 0x04000028 RID: 40
		private AssetBundleRequest _assetloader = null;
	}
}
