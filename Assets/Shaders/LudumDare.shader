Shader"Unlit/NewUnlitShader"
{



    Properties
    {
        _StartColor ("Low Health Color",Color) = (0,0,0,0)
        _EndColor ("Full Health Color",Color) = (0,0,0,0)
        _BackgroundTex ("background Color",2D) = "white" {}
        _Sprite ("Sprite", 2D) = "white" {}
        _HealthAmout ("Health",range(0,1)) = 0
        _YOffset ("YOffset",range(0,.5)) = 0
        _XOffset ("XOffset",range(0,.5)) = 0
        _SpeedOfShaking("Speed of Shaking",float) = 0
        _DeltaLeftRight("Difference of time between left and right",range(0,1)) = 0.5
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #define TAU 6.28318530718

            #include "UnityCG.cginc"

            float4 _StartColor;
            float4 _EndColor;
            sampler2D _BackgroundTex;
            sampler2D _Sprite;
            float _HealthAmout;
            float _YOffset;
            float _XOffset;
            float _SpeedOfShaking;
            float _DeltaLeftRight;

            float triangleSignal(float t)
            {
                return (abs(frac(t)-0.5));
            }

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
                o.vertex = o.vertex + float4(_XOffset,_YOffset,0,0)*(triangleSignal(_Time.y*_SpeedOfShaking + v.uv.x*_DeltaLeftRight));
                o.uv = v.uv;
                return o;
            }

            float4 frag (Interpolator i) : SV_Target
            {
                float4 col = lerp(_StartColor,_EndColor, _HealthAmout);
                float a = _HealthAmout;
                
                a = (a > i.uv);

                float4 t = tex2D(_Sprite, i.uv);
                
                float2 backgroundXY = i.uv;
                backgroundXY.x = frac(backgroundXY.x /16 * 100);

                float4 backgroundColor = tex2D(_BackgroundTex, backgroundXY);


                col = (col * a + backgroundColor * (1-a)) * (t == 1) + t * (t != 1);
                //col = (col * a) * (t == 1) + t * (t != 1) + backgroundColor;



                return col;
            }
            ENDCG
        }
    }
}
