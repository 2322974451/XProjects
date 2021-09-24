

using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
    public sealed class ShaderManager : XSingleton<ShaderManager>
    {
        private static Shader m_skin_effect = (Shader)null;
        private static Shader m_skin8 = (Shader)null;
        private static Shader m_skin_blend = (Shader)null;
        private static Shader m_skin_cutout = (Shader)null;
        private static Shader m_skin_cutout4 = (Shader)null;
        private static Shader m_fade_maskR_noLight = (Shader)null;
        private static Shader m_transparentGrayMaskRNoLight = (Shader)null;
        private static Shader m_color = (Shader)null;
        private static Shader m_maskR = (Shader)null;
        public static Shader _maskG;
        public static Shader _maskB;
        public static Shader _maskA;
        private static Shader m_radialBlur = (Shader)null;
        private static Shader m_blackWhite = (Shader)null;
        private static Shader m_gausBlur = (Shader)null;
        private AssetBundle m_ShaderAB = (AssetBundle)null;
        public static int _ShaderKeyMainTex;
        public static int _ShaderKeyMaskTex;
        public static int _ShaderKeyIDColor0;
        public static int _ShaderKeyIDHairColor;
        public static int _ShaderKeyIDFace;
        public static int _ShaderKeyIDHair;
        public static int _ShaderKeyIDBody;
        public static int _ShaderKeyIDAlpha;
        public static int[] _ShaderKeyIDSkin = new int[8];

        public static Shader _skin_effect
        {
            get
            {
                if ((Object)ShaderManager.m_skin_effect == (Object)null)
                    ShaderManager.m_skin_effect = XSingleton<ShaderManager>.singleton.FindShader("Skin-Effect", "Custom/Skin/Effect");
                return ShaderManager.m_skin_effect;
            }
        }

        public static Shader _skin8
        {
            get
            {
                if ((Object)ShaderManager.m_skin8 == (Object)null)
                    ShaderManager.m_skin8 = XSingleton<ShaderManager>.singleton.FindShader("Skin-RimLightBlend8", "Custom/Skin/RimlightBlend8");
                return ShaderManager.m_skin8;
            }
        }

        public static Shader _skin_blend
        {
            get
            {
                if ((Object)ShaderManager.m_skin_blend == (Object)null)
                    ShaderManager.m_skin_blend = XSingleton<ShaderManager>.singleton.FindShader("Skin-RimLightBlend", "Custom/Skin/RimlightBlend");
                return ShaderManager.m_skin_blend;
            }
        }

        public static Shader _skin_cutout
        {
            get
            {
                if ((Object)ShaderManager.m_skin_cutout == (Object)null)
                    ShaderManager.m_skin_cutout = XSingleton<ShaderManager>.singleton.FindShader("Skin-RimLightBlendCutout", "Custom/Skin/RimlightBlendCutout");
                return ShaderManager.m_skin_cutout;
            }
        }

        public static Shader _skin_cutout4
        {
            get
            {
                if ((Object)ShaderManager.m_skin_cutout4 == (Object)null)
                    ShaderManager.m_skin_cutout4 = XSingleton<ShaderManager>.singleton.FindShader("Skin-RimLightBlendCutout4", "Custom/Skin/RimlightBlendCutout4");
                return ShaderManager.m_skin_cutout4;
            }
        }

        public static Shader _fade_maskR_noLight
        {
            get
            {
                if ((Object)ShaderManager.m_fade_maskR_noLight == (Object)null)
                    ShaderManager.m_fade_maskR_noLight = XSingleton<ShaderManager>.singleton.FindShader("FadeMaskRNoLight", "Custom/Common/FadeMaskRNoLight");
                return ShaderManager.m_fade_maskR_noLight;
            }
        }

        public static Shader _transparentGrayMaskRNoLight
        {
            get
            {
                if ((Object)ShaderManager.m_transparentGrayMaskRNoLight == (Object)null)
                    ShaderManager.m_transparentGrayMaskRNoLight = XSingleton<ShaderManager>.singleton.FindShader("TransparentGrayMaskRNoLight", "Custom/Common/TransparentGrayMaskRNoLight");
                return ShaderManager.m_transparentGrayMaskRNoLight;
            }
        }

        public static Shader _color
        {
            get
            {
                if ((Object)ShaderManager.m_color == (Object)null)
                    ShaderManager.m_color = Shader.Find("Custom/Effect/Color");
                return ShaderManager.m_color;
            }
        }

        public static Shader _maskR
        {
            get
            {
                if ((Object)ShaderManager.m_maskR == (Object)null)
                    ShaderManager.m_maskR = XSingleton<ShaderManager>.singleton.FindShader("CustomShadowR", "Custom/Scene/CustomShadowR");
                return ShaderManager.m_maskR;
            }
        }

        public static Shader _radialBlur
        {
            get
            {
                if ((Object)ShaderManager.m_radialBlur == (Object)null)
                    ShaderManager.m_radialBlur = XSingleton<ShaderManager>.singleton.FindShader("RadialBlur", "Hidden/radialBlur");
                return ShaderManager.m_radialBlur;
            }
        }

        public static Shader _blackWhite
        {
            get
            {
                if ((Object)ShaderManager.m_blackWhite == (Object)null)
                    ShaderManager.m_blackWhite = XSingleton<ShaderManager>.singleton.FindShader("BlackWhite", "Hidden/blackWhite");
                return ShaderManager.m_blackWhite;
            }
        }

        public static Shader _gausBlur
        {
            get
            {
                if ((Object)ShaderManager.m_gausBlur == (Object)null)
                    ShaderManager.m_gausBlur = XSingleton<ShaderManager>.singleton.FindShader("BlurEffectConeTaps", "Hidden/BlurEffectConeTap");
                return ShaderManager.m_gausBlur;
            }
        }

        public bool Awake(RuntimePlatform editorPlatform)
        {
            ShaderManager._ShaderKeyMainTex = Shader.PropertyToID("_MainTex");
            ShaderManager._ShaderKeyMaskTex = Shader.PropertyToID("_Mask");
            ShaderManager._ShaderKeyIDColor0 = Shader.PropertyToID("_Color");
            ShaderManager._ShaderKeyIDHairColor = Shader.PropertyToID("_HairColor");
            ShaderManager._ShaderKeyIDFace = Shader.PropertyToID("_Face");
            ShaderManager._ShaderKeyIDHair = Shader.PropertyToID("_Hair");
            ShaderManager._ShaderKeyIDBody = Shader.PropertyToID("_Body");
            ShaderManager._ShaderKeyIDAlpha = Shader.PropertyToID("_Alpha");
            for (int index = 0; index < ShaderManager._ShaderKeyIDSkin.Length; ++index)
                ShaderManager._ShaderKeyIDSkin[index] = Shader.PropertyToID("_Tex" + index.ToString());
            string path = (string)null;
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    path = string.Format("{0}/Raw/update/iOS/AssetBundles/shaders.ab", (object)Application.dataPath);
                    break;
                case RuntimePlatform.Android:
                    path = string.Format("{0}!assets/update/Android/AssetBundles/shaders.ab", (object)Application.dataPath);
                    break;
                default:
                    switch (editorPlatform)
                    {
                        case RuntimePlatform.WindowsPlayer:
                            path = string.Format("{0}/update/AssetBundles/shaders.ab", (object)Application.streamingAssetsPath);
                            break;
                        case RuntimePlatform.IPhonePlayer:
                            path = string.Format("{0}/update/iOS/AssetBundles/shaders.ab", (object)Application.streamingAssetsPath);
                            break;
                        case RuntimePlatform.Android:
                            path = string.Format("{0}/update/Android/AssetBundles/shaders.ab", (object)Application.streamingAssetsPath);
                            break;
                    }
                    if (!File.Exists(path))
                    {
                        path = (string)null;
                        break;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(path))
                this.m_ShaderAB = AssetBundle.LoadFromFile(path);
            return true;
        }

        public Shader FindShader(string name0, string name1)
        {
            Shader shader = (Shader)null;
            if ((Object)this.m_ShaderAB != (Object)null)
                shader = this.m_ShaderAB.LoadAsset<Shader>(name0);
            if ((Object)shader == (Object)null)
                shader = Shader.Find(name1);
            return shader;
        }

        public static void SetColor32(MaterialPropertyBlock mpb, Color32 color, int keyID) => mpb.SetColor(keyID, (Color)color);

        public static void SetColor(MaterialPropertyBlock mpb, Color color, int keyID) => mpb.SetColor(keyID, color);

        public static void SetTexture(MaterialPropertyBlock mpb, Texture tex, int keyID)
        {
            if (!((Object)tex != (Object)null))
                return;
            mpb.SetTexture(keyID, tex);
        }

        public static void SetFloat(MaterialPropertyBlock mpb, float value, int keyID) => mpb.SetFloat(keyID, value);
    }
}
