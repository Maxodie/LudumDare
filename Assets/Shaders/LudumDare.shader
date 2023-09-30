Shader"Unlit/NewUnlitShader"
{
    Properties
    {
        _StartColor ("Low Health Color",Color) = (0,0,0,0)
        _EndColor ("Full Health Color",Color) = (0,0,0,0)
        _HealthAmout ("Health",range(0,1)) = 0
        _NumberOfPixel ("NumberofPixel",int) = 0
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            float4 _StartColor;
            float4 _EndColor;
            float _StartColorTreshold;
            float _EndColorTreshold;
            float _HealthAmout;
            int _NumberOfPixel;

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolator
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            Interpolator vert (MeshData v)
            {
                Interpolator o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                o.uv = v.uv;
                return o;
            }

            float4 frag (Interpolator i) : SV_Target
            {
                float4 col = lerp(_StartColor,_EndColor, _HealthAmout);
                
                float a = floor(_HealthAmout*_NumberOfPixel)/_NumberOfPixel;
                a = (a > i.uv)*2-1;
                col = col*a;
                clip(col);
                return col;
            }
            ENDCG
        }
    }
}
